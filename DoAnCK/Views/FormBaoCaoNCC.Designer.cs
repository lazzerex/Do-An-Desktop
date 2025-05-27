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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBaoCaoNCC = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTuNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDenNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNhaCungCap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(584, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO NHẬP HÀNG THEO NHÀ CUNG CẤP";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(71, 75);
            this.dtpTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpTuNgay.TabIndex = 2;
            this.dtpTuNgay.Value = new System.DateTime(2025, 5, 27, 11, 48, 0, 141);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(296, 75);
            this.dtpDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 30);
            this.dtpDenNgay.TabIndex = 4;
            this.dtpDenNgay.Value = new System.DateTime(2025, 5, 27, 11, 48, 0, 186);
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.cboNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FocusedColor = System.Drawing.Color.Empty;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNhaCungCap.ItemHeight = 30;
            this.cboNhaCungCap.Location = new System.Drawing.Point(544, 74);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(200, 36);
            this.cboNhaCungCap.TabIndex = 6;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(765, 74);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.TabIndex = 7;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dgvBaoCaoNCC
            // 
            this.dgvBaoCaoNCC.AllowUserToAddRows = false;
            this.dgvBaoCaoNCC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoNCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaoCaoNCC.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoNCC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaoCaoNCC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoNCC.Location = new System.Drawing.Point(0, 130);
            this.dgvBaoCaoNCC.Name = "dgvBaoCaoNCC";
            this.dgvBaoCaoNCC.ReadOnly = true;
            this.dgvBaoCaoNCC.RowHeadersVisible = false;
            this.dgvBaoCaoNCC.RowHeadersWidth = 51;
            this.dgvBaoCaoNCC.Size = new System.Drawing.Size(997, 424);
            this.dgvBaoCaoNCC.TabIndex = 8;
            this.dgvBaoCaoNCC.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNCC.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCaoNCC.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCaoNCC.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCaoNCC.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvBaoCaoNCC.ThemeStyle.ReadOnly = true;
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvBaoCaoNCC.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
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
            this.lblDenNgay.Location = new System.Drawing.Point(237, 80);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 18);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.lblNhaCungCap.Location = new System.Drawing.Point(462, 80);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(89, 18);
            this.lblNhaCungCap.TabIndex = 5;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // FormBaoCaoNCC
            // 
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.cboNhaCungCap);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.dgvBaoCaoNCC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoCaoNCC";
            this.Text = "FormBaoCaoNCC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
