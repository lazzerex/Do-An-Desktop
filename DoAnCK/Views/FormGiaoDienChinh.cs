using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;
using Guna.UI2.WinForms; // Thêm using để sử dụng Guna2GradientTileButton

namespace DoAnCK
{
    public partial class FormGiaoDienChinh : Form
    {
        private GiaoDienChinhService service;
        private Form currentFormChild;

        public FormGiaoDienChinh()
        {
            InitializeComponent();
            this.service = new GiaoDienChinhService(this);
            service.Initialize();
            nhapxuat.Visible = false; 
        }

        public void SetNhanVien(string tenNv)
        {
            NhanVien_lb.Text = $"Nhân viên: {tenNv}";
        }

        public void SetDate(string date)
        {
            Ngay_lb.Text = $"Ngày {date}";
        }

        public void SetAdminVisibility(bool isAdmin)
        {
            QuanLy_bt.Visible = isAdmin;
            BaoCao_bt.Visible = isAdmin;
        }

        public void OpenChildForm(Form childForm)
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

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm()
        {
            this.Close();
        }

        #region Event
        private void FormGiaoDienChinh_Load(object sender, EventArgs e)
        {
            // Initialization handled by GiaoDienChinhService
        }

        private void TrangChu_bt_Click(object sender, EventArgs e)
        {
            try
            {
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.SetCurrentNhanVien(KhoHang.Instance.CurrentNhanVien);
                service.OpenChildForm(formTrangChu);
                UpdateButtonStates(TrangChu_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở trang chủ: " + ex.Message);
            }
        }

        private void NhapHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormNhapXuat(KhoHang.Instance.CurrentNhanVien, true));
                UpdateButtonStates(NhapHang_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form nhập hàng: " + ex.Message);
            }
        }

        private void XuatHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormNhapXuat(KhoHang.Instance.CurrentNhanVien, false));
                UpdateButtonStates(XuatHang_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form xuất hàng: " + ex.Message);
            }
        }

        private void CuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                FormCuaHang formCuaHang = new FormCuaHang(KhoHang.Instance.CurrentNhanVien);
                service.OpenChildForm(formCuaHang);
                UpdateButtonStates(CuaHang_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form cửa hàng: " + ex.Message);
            }
        }

        private void NhaCungCap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                FormNhaCungCap formNhaCungCap = new FormNhaCungCap();
                formNhaCungCap.SetCurrentNhanVien(KhoHang.Instance.CurrentNhanVien);
                service.OpenChildForm(formNhaCungCap);
                UpdateButtonStates(NhaCungCap_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form nhà cung cấp: " + ex.Message);
            }
        }

        private void HoaDonNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormHoaDon(true));
                UpdateButtonStates(HoaDon_bt, HoaDonNhap_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form hóa đơn nhập: " + ex.Message);
            }
        }

        private void HoaDonXuat_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormHoaDon(false));
                UpdateButtonStates(HoaDon_bt, HoaDonXuat_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form hóa đơn xuất: " + ex.Message);
            }
        }

        private async void HoaDon_bt_Click(object sender, EventArgs e)
        {
            try
            {
                nhapxuat.Visible = true;
                int startPosition = HoaDon_bt.Left - nhapxuat.Width;
                nhapxuat.Left = startPosition;
                for (int i = 0; i <= nhapxuat.Width; i += 10)
                {
                    nhapxuat.Left = startPosition + i;
                    await Task.Delay(10);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi hiển thị menu hóa đơn: " + ex.Message);
            }
        }

        private async void HoaDon_bt_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(3000);
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
                ShowError("Lỗi khi ẩn menu hóa đơn: " + ex.Message);
            }
        }

        private void QuanLy_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormQuanLyAdmin(KhoHang.Instance.CurrentNhanVien));
                UpdateButtonStates(QuanLy_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form quản lý: " + ex.Message);
            }
        }

        private void BaoCao_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.OpenChildForm(new FormBaoCao());
                UpdateButtonStates(BaoCao_bt);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form báo cáo: " + ex.Message);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                service.LoadData();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            try
            {
                service.CreateTables();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tạo bảng: " + ex.Message);
            }
        }

        private void btnCheckSQLite_Click(object sender, EventArgs e)
        {
            try
            {
                service.ShowSQLiteInfo();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xem thông tin SQLite: " + ex.Message);
            }
        }

        private void btnXemLog_Click(object sender, EventArgs e)
        {
            try
            {
                service.ShowLog();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xem log: " + ex.Message);
            }
        }

        private void FormGiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                service.Logout();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi đóng ứng dụng: " + ex.Message);
            }
        }

        private void UpdateButtonStates(params Guna2GradientTileButton[] activeButtons)
        {
            // Đặt lại trạng thái của tất cả các nút
            TrangChu_bt.Checked = false;
            NhapHang_bt.Checked = false;
            XuatHang_bt.Checked = false;
            CuaHang_bt.Checked = false;
            NhaCungCap_bt.Checked = false;
            HoaDon_bt.Checked = false;
            HoaDonNhap_bt.Checked = false;
            HoaDonXuat_bt.Checked = false;
            QuanLy_bt.Checked = false;
            BaoCao_bt.Checked = false;

            // Đặt trạng thái Checked cho các nút được truyền vào
            foreach (var btn in activeButtons)
            {
                btn.Checked = true;
            }
        }
        #endregion
    }
}