using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DoAnCK
{
    public partial class FormBaoCaoCH : Form
    {
        private KhoHang kho = KhoHang.Instance;
        private SQLiteHelper dbHelper;

        public FormBaoCaoCH()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CuaHang.db");
                dbHelper = new SQLiteHelper(dbPath);

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

                TaiDuLieuBaoCaoHangHoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBaoCaoCH_Load(object sender, EventArgs e)
        {
            // Đã được xử lý trong LoadData()
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieuBaoCaoHangHoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieuBaoCaoHangHoa()
        {
            try
            {
                // Xóa dữ liệu cũ
                dgvBaoCaoCH.Rows.Clear();

                // Lấy ngày bắt đầu và kết thúc
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Kết thúc ngày

                // Điều kiện loại hàng
                string loaiHangDieuKien = "";
                if (cboLoaiHangHoa.SelectedIndex > 0)
                {
                    loaiHangDieuKien = $" AND hh.loai = '{cboLoaiHangHoa.SelectedItem}' ";
                }

                // Lấy dữ liệu từ cơ sở dữ liệu
                string query = @"
SELECT 
    hh.loai AS LoaiHang,
    SUM(cthd.so_luong) AS SoLuongBan,
    SUM(cthd.so_luong * cthd.gia_xuat) AS DoanhThu
FROM 
    HangHoa hh
JOIN 
    ChiTietHoaDon cthd ON hh.id = cthd.id_hang_hoa
JOIN 
    HoaDon hd ON cthd.id_hoa_don = hd.id_hoa_don
WHERE 
    hd.loai_hoa_don = 'Xuat'
    AND hd.ngay_tao_don BETWEEN @TuNgay AND @DenNgay
    " + loaiHangDieuKien + @"
GROUP BY 
    hh.loai
ORDER BY 
    DoanhThu DESC";

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbHelper.DatabasePath))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            ulong tongDoanhThu = 0;
                            Dictionary<string, ulong> doanhThuTheoLoai = new Dictionary<string, ulong>();
                            Dictionary<string, int> soLuongTheoLoai = new Dictionary<string, int>();

                            while (reader.Read())
                            {
                                string loaiHang = reader["LoaiHang"].ToString();
                                int soLuongBan = Convert.ToInt32(reader["SoLuongBan"]);
                                ulong doanhThu = Convert.ToUInt64(reader["DoanhThu"]);

                                doanhThuTheoLoai[loaiHang] = doanhThu;
                                soLuongTheoLoai[loaiHang] = soLuongBan;
                                tongDoanhThu += doanhThu;
                            }

                            // Hiển thị kết quả
                            foreach (var item in doanhThuTheoLoai)
                            {
                                string loaiHang = item.Key;
                                ulong doanhThu = item.Value;
                                int soLuong = soLuongTheoLoai[loaiHang];

                                double tyLe = tongDoanhThu > 0 ? (double)doanhThu / tongDoanhThu * 100 : 0;

                                dgvBaoCaoCH.Rows.Add(
                                    loaiHang,
                                    soLuong.ToString("N0"),
                                    doanhThu.ToString("N0") + " VNĐ",
                                    tyLe.ToString("F2") + "%"
                                );
                            }

                            // Thêm dòng tổng cộng
                            int tongSoLuong = soLuongTheoLoai.Values.Sum();
                            dgvBaoCaoCH.Rows.Add(
                                "TỔNG CỘNG",
                                tongSoLuong.ToString("N0"),
                                tongDoanhThu.ToString("N0") + " VNĐ",
                                "100%"
                            );
                            dgvBaoCaoCH.Rows[dgvBaoCaoCH.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvBaoCaoCH.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo hàng hóa: " + ex.Message);
            }
        }
    }
}
