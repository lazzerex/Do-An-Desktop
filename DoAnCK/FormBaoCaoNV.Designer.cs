namespace DoAnCK
{
    partial class FormBaoCaoNV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTuNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDenNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBaoCaoNV = new Guna.UI2.WinForms.Guna2DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNV)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 35);
            this.lblTitle.Text = "Báo cáo doanh thu và số lượng hóa đơn theo nhân viên";

            // lblTuNgay
            this.lblTuNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblTuNgay.Location = new System.Drawing.Point(22, 75);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(60, 15);
            this.lblTuNgay.Text = "Từ ngày:";

            // dtpTuNgay
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(90, 70);
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 36);
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;

            // lblDenNgay
            this.lblDenNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblDenNgay.Location = new System.Drawing.Point(260, 75);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(65, 15);
            this.lblDenNgay.Text = "Đến ngày:";

            // dtpDenNgay
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(330, 70);
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 36);
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;

            // btnXemBaoCao
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Location = new System.Drawing.Point(510, 70);
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 36);
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);

            // dgvBaoCaoNV
            this.dgvBaoCaoNV.Location = new System.Drawing.Point(20, 130);
            this.dgvBaoCaoNV.Size = new System.Drawing.Size(800, 400);
            this.dgvBaoCaoNV.ReadOnly = true;
            this.dgvBaoCaoNV.AllowUserToAddRows = false;
            this.dgvBaoCaoNV.AllowUserToDeleteRows = false;
            this.dgvBaoCaoNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;

            // FormBaoCaoNV
            this.ClientSize = new System.Drawing.Size(850, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.dgvBaoCaoNV);
            this.Name = "FormBaoCaoNV";
            this.Text = "FormBaoCaoNV";
            this.Load += new System.EventHandler(this.FormBaoCaoNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTuNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTuNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDenNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenNgay;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCaoNV;
    }
}
