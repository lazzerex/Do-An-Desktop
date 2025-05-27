using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class BaoCaoService
    {
        private readonly KhoHang kho = KhoHang.Instance;
        private readonly SQLiteHelper dbHelper;

        public BaoCaoService()
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CuaHang.db");
            dbHelper = new SQLiteHelper(dbPath);
        }

        public bool KiemTraQuyenAdmin()
        {
            if (kho.CurrentNhanVien != null && kho.CurrentNhanVien.IsAdmin)
            {
                return true;
            }

            MessageBox.Show("Bạn không có quyền xem báo cáo này!",
                "Quyền truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Báo cáo nhân viên
        public class BaoCaoNhanVien
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public int SoHDNhap { get; set; }
            public int SoHDXuat { get; set; }
            public ulong DoanhThuXuat { get; set; }
            public ulong TienNhapHang { get; set; }
        }

        public (List<BaoCaoNhanVien> Data, int TongHDNhap, int TongHDXuat, ulong TongDoanhThuXuat, ulong TongTienNhapHang)
            TaiDuLieuBaoCaoNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                var result = new List<BaoCaoNhanVien>();
                tuNgay = tuNgay.Date;
                denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

                string query = @"
                    SELECT 
                        nv.id_nv AS MaNV, 
                        nv.ten_nv AS TenNV,
                        (SELECT COUNT(*) FROM HoaDon hd1 WHERE hd1.id_nv = nv.id_nv AND hd1.loai_hoa_don = 'Nhap' 
                         AND hd1.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS SoHDNhap,
                        (SELECT COUNT(*) FROM HoaDon hd2 WHERE hd2.id_nv = nv.id_nv AND hd2.loai_hoa_don = 'Xuat' 
                         AND hd2.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS SoHDXuat,
                        (SELECT IFNULL(SUM(hd3.tong_tien), 0) FROM HoaDon hd3 WHERE hd3.id_nv = nv.id_nv AND hd3.loai_hoa_don = 'Xuat' 
                         AND hd3.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS DoanhThuXuat,
                        (SELECT IFNULL(SUM(hd4.tong_tien), 0) FROM HoaDon hd4 WHERE hd4.id_nv = nv.id_nv AND hd4.loai_hoa_don = 'Nhap' 
                         AND hd4.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS TienNhapHang
                    FROM 
                        NhanVien nv
                    ORDER BY 
                        DoanhThuXuat DESC";

                int tongHDNhap = 0;
                int tongHDXuat = 0;
                ulong tongDoanhThuXuat = 0;
                ulong tongTienNhapHang = 0;

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbHelper.DatabasePath}"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new BaoCaoNhanVien
                                {
                                    MaNV = reader["MaNV"].ToString(),
                                    TenNV = reader["TenNV"].ToString(),
                                    SoHDNhap = Convert.ToInt32(reader["SoHDNhap"]),
                                    SoHDXuat = Convert.ToInt32(reader["SoHDXuat"]),
                                    DoanhThuXuat = Convert.ToUInt64(reader["DoanhThuXuat"]),
                                    TienNhapHang = Convert.ToUInt64(reader["TienNhapHang"])
                                };

                                tongHDNhap += item.SoHDNhap;
                                tongHDXuat += item.SoHDXuat;
                                tongDoanhThuXuat += item.DoanhThuXuat;
                                tongTienNhapHang += item.TienNhapHang;

                                result.Add(item);
                            }
                        }
                    }
                }

                return (result, tongHDNhap, tongHDXuat, tongDoanhThuXuat, tongTienNhapHang);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo nhân viên: " + ex.Message);
            }
        }

        // Báo cáo nhà cung cấp
        public class BaoCaoNhaCungCap
        {
            public string IdNcc { get; set; }
            public string TenNcc { get; set; }
            public int SoLuongNhap { get; set; }
            public ulong TongGiaTri { get; set; }
            public double TyLeNhap { get; set; }
        }

        public (List<BaoCaoNhaCungCap> Data, int TongSoLuongNhap, ulong TongGiaTriNhap)
            TaiDuLieuBaoCaoNhaCungCap(DateTime tuNgay, DateTime denNgay, string idNcc = null)
        {
            try
            {
                var result = new List<BaoCaoNhaCungCap>();
                tuNgay = tuNgay.Date;
                denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

                string nccDieuKien = idNcc != null ? $" AND hd.id_ncc = '{idNcc}' " : "";
                string query = @"
                    SELECT 
                        ncc.id_ncc AS IdNcc,
                        ncc.ten_ncc AS TenNcc,
                        SUM(cthd.so_luong) AS SoLuongNhap,
                        SUM(cthd.so_luong * cthd.don_gia) AS TongGiaTri
                    FROM 
                        NhaCungCap ncc
                    JOIN 
                        HoaDon hd ON ncc.id_ncc = hd.id_ncc
                    JOIN 
                        ChiTietHoaDon cthd ON hd.id_hoa_don = cthd.id_hoa_don
                    WHERE 
                        hd.loai_hoa_don = 'Nhap'
                        AND hd.ngay_tao_don BETWEEN @TuNgay AND @DenNgay
                        " + nccDieuKien + @"
                    GROUP BY 
                        ncc.id_ncc, ncc.ten_ncc
                    ORDER BY 
                        TongGiaTri DESC";

                int tongSoLuongNhap = 0;
                ulong tongGiaTriNhap = 0;

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbHelper.DatabasePath}"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            var tempResults = new List<(string IdNcc, string TenNcc, int SoLuongNhap, ulong TongGiaTri)>();

                            while (reader.Read())
                            {
                                var item = (
                                    IdNcc: reader["IdNcc"].ToString(),
                                    TenNcc: reader["TenNcc"].ToString(),
                                    SoLuongNhap: Convert.ToInt32(reader["SoLuongNhap"]),
                                    TongGiaTri: Convert.ToUInt64(reader["TongGiaTri"])
                                );
                                tempResults.Add(item);
                                tongSoLuongNhap += item.SoLuongNhap;
                                tongGiaTriNhap += item.TongGiaTri;
                            }

                            foreach (var item in tempResults)
                            {
                                double tyLe = tongGiaTriNhap > 0 ? (double)item.TongGiaTri / tongGiaTriNhap * 100 : 0;
                                result.Add(new BaoCaoNhaCungCap
                                {
                                    IdNcc = item.IdNcc,
                                    TenNcc = item.TenNcc,
                                    SoLuongNhap = item.SoLuongNhap,
                                    TongGiaTri = item.TongGiaTri,
                                    TyLeNhap = tyLe
                                });
                            }
                        }
                    }
                }

                return (result, tongSoLuongNhap, tongGiaTriNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo nhà cung cấp: " + ex.Message);
            }
        }

        // Báo cáo cửa hàng
        public class BaoCaoHangHoa
        {
            public string LoaiHang { get; set; }
            public int SoLuongBan { get; set; }
            public ulong DoanhThu { get; set; }
            public double TyLeDoanhThu { get; set; }
        }

        public (List<BaoCaoHangHoa> Data, int TongSoLuongBan, ulong TongDoanhThu)
            TaiDuLieuBaoCaoHangHoa(DateTime tuNgay, DateTime denNgay, string loaiHang = null)
        {
            try
            {
                var result = new List<BaoCaoHangHoa>();
                tuNgay = tuNgay.Date;
                denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

                string loaiHangDieuKien = loaiHang != null ? $" AND hh.loai = '{loaiHang}' " : "";
                string query = @"
                    SELECT 
                        hh.loai AS LoaiHang,
                        SUM(cthd.so_luong) AS SoLuongBan,
                        SUM(cthd.so_luong * cthd.gia_xuat) AS DoanhThu
                    FROM 
                        HangHoa hh
                    JOIN 
                        ChiTietHoaDon cthd ON hh.id = cthd.id_hang_hoa
                    JOIN 
                        HoaDon hd ON cthd.id_hoa_don = hd.id_hoa_don
                    WHERE 
                        hd.loai_hoa_don = 'Xuat'
                        AND hd.ngay_tao_don BETWEEN @TuNgay AND @DenNgay
                        " + loaiHangDieuKien + @"
                    GROUP BY 
                        hh.loai
                    ORDER BY 
                        DoanhThu DESC";

                int tongSoLuongBan = 0;
                ulong tongDoanhThu = 0;

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbHelper.DatabasePath}"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            var tempResults = new List<(string LoaiHang, int SoLuongBan, ulong DoanhThu)>();

                            while (reader.Read())
                            {
                                var item = (
                                    LoaiHang: reader["LoaiHang"].ToString(),
                                    SoLuongBan: Convert.ToInt32(reader["SoLuongBan"]),
                                    DoanhThu: Convert.ToUInt64(reader["DoanhThu"])
                                );
                                tempResults.Add(item);
                                tongSoLuongBan += item.SoLuongBan;
                                tongDoanhThu += item.DoanhThu;
                            }

                            foreach (var item in tempResults)
                            {
                                double tyLe = tongDoanhThu > 0 ? (double)item.DoanhThu / tongDoanhThu * 100 : 0;
                                result.Add(new BaoCaoHangHoa
                                {
                                    LoaiHang = item.LoaiHang,
                                    SoLuongBan = item.SoLuongBan,
                                    DoanhThu = item.DoanhThu,
                                    TyLeDoanhThu = tyLe
                                });
                            }
                        }
                    }
                }

                return (result, tongSoLuongBan, tongDoanhThu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo hàng hóa: " + ex.Message);
            }
        }
    }
}