using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;

namespace DoAnCK
{
    public partial class FormQuanLyAdmin : Form
    {
        private readonly QuanLyService service = new QuanLyService();
        private readonly NhanVien currentNhanVien;

        public FormQuanLyAdmin(NhanVien nhanVien)
        {
            InitializeComponent();
            currentNhanVien = nhanVien;

            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                DanhSachNhanVien_dgv.Rows.Clear();
                var danhSach = service.LayDanhSachNhanVien(currentNhanVien.IdNv);
                foreach (var nv in danhSach)
                {
                    DanhSachNhanVien_dgv.Rows.Add(
                        nv.IdNv,
                        nv.TenNv,
                        nv.Username,
                        nv.Quyen
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapQuyen_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (DanhSachNhanVien_dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần cấp/hủy quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string idNv = DanhSachNhanVien_dgv.SelectedRows[0].Cells[0].Value.ToString();
                bool success = service.CapNhatQuyen(idNv, currentNhanVien);

                if (success)
                {
                    string tenNv = DanhSachNhanVien_dgv.SelectedRows[0].Cells[1].Value.ToString();
                    bool isAdmin = DanhSachNhanVien_dgv.SelectedRows[0].Cells[3].Value.ToString() == "Nhân viên";
                    MessageBox.Show($"Đã {(isAdmin ? "cấp" : "hủy")} quyền Admin cho nhân viên {tenNv}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            CapQuyen_bt_Click(sender, e); // Gọi cùng logic
        }

        private void XoaNV_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (DanhSachNhanVien_dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string idNv = DanhSachNhanVien_dgv.SelectedRows[0].Cells[0].Value.ToString();
                string tenNv = DanhSachNhanVien_dgv.SelectedRows[0].Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhân viên {tenNv}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool success = service.XoaNhanVien(idNv, currentNhanVien);
                    if (success)
                    {
                        MessageBox.Show($"Đã xóa nhân viên {tenNv}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaNV_bt_Click(sender, e); // Gọi cùng logic
        }

        private void XemThongTinNV_bt_Click(object sender, EventArgs e)
        {
            try
            {
                FormThongTinNhanVien form = new FormThongTinNhanVien();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            XemThongTinNV_bt_Click(sender, e); // Gọi cùng logic
        }

        private void XemLog_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentNhanVien != null && currentNhanVien.IsAdmin)
                {
                    FormXemLog formXemLog = new FormXemLog();
                    formXemLog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập tính năng này!",
                        "Quyền truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form xem log: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemLog_Click(object sender, EventArgs e)
        {
            XemLog_bt_Click(sender, e); // Gọi cùng logic
        }
    }
}