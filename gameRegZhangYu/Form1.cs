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

namespace gameRegZhangYu
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

            this.randomer = new Random();

            InitBrowser();
            InitTimer();
            InitReader();

            DbStore.Init();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.reader.Dispose();
        }

        private void InitBrowser()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("ppapi-flash-path", @"C:\Program Files (x86)\Google\Chrome\Application-\47.0.2526.106\PepperFlash\pepflashplayer.dll"); //Load a specific pepper flash version (Step 1 of 2)
            //路径写错，故意让Flash不可用            
            settings.CefCommandLineArgs.Add("ppapi-flash-version", "20.0.0.228"); //Load a specific pepper flash version (Step 2 of 2)
            //settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            //settings.CefCommandLineArgs.Add("proxy-server", "http://211.159.247.232:80");
            string andoridWeiXin = "Mozilla/5.0 (Linux; Android 4.4.4; HM NOTE 1LTEW Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/33.0.0.0 Mobile Safari/537.36 MicroMessenger/6.0.0.54_r849063.501 NetType/WIFI";
            string iphoneWeiXin = "Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12A365 MicroMessenger/5.4.1 NetType/WIFI";

            andoridWeiXin = "Mozilla/5.0 (Linux; Android 4.4.4; HM NOTE 1LTEW Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/33.0.0.0 Mobile Safari/537.36 NetType/WIFI";
            iphoneWeiXin = "Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12A365  NetType/WIFI";

            settings.UserAgent = randomer.Next() % 2 == 0 ? andoridWeiXin : iphoneWeiXin;
            //settings.UserAgent = andoridWeiXin;
            Cef.Initialize(settings);

            //startPage = "http://service.spiritsoft.cn/ua.html";
            //startPage = "http://tools.likai.cc/browser/";
            browser = new ChromiumWebBrowser(startPage);

            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | AnchorStyles.Top)));

            this.browser.Location = new System.Drawing.Point(209, 30);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "webBrowser1";
            this.browser.Size = new System.Drawing.Size(617, 554);

            this.browser.TabIndex = 0;

            this.Controls.Add(this.browser);

            this.browser.FrameLoadEnd += Browser_FrameLoadEnd;
            this.browser.LoadingStateChanged += Browser_LoadingStateChanged;
            this.browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            this.browser.LifeSpanHandler = new MyLifeSpanHandler();
        }

        private void InitTimer()
        {
            this.timer = new Timer();
            timer.Interval = randomer.Next(15, 25);
            timer.Tick += Timer_Tick;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ClearCookie();
            CloseOtherWin();
            timer.Stop();

            this.browser.Load(startPage);
            //ShowMsg("load page");
            timer.Interval = randomer.Next(15, 25) * 1000;
            timer.Start();
        }

        //清除cookie
        private void ClearCookie()
        {
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.DeleteCookiesAsync("", "");

            try
            {
                browser.GetFocusedFrame().ExecuteJavaScriptAsync("localStorage.clear()");
            }
            catch (Exception)
            {
                
            }
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

        private StreamReader reader = null;
        private string qq = null;
        private string qqpwd = null;

        private void InitReader()
        {
            try
            {
                reader = new StreamReader("qq.txt", Encoding.Default);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            try
            {

                //刚进来的页面
                if (string.Equals(e.Url, "https://h5weapp.zywawa.com/?ADTAG=tyhq#/", StringComparison.OrdinalIgnoreCase))
                {

                    //DbStore.Store($"{username},{pwd}");
                    CountNum++;
                    //$('div[data-cancel]').click();
                    //string js = @"

                    //    setTimeout(function() {  }, 1000);
                    //    ";                    
                    ShowMsg($"[{CountNum}] reload");
                    ExecuteJS("document.getElementsByClassName('tarItem')[2].click();", e, false);
                    ExecuteJS("document.getElementsByClassName('login-btn')[0].children[0].click();", e, true);
                }
                //string qqLoginUrl = "https://graph.qq.com/oauth2.0/authorize?client_id=101442945&redirect_uri=https%3A%2F%2Fapi.zywawa.com%2Fgrant%2Fauth%2Flogin%2Fqq%3Fdebug%26cv%3Dtyhq_1.0.0%26dev%3Dbrowser_1.0.0%26osversion%3Dbrowser_1.0.0%26returnurl%3Dhttps%253A%252F%252Fh5weapp.zywawa.com%252F%253FADTAG%253Dtyhq%2523%252Flogin&response_type=code&scope=get_user_info&state=STATE";
                if (e.Url.Contains("xui.ptlogin2.qq.com"))
                {
                    if (reader.EndOfStream)
                    {
                        ShowMsg("qq号用完了");
                        this.timer.Stop();
                    }
                    else
                    {
                        string line = reader.ReadLine();
                        qq = line.Split(new char[] { ',' })[0];
                        qqpwd = line.Split(new char[] { ',' })[1];
                        ShowMsg($"QQ:{qq},pwd:{qqpwd}");
                        string js = @"
                document.getElementById('u').value='qq';
                document.getElementById('p').value='pwd';
                document.getElementById('go').click();
                ".Replace("qq", qq)
                .Replace("pwd", qqpwd)
                ;
                        //ShowMsg(e.Url);
                        ExecuteJS(js, e, true);
                        ShowMsg("success");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void ExecuteJS(string js, FrameLoadEndEventArgs e, bool isDelay)
        {
            string str = js;
            if (isDelay)
            {
                str = @"
                    setTimeout(function() {                                              
                       {js}                       
                    }, 2000);
                ".Replace("{js}", js);
            }
            e.Frame.ExecuteJavaScriptAsync(str);
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
                    this.richTextBox1.Text = $"【{DateTime.Now.ToString("HH:mm:ss")}】:{msg}\r\n{this.richTextBox1.Text}";

                }), "");
            }
            else
            {
                if (this.richTextBox1.Text.Length > 2000)
                    this.richTextBox1.Text = "";
                this.richTextBox1.Text = $"【{DateTime.Now.ToString("HH:mm:ss")}】:{msg}\r\n{this.richTextBox1.Text}";
            }

        }
    }
}
