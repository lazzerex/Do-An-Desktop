using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormNhaCungCap : System.Windows.Forms.Form
    {
        private KhoHang kho = new KhoHang();
        private int index;

        public FormNhaCungCap()
        {
            InitializeComponent();

            kho.LoadData();
            ResetTextBoxes();
        }

        private NhaCungCap ncc;
        private void SetNCCInfo(NhaCungCap ncc)
        {
            this.ncc = ncc;
        }

        private void ResetTextBoxes()
        {
            IdNhaCungCap_tb.Clear();
            TenNhaCungCap_tb.Clear();
            SdtNhaCungCap_tb.Clear();
            DiaChi_tb.Clear();
        }
        private void ToggleTextBoxState(bool enabled)
        {
            IdNhaCungCap_tb.Enabled = enabled;
            TenNhaCungCap_tb.Enabled = enabled;
            SdtNhaCungCap_tb.Enabled = enabled;
            DiaChi_tb.Enabled = enabled;
        }

        private bool isAddingMode = false;

        #region Event
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (NhaCungCap ncc in kho.ds_ncc)
                {
                    DanhSachNhaCungCap_dgv.Rows.Add(ncc.IdNcc, ncc.TenNcc, ncc.SdtNcc, ncc.DiaChiNcc);
                }

                DanhSachNhaCungCap_dgv.Enabled = DanhSachNhaCungCap_dgv.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Xoa_bt_Click(object sender, EventArgs e)
        {
            try
            {
                index = DanhSachNhaCungCap_dgv.CurrentCell.RowIndex;
                kho.ds_ncc.RemoveAt(index);
                DanhSachNhaCungCap_dgv.Rows.RemoveAt(index);
                kho.LuuDanhSachNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Them_bt_Click(object sender, EventArgs e)
        {
            isAddingMode = true;
            ResetTextBoxes();
            ToggleTextBoxState(true);
        }

        private void CapNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (index < 0 || index >= kho.ds_ncc.Count)
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để cập nhật!", "Thông báo");
                    return;
                }

                DataGridViewRow selectedRow = DanhSachNhaCungCap_dgv.Rows[index];
                selectedRow.Cells[0].Value = IdNhaCungCap_tb.Text;
                selectedRow.Cells[1].Value = TenNhaCungCap_tb.Text;
                selectedRow.Cells[2].Value = SdtNhaCungCap_tb.Text;
                selectedRow.Cells[3].Value = DiaChi_tb.Text;

                NhaCungCap nccToUpdate = kho.ds_ncc[index];
                nccToUpdate.IdNcc = IdNhaCungCap_tb.Text;
                nccToUpdate.TenNcc = TenNhaCungCap_tb.Text;
                nccToUpdate.SdtNcc = SdtNhaCungCap_tb.Text;
                nccToUpdate.DiaChiNcc = DiaChi_tb.Text;

                DanhSachNhaCungCap_dgv.Refresh();
                kho.LuuDanhSachNCC();

                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                ResetTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Luu_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingMode)
                {
                    string id = IdNhaCungCap_tb.Text;
                    string ten = TenNhaCungCap_tb.Text;
                    string sdt = SdtNhaCungCap_tb.Text;
                    string diaChi = DiaChi_tb.Text;

                    NhaCungCap ncc = new NhaCungCap(id, ten, sdt, diaChi);
                    kho.ds_ncc.Add(ncc);
                    DanhSachNhaCungCap_dgv.Rows.Add(id, ten, sdt, diaChi);

                    kho.LuuDanhSachNCC();
                    MessageBox.Show("Đã lưu thành công!", "Thông báo");

                    isAddingMode = false;
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Hãy nhấn nút Thêm trước khi lưu!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Huy_bt_Click(object sender, EventArgs e)
        {
            isAddingMode = false;
            ResetTextBoxes();
        }

        private void DanhSachNhaCungCap_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            index = e.RowIndex;
            DataGridViewRow row = DanhSachNhaCungCap_dgv.Rows[index];

            if (row != null && row.Cells.Count >= 4)
            {
                IdNhaCungCap_tb.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                TenNhaCungCap_tb.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                SdtNhaCungCap_tb.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                DiaChi_tb.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
            }
        }
        #endregion
    }
}
