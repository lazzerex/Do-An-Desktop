using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormPhieuHoaDon : System.Windows.Forms.Form
    {
        public FormPhieuHoaDon()
        {
            InitializeComponent();
        }

        public void them_dshh(QuanLyNhapXuat qlnx)
        {
            try
            {
                foreach (HangHoa hh in qlnx.ds_hang_hoa)
                {
                    HoaDon1Component billComponent = new HoaDon1Component(this);
                    billComponent.hh = hh;
                    billComponent.SetProductInfo(hh);
                    dshd_flp.Controls.Add(billComponent);
                }

                ulong tong_tien = 0;
                ulong so_luong = 0;
                foreach (HangHoa hh in qlnx.ds_hang_hoa)
                {
                    tong_tien += hh.DonGia * hh.SoLuong;
                    so_luong += hh.SoLuong;
                }

                HoaDon2Component billTailComponent = new HoaDon2Component();
                billTailComponent.soluong_endbill.Text = "Số Lượng:   " + so_luong;
                billTailComponent.thanhtien_endbill.Text = "Thành Tiền:   " + String.Format("{0:N0}", tong_tien) + " VNĐ";
                dshd_flp.Controls.Add(billTailComponent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
