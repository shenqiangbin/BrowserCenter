using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFormVisitUrl
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int number;

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            number = 0;
        }

        private void InitTimer()
        {
            this.timer = new Timer();
            timer.Interval = (int)new TimeSpan(0, 0, 15).TotalMilliseconds;
            timer.Tick += Timer_Tick;
            //this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.txtUrl.Text);
            number++;
            lblNum.Text = number.ToString();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
