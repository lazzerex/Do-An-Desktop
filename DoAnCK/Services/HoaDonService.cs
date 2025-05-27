using System;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK.Services
{
    public class HoaDonService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormHoaDon view;

        public HoaDonService(FormHoaDon view)
        {
            this.view = view;
        }

        public void LoadInvoices(bool isNhap)
        {
            view.ClearInvoiceGrid();
            if (isNhap)
            {
                view.SetInvoiceType("Danh sách hoá đơn nhập", "ID nhà cung cấp");
                foreach (HoaDonNhap hdn in kho.ds_hoa_don_nhap)
                {
                    if (hdn.NvLap != null && hdn.NhaCungCap != null)
                    {
                        view.AddInvoiceRow(hdn.IdHoaDon, hdn.NgayTaoDon, hdn.NvLap.IdNv, hdn.NhaCungCap.IdNcc, hdn.TongTien);
                    }
                    else
                    {
                        view.ShowError("Có hóa đơn nhập lỗi. Vui lòng kiểm tra dữ liệu.");
                    }
                }
            }
            else
            {
                view.SetInvoiceType("Danh sách hoá đơn xuất", "ID cửa hàng");
                foreach (HoaDonXuat hdx in kho.ds_hoa_don_xuat)
                {
                    if (hdx.NvLap != null && hdx.CuaHang != null)
                    {
                        view.AddInvoiceRow(hdx.IdHoaDon, hdx.NgayTaoDon, hdx.NvLap.IdNv, hdx.CuaHang.IdCh, hdx.TongTien);
                    }
                    else
                    {
                        view.ShowError("Có hóa đơn xuất lỗi. Vui lòng kiểm tra dữ liệu.");
                    }
                }
            }
            view.EnableInvoiceGrid(kho.ds_hoa_don_nhap.Count > 0 || kho.ds_hoa_don_xuat.Count > 0);
        }

        public void ShowInvoiceDetails(int index, bool isNhap)
        {
            if (isNhap)
            {
                if (index >= 0 && index < kho.ds_hoa_don_nhap.Count)
                {
                    HoaDonNhap hdn = kho.ds_hoa_don_nhap[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.SetInvoiceDetails("Hoá Đơn Nhập", hdn.NgayTaoDon.ToString(), hdn.NvLap.IdNv, hdn.IdHoaDon, $"ID nhà cung cấp: {hdn.NhaCungCap.IdNcc}");
                    formHoaDon.AddInvoiceItems(hdn.Qlnx, isNhap);
                    formHoaDon.Show();
                }
                else
                {
                    view.ShowError("Hóa đơn nhập không hợp lệ.");
                }
            }
            else
            {
                if (index >= 0 && index < kho.ds_hoa_don_xuat.Count)
                {
                    HoaDonXuat hdx = kho.ds_hoa_don_xuat[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.SetInvoiceDetails("Hoá Đơn Xuất", hdx.NgayTaoDon.ToString(), hdx.NvLap.IdNv, hdx.IdHoaDon, $"ID cửa hàng: {hdx.CuaHang.IdCh}");
                    formHoaDon.AddInvoiceItems(hdx.Qlnx, isNhap);
                    formHoaDon.Show();
                }
                else
                {
                    view.ShowError("Hóa đơn xuất không hợp lệ.");
                }
            }
        }
    }
}