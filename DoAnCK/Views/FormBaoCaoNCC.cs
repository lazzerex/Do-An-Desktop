using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormBaoCaoNCC : Form
    {
        private readonly BaoCaoService service = new BaoCaoService();
        private readonly KhoHang kho = KhoHang.Instance;

        public FormBaoCaoNCC()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Tải danh sách nhà cung cấp
                cboNhaCungCap.Items.Clear();
                cboNhaCungCap.Items.Add("Tất cả nhà cung cấp");
                foreach (NhaCungCap ncc in kho.ds_ncc)
                {
                    cboNhaCungCap.Items.Add(ncc);
                }
                cboNhaCungCap.DisplayMember = "TenNcc";
                cboNhaCungCap.ValueMember = "IdNcc";
                cboNhaCungCap.SelectedIndex = 0;

                // Thiết lập giá trị mặc định cho DateTimePicker
                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                dtpDenNgay.Value = DateTime.Now;

                // Chuẩn bị DataGridView
                dgvBaoCaoNCC.Columns.Clear();
                dgvBaoCaoNCC.Columns.Add("IdNcc", "Mã NCC");
                dgvBaoCaoNCC.Columns.Add("TenNcc", "Tên nhà cung cấp");
                dgvBaoCaoNCC.Columns.Add("SoLuongNhap", "Số lượng nhập");
                dgvBaoCaoNCC.Columns.Add("TongGiaTri", "Tổng giá trị nhập");
                dgvBaoCaoNCC.Columns.Add("TyLeNhap", "Tỷ lệ giá trị nhập");

                // Tải dữ liệu mặc định
                HienThiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiBaoCao()
        {
            try
            {
                dgvBaoCaoNCC.Rows.Clear();

                string idNcc = null;
                if (cboNhaCungCap.SelectedIndex > 0 && cboNhaCungCap.SelectedItem is NhaCungCap ncc)
                {
                    idNcc = ncc.IdNcc;
                }

                var (data, tongSoLuongNhap, tongGiaTriNhap) =
                    service.TaiDuLieuBaoCaoNhaCungCap(dtpTuNgay.Value, dtpDenNgay.Value, idNcc);

                foreach (var item in data)
                {
                    dgvBaoCaoNCC.Rows.Add(
                        item.IdNcc,
                        item.TenNcc,
                        item.SoLuongNhap.ToString("N0"),
                        item.TongGiaTri.ToString("N0") + " VNĐ",
                        item.TyLeNhap.ToString("F2") + "%"
                    );
                }

                // Thêm dòng tổng cộng
                if (data.Count > 0)
                {
                    dgvBaoCaoNCC.Rows.Add(
                        "",
                        "TỔNG CỘNG",
                        tongSoLuongNhap.ToString("N0"),
                        tongGiaTriNhap.ToString("N0") + " VNĐ",
                        "100%"
                    );
                    dgvBaoCaoNCC.Rows[dgvBaoCaoNCC.Rows.Count - 1].DefaultCellStyle.Font =
                        new Font(dgvBaoCaoNCC.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi hiển thị báo cáo nhà cung cấp: " + ex.Message);
            }
        }
    }
}