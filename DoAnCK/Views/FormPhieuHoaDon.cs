using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormPhieuHoaDon : Form
    {
        private PhieuHoaDonService service;

        public FormPhieuHoaDon()
        {
            InitializeComponent();
            this.service = new PhieuHoaDonService(this);
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
        }

        public void SetInvoiceDetails(string type, string ngayLap, string idNv, string idHd, string idNccCh)
        {
            hd_lbl.Text = type;
            ngaylap_lbl.Text = $"Ngày lập: {ngayLap}";
            idnv_lbl.Text = $"ID nhân viên lập: {idNv}";
            idhd_lbl.Text = $"ID hoá đơn: {idHd}";
            idncc_ch_lbl.Text = idNccCh;
        }

        public void AddProduct(HangHoa hh, bool isNhap)
        {
            HoaDon1Component billComponent = new HoaDon1Component(this);
            billComponent.hh = hh;
            billComponent.SetProductInfo(hh, isNhap);
            dshd_flp.Controls.Add(billComponent);
        }

        public void AddInvoiceSummary(ulong soLuong, string tongTien)
        {
            HoaDon2Component billTailComponent = new HoaDon2Component();
            billTailComponent.soluong_endbill.Text = $"Số Lượng: {soLuong}";
            billTailComponent.thanhtien_endbill.Text = $"Thành Tiền: {tongTien} VNĐ";
            dshd_flp.Controls.Add(billTailComponent);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AddInvoiceItems(QuanLyNhapXuat qlnx, bool isNhap)
        {
            try
            {
                service.AddInvoiceItems(qlnx, isNhap);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi hiển thị chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}