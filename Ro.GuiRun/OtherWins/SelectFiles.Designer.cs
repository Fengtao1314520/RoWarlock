namespace Ro.GuiRun.OtherWins
{
    partial class SelectFiles
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
            this.rosB = new DMSkin.Metro.Controls.MetroButton();
            this.roiB = new DMSkin.Metro.Controls.MetroButton();
            this.rocB = new DMSkin.Metro.Controls.MetroButton();
            this.rosT = new DMSkin.Controls.DMTextBox();
            this.roiT = new DMSkin.Controls.DMTextBox();
            this.rocT = new DMSkin.Controls.DMTextBox();
            this.Save = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // rosB
            // 
            this.rosB.DM_UseSelectable = true;
            this.rosB.Location = new System.Drawing.Point(7, 62);
            this.rosB.Name = "rosB";
            this.rosB.Size = new System.Drawing.Size(85, 23);
            this.rosB.TabIndex = 0;
            this.rosB.Text = "选择Ros文件";
            this.rosB.Click += new System.EventHandler(this.rosB_Click);
            // 
            // roiB
            // 
            this.roiB.DM_UseSelectable = true;
            this.roiB.Location = new System.Drawing.Point(7, 145);
            this.roiB.Name = "roiB";
            this.roiB.Size = new System.Drawing.Size(85, 23);
            this.roiB.TabIndex = 1;
            this.roiB.Text = "选择Roi文件";
            this.roiB.Click += new System.EventHandler(this.roiB_Click);
            // 
            // rocB
            // 
            this.rocB.DM_UseSelectable = true;
            this.rocB.Location = new System.Drawing.Point(7, 223);
            this.rocB.Name = "rocB";
            this.rocB.Size = new System.Drawing.Size(85, 23);
            this.rocB.TabIndex = 2;
            this.rocB.Text = "选择Roc文件";
            this.rocB.Click += new System.EventHandler(this.rocB_Click);
            // 
            // rosT
            // 
            this.rosT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rosT.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rosT.Location = new System.Drawing.Point(98, 62);
            this.rosT.Name = "rosT";
            this.rosT.Size = new System.Drawing.Size(544, 23);
            this.rosT.TabIndex = 3;
            this.rosT.WaterText = "";
            // 
            // roiT
            // 
            this.roiT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roiT.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.roiT.Location = new System.Drawing.Point(98, 145);
            this.roiT.Name = "roiT";
            this.roiT.Size = new System.Drawing.Size(544, 23);
            this.roiT.TabIndex = 4;
            this.roiT.WaterText = "";
            // 
            // rocT
            // 
            this.rocT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rocT.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rocT.Location = new System.Drawing.Point(98, 223);
            this.rocT.Name = "rocT";
            this.rocT.Size = new System.Drawing.Size(544, 23);
            this.rocT.TabIndex = 5;
            this.rocT.WaterText = "";
            // 
            // Save
            // 
            this.Save.AutoSize = true;
            this.Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Save.Depth = 0;
            this.Save.Location = new System.Drawing.Point(569, 287);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Save.MouseState = MaterialSkin.MouseState.HOVER;
            this.Save.Name = "Save";
            this.Save.Primary = false;
            this.Save.Size = new System.Drawing.Size(73, 36);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存并关闭";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SelectFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 352);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.rocT);
            this.Controls.Add(this.roiT);
            this.Controls.Add(this.rosT);
            this.Controls.Add(this.rocB);
            this.Controls.Add(this.roiB);
            this.Controls.Add(this.rosB);
            this.Name = "SelectFiles";
            this.Text = "SelectFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Metro.Controls.MetroButton rosB;
        private DMSkin.Metro.Controls.MetroButton roiB;
        private DMSkin.Metro.Controls.MetroButton rocB;
        private DMSkin.Controls.DMTextBox rosT;
        private DMSkin.Controls.DMTextBox roiT;
        private DMSkin.Controls.DMTextBox rocT;
        private MaterialSkin.Controls.MaterialFlatButton Save;
    }
}