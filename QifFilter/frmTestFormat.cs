using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QifFilter
{
    public partial class frmTestFormat : Form
    {
        public frmTestFormat()
        {
            InitializeComponent();


            string[] sFormatos =
                new string[]
                      {"dd/MM/yyyy","MM/dd/yyyy",
                       "dd/MM'yyyy", "MM/dd'yyyy", 
                       "m/d'yy"};

            this.comboBox1.Items.AddRange(sFormatos);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dfecha = this.dateTimePicker1.Value;
            string sFormat = this.comboBox1.SelectedItem.ToString();

            sFormat = sFormat.Replace("'", " ");
            string sResult;
            sResult = string.Format(@"{0:" + sFormat + "}", dfecha);
            sResult = sResult.Replace(" ", "'");
            this.textBox1.Text = sResult;
            

            
        }
    }
}
