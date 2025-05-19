using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormHoaDon : System.Windows.Forms.Form
    {
        KhoHang kho = new KhoHang();
        private bool isnhap;

        private int index;

        public FormHoaDon(bool isnhap)
        {
            InitializeComponent();
            kho.LoadData();
            this.isnhap = isnhap;
        }

        #region Event
        private void HoaDon_load(object sender, EventArgs e)
        {
            try
            {
                if (isnhap)
                {
                    label1.Text = "Danh sách hoá đơn nhập";
                    DanhSachHoaDon_dgv.Columns["idnccch_hd"].HeaderText = "ID nhà cung cấp";
                    foreach (HoaDonNhap hdn in kho.ds_hoa_don_nhap)
                    {
                        if (hdn.NvLap != null && hdn.NhaCungCap != null)
                        {
                            DanhSachHoaDon_dgv.Rows.Add(hdn.IdHoaDon, hdn.NgayTaoDon, hdn.NvLap.IdNv, hdn.NhaCungCap.IdNcc, hdn.TongTien);
                        }
                        else
                        {
                            // Handle the case where NvLap or NhaCungCap is null
                            MessageBox.Show("Có hóa đơn lỗi hãy kiểm tra dữ liệu được lưu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    DanhSachHoaDon_dgv.Enabled = DanhSachHoaDon_dgv.Rows.Count > 0;
                }
                else
                {
                    label1.Text = "Danh sách hoá đơn xuất";
                    DanhSachHoaDon_dgv.Columns["idnccch_hd"].HeaderText = "ID cửa hàng";
                    foreach (HoaDonXuat hdx in kho.ds_hoa_don_xuat)
                    {

                        if (hdx.NvLap != null && hdx.CuaHang != null)
                        {
                            DanhSachHoaDon_dgv.Rows.Add(hdx.IdHoaDon, hdx.NgayTaoDon, hdx.NvLap.IdNv, hdx.CuaHang.IdCh, hdx.TongTien);
                        }
                        else
                        {                           
                            MessageBox.Show("Có hóa đơn lỗi hãy kiểm tra dữ liệu được lưu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    DanhSachHoaDon_dgv.Enabled = DanhSachHoaDon_dgv.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhSachHoaDon_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = DanhSachHoaDon_dgv.CurrentCell.RowIndex;
                if (isnhap)
                {
                    HoaDonNhap hdn = kho.ds_hoa_don_nhap[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.hd_lbl.Text = "Hoá Đơn Nhập";
                    formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                    formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + hdn.NvLap.IdNv;
                    formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + hdn.IdHoaDon;
                    formHoaDon.idncc_ch_lbl.Text = "ID nhà cung cấp: " + hdn.NhaCungCap.IdNcc;
                    formHoaDon.them_dshh(hdn.Qlnx);
                    formHoaDon.Show();
                }
                else
                {
                    HoaDonXuat hdx = kho.ds_hoa_don_xuat[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.hd_lbl.Text = "Hoá Đơn Xuất";
                    formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                    formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + hdx.NvLap.IdNv;
                    formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + hdx.IdHoaDon;
                    formHoaDon.idncc_ch_lbl.Text = "ID cửa hàng: " + hdx.CuaHang.IdCh;
                    formHoaDon.them_dshh(hdx.Qlnx);
                    formHoaDon.Show();
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
