using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace DoAnCK
{
    partial class FormBaoCaoNCC
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
            this.lblTitle = new Guna2HtmlLabel();
            this.dtpTuNgay = new Guna2DateTimePicker();
            this.dtpDenNgay = new Guna2DateTimePicker();
            this.cboNhaCungCap = new Guna2ComboBox();
            this.btnXemBaoCao = new Guna2Button();
            this.dgvBaoCaoNCC = new Guna2DataGridView();
            this.lblTuNgay = new Guna2HtmlLabel();
            this.lblDenNgay = new Guna2HtmlLabel();
            this.lblNhaCungCap = new Guna2HtmlLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNCC)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "BÁO CÁO NHẬP HÀNG THEO NHÀ CUNG CẤP";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(600, 40);

            // lblTuNgay
            this.lblTuNgay.Text = "Từ ngày:";
            this.lblTuNgay.Location = new Point(20, 80);
            this.lblTuNgay.Size = new Size(70, 20);

            // dtpTuNgay
            this.dtpTuNgay.Location = new Point(100, 75);
            this.dtpTuNgay.Size = new Size(150, 30);
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.FillColor = Color.White;

            // lblDenNgay
            this.lblDenNgay.Text = "Đến ngày:";
            this.lblDenNgay.Location = new Point(270, 80);
            this.lblDenNgay.Size = new Size(70, 20);

            // dtpDenNgay
            this.dtpDenNgay.Location = new Point(350, 75);
            this.dtpDenNgay.Size = new Size(150, 30);
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.FillColor = Color.White;

            // lblNhaCungCap
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            this.lblNhaCungCap.Location = new Point(520, 80);
            this.lblNhaCungCap.Size = new Size(100, 20);

            // cboNhaCungCap
            this.cboNhaCungCap.Location = new Point(630, 75);
            this.cboNhaCungCap.Size = new Size(200, 30);
            this.cboNhaCungCap.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnXemBaoCao
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Location = new Point(850, 75);
            this.btnXemBaoCao.Size = new Size(120, 30);
            this.btnXemBaoCao.Click += new EventHandler(this.btnXemBaoCao_Click);

            // dgvBaoCaoNCC
            this.dgvBaoCaoNCC.Location = new Point(20, 130);
            this.dgvBaoCaoNCC.Size = new Size(950, 390);
            this.dgvBaoCaoNCC.ReadOnly = true;
            this.dgvBaoCaoNCC.AllowUserToAddRows = false;
            this.dgvBaoCaoNCC.AllowUserToDeleteRows = false;
            this.dgvBaoCaoNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.BackColor = Color.White;

            // Form settings
            this.ClientSize = new Size(1000, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.cboNhaCungCap);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.dgvBaoCaoNCC);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += new EventHandler(this.FormBaoCaoNCC_Load);
            this.Text = "FormBaoCaoNCC";

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNCC)).EndInit();
            this.ResumeLayout(false);
        }


        #endregion

        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblTuNgay;
        private Guna2DateTimePicker dtpTuNgay;
        private Guna2HtmlLabel lblDenNgay;
        private Guna2DateTimePicker dtpDenNgay;
        private Guna2HtmlLabel lblNhaCungCap;
        private Guna2ComboBox cboNhaCungCap;
        private Guna2Button btnXemBaoCao;
        private Guna2DataGridView dgvBaoCaoNCC;

    }
}
