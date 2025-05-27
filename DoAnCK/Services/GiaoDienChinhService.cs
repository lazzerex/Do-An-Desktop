using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class GiaoDienChinhService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormGiaoDienChinh view;
        private NhanVien currentNhanVien;

        public GiaoDienChinhService(FormGiaoDienChinh view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            kho.InitSQLite(dbPath);
            kho.TaoTaiKhoanAdmin();
            Logger.Initialize(dbPath);

            view.SetDate(DateTime.Now.ToString("dd/MM/yyyy"));
            ShowLoginForm();
        }

        public void ShowLoginForm()
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            if (formDangNhap.ShowDialog() != DialogResult.OK)
            {
                view.CloseForm();
                return;
            }

            currentNhanVien = formDangNhap.current_nv;
            kho.CurrentNhanVien = currentNhanVien;

            view.SetNhanVien(currentNhanVien.TenNv);
            view.SetAdminVisibility(currentNhanVien.IsAdmin);
            OpenChildForm(new FormTrangChu());
        }

        public void OpenChildForm(Form childForm)
        {
            view.OpenChildForm(childForm);
        }

        public void LoadData()
        {
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            kho.InitSQLite(dbPath);
            kho.LoadData(true);
            view.ShowMessage("Đã tải dữ liệu từ SQLite thành công!");
        }

        public void CreateTables()
        {
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            SQLiteHelper dbHelper = new SQLiteHelper(dbPath);
            dbHelper.CreateNhaCungCapTable();
            dbHelper.CreateNhanVienTable();
            dbHelper.CreateHangHoaTable();
            dbHelper.CreateHoaDonTable();
            dbHelper.CreateChiTietHoaDonTable();
            dbHelper.CreateCuaHangTable();
            view.ShowMessage("Đã tạo/cập nhật các bảng thành công!");
        }

        public void ShowSQLiteInfo()
        {
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            FormSQLiteInfo formInfo = new FormSQLiteInfo(dbPath);
            formInfo.ShowDialog();
        }

        public void ShowLog()
        {
            if (currentNhanVien != null && currentNhanVien.IsAdmin)
            {
                FormXemLog formXemLog = new FormXemLog();
                formXemLog.ShowDialog();
            }
            else
            {
                view.ShowError("Bạn không có quyền truy cập tính năng này!");
            }
        }

        public void Logout()
        {
            if (currentNhanVien != null)
            {
                Logger.LogLogout(currentNhanVien);
            }
            kho.SaveToDatabase();
        }
    }
}