namespace DoAnCK
{
    partial class FormDangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TenDangNhap_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.MatKhau__tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.DangNhap_bt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnCheckSQLite = new Guna.UI2.WinForms.Guna2Button();
            this.btnChuyenDuLieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoBang = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(117, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(117, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(192, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TenDangNhap_tb
            // 
            this.TenDangNhap_tb.BorderRadius = 5;
            this.TenDangNhap_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TenDangNhap_tb.DefaultText = "";
            this.TenDangNhap_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TenDangNhap_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TenDangNhap_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TenDangNhap_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TenDangNhap_tb.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.TenDangNhap_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenDangNhap_tb.Font = new System.Drawing.Font("Arial", 10F);
            this.TenDangNhap_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenDangNhap_tb.Location = new System.Drawing.Point(110, 187);
            this.TenDangNhap_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TenDangNhap_tb.Name = "TenDangNhap_tb";
            this.TenDangNhap_tb.PlaceholderText = "";
            this.TenDangNhap_tb.SelectedText = "";
            this.TenDangNhap_tb.Size = new System.Drawing.Size(275, 31);
            this.TenDangNhap_tb.TabIndex = 8;
            // 
            // MatKhau__tb
            // 
            this.MatKhau__tb.BorderRadius = 5;
            this.MatKhau__tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MatKhau__tb.DefaultText = "";
            this.MatKhau__tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.MatKhau__tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.MatKhau__tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MatKhau__tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MatKhau__tb.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.MatKhau__tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MatKhau__tb.Font = new System.Drawing.Font("Arial", 10F);
            this.MatKhau__tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MatKhau__tb.Location = new System.Drawing.Point(108, 253);
            this.MatKhau__tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MatKhau__tb.Name = "MatKhau__tb";
            this.MatKhau__tb.PasswordChar = '*';
            this.MatKhau__tb.PlaceholderText = "";
            this.MatKhau__tb.SelectedText = "";
            this.MatKhau__tb.Size = new System.Drawing.Size(275, 31);
            this.MatKhau__tb.TabIndex = 9;
            // 
            // DangNhap_bt
            // 
            this.DangNhap_bt.BorderRadius = 20;
            this.DangNhap_bt.BorderThickness = 1;
            this.DangNhap_bt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DangNhap_bt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DangNhap_bt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DangNhap_bt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DangNhap_bt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DangNhap_bt.FillColor = System.Drawing.Color.White;
            this.DangNhap_bt.FillColor2 = System.Drawing.Color.White;
            this.DangNhap_bt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangNhap_bt.ForeColor = System.Drawing.Color.Black;
            this.DangNhap_bt.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(172)))));
            this.DangNhap_bt.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(114)))));
            this.DangNhap_bt.Location = new System.Drawing.Point(173, 299);
            this.DangNhap_bt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DangNhap_bt.Name = "DangNhap_bt";
            this.DangNhap_bt.Size = new System.Drawing.Size(134, 34);
            this.DangNhap_bt.TabIndex = 10;
            this.DangNhap_bt.Text = "Đăng Nhập";
            this.DangNhap_bt.Click += new System.EventHandler(this.DangNhap_bt_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(172)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(114)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(436, 32);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(106, 283);
            this.guna2GradientPanel1.TabIndex = 11;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 20;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(172)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(114)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(-44, 32);
            this.guna2GradientPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(99, 283);
            this.guna2GradientPanel2.TabIndex = 12;
            // 
            // btnCheckSQLite
            // 
            this.btnCheckSQLite.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckSQLite.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckSQLite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckSQLite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckSQLite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheckSQLite.ForeColor = System.Drawing.Color.White;
            this.btnCheckSQLite.Location = new System.Drawing.Point(12, 2);
            this.btnCheckSQLite.Name = "btnCheckSQLite";
            this.btnCheckSQLite.Size = new System.Drawing.Size(66, 25);
            this.btnCheckSQLite.TabIndex = 13;
            this.btnCheckSQLite.Text = "Check";
            this.btnCheckSQLite.Click += new System.EventHandler(this.btnCheckSQLite_Click);
            // 
            // btnChuyenDuLieu
            // 
            this.btnChuyenDuLieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenDuLieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenDuLieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChuyenDuLieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChuyenDuLieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChuyenDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnChuyenDuLieu.Location = new System.Drawing.Point(84, 2);
            this.btnChuyenDuLieu.Name = "btnChuyenDuLieu";
            this.btnChuyenDuLieu.Size = new System.Drawing.Size(66, 26);
            this.btnChuyenDuLieu.TabIndex = 14;
            this.btnChuyenDuLieu.Text = "Load Data";
            this.btnChuyenDuLieu.Click += new System.EventHandler(this.btnChuyenDuLieu_Click);
            // 
            // btnTaoBang
            // 
            this.btnTaoBang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoBang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoBang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoBang.ForeColor = System.Drawing.Color.White;
            this.btnTaoBang.Location = new System.Drawing.Point(156, 2);
            this.btnTaoBang.Name = "btnTaoBang";
            this.btnTaoBang.Size = new System.Drawing.Size(66, 25);
            this.btnTaoBang.TabIndex = 15;
            this.btnTaoBang.Text = "Create";
            this.btnTaoBang.Click += new System.EventHandler(this.btnTaoBang_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 376);
            this.Controls.Add(this.btnTaoBang);
            this.Controls.Add(this.btnChuyenDuLieu);
            this.Controls.Add(this.btnCheckSQLite);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.DangNhap_bt);
            this.Controls.Add(this.MatKhau__tb);
            this.Controls.Add(this.TenDangNhap_tb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox TenDangNhap_tb;
        private Guna.UI2.WinForms.Guna2TextBox MatKhau__tb;
        private Guna.UI2.WinForms.Guna2GradientButton DangNhap_bt;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Button btnCheckSQLite;
        private Guna.UI2.WinForms.Guna2Button btnChuyenDuLieu;
        private Guna.UI2.WinForms.Guna2Button btnTaoBang;
    }
}