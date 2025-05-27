using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK
{
    public partial class HangHoaNhapXuatComponent : UserControl
    {
        private FormNhapXuat nhapXuat;
        public HangHoa hh;

        public HangHoaNhapXuatComponent(FormNhapXuat nhapXuat)
        {
            InitializeComponent();
            this.nhapXuat = nhapXuat;
        }

        public void SetProductInfo(HangHoa hh, bool isNhap)
        {
            this.hh = hh;
            ten_lbl.Text = hh.TenHang;
            dongia_lbl.Text = String.Format("{0:N0}", isNhap ? hh.DonGia : hh.GiaXuat);
            soluong_lbl.Text = "SL: " + hh.SoLuong.ToString();
            if (!string.IsNullOrEmpty(hh.Img))
            {
                hanghoa_img.ImageLocation = hh.Img;
            }
            else
            {
                hanghoa_img.ImageLocation = "Resources/default.jpg";
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
            nhapXuat.AddProduct(hh);
        }
        #endregion
    }
}