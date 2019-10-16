using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChefBrowerDemo01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());

            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("--disable-web-security", "1");//关闭同源策略,允许跨域
            settings.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            Cef.Initialize(settings);
        }
    }
}
