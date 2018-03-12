using System;
using System.Windows.Forms;
using Ro.Common.Args;
using Ro.Common.UserType.GuiType;
using static System.String;

namespace Ro.GuiRun.OtherWins
{
    public partial class SetTime : Form
    {
        public SetTime()
        {
            InitializeComponent();
            ComArgs.SetTimer = new SetTimer(); //初始化
        }


        /// <summary>
        /// 点击保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            //保存按钮只是保存待保存的信息
            if (!IsNullOrEmpty(DefTime.Text) && !IsNullOrEmpty(EvertTime.Text))
            {
                ComArgs.SetTimer.IsRun = IsSetTime.Checked;
                ComArgs.SetTimer.StartTime = DefTime.Text;
                ComArgs.SetTimer.TimerTime = EvertTime.Text;
                if (MessageBox.Show($@"当前设置:{IsSetTime.Checked},运行时间为:{DefTime.Text}") == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(@"请输入正确的时间和小时数");
            }
        }
    }
}
