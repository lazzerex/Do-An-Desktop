using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class HoaDon1Component : UserControl
    {
        private FormPhieuHoaDon HoaDon;
        public HangHoa hh;
        public HoaDon1Component(FormPhieuHoaDon HoaDon)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
        }
        public void SetProductInfo(HangHoa hh, bool isNhap)
        {
            id_bhdx.Text = hh.Id.ToString();
            sp_bhdx.Text = hh.TenHang;
            sl_bhdx.Text = hh.SoLuong.ToString();
            ulong gia = isNhap ? hh.DonGia : hh.GiaXuat;
            tt_bhdx.Text = String.Format("{0:N0}", gia * hh.SoLuong);
        }
    }
}
