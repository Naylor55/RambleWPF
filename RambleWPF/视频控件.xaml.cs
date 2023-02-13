using LibVLCSharp.Shared;
using LibVLCSharp.WPF;
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
    /// 视频控件.xaml 的交互逻辑
    /// </summary>
    public partial class 视频控件 : Window
    {
        readonly LibVLC _libvlc;
        public 视频控件()
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


            Canvas.SetLeft(main_video, 50);
            Canvas.SetTop(main_video, 500);
            main_video.Width = 300;
            main_video.Height = 168.75;
            Canvas.SetZIndex(main_video, 2);




            Canvas.SetLeft(small_video, 100);
            Canvas.SetTop(small_video, 0);
            int v = Canvas.GetZIndex(small_video);
            Canvas.SetZIndex(small_video, 1);
            int v1 = Canvas.GetZIndex(small_video);
            small_video.Width = 1366;
            small_video.Height = 768;


            int v3 = Canvas.GetZIndex(small_video);

            int v4 = Canvas.GetZIndex(main_video);

            foreach (Window window in Application.Current.Windows)
            {

                Console.WriteLine(window.Title);
            }
            for (int i = 0; i < Application.Current.Windows.Count; i++)
            {
                Window w = Application.Current.Windows[i];
                if (i == 1)
                {
                    w.Topmost = true;
                }
              
                if (w.Title == "LibVLCSharp.WPF")
                {

                }
            }

            VideoView video =new VideoView();
            video.Name = "video";
            video.Width = 500;
            video.Height = 500;


        }

        private void main_video_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int i = 9;
        }
    }
}
