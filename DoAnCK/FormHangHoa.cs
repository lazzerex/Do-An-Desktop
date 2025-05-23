using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormHangHoa : System.Windows.Forms.Form
    {
        private KhoHang kho = KhoHang.Instance;
        private HangHoa hh;
        private string img_filepath;
        private FormTrangChu formTrangChu;

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            kho.CurrentNhanVien = nhanVien;
        }

        public FormHangHoa(HangHoa hh, FormTrangChu formTrangChu)
        {
            InitializeComponent();

            this.formTrangChu = formTrangChu;
            this.hh = hh;
            kho.LoadData();
        }

        #region Event
        private void ThemAnh_bt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Chọn ảnh hàng hóa",
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    AnhHangHoa_bt.Image = Image.FromFile(filePath);
                    ThemAnh_bt.Visible = false;
                    img_filepath = @".\" + filePath.Substring(filePath.IndexOf("Resources"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string text = IdHangHoa_tb.Text;
                if (!(text.StartsWith("DT") || text.StartsWith("GD") || text.StartsWith("TR")))
                {
                    MessageBox.Show("ID phải bắt đầu bằng DT, GD, hoặc TR.", "Sai mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IdHangHoa_tb.Focus();
                }

                HangHoa foundHangHoa = null;
                for (int i = 0; i < kho.ds_hang_hoa.Count; i++)
                {
                    if (kho.ds_hang_hoa[i].Id == IdHangHoa_tb.Text)
                    {
                        foundHangHoa = kho.ds_hang_hoa[i];
                        break;
                    }
                }

                if (foundHangHoa != null)
                {
                    MessageBox.Show("Hàng hoá đã tồn tại");
                    IdHangHoa_tb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string loai_hh = LoaiHangHoa_cb.Text;

                if (TenHangHoa_tb.Text == "" || IdHangHoa_tb.Text == "" || DonGia_tb.Text == "" || GiaBan_tb.Text == "" || LoaiHangHoa_cb.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult xacnhan = MessageBox.Show("Bạn có chắc chắn muốn thêm hàng hoá?", "Xác nhận", MessageBoxButtons.OKCancel);
                    if (xacnhan == DialogResult.OK)
                    {
                        if (loai_hh == "Điện tử")
                        {
                            hh = new DienTu(
                                IdHangHoa_tb.Text,
                                TenHangHoa_tb.Text,
                                Convert.ToUInt32(SoLuong_tb.Text),
                                Convert.ToUInt64(DonGia_tb.Text),
                                img_filepath,
                                Convert.ToUInt64(GiaBan_tb.Text));

                            kho.them_hh(hh);
                        }
                        else if (loai_hh == "Gia dụng")
                        {
                            hh = new GiaDung(
                                IdHangHoa_tb.Text,
                                TenHangHoa_tb.Text,
                                Convert.ToUInt32(SoLuong_tb.Text),
                                Convert.ToUInt64(DonGia_tb.Text),
                                img_filepath,
                                Convert.ToUInt64(GiaBan_tb.Text));

                            kho.them_hh(hh);
                        }
                        else if (loai_hh == "Thời trang")
                        {
                            hh = new ThoiTrang(
                                IdHangHoa_tb.Text,
                                TenHangHoa_tb.Text,
                                Convert.ToUInt32(SoLuong_tb.Text),
                                Convert.ToUInt64(DonGia_tb.Text),
                                img_filepath,
                                Convert.ToUInt64(GiaBan_tb.Text));

                            kho.them_hh(hh);
                        }

                        formTrangChu.Reload_flp();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void XoaHang_tb_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult xacnhan = MessageBox.Show("Bạn có chắc chắn muốn xoá hàng hoá?", "Xác nhận", MessageBoxButtons.OKCancel);
                if (xacnhan == DialogResult.OK)
                {
                    HangHoa foundHangHoa = null;
                    for (int i = 0; i < kho.ds_hang_hoa.Count; i++)
                    {
                        if (kho.ds_hang_hoa[i].Id == hh.Id)
                        {
                            foundHangHoa = kho.ds_hang_hoa[i];
                            break;
                        }
                    }

                    if (foundHangHoa != null)
                    {
                        hh = foundHangHoa;
                        kho.xoa_hh(hh);
                        formTrangChu.Reload_flp();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            try
            {
                LoaiHangHoa_cb.Items.Add("Điện tử");
                LoaiHangHoa_cb.Items.Add("Gia dụng");
                LoaiHangHoa_cb.Items.Add("Thời trang");

                if (hh == null)
                {
                    XoaHang_bt.Visible = false;
                    SoLuong_tb.Text = "0";
                    SoLuong_tb.Enabled = false;
                }
                else
                {
                    if (hh.Img != null)
                    {
                        AnhHangHoa_bt.Image = Image.FromFile(hh.Img);
                    }
                    ThemAnh_bt.Visible = false;
                    IdHangHoa_tb.Text = hh.Id;
                    TenHangHoa_tb.Text = hh.TenHang;
                    SoLuong_tb.Text = hh.SoLuong.ToString();
                    DonGia_tb.Text = hh.DonGia.ToString();
                    GiaBan_tb.Text = hh.GiaBan.ToString();

                    if (hh is DienTu)
                    {
                        LoaiHangHoa_cb.Text = "Điện tử";
                    }
                    else if (hh is ThoiTrang)
                    {
                        LoaiHangHoa_cb.Text = "Thời trang";
                    }
                    else if (hh is GiaDung)
                    {
                        LoaiHangHoa_cb.Text = "Gia dụng";
                    }

                    ThemAnh_bt.Enabled = false;
                    IdHangHoa_tb.Enabled = false;
                    TenHangHoa_tb.Enabled = false;
                    DonGia_tb.Enabled = false;
                    GiaBan_tb.Enabled = false;
                    LoaiHangHoa_cb.Enabled = false;
                    SoLuong_tb.Enabled = false;
                    Themhang_bt.Visible = false;
                    XoaHang_bt.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
