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
    /// memo_window.xaml の相互作用ロジック
    /// </summary>
    public partial class memo_window : Window
    {
        public memo_setting setting;
        public property_window property;

        public Brush back;
        public Brush default_memocolor;
        public bool mouse_over;

        public memo_window(string id = "0")
        {
            InitializeComponent();
            memo_textbox.Width = this.Width;
            memo_textbox.Height = this.Height-28;

            setting = new memo_setting(this);
            back = this.Background;
            mouse_over = true;

            Color c = Color.FromRgb(0, 0, 0);
            default_memocolor = new SolidColorBrush(c);
            title_label.Foreground = default_memocolor;

            if(id != "0")
            {
                setting.memoID = id;
            }

        }

        public void syncpropartywindow()    //プロパティウィンドウとかと同期
        {
            Topmost_Right.IsChecked = this.Topmost;

            if (this.title_label.Visibility == Visibility.Hidden)
            {
                title_hidden.IsChecked = true;
            }
            else
            {
                title_hidden.IsChecked = false;
            }

            if (property != null)
            {
                property.topmost_checkBox.IsChecked = this.Topmost;

                if(title_label.Visibility == Visibility.Hidden)
                {
                    property.titlehidden_checkbox.IsChecked = true;
                }else
                {
                    property.titlehidden_checkbox.IsChecked = false;
                }

            }
        }

        public void transport(bool enable)
        {
            if (enable)
            {
                this.Background = Brushes.Transparent;
                closebutton.Visibility = Visibility.Hidden;
                //   menu_button.Visibility = Visibility.Hidden;
                minimaziebutton.Visibility = Visibility.Hidden;
                title_label.Foreground = setting.font_color;

            }
            else
            {
                this.Background = setting.back;
                closebutton.Visibility = Visibility.Visible;
                //    menu_button.Visibility = Visibility.Visible;
                minimaziebutton.Visibility = Visibility.Visible;
                title_label.Foreground = default_memocolor;
            }

            setting.Synchronism();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  //移動
        {
            if (!(setting.transport_enable))
            {
                if (e.ButtonState != MouseButtonState.Pressed)
                {
                    return;
                }

                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //閉じるボタン
        {
            System.Console.WriteLine("close:{0}",setting.memoID);
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)  //ウィンドウの大きさ変更イベント
        {
            memo_textbox.Width = this.Width;
            memo_textbox.Height = this.Height - 28;
        }


        private void Font_cahnge_menu_Click(object sender, RoutedEventArgs e)   //フォント変更
        {
            var dlg = new FontDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                memo_textbox.FontFamily = new FontFamily(dlg.Font.FontFamily.Name);
                memo_textbox.FontSize = dlg.Font.SizeInPoints;
            }
            setting.Synchronism();
        }

        private void Change_titile_Click(object sender, RoutedEventArgs e)  //タイトル変更
        {
            change_titile_window window = new change_titile_window(this);
            window.Show();
        }

        private void memo_textcolor_Click(object sender, RoutedEventArgs e) //フォント色変更
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                memo_textbox.Foreground = new SolidColorBrush(color);
            }

            setting.Synchronism();
        }
                    
        private void BackColorMenu_right_Click(object sender, RoutedEventArgs e)    //背景色の変更
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                back = new SolidColorBrush(color);
                if(!(setting.transport_enable))
                {
                    Background = back;
                }
            }
            setting.Synchronism();
        }

        private void title_hidden_Click(object sender, RoutedEventArgs e)   //タイトル非表示ボタン
        {
            if (title_hidden.IsChecked)
            {
                title_label.Visibility = Visibility.Hidden;
                //titile_hidden_2.IsChecked = true;
                syncpropartywindow();
                setting.Synchronism();
            }
            else
            {
                title_label.Visibility = Visibility.Visible;
               // titile_hidden_2.IsChecked = false;
                syncpropartywindow();
                setting.Synchronism();
            }
        }

        private void Topmost_Right_Click(object sender, RoutedEventArgs e)
        {
            Topmost = Topmost_Right.IsChecked;
            // TopMost_bar.IsChecked = Topmost_Right.IsChecked;
            syncpropartywindow();
            setting.Synchronism();
        }

        private void property_menu_Click(object sender, RoutedEventArgs e)  //プロパティウィンドウを開く
        {
            property = new property_window(this);
            property.Show();
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)    //メモの上にカーソルが乗る
        {
            if((mouse_over) & (!(setting.transport_enable)))
            {
                this.Opacity = 1.00;
            }
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)    //メモの上からカーソルが離れる
        {
            if ((mouse_over) & (!(setting.transport_enable)))
            {
                this.Opacity = setting.transper;
            }
        }

        private void minimaziebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
