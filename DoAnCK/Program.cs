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

            // Khởi tạo Logger
            string dbPath = Path.Combine(Application.StartupPath, "CuaHang.db");
            Logger.Initialize(dbPath);

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
