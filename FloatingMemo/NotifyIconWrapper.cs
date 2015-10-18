using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.IO;

namespace FloatingMemo
{
    public partial class NotifyIconWrapper : Component
    {

        public List<memo_window> memo_list = null;

        private memo_window loadsave(string filename)   //saveクラスを生成してそこからmemo_windowクラスを作る
        {
            string fileName = @filename;
            save savefile;

            //＜XMLファイルから読み込む＞
            //XmlSerializerオブジェクトの作成
            System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(save));
            //ファイルを開く
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));
            //XMLファイルから読み込み、逆シリアル化する
            savefile = (save)serializer2.Deserialize(sr);
            //閉じる
            sr.Close();

            memo_window new_memo = new memo_window(savefile.memoID);
            new_memo.title_label.Content = savefile.title;
            new_memo.memo_textbox.Text = savefile.content;
            new_memo.Topmost = savefile.topmost;

            return new_memo;
        }

        //---------以下イベント------------------
        public NotifyIconWrapper()
        {
            InitializeComponent();

            this.exit_app.Click += this.exit_app_click; //終了イベント
            this.Add_new_memo.Click += this.add_memo_click; //新規メモ作成イベント

            string[] dir = Directory.GetFiles(@"memofile", "*_setting.config", SearchOption.AllDirectories);
            foreach (string i in dir)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("ok");

        }

        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        private void exit_app_click(object sender,EventArgs e)  //タスクバーの終了ボタン
        {
            if (memo_list != null)
            {
                foreach (memo_window i in memo_list)
                {
                    if (i != null)
                    {
                        i.setting.Synchronism();
                        i.setting.set_save();
                    }
                }
            }

            App.Current.Shutdown();
        }

        private void add_memo_click(object sender,EventArgs e)  //タスクバーの新規メモ作成ボタン
        {
            memo_window new_window = new memo_window();
            change_titile_window change = new change_titile_window(new_window);

            if(memo_list == null)
            {
                memo_list = new List<memo_window>();
            }

            new_window.Show();
            change.Show();     //タイトル名設定ウィンドウ表示
            memo_list.Add(new_window);
        }

        private void change_transportmode_Click(object sender, EventArgs e)
        {
            if (memo_list != null)
            {
                foreach (memo_window i in memo_list)
                {
                    if (i != null)
                    {
                        i.transport(change_transportmode.Checked);
                    }
                }
            }
        }
    }
}
