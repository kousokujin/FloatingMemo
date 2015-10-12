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

namespace FloatingMemo
{
    /// <summary>
    /// property_window.xaml の相互作用ロジック
    /// </summary>
    public partial class property_window : Window
    {
        memo_window memo;

        public property_window(memo_window window)
        {
            InitializeComponent();
            memo = window;

            topmost_checkBox.IsChecked = memo.Topmost;
            titlehidden_checkbox.IsChecked = title_hidden();
        }

        private bool title_hidden()
        {
            bool output;

            if (memo.title_label.Visibility == Visibility.Visible)
            {
                output = false;
            }
            else
            {
                output = true;
            }

            return output;
        }
    }
}
