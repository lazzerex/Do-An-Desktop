using DoAnCK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DoAnCK.Utils;
using System.Data.SQLite;

namespace DoAnCK.Models

{
    public class KhoHang
    {


        private static KhoHang _instance;
        public static KhoHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KhoHang();
                return _instance;
            }
        }

        public List<HangHoa> ds_hang_hoa = new List<HangHoa>();
        public List<NhanVien> ds_nhan_vien = new List<NhanVien>();
        public List<CuaHang> ds_cua_hang = new List<CuaHang>();
        public List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        public List<HoaDonNhap> ds_hoa_don_nhap = new List<HoaDonNhap>();
        public List<HoaDonXuat> ds_hoa_don_xuat = new List<HoaDonXuat>();

        private SQLiteHelper dbHelper;
        private bool useDatabase = false;

        public NhanVien CurrentNhanVien { get; set; }

        // constructor của lớp KhoHang
        public KhoHang()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CuaHang.db");
            if (File.Exists(dbPath))
            {
                InitSQLite(dbPath);
            }
        }

        // Phương thức khởi tạo kết nối SQLite
        public void InitSQLite(string dbFilePath)
        {
            try
            {
                dbHelper = new SQLiteHelper(dbFilePath);

                // Khởi tạo Logger sớm
                Logger.Initialize(dbFilePath);

                // Kiểm tra kết nối
                if (dbHelper.TestConnection())
                {
                    useDatabase = true;

                    // Đảm bảo các bảng cần thiết đã được tạo
                    dbHelper.CheckTablesBeforeMigration();
                }
                else
                {
                    useDatabase = false;
                }
            }
            catch (Exception ex)
            {
                useDatabase = false;
                throw new Exception("Không thể kết nối đến SQLite: " + ex.Message, ex);
            }
        }

        public void TaoTaiKhoanAdmin()
        {
            // Kiểm tra xem đã có tài khoản admin nào chưa
            NhanVien adminNV = ds_nhan_vien.Find(nv => nv.IsAdmin);

            // Nếu chưa có admin nào, tạo một tài khoản admin mặc định
            if (adminNV == null)
            {
                // Tạo ID ngẫu nhiên cho admin
                string id = "AD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Tạo tài khoản admin
                NhanVien admin = new NhanVien(
                    id,
                    "Admin",
                    30,
                    true,
                    "Địa chỉ Admin",
                    "admin",
                    "admin123",
                    true // Đặt quyền admin
                );

                // Thêm vào danh sách và lưu
                ds_nhan_vien.Add(admin);
                LuuDanhSachNV();

                //MessageBox.Show("Đã tạo tài khoản Admin mặc định.\nTên đăng nhập: admin\nMật khẩu: admin123\nVui lòng đổi mật khẩu sau khi đăng nhập lần đầu!",
                //    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaNhaCungCap(string idNcc)
        {
            // Xóa từ cơ sở dữ liệu SQLite
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    dbHelper.DeleteNhaCungCap(idNcc);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa từ SQLite: {ex.Message}");
                }
            }
        }

        public void XoaCuaHang(string idCh)
        {
            // Xóa từ cơ sở dữ liệu SQLite
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    dbHelper.DeleteCuaHang(idCh);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa từ SQLite: {ex.Message}");
                }
            }
        }
        public bool kha_dung(QuanLyNhapXuat qlnx)
        {
            for (int i = 0; i < qlnx.ds_hang_hoa.Count; i++)
            {
                HangHoa hh = qlnx.ds_hang_hoa[i];
                HangHoa hh_kho = FindHangHoaById(hh.Id);
                if (hh.SoLuong > hh_kho.SoLuong)
                {
                    return false;
                }
            }
            return true;
        }

        public void capnhatkho(QuanLyNhapXuat qlnx, bool isnhap)
        {
            for (int i = 0; i < qlnx.ds_hang_hoa.Count; i++)
            {
                HangHoa hanghoa = qlnx.ds_hang_hoa[i];
                HangHoa hh_kho = FindHangHoaById(hanghoa.Id);
                if (isnhap)
                {
                    hh_kho.SoLuong += hanghoa.SoLuong;
                }
                else
                {
                    hh_kho.SoLuong -= hanghoa.SoLuong;
                }
            }
            LuuDanhSachHH();
        }

        public NhanVien dang_nhap(string username, string password)
        {
            for (int i = 0; i < ds_nhan_vien.Count; i++)
            {
                NhanVien nv = ds_nhan_vien[i];
                if (nv.Username == username && nv.Password == password)
                {
                    return nv;
                }
            }
            return null;
        }

        public void LuuDanhSachCH()
        {
            bool luuSQLiteThanhCong = false;

            // Ưu tiên lưu vào SQLite trước
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    foreach (CuaHang ch in ds_cua_hang)
                    {
                        dbHelper.InsertCuaHang(ch);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/cua_hang.dat", ds_cua_hang);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu cửa hàng: {ex.Message}", ex);
                }
            }
        }

        public void them_hh(HangHoa hh)
        {
            ds_hang_hoa.Add(hh);
            LuuDanhSachHH();

            // Ghi log
            if (CurrentNhanVien != null)
            {
                Logger.LogThemHangHoa(CurrentNhanVien, hh);
            }
        }

        public void xoa_hh(HangHoa hh)
        {
            ds_hang_hoa.Remove(hh);
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    dbHelper.DeleteHangHoa(hh.Id); // Xóa trong database
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa hàng hóa từ SQLite: {ex.Message}");
                }
            }
            LuuDanhSachHH(); // Lưu danh sách còn lại

            // Ghi log
            if (CurrentNhanVien != null)
            {
                Logger.LogXoaHangHoa(CurrentNhanVien, hh);
            }
        }

        public void ThemHoaDonNhap(HoaDonNhap hoaDon)
        {
            ds_hoa_don_nhap.Add(hoaDon);
            LuuDanhSachHDN();

            // Ghi log
            if (CurrentNhanVien != null)
            {
                Logger.LogNhapHang(CurrentNhanVien, hoaDon);
            }
        }

        public void ThemHoaDonXuat(HoaDonXuat hoaDon)
        {
            ds_hoa_don_xuat.Add(hoaDon);
            LuuDanhSachHDX();

            // Ghi log
            if (CurrentNhanVien != null)
            {
                Logger.LogXuatHang(CurrentNhanVien, hoaDon);
            }
        }


        public void LoadData(bool fromDatabase = false)
        {
            if (fromDatabase && dbHelper != null)
            {
                try
                {
                    // Ưu tiên đọc từ SQLite
                    dbHelper.LoadDataFromSQLiteToKhoHang(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi đọc từ SQLite: {ex.Message}. Thử đọc từ file XML...");
                    LoadFromXml();
                }
            }
            else
            {
                try
                {
                    // Vẫn ưu tiên đọc từ SQLite nếu có thể
                    if (useDatabase && dbHelper != null)
                    {
                        dbHelper.LoadDataFromSQLiteToKhoHang(this);
                    }
                    else
                    {
                        LoadFromXml();
                    }
                }
                catch (Exception ex)
                {
                    // Nếu không đọc được từ SQLite, thử đọc từ XML
                    try
                    {
                        LoadFromXml();
                    }
                    catch
                    {
                        throw ex; // Nếu cả hai cách đều thất bại, ném ngoại lệ gốc
                    }
                }
            }
        }

        private void LoadFromXml()
        {
            ds_hang_hoa = LoadDanhSach<HangHoa>("Resources/hang_hoa.dat");
            ds_ncc = LoadDanhSach<NhaCungCap>("Resources/nha_cung_cap.dat");
            ds_cua_hang = LoadDanhSach<CuaHang>("Resources/cua_hang.dat");
            ds_hoa_don_nhap = LoadDanhSach<HoaDonNhap>("Resources/hoa_don_nhap.dat");
            ds_hoa_don_xuat = LoadDanhSach<HoaDonXuat>("Resources/hoa_don_xuat.dat");
            ds_nhan_vien = LoadDanhSach<NhanVien>("Resources/nhan_vien.dat");
        }

        public void SaveToDatabase()
        {
            if (dbHelper != null)
            {
                try
                {
                    // Lưu tất cả dữ liệu vào SQLite
                    foreach (CuaHang ch in ds_cua_hang)
                    {
                        dbHelper.InsertCuaHang(ch);
                    }

                    foreach (NhaCungCap ncc in ds_ncc)
                    {
                        dbHelper.InsertNhaCungCap(ncc);
                    }

                    foreach (NhanVien nv in ds_nhan_vien)
                    {
                        dbHelper.InsertNhanVien(nv);
                    }

                    foreach (HangHoa hh in ds_hang_hoa)
                    {
                        dbHelper.InsertHangHoa(hh);
                    }

                    foreach (HoaDonNhap hdn in ds_hoa_don_nhap)
                    {
                        dbHelper.InsertHoaDon(hdn);
                    }

                    foreach (HoaDonXuat hdx in ds_hoa_don_xuat)
                    {
                        dbHelper.InsertHoaDon(hdx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào cơ sở dữ liệu: {ex.Message}");
                    // Có thể thêm code để lưu vào XML nếu lưu vào Database thất bại
                    try
                    {
                        // Lưu tất cả dữ liệu vào các file XML
                        LuuDanhSach("Resources/cua_hang.dat", ds_cua_hang);
                        LuuDanhSach("Resources/nha_cung_cap.dat", ds_ncc);
                        LuuDanhSach("Resources/nhan_vien.dat", ds_nhan_vien);
                        LuuDanhSach("Resources/hang_hoa.dat", ds_hang_hoa);
                        LuuDanhSach("Resources/hoa_don_nhap.dat", ds_hoa_don_nhap);
                        LuuDanhSach("Resources/hoa_don_xuat.dat", ds_hoa_don_xuat);
                        Console.WriteLine("Đã lưu dữ liệu vào XML do không thể lưu vào cơ sở dữ liệu");
                    }
                    catch (Exception innerEx)
                    {
                        throw new Exception($"Không thể lưu dữ liệu (cả SQLite và XML): {innerEx.Message}", innerEx);
                    }
                }
            }
            else
            {
                // Nếu không có kết nối đến SQLite, lưu vào XML
                try
                {
                    LuuDanhSach("Resources/cua_hang.dat", ds_cua_hang);
                    LuuDanhSach("Resources/nha_cung_cap.dat", ds_ncc);
                    LuuDanhSach("Resources/nhan_vien.dat", ds_nhan_vien);
                    LuuDanhSach("Resources/hang_hoa.dat", ds_hang_hoa);
                    LuuDanhSach("Resources/hoa_don_nhap.dat", ds_hoa_don_nhap);
                    LuuDanhSach("Resources/hoa_don_xuat.dat", ds_hoa_don_xuat);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu vào XML: {ex.Message}", ex);
                }
            }
        }


        private HangHoa FindHangHoaById(string id)
        {
            for (int i = 0; i < ds_hang_hoa.Count; i++)
            {
                if (ds_hang_hoa[i].Id == id)
                {
                    return ds_hang_hoa[i];
                }
            }
            return null;
        }

        public void LuuDanhSachNV()
        {
            bool luuSQLiteThanhCong = false;

            // Ưu tiên lưu vào SQLite trước
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    foreach (NhanVien nv in ds_nhan_vien)
                    {
                        dbHelper.InsertNhanVien(nv);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/nhan_vien.dat", ds_nhan_vien);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu nhân viên: {ex.Message}", ex);
                }
            }
            
            
        }

        public void LuuDanhSachNCC()
        {
            bool luuSQLiteThanhCong = false;

            // Ưu tiên lưu vào SQLite trước
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    foreach (var ncc in ds_ncc)
                    {
                        dbHelper.InsertNhaCungCap(ncc);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/nha_cung_cap.dat", ds_ncc);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu nhà cung cấp: {ex.Message}", ex);
                }
            }

       
        }

        private void LuuDanhSach(string filePath, object data)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(writer, data);
            }
        }

        public void LuuDanhSachHH()
        {
            bool luuSQLiteThanhCong = false;

            // Xóa tất cả hàng hóa trong database trước khi lưu mới
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    // Xóa toàn bộ bảng HangHoa để đồng bộ với ds_hang_hoa
                    ExecuteNonQuery("DELETE FROM HangHoa");
                    foreach (HangHoa hh in ds_hang_hoa)
                    {
                        dbHelper.InsertHangHoa(hh);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/hang_hoa.dat", ds_hang_hoa);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu hàng hóa: {ex.Message}", ex);
                }
            }
        }

        private void LuuDanhSachHDX()
        {
            bool luuSQLiteThanhCong = false;

            // Ưu tiên lưu vào SQLite trước
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    foreach (HoaDonXuat hdx in ds_hoa_don_xuat)
                    {
                        dbHelper.InsertHoaDon(hdx);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/hoa_don_xuat.dat", ds_hoa_don_xuat);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu hóa đơn xuất: {ex.Message}", ex);
                }
            }
        }

        private void LuuDanhSachHDN()
        {
            bool luuSQLiteThanhCong = false;

            // Ưu tiên lưu vào SQLite trước
            if (useDatabase && dbHelper != null)
            {
                try
                {
                    foreach (HoaDonNhap hdn in ds_hoa_don_nhap)
                    {
                        dbHelper.InsertHoaDon(hdn);
                    }
                    luuSQLiteThanhCong = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào SQLite: {ex.Message}");
                    luuSQLiteThanhCong = false;
                }
            }

            // Nếu không lưu được vào SQLite hoặc không dùng SQLite, lưu vào XML
            if (!luuSQLiteThanhCong)
            {
                try
                {
                    LuuDanhSach("Resources/hoa_don_nhap.dat", ds_hoa_don_nhap);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thể lưu dữ liệu hóa đơn nhập: {ex.Message}", ex);
                }
            }
        }

        private List<T> LoadDanhSach<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                return (List<T>)serializer.Deserialize(reader);
            }
        }
        public string SinhIdHoaDonNhap()
        {
            int max = 0;
            foreach (var hd in ds_hoa_don_nhap)
            {
                if (!string.IsNullOrEmpty(hd.IdHoaDon) && hd.IdHoaDon.StartsWith("HDN"))
                {
                    if (int.TryParse(hd.IdHoaDon.Substring(3), out int so))
                        if (so > max) max = so;
                }
            }
            return "HDN" + (max + 1);
        }

        public string SinhIdHoaDonXuat()
        {
            int max = 0;
            foreach (var hd in ds_hoa_don_xuat)
            {
                if (!string.IsNullOrEmpty(hd.IdHoaDon) && hd.IdHoaDon.StartsWith("HDX"))
                {
                    if (int.TryParse(hd.IdHoaDon.Substring(3), out int so))
                        if (so > max) max = so;
                }
            }
            return "HDX" + (max + 1);
        }

        private void ExecuteNonQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbHelper.DatabasePath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
