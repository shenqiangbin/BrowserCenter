using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameReg
{
    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
        // Wait for the underlying `Javascript Context` to be created, this is only called for the main frame.
        // If the page has no javascript, no context will be created.
        public void OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";
            //frame.ExecuteJavaScriptAsync(script);
        }


        public void OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            //const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";
            //frame.ExecuteJavaScriptAsync(script);
        }


    }
}
