﻿using System;
using System.IO;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;
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
