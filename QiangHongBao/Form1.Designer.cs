namespace QiangHongBao
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowDev = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtIntervalMin = new System.Windows.Forms.TextBox();
            this.txtIntervalMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowDev
            // 
            this.btnShowDev.Location = new System.Drawing.Point(2, 1);
            this.btnShowDev.Name = "btnShowDev";
            this.btnShowDev.Size = new System.Drawing.Size(75, 23);
            this.btnShowDev.TabIndex = 2;
            this.btnShowDev.Text = "ShowDev";
            this.btnShowDev.UseVisualStyleBackColor = true;
            this.btnShowDev.Click += new System.EventHandler(this.btnShowDev_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(2, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(187, 533);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // txtIntervalMin
            // 
            this.txtIntervalMin.Location = new System.Drawing.Point(122, 24);
            this.txtIntervalMin.Name = "txtIntervalMin";
            this.txtIntervalMin.Size = new System.Drawing.Size(35, 21);
            this.txtIntervalMin.TabIndex = 4;
            this.txtIntervalMin.Text = "15";
            // 
            // txtIntervalMax
            // 
            this.txtIntervalMax.Location = new System.Drawing.Point(158, 24);
            this.txtIntervalMax.Name = "txtIntervalMax";
            this.txtIntervalMax.Size = new System.Drawing.Size(34, 21);
            this.txtIntervalMax.TabIndex = 5;
            this.txtIntervalMax.Text = "25";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "执行一次的间隔是：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(83, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 596);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntervalMax);
            this.Controls.Add(this.txtIntervalMin);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnShowDev);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnShowDev;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtIntervalMin;
        private System.Windows.Forms.TextBox txtIntervalMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
    }
}

