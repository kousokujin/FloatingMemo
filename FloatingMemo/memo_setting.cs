using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FloatingMemo
{
    public class memo_setting
    {
        memo_window memo;
        string title;   //タイトル
        string content; //内容
        bool topmost;   //常に最前面
        bool title_hidden; //タイトル非表示
        public string memoID;

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

            if(memo.title_label.Visibility == Visibility.Visible)
            {
                title_hidden = false;
            }
            else
            {
                title_hidden = true;
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
