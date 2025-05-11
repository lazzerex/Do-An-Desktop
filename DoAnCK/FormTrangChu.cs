using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DoAnCK
{
    public partial class FormTrangChu : System.Windows.Forms.Form
    {
        private KhoHang kho = new KhoHang();
        public FormTrangChu()
        {
            InitializeComponent();
            kho.LoadData();
        }

        public void Reload_flp()
        {
            try
            {
                DanhSachHangHoa_flp.Controls.Clear();
                kho.LoadData();

                if (DienTu_bt.Checked)
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is DienTu && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else if (GiaDung_bt.Checked)
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is GiaDung && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else if (ThoiTrang_bt.Checked)
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is ThoiTrang && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else if (TatCaHangHoa_bt.Checked)
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search")
                        {
                            HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event
        private void TatCaHangHoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                TatCaHangHoa_bt.Checked = true;
                GiaDung_bt.Checked = false;
                DienTu_bt.Checked = false;
                ThoiTrang_bt.Checked = false;

                DanhSachHangHoa_flp.Controls.Clear();
                Reload_flp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DanhSachHangHoa_flp.Controls.Clear();
                Reload_flp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DanhSachHangHoa_flp.Controls.Clear();
                Reload_flp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DanhSachHangHoa_flp.Controls.Clear();
                Reload_flp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhungTimKiem_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DanhSachHangHoa_flp.Controls.Clear();
                string searchText = KhungTimKiem_tb.Text;
                Reload_flp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhungTimKiem_tb_MouseClick(object sender, MouseEventArgs e)
        {
            KhungTimKiem_tb.Text = "";
        }

        private void ThemHangHoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                FormHangHoa formthem = new FormHangHoa(null, this);
                formthem.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath_hh = "Resources/hang_hoa.dat";
                using (StreamReader reader = new StreamReader(filePath_hh))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<HangHoa>));
                    kho.ds_hang_hoa = (List<HangHoa>)serializer.Deserialize(reader);
                }

                foreach (HangHoa hh in kho.ds_hang_hoa)
                {
                    HangHoaTrangChuComponent hh_component = new HangHoaTrangChuComponent(this);
                    hh_component.hh = hh;
                    hh_component.SetProductInfo(hh);
                    DanhSachHangHoa_flp.Controls.Add(hh_component);
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

