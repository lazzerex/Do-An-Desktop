using System;
using System.IO;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class FormDangNhap : System.Windows.Forms.Form
    {
        private KhoHang kho = KhoHang.Instance;

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            kho.CurrentNhanVien = nhanVien;
        }

        public NhanVien current_nv;

        public FormDangNhap()
        {
            InitializeComponent();

            kho.LoadData();
        }

        #region Event
        private void DangNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TenDangNhap_tb.Text;
                string password = MatKhau__tb.Text;

                current_nv = kho.dang_nhap(username, password);

                if (current_nv != null)
                {
                    // Khởi tạo Logger và ghi log đăng nhập
                    string dbPath = System.IO.Path.Combine(Application.StartupPath, "CuaHang.db");
                    try
                    {
                        Logger.Initialize(dbPath);
                        Logger.LogLogin(current_nv);
                    }
                    catch (Exception logEx)
                    {
                        Console.WriteLine("Lỗi khi ghi log: " + logEx.Message);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnCheckSQLite_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
                FormSQLiteInfo formInfo = new FormSQLiteInfo(dbPath);
                formInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChuyenDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đường dẫn đến file database
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");

                // Khởi tạo kết nối SQLite
                SQLiteHelper dbHelper = new SQLiteHelper(dbPath);

                // Kiểm tra và tạo các bảng trước khi chuyển dữ liệu
                dbHelper.CheckTablesBeforeMigration();

                // Khởi tạo kết nối SQLite cho KhoHang
                kho.InitSQLite(dbPath);

                // Đọc dữ liệu từ file .dat
                kho.LoadData(false); // false = đọc từ file .dat

                // Chuyển dữ liệu sang SQLite
                kho.SaveToDatabase();

                MessageBox.Show("Chuyển dữ liệu từ file .dat sang SQLite thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTaoBang_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
                SQLiteHelper dbHelper = new SQLiteHelper(dbPath);

                // Tạo các bảng
                dbHelper.CreateCuaHangTable();
                dbHelper.CreateNhaCungCapTable();
                dbHelper.CreateNhanVienTable();
                dbHelper.CreateHangHoaTable();
                dbHelper.CreateHoaDonTable();
                dbHelper.CreateChiTietHoaDonTable();

                MessageBox.Show("Đã tạo các bảng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void DangNhap_bt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string username = TenDangNhap_tb.Text;
        //        string password = MatKhau__tb.Text;

        //        current_nv = kho.dang_nhap(username, password);

        //        if (current_nv != null)
        //        {
        //            // Ghi log đăng nhập
        //            Logger.LogLogin(current_nv);

        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}
