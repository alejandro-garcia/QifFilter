namespace QifFilter
{
    partial class frmQifFilter
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dirListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
			this.driveListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
			this.fileListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cboTipoFechaOut = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboTipoFechaIn = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboFormatos = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cboTipoSeparador = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkUseHistoric = new System.Windows.Forms.CheckBox();
			this.chkFiltrarFechas = new System.Windows.Forms.CheckBox();
			this.dtpFecHas = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpFecDes = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.btnProcesar = new System.Windows.Forms.Button();
			this.btnSalir = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cboTipoCuenta = new System.Windows.Forms.ComboBox();
			this.chkAvoidTransfers = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(13, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(486, 208);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Seleccione los Archivos a Procesar";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 16);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dirListBox1);
			this.splitContainer1.Panel1.Controls.Add(this.driveListBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.fileListBox1);
			this.splitContainer1.Size = new System.Drawing.Size(480, 189);
			this.splitContainer1.SplitterDistance = 160;
			this.splitContainer1.TabIndex = 0;
			// 
			// dirListBox1
			// 
			this.dirListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dirListBox1.FormattingEnabled = true;
			this.dirListBox1.IntegralHeight = false;
			this.dirListBox1.Location = new System.Drawing.Point(3, 30);
			this.dirListBox1.Name = "dirListBox1";
			this.dirListBox1.Size = new System.Drawing.Size(154, 153);
			this.dirListBox1.TabIndex = 3;
			this.dirListBox1.Change += new System.EventHandler(this.dirListBox1_Change);
			// 
			// driveListBox1
			// 
			this.driveListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.driveListBox1.FormattingEnabled = true;
			this.driveListBox1.Location = new System.Drawing.Point(3, 3);
			this.driveListBox1.Name = "driveListBox1";
			this.driveListBox1.Size = new System.Drawing.Size(154, 21);
			this.driveListBox1.TabIndex = 2;
			this.driveListBox1.SelectedIndexChanged += new System.EventHandler(this.driveListBox1_SelectedIndexChanged);
			// 
			// fileListBox1
			// 
			this.fileListBox1.FormattingEnabled = true;
			this.fileListBox1.Location = new System.Drawing.Point(3, 3);
			this.fileListBox1.Name = "fileListBox1";
			this.fileListBox1.Pattern = "*.qif";
			this.fileListBox1.Size = new System.Drawing.Size(310, 173);
			this.fileListBox1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cboTipoFechaOut);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cboTipoFechaIn);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.cboFormatos);
			this.groupBox2.Location = new System.Drawing.Point(16, 219);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(479, 52);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Formatos";
			// 
			// cboTipoFechaOut
			// 
			this.cboTipoFechaOut.FormattingEnabled = true;
			this.cboTipoFechaOut.Location = new System.Drawing.Point(385, 19);
			this.cboTipoFechaOut.Name = "cboTipoFechaOut";
			this.cboTipoFechaOut.Size = new System.Drawing.Size(88, 21);
			this.cboTipoFechaOut.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(333, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Destino:";
			// 
			// cboTipoFechaIn
			// 
			this.cboTipoFechaIn.FormattingEnabled = true;
			this.cboTipoFechaIn.Location = new System.Drawing.Point(211, 19);
			this.cboTipoFechaIn.Name = "cboTipoFechaIn";
			this.cboTipoFechaIn.Size = new System.Drawing.Size(97, 21);
			this.cboTipoFechaIn.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(164, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Origen:";
			// 
			// cboFormatos
			// 
			this.cboFormatos.FormattingEnabled = true;
			this.cboFormatos.Location = new System.Drawing.Point(6, 19);
			this.cboFormatos.Name = "cboFormatos";
			this.cboFormatos.Size = new System.Drawing.Size(151, 21);
			this.cboFormatos.TabIndex = 0;
			this.cboFormatos.SelectedIndexChanged += new System.EventHandler(this.cboFormatos_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cboTipoSeparador);
			this.groupBox3.Location = new System.Drawing.Point(17, 283);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(170, 45);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Separador Decimal";
			// 
			// cboTipoSeparador
			// 
			this.cboTipoSeparador.FormattingEnabled = true;
			this.cboTipoSeparador.Location = new System.Drawing.Point(6, 18);
			this.cboTipoSeparador.Name = "cboTipoSeparador";
			this.cboTipoSeparador.Size = new System.Drawing.Size(150, 21);
			this.cboTipoSeparador.TabIndex = 1;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkAvoidTransfers);
			this.groupBox4.Controls.Add(this.chkUseHistoric);
			this.groupBox4.Controls.Add(this.chkFiltrarFechas);
			this.groupBox4.Controls.Add(this.dtpFecHas);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.dtpFecDes);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Location = new System.Drawing.Point(16, 334);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(478, 78);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Periodo";
			// 
			// chkUseHistoric
			// 
			this.chkUseHistoric.AutoSize = true;
			this.chkUseHistoric.Location = new System.Drawing.Point(290, 16);
			this.chkUseHistoric.Name = "chkUseHistoric";
			this.chkUseHistoric.Size = new System.Drawing.Size(129, 17);
			this.chkUseHistoric.TabIndex = 7;
			this.chkUseHistoric.Text = "Llenar según historico";
			this.chkUseHistoric.UseVisualStyleBackColor = true;
			this.chkUseHistoric.CheckedChanged += new System.EventHandler(this.chkUseHistoric_CheckedChanged);
			// 
			// chkFiltrarFechas
			// 
			this.chkFiltrarFechas.AutoSize = true;
			this.chkFiltrarFechas.Checked = true;
			this.chkFiltrarFechas.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFiltrarFechas.Location = new System.Drawing.Point(167, 30);
			this.chkFiltrarFechas.Name = "chkFiltrarFechas";
			this.chkFiltrarFechas.Size = new System.Drawing.Size(108, 17);
			this.chkFiltrarFechas.TabIndex = 6;
			this.chkFiltrarFechas.Text = "Filtrar por Periodo";
			this.chkFiltrarFechas.UseVisualStyleBackColor = true;
			this.chkFiltrarFechas.CheckedChanged += new System.EventHandler(this.chkFiltrarFechas_CheckedChanged);
			// 
			// dtpFecHas
			// 
			this.dtpFecHas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecHas.Location = new System.Drawing.Point(54, 39);
			this.dtpFecHas.Name = "dtpFecHas";
			this.dtpFecHas.Size = new System.Drawing.Size(103, 20);
			this.dtpFecHas.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Hasta:";
			// 
			// dtpFecDes
			// 
			this.dtpFecDes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecDes.Location = new System.Drawing.Point(54, 16);
			this.dtpFecDes.Name = "dtpFecDes";
			this.dtpFecDes.Size = new System.Drawing.Size(103, 20);
			this.dtpFecDes.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Desde:";
			// 
			// btnProcesar
			// 
			this.btnProcesar.Location = new System.Drawing.Point(119, 418);
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(112, 33);
			this.btnProcesar.TabIndex = 4;
			this.btnProcesar.Text = "Procesar";
			this.btnProcesar.UseVisualStyleBackColor = true;
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(267, 418);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(112, 33);
			this.btnSalir.TabIndex = 5;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cboTipoCuenta);
			this.groupBox5.Location = new System.Drawing.Point(193, 283);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(303, 45);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Tipo de Cuenta";
			// 
			// cboTipoCuenta
			// 
			this.cboTipoCuenta.FormattingEnabled = true;
			this.cboTipoCuenta.Location = new System.Drawing.Point(6, 18);
			this.cboTipoCuenta.Name = "cboTipoCuenta";
			this.cboTipoCuenta.Size = new System.Drawing.Size(150, 21);
			this.cboTipoCuenta.TabIndex = 1;
			this.cboTipoCuenta.SelectedIndexChanged += new System.EventHandler(this.cboTipoCuenta_SelectedIndexChanged);
			// 
			// chkAvoidTransfers
			// 
			this.chkAvoidTransfers.AutoSize = true;
			this.chkAvoidTransfers.Location = new System.Drawing.Point(290, 39);
			this.chkAvoidTransfers.Name = "chkAvoidTransfers";
			this.chkAvoidTransfers.Size = new System.Drawing.Size(125, 17);
			this.chkAvoidTransfers.TabIndex = 8;
			this.chkAvoidTransfers.Text = "Omitir Transferencias";
			this.chkAvoidTransfers.UseVisualStyleBackColor = true;
			// 
			// frmQifFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 473);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.btnProcesar);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmQifFilter";
			this.Text = "Filtrado de Archivos QIF";
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox driveListBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTipoFechaOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoFechaIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFormatos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboTipoSeparador;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpFecHas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecDes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkFiltrarFechas;
        private System.Windows.Forms.CheckBox chkUseHistoric;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboTipoCuenta;
				private System.Windows.Forms.CheckBox chkAvoidTransfers;
    }
}

