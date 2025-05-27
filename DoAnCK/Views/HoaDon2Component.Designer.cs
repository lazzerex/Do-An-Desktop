namespace DoAnCK
{
    partial class HoaDon2Component
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label22 = new System.Windows.Forms.Label();
            this.thanhtien_endbill = new System.Windows.Forms.Label();
            this.soluong_endbill = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label22.Location = new System.Drawing.Point(2, 4);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label22.Size = new System.Drawing.Size(460, 15);
            this.label22.TabIndex = 25;
            this.label22.Text = "---------------------------------------------------------------------------------" +
    "--------";
            // 
            // thanhtien_endbill
            // 
            this.thanhtien_endbill.AutoSize = true;
            this.thanhtien_endbill.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.thanhtien_endbill.Location = new System.Drawing.Point(170, 60);
            this.thanhtien_endbill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.thanhtien_endbill.Name = "thanhtien_endbill";
            this.thanhtien_endbill.Size = new System.Drawing.Size(95, 19);
            this.thanhtien_endbill.TabIndex = 33;
            this.thanhtien_endbill.Text = "Thành tiền:";
            // 
            // soluong_endbill
            // 
            this.soluong_endbill.AutoSize = true;
            this.soluong_endbill.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.soluong_endbill.Location = new System.Drawing.Point(186, 30);
            this.soluong_endbill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.soluong_endbill.Name = "soluong_endbill";
            this.soluong_endbill.Size = new System.Drawing.Size(79, 19);
            this.soluong_endbill.TabIndex = 34;
            this.soluong_endbill.Text = "Số lượng:";
            // 
            // HangHoaBillComponent2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.soluong_endbill);
            this.Controls.Add(this.thanhtien_endbill);
            this.Controls.Add(this.label22);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HangHoaBillComponent2";
            this.Size = new System.Drawing.Size(430, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label thanhtien_endbill;
        public System.Windows.Forms.Label soluong_endbill;
    }
}
