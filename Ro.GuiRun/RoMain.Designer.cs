using DMSkin;

namespace Ro.GuiRun
{
    partial class RoMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoMain));
            this.RosTree = new System.Windows.Forms.TreeView();
            this.Start = new MaterialSkin.Controls.MaterialFlatButton();
            this.ResultView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Names = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Control = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectFile = new DMSkin.Metro.Controls.MetroButton();
            this.GuiStrip = new System.Windows.Forms.StatusStrip();
            this.TotalSteps = new System.Windows.Forms.ToolStripStatusLabel();
            this.SucSteps = new System.Windows.Forms.ToolStripStatusLabel();
            this.FailSteps = new System.Windows.Forms.ToolStripStatusLabel();
            this.SucCover = new System.Windows.Forms.ToolStripStatusLabel();
            this.OneKey = new DMSkin.Metro.Controls.MetroButton();
            this.GuiStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RosTree
            // 
            this.RosTree.CheckBoxes = true;
            this.RosTree.Location = new System.Drawing.Point(7, 41);
            this.RosTree.Name = "RosTree";
            this.RosTree.Size = new System.Drawing.Size(227, 600);
            this.RosTree.TabIndex = 0;
            this.RosTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.RosTree_AfterCheck);
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Start.Depth = 0;
            this.Start.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(925, 633);
            this.Start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Start.MouseState = MaterialSkin.MouseState.HOVER;
            this.Start.Name = "Start";
            this.Start.Primary = false;
            this.Start.Size = new System.Drawing.Size(65, 36);
            this.Start.TabIndex = 1;
            this.Start.Text = "开始运行";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ResultView
            // 
            this.ResultView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Names,
            this.Control,
            this.Result,
            this.Extra});
            this.ResultView.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultView.Location = new System.Drawing.Point(240, 41);
            this.ResultView.Name = "ResultView";
            this.ResultView.Size = new System.Drawing.Size(753, 568);
            this.ResultView.TabIndex = 2;
            this.ResultView.UseCompatibleStateImageBehavior = false;
            this.ResultView.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "步骤编号";
            this.ID.Width = 100;
            // 
            // Names
            // 
            this.Names.Text = "步骤名称";
            this.Names.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Names.Width = 150;
            // 
            // Control
            // 
            this.Control.Text = "使用控件";
            this.Control.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Control.Width = 150;
            // 
            // Result
            // 
            this.Result.Text = "执行结果";
            this.Result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Result.Width = 150;
            // 
            // Extra
            // 
            this.Extra.Text = "追加信息";
            this.Extra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Extra.Width = 200;
            // 
            // SelectFile
            // 
            this.SelectFile.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.SelectFile.DM_UseSelectable = true;
            this.SelectFile.Location = new System.Drawing.Point(7, 7);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(88, 28);
            this.SelectFile.TabIndex = 4;
            this.SelectFile.Text = "选择文件夹";
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // GuiStrip
            // 
            this.GuiStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.GuiStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TotalSteps,
            this.SucSteps,
            this.FailSteps,
            this.SucCover});
            this.GuiStrip.Location = new System.Drawing.Point(4, 674);
            this.GuiStrip.Name = "GuiStrip";
            this.GuiStrip.Size = new System.Drawing.Size(347, 22);
            this.GuiStrip.TabIndex = 5;
            this.GuiStrip.Text = "statusStrip1";
            // 
            // TotalSteps
            // 
            this.TotalSteps.Name = "TotalSteps";
            this.TotalSteps.Size = new System.Drawing.Size(78, 17);
            this.TotalSteps.Text = "当前步骤数:0";
            // 
            // SucSteps
            // 
            this.SucSteps.Name = "SucSteps";
            this.SucSteps.Size = new System.Drawing.Size(78, 17);
            this.SucSteps.Text = "成功步骤数:0";
            // 
            // FailSteps
            // 
            this.FailSteps.Name = "FailSteps";
            this.FailSteps.Size = new System.Drawing.Size(78, 17);
            this.FailSteps.Text = "失败步骤数:0";
            // 
            // SucCover
            // 
            this.SucCover.Name = "SucCover";
            this.SucCover.Size = new System.Drawing.Size(65, 17);
            this.SucCover.Text = "成功率:0%";
            // 
            // OneKey
            // 
            this.OneKey.DM_UseSelectable = true;
            this.OneKey.Location = new System.Drawing.Point(101, 7);
            this.OneKey.Name = "OneKey";
            this.OneKey.Size = new System.Drawing.Size(82, 28);
            this.OneKey.TabIndex = 6;
            this.OneKey.Text = "一键选择";
            this.OneKey.Click += new System.EventHandler(this.OneKey_Click);
            // 
            // RoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.OneKey);
            this.Controls.Add(this.GuiStrip);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.ResultView);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.RosTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoMain";
            this.GuiStrip.ResumeLayout(false);
            this.GuiStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView RosTree;
        private MaterialSkin.Controls.MaterialFlatButton Start;
        private System.Windows.Forms.ListView ResultView;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Names;
        private System.Windows.Forms.ColumnHeader Control;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.ColumnHeader Extra;
        private DMSkin.Metro.Controls.MetroButton SelectFile;
        private System.Windows.Forms.StatusStrip GuiStrip;
        private System.Windows.Forms.ToolStripStatusLabel TotalSteps;
        private System.Windows.Forms.ToolStripStatusLabel SucSteps;
        private System.Windows.Forms.ToolStripStatusLabel FailSteps;
        private System.Windows.Forms.ToolStripStatusLabel SucCover;
        private DMSkin.Metro.Controls.MetroButton OneKey;
    }
}

