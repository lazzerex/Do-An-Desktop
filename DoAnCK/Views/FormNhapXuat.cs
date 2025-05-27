using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormNhapXuat : Form
    {
        private NhapXuatService service;
        public bool isNhap;

        public FormNhapXuat(NhanVien currentNhanVien, bool isNhap)
        {
            InitializeComponent();
            this.isNhap = isNhap;
            this.service = new NhapXuatService(this, currentNhanVien, isNhap);
            KhoHang.Instance.LoadData();
            service.Initialize();
        }

        public void SetEntityType(string label)
        {
            lanbel2.Text = label;
        }

        public void PopulateEntityComboBox(List<string> entities)
        {
            DsNccCh_cb.Items.Clear();
            DsNccCh_cb.Items.AddRange(entities.ToArray());
        }

        public void AddProduct(HangHoa hh, bool isNhap)
        {
            HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
            hh_component.hh = hh;
            hh_component.SetProductInfo(hh, isNhap);
            DanhSachHangHoa_flp.Controls.Add(hh_component);
        }

        public void AddSelectedProduct(HangHoa hh, bool isNhap)
        {
            HangHoaDuocChonComponent hh_lo = new HangHoaDuocChonComponent(this);
            hh_lo.hh = hh;
            hh_lo.SetProductInfo(isNhap);
            HangHoaDuocChon_flp.Controls.Add(hh_lo);
        }

        public void ClearProductList()
        {
            DanhSachHangHoa_flp.Controls.Clear();
        }

        public void ClearSelectedProducts()
        {
            HangHoaDuocChon_flp.Controls.Clear();
        }

        public void UpdateTotal(string tongTien)
        {
            TongTienHang_lb.Text = $"Tổng tiền: {tongTien} VNĐ";
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AddProduct(HangHoa hh)
        {
            service.AddSelectedProduct(hh);
        }

        public void RemoveProduct(HangHoaDuocChonComponent component)
        {
            service.RemoveSelectedProduct(component.hh);
            HangHoaDuocChon_flp.Controls.Remove(component);
        }

        public void UpdateProductQuantity(HangHoa hh, uint soLuong)
        {
            service.UpdateProductQuantity(hh, soLuong);
        }

        #region Event
        private void KhungTimKiem_tb_TextChanged(object sender, EventArgs e)
        {
            service.ReloadProductList(KhungTimKiem_tb.Text, LoaiHangHoa_cb.Text);
        }

        private void LoaiHangHoa_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            service.ReloadProductList(KhungTimKiem_tb.Text, LoaiHangHoa_cb.Text);
        }

        private void KhungTimKiem_tb_Click(object sender, EventArgs e)
        {
            KhungTimKiem_tb.Text = "";
        }

        private void Huy_bt_Click(object sender, EventArgs e)
        {
            service.ClearSelectedProducts();
        }

        private void XuatHoaDon_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.CreateInvoice(DsNccCh_cb.Text);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xuất hóa đơn: " + ex.Message);
            }
        }
        #endregion
    }
}