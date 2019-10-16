ChefBrower的使用。

注意参照github发布的【版本】和【.NET版本】的对应关系。

.NET 4.0 版本使用的是 CefSharp.WinForms 49.0.0

在 NuGet 中安装  CefSharp.WinForms 49.0.0
注意弹出来的 reame.txt
里面中提到的两点：
	修改为 x86 或 x64
	要安装 vc++ 2013

使用：
public ChromiumWebBrowser browser;

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

注意：browser的外观布局代码是如何得到的？

先用一个微软自带的webBrower，先调整他的布局，然后得到代码后，Copy过来即可。

加载某个地址：
this.browser.Load(url);


window.open 问题参照:
https://blog.csdn.net/lanwilliam/article/details/79640954

