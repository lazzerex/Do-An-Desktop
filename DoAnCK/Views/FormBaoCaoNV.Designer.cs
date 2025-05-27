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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTuNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDenNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBaoCaoNV = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(707, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo doanh thu và số lượng hóa đơn theo nhân viên";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblTuNgay.Location = new System.Drawing.Point(22, 75);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 18);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(90, 70);
            this.dtpTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 36);
            this.dtpTuNgay.TabIndex = 2;
            this.dtpTuNgay.Value = new System.DateTime(2025, 5, 27, 11, 47, 57, 682);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblDenNgay.Location = new System.Drawing.Point(260, 75);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 18);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(330, 70);
            this.dtpDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 36);
            this.dtpDenNgay.TabIndex = 4;
            this.dtpDenNgay.Value = new System.DateTime(2025, 5, 27, 11, 47, 57, 729);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(510, 70);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 36);
            this.btnXemBaoCao.TabIndex = 5;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dgvBaoCaoNV
            // 
            this.dgvBaoCaoNV.AllowUserToAddRows = false;
            this.dgvBaoCaoNV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaoCaoNV.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoNV.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaoCaoNV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoNV.Location = new System.Drawing.Point(0, 130);
            this.dgvBaoCaoNV.Name = "dgvBaoCaoNV";
            this.dgvBaoCaoNV.ReadOnly = true;
            this.dgvBaoCaoNV.RowHeadersVisible = false;
            this.dgvBaoCaoNV.RowHeadersWidth = 51;
            this.dgvBaoCaoNV.Size = new System.Drawing.Size(934, 415);
            this.dgvBaoCaoNV.TabIndex = 6;
            this.dgvBaoCaoNV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCaoNV.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvBaoCaoNV.ThemeStyle.ReadOnly = true;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvBaoCaoNV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // FormBaoCaoNV
            // 
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.dgvBaoCaoNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoCaoNV";
            this.Text = "FormBaoCaoNV";
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
