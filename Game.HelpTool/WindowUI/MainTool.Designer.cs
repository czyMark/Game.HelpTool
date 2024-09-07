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
            this.ForStartExe = new System.Windows.Forms.Button();
            this.ScriptListView = new System.Windows.Forms.ListView();
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
            this.SelectAllForStartExe = new System.Windows.Forms.Button();
            this.EditScriptDetailInfobtn = new System.Windows.Forms.Button();
            this.ScriptDelayTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckScriptFolder = new System.Windows.Forms.Button();
            this.ScreenLine = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ScreenLineYTxt = new System.Windows.Forms.TextBox();
            this.AddWhereBtn = new System.Windows.Forms.Button();
            this.FindPix = new System.Windows.Forms.Button();
            this.AddColorWhereBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AllForStartExe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GlobalScriptPlanBtn = new System.Windows.Forms.Button();
            this.DefaultScriptPlanBtn = new System.Windows.Forms.Button();
            this.StatExebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartExe
            // 
            this.StartExe.Location = new System.Drawing.Point(189, 470);
            this.StartExe.Name = "StartExe";
            this.StartExe.Size = new System.Drawing.Size(125, 23);
            this.StartExe.TabIndex = 0;
            this.StartExe.Text = "执行单次";
            this.StartExe.UseVisualStyleBackColor = true;
            this.StartExe.Click += new System.EventHandler(this.StartExe_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(597, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "选择模拟器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.CheckFile_Click);
            // 
            // FileExePath
            // 
            this.FileExePath.Location = new System.Drawing.Point(702, 630);
            this.FileExePath.Name = "FileExePath";
            this.FileExePath.Size = new System.Drawing.Size(84, 21);
            this.FileExePath.TabIndex = 3;
            this.FileExePath.Text = "C://";
            this.FileExePath.Visible = false;
            // 
            // ForStartExe
            // 
            this.ForStartExe.Location = new System.Drawing.Point(320, 470);
            this.ForStartExe.Name = "ForStartExe";
            this.ForStartExe.Size = new System.Drawing.Size(109, 23);
            this.ForStartExe.TabIndex = 5;
            this.ForStartExe.Text = "循环执行";
            this.ForStartExe.UseVisualStyleBackColor = true;
            this.ForStartExe.Click += new System.EventHandler(this.ForStartExe_Click);
            // 
            // ScriptListView
            // 
            this.ScriptListView.HideSelection = false;
            this.ScriptListView.Location = new System.Drawing.Point(5, 85);
            this.ScriptListView.Name = "ScriptListView";
            this.ScriptListView.Size = new System.Drawing.Size(788, 334);
            this.ScriptListView.TabIndex = 7;
            this.ScriptListView.UseCompatibleStateImageBehavior = false;
            this.ScriptListView.SelectedIndexChanged += new System.EventHandler(this.ScriptListView_SelectedIndexChanged);
            this.ScriptListView.DoubleClick += new System.EventHandler(this.ScriptListView_DoubleClick);
            this.ScriptListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScriptListView_MouseClick);
            // 
            // MakeScriptBtn
            // 
            this.MakeScriptBtn.Location = new System.Drawing.Point(6, 56);
            this.MakeScriptBtn.Name = "MakeScriptBtn";
            this.MakeScriptBtn.Size = new System.Drawing.Size(92, 23);
            this.MakeScriptBtn.TabIndex = 9;
            this.MakeScriptBtn.Text = "录制脚本";
            this.MakeScriptBtn.UseVisualStyleBackColor = true;
            this.MakeScriptBtn.Click += new System.EventHandler(this.MakeScriptBtn_Click);
            // 
            // CheckScriptBtn
            // 
            this.CheckScriptBtn.Location = new System.Drawing.Point(104, 12);
            this.CheckScriptBtn.Name = "CheckScriptBtn";
            this.CheckScriptBtn.Size = new System.Drawing.Size(111, 23);
            this.CheckScriptBtn.TabIndex = 10;
            this.CheckScriptBtn.Text = "选择脚本执行";
            this.CheckScriptBtn.UseVisualStyleBackColor = true;
            this.CheckScriptBtn.Click += new System.EventHandler(this.CheckScriptBtn_Click);
            // 
            // FindScript
            // 
            this.FindScript.Location = new System.Drawing.Point(6, 12);
            this.FindScript.Name = "FindScript";
            this.FindScript.Size = new System.Drawing.Size(92, 23);
            this.FindScript.TabIndex = 11;
            this.FindScript.Text = "刷新脚本列表";
            this.FindScript.UseVisualStyleBackColor = true;
            this.FindScript.Click += new System.EventHandler(this.FindScript_Click);
            // 
            // CountNumTxt
            // 
            this.CountNumTxt.Location = new System.Drawing.Point(70, 502);
            this.CountNumTxt.Name = "CountNumTxt";
            this.CountNumTxt.Size = new System.Drawing.Size(113, 21);
            this.CountNumTxt.TabIndex = 12;
            this.CountNumTxt.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 505);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "计数器：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "脚本名称：";
            // 
            // ExceScriptName
            // 
            this.ExceScriptName.Enabled = false;
            this.ExceScriptName.Location = new System.Drawing.Point(70, 427);
            this.ExceScriptName.Name = "ExceScriptName";
            this.ExceScriptName.Size = new System.Drawing.Size(423, 21);
            this.ExceScriptName.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "删除选中脚本";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteScriptbtn_Click);
            // 
            // EditScriptInfobtn
            // 
            this.EditScriptInfobtn.Location = new System.Drawing.Point(499, 425);
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
            this.label6.Location = new System.Drawing.Point(3, 547);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 112);
            this.label6.TabIndex = 18;
            this.label6.Text = "录制脚本说明：\r\n1-F8是生成Guid输入\r\n2-F9是在循环执行时写入计数\r\n3-F10可停止录制并生成脚本\r\n4-F11是输出图片识别缓存内容\r\n5-录制扩" +
    "展脚本需要在左上角屏幕范围内操作\r\n6-增加条件时 双击或者Enter可确认截图区域";
            // 
            // ScreenLineXTxt
            // 
            this.ScreenLineXTxt.Location = new System.Drawing.Point(480, 58);
            this.ScreenLineXTxt.Name = "ScreenLineXTxt";
            this.ScreenLineXTxt.Size = new System.Drawing.Size(59, 21);
            this.ScreenLineXTxt.TabIndex = 19;
            this.ScreenLineXTxt.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "脚本扩展：";
            // 
            // SelectAllForStartExe
            // 
            this.SelectAllForStartExe.Location = new System.Drawing.Point(320, 500);
            this.SelectAllForStartExe.Name = "SelectAllForStartExe";
            this.SelectAllForStartExe.Size = new System.Drawing.Size(181, 23);
            this.SelectAllForStartExe.TabIndex = 21;
            this.SelectAllForStartExe.Text = "从选中脚本按顺序循环所有脚本";
            this.SelectAllForStartExe.UseVisualStyleBackColor = true;
            this.SelectAllForStartExe.Click += new System.EventHandler(this.SelectAllForStartExe_Click);
            // 
            // EditScriptDetailInfobtn
            // 
            this.EditScriptDetailInfobtn.Location = new System.Drawing.Point(695, 425);
            this.EditScriptDetailInfobtn.Name = "EditScriptDetailInfobtn";
            this.EditScriptDetailInfobtn.Size = new System.Drawing.Size(92, 23);
            this.EditScriptDetailInfobtn.TabIndex = 22;
            this.EditScriptDetailInfobtn.Text = "修改具体信息";
            this.EditScriptDetailInfobtn.UseVisualStyleBackColor = true;
            this.EditScriptDetailInfobtn.Visible = false;
            this.EditScriptDetailInfobtn.Click += new System.EventHandler(this.EditScriptDetailInfobtn_Click);
            // 
            // ScriptDelayTxt
            // 
            this.ScriptDelayTxt.Location = new System.Drawing.Point(70, 472);
            this.ScriptDelayTxt.Name = "ScriptDelayTxt";
            this.ScriptDelayTxt.Size = new System.Drawing.Size(113, 21);
            this.ScriptDelayTxt.TabIndex = 19;
            this.ScriptDelayTxt.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 475);
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
            this.ScreenLine.Location = new System.Drawing.Point(611, 58);
            this.ScreenLine.Name = "ScreenLine";
            this.ScreenLine.Size = new System.Drawing.Size(78, 23);
            this.ScreenLine.TabIndex = 24;
            this.ScreenLine.Text = "显示位置";
            this.ScreenLine.UseVisualStyleBackColor = true;
            this.ScreenLine.Click += new System.EventHandler(this.ScreenLine_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(367, 547);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(280, 80);
            this.label10.TabIndex = 26;
            this.label10.Text = "运行脚本说明：\r\n1-F5退出正在执行的脚本\r\n2-F6脚本执行暂停\r\n3-F7脚本继续执行\r\n3-只有循环所有脚本才会执行全局脚本";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(346, 535);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 144);
            this.label11.TabIndex = 27;
            this.label11.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // ScreenLineYTxt
            // 
            this.ScreenLineYTxt.Location = new System.Drawing.Point(545, 58);
            this.ScreenLineYTxt.Name = "ScreenLineYTxt";
            this.ScreenLineYTxt.Size = new System.Drawing.Size(60, 21);
            this.ScreenLineYTxt.TabIndex = 28;
            this.ScreenLineYTxt.Text = "1";
            // 
            // AddWhereBtn
            // 
            this.AddWhereBtn.Location = new System.Drawing.Point(104, 56);
            this.AddWhereBtn.Name = "AddWhereBtn";
            this.AddWhereBtn.Size = new System.Drawing.Size(111, 23);
            this.AddWhereBtn.TabIndex = 29;
            this.AddWhereBtn.Text = "增加图中文字条件";
            this.AddWhereBtn.UseVisualStyleBackColor = true;
            this.AddWhereBtn.Click += new System.EventHandler(this.AddWhereBtn_Click);
            // 
            // FindPix
            // 
            this.FindPix.Location = new System.Drawing.Point(695, 58);
            this.FindPix.Name = "FindPix";
            this.FindPix.Size = new System.Drawing.Size(99, 23);
            this.FindPix.TabIndex = 30;
            this.FindPix.Text = "寻找屏幕坐标";
            this.FindPix.UseVisualStyleBackColor = true;
            this.FindPix.Click += new System.EventHandler(this.FindPix_Click);
            // 
            // AddColorWhereBtn
            // 
            this.AddColorWhereBtn.Location = new System.Drawing.Point(222, 56);
            this.AddColorWhereBtn.Name = "AddColorWhereBtn";
            this.AddColorWhereBtn.Size = new System.Drawing.Size(92, 23);
            this.AddColorWhereBtn.TabIndex = 29;
            this.AddColorWhereBtn.Text = "增加颜色条件";
            this.AddColorWhereBtn.UseVisualStyleBackColor = true;
            this.AddColorWhereBtn.Click += new System.EventHandler(this.AddColorWhereBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(-4, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(807, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "——————————————————————————————————————————";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(-5, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(807, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "——————————————————————————————————————————";
            // 
            // AllForStartExe
            // 
            this.AllForStartExe.Location = new System.Drawing.Point(190, 500);
            this.AllForStartExe.Name = "AllForStartExe";
            this.AllForStartExe.Size = new System.Drawing.Size(124, 23);
            this.AllForStartExe.TabIndex = 21;
            this.AllForStartExe.Text = "按顺序循环所有脚本";
            this.AllForStartExe.UseVisualStyleBackColor = true;
            this.AllForStartExe.Click += new System.EventHandler(this.AllForStartExe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(-4, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(807, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "——————————————————————————————————————————";
            // 
            // GlobalScriptPlanBtn
            // 
            this.GlobalScriptPlanBtn.Location = new System.Drawing.Point(690, 12);
            this.GlobalScriptPlanBtn.Name = "GlobalScriptPlanBtn";
            this.GlobalScriptPlanBtn.Size = new System.Drawing.Size(103, 23);
            this.GlobalScriptPlanBtn.TabIndex = 23;
            this.GlobalScriptPlanBtn.Text = "切换到全局脚本文件夹";
            this.GlobalScriptPlanBtn.UseVisualStyleBackColor = true;
            this.GlobalScriptPlanBtn.Click += new System.EventHandler(this.GlobalScriptPlanBtn_Click);
            // 
            // DefaultScriptPlanBtn
            // 
            this.DefaultScriptPlanBtn.Location = new System.Drawing.Point(581, 12);
            this.DefaultScriptPlanBtn.Name = "DefaultScriptPlanBtn";
            this.DefaultScriptPlanBtn.Size = new System.Drawing.Size(103, 23);
            this.DefaultScriptPlanBtn.TabIndex = 23;
            this.DefaultScriptPlanBtn.Text = "切换到默认脚本文件夹";
            this.DefaultScriptPlanBtn.UseVisualStyleBackColor = true;
            this.DefaultScriptPlanBtn.Click += new System.EventHandler(this.DefaultScriptPlanBtn_Click);
            // 
            // StatExebtn
            // 
            this.StatExebtn.Location = new System.Drawing.Point(320, 56);
            this.StatExebtn.Name = "StatExebtn";
            this.StatExebtn.Size = new System.Drawing.Size(92, 23);
            this.StatExebtn.TabIndex = 31;
            this.StatExebtn.Text = "录制启动程序";
            this.StatExebtn.UseVisualStyleBackColor = true;
            this.StatExebtn.Click += new System.EventHandler(this.StatExebtn_Click);
            // 
            // MainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 663);
            this.Controls.Add(this.StatExebtn);
            this.Controls.Add(this.FindPix);
            this.Controls.Add(this.AddColorWhereBtn);
            this.Controls.Add(this.AddWhereBtn);
            this.Controls.Add(this.ScreenLineYTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScreenLine);
            this.Controls.Add(this.DefaultScriptPlanBtn);
            this.Controls.Add(this.GlobalScriptPlanBtn);
            this.Controls.Add(this.CheckScriptFolder);
            this.Controls.Add(this.EditScriptDetailInfobtn);
            this.Controls.Add(this.AllForStartExe);
            this.Controls.Add(this.SelectAllForStartExe);
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
            this.Controls.Add(this.ScriptListView);
            this.Controls.Add(this.ForStartExe);
            this.Controls.Add(this.FileExePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StartExe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "飞鸿羽翼，展翅翱翔";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartExe;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FileExePath;
        private System.Windows.Forms.Button ForStartExe;
        private System.Windows.Forms.ListView ScriptListView;
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
        private System.Windows.Forms.Button SelectAllForStartExe;
        private System.Windows.Forms.Button EditScriptDetailInfobtn;
        private System.Windows.Forms.TextBox ScriptDelayTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CheckScriptFolder;
        private System.Windows.Forms.Button ScreenLine;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ScreenLineYTxt;
        private System.Windows.Forms.Button AddWhereBtn;
        private System.Windows.Forms.Button FindPix;
        private System.Windows.Forms.Button AddColorWhereBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AllForStartExe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GlobalScriptPlanBtn;
        private System.Windows.Forms.Button DefaultScriptPlanBtn;
        private System.Windows.Forms.ContextMenuStrip ListStrip = new System.Windows.Forms.ContextMenuStrip();//列表菜单
        private System.Windows.Forms.Button StatExebtn;
    }
}

