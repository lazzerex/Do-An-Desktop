using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class FormHangHoa : Form
    {
        private HangHoaService service;
        private string img_filepath;
        private HangHoa hh;

        public FormHangHoa(HangHoa hh, FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.hh = hh;
            this.service = new HangHoaService(this, formTrangChu);
            KhoHang.Instance.LoadData();
            service.LoadHangHoa(hh);
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            KhoHang.Instance.CurrentNhanVien = nhanVien;
        }

        public void PopulateLoaiHangHoa()
        {
            LoaiHangHoa_cb.Items.Add("Điện tử");
            LoaiHangHoa_cb.Items.Add("Gia dụng");
            LoaiHangHoa_cb.Items.Add("Thời trang");
        }

        public void SetAddMode()
        {
            XoaHang_bt.Visible = false;
            SoLuong_tb.Text = "0";
            SoLuong_tb.Enabled = false;
        }

        public void SetViewMode(HangHoa hh)
        {
            if (!string.IsNullOrEmpty(hh.Img))
            {
                try
                {
                    AnhHangHoa_bt.Image = Image.FromFile(hh.Img);
                }
                catch
                {
                    AnhHangHoa_bt.Image = null; // Handle missing image
                }
            }
            ThemAnh_bt.Visible = false;
            IdHangHoa_tb.Text = hh.Id;
            TenHangHoa_tb.Text = hh.TenHang;
            SoLuong_tb.Text = hh.SoLuong.ToString();
            GiaNhap_tb.Text = hh.DonGia.ToString();
            GiaXuat_tb.Text = hh.GiaXuat.ToString();

            if (hh is DienTu)
            {
                LoaiHangHoa_cb.Text = "Điện tử";
            }
            else if (hh is GiaDung)
            {
                LoaiHangHoa_cb.Text = "Gia dụng";
            }
            else if (hh is ThoiTrang)
            {
                LoaiHangHoa_cb.Text = "Thời trang";
            }
            else
            {
                LoaiHangHoa_cb.Text = "";
            }

            ThemAnh_bt.Enabled = false;
            IdHangHoa_tb.Enabled = false;
            TenHangHoa_tb.Enabled = false;
            GiaNhap_tb.Enabled = false;
            GiaXuat_tb.Enabled = false;
            LoaiHangHoa_cb.Enabled = false;
            SoLuong_tb.Enabled = false;
            Themhang_bt.Visible = false;
            XoaHang_bt.Visible = true;
        }

        public void SetImage(string filePath, string relativePath)
        {
            AnhHangHoa_bt.Image = Image.FromFile(filePath);
            ThemAnh_bt.Visible = false;
            img_filepath = relativePath;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        public void FocusIdField()
        {
            IdHangHoa_tb.Focus();
        }

        public void ClearIdField()
        {
            IdHangHoa_tb.Text = "";
        }

        public void CloseForm()
        {
            this.Close();
        }

        #region Event
        private void ThemAnh_bt_Click(object sender, EventArgs e)
        {
            try
            {
                service.SelectImage();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi chọn ảnh: " + ex.Message);
            }
        }

        private void IdHangHoa_tb_TextChanged(object sender, EventArgs e)
        {
            if (IdHangHoa_tb.Text.Length > 4)
            {
                IdHangHoa_tb.Text = IdHangHoa_tb.Text.Substring(0, 4);
                IdHangHoa_tb.SelectionStart = IdHangHoa_tb.Text.Length;
            }
        }

        private void IdHangHoa_tb_Leave(object sender, EventArgs e)
        {
            try
            {
                service.CheckId(IdHangHoa_tb.Text);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi kiểm tra ID: " + ex.Message);
            }
        }

        private void keypress_DonGia_tb(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ThemHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                uint soLuong;
                ulong giaNhap, giaXuat;
                try
                {
                    soLuong = uint.Parse(SoLuong_tb.Text);
                    giaNhap = ulong.Parse(GiaNhap_tb.Text);
                    giaXuat = ulong.Parse(GiaXuat_tb.Text);
                }
                catch
                {
                    ShowError("Số lượng, giá nhập, và giá xuất phải là số hợp lệ!");
                    return;
                }

                service.AddHangHoa(
                    IdHangHoa_tb.Text,
                    TenHangHoa_tb.Text,
                    soLuong,
                    giaNhap,
                    giaXuat,
                    LoaiHangHoa_cb.Text,
                    img_filepath
                );
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi thêm hàng hóa: " + ex.Message);
            }
        }

        private void XoaHang_tb_Click(object sender, EventArgs e)
        {
            try
            {
                service.RemoveHangHoa(hh);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xóa hàng hóa: " + ex.Message);
            }
        }

        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            // Moved to service.LoadHangHoa to ensure consistent initialization
        }
        #endregion
    }
}