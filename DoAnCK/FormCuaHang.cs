using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormCuaHang : System.Windows.Forms.Form
    {
        private KhoHang kho = new KhoHang();
        private int index;
        private CuaHang ch;
        private bool isAddingMode = false;

        public FormCuaHang()
        {
            InitializeComponent();
            kho.LoadData();

            ResetTextBoxes();
        }

        private void SetNCCInfo(CuaHang ch)
        {
            this.ch = ch;
        }

        private void ResetTextBoxes()
        {
            IdCuaHang_tb.Clear();
            TenCuaHang_tb.Clear();
            SdtCuaHang_tb.Clear();
            DiaChi_tb.Clear();
        }
        private void ToggleTextBoxState(bool enabled)
        {
            IdCuaHang_tb.Enabled = enabled;
            TenCuaHang_tb.Enabled = enabled;
            SdtCuaHang_tb.Enabled = enabled;
            DiaChi_tb.Enabled = enabled;
        }

        #region Event
        private void btnthem_Click(object sender, EventArgs e)
        {
            isAddingMode = true;
            ResetTextBoxes();
            ToggleTextBoxState(true);
        }

        private void XoaCuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                index = DanhSachCuaHang_dgv.CurrentCell.RowIndex;
                kho.ds_cua_hang.RemoveAt(index);
                DanhSachCuaHang_dgv.Rows.RemoveAt(index);
                kho.LuuDanhSachCH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhap_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (index < 0 || index >= kho.ds_ncc.Count)
                {
                    MessageBox.Show("Vui lòng chọn một cửa hàng để cập nhật!", "Thông báo");
                    return;
                }

                DataGridViewRow selectedRow = DanhSachCuaHang_dgv.Rows[index];
                selectedRow.Cells[0].Value = IdCuaHang_tb.Text;
                selectedRow.Cells[1].Value = TenCuaHang_tb.Text;
                selectedRow.Cells[2].Value = SdtCuaHang_tb.Text;
                selectedRow.Cells[3].Value = DiaChi_tb.Text;

                CuaHang chToUpdate = kho.ds_cua_hang[index];
                chToUpdate.IdCh = IdCuaHang_tb.Text;
                chToUpdate.TenCh = TenCuaHang_tb.Text;
                chToUpdate.SdtCh = SdtCuaHang_tb.Text;
                chToUpdate.DiaChiCh = DiaChi_tb.Text;

                DanhSachCuaHang_dgv.Refresh();
                kho.LuuDanhSachCH();

                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                ResetTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LuuCuaHang_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingMode)
                {
                    string id = IdCuaHang_tb.Text;
                    string ten = TenCuaHang_tb.Text;
                    string sdt = SdtCuaHang_tb.Text;
                    string diaChi = DiaChi_tb.Text;

                    CuaHang ch = new CuaHang(id, ten, sdt, diaChi);
                    kho.ds_cua_hang.Add(ch);
                    DanhSachCuaHang_dgv.Rows.Add(id, ten, sdt, diaChi);

                    kho.LuuDanhSachCH();

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

        private void DanhSachCuaHang_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            index = e.RowIndex;
            DataGridViewRow row = DanhSachCuaHang_dgv.Rows[index];

            if (row != null && row.Cells.Count >= 4)
            {
                IdCuaHang_tb.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                TenCuaHang_tb.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                SdtCuaHang_tb.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                DiaChi_tb.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
            }
        }

        private void DanhSachCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            index = e.RowIndex;
            DataGridViewRow row = DanhSachCuaHang_dgv.Rows[index];

            if (row != null && row.Cells.Count >= 4)
            {
                IdCuaHang_tb.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                TenCuaHang_tb.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                SdtCuaHang_tb.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                DiaChi_tb.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
            }
        }

        private void FormCuaHang_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (CuaHang ch in kho.ds_cua_hang)
                {
                    DanhSachCuaHang_dgv.Rows.Add(ch.IdCh, ch.TenCh, ch.SdtCh, ch.DiaChiCh);
                }

                DanhSachCuaHang_dgv.Enabled = DanhSachCuaHang_dgv.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
