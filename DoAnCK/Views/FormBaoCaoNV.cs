using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormBaoCaoNV : Form
    {
        private readonly BaoCaoService service = new BaoCaoService();

        public FormBaoCaoNV()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Thiết lập giá trị mặc định cho DateTimePicker
                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                dtpDenNgay.Value = DateTime.Now;

                // Chuẩn bị DataGridView
                dgvBaoCaoNV.Columns.Clear();
                dgvBaoCaoNV.Columns.Add("MaNV", "Mã NV");
                dgvBaoCaoNV.Columns.Add("TenNV", "Tên nhân viên");
                dgvBaoCaoNV.Columns.Add("SoHDNhap", "Số HD nhập");
                dgvBaoCaoNV.Columns.Add("SoHDXuat", "Số HD xuất");
                dgvBaoCaoNV.Columns.Add("TongDoanhThu", "Tổng doanh thu");
                dgvBaoCaoNV.Columns.Add("TongTienNhap", "Tổng tiền nhập hàng");

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
                dgvBaoCaoNV.Rows.Clear();

                var (data, tongHDNhap, tongHDXuat, tongDoanhThuXuat, tongTienNhapHang) =
                    service.TaiDuLieuBaoCaoNhanVien(dtpTuNgay.Value, dtpDenNgay.Value);

                foreach (var item in data)
                {
                    dgvBaoCaoNV.Rows.Add(
                        item.MaNV,
                        item.TenNV,
                        item.SoHDNhap,
                        item.SoHDXuat,
                        item.DoanhThuXuat.ToString("N0") + " VNĐ",
                        item.TienNhapHang.ToString("N0") + " VNĐ"
                    );
                }

                // Thêm dòng tổng cộng
                if (data.Count > 0)
                {
                    dgvBaoCaoNV.Rows.Add(
                        "",
                        "TỔNG CỘNG",
                        tongHDNhap,
                        tongHDXuat,
                        tongDoanhThuXuat.ToString("N0") + " VNĐ",
                        tongTienNhapHang.ToString("N0") + " VNĐ"
                    );
                    dgvBaoCaoNV.Rows[dgvBaoCaoNV.Rows.Count - 1].DefaultCellStyle.Font =
                        new Font(dgvBaoCaoNV.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi hiển thị báo cáo nhân viên: " + ex.Message);
            }
        }
    }
}