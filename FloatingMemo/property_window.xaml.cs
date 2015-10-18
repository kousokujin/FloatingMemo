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
using System.Windows.Forms;

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
            opt_slider.Value = setting.transper * 100;
            opt_label.Content = string.Format("{0:0}", opt_slider.Value);
            enable_mouseover.IsChecked = !(setting.mouse_over);
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
            setting.Synchronism();
        }

        private void topmost_checkBox_Click(object sender, RoutedEventArgs e)   //常に最前面チェックボックス
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

        private void titlehidden_checkbox_Click(object sender, RoutedEventArgs e)   //タイトル非表示チェックボックス
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

            setting.Synchronism();
        }


        private void opt_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)   //透明度スライダー
        {
            if(memo != null)
            {
                memo.Opacity = opt_slider.Value/100;
                opt_label.Content = string.Format("{0:0}",opt_slider.Value);
                setting.Synchronism(); 
            }
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            setting.Synchronism();
            Close();
        }

        private void enable_mouseover_Click(object sender, RoutedEventArgs e)   //マウスオーバー
        {
            if (enable_mouseover.IsChecked == true)
            {
                memo.mouse_over = false;
            }else
            {
                memo.mouse_over = true;
            }
            setting.Synchronism();
        }

        private void fontcolorchange_Click(object sender, RoutedEventArgs e)    //フォントカラー変更
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                memo.memo_textbox.Foreground = new SolidColorBrush(color);
                memo.default_memocolor = new SolidColorBrush(color);
            }

            setting.Synchronism();
        }

        private void backcolorchange_Click(object sender, RoutedEventArgs e)    //背景色変更
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                memo.back = new SolidColorBrush(color);
                if (!(setting.transport_enable))
                {
                    memo.Background = memo.back;
                }
            }
            setting.Synchronism();
        }

        private void fontchange_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FontDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                memo.memo_textbox.FontFamily = new FontFamily(dlg.Font.FontFamily.Name);
                memo.memo_textbox.FontSize = dlg.Font.SizeInPoints;
            }
            setting.Synchronism();
        }
    }
}
