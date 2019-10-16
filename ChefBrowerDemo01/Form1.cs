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
using System.Configuration;

namespace ChefBrowerDemo01
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browser;
        public int BWidth { get; set; }
        public int BHeight { get; set; }
        public int BX { get; set; }
        public int BY { get; set; }

        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }

        public Form1(int width,int height,int x,int y)
        {

            InitializeComponent();
            this.BWidth = width;
            this.BHeight = height;
            this.BX = x;
            this.BY = y;

            InitBrowser();
        }

        private void InitBrowser()
        {
            //854 635
            //MessageBox.Show(this.Size.ToString());            
            //this.Size = new System.Drawing.Size(this.BWidth, this.BHeight);
            this.ClientSize = new System.Drawing.Size(this.BWidth+16, this.BHeight+16);
            //this.MaximumSize = new System.Drawing.Size(this.BWidth+16, this.BHeight+16);
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            //Rectangle area = Screen.FromHandle(this.Handle).WorkingArea;
            //area.X = 0;
            //this.MaximizedBounds = area;
            //this.MaximumSize = area.Size;
            //this.Size = area.Size;

           

            String url = "http://10.170.128.54:8162/";
            //url = "http://10.170.128.54:8161/boat?modelid=488846";
            //url = "http://www.sqber.com";
            url = "http://10.170.128.54:8161/boat?modelid=489015";
            //url = "http://10.170.128.54:8161/boat?modelid=488846";
            url = ConfigurationManager.AppSettings["website"].ToString();
            browser = new ChromiumWebBrowser(url);
 

            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | AnchorStyles.Top)));
            this.browser.Location = new System.Drawing.Point(0, 0);
            //this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            //this.browser.Size = new System.Drawing.Size( this.BWidth * 200 / 1282 ,this.BHeight * 300 / 762);
            //this.browser.Top = 0;
            //this.browser.Left = 0;
            this.browser.Name = "webBrowser1";
            this.browser.Dock = DockStyle.Fill;
            this.browser.TabIndex = 0;

            this.Controls.Add(this.browser);
            this.browser.Refresh();

            this.browser.KeyboardHandler = new CEFKeyBoardHander();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //string url = this.textBox1.Text;
            //this.browser.Load(url);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = this.BX;
            this.Top = this.BY;
          
        }
    }
}
