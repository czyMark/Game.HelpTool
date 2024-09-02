namespace Game.HelpTool
{
    partial class MainTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTool));
            this.StartExe = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.FileExePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ForStartExe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ScriptListView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.MakeScriptBtn = new System.Windows.Forms.Button();
            this.CheckScriptBtn = new System.Windows.Forms.Button();
            this.FindScript = new System.Windows.Forms.Button();
            this.CountNumTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExceScriptName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.EditScriptInfobtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ScreenLineXTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AllForStartExe = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ScriptDelayTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckScriptFolder = new System.Windows.Forms.Button();
            this.ScreenLine = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ScreenLineYTxt = new System.Windows.Forms.TextBox();
            this.SelectPositionBtn = new System.Windows.Forms.Button();
            this.FindPix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartExe
            // 
            this.StartExe.Location = new System.Drawing.Point(6, 439);
            this.StartExe.Name = "StartExe";
            this.StartExe.Size = new System.Drawing.Size(107, 23);
            this.StartExe.TabIndex = 0;
            this.StartExe.Text = "启动";
            this.StartExe.UseVisualStyleBackColor = true;
            this.StartExe.Click += new System.EventHandler(this.StartExe_Click);
            this.StartExe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(751, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "选择模拟器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.CheckFile_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // FileExePath
            // 
            this.FileExePath.Location = new System.Drawing.Point(767, 12);
            this.FileExePath.Name = "FileExePath";
            this.FileExePath.Size = new System.Drawing.Size(21, 21);
            this.FileExePath.TabIndex = 3;
            this.FileExePath.Text = "C://";
            this.FileExePath.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(797, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "——————————————————————————————————————————————————————————————————";
            // 
            // ForStartExe
            // 
            this.ForStartExe.Location = new System.Drawing.Point(119, 439);
            this.ForStartExe.Name = "ForStartExe";
            this.ForStartExe.Size = new System.Drawing.Size(107, 23);
            this.ForStartExe.TabIndex = 5;
            this.ForStartExe.Text = "循环启动";
            this.ForStartExe.UseVisualStyleBackColor = true;
            this.ForStartExe.Click += new System.EventHandler(this.ForStartExe_Click);
            this.ForStartExe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(797, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "——————————————————————————————————————————————————————————————————";
            // 
            // ScriptListView
            // 
            this.ScriptListView.Location = new System.Drawing.Point(6, 88);
            this.ScriptListView.Name = "ScriptListView";
            this.ScriptListView.Size = new System.Drawing.Size(788, 306);
            this.ScriptListView.TabIndex = 7;
            this.ScriptListView.UseCompatibleStateImageBehavior = false;
            this.ScriptListView.SelectedIndexChanged += new System.EventHandler(this.ScriptListView_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "请选择运行脚本：";
            // 
            // MakeScriptBtn
            // 
            this.MakeScriptBtn.Location = new System.Drawing.Point(331, 12);
            this.MakeScriptBtn.Name = "MakeScriptBtn";
            this.MakeScriptBtn.Size = new System.Drawing.Size(92, 23);
            this.MakeScriptBtn.TabIndex = 9;
            this.MakeScriptBtn.Text = "录制脚本";
            this.MakeScriptBtn.UseVisualStyleBackColor = true;
            this.MakeScriptBtn.Click += new System.EventHandler(this.MakeScriptBtn_Click);
            this.MakeScriptBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // CheckScriptBtn
            // 
            this.CheckScriptBtn.Location = new System.Drawing.Point(104, 12);
            this.CheckScriptBtn.Name = "CheckScriptBtn";
            this.CheckScriptBtn.Size = new System.Drawing.Size(111, 23);
            this.CheckScriptBtn.TabIndex = 10;
            this.CheckScriptBtn.Text = "选择本地脚本执行";
            this.CheckScriptBtn.UseVisualStyleBackColor = true;
            this.CheckScriptBtn.Click += new System.EventHandler(this.CheckScriptBtn_Click);
            // 
            // FindScript
            // 
            this.FindScript.Location = new System.Drawing.Point(6, 12);
            this.FindScript.Name = "FindScript";
            this.FindScript.Size = new System.Drawing.Size(92, 23);
            this.FindScript.TabIndex = 11;
            this.FindScript.Text = "加载默认脚本";
            this.FindScript.UseVisualStyleBackColor = true;
            this.FindScript.Click += new System.EventHandler(this.FindScript_Click);
            // 
            // CountNumTxt
            // 
            this.CountNumTxt.Location = new System.Drawing.Point(693, 401);
            this.CountNumTxt.Name = "CountNumTxt";
            this.CountNumTxt.Size = new System.Drawing.Size(99, 21);
            this.CountNumTxt.TabIndex = 12;
            this.CountNumTxt.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(637, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "计数器：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "运行脚本：";
            // 
            // ExceScriptName
            // 
            this.ExceScriptName.Enabled = false;
            this.ExceScriptName.Location = new System.Drawing.Point(72, 401);
            this.ExceScriptName.Name = "ExceScriptName";
            this.ExceScriptName.Size = new System.Drawing.Size(99, 21);
            this.ExceScriptName.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "删除选中脚本";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteScriptbtn_Click);
            // 
            // EditScriptInfobtn
            // 
            this.EditScriptInfobtn.Location = new System.Drawing.Point(205, 59);
            this.EditScriptInfobtn.Name = "EditScriptInfobtn";
            this.EditScriptInfobtn.Size = new System.Drawing.Size(92, 23);
            this.EditScriptInfobtn.TabIndex = 17;
            this.EditScriptInfobtn.Text = "修改脚本";
            this.EditScriptInfobtn.UseVisualStyleBackColor = true;
            this.EditScriptInfobtn.Click += new System.EventHandler(this.EditScriptInfobtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 128);
            this.label6.TabIndex = 18;
            this.label6.Text = "运行说明：\r\n1-在录制状态下按F10可停止录制生成脚本\r\n2-录制脚本时F8是生成Guid输入\r\n3-录制脚本时F9是在循环执行时写入计数\r\n4-在脚本启动状态" +
    "下按F11可停止脚本继续执行\r\n5-默认第一次脚本扩展是左右分屏\r\n6-F7为暂停\r\n7-F6为重新开始";
            // 
            // ScreenLineXTxt
            // 
            this.ScreenLineXTxt.Location = new System.Drawing.Point(247, 401);
            this.ScreenLineXTxt.Name = "ScreenLineXTxt";
            this.ScreenLineXTxt.Size = new System.Drawing.Size(59, 21);
            this.ScreenLineXTxt.TabIndex = 19;
            this.ScreenLineXTxt.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "脚本扩展：";
            // 
            // AllForStartExe
            // 
            this.AllForStartExe.Location = new System.Drawing.Point(232, 439);
            this.AllForStartExe.Name = "AllForStartExe";
            this.AllForStartExe.Size = new System.Drawing.Size(107, 23);
            this.AllForStartExe.TabIndex = 21;
            this.AllForStartExe.Text = "所有脚本并重复";
            this.AllForStartExe.UseVisualStyleBackColor = true;
            this.AllForStartExe.Click += new System.EventHandler(this.AllForStartExe_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(303, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "修改具体信息";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // ScriptDelayTxt
            // 
            this.ScriptDelayTxt.Location = new System.Drawing.Point(530, 401);
            this.ScriptDelayTxt.Name = "ScriptDelayTxt";
            this.ScriptDelayTxt.Size = new System.Drawing.Size(99, 21);
            this.ScriptDelayTxt.TabIndex = 19;
            this.ScriptDelayTxt.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "脚本延迟：";
            // 
            // CheckScriptFolder
            // 
            this.CheckScriptFolder.Location = new System.Drawing.Point(222, 12);
            this.CheckScriptFolder.Name = "CheckScriptFolder";
            this.CheckScriptFolder.Size = new System.Drawing.Size(103, 23);
            this.CheckScriptFolder.TabIndex = 23;
            this.CheckScriptFolder.Text = "选择脚本文件夹";
            this.CheckScriptFolder.UseVisualStyleBackColor = true;
            this.CheckScriptFolder.Click += new System.EventHandler(this.CheckScriptFolder_Click);
            // 
            // ScreenLine
            // 
            this.ScreenLine.Location = new System.Drawing.Point(378, 401);
            this.ScreenLine.Name = "ScreenLine";
            this.ScreenLine.Size = new System.Drawing.Size(78, 21);
            this.ScreenLine.TabIndex = 24;
            this.ScreenLine.Text = "显示位置";
            this.ScreenLine.UseVisualStyleBackColor = true;
            this.ScreenLine.Click += new System.EventHandler(this.ScreenLine_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-3, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(797, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "——————————————————————————————————————————————————————————————————";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(365, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(280, 32);
            this.label10.TabIndex = 26;
            this.label10.Text = "\r\n8-脚本扩展需要脚本需要在左上角录制";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 492);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 120);
            this.label11.TabIndex = 27;
            this.label11.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|";
            // 
            // ScreenLineYTxt
            // 
            this.ScreenLineYTxt.Location = new System.Drawing.Point(312, 401);
            this.ScreenLineYTxt.Name = "ScreenLineYTxt";
            this.ScreenLineYTxt.Size = new System.Drawing.Size(60, 21);
            this.ScreenLineYTxt.TabIndex = 28;
            this.ScreenLineYTxt.Text = "2";
            // 
            // SelectPositionBtn
            // 
            this.SelectPositionBtn.Location = new System.Drawing.Point(608, 12);
            this.SelectPositionBtn.Name = "SelectPositionBtn";
            this.SelectPositionBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectPositionBtn.TabIndex = 29;
            this.SelectPositionBtn.Text = "框选位置";
            this.SelectPositionBtn.UseVisualStyleBackColor = true;
            this.SelectPositionBtn.Click += new System.EventHandler(this.SelectPositionBtn_Click);
            // 
            // FindPix
            // 
            this.FindPix.Location = new System.Drawing.Point(689, 12);
            this.FindPix.Name = "FindPix";
            this.FindPix.Size = new System.Drawing.Size(103, 23);
            this.FindPix.TabIndex = 30;
            this.FindPix.Text = "寻找屏幕坐标";
            this.FindPix.UseVisualStyleBackColor = true;
            this.FindPix.Click += new System.EventHandler(this.FindPix_Click);
            // 
            // MainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.FindPix);
            this.Controls.Add(this.SelectPositionBtn);
            this.Controls.Add(this.ScreenLineYTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ScreenLine);
            this.Controls.Add(this.CheckScriptFolder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AllForStartExe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ScriptDelayTxt);
            this.Controls.Add(this.ScreenLineXTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EditScriptInfobtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExceScriptName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CountNumTxt);
            this.Controls.Add(this.FindScript);
            this.Controls.Add(this.CheckScriptBtn);
            this.Controls.Add(this.MakeScriptBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ScriptListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ForStartExe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileExePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StartExe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作记录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartExe;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FileExePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ForStartExe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView ScriptListView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MakeScriptBtn;
        private System.Windows.Forms.Button CheckScriptBtn;
        private System.Windows.Forms.Button FindScript;
        private System.Windows.Forms.TextBox CountNumTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExceScriptName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EditScriptInfobtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ScreenLineXTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AllForStartExe;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox ScriptDelayTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CheckScriptFolder;
        private System.Windows.Forms.Button ScreenLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ScreenLineYTxt;
        private System.Windows.Forms.Button SelectPositionBtn;
        private System.Windows.Forms.Button FindPix;
    }
}

