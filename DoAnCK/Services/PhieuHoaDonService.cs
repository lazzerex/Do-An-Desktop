using System;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK.Services
{
    public class PhieuHoaDonService
    {
        private FormPhieuHoaDon view;

        public PhieuHoaDonService(FormPhieuHoaDon view)
        {
            this.view = view;
        }

        public void AddInvoiceItems(QuanLyNhapXuat qlnx, bool isNhap)
        {
            foreach (HangHoa hh in qlnx.ds_hang_hoa)
            {
                view.AddProduct(hh, isNhap);
            }

            ulong tongTien = 0;
            ulong soLuong = 0;
            foreach (HangHoa hh in qlnx.ds_hang_hoa)
            {
                tongTien += (isNhap ? hh.DonGia : hh.GiaXuat) * hh.SoLuong;
                soLuong += hh.SoLuong;
            }

            view.AddInvoiceSummary(soLuong, String.Format("{0:N0}", tongTien));
        }
    }
}