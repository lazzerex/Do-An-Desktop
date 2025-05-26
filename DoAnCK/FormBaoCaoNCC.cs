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
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class FormBaoCaoNCC : Form
    {
        private KhoHang kho = KhoHang.Instance;
        private SQLiteHelper dbHelper;

        public FormBaoCaoNCC()
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
                TaiDuLieuBaoCaoNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBaoCaoNCC_Load(object sender, EventArgs e)
        {
            // Đã được xử lý trong LoadData()
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieuBaoCaoNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieuBaoCaoNhaCungCap()
        {
            try
            {
                // Xóa dữ liệu cũ
                dgvBaoCaoNCC.Rows.Clear();

                // Lấy ngày bắt đầu và kết thúc
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Kết thúc ngày

                // Điều kiện nhà cung cấp
                string nccDieuKien = "";
                if (cboNhaCungCap.SelectedIndex > 0 && cboNhaCungCap.SelectedItem is NhaCungCap ncc)
                {
                    nccDieuKien = $" AND hd.id_ncc = '{ncc.IdNcc}' ";
                }

                // Lấy dữ liệu từ cơ sở dữ liệu
                string query = @"
SELECT 
    ncc.id_ncc AS IdNcc,
    ncc.ten_ncc AS TenNcc,
    SUM(cthd.so_luong) AS SoLuongNhap,
    SUM(cthd.so_luong * cthd.don_gia) AS TongGiaTri
FROM 
    NhaCungCap ncc
JOIN 
    HoaDon hd ON ncc.id_ncc = hd.id_ncc
JOIN 
    ChiTietHoaDon cthd ON hd.id_hoa_don = cthd.id_hoa_don
WHERE 
    hd.loai_hoa_don = 'Nhap'
    AND hd.ngay_tao_don BETWEEN @TuNgay AND @DenNgay
    " + nccDieuKien + @"
GROUP BY 
    ncc.id_ncc, ncc.ten_ncc
ORDER BY 
    TongGiaTri DESC";

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbHelper.DatabasePath))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyy-MM-dd HH:mm:ss"));

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            ulong tongGiaTri = 0;
                            Dictionary<string, ulong> giaTriTheoNCC = new Dictionary<string, ulong>();
                            Dictionary<string, int> soLuongTheoNCC = new Dictionary<string, int>();
                            Dictionary<string, string> tenNCC = new Dictionary<string, string>();

                            while (reader.Read())
                            {
                                string idNcc = reader["IdNcc"].ToString();
                                string tenNcc = reader["TenNcc"].ToString();
                                int soLuongNhap = Convert.ToInt32(reader["SoLuongNhap"]);
                                ulong tongGiaTriNhap = Convert.ToUInt64(reader["TongGiaTri"]);

                                giaTriTheoNCC[idNcc] = tongGiaTriNhap;
                                soLuongTheoNCC[idNcc] = soLuongNhap;
                                tenNCC[idNcc] = tenNcc;
                                tongGiaTri += tongGiaTriNhap;
                            }

                            // Hiển thị kết quả
                            foreach (var item in giaTriTheoNCC)
                            {
                                string idNcc = item.Key;
                                ulong giaTri = item.Value;
                                int soLuong = soLuongTheoNCC[idNcc];
                                string ten = tenNCC[idNcc];

                                double tyLe = tongGiaTri > 0 ? (double)giaTri / tongGiaTri * 100 : 0;

                                dgvBaoCaoNCC.Rows.Add(
                                    idNcc,
                                    ten,
                                    soLuong.ToString("N0"),
                                    giaTri.ToString("N0") + " VNĐ",
                                    tyLe.ToString("F2") + "%"
                                );
                            }

                            // Thêm dòng tổng cộng
                            int tongSoLuong = soLuongTheoNCC.Values.Sum();
                            dgvBaoCaoNCC.Rows.Add(
                                "",
                                "TỔNG CỘNG",
                                tongSoLuong.ToString("N0"),
                                tongGiaTri.ToString("N0") + " VNĐ",
                                "100%"
                            );
                            dgvBaoCaoNCC.Rows[dgvBaoCaoNCC.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvBaoCaoNCC.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu báo cáo nhà cung cấp: " + ex.Message);
            }
        }
    }
}
