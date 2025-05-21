using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCK
{
    public static class Logger
    {
        private static SQLiteHelper _dbHelper;

        public static void Initialize(string dbPath)
        {
            try
            {
                if (string.IsNullOrEmpty(dbPath))
                {
                    dbPath = System.IO.Path.Combine(Application.StartupPath, "CuaHang.db");
                }

                _dbHelper = new SQLiteHelper(dbPath);

                // Đảm bảo bảng log tồn tại
                _dbHelper.CreateLogTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo Logger: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức kiểm tra Logger đã được khởi tạo chưa
        private static bool IsInitialized()
        {
            if (_dbHelper == null)
            {
                // Tự động khởi tạo với đường dẫn mặc định
                Initialize(null);
                return _dbHelper != null;
            }
            return true;
        }



        public static void LogLogin(NhanVien nv)
        {
            if (IsInitialized() && nv != null)
            {
                _dbHelper.InsertLog(nv.IdNv, "Đăng nhập", $"Nhân viên {nv.TenNv} đã đăng nhập");
            }
        }

        public static void LogLogout(NhanVien nv)
        {
            if (IsInitialized() && nv != null)
            {
                _dbHelper.InsertLog(nv.IdNv, "Đăng xuất", $"Nhân viên {nv.TenNv} đã đăng xuất");
            }
        }

        public static void LogNhapHang(NhanVien nv, HoaDonNhap hoaDon)
        {
            if (IsInitialized() && nv != null)
            {
                string details = $"Mã hóa đơn: {hoaDon.IdHoaDon}, Tổng tiền: {hoaDon.TongTien}, NCC: {hoaDon.NhaCungCap.TenNcc}";
                _dbHelper.InsertLog(nv.IdNv, "Nhập hàng", $"Nhân viên {nv.TenNv} đã nhập hàng", details);
            }
        }

        public static void LogXuatHang(NhanVien nv, HoaDonXuat hoaDon)
        {
            if (IsInitialized() && nv != null)
            {
                string details = $"Mã hóa đơn: {hoaDon.IdHoaDon}, Tổng tiền: {hoaDon.TongTien}, Cửa hàng: {hoaDon.CuaHang.TenCh}";
                _dbHelper.InsertLog(nv.IdNv, "Xuất hàng", $"Nhân viên {nv.TenNv} đã xuất hàng", details);
            }
        }


        public static void LogThemNhaCungCap(NhanVien nv, NhaCungCap ncc)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã NCC: {ncc.IdNcc}, Tên NCC: {ncc.TenNcc}";
                _dbHelper.InsertLog(nv.IdNv, "Thêm NCC", $"Nhân viên {nv.TenNv} đã thêm nhà cung cấp mới", details);
            }
        }

        public static void LogXoaNhaCungCap(NhanVien nv, NhaCungCap ncc)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã NCC: {ncc.IdNcc}, Tên NCC: {ncc.TenNcc}";
                _dbHelper.InsertLog(nv.IdNv, "Xóa NCC", $"Nhân viên {nv.TenNv} đã xóa nhà cung cấp", details);
            }
        }

        public static void LogThemCuaHang(NhanVien nv, CuaHang ch)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã CH: {ch.IdCh}, Tên CH: {ch.TenCh}";
                _dbHelper.InsertLog(nv.IdNv, "Thêm cửa hàng", $"Nhân viên {nv.TenNv} đã thêm cửa hàng mới", details);
            }
        }

        public static void LogXoaCuaHang(NhanVien nv, CuaHang ch)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã CH: {ch.IdCh}, Tên CH: {ch.TenCh}";
                _dbHelper.InsertLog(nv.IdNv, "Xóa cửa hàng", $"Nhân viên {nv.TenNv} đã xóa cửa hàng", details);
            }
        }

        public static void LogThemHangHoa(NhanVien nv, HangHoa hh)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã HH: {hh.Id}, Tên HH: {hh.TenHang}, Số lượng: {hh.SoLuong}, Đơn giá: {hh.DonGia}";
                _dbHelper.InsertLog(nv.IdNv, "Thêm hàng hóa", $"Nhân viên {nv.TenNv} đã thêm hàng hóa mới", details);
            }
        }

        public static void LogXoaHangHoa(NhanVien nv, HangHoa hh)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã HH: {hh.Id}, Tên HH: {hh.TenHang}";
                _dbHelper.InsertLog(nv.IdNv, "Xóa hàng hóa", $"Nhân viên {nv.TenNv} đã xóa hàng hóa", details);
            }
        }

        public static void LogGeneric(NhanVien nv, string activityType, string description, string details = "")
        {
            if (_dbHelper != null && nv != null)
            {
                _dbHelper.InsertLog(nv.IdNv, activityType, description, details);
            }
        }

       

        public static void LogSuaHangHoa(NhanVien nv, HangHoa oldHH, HangHoa newHH)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã HH: {newHH.Id}, " +
                    $"Tên hàng: từ '{oldHH.TenHang}' thành '{newHH.TenHang}', " +
                    $"Số lượng: từ {oldHH.SoLuong} thành {newHH.SoLuong}, " +
                    $"Đơn giá: từ {oldHH.DonGia} thành {newHH.DonGia}";
                _dbHelper.InsertLog(nv.IdNv, "Sửa hàng hóa", $"Nhân viên {nv.TenNv} đã cập nhật thông tin hàng hóa", details);
            }
        }

        public static void LogThemNhanVien(NhanVien admin, NhanVien newNV)
        {
            if (_dbHelper != null && admin != null)
            {
                string details = $"Mã NV: {newNV.IdNv}, Tên NV: {newNV.TenNv}, Username: {newNV.Username}, Là Admin: {(newNV.IsAdmin ? "Có" : "Không")}";
                _dbHelper.InsertLog(admin.IdNv, "Thêm nhân viên", $"Admin {admin.TenNv} đã thêm nhân viên mới", details);
            }
        }

        public static void LogXoaNhanVien(NhanVien admin, NhanVien deletedNV)
        {
            if (_dbHelper != null && admin != null)
            {
                string details = $"Mã NV: {deletedNV.IdNv}, Tên NV: {deletedNV.TenNv}, Username: {deletedNV.Username}";
                _dbHelper.InsertLog(admin.IdNv, "Xóa nhân viên", $"Admin {admin.TenNv} đã xóa nhân viên", details);
            }
        }

        public static void LogCapNhatQuyen(NhanVien admin, NhanVien targetNV, bool isNowAdmin)
        {
            if (_dbHelper != null && admin != null)
            {
                string details = $"Mã NV: {targetNV.IdNv}, Tên NV: {targetNV.TenNv}, Trạng thái quyền: {(isNowAdmin ? "Cấp quyền Admin" : "Hủy quyền Admin")}";
                _dbHelper.InsertLog(admin.IdNv, "Cập nhật quyền", $"Admin {admin.TenNv} đã {(isNowAdmin ? "cấp" : "hủy")} quyền admin cho nhân viên {targetNV.TenNv}", details);
            }
        }

        public static void LogSuaThongTinNCC(NhanVien nv, NhaCungCap oldNCC, NhaCungCap newNCC)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã NCC: {newNCC.IdNcc}, " +
                    $"Tên: từ '{oldNCC.TenNcc}' thành '{newNCC.TenNcc}', " +
                    $"SĐT: từ '{oldNCC.SdtNcc}' thành '{newNCC.SdtNcc}', " +
                    $"Địa chỉ: từ '{oldNCC.DiaChiNcc}' thành '{newNCC.DiaChiNcc}'";
                _dbHelper.InsertLog(nv.IdNv, "Sửa thông tin NCC", $"Nhân viên {nv.TenNv} đã cập nhật thông tin nhà cung cấp", details);
            }
        }

        public static void LogSuaThongTinCH(NhanVien nv, CuaHang oldCH, CuaHang newCH)
        {
            if (_dbHelper != null && nv != null)
            {
                string details = $"Mã CH: {newCH.IdCh}, " +
                    $"Tên: từ '{oldCH.TenCh}' thành '{newCH.TenCh}', " +
                    $"SĐT: từ '{oldCH.SdtCh}' thành '{newCH.SdtCh}', " +
                    $"Địa chỉ: từ '{oldCH.DiaChiCh}' thành '{newCH.DiaChiCh}'";
                _dbHelper.InsertLog(nv.IdNv, "Sửa thông tin CH", $"Nhân viên {nv.TenNv} đã cập nhật thông tin cửa hàng", details);
            }
        }

    }
}