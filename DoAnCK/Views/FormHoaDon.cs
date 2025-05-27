using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormHoaDon : Form
    {
        private HoaDonService service;
        private bool isNhap;

        public FormHoaDon(bool isNhap)
        {
            InitializeComponent();
            this.isNhap = isNhap;
            this.service = new HoaDonService(this);
            KhoHang.Instance.LoadData();
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
        }

        public void SetInvoiceType(string title, string idColumnHeader)
        {
            label1.Text = title;
            DanhSachHoaDon_dgv.Columns["idnccch_hd"].HeaderText = idColumnHeader;
        }

        public void AddInvoiceRow(string id, DateTime ngayTao, string idNv, string idNccCh, ulong tongTien)
        {
            DanhSachHoaDon_dgv.Rows.Add(id, ngayTao, idNv, idNccCh, tongTien);
        }

        public void ClearInvoiceGrid()
        {
            DanhSachHoaDon_dgv.Rows.Clear();
        }

        public void EnableInvoiceGrid(bool enable)
        {
            DanhSachHoaDon_dgv.Enabled = enable;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Event
        private void HoaDon_load(object sender, EventArgs e)
        {
            try
            {
                service.LoadInvoices(isNhap);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách hóa đơn: " + ex.Message);
            }
        }

        private void DanhSachHoaDon_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = DanhSachHoaDon_dgv.CurrentCell.RowIndex;
                service.ShowInvoiceDetails(index, isNhap);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi hiển thị chi tiết hóa đơn: " + ex.Message);
            }
        }
        #endregion
    }
}