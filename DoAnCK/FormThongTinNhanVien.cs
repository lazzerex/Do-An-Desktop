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
    public partial class FormThongTinNhanVien : Form
    {
        private KhoHang kho = new KhoHang();

        public FormThongTinNhanVien()
        {
            InitializeComponent();
            kho.LoadData();
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            dataGridViewNhanVien.Rows.Clear();
            foreach (NhanVien nv in kho.ds_nhan_vien)
            {
                dataGridViewNhanVien.Rows.Add(
                    nv.IdNv,
                    nv.TenNv,
                    nv.Tuoi,
                    nv.GioiTinh ? "Nam" : "Nữ",
                    nv.DiaChiNv,
                    nv.Username,
                    nv.IsAdmin ? "Admin" : "Nhân viên"
                );
            }
        }
    }
}
