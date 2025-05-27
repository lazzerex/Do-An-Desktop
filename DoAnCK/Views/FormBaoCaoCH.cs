using System;
using System.Drawing;
using System.Windows.Forms;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormBaoCaoCH : Form
    {
        private readonly BaoCaoService service = new BaoCaoService();

        public FormBaoCaoCH()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Load combo box loại hàng hóa
                cboLoaiHangHoa.Items.Clear();
                cboLoaiHangHoa.Items.Add("Tất cả loại hàng");
                cboLoaiHangHoa.Items.Add("Điện tử");
                cboLoaiHangHoa.Items.Add("Gia dụng");
                cboLoaiHangHoa.Items.Add("Thời trang");
                cboLoaiHangHoa.SelectedIndex = 0;

                // Thiết lập giá trị mặc định cho DateTimePicker
                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                dtpDenNgay.Value = DateTime.Now;

                // Cấu hình DataGridView
                dgvBaoCaoCH.Columns.Clear();
                dgvBaoCaoCH.Columns.Add("LoaiHang", "Loại hàng");
                dgvBaoCaoCH.Columns.Add("SoLuongBan", "Số lượng bán");
                dgvBaoCaoCH.Columns.Add("DoanhThu", "Doanh thu");
                dgvBaoCaoCH.Columns.Add("TyLeDoanhThu", "Tỷ lệ doanh thu");

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
                dgvBaoCaoCH.Rows.Clear();

                string loaiHang = null;
                if (cboLoaiHangHoa.SelectedIndex > 0)
                {
                    loaiHang = cboLoaiHangHoa.SelectedItem.ToString();
                }

                var (data, tongSoLuongBan, tongDoanhThu) =
                    service.TaiDuLieuBaoCaoHangHoa(dtpTuNgay.Value, dtpDenNgay.Value, loaiHang);

                foreach (var item in data)
                {
                    dgvBaoCaoCH.Rows.Add(
                        item.LoaiHang,
                        item.SoLuongBan.ToString("N0"),
                        item.DoanhThu.ToString("N0") + " VNĐ",
                        item.TyLeDoanhThu.ToString("F2") + "%"
                    );
                }

                // Thêm dòng tổng cộng
                if (data.Count > 0)
                {
                    dgvBaoCaoCH.Rows.Add(
                        "TỔNG CỘNG",
                        tongSoLuongBan.ToString("N0"),
                        tongDoanhThu.ToString("N0") + " VNĐ",
                        "100%"
                    );
                    dgvBaoCaoCH.Rows[dgvBaoCaoCH.Rows.Count - 1].DefaultCellStyle.Font =
                        new Font(dgvBaoCaoCH.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi hiển thị báo cáo hàng hóa: " + ex.Message);
            }
        }
    }
}