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
using System.IO;

namespace gameReg
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browser;
        private Timer timer;
        private Random randomer;
        private int CountNum = 0;
        private string startPage = System.Configuration.ConfigurationManager.AppSettings["startPage"];

        public Form1()
        {
            InitializeComponent();

            InitBrowser();
            InitTimer();

            DbStore.Init();
        }

        private void InitBrowser()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("ppapi-flash-path", @"C:\Program Files (x86)\Google\Chrome\Application-\47.0.2526.106\PepperFlash\pepflashplayer.dll"); //Load a specific pepper flash version (Step 1 of 2)
            //路径写错，故意让Flash不可用            
            settings.CefCommandLineArgs.Add("ppapi-flash-version", "20.0.0.228"); //Load a specific pepper flash version (Step 2 of 2)
            //settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            //settings.CefCommandLineArgs.Add("proxy-server", "http://211.159.247.232:80");
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser(startPage);

            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | AnchorStyles.Top)));
            this.browser.Location = new System.Drawing.Point(3, 30);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "webBrowser1";
            this.browser.Size = new System.Drawing.Size(832, 563);
            this.browser.TabIndex = 0;

            this.Controls.Add(this.browser);

            this.browser.FrameLoadEnd += Browser_FrameLoadEnd;
            this.browser.LoadingStateChanged += Browser_LoadingStateChanged;
            this.browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            //this.browser.LifeSpanHandler = new MyLifeSpanHandler();
        }

        private void InitTimer()
        {
            this.timer = new Timer();
            this.randomer = new Random();
            timer.Interval = randomer.Next(15, 25);
            timer.Tick += Timer_Tick;
            this.timer.Start();
            CloseOtherWin();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ClearCookie();
            timer.Stop();
            this.browser.Load(startPage);
            ShowMsg("load page");
            timer.Interval = randomer.Next(15, 25) * 1000;
            timer.Start();
        }

        //清除cookie
        private void ClearCookie()
        {
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.DeleteCookiesAsync("", "");
        }

        //关闭其他窗体
        private void CloseOtherWin()
        {
            foreach (Form win in Application.OpenForms)
            {
                if (win != this)
                {
                    win.Close();
                }
            }
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //if (e.IsLoading == false)
            //{
            //    browser.ExecuteScriptAsync("alert('All Resources Have Loaded');");
            //}
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            try
            {
                if (!string.Equals(e.Url, startPage, StringComparison.OrdinalIgnoreCase))
                    return;

                if (e.Frame.IsMain)
                {
                    string str2 = Guid.NewGuid().ToString().Substring(0, 2);
                    string str3 = Guid.NewGuid().ToString().Substring(0, 2);

                    string username = str2 + randomer.Next(99999 + 1, 999999999);
                    string pwd = str3 + randomer.Next(99999 + 1, 999999999).ToString();
                    //由于页面判断没能使用Flash，需间隔一下，才展示元素，因此这里也需要延时2秒钟。
                    string str = @"
                    setTimeout(function() {                        
                       document.getElementById('main').click();
                       $('#login_account').val('@username');
                       $('#password').val('@pwd');
                       $('#password1').val('@pwd');
                       setTimeout(function() {  $('#submitbtn').click(); }, 1000);
                    }, 2000);
                ".Replace("@username", username)
                    .Replace("@pwd", pwd);

                    CountNum++;
                    ShowMsg($"[{CountNum}] registering:{username},{pwd}");
                    DbStore.Store($"{username},{pwd}");
                    e.Frame.ExecuteJavaScriptAsync(str);
                }
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //string url = this.textBox1.Text;
            //this.browser.Load(url);            
        }

        private void btnShowDev_Click(object sender, EventArgs e)
        {
            this.browser.ShowDevTools();
        }

        private void ShowMsg(string msg)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>((m) =>
                {
                    if (this.richTextBox1.Text.Length > 2000)
                        this.richTextBox1.Text = "";
                    this.richTextBox1.Text = $"【{DateTime.Now.ToLocalTime()}】:{msg}\r\n{this.richTextBox1.Text}";

                }), "");
            }
            else
            {
                if (this.richTextBox1.Text.Length > 2000)
                    this.richTextBox1.Text = "";
                this.richTextBox1.Text = $"【{DateTime.Now.ToLocalTime()}】:{msg}\r\n{this.richTextBox1.Text}";
            }

        }
    }
}
