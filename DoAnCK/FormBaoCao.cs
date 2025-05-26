using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class FormBaoCao : Form
    {
        private KhoHang kho = KhoHang.Instance;
        private Form currentFormChild;

        public FormBaoCao()
        {
            InitializeComponent();
            OpenChildForm(new FormBaoCaoNV());
        }

        // Kiểm tra quyền admin
        private bool KiemTraQuyenAdmin()
        {
            if (kho.CurrentNhanVien != null && kho.CurrentNhanVien.IsAdmin)
            {
                return true;
            }

            MessageBox.Show("Bạn không có quyền xem báo cáo này!",
                "Quyền truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void OpenChildForm(Form childForm)
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
                BaoCao_panel.Controls.Add(childForm);
                BaoCao_panel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCaoNV_bt_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            OpenChildForm(new FormBaoCaoNV());
        }

        private void BaoCaoCH_bt_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            OpenChildForm(new FormBaoCaoCH());
        }

        private void BaoCaoNCC_bt_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            OpenChildForm(new FormBaoCaoNCC());
        }
    }
}
