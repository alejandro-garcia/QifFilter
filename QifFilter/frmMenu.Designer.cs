namespace QifFilter
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoogleDocs = new System.Windows.Forms.Button();
            this.btnQifFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQifFilter);
            this.groupBox1.Controls.Add(this.btnGoogleDocs);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btnGoogleDocs
            // 
            this.btnGoogleDocs.Location = new System.Drawing.Point(40, 31);
            this.btnGoogleDocs.Name = "btnGoogleDocs";
            this.btnGoogleDocs.Size = new System.Drawing.Size(236, 49);
            this.btnGoogleDocs.TabIndex = 0;
            this.btnGoogleDocs.Text = "Importar Movimientos Google Docs";
            this.btnGoogleDocs.UseVisualStyleBackColor = true;
            this.btnGoogleDocs.Click += new System.EventHandler(this.btnGoogleDocs_Click);
            // 
            // btnQifFilter
            // 
            this.btnQifFilter.Location = new System.Drawing.Point(40, 104);
            this.btnQifFilter.Name = "btnQifFilter";
            this.btnQifFilter.Size = new System.Drawing.Size(236, 49);
            this.btnQifFilter.TabIndex = 1;
            this.btnQifFilter.Text = "Importar Movimientos .QIF";
            this.btnQifFilter.UseVisualStyleBackColor = true;
            this.btnQifFilter.Click += new System.EventHandler(btnQifFilter_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 290);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente Finanzas Personales";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQifFilter;
        private System.Windows.Forms.Button btnGoogleDocs;
    }
}