using System;
using System.Windows.Forms;

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
        public void SetProductInfo(HangHoa hh)
        {
            id_bhdx.Text = hh.Id.ToString();
            sp_bhdx.Text = hh.TenHang;
            sl_bhdx.Text = hh.SoLuong.ToString();
            tt_bhdx.Text = String.Format("{0:N0}", hh.DonGia * hh.SoLuong);
        }
    }
}
