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
                dgvBaoCaoNV.Columns.Add("TongTienNhap", "Tổng tiền nhập hàng"); // Thêm cột mới

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

                // Sử dụng truy vấn SQLite
                string query = @"
        SELECT 
            nv.id_nv AS MaNV, 
            nv.ten_nv AS TenNV,
            (SELECT COUNT(*) FROM HoaDon hd1 WHERE hd1.id_nv = nv.id_nv AND hd1.loai_hoa_don = 'Nhap' 
             AND hd1.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS SoHDNhap,
            (SELECT COUNT(*) FROM HoaDon hd2 WHERE hd2.id_nv = nv.id_nv AND hd2.loai_hoa_don = 'Xuat' 
             AND hd2.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS SoHDXuat,
            (SELECT IFNULL(SUM(hd3.tong_tien), 0) FROM HoaDon hd3 WHERE hd3.id_nv = nv.id_nv AND hd3.loai_hoa_don = 'Xuat' 
             AND hd3.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS DoanhThuXuat,
            (SELECT IFNULL(SUM(hd4.tong_tien), 0) FROM HoaDon hd4 WHERE hd4.id_nv = nv.id_nv AND hd4.loai_hoa_don = 'Nhap' 
             AND hd4.ngay_tao_don BETWEEN @TuNgay AND @DenNgay) AS TienNhapHang
        FROM 
            NhanVien nv
        ORDER BY 
            DoanhThuXuat DESC";

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbHelper.DatabasePath))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            int tongHDNhap = 0;
                            int tongHDXuat = 0;
                            ulong tongDoanhThuXuat = 0;
                            ulong tongTienNhapHang = 0;

                            while (reader.Read())
                            {
                                string maNV = reader["MaNV"].ToString();
                                string tenNV = reader["TenNV"].ToString();
                                int soHDNhap = Convert.ToInt32(reader["SoHDNhap"]);
                                int soHDXuat = Convert.ToInt32(reader["SoHDXuat"]);
                                ulong doanhThuXuat = Convert.ToUInt64(reader["DoanhThuXuat"]);
                                ulong tienNhapHang = Convert.ToUInt64(reader["TienNhapHang"]);

                                // Cập nhật tổng
                                tongHDNhap += soHDNhap;
                                tongHDXuat += soHDXuat;
                                tongDoanhThuXuat += doanhThuXuat;
                                tongTienNhapHang += tienNhapHang;

                                // Thêm vào DataGridView
                                dgvBaoCaoNV.Rows.Add(
    maNV,
    tenNV,
    soHDNhap,
    soHDXuat,
    doanhThuXuat.ToString("N0") + " VNĐ",
    tienNhapHang.ToString("N0") + " VNĐ"
);
                            }

                            // Thêm dòng tổng cộng
                            dgvBaoCaoNV.Rows.Add(
     "",
     "TỔNG CỘNG",
     tongHDNhap,
     tongHDXuat,
     tongDoanhThuXuat.ToString("N0") + " VNĐ",
     tongTienNhapHang.ToString("N0") + " VNĐ");

                            if (dgvBaoCaoNV.Rows.Count > 0)
                            {
                                dgvBaoCaoNV.Rows[dgvBaoCaoNV.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvBaoCaoNV.Font, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo nhân viên: " + ex.Message + "\n" + ex.StackTrace);
            }
        }


                
        }
    }

