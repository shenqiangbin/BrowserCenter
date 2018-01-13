using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace ChefBrowerDemo01
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();

            InitBrowser();
        }

        private void InitBrowser()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser("http://www.baidu.com");

            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | AnchorStyles.Top)));
            this.browser.Location = new System.Drawing.Point(3, 30);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "webBrowser1";
            this.browser.Size = new System.Drawing.Size(832, 563);
            this.browser.TabIndex = 0;

            this.Controls.Add(this.browser);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = this.textBox1.Text;
            this.browser.Load(url);
        }
    }
}
