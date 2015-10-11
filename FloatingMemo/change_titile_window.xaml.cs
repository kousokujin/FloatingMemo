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
    /// change_titile_window.xaml の相互作用ロジック
    /// </summary>
    public partial class change_titile_window : Window
    {
        memo_window memo_win;

        public change_titile_window(memo_window memo)
        {
            InitializeComponent();
            memo_win = memo;
            titile_textbox.Text =(string)memo_win.title_label.Content;
            titile_textbox.SelectAll();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  //ドラッグで移動する
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

        private void OK_button_Click(object sender, RoutedEventArgs e)  //OKボタン
        {
            memo_win.title_label.Content = titile_textbox.Text;
            Close();
        }
    }
}
