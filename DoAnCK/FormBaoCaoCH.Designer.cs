namespace DoAnCK
{
    partial class FormBaoCaoCH
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
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiHangHoa = new System.Windows.Forms.ComboBox();
            this.dgvBaoCaoCH = new System.Windows.Forms.DataGridView();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblLoaiHang = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoCH)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(513, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thống kê số lượng và doanh thu theo loại hàng";

            // lblTuNgay
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(22, 72);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(64, 17);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";

            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 70);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 22);
            this.dtpTuNgay.TabIndex = 2;

            // lblDenNgay
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(272, 72);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(71, 17);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";

            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(350, 70);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 22);
            this.dtpDenNgay.TabIndex = 4;

            // lblLoaiHang
            this.lblLoaiHang.AutoSize = true;
            this.lblLoaiHang.Location = new System.Drawing.Point(520, 72);
            this.lblLoaiHang.Name = "lblLoaiHang";
            this.lblLoaiHang.Size = new System.Drawing.Size(72, 17);
            this.lblLoaiHang.TabIndex = 5;
            this.lblLoaiHang.Text = "Loại hàng:";

            // cboLoaiHangHoa
            this.cboLoaiHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHangHoa.FormattingEnabled = true;
            this.cboLoaiHangHoa.Location = new System.Drawing.Point(600, 70);
            this.cboLoaiHangHoa.Name = "cboLoaiHangHoa";
            this.cboLoaiHangHoa.Size = new System.Drawing.Size(150, 24);
            this.cboLoaiHangHoa.TabIndex = 6;

            // btnXemBaoCao
            this.btnXemBaoCao.Location = new System.Drawing.Point(780, 70);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.TabIndex = 7;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);

            // dgvBaoCaoCH
            this.dgvBaoCaoCH.AllowUserToAddRows = false;
            this.dgvBaoCaoCH.AllowUserToDeleteRows = false;
            this.dgvBaoCaoCH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCaoCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoCH.Location = new System.Drawing.Point(20, 120);
            this.dgvBaoCaoCH.Name = "dgvBaoCaoCH";
            this.dgvBaoCaoCH.ReadOnly = true;
            this.dgvBaoCaoCH.RowHeadersWidth = 51;
            this.dgvBaoCaoCH.RowTemplate.Height = 24;
            this.dgvBaoCaoCH.Size = new System.Drawing.Size(880, 400);
            this.dgvBaoCaoCH.TabIndex = 8;

            // FormBaoCaoCH
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.dgvBaoCaoCH);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.cboLoaiHangHoa);
            this.Controls.Add(this.lblLoaiHang);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoCaoCH";
            this.Text = "FormBaoCaoCH";
            this.Load += new System.EventHandler(this.FormBaoCaoCH_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoCH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLoaiHang;
        private System.Windows.Forms.ComboBox cboLoaiHangHoa;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCaoCH;
    }
}
