using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormNhaCungCap : Form
    {
        private NhaCungCapService service;
        private bool isAddingMode = false;
        private int index = -1;

        public FormNhaCungCap()
        {
            InitializeComponent();
            this.service = new NhaCungCapService(this);
            KhoHang.Instance.LoadData();
            ResetTextBoxes();
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
        }

        public void AddSupplierRow(string id, string ten, string sdt, string diaChi)
        {
            DanhSachNhaCungCap_dgv.Rows.Add(id, ten, sdt, diaChi);
        }

        public void UpdateSupplierRow(int index, string id, string ten, string sdt, string diaChi)
        {
            DanhSachNhaCungCap_dgv.Rows[index].Cells[0].Value = id;
            DanhSachNhaCungCap_dgv.Rows[index].Cells[1].Value = ten;
            DanhSachNhaCungCap_dgv.Rows[index].Cells[2].Value = sdt;
            DanhSachNhaCungCap_dgv.Rows[index].Cells[3].Value = diaChi;
            DanhSachNhaCungCap_dgv.Refresh();
        }

        public void RemoveSupplierRow(int index)
        {
            DanhSachNhaCungCap_dgv.Rows.RemoveAt(index);
        }

        public void ClearSupplierGrid()
        {
            DanhSachNhaCungCap_dgv.Rows.Clear();
        }

        public void EnableSupplierGrid(bool enable)
        {
            DanhSachNhaCungCap_dgv.Enabled = enable;
        }

        public void SetSupplierInfo(string id, string ten, string sdt, string diaChi)
        {
            IdNhaCungCap_tb.Text = id;
            TenNhaCungCap_tb.Text = ten;
            SdtNhaCungCap_tb.Text = sdt;
            DiaChi_tb.Text = diaChi;
        }

        public void ResetTextBoxes()
        {
            IdNhaCungCap_tb.Clear();
            TenNhaCungCap_tb.Clear();
            SdtNhaCungCap_tb.Clear();
            DiaChi_tb.Clear();
        }

        public void ToggleTextBoxState(bool enabled)
        {
            IdNhaCungCap_tb.Enabled = enabled;
            TenNhaCungCap_tb.Enabled = enabled;
            SdtNhaCungCap_tb.Enabled = enabled;
            DiaChi_tb.Enabled = enabled;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ResetForm()
        {
            isAddingMode = false;
            ResetTextBoxes();
            ToggleTextBoxState(false);
        }

        #region Event
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                service.LoadSuppliers();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void Them_bt_Click(object sender, EventArgs e)
        {
            isAddingMode = true;
            ResetTextBoxes();
            ToggleTextBoxState(true);
        }

        private void Luu_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingMode)
                {
                    service.AddSupplier(IdNhaCungCap_tb.Text, TenNhaCungCap_tb.Text, SdtNhaCungCap_tb.Text, DiaChi_tb.Text);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lưu nhà cung cấp: " + ex.Message);
            }
        }

        private void CapNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.UpdateSupplier(index, IdNhaCungCap_tb.Text, TenNhaCungCap_tb.Text, SdtNhaCungCap_tb.Text, DiaChi_tb.Text);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        private void Xoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteSupplier(index);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        private void Huy_bt_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void DanhSachNhaCungCap_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                service.SelectSupplier(index);
            }
        }
        #endregion
    }
}