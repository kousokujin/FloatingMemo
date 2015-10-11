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


        public memo_window()
        {
            InitializeComponent();
            memo_textbox.Width = this.Width;
            memo_textbox.Height = this.Height-28;

        }

        /*
        public void Monitor_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //フォームの移動
                this.Left += e.X + mousePoint.X;
                this.Top += e.Y + mousePoint.Y;
            }
        }

        public void Monitor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //左クリックの場合のみ位置を記憶
                mousePoint = new Point(-e.X, -e.Y);
            }
        }
        */

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
            dlg.ShowColor = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                memo_textbox.FontFamily = new FontFamily(dlg.Font.FontFamily.Name);
                memo_textbox.FontSize = dlg.Font.SizeInPoints;
            }
        }

        private void RightClick_menu_font_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FontDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                memo_textbox.FontFamily = new FontFamily(dlg.Font.FontFamily.Name);
                memo_textbox.FontSize = dlg.Font.SizeInPoints;
            }
        }

        private void Change_titile_Right_Click(object sender, RoutedEventArgs e)    //タイトル変更
        {
            change_titile_window window = new change_titile_window(this);
            window.Show();
        }

        private void Change_titile_Click(object sender, RoutedEventArgs e)
        {
            change_titile_window window = new change_titile_window(this);
            window.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)   //フォントカラー変更
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                memo_textbox.Foreground = new SolidColorBrush(color);
            }
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
    }
}
