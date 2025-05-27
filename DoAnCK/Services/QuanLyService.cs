using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class QuanLyService
    {
        private readonly KhoHang kho = KhoHang.Instance;
        private readonly SQLiteHelper dbHelper;

        public QuanLyService()
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CuaHang.db");
            dbHelper = new SQLiteHelper(dbPath);
            Logger.Initialize(dbPath); // Khởi tạo Logger
        }

        // Lớp dữ liệu cho nhân viên trong FormQuanLyAdmin
        public class NhanVienAdminView
        {
            public string IdNv { get; set; }
            public string TenNv { get; set; }
            public string Username { get; set; }
            public string Quyen { get; set; }
        }

        // Lấy danh sách nhân viên cho FormQuanLyAdmin (loại trừ nhân viên hiện tại)
        public List<NhanVienAdminView> LayDanhSachNhanVien(string currentNhanVienId)
        {
            try
            {
                var result = new List<NhanVienAdminView>();
                foreach (NhanVien nv in kho.ds_nhan_vien)
                {
                    if (nv.IdNv != currentNhanVienId)
                    {
                        result.Add(new NhanVienAdminView
                        {
                            IdNv = nv.IdNv,
                            TenNv = nv.TenNv,
                            Username = nv.Username,
                            Quyen = nv.IsAdmin ? "Admin" : "Nhân viên"
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        // Cấp hoặc hủy quyền admin
        public bool CapNhatQuyen(string idNv, NhanVien currentNhanVien)
        {
            try
            {
                NhanVien nv = kho.ds_nhan_vien.Find(x => x.IdNv == idNv);
                if (nv == null)
                {
                    return false;
                }

                nv.IsAdmin = !nv.IsAdmin;
                kho.LuuDanhSachNV();
                Logger.LogCapNhatQuyen(currentNhanVien, nv, nv.IsAdmin);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogGeneric(currentNhanVien, "Lỗi cấp quyền", "Lỗi khi cập nhật quyền nhân viên", ex.Message);
                throw new Exception("Lỗi khi cập nhật quyền: " + ex.Message);
            }
        }

        // Xóa nhân viên
        public bool XoaNhanVien(string idNv, NhanVien currentNhanVien)
        {
            try
            {
                NhanVien nv = kho.ds_nhan_vien.Find(x => x.IdNv == idNv);
                if (nv == null)
                {
                    return false;
                }

                kho.ds_nhan_vien.Remove(nv);
                kho.LuuDanhSachNV();
                Logger.LogXoaNhanVien(currentNhanVien, nv);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogGeneric(currentNhanVien, "Lỗi xóa nhân viên", "Lỗi khi xóa nhân viên", ex.Message);
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        // Lớp dữ liệu cho nhân viên trong FormThongTinNhanVien
        public class NhanVienThongTinView
        {
            public string IdNv { get; set; }
            public string TenNv { get; set; }
            public uint Tuoi { get; set; }
            public string GioiTinh { get; set; }
            public string DiaChiNv { get; set; }
            public string Username { get; set; }
            public string Quyen { get; set; }
        }

        // Lấy danh sách nhân viên cho FormThongTinNhanVien
        public List<NhanVienThongTinView> LayDanhSachThongTinNhanVien()
        {
            try
            {
                var result = new List<NhanVienThongTinView>();
                foreach (NhanVien nv in kho.ds_nhan_vien)
                {
                    result.Add(new NhanVienThongTinView
                    {
                        IdNv = nv.IdNv,
                        TenNv = nv.TenNv,
                        Tuoi = nv.Tuoi,
                        GioiTinh = nv.GioiTinh ? "Nam" : "Nữ",
                        DiaChiNv = nv.DiaChiNv,
                        Username = nv.Username,
                        Quyen = nv.IsAdmin ? "Admin" : "Nhân viên"
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải thông tin nhân viên: " + ex.Message);
            }
        }

        // Lấy danh sách loại hoạt động log
        public List<string> LayLoaiHoatDong()
        {
            try
            {
                return dbHelper.GetActivityTypes();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải loại hoạt động log: " + ex.Message);
            }
        }

        // Lấy dữ liệu log theo bộ lọc
        public DataTable LayDanhSachLog(string nhanVienId, string activityType, DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return dbHelper.GetLogsByFilter(
                    nhanVienId == "all" ? null : nhanVienId,
                    activityType == "all" ? null : activityType,
                    tuNgay,
                    denNgay
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu log: " + ex.Message);
            }
        }
    }
}