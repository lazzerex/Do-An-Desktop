using System;
using System.IO;
using System.Windows.Forms;

namespace DoAnCK
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Kiểm tra xem người dùng có muốn kiểm tra SQLite không
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            if (File.Exists(dbPath))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn kiểm tra kết nối SQLite không?",
                    "Kiểm tra SQLite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Run(new FormSQLiteInfo(dbPath));
                    return;
                }
            }

            try
            {
                Application.Run(new FormGiaoDienChinh());
            }
            catch (ObjectDisposedException)
            {
                return;
            }

        }
    }
}