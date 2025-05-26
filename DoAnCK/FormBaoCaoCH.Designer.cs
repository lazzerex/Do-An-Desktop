using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;
using System;

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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboLoaiHangHoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBaoCaoCH = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTuNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDenNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLoaiHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoCH)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "THỐNG KÊ SỐ LƯỢNG VÀ DOANH THU THEO LOẠI HÀNG";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(600, 40);

            // lblTuNgay
            this.lblTuNgay.Text = "Từ ngày:";
            this.lblTuNgay.Location = new System.Drawing.Point(20, 80);
            this.lblTuNgay.Size = new System.Drawing.Size(70, 20);

            // dtpTuNgay
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 75);
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;

            // lblDenNgay
            this.lblDenNgay.Text = "Đến ngày:";
            this.lblDenNgay.Location = new System.Drawing.Point(270, 80);
            this.lblDenNgay.Size = new System.Drawing.Size(70, 20);

            // dtpDenNgay
            this.dtpDenNgay.Location = new System.Drawing.Point(350, 75);
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;

            // lblLoaiHang
            this.lblLoaiHang.Text = "Loại hàng:";
            this.lblLoaiHang.Location = new System.Drawing.Point(520, 80);
            this.lblLoaiHang.Size = new System.Drawing.Size(80, 20);

            // cboLoaiHangHoa
            this.cboLoaiHangHoa.Location = new System.Drawing.Point(610, 75);
            this.cboLoaiHangHoa.Size = new System.Drawing.Size(160, 30);
            this.cboLoaiHangHoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnXemBaoCao
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Location = new System.Drawing.Point(790, 75);
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.FillColor = System.Drawing.Color.FromArgb(0, 71, 160);
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);

            // btnExportExcel
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Location = new System.Drawing.Point(920, 75);
            this.btnExportExcel.Size = new System.Drawing.Size(100, 30);
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(31, 137, 62);

            // dgvBaoCaoCH
            this.dgvBaoCaoCH.Location = new System.Drawing.Point(20, 130);
            this.dgvBaoCaoCH.Size = new System.Drawing.Size(950, 390);
            this.dgvBaoCaoCH.ReadOnly = true;
            this.dgvBaoCaoCH.AllowUserToAddRows = false;
            this.dgvBaoCaoCH.AllowUserToDeleteRows = false;
            this.dgvBaoCaoCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(0, 71, 160);
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;

            // Form settings
            this.ClientSize = new System.Drawing.Size(1040, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblLoaiHang);
            this.Controls.Add(this.cboLoaiHangHoa);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvBaoCaoCH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Load += new System.EventHandler(this.FormBaoCaoCH_Load);
            this.Text = "FormBaoCaoCH";

            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoCH)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTuNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTuNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDenNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoaiHang;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiHangHoa;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCaoCH;
    }
}
