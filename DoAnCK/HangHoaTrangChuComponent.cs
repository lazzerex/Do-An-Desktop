using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class HangHoaTrangChuComponent : UserControl
    {
        public HangHoaTrangChuComponent(FormTrangChu TrangChu)
        {
            InitializeComponent();
            this.TrangChu = TrangChu;
        }
        private FormTrangChu TrangChu;
        public HangHoa hh;
        public void SetProductInfo(HangHoa hh)
        {
            id_lbl.Text = hh.Id;
            ten_lbl.Text = hh.TenHang;
            dongia_lbl.Text = String.Format("{0:N0}", hh.DonGia);
            soluong_lbl.Text = "SL: " + hh.SoLuong.ToString();
            if (hh.Img != null)
            {
                hanghoa_img.ImageLocation = hh.Img;
            }
        }

        #region Event
        private void Mouse_Enter(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.Gray;
        }
        private void Mouse_Leave(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.FromArgb(192, 255, 192);
        }

        private void Mouse_Click(object sender, EventArgs e)
        {
            FormHangHoa formHangHoa = new FormHangHoa(hh, TrangChu);

            formHangHoa.Show();
        }
        #endregion

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HangHoaTrangChuComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
