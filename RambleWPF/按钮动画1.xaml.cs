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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RambleWPF
{
    /// <summary>
    /// 按钮动画1.xaml 的交互逻辑
    /// </summary>
    public partial class 按钮动画1 : Window
    {
        public 按钮动画1()
        {
            InitializeComponent();
            //居中
            //WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Left = 100;
            this.Top = 100;
            WindowStyle = WindowStyle.None;
            ResizeMode =ResizeMode.NoResize;

        }



        void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = sender as Button;
            //if (buttonTest.Width == 200)
            //{
            //    //指定长度变化的起点,终点与持续时间,并在动画结束时保持大小
            //    DoubleAnimation widthAnimation = new DoubleAnimation(200, 400, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            //    DoubleAnimation heightAnimation = new DoubleAnimation(50, 100, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);

            //    //开始动画
            //    //变化不是阻塞的,而是异步,所以看上去长度与高度几乎是同时变化
            //    buttonTest.BeginAnimation(Button.WidthProperty, widthAnimation);
            //    buttonTest.BeginAnimation(Button.HeightProperty, heightAnimation);
            //}
            //else {
            //    DoubleAnimation widthAnimation = new DoubleAnimation(400, 200, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            //    DoubleAnimation heightAnimation = new DoubleAnimation(100, 50, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            //    buttonTest.BeginAnimation(Button.WidthProperty, widthAnimation);
            //    buttonTest.BeginAnimation(Button.HeightProperty, heightAnimation);
            //}
        }

        /// <summary>
        /// 放大窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            this.BeginAnimation(Window.WidthProperty, new DoubleAnimation(800, 1000, new Duration(TimeSpan.FromSeconds(2))));
            this.BeginAnimation(Window.HeightProperty, new DoubleAnimation(450, 700, new Duration(TimeSpan.FromSeconds(3))));
        }

        /// <summary>
        /// 缩小窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            this.BeginAnimation(Window.WidthProperty, new DoubleAnimation(1000, 800, new Duration(TimeSpan.FromSeconds(2))));
            this.BeginAnimation(Window.HeightProperty, new DoubleAnimation(700, 450, new Duration(TimeSpan.FromSeconds(2))));
        }

        /// <summary>
        /// 放大按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_big_Click(object sender, RoutedEventArgs e)
        {
            //指定长度变化的起点,终点与持续时间,并在动画结束时保持大小
            DoubleAnimation widthAnimation = new DoubleAnimation(200, 400, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            DoubleAnimation heightAnimation = new DoubleAnimation(50, 100, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);

            //开始动画
            //变化不是阻塞的,而是异步,所以看上去长度与高度几乎是同时变化
            buttonTest.BeginAnimation(Button.WidthProperty, widthAnimation);
            buttonTest.BeginAnimation(Button.HeightProperty, heightAnimation);

        }

        /// <summary>
        /// 缩小按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_small_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(400, 200, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            DoubleAnimation heightAnimation = new DoubleAnimation(100, 50, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            buttonTest.BeginAnimation(Button.WidthProperty, widthAnimation);
            buttonTest.BeginAnimation(Button.HeightProperty, heightAnimation);
        }

        /// <summary>
        /// 改变窗体leftAndTop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dou = new DoubleAnimation(100, 200, TimeSpan.FromSeconds(2));
            this.BeginAnimation(Window.LeftProperty, dou);
            this.BeginAnimation(Window.TopProperty, dou);
        }

        /// <summary>
        /// 窗体全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dou = new DoubleAnimation(10, 0, TimeSpan.FromSeconds(2));
            this.BeginAnimation(Window.LeftProperty, new DoubleAnimation(10, 0, TimeSpan.FromSeconds(2)));
            this.BeginAnimation(Window.TopProperty, new DoubleAnimation(10, 0, TimeSpan.FromSeconds(2)));

            //工作区域就是不包括任务栏的其他区域
            double x = SystemParameters.WorkArea.Width;
            //得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;

            this.BeginAnimation(Window.WidthProperty, new DoubleAnimation(this.Width, x, new Duration(TimeSpan.FromSeconds(2))));
            this.BeginAnimation(Window.HeightProperty, new DoubleAnimation(this.Height, y, new Duration(TimeSpan.FromSeconds(3))));

        }
    }
}
