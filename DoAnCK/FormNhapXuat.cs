using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormNhapXuat : System.Windows.Forms.Form
    {
        private bool isnhap;
        private KhoHang kho = new KhoHang();
        private QuanLyNhapXuat qlnx = new QuanLyNhapXuat();
        private NhanVien current_nv = new NhanVien();

        public FormNhapXuat(NhanVien current_nv, bool isnhap)
        {
            InitializeComponent();

            kho.LoadData();

            this.isnhap = isnhap;
            this.current_nv = current_nv;
        }

        public void them_hh_lo(HangHoa hh)
        {
            try
            {
                if (qlnx.ton_tai(hh) == false)
                {
                    HangHoaDuocChonComponent hh_lo = new HangHoaDuocChonComponent(this);
                    hh_lo.hh = (HangHoa)hh.Clone();
                    hh_lo.hh.SoLuong = 1;
                    hh_lo.SetProductInfo();
                    HangHoaDuocChon_flp.Controls.Add(hh_lo);
                    qlnx.them_hh(hh_lo.hh);
                    tinh_tong_tien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void xoa_hh_lo(HangHoaDuocChonComponent hh_lo)
        {
            try
            {
                HangHoaDuocChon_flp.Controls.Remove(hh_lo);
                qlnx.xoa_hh(hh_lo.hh);
                tinh_tong_tien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void nhap_sl(HangHoaDuocChonComponent hh_lo)
        {
            try
            {
                qlnx.cap_nhat_sl(hh_lo.hh, hh_lo.hh.SoLuong);
                tinh_tong_tien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void tinh_tong_tien()
        {
            try
            {
                ulong tong_tien = qlnx.tinh_tong_tien();
                TongTienHang_lb.Text = "Tổng tiền: " + String.Format("{0:N0}", tong_tien) + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reload_flp()
        {
            try
            {
                DanhSachHangHoa_flp.Controls.Clear();
                kho.LoadData();

                if (LoaiHangHoa_cb.Text == "Điện tử")
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is DienTu && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else if (LoaiHangHoa_cb.Text == "Gia dụng")
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is GiaDung && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else if (LoaiHangHoa_cb.Text == "Thời trang")
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh is ThoiTrang && (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search"))
                        {
                            HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
                            hh_component.hh = hh;
                            hh_component.SetProductInfo(hh);
                            DanhSachHangHoa_flp.Controls.Add(hh_component);
                        }
                    }
                }
                else
                {
                    foreach (HangHoa hh in kho.ds_hang_hoa)
                    {
                        if (hh.TenHang.ToLower().Contains(KhungTimKiem_tb.Text) || KhungTimKiem_tb.Text == "Search")
                        {
                            HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
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

        private void KhungTimKiem_tb_TextChanged(object sender, EventArgs e)
        {
            Reload_flp();
        }

        private void LoaiHangHoa_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reload_flp();
        }

        private void KhungTimKiem_tb_Click(object sender, EventArgs e)
        {
            KhungTimKiem_tb.Text = "";
        }

        private void Huy_bt_Click(object sender, EventArgs e)
        {
            qlnx = new QuanLyNhapXuat();
            HangHoaDuocChon_flp.Controls.Clear();
            tinh_tong_tien();
        }

        private void XuatHoaDon_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (isnhap)
                {
                    
                    NhaCungCap current_ncc = null;
                    for (int i = 0; i < kho.ds_ncc.Count; i++)
                    {
                        if (kho.ds_ncc[i].TenNcc == DsNccCh_cb.Text)
                        {
                            current_ncc = kho.ds_ncc[i];
                            break;
                        }
                    }

                    if (current_ncc != null)
                    {
                        kho.capnhatkho(qlnx, true);

                        HoaDonNhap hoaDonNhap = new HoaDonNhap(qlnx, null, current_nv, current_ncc, qlnx.tinh_tong_tien());
                        string id_hoa_don = hoaDonNhap.SetID() + (kho.ds_hoa_don_nhap.Count + 1);
                        hoaDonNhap.IdHoaDon = id_hoa_don;

                        kho.ThemHoaDonNhap(hoaDonNhap);

                        FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                        formHoaDon.hd_lbl.Text = "Hoá Đơn Nhập";
                        formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                        formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + current_nv.IdNv;
                        formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + id_hoa_don;
                        formHoaDon.idncc_ch_lbl.Text = "ID nhà cung cấp: " + current_ncc.IdNcc;
                        formHoaDon.them_dshh(qlnx);
                        formHoaDon.Show();

                        Reload_flp();
                        HangHoaDuocChon_flp.Controls.Clear();
                        tinh_tong_tien();
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    
                    CuaHang current_ch = null;
                    for (int i = 0; i < kho.ds_cua_hang.Count; i++)
                    {
                        if (kho.ds_cua_hang[i].TenCh == DsNccCh_cb.Text)
                        {
                            current_ch = kho.ds_cua_hang[i];
                            break;
                        }
                    }

                    if (current_ch != null)
                    {
                        if (kho.kha_dung(qlnx))
                        {
                            kho.capnhatkho(qlnx, false);

                            HoaDonXuat hoaDonXuat = new HoaDonXuat(qlnx, null, current_nv, current_ch, qlnx.tinh_tong_tien());
                            string id_hoa_don = hoaDonXuat.SetID() + (kho.ds_hoa_don_xuat.Count + 1);
                            hoaDonXuat.IdHoaDon = id_hoa_don;

                            kho.ThemHoaDonXuat(hoaDonXuat);

                            FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                            formHoaDon.hd_lbl.Text = "Hoá Đơn Xuất";
                            formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                            formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + current_nv.IdNv;
                            formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + id_hoa_don;
                            formHoaDon.idncc_ch_lbl.Text = "ID cửa hàng: " + current_ch.IdCh;
                            formHoaDon.them_dshh(qlnx);
                            formHoaDon.Show();

                            Reload_flp();
                            HangHoaDuocChon_flp.Controls.Clear();
                            tinh_tong_tien();
                        }
                        else
                        {
                            MessageBox.Show("Số lượng tồn kho không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormNhapXuat_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (HangHoa hh in kho.ds_hang_hoa)
                {
                    HangHoaNhapXuatComponent hh_component = new HangHoaNhapXuatComponent(this);
                    hh_component.hh = hh;
                    hh_component.SetProductInfo(hh);
                    DanhSachHangHoa_flp.Controls.Add(hh_component);
                }

                if (isnhap)
                {
                    lanbel2.Text = "Nhà cung cấp";
                    foreach (NhaCungCap ncc in kho.ds_ncc)
                    {
                        DsNccCh_cb.Items.Add(ncc.TenNcc);
                    }
                }
                else
                {
                    lanbel2.Text = "Cửa hàng";
                    foreach (CuaHang ch in kho.ds_cua_hang)
                    {
                        DsNccCh_cb.Items.Add(ch.TenCh);
                    }
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

