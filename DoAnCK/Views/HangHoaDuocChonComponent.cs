using System;
using System.Windows.Forms;
using DoAnCK.Models;

namespace DoAnCK
{
    public partial class HangHoaDuocChonComponent : UserControl
    {
        private FormNhapXuat nhapXuat;
        public HangHoa hh;

        public HangHoaDuocChonComponent(FormNhapXuat nhapXuat)
        {
            InitializeComponent();
            this.nhapXuat = nhapXuat;
        }

        public void SetProductInfo(bool isNhap)
        {
            id_lbl.Text = hh.Id;
            ten_lbl.Text = hh.TenHang;
            soluong_tb.Text = hh.SoLuong.ToString();
            ulong gia = isNhap ? hh.DonGia : hh.GiaXuat;
            thanhtien_lbl.Text = String.Format("{0:N0}", gia * hh.SoLuong);
        }

        #region Event
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            nhapXuat.RemoveProduct(this);
        }

        private void soluong_tb_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(soluong_tb.Text))
            {
                try
                {
                    uint soLuong = Convert.ToUInt32(soluong_tb.Text);
                    hh.SoLuong = soLuong;
                    nhapXuat.UpdateProductQuantity(hh, soLuong);
                    ulong gia = nhapXuat.isNhap ? hh.DonGia : hh.GiaXuat;
                    thanhtien_lbl.Text = String.Format("{0:N0}", gia * hh.SoLuong);
                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void soluong_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}