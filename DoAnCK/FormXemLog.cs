using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace DoAnCK
{
    public partial class FormXemLog : Form
    {
        private SQLiteHelper dbHelper;
        private KhoHang kho = new KhoHang();

        public FormXemLog()
        {
            InitializeComponent();

            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
                dbHelper = new SQLiteHelper(dbPath);
                kho.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormXemLog_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNhanVienComboBox();
                LoadLoaiHoatDongComboBox();
                FormatDataGridView();

                // Thiết lập giá trị mặc định cho DateTimePicker nếu có
                if (dateTimePickerTu != null)
                    dateTimePickerTu.Value = DateTime.Now.AddMonths(-1);
                if (dateTimePickerDen != null)
                    dateTimePickerDen.Value = DateTime.Now;

                // Tải dữ liệu log ban đầu
                LoadLogData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVienComboBox()
        {
            if (comboBoxNhanVien == null)
                return;

            comboBoxNhanVien.Items.Clear();
            comboBoxNhanVien.Items.Add("Tất cả nhân viên");

            foreach (NhanVien nv in kho.ds_nhan_vien)
            {
                comboBoxNhanVien.Items.Add(nv);
            }

            comboBoxNhanVien.DisplayMember = "TenNv";
            comboBoxNhanVien.ValueMember = "IdNv";
            comboBoxNhanVien.SelectedIndex = 0;
        }

        private void LoadLoaiHoatDongComboBox()
        {
            comboBoxLoaiHoatDong.Items.Clear();
            comboBoxLoaiHoatDong.Items.Add("Tất cả hoạt động");

            List<string> activityTypes = dbHelper.GetActivityTypes();
            foreach (string activityType in activityTypes)
            {
                comboBoxLoaiHoatDong.Items.Add(activityType);
            }

            comboBoxLoaiHoatDong.SelectedIndex = 0;
        }

        private void FormatDataGridView()
        {
            dataGridViewLog.AutoGenerateColumns = false;
            dataGridViewLog.Columns.Clear();

            // Thêm cột thời gian
            DataGridViewTextBoxColumn colTime = new DataGridViewTextBoxColumn();
            colTime.HeaderText = "Thời gian";
            colTime.DataPropertyName = "timestamp";
            colTime.Width = 150;
            dataGridViewLog.Columns.Add(colTime);

            // Thêm cột tên nhân viên
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Nhân viên";
            colName.DataPropertyName = "ten_nv";
            colName.Width = 150;
            dataGridViewLog.Columns.Add(colName);

            // Thêm cột loại hoạt động
            DataGridViewTextBoxColumn colActivity = new DataGridViewTextBoxColumn();
            colActivity.HeaderText = "Loại hoạt động";
            colActivity.DataPropertyName = "activity_type";
            colActivity.Width = 120;
            dataGridViewLog.Columns.Add(colActivity);

            // Thêm cột mô tả
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.HeaderText = "Mô tả";
            colDesc.DataPropertyName = "description";
            colDesc.Width = 200;
            dataGridViewLog.Columns.Add(colDesc);

            // Thêm cột chi tiết
            DataGridViewTextBoxColumn colDetails = new DataGridViewTextBoxColumn();
            colDetails.HeaderText = "Chi tiết";
            colDetails.DataPropertyName = "details";
            colDetails.Width = 250;
            dataGridViewLog.Columns.Add(colDetails);
        }

        private void LoadLogData()
        {
            string selectedNhanVienId = "all";
            if (comboBoxNhanVien.SelectedIndex > 0 && comboBoxNhanVien.SelectedItem is NhanVien selectedNV)
            {
                selectedNhanVienId = selectedNV.IdNv;
            }

            string selectedActivityType = "all";
            if (comboBoxLoaiHoatDong.SelectedIndex > 0)
            {
                selectedActivityType = comboBoxLoaiHoatDong.SelectedItem.ToString();
            }

            DateTime fromDate = dateTimePickerTu.Value.Date;
            DateTime toDate = dateTimePickerDen.Value.Date;

            DataTable logs = dbHelper.GetLogsByFilter(
                selectedNhanVienId,
                selectedActivityType,
                fromDate,
                toDate
            );

            dataGridViewLog.DataSource = logs;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadLogData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            comboBoxNhanVien.SelectedIndex = 0;
            comboBoxLoaiHoatDong.SelectedIndex = 0;
            dateTimePickerTu.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerDen.Value = DateTime.Now;
            LoadLogData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files|*.csv";
            saveDialog.Title = "Lưu file log";
            saveDialog.FileName = "Log_Hoat_Dong_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName, false, System.Text.Encoding.Unicode))
                    {
                        // Viết tiêu đề cột
                        List<string> headerRow = new List<string>();
                        foreach (DataGridViewColumn col in dataGridViewLog.Columns)
                        {
                            headerRow.Add(col.HeaderText);
                        }
                        sw.WriteLine(string.Join(",", headerRow));

                        // Viết dữ liệu
                        foreach (DataGridViewRow row in dataGridViewLog.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                List<string> dataRow = new List<string>();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        // Đảm bảo dữ liệu không chứa dấu phẩy hoặc được bao quanh bằng dấu ngoặc kép
                                        string value = cell.Value.ToString();
                                        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                                        {
                                            value = "\"" + value.Replace("\"", "\"\"") + "\"";
                                        }
                                        dataRow.Add(value);
                                    }
                                    else
                                    {
                                        dataRow.Add("");
                                    }
                                }
                                sw.WriteLine(string.Join(",", dataRow));
                            }
                        }
                    }

                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file vừa xuất
                    Process.Start(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}