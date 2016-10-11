using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Data.SQLite;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QifFilter
{
    public partial class frmQifFilter : Form
    {
			private string sFmtDecOrig;
			private string sFmtDecDest;
			private string strFilename;
			private string strFileNameNew;
			List<TransactionItem> transList = null;
			string strHeader = String.Empty;
      private SQLiteConnection conn;
			private DateTime? fechaMayor;
			private QifFilterSettings filterSettings;
			private string tag = string.Empty;


			public frmQifFilter()
			{
						InitializeComponent();

						this.cboFormatos.Items.Add("Palm-Money");
						this.cboFormatos.Items.Add("Palm-Quicken");
						this.cboFormatos.Items.Add("Money-Quicken");
						this.cboFormatos.Items.Add("Money-Palm");
						this.cboFormatos.Items.Add("Quicken-Palm");
						this.cboFormatos.Items.Add("Quicken-Money");
						this.cboFormatos.Items.Add("Finacisto-Quicken");
						this.cboFormatos.Items.Add("Mercantil-Quicken");

                        this.cboTipoCuenta.Items.Add("Efectivo");
                        this.cboTipoCuenta.Items.Add("Banco");
                        this.cboTipoCuenta.Items.Add("Tarjeta Credito");

						//añado los formatos de fecha
						string[] sFormatos = 
								 new string[]
											{"dd/MM/yyyy","MM/dd/yyyy",
											 "dd/MM'yyyy", "MM/dd'yyyy", 
											 "M/d'yy"};
						this.cboTipoFechaIn.Items.AddRange(sFormatos);
						this.cboTipoFechaOut.Items.AddRange (sFormatos);
						
						this.cboTipoSeparador.Items.AddRange(new string[]{"Sin Cambios", "Coma-Punto", "Punto-Coma"});
						this.dtpFecDes.Value = DateTime.Now;
						this.dtpFecHas.Value = DateTime.Now;
		  }

			private void driveListBox1_SelectedIndexChanged(object sender, EventArgs e)
			{
				this.dirListBox1.Path = this.driveListBox1.Drive;
			}

			void dirListBox1_Change(object sender, System.EventArgs e)
			{
				this.fileListBox1.Path = this.dirListBox1.Path;
			}

			private void btnSalir_Click(object sender, EventArgs e)
			{
				this.Close();
			}

			private void btnProcesar_Click(object sender, EventArgs e)
			{
				//string strFilename;           
				string strFecha;
				DateTime dFecha;
				string strLinea;
				int cntLinea;
				bool bolGraba;
				DestinationAccountTypes accountType = DestinationAccountTypes.Cash;

				string sFmtFecIN;
				string sFmtFecOut; 


				ValidarSelecciones();

				ValidarFormatosDecimales();

				ValidarRutaArchivos();

				transList = new List<TransactionItem>();
				TransactionItem trans = null; 

				cntLinea = 0;
				bolGraba = true;

				using (StreamReader sr = File.OpenText(strFilename))
				{
						while ((strLinea = sr.ReadLine()) != null)
						{
							cntLinea++;

							if (strHeader == String.Empty && cntLinea==1)
							{
								strHeader = strLinea;
							}
							else if (strHeader != string.Empty && cntLinea == 1 && strLinea.Contains("!Type"))
							{
								strHeader = strLinea;
							}
							

							strLinea = strLinea.Replace("\t", "");

								if (strLinea.Trim() != "^")
								{                       
										if (strLinea.Substring(0, 1) == "D")
										{
												trans = new TransactionItem();

												bolGraba = false;
												strFecha = strLinea.Substring(1);
													 
												sFmtFecIN = this.cboTipoFechaIn.SelectedItem.ToString().Replace("'"," ");

												dFecha = ValidarFechas(strFecha, ref bolGraba, sFmtFecIN);

												sFmtFecOut = this.cboTipoFechaOut.SelectedItem.ToString().Replace("'", " ");
												strLinea = string.Format("{0:" + sFmtFecOut + "}", dFecha);
												strLinea = strLinea.Replace(" ", "'");
												trans.Date = strLinea;
												strLinea = string.Format("D{0}", strLinea); 
										}
										else
										{
												if (sFmtDecOrig != "")
														if (strLinea.Substring(0, 1) == "T")
																strLinea.Replace(sFmtDecOrig, sFmtDecDest);

												if (strLinea.Trim() == "!Account") bolGraba = false;

												if (strLinea.Trim().Contains("!Type") && !strLinea.Trim().Contains("!Type:Cat"))
												{
													accountType = ObtenerTipoCuenta(strLinea.Trim());
												}


												if (strLinea != "" && !strLinea.Contains(@"!Type") && trans != null)
													if (bolGraba == true)
													{
														switch (strLinea.Substring(0, 1))
														{
															case "T":
																trans.Amount = strLinea.Substring(1);
																break;
															case "L":
																trans.Category = strLinea.Substring(1);
																break;
															case "P":
																trans.Payee = strLinea.Substring(1);
																break;
															case "M":
																trans.Memo = strLinea.Substring(1);
																break;
															default:
																trans.OtherField = strLinea;
																break;
														}

														if (trans.Category != null && trans.Category.Contains("["))
														{
                                                            if (!chkAvoidTransfers.Checked)
                                                            {
                                                                trans.Payee = GetTransferPayee(trans, accountType);
                                                                if (!string.IsNullOrEmpty(tag))
                                                                    trans.Category += "/" + tag;
                                                            }
                                                            else
                                                            {
                                                                bolGraba = false;
                                                            }
														}
													}
										}
								}
								else
								{
										if (cntLinea > 1 && this.cboFormatos.Text == "Mercantil-Quicken")
										{
											AdaptarFormatoMercantil(ref trans);
										}

										if (bolGraba == true)
											transList.Add(trans);

										cntLinea = 0;
										tag = string.Empty;
										bolGraba = false;
								}
						}
				}

				if (transList.Count != 0)
				{
					this.SalvarResultados();
				}

        this.SaveLog();

				MessageBox.Show("Proceso Finalizado!!!");
		  }

			private string GetTransferPayee(TransactionItem trans, DestinationAccountTypes accountType)
			{
				QifFilterSettings settings = QifFilterSettings.GetCurrent();
				string result = string.Empty;


				Match match = Regex.Match(trans.Category, @"\[(\w*)]");
			  string accountName = match.Groups[1].ToString();


				foreach (TransfersInfo item in settings.TranfersRules.ListTransferInfo)
				{
					if (item.AccountName == accountName && item.DestAccountType == accountType)
						{
							if (trans.Amount.Contains("-"))
							{
								result = item.WithdrawalPayee;
							}
							else
							{
								result = item.DepositPayee;
							}
							tag = item.Tag;
						}					
				}

				return result;
			}

			private DestinationAccountTypes ObtenerTipoCuenta(string valorTexto)
			{
				DestinationAccountTypes result = DestinationAccountTypes.Cash;

				if (valorTexto == "!Type:Cash")
					result = DestinationAccountTypes.Cash;
				else if (valorTexto == "!Type:Bank")
					result = DestinationAccountTypes.Bank;
				else if (valorTexto == "!Type:CCard")
					result = DestinationAccountTypes.Credit;

				return result;
			}

				private void ValidarRutaArchivos()
				{
						int iLenPath = this.fileListBox1.Path.Length;
						string sPathEndChar = this.fileListBox1.Path.Substring(--iLenPath, 1);
						strFilename = this.fileListBox1.Path;
						bool bValPath = sPathEndChar.Equals(@"\");
						if (!bValPath) strFilename += @"\";
						strFilename += this.fileListBox1.FileName;
						strFileNameNew = strFilename;
						StringBuilder objRuta = new StringBuilder();
						objRuta.Append(strFileNameNew.ToLower());
						objRuta.Replace(".qif", "-NEW.qif");
						strFileNameNew = objRuta.ToString();
				}

				private void ValidarFormatosDecimales()
				{
          if (this.cboTipoSeparador.SelectedItem == null)
          {
            sFmtDecOrig = "";
            sFmtDecDest = "";
            return;
          }

					if (this.cboTipoSeparador.SelectedItem.ToString() == "Coma-Punto")
					{
						sFmtDecOrig = ",";
						sFmtDecDest = ".";
					}
					else if (this.cboTipoSeparador.SelectedItem.ToString() == "Punto-Coma")
					{
						sFmtDecOrig = ".";
						sFmtDecDest = ",";
					}
					else
					{
						sFmtDecOrig = "";
						sFmtDecDest = "";
					}
				}

				private DateTime ValidarFechas(string strFecha, ref bool bolGraba, string sFmtFecIN)
				{
						DateTime dFecha;
						DateTime.TryParseExact(strFecha, sFmtFecIN, null, DateTimeStyles.None, out dFecha);
						

						if (this.chkFiltrarFechas.CheckState == CheckState.Checked)
						{
								if (dFecha >= DateTime.Parse(this.dtpFecDes.Value.ToShortDateString()) &&
										dFecha <= DateTime.Parse(this.dtpFecHas.Value.ToShortDateString()))
								{
										bolGraba = true;

										if (fechaMayor == null)
											fechaMayor = dFecha;
										else if (dFecha > fechaMayor)
											fechaMayor = dFecha;
								}
						}
						else
						{
								bolGraba = true;

								if (fechaMayor == null)
									fechaMayor = dFecha;
								else if (dFecha > fechaMayor)
									fechaMayor = dFecha;

						}
						return dFecha;
				}

				private void ValidarSelecciones()
				{
						//valido las fechas
						if (this.chkFiltrarFechas.Checked = true && DateTime.Compare(this.dtpFecHas.Value, this.dtpFecDes.Value) < 0)
						{
								MessageBox.Show("La Fecha Final no puede ser menor a la inicial", "Fechas Incorrectas", MessageBoxButtons.OK);
								this.Close();
						}

						if (this.fileListBox1.FileName == "")
						{
								MessageBox.Show("Debe Seleccionar un Archivo para Poder continuar", "Debe seleccionar un Archivo", MessageBoxButtons.OK);
								this.Close();
						}

						if (this.cboTipoFechaIn.SelectedItem.ToString() == "" || this.cboTipoFechaOut.SelectedItem.ToString() == "")
						{
								MessageBox.Show("Debe Seleccionar los formatos de fecha de entrada y de salida", "Faltan datos", MessageBoxButtons.OK);
								this.Close();
						}
				}

				private void AdaptarFormatoMercantil(ref TransactionItem trans)
				{
					string memo;

					memo = trans.Memo.Replace("ND- ", "");
					MercantilRules mercantilRules = new MercantilRules();

					foreach (MercantilRulesInfo info in mercantilRules.ListaReglas)
					{
						if (memo.Contains(info.SourceText))
						{
							trans.Payee = info.Payee;
							trans.Category = info.Category;
							break;
						}
					}
				}

				private void SalvarResultados()
				{
					if (File.Exists(strFileNameNew))
						File.Delete(strFileNameNew);

					FileStream ofs = new FileStream(strFileNameNew, FileMode.Create);
					StreamWriter stream = new StreamWriter(ofs);

					//quicken no permite importar de .qif a cuentas bancarias.
					//por lo tanto la importación la hago a una cuenta temporal.
					if (this.cboFormatos.Text == "Mercantil-Quicken")
						stream.WriteLine("!Type:Cash");
					else
						stream.WriteLine(strHeader);

					foreach (TransactionItem item in this.transList)
					{
            if (item == null)
              continue;

						stream.WriteLine(item.ToString());
						stream.WriteLine("^");
					}

					stream.Flush();
					stream.Close();
					ofs.Close();
					ofs.Dispose();
				}

				private void cboFormatos_SelectedIndexChanged(object sender, EventArgs e)
				{
					switch (this.cboFormatos.SelectedItem.ToString())
					{
							case "Money-Quicken":
									this.cboTipoFechaIn.SelectedIndex = 2;  //dd/MM'yyyy  
									this.cboTipoFechaOut.SelectedIndex = 4; //m/d'yy 
									break;

							case "Quicken-Money":
									this.cboTipoFechaIn.SelectedIndex = 4;  //m/d'yy
									this.cboTipoFechaOut.SelectedIndex = 2;  //dd/MM'yyyy  
									break;

							case "Finacisto-Quicken":
									this.cboTipoFechaIn.SelectedIndex = 1;  //MM/dd/yyyy
									this.cboTipoFechaOut.SelectedIndex = 4; //m/d'yy 
									break;

							case "Mercantil-Quicken":
									this.cboTipoFechaIn.SelectedIndex = 1;  //MM/dd/yyyy
									this.cboTipoFechaOut.SelectedIndex = 4; //m/d'yy 
									break;
					}
				}

                private void SaveLog()
                {
                    string dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "logdb.db3");
                    conn = new SQLiteConnection(string.Format("Data Source = {0}", dbPath));

                    try
                    {
                        conn.Open();
                    }
                    catch 
                    {
                        return;
                    }

                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandType = CommandType.Text;

                    string insSql = "INSERT INTO historylog (filepath, source_format_id, dest_format_id, decimal_separator_id, first_date, last_date, last_date_file, date_created) VALUES (";
                    insSql += "@filepath, @source_format_id, @dest_format_id, @decimal_separator_id, @first_date, @last_date, @last_date_file, @date_created)";

                    cmd.CommandText = insSql;
                    cmd.Parameters.AddWithValue("@filepath", strFilename);
                    cmd.Parameters.AddWithValue("@source_format_id", GetFKId("formats", cboTipoFechaIn.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@dest_format_id", GetFKId("formats", cboTipoFechaOut.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@decimal_separator_id", GetFKId("decimal_separators", (string.IsNullOrEmpty(cboTipoSeparador.SelectedItem.ToString())?"Sin Cambios":cboTipoSeparador.SelectedItem.ToString())));

                    if (this.dtpFecDes.Value == null)
                        cmd.Parameters.AddWithValue("@first_date", null);
                    else
                        cmd.Parameters.AddWithValue("@first_date", DateTimeSQLite(this.dtpFecDes.Value));

                    if (this.dtpFecHas.Value == null)
                        cmd.Parameters.AddWithValue("@last_date", null);
                    else
                        cmd.Parameters.AddWithValue("@last_date", DateTimeSQLite(this.dtpFecHas.Value));

										cmd.Parameters.AddWithValue("@last_date_file", DateTimeSQLite((DateTime)fechaMayor));
                    cmd.Parameters.AddWithValue("@date_created", DateTimeSQLite(DateTime.Now));


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }

                private int GetFKId(string table, string dateFormat)
                {
                    int result = -1;
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT id FROM " + table + " WHERE name = @name";
                    cmd.Parameters.AddWithValue("@name", dateFormat);

                    //DataSet dataSet = null;
                    try
                    {
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result = reader.GetInt32(0);
                        }
                    }
                    catch 
                    {                  
                    }
                    //SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    //adapter.Fill(dataSet);
                    //result = dataSet.Tables[0].Rows[0].Field<int>("id");

                    return result;
                }

                private string DateTimeSQLite(DateTime datetime)
                {
                    string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
                    return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
                }

                private void chkFiltrarFechas_CheckedChanged(object sender, EventArgs e)
                {
                    if (this.chkFiltrarFechas.Checked)
                    {
                        this.chkUseHistoric.Enabled = true;
                    }
                    else
                    {
                        this.chkUseHistoric.CheckedChanged -= this.chkUseHistoric_CheckedChanged;
                        this.chkUseHistoric.CheckState = CheckState.Unchecked;
                        this.chkUseHistoric.Enabled = false;
                        this.chkUseHistoric.CheckedChanged += new System.EventHandler(this.chkUseHistoric_CheckedChanged);
                    }
                }

                private void chkUseHistoric_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void cboTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
                {

                }
  }
}
