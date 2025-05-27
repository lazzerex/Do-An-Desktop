using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormCuaHang : Form
    {
        private CuaHangService service;
        private bool isAddingMode = false;
        private int index = -1;

        public FormCuaHang(NhanVien nhanVien = null)
        {
            InitializeComponent();
            this.service = new CuaHangService(this);
            KhoHang.Instance.LoadData();
            if (nhanVien != null)
            {
                SetCurrentNhanVien(nhanVien);
            }
            ResetTextBoxes();
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
        }

        public void AddStoreRow(string id, string ten, string sdt, string diaChi)
        {
            DanhSachCuaHang_dgv.Rows.Add(id, ten, sdt, diaChi);
        }

        public void UpdateStoreRow(int index, string id, string ten, string sdt, string diaChi)
        {
            DanhSachCuaHang_dgv.Rows[index].Cells[0].Value = id;
            DanhSachCuaHang_dgv.Rows[index].Cells[1].Value = ten;
            DanhSachCuaHang_dgv.Rows[index].Cells[2].Value = sdt;
            DanhSachCuaHang_dgv.Rows[index].Cells[3].Value = diaChi;
            DanhSachCuaHang_dgv.Refresh();
        }

        public void RemoveStoreRow(int index)
        {
            DanhSachCuaHang_dgv.Rows.RemoveAt(index);
        }

        public void ClearStoreGrid()
        {
            DanhSachCuaHang_dgv.Rows.Clear();
        }

        public void EnableStoreGrid(bool enable)
        {
            DanhSachCuaHang_dgv.Enabled = enable;
        }

        public void SetStoreInfo(string id, string ten, string sdt, string diaChi)
        {
            IdCuaHang_tb.Text = id;
            TenCuaHang_tb.Text = ten;
            SdtCuaHang_tb.Text = sdt;
            DiaChi_tb.Text = diaChi;
        }

        public void ResetTextBoxes()
        {
            IdCuaHang_tb.Clear();
            TenCuaHang_tb.Clear();
            SdtCuaHang_tb.Clear();
            DiaChi_tb.Clear();
        }

        public void ToggleTextBoxState(bool enabled)
        {
            IdCuaHang_tb.Enabled = enabled;
            TenCuaHang_tb.Enabled = enabled;
            SdtCuaHang_tb.Enabled = enabled;
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
        private void FormCuaHang_Load(object sender, EventArgs e)
        {
            try
            {
                service.LoadStores();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách cửa hàng: " + ex.Message);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            isAddingMode = true;
            ResetTextBoxes();
            ToggleTextBoxState(true);
        }

        private void LuuCuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingMode)
                {
                    service.AddStore(IdCuaHang_tb.Text, TenCuaHang_tb.Text, SdtCuaHang_tb.Text, DiaChi_tb.Text);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lưu cửa hàng: " + ex.Message);
            }
        }

        private void CapNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.UpdateStore(index, IdCuaHang_tb.Text, TenCuaHang_tb.Text, SdtCuaHang_tb.Text, DiaChi_tb.Text);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi cập nhật cửa hàng: " + ex.Message);
            }
        }

        private void XoaCuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteStore(index);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xóa cửa hàng: " + ex.Message);
            }
        }

        private void Huy_bt_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void DanhSachCuaHang_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                service.SelectStore(index);
            }
        }
        #endregion
    }
}