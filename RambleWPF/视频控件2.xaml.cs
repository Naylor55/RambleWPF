using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// 视频控件2.xaml 的交互逻辑
    /// </summary>
    public partial class 视频控件2 : Window
    {
        readonly LibVLC _libvlc;
        public 视频控件2()
        {
            InitializeComponent();
            _libvlc = new LibVLC();
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            AllowsTransparency = true;
            //工作区域就是不包括任务栏的其他区域
            double x = SystemParameters.WorkArea.Width;
            //得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;
            win.Width = x;
            win.Height = y;
            win.Top = 0;
            win.Left = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(main_video, 100);
            Canvas.SetZIndex(main_video, 1);
            main_video.Width = 1366;
            main_video.Height = 768;

            Canvas.SetLeft(small_video, 150);
            Canvas.SetTop(small_video, 500);
            Canvas.SetZIndex(small_video, 2);
            small_video.Width = 300;
            small_video.Height = 168.75;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.Tag = main_video.Name;
            string url = "rtsp://admin:Admin123@192.168.1.120:554/ch1/main/av_stream";
            LibVLCSharp.Shared.MediaPlayer player = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
            main_video.MediaPlayer = player;
            using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url)))
            {
                main_video.MediaPlayer.Play(media);
            }

            string url2 = "rtsp://admin:abc12345@192.168.1.142:554/Streaming/Channels/1";
            LibVLCSharp.Shared.MediaPlayer player2 = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
            small_video.MediaPlayer = player2;
            using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url2)))
            {
                small_video.MediaPlayer.Play(media);
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            string url = "rtsp://admin:Admin123@192.168.1.120:554/ch1/main/av_stream";
            string url2 = "rtsp://admin:abc12345@192.168.1.142:554/Streaming/Channels/1";
            if (this.Tag as string != main_video.Name)
            {
                this.Tag = main_video.Name;
                using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url)))
                {
                    main_video.MediaPlayer.Play(media);
                }

                using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url2)))
                {
                    small_video.MediaPlayer.Play(media);
                }
            }
            else
            {
                this.Tag = small_video.Name;
                using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url2)))
                {
                    main_video.MediaPlayer.Play(media);
                }

                using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url)))
                {
                    small_video.MediaPlayer.Play(media);
                }
            }
        }
    }
}
