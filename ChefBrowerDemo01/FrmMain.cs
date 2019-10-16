using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChefBrowerDemo01
{
    public partial class FrmMain : Form
    {
        private Form1 browserForm;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var BWidth = int.Parse(txtWidth.Text.Trim());
            var BHeight = int.Parse(txtHeight.Text.Trim());
            var Bx = int.Parse(txtX.Text.Trim());
            var By = int.Parse(txtY.Text.Trim());
            browserForm = new Form1(BWidth,BHeight,Bx,By);
            browserForm.Show();
            this.btnOpen.Enabled = false;
            this.btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            browserForm.Close();
            this.btnOpen.Enabled = true;
            this.btnClose.Enabled = false;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var sc = System.Windows.Forms.Screen.AllScreens;

            StringBuilder builder = new StringBuilder();
            //显示不同屏幕的属性
            foreach (var v in sc)
            {
                var l = v.WorkingArea.Location;
                builder.Append($"显示器：{v.DeviceName} x：{v.WorkingArea.X} y：{v.WorkingArea.Y}  宽：{v.WorkingArea.Width} 高：{v.WorkingArea.Height} \r\n");
            }

            this.richTextBoxInfo.Text = builder.ToString();


            txtWidth.Text = ConfigGet("w");
            txtHeight.Text = ConfigGet("h");
            txtX.Text = ConfigGet("x");
            txtY.Text = ConfigGet("y");

            this.btnClose.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var BWidth = int.Parse(txtWidth.Text.Trim());
            var BHeight = int.Parse(txtHeight.Text.Trim());
            var Bx = int.Parse(txtX.Text.Trim());
            var By = int.Parse(txtY.Text.Trim());

            ConfigSet("x", Bx.ToString());
            ConfigSet("y", By.ToString());
            ConfigSet("w", BWidth.ToString());
            ConfigSet("h", BHeight.ToString());

            MessageBox.Show("保存成功");
        }

        public String ConfigGet(string key)
        {
            var s = ConfigurationManager.AppSettings[key].ToString();
            return s;
        }

        public void ConfigSet(string key,string value)
        {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
