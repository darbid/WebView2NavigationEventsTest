using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WebView2NavigationEventsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess) System.Diagnostics.Debug.Print("WebView is ready for native window.");
            this.WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            this.WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Debug.Print("++++++++++++++++++++++++NavigationCompleted++++++++++++++++++++++++++++");
            Debug.Print("NavigationId: " + e.NavigationId.ToString());
            Debug.Print("URL: " + this.WebView.CoreWebView2.Source);
            Debug.Print("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        private void CoreWebView2_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Debug.Print("#######################NavigationStarting##############################");
            Debug.Print("NavigationId: " + e.NavigationId.ToString());
            Debug.Print("URL: " + e.Uri);
            Debug.Print("#####################################################");
        }
    }
}
