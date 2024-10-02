namespace QLNhanSu.xuatbaocao
{
    partial class BaoCaoNhanVien
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
            this.rptBaoCaoNV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptBaoCaoNV
            // 
            this.rptBaoCaoNV.Location = new System.Drawing.Point(12, 13);
            this.rptBaoCaoNV.Name = "rptBaoCaoNV";
            this.rptBaoCaoNV.ServerReport.BearerToken = null;
            this.rptBaoCaoNV.Size = new System.Drawing.Size(1648, 744);
            this.rptBaoCaoNV.TabIndex = 0;
            this.rptBaoCaoNV.Load += new System.EventHandler(this.rptBaoCaoNV_Load);
            // 
            // BaoCaoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 769);
            this.Controls.Add(this.rptBaoCaoNV);
            this.Name = "BaoCaoNhanVien";
            this.Text = "BaoCaoNhanVien";
            this.Load += new System.EventHandler(this.BaoCaoNhanVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptBaoCaoNV;
    }
}