namespace DoAnCK
{
    partial class FormQuanLyAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.DanhSachNhanVien_dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.IDNV1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuyenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.XemLog_bt = new Guna.UI2.WinForms.Guna2Button();
            this.XemThongTinNV_bt = new Guna.UI2.WinForms.Guna2Button();
            this.XoaNV_bt = new Guna.UI2.WinForms.Guna2Button();
            this.CapQuyen_bt = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVien_dgv)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(172)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(114)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1229, 78);
            this.guna2GradientPanel1.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh Sách Nhân Viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DanhSachNhanVien_dgv
            // 
            this.DanhSachNhanVien_dgv.AllowUserToAddRows = false;
            this.DanhSachNhanVien_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.DanhSachNhanVien_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DanhSachNhanVien_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DanhSachNhanVien_dgv.ColumnHeadersHeight = 18;
            this.DanhSachNhanVien_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DanhSachNhanVien_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNV1,
            this.TenNV1,
            this.UserName1,
            this.QuyenNV});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DanhSachNhanVien_dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.DanhSachNhanVien_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.DanhSachNhanVien_dgv.Location = new System.Drawing.Point(-3, 83);
            this.DanhSachNhanVien_dgv.Name = "DanhSachNhanVien_dgv";
            this.DanhSachNhanVien_dgv.ReadOnly = true;
            this.DanhSachNhanVien_dgv.RowHeadersWidth = 51;
            this.DanhSachNhanVien_dgv.RowTemplate.Height = 24;
            this.DanhSachNhanVien_dgv.Size = new System.Drawing.Size(1232, 418);
            this.DanhSachNhanVien_dgv.TabIndex = 31;
            this.DanhSachNhanVien_dgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.DanhSachNhanVien_dgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.DanhSachNhanVien_dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DanhSachNhanVien_dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DanhSachNhanVien_dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DanhSachNhanVien_dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DanhSachNhanVien_dgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DanhSachNhanVien_dgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DanhSachNhanVien_dgv.ThemeStyle.HeaderStyle.Height = 18;
            this.DanhSachNhanVien_dgv.ThemeStyle.ReadOnly = true;
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.Height = 24;
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.DanhSachNhanVien_dgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // IDNV1
            // 
            this.IDNV1.HeaderText = "ID";
            this.IDNV1.MinimumWidth = 6;
            this.IDNV1.Name = "IDNV1";
            this.IDNV1.ReadOnly = true;
            // 
            // TenNV1
            // 
            this.TenNV1.HeaderText = "Tên Nhân Viên";
            this.TenNV1.MinimumWidth = 6;
            this.TenNV1.Name = "TenNV1";
            this.TenNV1.ReadOnly = true;
            // 
            // UserName1
            // 
            this.UserName1.HeaderText = "Tên Đăng Nhập";
            this.UserName1.MinimumWidth = 6;
            this.UserName1.Name = "UserName1";
            this.UserName1.ReadOnly = true;
            // 
            // QuyenNV
            // 
            this.QuyenNV.HeaderText = "Quyền ";
            this.QuyenNV.MinimumWidth = 6;
            this.QuyenNV.Name = "QuyenNV";
            this.QuyenNV.ReadOnly = true;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 20;
            this.guna2GradientPanel2.Controls.Add(this.XemLog_bt);
            this.guna2GradientPanel2.Controls.Add(this.XemThongTinNV_bt);
            this.guna2GradientPanel2.Controls.Add(this.XoaNV_bt);
            this.guna2GradientPanel2.Controls.Add(this.CapQuyen_bt);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(172)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(114)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 506);
            this.guna2GradientPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1229, 132);
            this.guna2GradientPanel2.TabIndex = 32;
            // 
            // XemLog_bt
            // 
            this.XemLog_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XemLog_bt.BackColor = System.Drawing.Color.Transparent;
            this.XemLog_bt.BorderRadius = 20;
            this.XemLog_bt.BorderThickness = 1;
            this.XemLog_bt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.XemLog_bt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.XemLog_bt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.XemLog_bt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.XemLog_bt.FillColor = System.Drawing.Color.Transparent;
            this.XemLog_bt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XemLog_bt.ForeColor = System.Drawing.Color.Black;
            this.XemLog_bt.Location = new System.Drawing.Point(921, 45);
            this.XemLog_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XemLog_bt.Name = "XemLog_bt";
            this.XemLog_bt.Size = new System.Drawing.Size(284, 43);
            this.XemLog_bt.TabIndex = 8;
            this.XemLog_bt.Text = "Xem Log Hệ Thống";
            this.XemLog_bt.Click += new System.EventHandler(this.XemLog_bt_Click);
            // 
            // XemThongTinNV_bt
            // 
            this.XemThongTinNV_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XemThongTinNV_bt.BackColor = System.Drawing.Color.Transparent;
            this.XemThongTinNV_bt.BorderRadius = 20;
            this.XemThongTinNV_bt.BorderThickness = 1;
            this.XemThongTinNV_bt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.XemThongTinNV_bt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.XemThongTinNV_bt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.XemThongTinNV_bt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.XemThongTinNV_bt.FillColor = System.Drawing.Color.Transparent;
            this.XemThongTinNV_bt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XemThongTinNV_bt.ForeColor = System.Drawing.Color.Black;
            this.XemThongTinNV_bt.Location = new System.Drawing.Point(622, 45);
            this.XemThongTinNV_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XemThongTinNV_bt.Name = "XemThongTinNV_bt";
            this.XemThongTinNV_bt.Size = new System.Drawing.Size(292, 43);
            this.XemThongTinNV_bt.TabIndex = 7;
            this.XemThongTinNV_bt.Text = "Xem Thông Tin Nhân Viên";
            this.XemThongTinNV_bt.Click += new System.EventHandler(this.XemThongTinNV_bt_Click);
            // 
            // XoaNV_bt
            // 
            this.XoaNV_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XoaNV_bt.BackColor = System.Drawing.Color.Transparent;
            this.XoaNV_bt.BorderRadius = 20;
            this.XoaNV_bt.BorderThickness = 1;
            this.XoaNV_bt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.XoaNV_bt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.XoaNV_bt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.XoaNV_bt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.XoaNV_bt.FillColor = System.Drawing.Color.Transparent;
            this.XoaNV_bt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XoaNV_bt.ForeColor = System.Drawing.Color.Black;
            this.XoaNV_bt.Location = new System.Drawing.Point(323, 45);
            this.XoaNV_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XoaNV_bt.Name = "XoaNV_bt";
            this.XoaNV_bt.Size = new System.Drawing.Size(292, 43);
            this.XoaNV_bt.TabIndex = 6;
            this.XoaNV_bt.Text = "Xóa Nhân Viên";
            this.XoaNV_bt.Click += new System.EventHandler(this.XoaNV_bt_Click);
            // 
            // CapQuyen_bt
            // 
            this.CapQuyen_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CapQuyen_bt.BackColor = System.Drawing.Color.Transparent;
            this.CapQuyen_bt.BorderRadius = 20;
            this.CapQuyen_bt.BorderThickness = 1;
            this.CapQuyen_bt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CapQuyen_bt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CapQuyen_bt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CapQuyen_bt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CapQuyen_bt.FillColor = System.Drawing.Color.Transparent;
            this.CapQuyen_bt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapQuyen_bt.ForeColor = System.Drawing.Color.Black;
            this.CapQuyen_bt.Location = new System.Drawing.Point(24, 45);
            this.CapQuyen_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CapQuyen_bt.Name = "CapQuyen_bt";
            this.CapQuyen_bt.Size = new System.Drawing.Size(292, 43);
            this.CapQuyen_bt.TabIndex = 5;
            this.CapQuyen_bt.Text = "Cấp/Hủy Quyền Admin";
            this.CapQuyen_bt.Click += new System.EventHandler(this.CapQuyen_bt_Click);
            // 
            // FormQuanLyAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 638);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.DanhSachNhanVien_dgv);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormQuanLyAdmin";
            this.Text = "Quản lý hệ thống - Admin";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVien_dgv)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView DanhSachNhanVien_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuyenNV;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Button CapQuyen_bt;
        private Guna.UI2.WinForms.Guna2Button XemLog_bt;
        private Guna.UI2.WinForms.Guna2Button XemThongTinNV_bt;
        private Guna.UI2.WinForms.Guna2Button XoaNV_bt;
    }
}
