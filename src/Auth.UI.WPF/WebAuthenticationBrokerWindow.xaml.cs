using System.Windows;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf; 
using System.Threading.Tasks;
using System;

namespace Firebase.Auth.UI
{
    internal partial class WebAuthenticationBrokerWindow : Window
    {
        public WebAuthenticationBrokerWindow()
        {
            InitializeComponent();
            this.WebView.CoreWebView2InitializationCompleted += async (s, e) =>
            {
                if (e.IsSuccess)
                {
                    await ClearBrowserCache(this.WebView);
                }
            };
        }

        private async Task ClearBrowserCache(WebView2 webView)
            {
                // Check for the CoreWebView2 object, which exposes the clearing method
                if (webView.CoreWebView2 != null)
                {
                    try
                    {
                        // Use the default profile
                        var profile = webView.CoreWebView2.Profile; 

                        // Clear all types of browsing data (cookies, cache, etc.)
                        await profile.ClearBrowsingDataAsync();
                        
                        // Log for confirmation
                        System.Diagnostics.Debug.WriteLine("✅ WebView2 cache successfully cleared via injected source code.");
                    }
                    catch (Exception ex)
                    {
                        // Log if the clearing fails
                        System.Diagnostics.Debug.WriteLine($"⚠️ Failed to clear WebView2 cache: {ex.Message}");
                    }
                }
            }
    }
}
