namespace QLNhanSu.xuatbaocao
{
    partial class BaoCaoPhuCap
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
            this.rptPhuCap = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptPhuCap
            // 
            this.rptPhuCap.Location = new System.Drawing.Point(5, 5);
            this.rptPhuCap.Name = "rptPhuCap";
            this.rptPhuCap.ServerReport.BearerToken = null;
            this.rptPhuCap.Size = new System.Drawing.Size(1068, 527);
            this.rptPhuCap.TabIndex = 0;
            // 
            // BaoCaoPhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 544);
            this.Controls.Add(this.rptPhuCap);
            this.Name = "BaoCaoPhuCap";
            this.Text = "BaoCaoPhuCap";
            this.Load += new System.EventHandler(this.BaoCaoPhuCap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptPhuCap;
    }
}