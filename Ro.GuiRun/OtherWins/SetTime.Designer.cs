namespace Ro.GuiRun.OtherWins
{
    partial class SetTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IsSetTime = new DMSkin.Controls.DMCheckBox();
            this.metroLabel2 = new DMSkin.Metro.Controls.MetroLabel();
            this.DefTime = new DMSkin.Controls.DMTextBox();
            this.EvertTime = new DMSkin.Controls.DMTextBox();
            this.metroLabel3 = new DMSkin.Metro.Controls.MetroLabel();
            this.metroLabel4 = new DMSkin.Metro.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IsSetTime
            // 
            this.IsSetTime.BackColor = System.Drawing.Color.Transparent;
            this.IsSetTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IsSetTime.Checked = true;
            this.IsSetTime.Location = new System.Drawing.Point(18, 14);
            this.IsSetTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IsSetTime.Name = "IsSetTime";
            this.IsSetTime.Size = new System.Drawing.Size(138, 24);
            this.IsSetTime.TabIndex = 0;
            this.IsSetTime.Text = "是否定时运行";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 90);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 20);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "执行时间:";
            // 
            // DefTime
            // 
            this.DefTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefTime.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefTime.Location = new System.Drawing.Point(122, 90);
            this.DefTime.Name = "DefTime";
            this.DefTime.Size = new System.Drawing.Size(206, 27);
            this.DefTime.TabIndex = 3;
            this.DefTime.Text = "02:00:00";
            this.DefTime.WaterText = "";
            // 
            // EvertTime
            // 
            this.EvertTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EvertTime.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EvertTime.Location = new System.Drawing.Point(122, 139);
            this.EvertTime.Name = "EvertTime";
            this.EvertTime.Size = new System.Drawing.Size(72, 27);
            this.EvertTime.TabIndex = 4;
            this.EvertTime.Text = "2";
            this.EvertTime.WaterText = "";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(18, 139);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(23, 20);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "每";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(200, 146);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(93, 20);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "小时运行一次";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "设定";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(339, 180);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 37);
            this.Save.TabIndex = 9;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 220);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.EvertTime);
            this.Controls.Add(this.DefTime);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.IsSetTime);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetTime";
            this.Text = "SetTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Controls.DMCheckBox IsSetTime;
        private DMSkin.Metro.Controls.MetroLabel metroLabel2;
        private DMSkin.Controls.DMTextBox DefTime;
        private DMSkin.Controls.DMTextBox EvertTime;
        private DMSkin.Metro.Controls.MetroLabel metroLabel3;
        private DMSkin.Metro.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
    }
}