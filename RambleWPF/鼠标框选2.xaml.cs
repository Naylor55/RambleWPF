using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// 鼠标框选2.xaml 的交互逻辑
    /// </summary>
    public partial class 鼠标框选2 : Window
    {
        readonly LibVLC _libvlc;

        //拖动展示的提示框
        private static Border currentBoxSelectedBorder = null;
        //鼠标是否移动
        private static bool isCanMove = false;
        //起始坐标
        private static Point tempStartPoint;
        //结束坐标
        private static Point EndPoint;

        public 鼠标框选2()
        {
            InitializeComponent();

            _libvlc = new LibVLC();
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            AllowsTransparency = true;
            this.Width = 2000;
            this.Height = 1000;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(main_video, 100);
            Canvas.SetZIndex(main_video, 1);
            main_video.Width = 1366;
            main_video.Height = 768;

            mainCanvas.Width = 1366;
            mainCanvas.Height = 768;
            mask.Width = 1366;
            mask.Height = 768;



        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            string url = "rtsp://admin:Admin123@192.168.1.120:554/ch1/main/av_stream";
            LibVLCSharp.Shared.MediaPlayer player = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
            main_video.MediaPlayer = player;
            main_video.IsEnabled = false;
            using (LibVLCSharp.Shared.Media media = new Media(_libvlc, new Uri(url)))
            {
                main_video.MediaPlayer.Play(media);
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("起始坐标：" + JsonConvert.SerializeObject(tempStartPoint));
            MessageBox.Show("结束坐标：" + JsonConvert.SerializeObject(EndPoint));
        }

        /// <summary>
        /// 鼠标按下记录起始点
        /// </summary>
        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isCanMove = true;
            tempStartPoint = e.GetPosition(this.mask);
        }

        /// <summary>
        /// 框选逻辑
        /// </summary>
        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCanMove)
            {
                Point tempEndPoint = e.GetPosition(this.mask);
                //绘制跟随鼠标移动的方框
                DrawMultiselectBorder(tempEndPoint, tempStartPoint);
            }
        }

        /// <summary>
        /// 鼠标抬起时清除选框
        /// </summary>
        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentBoxSelectedBorder != null)
            {
                //获取选框的矩形位置
                Point tempEndPoint = e.GetPosition(this.mask);
                EndPoint = tempEndPoint;
               
                this.mainCanvas.Children.Remove(currentBoxSelectedBorder);
                currentBoxSelectedBorder = null;
            }

            isCanMove = false;
        }

        /// <summary>
        /// 绘制跟随鼠标移动的方框
        /// </summary>
        private void DrawMultiselectBorder(Point endPoint, Point startPoint)
        {
            if (currentBoxSelectedBorder == null)
            {
                currentBoxSelectedBorder = new Border();
                currentBoxSelectedBorder.Background = new SolidColorBrush(Colors.Orange);
                currentBoxSelectedBorder.Opacity = 0.4;
                currentBoxSelectedBorder.BorderThickness = new Thickness(2);
                currentBoxSelectedBorder.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Canvas.SetZIndex(currentBoxSelectedBorder, 100);
                this.mainCanvas.Children.Add(currentBoxSelectedBorder);
            }
            currentBoxSelectedBorder.Width = Math.Abs(endPoint.X - startPoint.X);
            currentBoxSelectedBorder.Height = Math.Abs(endPoint.Y - startPoint.Y);
            if (endPoint.X - startPoint.X >= 0)
                Canvas.SetLeft(currentBoxSelectedBorder, startPoint.X);
            else
                Canvas.SetLeft(currentBoxSelectedBorder, endPoint.X);
            if (endPoint.Y - startPoint.Y >= 0)
                Canvas.SetTop(currentBoxSelectedBorder, startPoint.Y);
            else
                Canvas.SetTop(currentBoxSelectedBorder, endPoint.Y);
        }
    }
}
