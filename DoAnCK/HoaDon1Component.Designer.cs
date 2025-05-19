namespace DoAnCK
{
    partial class HoaDon1Component
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
            this.tt_bhdx = new System.Windows.Forms.Label();
            this.sl_bhdx = new System.Windows.Forms.Label();
            this.sp_bhdx = new System.Windows.Forms.Label();
            this.id_bhdx = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tt_bhdx
            // 
            this.tt_bhdx.AutoSize = true;
            this.tt_bhdx.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tt_bhdx.Location = new System.Drawing.Point(445, 7);
            this.tt_bhdx.Name = "tt_bhdx";
            this.tt_bhdx.Size = new System.Drawing.Size(93, 20);
            this.tt_bhdx.TabIndex = 32;
            this.tt_bhdx.Text = "Thành tiền";
            // 
            // sl_bhdx
            // 
            this.sl_bhdx.AutoSize = true;
            this.sl_bhdx.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.sl_bhdx.Location = new System.Drawing.Point(308, 7);
            this.sl_bhdx.Name = "sl_bhdx";
            this.sl_bhdx.Size = new System.Drawing.Size(80, 20);
            this.sl_bhdx.TabIndex = 31;
            this.sl_bhdx.Text = "Số lượng";
            // 
            // sp_bhdx
            // 
            this.sp_bhdx.AutoSize = true;
            this.sp_bhdx.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.sp_bhdx.Location = new System.Drawing.Point(116, 7);
            this.sp_bhdx.Name = "sp_bhdx";
            this.sp_bhdx.Size = new System.Drawing.Size(117, 20);
            this.sp_bhdx.TabIndex = 30;
            this.sp_bhdx.Text = "Tên sản phẩm";
            // 
            // id_bhdx
            // 
            this.id_bhdx.AutoSize = true;
            this.id_bhdx.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.id_bhdx.Location = new System.Drawing.Point(34, 7);
            this.id_bhdx.Name = "id_bhdx";
            this.id_bhdx.Size = new System.Drawing.Size(27, 20);
            this.id_bhdx.TabIndex = 29;
            this.id_bhdx.Text = "ID";
            // 
            // HangHoaBillComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tt_bhdx);
            this.Controls.Add(this.sl_bhdx);
            this.Controls.Add(this.sp_bhdx);
            this.Controls.Add(this.id_bhdx);
            this.Name = "HangHoaBillComponent";
            this.Size = new System.Drawing.Size(573, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tt_bhdx;
        private System.Windows.Forms.Label sl_bhdx;
        private System.Windows.Forms.Label sp_bhdx;
        private System.Windows.Forms.Label id_bhdx;
    }
}
