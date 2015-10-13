using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FloatingMemo
{
    public class memo_setting
    {
        memo_window memo;
        public string title;   //タイトル
        string content; //内容
        public bool topmost;   //常に最前面
        public bool title_hidden; //タイトル非表示
        public string memoID;
        public double transper; //透明度
        public bool transport_enable; //透明化
        public Brush back;
        public Brush font_color;
        public bool mouse_over;


        public memo_setting(memo_window memo_w)
        {
            this.memo = memo_w;
            GenerateID();
            Synchronism();
        }

        public void Synchronism()
        {
            title = (string)memo.title_label.Content;
            content = memo.memo_textbox.Text;
            topmost = memo.Topmost;
            transper = memo.Opacity;
            back = memo.back;
            font_color = memo.memo_textbox.Foreground;
            mouse_over = memo.mouse_over;

            if(memo.title_label.Visibility == Visibility.Visible)
            {
                title_hidden = false;
            }
            else
            {
                title_hidden = true;
            }

            if(memo.Background == Brushes.Transparent)  //背景透明
            {
                transport_enable = true;
            }
            else
            {
                transport_enable = false;
            }

            //デバッグ用
            System.Console.WriteLine("ID:{0}", memoID);
            System.Console.WriteLine("title:{0} hidden:{1}", title,title_hidden);
            System.Console.WriteLine("topmost:{0}", topmost);
        }

        private void GenerateID()   //メモ固有のIDを生成(16桁の16進数)
        {
            int seed = Environment.TickCount;
            Random rad_1 = new Random(seed);
            Random rad_2 = new Random(++seed);
            Random rad_3 = new Random(++seed);
            Random rad_4 = new Random(++seed);

            int hex = Convert.ToInt32(0xFFFF);
            int intrand_1 = rad_1.Next(0, hex);
            int intrand_2 = rad_2.Next(0, hex);
            int intrand_3 = rad_3.Next(0, hex);
            int intrand_4 = rad_4.Next(0, hex);
            memoID = string.Format("{0:X}{1:X}{2:X}{3:X}", intrand_1, intrand_2,intrand_3,intrand_4);

            //デバッグ用
            System.Console.WriteLine("GenerateID:{0}", memoID);
        }
    }
}
