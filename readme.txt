WinForm端浏览器功能实现：
1、使用微软自带的WebBrowser
2、使用GitHub上的CefSharp
	注意要安装 vs 2013 C++ 东西
	平台修改为 x86

优缺点：
	1、WebBrowser生成的安装包小，但CefSharp生成的安装包大
	2、WebBrowser有些页面效果不好，而CefSharp效果好，是WebKit内核，类似Chrmoe。

CefSharp的地址：https://github.com/cefsharp