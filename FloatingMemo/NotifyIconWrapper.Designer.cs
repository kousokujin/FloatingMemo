namespace FloatingMemo
{
    partial class NotifyIconWrapper
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add_new_memo = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_app = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.change_transportmode = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add_new_memo,
            this.change_transportmode,
            this.toolStripSeparator1,
            this.exit_app});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(156, 54);
            // 
            // Add_new_memo
            // 
            this.Add_new_memo.AutoSize = false;
            this.Add_new_memo.Name = "Add_new_memo";
            this.Add_new_memo.Size = new System.Drawing.Size(155, 22);
            this.Add_new_memo.Text = "新しいメモを追加";
            // 
            // exit_app
            // 
            this.exit_app.Name = "exit_app";
            this.exit_app.Size = new System.Drawing.Size(155, 22);
            this.exit_app.Text = "終了";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // change_transportmode
            // 
            this.change_transportmode.CheckOnClick = true;
            this.change_transportmode.Name = "change_transportmode";
            this.change_transportmode.Size = new System.Drawing.Size(155, 22);
            this.change_transportmode.Text = "透過モード";
            this.change_transportmode.Click += new System.EventHandler(this.change_transportmode_Click);
            this.notifyMenu.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem exit_app;
        private System.Windows.Forms.ToolStripMenuItem Add_new_memo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem change_transportmode;
    }
}
