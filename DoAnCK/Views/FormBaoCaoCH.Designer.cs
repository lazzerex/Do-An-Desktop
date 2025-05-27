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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(734, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ SỐ LƯỢNG VÀ DOANH THU THEO LOẠI HÀNG";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(72, 75);
            this.dtpTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpTuNgay.TabIndex = 2;
            this.dtpTuNgay.Value = new System.DateTime(2025, 5, 27, 11, 38, 33, 453);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(299, 75);
            this.dtpDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpDenNgay.TabIndex = 4;
            this.dtpDenNgay.Value = new System.DateTime(2025, 5, 27, 11, 38, 33, 501);
            // 
            // cboLoaiHangHoa
            // 
            this.cboLoaiHangHoa.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiHangHoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHangHoa.FocusedColor = System.Drawing.Color.Empty;
            this.cboLoaiHangHoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiHangHoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLoaiHangHoa.ItemHeight = 30;
            this.cboLoaiHangHoa.Location = new System.Drawing.Point(519, 75);
            this.cboLoaiHangHoa.Name = "cboLoaiHangHoa";
            this.cboLoaiHangHoa.Size = new System.Drawing.Size(160, 36);
            this.cboLoaiHangHoa.TabIndex = 6;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(685, 75);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.TabIndex = 7;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dgvBaoCaoCH
            // 
            this.dgvBaoCaoCH.AllowUserToAddRows = false;
            this.dgvBaoCaoCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBaoCaoCH.ColumnHeadersHeight = 29;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoCH.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBaoCaoCH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoCH.Location = new System.Drawing.Point(-1, 130);
            this.dgvBaoCaoCH.Name = "dgvBaoCaoCH";
            this.dgvBaoCaoCH.ReadOnly = true;
            this.dgvBaoCaoCH.RowHeadersVisible = false;
            this.dgvBaoCaoCH.RowHeadersWidth = 51;
            this.dgvBaoCaoCH.Size = new System.Drawing.Size(998, 416);
            this.dgvBaoCaoCH.TabIndex = 9;
            this.dgvBaoCaoCH.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoCH.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoCH.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoCH.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCaoCH.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvBaoCaoCH.ThemeStyle.ReadOnly = true;
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvBaoCaoCH.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 80);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 18);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblDenNgay.Location = new System.Drawing.Point(239, 80);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 18);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblLoaiHang
            // 
            this.lblLoaiHang.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaiHang.Location = new System.Drawing.Point(458, 80);
            this.lblLoaiHang.Name = "lblLoaiHang";
            this.lblLoaiHang.Size = new System.Drawing.Size(65, 18);
            this.lblLoaiHang.TabIndex = 5;
            this.lblLoaiHang.Text = "Loại hàng:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(811, 75);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 30);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất Excel";
            // 
            // FormBaoCaoCH
            // 
            this.ClientSize = new System.Drawing.Size(1000, 550);
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
            this.Name = "FormBaoCaoCH";
            this.Text = "FormBaoCaoCH";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoCH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
