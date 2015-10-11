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
        String title;   //タイトル
        String content; //内容
        bool topmost;   //常に最前面
        bool title_hidden; //タイトル非表示

        public memo_setting(memo_window memo_w)
        {
            this.memo = memo_w;
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
            System.Console.WriteLine("title:{0} hidden:{1}", title,title_hidden);
            System.Console.WriteLine("topmost:{0}", topmost);
        }
    }
}
