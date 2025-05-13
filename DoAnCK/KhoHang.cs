using DoAnCK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DoAnCK
{
    public class KhoHang
    {
        public List<HangHoa> ds_hang_hoa = new List<HangHoa>();
        public List<NhanVien> ds_nhan_vien = new List<NhanVien>();
        public List<CuaHang> ds_cua_hang = new List<CuaHang>();
        public List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        public List<HoaDonNhap> ds_hoa_don_nhap = new List<HoaDonNhap>();
        public List<HoaDonXuat> ds_hoa_don_xuat = new List<HoaDonXuat>();

        private SQLiteHelper dbHelper;
        private bool useDatabase = false;

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
            // Lưu vào XML như hiện tại
            LuuDanhSach("Resources/cua_hang.dat", ds_cua_hang);

            // Lưu vào SQLite nếu đã kết nối
            if (useDatabase && dbHelper != null)
            {
                foreach (CuaHang ch in ds_cua_hang)
                {
                    dbHelper.InsertCuaHang(ch);
                }
            }
        }

        public void ThemHoaDonNhap(HoaDonNhap hoaDon)
        {
            ds_hoa_don_nhap.Add(hoaDon);
            LuuDanhSachHDN(); // Sẽ lưu vào cả XML và SQLite
        }

        public void ThemHoaDonXuat(HoaDonXuat hoaDon)
        {
            ds_hoa_don_xuat.Add(hoaDon);
            LuuDanhSachHDX();
        }

        public void them_hh(HangHoa hh)
        {
            ds_hang_hoa.Add(hh);
            LuuDanhSachHH();
        }

        public void xoa_hh(HangHoa hh)
        {
            ds_hang_hoa.Remove(hh);
            LuuDanhSachHH();
        }

        public void LoadData(bool fromDatabase = false)
        {
            if (fromDatabase && dbHelper != null)
            {
                // Đọc dữ liệu từ SQLite
                dbHelper.LoadDataFromSQLiteToKhoHang(this);
            }
            else
            {
                // Đọc dữ liệu từ file .dat
                try
                {
                    ds_hang_hoa = LoadDanhSach<HangHoa>("Resources/hang_hoa.dat");
                    ds_ncc = LoadDanhSach<NhaCungCap>("Resources/nha_cung_cap.dat");
                    ds_cua_hang = LoadDanhSach<CuaHang>("Resources/cua_hang.dat");
                    ds_hoa_don_nhap = LoadDanhSach<HoaDonNhap>("Resources/hoa_don_nhap.dat");
                    ds_hoa_don_xuat = LoadDanhSach<HoaDonXuat>("Resources/hoa_don_xuat.dat");
                    ds_nhan_vien = LoadDanhSach<NhanVien>("Resources/nhan_vien.dat");
                }
                catch (Exception ex)
                {
                    // Nếu không đọc được từ file .dat, thử đọc từ SQLite
                    if (dbHelper != null)
                    {
                        dbHelper.LoadDataFromSQLiteToKhoHang(this);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        public void SaveToDatabase()
        {
            if (dbHelper != null)
            {
                dbHelper.MigrateFromXmlToSQLite(this);
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
            // Lưu vào XML
            LuuDanhSach("Resources/nhan_vien.dat", ds_nhan_vien);

            // Lưu vào SQLite nếu đã kết nối
            if (useDatabase && dbHelper != null)
            {
                foreach (NhanVien nv in ds_nhan_vien)
                {
                    dbHelper.InsertNhanVien(nv);
                }
            }
        }
        public void LuuDanhSachNCC()
        {
            LuuDanhSach("Resources/nha_cung_cap.dat", ds_ncc);

            if (useDatabase && dbHelper != null)
            {
                foreach (var ncc in ds_ncc)
                {
                    dbHelper.InsertNhaCungCap(ncc);
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

        private void LuuDanhSachHH()
        {
            // Lưu vào XML như hiện tại
            LuuDanhSach("Resources/hang_hoa.dat", ds_hang_hoa);

            // Lưu vào SQLite nếu đã kết nối
            if (useDatabase && dbHelper != null)
            {
                foreach (HangHoa hh in ds_hang_hoa)
                {
                    dbHelper.InsertHangHoa(hh);
                }
            }
        }
        private void LuuDanhSachHDX()
        {
            // Lưu vào XML như hiện tại
            LuuDanhSach("Resources/hoa_don_xuat.dat", ds_hoa_don_xuat);

            // Lưu vào SQLite nếu đã kết nối
            if (useDatabase && dbHelper != null)
            {
                foreach (HoaDonXuat hdx in ds_hoa_don_xuat)
                {
                    dbHelper.InsertHoaDon(hdx);
                }
            }
        }
        private void LuuDanhSachHDN()
        {
            // Lưu vào XML như hiện tại
            LuuDanhSach("Resources/hoa_don_nhap.dat", ds_hoa_don_nhap);

            // Lưu vào SQLite nếu đã kết nối
            if (useDatabase && dbHelper != null)
            {
                foreach (HoaDonNhap hdn in ds_hoa_don_nhap)
                {
                    dbHelper.InsertHoaDon(hdn);
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
    }
}