using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormTrangChu : Form
    {
        private TrangChuService service;
        public NhanVien CurrentNhanVien { get; set; }

        public FormTrangChu()
        {
            InitializeComponent();
            this.service = new TrangChuService(this);
            KhoHang.Instance.LoadData(true); // Tải từ database
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
            CurrentNhanVien = nhanVien;
        }

        public void AddProduct(HangHoa hh)
        {
            HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
            hh_component.hh = hh;
            hh_component.SetProductInfo(hh);
            DanhSachHangHoa_flp.Controls.Add(hh_component);
        }

        public void ClearProductList()
        {
            DanhSachHangHoa_flp.Controls.Clear();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowHangHoaDetails(HangHoa hh)
        {
            service.ShowHangHoaDetails(hh, CurrentNhanVien);
        }

        public void RefreshProducts()
        {
            try
            {
                string loaiHangHoa = DienTu_bt.Checked ? "Điện tử" :
                                     GiaDung_bt.Checked ? "Gia dụng" :
                                     ThoiTrang_bt.Checked ? "Thời trang" :
                                     TatCaHangHoa_bt.Checked ? "Tất cả" : "Tất cả";
                service.LoadProducts(KhungTimKiem_tb.Text, loaiHangHoa);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi làm mới danh sách hàng hóa: " + ex.Message);
            }
        }

        #region Event
        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                KhungTimKiem_tb.Text = ""; // Đặt ô tìm kiếm rỗng khi tải form
                TatCaHangHoa_bt.Checked = true;
                service.LoadProducts("", "Tất cả"); // Tải tất cả hàng hóa
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách hàng hóa: " + ex.Message);
            }
        }

        private void TatCaHangHoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                TatCaHangHoa_bt.Checked = true;
                GiaDung_bt.Checked = false;
                DienTu_bt.Checked = false;
                ThoiTrang_bt.Checked = false;
                service.LoadProducts(KhungTimKiem_tb.Text, "Tất cả");
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lọc hàng hóa: " + ex.Message);
            }
        }

        private void GiaDung_bt_Click(object sender, EventArgs e)
        {
            try
            {
                TatCaHangHoa_bt.Checked = false;
                GiaDung_bt.Checked = true;
                DienTu_bt.Checked = false;
                ThoiTrang_bt.Checked = false;
                service.LoadProducts(KhungTimKiem_tb.Text, "Gia dụng");
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lọc hàng hóa: " + ex.Message);
            }
        }

        private void DienTu_bt_Click(object sender, EventArgs e)
        {
            try
            {
                TatCaHangHoa_bt.Checked = false;
                GiaDung_bt.Checked = false;
                DienTu_bt.Checked = true;
                ThoiTrang_bt.Checked = false;
                service.LoadProducts(KhungTimKiem_tb.Text, "Điện tử");
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lọc hàng hóa: " + ex.Message);
            }
        }

        private void ThoiTrang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                TatCaHangHoa_bt.Checked = false;
                GiaDung_bt.Checked = false;
                DienTu_bt.Checked = false;
                ThoiTrang_bt.Checked = true;
                service.LoadProducts(KhungTimKiem_tb.Text, "Thời trang");
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lọc hàng hóa: " + ex.Message);
            }
        }

        private void KhungTimKiem_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string loaiHangHoa = DienTu_bt.Checked ? "Điện tử" :
                                     GiaDung_bt.Checked ? "Gia dụng" :
                                     ThoiTrang_bt.Checked ? "Thời trang" :
                                     TatCaHangHoa_bt.Checked ? "Tất cả" : "Tất cả";
                service.LoadProducts(KhungTimKiem_tb.Text, loaiHangHoa);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tìm kiếm hàng hóa: " + ex.Message);
            }
        }

        private void KhungTimKiem_tb_MouseClick(object sender, MouseEventArgs e)
        {
            if (KhungTimKiem_tb.Text == "Tìm kiếm...")
            {
                KhungTimKiem_tb.Text = "";
            }
        }

        private void ThemHangHoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddNewProduct(CurrentNhanVien);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form thêm hàng hóa: " + ex.Message);
            }
        }
        #endregion
    }
}