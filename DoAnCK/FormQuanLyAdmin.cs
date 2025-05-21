using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormQuanLyAdmin : Form
    {
        private KhoHang kho = new KhoHang();
        private NhanVien currentNhanVien;

        public FormQuanLyAdmin(NhanVien nhanVien)
        {
            InitializeComponent();
            currentNhanVien = nhanVien; 
            kho.LoadData();
            LoadDanhSachNhanVien();
        }

        
        private void LoadDanhSachNhanVien()
        {
            dataGridViewNhanVien.Rows.Clear();
            foreach (NhanVien nv in kho.ds_nhan_vien)
            {
                // Không hiển thị nhân viên hiện tại
                if (nv.IdNv != currentNhanVien.IdNv)
                {
                    dataGridViewNhanVien.Rows.Add(
                        nv.IdNv,
                        nv.TenNv,
                        nv.Username,
                        nv.IsAdmin ? "Admin" : "Nhân viên"
                    );
                }
            }
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count > 0)
            {
                string idNV = dataGridViewNhanVien.SelectedRows[0].Cells[0].Value.ToString();
                NhanVien nv = kho.ds_nhan_vien.Find(x => x.IdNv == idNV);

                if (nv != null)
                {
                    nv.IsAdmin = !nv.IsAdmin;
                    kho.LuuDanhSachNV();

                    // Ghi log hoạt động
                    try
                    {
                        Logger.LogCapNhatQuyen(currentNhanVien, nv, nv.IsAdmin);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi ghi log: " + ex.Message);
                    }

                    LoadDanhSachNhanVien();
                    MessageBox.Show($"Đã {(nv.IsAdmin ? "cấp" : "hủy")} quyền Admin cho nhân viên {nv.TenNv}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cấp/hủy quyền");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count > 0)
            {
                string idNV = dataGridViewNhanVien.SelectedRows[0].Cells[0].Value.ToString();
                NhanVien nv = kho.ds_nhan_vien.Find(x => x.IdNv == idNV);

                if (nv != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa nhân viên {nv.TenNv}?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        kho.ds_nhan_vien.Remove(nv);
                        kho.LuuDanhSachNV();
                        LoadDanhSachNhanVien();
                        MessageBox.Show($"Đã xóa nhân viên {nv.TenNv}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
            }
        }

        //private void btnXemLog_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Tính năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            FormThongTinNhanVien form = new FormThongTinNhanVien();
            form.ShowDialog();
        }
        private void btnXemLog_Click(object sender, EventArgs e)
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





    }
}
