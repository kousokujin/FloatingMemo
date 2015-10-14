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

namespace FloatingMemo
{
    public partial class NotifyIconWrapper : Component
    {

        public List<memo_window> memo_list = null;

        //---------以下イベント------------------
        public NotifyIconWrapper()
        {
            InitializeComponent();

            this.exit_app.Click += this.exit_app_click; //終了イベント
            this.Add_new_memo.Click += this.add_memo_click; //新規メモ作成イベント
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
                        //i.setting.set_save();
                        //set_save(i);
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

        public void set_save(memo_window memo)  //設定ファイルの保存
        {

            memo.setting.p = memo.PointToScreen(new Point(0.0d, 0.0d));

            //保存先のファイル名
            string fileName = string.Format(@"{0}_setting.config", memo.setting.memoID);

            //＜XMLファイルに書き込む＞
            //XmlSerializerオブジェクトを作成
            //書き込むオブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(memo_setting));
            //ファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, memo.setting);
            //閉じる
            sw.Close();
        }
    }
}
