using Microsoft.Web.WebView2.Core;
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
using System.Windows.Shapes;

namespace RambleWPF
{
    /// <summary>
    /// WebView2Demo.xaml 的交互逻辑
    /// </summary>S
    public partial class WebView2Demo : Window
    {
        public WebView2Demo()
        {
            InitializeComponent();

            InitializeAsync();
        }

        async void InitializeAsync()
        {
            wv2.CreationProperties = new Microsoft.Web.WebView2.Wpf.CoreWebView2CreationProperties
            {
                UserDataFolder = "D:\\A\\wvUDF"
            };
            await wv2.EnsureCoreWebView2Async();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.wv2.Source = new Uri("http://baidu.com");
            //this.wv2.Source = new Uri("about:blank");
            //this.wv2.Source = new Uri("file:///E:/code/WPF/ramble-wpf/RambleWPF/html/PostMessage.html");

            //导航开始
            this.wv2.NavigationStarting += wv2_NavigationStarting;
            //源已经更改
            this.wv2.SourceChanged += Wv2_SourceChanged;
            //内容加载中
            this.wv2.ContentLoading += Wv2_ContentLoading;
            //导航结束
            this.wv2.NavigationCompleted += Wv2_NavigationCompleted;

            this.wv2.WebMessageReceived += Wv2_WebMessageReceived;



        }

        private void Wv2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            //接收到的字符串
            string msg = e.TryGetWebMessageAsString();
            //接收到的json
            string msgJson = e.WebMessageAsJson;

        }

        private void Wv2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //  throw new NotImplementedException();
        }

        private void Wv2_ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
        {
            //  throw new NotImplementedException();
        }

        private void Wv2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void wv2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            if (wv2 != null && wv2.CoreWebView2 != null)
            {
                wv2.CoreWebView2.Navigate(addressBar.Text);
            }
        }
    }
}
