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
        memo_setting setting;
        public property_window(memo_window window)
        {
            InitializeComponent();
            memo = window;
            setting = window.setting;

            title_label.Content = string.Format("{0}のプロパティ",setting.title);
            memoID_label.Content = string.Format("memoID:{0}",setting.memoID);
            topmost_checkBox.IsChecked = memo.Topmost;
            titlehidden_checkbox.IsChecked = setting.title_hidden;
        }

        private void property_win_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //ドラッグで移動
        {
            if (e.ButtonState != MouseButtonState.Pressed)
            {
                return;
            }

            this.DragMove();
        }

        private void close_button_Click(object sender, RoutedEventArgs e)   //閉じるボタン
        {
            Close();
        }

        private void topmost_checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (topmost_checkBox.IsChecked == true)
            {
                memo.Topmost = true;
                memo.syncpropartywindow();
            }
            else
            {
                memo.Topmost = false;
                memo.syncpropartywindow();
            }

            setting.Synchronism();
        }

        private void titlehidden_checkbox_Click(object sender, RoutedEventArgs e)
        {
            if(titlehidden_checkbox.IsChecked == true)
            {
                memo.title_label.Visibility = Visibility.Hidden;
                memo.syncpropartywindow();
            }
            else
            {
                memo.title_label.Visibility = Visibility.Visible;
                memo.syncpropartywindow();
            }
        }
    }
}
