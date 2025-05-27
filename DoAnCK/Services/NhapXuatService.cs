using System;
using System.Linq;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK.Services
{
    public class NhapXuatService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormNhapXuat view;
        private QuanLyNhapXuat qlnx = new QuanLyNhapXuat();
        private NhanVien currentNhanVien;
        private bool isNhap;

        public NhapXuatService(FormNhapXuat view, NhanVien currentNhanVien, bool isNhap)
        {
            this.view = view;
            this.currentNhanVien = currentNhanVien;
            this.isNhap = isNhap;
            kho.CurrentNhanVien = currentNhanVien;
        }

        public void Initialize()
        {
            if (isNhap)
            {
                view.SetEntityType("Nhà cung cấp");
                view.PopulateEntityComboBox(kho.ds_ncc.Select(ncc => ncc.TenNcc).ToList());
            }
            else
            {
                view.SetEntityType("Cửa hàng");
                view.PopulateEntityComboBox(kho.ds_cua_hang.Select(ch => ch.TenCh).ToList());
            }
            ReloadProductList("");
        }

        public void AddSelectedProduct(HangHoa hh)
        {
            if (!qlnx.ton_tai(hh))
            {
                HangHoa clone = (HangHoa)hh.Clone();
                clone.SoLuong = 1;
                qlnx.them_hh(clone);
                view.AddSelectedProduct(clone, isNhap);
                UpdateTotal();
            }
        }

        public void RemoveSelectedProduct(HangHoa hh)
        {
            qlnx.xoa_hh(hh);
            UpdateTotal();
        }

        public void UpdateProductQuantity(HangHoa hh, uint soLuong)
        {
            qlnx.cap_nhat_sl(hh, soLuong);
            UpdateTotal();
        }

        public void ClearSelectedProducts()
        {
            qlnx = new QuanLyNhapXuat();
            view.ClearSelectedProducts();
            UpdateTotal();
        }

        public void ReloadProductList(string searchText, string loaiHangHoa = "")
        {
            view.ClearProductList();
            var filteredProducts = kho.ds_hang_hoa
                .Where(hh => string.IsNullOrEmpty(searchText) || hh.TenHang.ToLower().Contains(searchText.ToLower()))
                .Where(hh => string.IsNullOrEmpty(loaiHangHoa) ||
                             (loaiHangHoa == "Điện tử" && hh is DienTu) ||
                             (loaiHangHoa == "Gia dụng" && hh is GiaDung) ||
                             (loaiHangHoa == "Thời trang" && hh is ThoiTrang));

            foreach (HangHoa hh in filteredProducts)
            {
                view.AddProduct(hh, isNhap);
            }
        }

        public void CreateInvoice(string selectedEntity)
        {
            if (string.IsNullOrEmpty(selectedEntity))
            {
                view.ShowError(isNhap ? "Hãy chọn nhà cung cấp!" : "Hãy chọn cửa hàng!");
                return;
            }

            if (qlnx.ds_hang_hoa.Count == 0)
            {
                view.ShowError("Vui lòng chọn ít nhất một sản phẩm!");
                return;
            }

            if (isNhap)
            {
                NhaCungCap ncc = kho.ds_ncc.FirstOrDefault(n => n.TenNcc == selectedEntity);
                if (ncc == null)
                {
                    view.ShowError("Nhà cung cấp không hợp lệ!");
                    return;
                }

                kho.capnhatkho(qlnx, true);
                HoaDonNhap hdn = new HoaDonNhap(qlnx, kho.SinhIdHoaDonNhap(), currentNhanVien, ncc, qlnx.tinh_tong_tien(isNhap));
                kho.ThemHoaDonNhap(hdn); // Includes logging via Logger.LogNhapHang

                FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                formHoaDon.SetInvoiceDetails("Hoá Đơn Nhập", hdn.NgayTaoDon.ToString(), hdn.NvLap.IdNv, hdn.IdHoaDon, $"ID nhà cung cấp: {ncc.IdNcc}");
                formHoaDon.AddInvoiceItems(hdn.Qlnx, isNhap);
                formHoaDon.Show();
            }
            else
            {
                CuaHang ch = kho.ds_cua_hang.FirstOrDefault(c => c.TenCh == selectedEntity);
                if (ch == null)
                {
                    view.ShowError("Cửa hàng không hợp lệ!");
                    return;
                }

                if (!kho.kha_dung(qlnx))
                {
                    view.ShowError("Số lượng tồn kho không đủ!");
                    return;
                }

                kho.capnhatkho(qlnx, false);
                HoaDonXuat hdx = new HoaDonXuat(qlnx, kho.SinhIdHoaDonXuat(), currentNhanVien, ch, qlnx.tinh_tong_tien(isNhap));
                kho.ThemHoaDonXuat(hdx); // Includes logging via Logger.LogXuatHang

                FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                formHoaDon.SetInvoiceDetails("Hoá Đơn Xuất", hdx.NgayTaoDon.ToString(), hdx.NvLap.IdNv, hdx.IdHoaDon, $"ID cửa hàng: {ch.IdCh}");
                formHoaDon.AddInvoiceItems(hdx.Qlnx, isNhap);
                formHoaDon.Show();
            }

            ClearSelectedProducts();
            ReloadProductList("");
        }

        private void UpdateTotal()
        {
            ulong tongTien = qlnx.tinh_tong_tien(isNhap);
            view.UpdateTotal(String.Format("{0:N0}", tongTien));
        }
    }
}