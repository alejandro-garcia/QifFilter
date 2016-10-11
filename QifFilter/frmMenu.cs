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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnGoogleDocs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Caracteristica en Desarrollo");
        }

        private void btnQifFilter_Click(object sender, System.EventArgs e)
        {
            frmQifFilter myForm = new frmQifFilter();
            myForm.Show(this);
        }
        
    }
}
