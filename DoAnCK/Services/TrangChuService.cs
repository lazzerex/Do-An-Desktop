using System;
using System.Linq;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK.Services
{
    public class TrangChuService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormTrangChu view;

        public TrangChuService(FormTrangChu view)
        {
            this.view = view;
        }

        public void LoadProducts(string searchText, string loaiHangHoa)
        {
            view.ClearProductList();
            if (kho.ds_hang_hoa == null || !kho.ds_hang_hoa.Any())
            {
                view.ShowError($"Không có hàng hóa trong kho. Số lượng: {kho.ds_hang_hoa?.Count ?? 0}");
                return;
            }

            // Debug: In giá trị searchText và loaiHangHoa
            Console.WriteLine($"LoadProducts: searchText='{searchText}', loaiHangHoa='{loaiHangHoa}'");

            var filteredProducts = kho.ds_hang_hoa
                .Where(hh => string.IsNullOrWhiteSpace(searchText) || hh.TenHang.ToLower().Contains(searchText.Trim().ToLower()))
                .Where(hh =>
                {
                    if (string.IsNullOrEmpty(loaiHangHoa) || loaiHangHoa.ToLower() == "tất cả")
                        return true;

                    switch (loaiHangHoa.ToLower())
                    {
                        case "điện tử":
                            return hh is DienTu;
                        case "gia dụng":
                            return hh is GiaDung;
                        case "thời trang":
                            return hh is ThoiTrang;
                        default:
                            return false;
                    }
                });

            int count = 0;
            foreach (HangHoa hh in filteredProducts)
            {
                view.AddProduct(hh);
                count++;
                // Debug: In thông tin hàng hóa
                Console.WriteLine($"Hàng hóa: Id={hh.Id}, Ten={hh.TenHang}, Loai={hh.GetType().Name}");
            }

            if (count == 0)
            {
                view.ShowMessage($"Không tìm thấy hàng hóa. Bộ lọc: loai='{loaiHangHoa}', search='{searchText}'. Tổng hàng hóa: {kho.ds_hang_hoa.Count}");
            }
        }

        public void ShowHangHoaDetails(HangHoa hh, NhanVien currentNhanVien)
        {
            FormHangHoa formHangHoa = new FormHangHoa(hh, view);
            formHangHoa.SetCurrentNhanVien(currentNhanVien);
            formHangHoa.ShowDialog();
        }

        public void AddNewProduct(NhanVien currentNhanVien)
        {
            FormHangHoa formHangHoa = new FormHangHoa(null, view);
            formHangHoa.SetCurrentNhanVien(currentNhanVien);
            formHangHoa.ShowDialog();
        }
    }
}