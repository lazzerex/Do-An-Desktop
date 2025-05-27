using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class HangHoaService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormHangHoa view;
        private FormTrangChu parentView;

        public HangHoaService(FormHangHoa view, FormTrangChu parentView)
        {
            this.view = view;
            this.parentView = parentView;
        }

        public void LoadHangHoa(HangHoa hh)
        {
            view.PopulateLoaiHangHoa();
            if (hh == null)
            {
                view.SetAddMode();
            }
            else
            {
                view.SetViewMode(hh);
            }
        }

        public void CheckId(string id)
        {
            if (string.IsNullOrEmpty(id) || !(id.StartsWith("DT") || id.StartsWith("GD") || id.StartsWith("TR")))
            {
                view.ShowError("ID phải bắt đầu bằng DT, GD, hoặc TR.");
                view.FocusIdField();
                return;
            }

            if (kho.ds_hang_hoa.Exists(h => h.Id == id))
            {
                view.ShowError("Hàng hoá đã tồn tại");
                view.ClearIdField();
            }
        }

        public void AddHangHoa(string id, string ten, uint soLuong, ulong giaNhap, ulong giaXuat, string loai, string imgFilePath)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(loai) ||
                giaNhap == 0 || giaXuat == 0)
            {
                view.ShowError("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!view.Confirm("Bạn có chắc chắn muốn thêm hàng hoá?"))
            {
                return;
            }

            HangHoa newHH = null;
            if (loai == "Điện tử")
            {
                newHH = new DienTu(id, ten, soLuong, giaNhap, giaXuat, imgFilePath);
            }
            else if (loai == "Gia dụng")
            {
                newHH = new GiaDung(id, ten, soLuong, giaNhap, giaXuat, imgFilePath);
            }
            else if (loai == "Thời trang")
            {
                newHH = new ThoiTrang(id, ten, soLuong, giaNhap, giaXuat, imgFilePath);
            }

            if (newHH != null)
            {
                kho.them_hh(newHH); // Gọi phương thức của KhoHang, đã bao gồm lưu dữ liệu và ghi log
                parentView.RefreshProducts();
                view.CloseForm();
            }
            else
            {
                view.ShowError("Loại hàng hóa không hợp lệ!");
            }
        }

        public void RemoveHangHoa(HangHoa hh)
        {
            if (hh == null)
            {
                view.ShowError("Không có hàng hóa để xóa!");
                return;
            }

            if (!view.Confirm("Bạn có chắc chắn muốn xoá hàng hoá?"))
            {
                return;
            }

            kho.xoa_hh(hh); // Gọi phương thức của KhoHang, đã bao gồm lưu dữ liệu và ghi log
            parentView.RefreshProducts();
            view.CloseForm();
        }

        public void SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh hàng hóa",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string relativePath;
                try
                {
                    relativePath = filePath.Contains("Resources")
                        ? @".\" + filePath.Substring(filePath.IndexOf("Resources"))
                        : filePath;
                }
                catch
                {
                    relativePath = filePath; // Fallback to absolute path if Resources not found
                }
                view.SetImage(filePath, relativePath);
            }
        }
    }
}