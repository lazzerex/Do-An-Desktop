using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormBaoCao : Form
    {
        public FormBaoCao()
        {
            InitializeComponent();
            OpenChildForm(new FormBaoCaoNV());
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
            OpenChildForm(new FormBaoCaoNV());
        }

        private void BaoCaoCH_bt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBaoCaoCH());
        }

        private void BaoCaoNCC_bt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBaoCaoNCC());
        }
    }
}
