using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormGiaoDienChinh : System.Windows.Forms.Form
    {
        private KhoHang kho = KhoHang.Instance;
        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            kho.CurrentNhanVien = nhanVien;
        }
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

                    // Sử dụng đối tượng singleton KhoHang.Instance
                    kho.CurrentNhanVien = currentNhanVien;

                    // Khởi tạo Logger
                    string dbPath = System.IO.Path.Combine(Application.StartupPath, "CuaHang.db");
                    Logger.Initialize(dbPath);

                    // Hiển thị form trang chủ
                    FormTrangChu formTrangChu = new FormTrangChu();
                    formTrangChu.CurrentNhanVien = currentNhanVien;  // Truyền CurrentNhanVien
                    OpenChildForm(formTrangChu);

                    // Hiển thị nút Admin nếu người dùng là admin
                    if (QuanLy_bt != null)
                        QuanLy_bt.Visible = currentNhanVien.IsAdmin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLy_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormQuanLyAdmin(currentNhanVien));
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
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormQuanLyAdmin(currentNhanVien));
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
                // Tạo FormTrangChu mới và truyền currentNhanVien
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.CurrentNhanVien = currentNhanVien;
                formTrangChu.SetCurrentNhanVien(currentNhanVien);

                // Sử dụng form đã được cài đặt CurrentNhanVien
                OpenChildForm(formTrangChu);

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
                // Tạo và truyền currentNhanVien khi khởi tạo FormCuaHang
                FormCuaHang formCuaHang = new FormCuaHang(currentNhanVien);

          

                // Mở form đã được khởi tạo với CurrentNhanVien
                OpenChildForm(formCuaHang);

                // Phần còn lại giữ nguyên
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
                // Tạo đối tượng FormNhaCungCap và truyền CurrentNhanVien
                FormNhaCungCap formNhaCungCap = new FormNhaCungCap();
                formNhaCungCap.SetCurrentNhanVien(currentNhanVien);

                // Mở form đã được cài đặt CurrentNhanVien
                OpenChildForm(formNhaCungCap);

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



                    // Thay vì sử dụng pnlAdmin không tồn tại, hãy sử dụng btnAdmin đã có trong form
                    QuanLy_bt.Visible = currentNhanVien.IsAdmin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormGiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            kho.SaveToDatabase();
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

