using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Services;
using System.Diagnostics;

namespace DoAnCK
{
    public partial class FormXemLog : Form
    {
        private readonly QuanLyService service = new QuanLyService();
        private readonly KhoHang kho = KhoHang.Instance;

        public FormXemLog()
        {
            InitializeComponent();
        }

        public void SetCurrentNhanVien(NhanVien nhanVien)
        {
            kho.CurrentNhanVien = nhanVien;
        }

        private void FormXemLog_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNhanVienComboBox();
                LoadLoaiHoatDongComboBox();
                FormatDataGridView();

                dateTimePickerTu.Value = DateTime.Now.AddMonths(-1);
                dateTimePickerDen.Value = DateTime.Now;

                LoadLogData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVienComboBox()
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoaiHoatDongComboBox()
        {
            try
            {
                comboBoxLoaiHoatDong.Items.Clear();
                comboBoxLoaiHoatDong.Items.Add("Tất cả hoạt động");
                var activityTypes = service.LayLoaiHoatDong();
                foreach (string activityType in activityTypes)
                {
                    comboBoxLoaiHoatDong.Items.Add(activityType);
                }
                comboBoxLoaiHoatDong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại hoạt động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dataGridViewLog.AutoGenerateColumns = false;
            dataGridViewLog.Columns.Clear();

            dataGridViewLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thời gian",
                DataPropertyName = "timestamp",
                Width = 150
            });
            dataGridViewLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nhân viên",
                DataPropertyName = "ten_nv",
                Width = 150
            });
            dataGridViewLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại hoạt động",
                DataPropertyName = "activity_type",
                Width = 120
            });
            dataGridViewLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô tả",
                DataPropertyName = "description",
                Width = 200
            });
            dataGridViewLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Chi tiết",
                DataPropertyName = "details",
                Width = 250
            });
        }

        private void LoadLogData()
        {
            try
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

                DataTable logs = service.LayDanhSachLog(selectedNhanVienId, selectedActivityType, fromDate, toDate);
                dataGridViewLog.DataSource = logs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu log: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadLogData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxNhanVien.SelectedIndex = 0;
                comboBoxLoaiHoatDong.SelectedIndex = 0;
                dateTimePickerTu.Value = DateTime.Now.AddMonths(-1);
                dateTimePickerDen.Value = DateTime.Now;
                LoadLogData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLog.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.csv";
                    saveDialog.Title = "Lưu file log";
                    saveDialog.FileName = "Log_Hoat_Dong_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    if (saveDialog.ShowDialog() == DialogResult.OK)
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
                                        string value = cell.Value?.ToString() ?? "";
                                        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                                        {
                                            value = "\"" + value.Replace("\"", "\"\"") + "\"";
                                        }
                                        dataRow.Add(value);
                                    }
                                    sw.WriteLine(string.Join(",", dataRow));
                                }
                            }
                        }

                        MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}