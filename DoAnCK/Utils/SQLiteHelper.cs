using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DoAnCK.Models;
namespace DoAnCK.Utils
{
    public class SQLiteHelper
    {
        private readonly string _connectionString;
        private readonly string _databasePath;
        public string DatabasePath => _databasePath;
        public SQLiteHelper(string dbFilePath)
        {
            _databasePath = dbFilePath;
            _connectionString = $"Data Source={dbFilePath};Version=3;";

            // Tạo file database nếu chưa tồn tại
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        public void CreateNhaCungCapTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS NhaCungCap (
                id_ncc TEXT PRIMARY KEY,
                ten_ncc TEXT NOT NULL,
                sdt_ncc TEXT,
                dia_chi_ncc TEXT
            );";

            ExecuteNonQuery(query);
        }

        public void CreateNhanVienTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS NhanVien (
                id_nv TEXT PRIMARY KEY,
                ten_nv TEXT NOT NULL,
                tuoi INTEGER,
                gioi_tinh INTEGER,
                dia_chi_nv TEXT,
                username TEXT UNIQUE,
                password TEXT,
                is_admin INTEGER DEFAULT 0
            );";

            ExecuteNonQuery(query);
        }

        public void CreateHangHoaTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS HangHoa (
                id TEXT PRIMARY KEY,
                ten_hang TEXT NOT NULL,
                so_luong INTEGER,
                don_gia INTEGER,
                gia_xuat INTEGER, -- fix
                img TEXT,
                loai TEXT
            );";

            ExecuteNonQuery(query);
        }

        public void CreateHoaDonTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS HoaDon (
                id_hoa_don TEXT PRIMARY KEY,
                ngay_tao_don TEXT,
                id_nv TEXT,
                tong_tien INTEGER,
                loai_hoa_don TEXT,
                id_ncc TEXT,
                id_ch TEXT,
                FOREIGN KEY (id_nv) REFERENCES NhanVien(id_nv),
                FOREIGN KEY (id_ncc) REFERENCES NhaCungCap(id_ncc),
                FOREIGN KEY (id_ch) REFERENCES CuaHang(id_ch)
            );";

            ExecuteNonQuery(query);
        }

        public void CreateCuaHangTable()
        {
            string query = @"
    CREATE TABLE IF NOT EXISTS CuaHang (
        id_ch TEXT PRIMARY KEY,
        ten_ch TEXT NOT NULL,
        sdt_ch TEXT,
        dia_chi_ch TEXT
    );";

            ExecuteNonQuery(query);
        }

        public void CreateChiTietHoaDonTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS ChiTietHoaDon (
                id_hoa_don TEXT,
                id_hang_hoa TEXT,
                so_luong INTEGER,
                don_gia INTEGER,
                gia_xuat INTEGER, -- fix
                PRIMARY KEY (id_hoa_don, id_hang_hoa),
                FOREIGN KEY (id_hoa_don) REFERENCES HoaDon(id_hoa_don),
                FOREIGN KEY (id_hang_hoa) REFERENCES HangHoa(id)
            );";

            ExecuteNonQuery(query);
        }

        public void CreateLogTable()
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS ActivityLog (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            timestamp TEXT NOT NULL,
            id_nv TEXT NOT NULL,
            activity_type TEXT NOT NULL,
            description TEXT,
            details TEXT,
            FOREIGN KEY (id_nv) REFERENCES NhanVien(id_nv)
             );";

            ExecuteNonQuery(query);
        }

        public void DeleteNhaCungCap(string idNcc)
        {
            string query = $"DELETE FROM NhaCungCap WHERE id_ncc = '{idNcc}'";
            ExecuteNonQuery(query);
        }

        public void DeleteCuaHang(string idCh)
        {
            string query = $"DELETE FROM CuaHang WHERE id_ch = '{idCh}'";
            ExecuteNonQuery(query);
        }


        public void InsertNhaCungCap(NhaCungCap ncc)
        {
            string query = $@"
            INSERT OR REPLACE INTO NhaCungCap (id_ncc, ten_ncc, sdt_ncc, dia_chi_ncc)
            VALUES ('{ncc.IdNcc}', '{ncc.TenNcc}', '{ncc.SdtNcc}', '{ncc.DiaChiNcc}');";

            ExecuteNonQuery(query);
        }

public void InsertNhanVien(NhanVien nv)
{
    string query = $@"
    INSERT OR REPLACE INTO NhanVien (id_nv, ten_nv, tuoi, gioi_tinh, dia_chi_nv, username, password, is_admin)
    VALUES ('{nv.IdNv}', '{nv.TenNv}', {nv.Tuoi}, {(nv.GioiTinh ? 1 : 0)}, '{nv.DiaChiNv}', '{nv.Username}', '{nv.Password}', {(nv.IsAdmin ? 1 : 0)});";

    ExecuteNonQuery(query);
}

        public void InsertCuaHang(CuaHang ch)
        {
            string query = $@"
            INSERT OR REPLACE INTO CuaHang (id_ch, ten_ch, sdt_ch, dia_chi_ch)
            VALUES ('{ch.IdCh}', '{ch.TenCh}', '{ch.SdtCh}', '{ch.DiaChiCh}');";

            ExecuteNonQuery(query);
        }

        public void InsertHangHoa(HangHoa hh)
        {
            string loai = "";
            if (hh is DienTu)
                loai = "DienTu";
            else if (hh is GiaDung)
                loai = "GiaDung";
            else if (hh is ThoiTrang)
                loai = "ThoiTrang";

            string query = $@"
            INSERT OR REPLACE INTO HangHoa (id, ten_hang, so_luong, don_gia, gia_xuat, img, loai)
            VALUES ('{hh.Id}', '{hh.TenHang}', {hh.SoLuong}, {hh.DonGia}, {hh.GiaXuat}, '{hh.Img}', '{loai}');";

            ExecuteNonQuery(query);
        }

        public void InsertHoaDon(HoaDon hoaDon)
        {
            string loaiHoaDon = "";
            string idNCC = "NULL";
            string idCH = "NULL";

            if (hoaDon is HoaDonNhap)
            {
                loaiHoaDon = "Nhap";
                idNCC = $"'{((HoaDonNhap)hoaDon).NhaCungCap.IdNcc}'";
            }
            else if (hoaDon is HoaDonXuat)
            {
                loaiHoaDon = "Xuat";
                idCH = $"'{((HoaDonXuat)hoaDon).CuaHang.IdCh}'";
            }

            string query = $@"
            INSERT OR REPLACE INTO HoaDon (id_hoa_don, ngay_tao_don, id_nv, tong_tien, loai_hoa_don, id_ncc, id_ch)
            VALUES ('{hoaDon.IdHoaDon}', '{hoaDon.NgayTaoDon.ToString("yyyy-MM-dd HH:mm:ss")}', '{hoaDon.NvLap.IdNv}', {hoaDon.TongTien}, '{loaiHoaDon}', {idNCC}, {idCH});";

            ExecuteNonQuery(query);

            // Lưu chi tiết hóa đơn
            foreach (HangHoa hh in hoaDon.Qlnx.ds_hang_hoa)
            {
                ulong Gia = 0;
                if (hoaDon.IdHoaDon.StartsWith("HDN"))
                {
                    Gia = hh.DonGia; // Hóa đơn nhập: dùng DonGia
                }
                else if (hoaDon.IdHoaDon.StartsWith("HDX"))
                {
                    Gia = hh.GiaXuat; // Hóa đơn xuất: dùng GiaXuat
                }

                string detailQuery = $@"
        INSERT OR REPLACE INTO ChiTietHoaDon (id_hoa_don, id_hang_hoa, so_luong, don_gia, gia_xuat)
        VALUES ('{hoaDon.IdHoaDon}', '{hh.Id}', {hh.SoLuong}, {hh.DonGia}, {Gia});";

                ExecuteNonQuery(detailQuery);
            }
        }

        //Phương thức luu log

        public void InsertLog(string idNv, string activityType, string description, string details = "")
        {
            try
            {
                // Kiểm tra xem nhân viên tồn tại không
                string checkQuery = $"SELECT COUNT(*) FROM NhanVien WHERE id_nv = '{idNv}'";
                int count = 0;

                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(checkQuery, connection))
                    {
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                if (count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"WARNING: Không tìm thấy nhân viên ID {idNv} trong database!");
                    return;
                }

                // Tiếp tục ghi log
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $@"
        INSERT INTO ActivityLog (timestamp, id_nv, activity_type, description, details)
        VALUES ('{timestamp}', '{idNv}', '{activityType}', '{description}', '{details}');";

                ExecuteNonQuery(query);
                System.Diagnostics.Debug.WriteLine("InsertLog thành công!");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi trong InsertLog: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw; // Ném lại ngoại lệ để caller xử lý
            }
        }



        public DataTable GetLogsByFilter(string idNv = null, string activityType = null,
    DateTime? fromDate = null, DateTime? toDate = null)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
        SELECT l.timestamp, n.ten_nv, l.activity_type, l.description, l.details 
        FROM ActivityLog l
        JOIN NhanVien n ON l.id_nv = n.id_nv
        WHERE 1=1");

            // Thêm các điều kiện lọc
            if (!string.IsNullOrEmpty(idNv) && idNv != "all")
            {
                queryBuilder.Append($" AND l.id_nv = '{idNv}'");
            }

            if (!string.IsNullOrEmpty(activityType) && activityType != "all")
            {
                queryBuilder.Append($" AND l.activity_type = '{activityType}'");
            }

            if (fromDate != null)
            {
                string fromDateStr = ((DateTime)fromDate).ToString("yyyy-MM-dd 00:00:00");
                queryBuilder.Append($" AND l.timestamp >= '{fromDateStr}'");
            }

            if (toDate != null)
            {
                string toDateStr = ((DateTime)toDate).ToString("yyyy-MM-dd 23:59:59");
                queryBuilder.Append($" AND l.timestamp <= '{toDateStr}'");
            }

            queryBuilder.Append(" ORDER BY l.timestamp DESC");

            return ExecuteQuery(queryBuilder.ToString());
        }

        public List<string> GetActivityTypes()
        {
            List<string> types = new List<string>();
            string query = "SELECT DISTINCT activity_type FROM ActivityLog ORDER BY activity_type";
       
            DataTable dataTable = ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                types.Add(row["activity_type"].ToString());
            }
       
            return types;
        }


        // Phương thức để chuyển đổi từ XML sang SQLite
        public void MigrateFromXmlToSQLite(KhoHang khoHang)
        {
            try
            {
                // Tạo tất cả bảng cần thiết
                CreateNhaCungCapTable();
                CreateNhanVienTable();
                CreateCuaHangTable(); // Đảm bảo gọi phương thức này
                CreateHangHoaTable();
                CreateHoaDonTable();
                CreateChiTietHoaDonTable();

                // Nhập dữ liệu từ các danh sách trong KhoHang
                foreach (var ch in khoHang.ds_cua_hang)
                {
                    InsertCuaHang(ch);
                }

                foreach (var ncc in khoHang.ds_ncc)
                {
                    InsertNhaCungCap(ncc);
                }

                foreach (var nv in khoHang.ds_nhan_vien)
                {
                    InsertNhanVien(nv);
                }

                foreach (var hh in khoHang.ds_hang_hoa)
                {
                    InsertHangHoa(hh);
                }

                foreach (var hdn in khoHang.ds_hoa_don_nhap)
                {
                    InsertHoaDon(hdn);
                }

                foreach (var hdx in khoHang.ds_hoa_don_xuat)
                {
                    InsertHoaDon(hdx);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi chuyển dữ liệu: {ex.Message}", ex);
            }
        }

        public bool TableExists(string tableName)
        {
            string query = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void CheckTablesBeforeMigration()
        {
            string[] requiredTables = { "CuaHang", "NhaCungCap", "NhanVien", "HangHoa", "HoaDon", "ChiTietHoaDon", "ActivityLog" };

            foreach (string tableName in requiredTables)
            {
                if (!TableExists(tableName))
                {
                    // Tạo bảng nếu chưa tồn tại
                    switch (tableName)
                    {
                        case "CuaHang":
                            CreateCuaHangTable();
                            break;
                        case "NhaCungCap":
                            CreateNhaCungCapTable();
                            break;
                        case "NhanVien":
                            CreateNhanVienTable();
                            break;
                        case "HangHoa":
                            CreateHangHoaTable();
                            break;
                        case "HoaDon":
                            CreateHoaDonTable();
                            break;
                        case "ChiTietHoaDon":
                            CreateChiTietHoaDonTable();
                            break;
                        case "ActivityLog":
                            CreateLogTable();
                            break;
                    }
                }
            }
        }




        // Phương thức để load dữ liệu từ SQLite vào KhoHang
        public void LoadDataFromSQLiteToKhoHang(KhoHang khoHang)
        {
            // Load NhaCungCap
            LoadNhaCungCap(khoHang);

            // Load NhanVien
            LoadNhanVien(khoHang);

            // Load CuaHang
            LoadCuaHang(khoHang);

            // Load HangHoa
            LoadHangHoa(khoHang);

            // Load HoaDon
            LoadHoaDon(khoHang);
        }

        private void LoadNhaCungCap(KhoHang khoHang)
        {
            khoHang.ds_ncc.Clear();
            DataTable dataTable = ExecuteQuery("SELECT * FROM NhaCungCap");

            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["id_ncc"].ToString();
                string ten = row["ten_ncc"].ToString();
                string sdt = row["sdt_ncc"].ToString();
                string diaChi = row["dia_chi_ncc"].ToString();

                NhaCungCap ncc = new NhaCungCap(id, ten, sdt, diaChi);
                khoHang.ds_ncc.Add(ncc);
            }
        }
        private void LoadNhanVien(KhoHang khoHang)
        {
            khoHang.ds_nhan_vien.Clear();

            // Kiểm tra xem cột is_admin có tồn tại không
            bool isAdminColumnExists = false;
            DataTable tableInfo = GetTableStructure("NhanVien");
            foreach (DataRow row in tableInfo.Rows)
            {
                if (row["name"].ToString().ToLower() == "is_admin")
                {
                    isAdminColumnExists = true;
                    break;
                }
            }

            // Nếu cột is_admin chưa tồn tại, thêm vào
            if (!isAdminColumnExists)
            {
                try
                {
                    ExecuteNonQuery("ALTER TABLE NhanVien ADD COLUMN is_admin INTEGER DEFAULT 0;");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm cột is_admin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DataTable dataTable = ExecuteQuery("SELECT * FROM NhanVien");

            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["id_nv"].ToString();
                string ten = row["ten_nv"].ToString();
                uint tuoi = Convert.ToUInt32(row["tuoi"]);
                bool gioiTinh = Convert.ToBoolean(row["gioi_tinh"]);
                string diaChi = row["dia_chi_nv"].ToString();
                string username = row["username"].ToString();
                string password = row["password"].ToString();

                // Đọc trường is_admin nếu có
                bool isAdmin = false;
                if (isAdminColumnExists && row["is_admin"] != DBNull.Value)
                {
                    isAdmin = Convert.ToBoolean(Convert.ToInt32(row["is_admin"]));
                }

                NhanVien nv = new NhanVien();
                nv.IdNv = id;
                nv.TenNv = ten;
                nv.Tuoi = tuoi;
                nv.GioiTinh = gioiTinh;
                nv.DiaChiNv = diaChi;
                nv.Username = username;
                nv.Password = password;
                nv.IsAdmin = isAdmin;

                khoHang.ds_nhan_vien.Add(nv);
            }
        }


        private void LoadCuaHang(KhoHang khoHang)
        {
            khoHang.ds_cua_hang.Clear();
            DataTable dataTable = ExecuteQuery("SELECT * FROM CuaHang");

            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["id_ch"].ToString();
                string ten = row["ten_ch"].ToString();
                string sdt = row["sdt_ch"].ToString();
                string diaChi = row["dia_chi_ch"].ToString();

                CuaHang ch = new CuaHang(id, ten, sdt, diaChi);
                khoHang.ds_cua_hang.Add(ch);
            }
        }

        private void LoadHangHoa(KhoHang khoHang)
        {
            khoHang.ds_hang_hoa.Clear();
            DataTable dataTable = ExecuteQuery("SELECT * FROM HangHoa");

            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["id"].ToString();
                string ten = row["ten_hang"].ToString();
                uint soLuong = Convert.ToUInt32(row["so_luong"]);
                ulong donGia = Convert.ToUInt64(row["don_gia"]);
                ulong giaXuat = Convert.ToUInt64(row["gia_xuat"]); //fix
                string img = row["img"].ToString();
                string loai = row["loai"].ToString();

                HangHoa hh = null;

                switch (loai)
                {
                    case "DienTu":
                        hh = new DienTu(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                    case "GiaDung":
                        hh = new GiaDung(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                    case "ThoiTrang":
                        hh = new ThoiTrang(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                }

                if (hh != null)
                {
                    khoHang.ds_hang_hoa.Add(hh);
                }
            }
        }

        private void LoadHoaDon(KhoHang khoHang)
        {
            LoadHoaDonNhap(khoHang);
            LoadHoaDonXuat(khoHang);
        }

        private void LoadHoaDonNhap(KhoHang khoHang)
        {
            khoHang.ds_hoa_don_nhap.Clear();
            string query = @"
                SELECT h.*, ncc.id_ncc, ncc.ten_ncc, ncc.sdt_ncc, ncc.dia_chi_ncc
                FROM HoaDon h
                JOIN NhaCungCap ncc ON h.id_ncc = ncc.id_ncc
                WHERE h.loai_hoa_don = 'Nhap'";

            DataTable dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                string idHD = row["id_hoa_don"].ToString();
                string idNV = row["id_nv"].ToString();
                ulong tongTien = Convert.ToUInt64(row["tong_tien"]);

                // Tìm nhân viên
                NhanVien nv = khoHang.ds_nhan_vien.Find(x => x.IdNv == idNV);
                if (nv == null) continue;

                // Tạo nhà cung cấp
                string idNCC = row["id_ncc"].ToString();
                string tenNCC = row["ten_ncc"].ToString();
                string sdtNCC = row["sdt_ncc"].ToString();
                string diaChiNCC = row["dia_chi_ncc"].ToString();
                NhaCungCap ncc = new NhaCungCap(idNCC, tenNCC, sdtNCC, diaChiNCC);

                // Lấy chi tiết hóa đơn
                QuanLyNhapXuat qlnx = LoadChiTietHoaDon(idHD);

                // Tạo hóa đơn nhập
                HoaDonNhap hdn = new HoaDonNhap(qlnx, idHD, nv, ncc, tongTien);
                DateTime ngayTaoDon = DateTime.Parse(row["ngay_tao_don"].ToString());
                hdn.NgayTaoDon = ngayTaoDon;
                khoHang.ds_hoa_don_nhap.Add(hdn);
            }
        }

        private void LoadHoaDonXuat(KhoHang khoHang)
        {
            khoHang.ds_hoa_don_xuat.Clear();
            string query = @"
                SELECT h.*, ch.id_ch, ch.ten_ch, ch.sdt_ch, ch.dia_chi_ch
                FROM HoaDon h
                JOIN CuaHang ch ON h.id_ch = ch.id_ch
                WHERE h.loai_hoa_don = 'Xuat'";

            DataTable dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                string idHD = row["id_hoa_don"].ToString();
                string idNV = row["id_nv"].ToString();
                ulong tongTien = Convert.ToUInt64(row["tong_tien"]);

                // Tìm nhân viên
                NhanVien nv = khoHang.ds_nhan_vien.Find(x => x.IdNv == idNV);
                if (nv == null) continue;

                // Tạo cửa hàng
                string idCH = row["id_ch"].ToString();
                string tenCH = row["ten_ch"].ToString();
                string sdtCH = row["sdt_ch"].ToString();
                string diaChiCH = row["dia_chi_ch"].ToString();
                CuaHang ch = new CuaHang(idCH, tenCH, sdtCH, diaChiCH);

                // Lấy chi tiết hóa đơn
                QuanLyNhapXuat qlnx = LoadChiTietHoaDon(idHD);

                // Tạo hóa đơn xuất
                HoaDonXuat hdx = new HoaDonXuat(qlnx, idHD, nv, ch, tongTien);
                DateTime ngayTaoDon = DateTime.Parse(row["ngay_tao_don"].ToString());
                hdx.NgayTaoDon = ngayTaoDon;
                khoHang.ds_hoa_don_xuat.Add(hdx);
            }
        }

        private QuanLyNhapXuat LoadChiTietHoaDon(string idHoaDon)
        {
            QuanLyNhapXuat qlnx = new QuanLyNhapXuat();

            string query = $@"
                SELECT ct.*, h.id, h.ten_hang, h.so_luong, h.don_gia, h.gia_xuat, h.img, h.loai
                FROM ChiTietHoaDon ct
                JOIN HangHoa h ON ct.id_hang_hoa = h.id
                WHERE ct.id_hoa_don = '{idHoaDon}'";

            DataTable dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["id"].ToString();
                string ten = row["ten_hang"].ToString();
                uint soLuong = Convert.ToUInt32(row["so_luong"]);
                ulong donGia = Convert.ToUInt64(row["don_gia"]);
                ulong giaXuat = Convert.ToUInt64(row["gia_xuat"]); //fix
                string img = row["img"].ToString();
                string loai = row["loai"].ToString();

                HangHoa hh = null;

                switch (loai)
                {
                    case "DienTu":
                        hh = new DienTu(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                    case "GiaDung":
                        hh = new GiaDung(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                    case "ThoiTrang":
                        hh = new ThoiTrang(id, ten, soLuong, donGia, giaXuat, img);
                        break;
                }

                if (hh != null)
                {
                    qlnx.them_hh(hh);
                }
            }

            return qlnx;
        }

        // Phương thức kiểm tra kết nối đến SQLite
        public bool TestConnection()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                return false;
            }
        }

        // Phương thức trả về danh sách các bảng trong cơ sở dữ liệu
        public List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();
            string query = @"
                SELECT name FROM sqlite_master 
                WHERE type='table' AND name NOT LIKE 'sqlite_%'
                ORDER BY name;";

            DataTable dataTable = ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                tableNames.Add(row["name"].ToString());
            }

            return tableNames;
        }

        // Phương thức trả về thông tin cấu trúc của một bảng
        public DataTable GetTableStructure(string tableName)
        {
            string query = $"PRAGMA table_info({tableName});";
            return ExecuteQuery(query);
        }

        // Phương thức đếm số lượng bản ghi trong một bảng
        public int CountRecords(string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName};";
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
