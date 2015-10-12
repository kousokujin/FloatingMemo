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

        public memo_window()
        {
            InitializeComponent();
            memo_textbox.Width = this.Width;
            memo_textbox.Height = this.Height-28;

            setting = new memo_setting(this);

        }

        private void GenerateID()
        {
            int seed = Environment.TickCount;
            Random rad_1 = new Random(seed);
            Random rad_2 = new Random(++seed);
            int hex = Convert.ToInt32("0xFFFFFFFF", 10);
            int intrand_1 = rad_1.Next(0,hex);
            int intrand_2 = rad_2.Next(0, hex);
            string str = string.Format("{0:X}{1:X}", intrand_1, intrand_2);

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  //移動
        {
            if (e.ButtonState != MouseButtonState.Pressed)
            {
                return;
            }

            this.DragMove();

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
        }

        private void Change_titile_Click(object sender, RoutedEventArgs e)  //タイトル変更
        {
            change_titile_window window = new change_titile_window(this);
            window.Show();
        }

        private void memo_textcolor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                memo_textbox.Foreground = new SolidColorBrush(color);
            }
        }
                    
        private void BackColorMenu_right_Click(object sender, RoutedEventArgs e)    //背景色の変更
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                Background = new SolidColorBrush(color);
            }
        }

        private void titile_hidden_Click(object sender, RoutedEventArgs e)  //タイトル非表示
        {
            if(titile_hidden_2.IsChecked)
            {
                title_label.Visibility = Visibility.Hidden;
                title_hidden.IsChecked = true;
                setting.Synchronism();
            }
            else
            {
                title_label.Visibility = Visibility.Visible;
                title_hidden.IsChecked = false;
                setting.Synchronism();
            }
        }

        private void title_hidden_Click(object sender, RoutedEventArgs e)
        {
            if (title_hidden.IsChecked)
            {
                title_label.Visibility = Visibility.Hidden;
                titile_hidden_2.IsChecked = true;
                setting.Synchronism();
            }
            else
            {
                title_label.Visibility = Visibility.Visible;
                titile_hidden_2.IsChecked = false;
                setting.Synchronism();
            }
        }

        private void TopMost_bar_Click(object sender, RoutedEventArgs e)    //常に最前面
        {
            Topmost = TopMost_bar.IsChecked;
            Topmost_Right.IsChecked = TopMost_bar.IsChecked;
            setting.Synchronism();
        }

        private void Topmost_Right_Click(object sender, RoutedEventArgs e)
        {
            Topmost = Topmost_Right.IsChecked;
            TopMost_bar.IsChecked = Topmost_Right.IsChecked;
            setting.Synchronism();
        }

        private void property_menu_Click(object sender, RoutedEventArgs e)
        {
            property = new property_window(this);
            property.Show();
        }
    }
}
