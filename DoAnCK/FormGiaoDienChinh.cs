using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormGiaoDienChinh : System.Windows.Forms.Form
    {
        public FormGiaoDienChinh()
        {
            InitializeComponent();
            Ngay_lb.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");

            // Khởi tạo SQLite nhưng không tạo bảng tự động
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            KhoHang kho = new KhoHang();
            kho.InitSQLite(dbPath);

            // Tạo tài khoản admin nếu chưa có
            kho.TaoTaiKhoanAdmin();

            OpenChildForm(new FormTrangChu());
            ShowLoginForm();
            nhapxuat.Visible = false;
        }


        private System.Windows.Forms.Button btnAdmin;

        private NhanVien currentNhanVien;
        private void ShowLoginForm()
        {
            try
            {
                FormDangNhap formDangNhap = new FormDangNhap();
                if (formDangNhap.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    // Đảm bảo đã có biến current_nv từ formDangNhap
                    currentNhanVien = formDangNhap.current_nv;

                    NhanVien_lb.Text = "Nhân viên: " + currentNhanVien.TenNv;
                    Ngay_lb.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                    OpenChildForm(new FormTrangChu());

                    // Cập nhật CurrentNhanVien trong KhoHang
                    KhoHang kho = new KhoHang();
                    kho.CurrentNhanVien = currentNhanVien;

                    // Hiển thị nút Admin nếu người dùng là admin
                    if (btnAdmin != null)
                        btnAdmin.Visible = currentNhanVien.IsAdmin;

                    // Ghi log đăng nhập
                    try
                    {
                        Logger.LogLogin(currentNhanVien);
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi một cách im lặng để không ảnh hưởng đến trải nghiệm người dùng
                        Console.WriteLine("Lỗi ghi log đăng nhập: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormQuanLyAdmin(currentNhanVien));
                // Bỏ check tất cả các nút menu khác
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Windows.Forms.Form currentFormChild;
        private void OpenChildForm(System.Windows.Forms.Form childForm)
        {
            try
            {
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }
                currentFormChild = childForm;
                childForm.TopLevel = false;
                childForm.Dock = DockStyle.Fill;
                panelBody.Controls.Add(childForm);
                panelBody.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool hoadonExpand = false;
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

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        #region Event

        private async void HoaDon_bt_Click(object sender, EventArgs e)
        {
            try
            {
                nhapxuat.Visible = true;
                int startPosition = HoaDon_bt.Left - nhapxuat.Width; // Đặt ở bên trái
                nhapxuat.Left = startPosition;

                // Hiệu ứng trượt từ trái sang phải
                for (int i = 0; i <= nhapxuat.Width; i += 10)
                {
                    nhapxuat.Left = startPosition + i;
                    await Task.Delay(10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void HoaDon_bt_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(3000); // Đợi xem chuột có quay lại không
                int startPosition = nhapxuat.Left;
                for (int i = nhapxuat.Width; i >= 0; i -= 10)
                {
                    nhapxuat.Left = startPosition - (nhapxuat.Width - i);
                    await Task.Delay(10);
                }
                nhapxuat.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrangChu_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormTrangChu());
                TrangChu_bt.Checked = true;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhapHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormNhapXuat(currentNhanVien, true));
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = true;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuatHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormNhapXuat(currentNhanVien, false));
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = true;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormCuaHang());
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = true;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhaCungCap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormNhaCungCap());
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = true;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HoaDonNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormHoaDon(true));
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = true;
                HoaDonXuat_bt.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HoaDonXuat_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormHoaDon(false));
                TrangChu_bt.Checked = false;
                NhapHang_bt.Checked = false;
                XuatHang_bt.Checked = false;
                CuaHang_bt.Checked = false;
                NhaCungCap_bt.Checked = false;
                HoaDonNhap_bt.Checked = false;
                HoaDonXuat_bt.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện Load Data
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
                KhoHang kho = new KhoHang();
                kho.InitSQLite(dbPath);
                kho.LoadData(true); // Tải dữ liệu từ SQLite
                MessageBox.Show("Đã tải dữ liệu từ SQLite thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện Create Tables - chuyển code từ constructor sang đây
        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
                SQLiteHelper dbHelper = new SQLiteHelper(dbPath);

                // Tạo các bảng nếu chưa tồn tại
                dbHelper.CreateNhaCungCapTable();
                dbHelper.CreateNhanVienTable();
                dbHelper.CreateHangHoaTable();
                dbHelper.CreateHoaDonTable();
                dbHelper.CreateChiTietHoaDonTable();
                dbHelper.CreateCuaHangTable();

                MessageBox.Show("Đã tạo/cập nhật các bảng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormGiaoDienChinh_Load(object sender, EventArgs e)
        {
            try
            {
                // Thay vì sử dụng TenNV_lbl, ChucVu_lbl không tồn tại, hãy sử dụng NhanVien_lb đã có
                if (currentNhanVien != null)
                {
                    NhanVien_lb.Text = "Nhân viên: " + currentNhanVien.TenNv;
                    // Ngay_lb hiện tại đã có trong form, không cần thay đổi

                    // Khởi tạo Logger
                    string dbPath = System.IO.Path.Combine(Application.StartupPath, "CuaHang.db");
                    Logger.Initialize(dbPath);

                    // Ghi log đăng nhập
                    Logger.LogLogin(currentNhanVien);

                    // Thay vì sử dụng pnlAdmin không tồn tại, hãy sử dụng btnAdmin đã có trong form
                    btnAdmin.Visible = currentNhanVien.IsAdmin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormGiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ghi log đăng xuất
            try
            {
                if (currentNhanVien != null)
                    Logger.LogLogout(currentNhanVien);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi một cách im lặng để không ảnh hưởng đến trải nghiệm người dùng
                Console.WriteLine("Lỗi ghi log đăng xuất: " + ex.Message);
            }
        }
        private void btnXemLog_Click(object sender, EventArgs e)
        {
            if (currentNhanVien != null && currentNhanVien.IsAdmin)
            {
                FormXemLog formXemLog = new FormXemLog();
                formXemLog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập tính năng này!",
                    "Quyền truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion


    }
}

