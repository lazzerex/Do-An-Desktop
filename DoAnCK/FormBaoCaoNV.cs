using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DoAnCK
{
    public partial class FormBaoCaoNV : Form
    {
        private KhoHang kho = KhoHang.Instance;
        private SQLiteHelper dbHelper;

        public FormBaoCaoNV()
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

                // Cấu hình DataGridView
                dgvBaoCaoNV.Columns.Clear();
                dgvBaoCaoNV.Columns.Add("MaNV", "Mã NV");
                dgvBaoCaoNV.Columns.Add("TenNV", "Tên nhân viên");
                dgvBaoCaoNV.Columns.Add("SoHDNhap", "Số HD nhập");
                dgvBaoCaoNV.Columns.Add("SoHDXuat", "Số HD xuất");
                dgvBaoCaoNV.Columns.Add("TongDoanhThu", "Tổng doanh thu");

                // Thiết lập giá trị mặc định cho DateTimePicker
                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                dtpDenNgay.Value = DateTime.Now;

                // Tải dữ liệu mặc định
                TaiDuLieuBaoCaoNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBaoCaoNV_Load(object sender, EventArgs e)
        {
            // Đã được xử lý trong LoadData()
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieuBaoCaoNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieuBaoCaoNhanVien()
        {
            try
            {
                // Xóa dữ liệu cũ
                dgvBaoCaoNV.Rows.Clear();

                // Lấy ngày bắt đầu và kết thúc
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Kết thúc ngày

                // Lấy dữ liệu từ cơ sở dữ liệu
                string query = @"
                SELECT 
                    nv.id_nv, 
                    nv.ten_nv, 
                    COUNT(CASE WHEN hd.loai_hoa_don = 'Nhap' THEN hd.id_hoa_don END) AS SoHDNhap,
                    COUNT(CASE WHEN hd.loai_hoa_don = 'Xuat' THEN hd.id_hoa_don END) AS SoHDXuat,
                    SUM(CASE WHEN hd.loai_hoa_don = 'Xuat' THEN hd.tong_tien ELSE 0 END) AS TongDoanhThu
                FROM 
                    NhanVien nv
                LEFT JOIN 
                    HoaDon hd ON nv.id_nv = hd.id_nv AND hd.ngay_tao_don BETWEEN @TuNgay AND @DenNgay
                GROUP BY 
                    nv.id_nv, nv.ten_nv
                ORDER BY 
                    TongDoanhThu DESC";

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbHelper.DatabasePath))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string idNv = reader["IdNv"].ToString();
                                string tenNv = reader["TenNv"].ToString();
                                int soHDNhap = Convert.ToInt32(reader["SoHDNhap"]);
                                int soHDXuat = Convert.ToInt32(reader["SoHDXuat"]);
                                ulong tongDoanhThu = Convert.ToUInt64(reader["TongDoanhThu"]);

                                dgvBaoCaoNV.Rows.Add(idNv, tenNv, soHDNhap, soHDXuat, tongDoanhThu.ToString("N0") + " VNĐ");
                            }
                        }
                    }
                }

                // Thêm dòng tổng cộng
                int tongHDNhap = 0;
                int tongHDXuat = 0;
                ulong tongDT = 0;

                foreach (DataGridViewRow row in dgvBaoCaoNV.Rows)
                {
                    tongHDNhap += Convert.ToInt32(row.Cells["SoHDNhap"].Value);
                    tongHDXuat += Convert.ToInt32(row.Cells["SoHDXuat"].Value);

                    string dtStr = row.Cells["TongDoanhThu"].Value.ToString().Replace(" VNĐ", "").Replace(",", "");
                    if (!string.IsNullOrEmpty(dtStr))
                        tongDT += Convert.ToUInt64(dtStr);
                }

                dgvBaoCaoNV.Rows.Add("", "TỔNG CỘNG", tongHDNhap, tongHDXuat, tongDT.ToString("N0") + " VNĐ");
                dgvBaoCaoNV.Rows[dgvBaoCaoNV.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvBaoCaoNV.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo nhân viên: " + ex.Message);
            }
        }
    }
}
