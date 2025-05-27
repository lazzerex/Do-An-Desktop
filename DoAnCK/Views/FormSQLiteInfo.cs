using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK
{
    public partial class FormSQLiteInfo : Form
    {
        private SQLiteHelper dbHelper;

        public FormSQLiteInfo(string dbFilePath)
        {
            InitializeComponent();
            dbHelper = new SQLiteHelper(dbFilePath);
        }
        private KhoHang kho = KhoHang.Instance;
        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            kho.CurrentNhanVien = nhanVien;
        }

        private void FormSQLiteInfo_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối
            bool connected = dbHelper.TestConnection();
            lblConnectionStatus.Text = connected ? "Đã kết nối thành công" : "Kết nối thất bại";
            lblConnectionStatus.ForeColor = connected ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            if (connected)
            {
                // Hiển thị danh sách các bảng
                List<string> tableNames = dbHelper.GetTableNames();
                cboTables.Items.Clear();
                foreach (string tableName in tableNames)
                {
                    cboTables.Items.Add(tableName);
                }

                if (cboTables.Items.Count > 0)
                {
                    cboTables.SelectedIndex = 0;
                }
            }
        }

        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTables.SelectedItem != null)
            {
                string selectedTable = cboTables.SelectedItem.ToString();

                // Hiển thị cấu trúc bảng
                DataTable structure = dbHelper.GetTableStructure(selectedTable);
                dgvStructure.DataSource = structure;

                // Đếm số bản ghi
                int recordCount = dbHelper.CountRecords(selectedTable);
                lblRecordCount.Text = $"Số lượng bản ghi: {recordCount}";

                // Hiển thị nội dung bảng
                string query = $"SELECT * FROM {selectedTable} LIMIT 100";
                DataTable content = dbHelper.ExecuteQuery(query);
                dgvContent.DataSource = content;
            }
        }

        // Add this method to the FormSQLiteInfo class
        private void dgvContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add your event handling logic here
            MessageBox.Show($"Cell clicked at Row: {e.RowIndex}, Column: {e.ColumnIndex}");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormSQLiteInfo_Load(sender, e);
        }
    }
}
