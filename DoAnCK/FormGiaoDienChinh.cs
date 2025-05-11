using System;
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
            OpenChildForm(new FormTrangChu());
            ShowLoginForm();
            nhapxuat.Visible = false;
        }

        private NhanVien current_nv;
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
                    NhanVien_lb.Text = "Nhân viên: " + formDangNhap.current_nv.TenNv;
                    Ngay_lb.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                    OpenChildForm(new FormTrangChu());
                    current_nv = formDangNhap.current_nv;
                }
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
                OpenChildForm(new FormNhapXuat(current_nv, true));
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
                OpenChildForm(new FormNhapXuat(current_nv, false));
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

        #endregion
    }
}

