using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK
{
    public partial class HangHoaTrangChuComponent : UserControl
    {
        private FormTrangChu trangChu;
        public HangHoa hh;

        public HangHoaTrangChuComponent(FormTrangChu trangChu)
        {
            InitializeComponent();
            this.trangChu = trangChu;
        }

        public void SetProductInfo(HangHoa hh)
        {
            this.hh = hh;
            id_lbl.Text = hh.Id;
            ten_lbl.Text = hh.TenHang;
            dongia_lbl.Text = String.Format("{0:N0}", hh.DonGia);
            soluong_lbl.Text = "SL: " + hh.SoLuong.ToString();
            if (!string.IsNullOrEmpty(hh.Img))
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
            guna2GradientPanel1.FillColor = Color.FromArgb(169, 183, 172);
        }

        private void Mouse_Click(object sender, EventArgs e)
        {
            trangChu.ShowHangHoaDetails(hh);
        }
        #endregion
    }
}