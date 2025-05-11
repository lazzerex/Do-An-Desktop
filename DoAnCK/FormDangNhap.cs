using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormDangNhap : System.Windows.Forms.Form
    {
        private KhoHang kho = new KhoHang();

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
    }
}
