using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            App.Current.Shutdown();
        }

        private void add_memo_click(object sender,EventArgs e)  //タスクバーの新規メモ作成ボタン
        {
            memo_window new_window = new memo_window();
            if(memo_list == null)
            {
                memo_list = new List<memo_window>();
            }
            new_window.Show();
            memo_list.Add(new_window);
        }
    }
}
