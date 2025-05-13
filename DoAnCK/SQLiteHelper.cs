using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;

namespace DoAnCK
{
    public class SQLiteHelper
    {
        private readonly string _connectionString;
        private readonly string _databasePath;

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
                password TEXT
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
                PRIMARY KEY (id_hoa_don, id_hang_hoa),
                FOREIGN KEY (id_hoa_don) REFERENCES HoaDon(id_hoa_don),
                FOREIGN KEY (id_hang_hoa) REFERENCES HangHoa(id)
            );";

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
            INSERT OR REPLACE INTO NhanVien (id_nv, ten_nv, tuoi, gioi_tinh, dia_chi_nv, username, password)
            VALUES ('{nv.IdNv}', '{nv.TenNv}', {nv.Tuoi}, {(nv.GioiTinh ? 1 : 0)}, '{nv.DiaChiNv}', '{nv.Username}', '{nv.Password}');";

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
            INSERT OR REPLACE INTO HangHoa (id, ten_hang, so_luong, don_gia, img, loai)
            VALUES ('{hh.Id}', '{hh.TenHang}', {hh.SoLuong}, {hh.DonGia}, '{hh.Img}', '{loai}');";

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
                string detailQuery = $@"
                INSERT OR REPLACE INTO ChiTietHoaDon (id_hoa_don, id_hang_hoa, so_luong, don_gia)
                VALUES ('{hoaDon.IdHoaDon}', '{hh.Id}', {hh.SoLuong}, {hh.DonGia});";

                ExecuteNonQuery(detailQuery);
            }
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
            string[] requiredTables = { "CuaHang", "NhaCungCap", "NhanVien", "HangHoa", "HoaDon", "ChiTietHoaDon" };

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

                NhanVien nv = new NhanVien(id, ten, tuoi, gioiTinh, diaChi, username, password);
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
                string img = row["img"].ToString();
                string loai = row["loai"].ToString();

                HangHoa hh = null;

                switch (loai)
                {
                    case "DienTu":
                        hh = new DienTu(id, ten, soLuong, donGia, img);
                        break;
                    case "GiaDung":
                        hh = new GiaDung(id, ten, soLuong, donGia, img);
                        break;
                    case "ThoiTrang":
                        hh = new ThoiTrang(id, ten, soLuong, donGia, img);
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
                khoHang.ds_hoa_don_xuat.Add(hdx);
            }
        }

        private QuanLyNhapXuat LoadChiTietHoaDon(string idHoaDon)
        {
            QuanLyNhapXuat qlnx = new QuanLyNhapXuat();

            string query = $@"
                SELECT ct.*, h.id, h.ten_hang, h.so_luong, h.don_gia, h.img, h.loai
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
                string img = row["img"].ToString();
                string loai = row["loai"].ToString();

                HangHoa hh = null;

                switch (loai)
                {
                    case "DienTu":
                        hh = new DienTu(id, ten, soLuong, donGia, img);
                        break;
                    case "GiaDung":
                        hh = new GiaDung(id, ten, soLuong, donGia, img);
                        break;
                    case "ThoiTrang":
                        hh = new ThoiTrang(id, ten, soLuong, donGia, img);
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
