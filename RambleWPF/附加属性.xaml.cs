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
    /// 附加属性.xaml 的交互逻辑
    /// </summary>
    public partial class 附加属性 : Window
    {
        public 附加属性()
        {
            InitializeComponent();
            //DataContext = this;
        }

        private void tb_search_TextInput(object sender, TextCompositionEventArgs e)
        {
            string text = this.tb_search.Text;
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = this.tb_search.Text;
        }


        
    }
}
