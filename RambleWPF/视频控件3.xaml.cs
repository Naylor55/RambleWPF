using LibVLCSharp.Shared;
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
    /// 视频控件3.xaml 的交互逻辑
    /// </summary>
    public partial class 视频控件3 : Window
    {

        readonly LibVLC _libvlc;


        public 视频控件3()
        {
            InitializeComponent();
            _libvlc = new LibVLC();

            this.WindowStyle = WindowStyle.None;
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
            video.Width = x;
            video.Height = y;
            mask.Width = x;
            mask.Height = y;

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            video.IsEnabled = false;
            //rtsp 播放串
            //string url = "rtsp://admin:Admin123@192.168.1.120:554/ch1/main/av_stream";

            //m3u8播放串
            //string url = "http://1257120875.vod2.myqcloud.com/0ef121cdvodtransgzp1257120875/3055695e5285890780828799271/v.f230.m3u8";

            //播放文件
            string url = "C:\\Users\\cml\\Desktop\\temp\\流浪地球2.mp4";
            LibVLCSharp.Shared.MediaPlayer player = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
            video.MediaPlayer = player;
            using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url)))
            {
                video.MediaPlayer.Play(media);
            }
            player.AspectRatio = video.Width + ":" + video.Height;

        }





        private void test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("您点击了【测试】按钮");
        }

        private void video_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("您点击了【video】画面中没有按钮的画面区域");
        }


        private void mask_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("您点击了【遮罩层】");
        }

        private void root_grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("您点击了【root_grid】");
        }


        /// <summary>
        /// 挤压和拉伸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extrusion_Click(object sender, RoutedEventArgs e)
        {
            //video.MediaPlayer.AspectRatio = this.Width + ":" + 100;

            video.MediaPlayer.AspectRatio = 100 + ":" + video.Height;

        }


    }
}
