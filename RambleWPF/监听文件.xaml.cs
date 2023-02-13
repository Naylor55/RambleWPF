using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// 监听文件.xaml 的交互逻辑
    /// </summary>
    public partial class 监听文件 : Window
    {


        private FileSystemWatcher _FileSystemWatcher = new FileSystemWatcher();
        public 监听文件()
        {
            InitializeComponent();
            MonitorDirectory("D:\\tmpp");
        }

        private  void MonitorDirectory(string path, bool isIncludeSubDir = true)
        {
            _FileSystemWatcher.EnableRaisingEvents = false;
            _FileSystemWatcher = new FileSystemWatcher();
            _FileSystemWatcher.Path = path;
            _FileSystemWatcher.IncludeSubdirectories = isIncludeSubDir;
            _FileSystemWatcher.Renamed += OnRenamed;
            _FileSystemWatcher.Changed += OnChanged;
            _FileSystemWatcher.Error += OnError;
            //开始监控
            _FileSystemWatcher.EnableRaisingEvents = true;

        }

        private void _FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (var watcher = new FileSystemWatcher(@"D:\tmpp"))
            {
                watcher.NotifyFilter = NotifyFilters.Attributes
                                      | NotifyFilters.CreationTime
                                      | NotifyFilters.DirectoryName
                                      | NotifyFilters.FileName
                                      | NotifyFilters.LastAccess
                                      | NotifyFilters.LastWrite
                                      | NotifyFilters.Security
                                      | NotifyFilters.Size;
                watcher.Changed += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.Error += OnError;

                watcher.Filter = "bootstrap.json";
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                try
                {
                }
                catch (Exception ex)
                {
                }
            }));
        }


        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("监听到bootstrap.json文件触发OnRenamed事件");
        }

        private void OnError(object sender, System.IO.ErrorEventArgs e)
        {
            Console.WriteLine("监听到bootstrap.json文件触发OnError事件");
            PrintException(e.GetException());
        }

        private static void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine("OnError,e={0},堆栈={1}", ex.Message, ex.StackTrace);
                PrintException(ex.InnerException);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
