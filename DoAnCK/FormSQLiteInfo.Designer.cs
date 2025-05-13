using System.Windows.Forms;
using System;

namespace DoAnCK
{
    partial class FormSQLiteInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.lblSelectTable = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblStructure = new System.Windows.Forms.Label();
            this.dgvStructure = new System.Windows.Forms.DataGridView();
            this.lblContent = new System.Windows.Forms.Label();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(12, 9);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(90, 13);
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Text = "Trạng thái kết nối";
            this.lblConnectionStatus.Click += new System.EventHandler(this.lblConnectionStatus_Click);
            // 
            // cboTables
            // 
            this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point(111, 40);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(200, 21);
            this.cboTables.TabIndex = 1;
            // 
            // lblSelectTable
            // 
            this.lblSelectTable.AutoSize = true;
            this.lblSelectTable.Location = new System.Drawing.Point(12, 43);
            this.lblSelectTable.Name = "lblSelectTable";
            this.lblSelectTable.Size = new System.Drawing.Size(62, 13);
            this.lblSelectTable.TabIndex = 2;
            this.lblSelectTable.Text = "Chọn bảng:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(12, 70);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(99, 13);
            this.lblRecordCount.TabIndex = 3;
            this.lblRecordCount.Text = "Số lượng bản ghi: 0";
            // 
            // lblStructure
            // 
            this.lblStructure.AutoSize = true;
            this.lblStructure.Location = new System.Drawing.Point(12, 90);
            this.lblStructure.Name = "lblStructure";
            this.lblStructure.Size = new System.Drawing.Size(77, 13);
            this.lblStructure.TabIndex = 4;
            this.lblStructure.Text = "Cấu trúc bảng:";
            // 
            // dgvStructure
            // 
            this.dgvStructure.AllowUserToAddRows = false;
            this.dgvStructure.AllowUserToDeleteRows = false;
            this.dgvStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStructure.Location = new System.Drawing.Point(12, 110);
            this.dgvStructure.Name = "dgvStructure";
            this.dgvStructure.ReadOnly = true;
            this.dgvStructure.Size = new System.Drawing.Size(400, 200);
            this.dgvStructure.TabIndex = 5;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(12, 330);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(80, 13);
            this.lblContent.TabIndex = 6;
            this.lblContent.Text = "Nội dung bảng:";
            // 
            // dgvContent
            // 

            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.Load += new System.EventHandler(this.FormSQLiteInfo_Load);
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(111, 330);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.Size = new System.Drawing.Size(776, 150);
            this.dgvContent.TabIndex = 7;
            this.dgvContent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContent_CellContentClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(598, 287);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // FormSQLiteInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.dgvStructure);
            this.Controls.Add(this.lblStructure);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.lblSelectTable);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.lblConnectionStatus);
            this.Name = "FormSQLiteInfo";
            this.Text = "FormSQLiteInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ComboBox cboTables;
        private System.Windows.Forms.Label lblSelectTable;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblStructure;
        private System.Windows.Forms.DataGridView dgvStructure;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.Button btnRefresh;

        // Add the following method to handle the Click event:
        private void lblConnectionStatus_Click(object sender, EventArgs e)
        {
            // Add your event handling logic here
            MessageBox.Show("Connection status label clicked!");
        }
    }
}