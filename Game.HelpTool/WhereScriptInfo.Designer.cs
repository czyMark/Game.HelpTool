namespace Game.HelpTool
{
    partial class WhereScriptInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhereScriptInfo));
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.WhereSelectBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WhereinfoinfoTxt = new System.Windows.Forms.RichTextBox();
            this.WhereIntTxt = new System.Windows.Forms.TextBox();
            this.WhereOrderTxt = new System.Windows.Forms.TextBox();
            this.OperLogbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(193, 325);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 5;
            this.ConfirmBtn.Text = "确认";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(291, 325);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "取消";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // WhereSelectBox
            // 
            this.WhereSelectBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WhereSelectBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.WhereSelectBox.FormattingEnabled = true;
            this.WhereSelectBox.Items.AddRange(new object[] {
            "0-重新从第一个开始",
            "1-从第N个开始",
            "2-按顺序从开始获取第N个值",
            "3-按顺序从最后开始获取第N个值",
            "4-到N个值结束",
            "5-最后往前数N个值结束",
            "6-对获取到的值操作+",
            "7-开始后判断大到小顺序执行",
            "8-开始后判断小到大顺序执行",
            "9-每当图中出现XX执行"});
            this.WhereSelectBox.Location = new System.Drawing.Point(0, 0);
            this.WhereSelectBox.Name = "WhereSelectBox";
            this.WhereSelectBox.Size = new System.Drawing.Size(185, 360);
            this.WhereSelectBox.Sorted = true;
            this.WhereSelectBox.TabIndex = 8;
            this.WhereSelectBox.SelectedIndexChanged += new System.EventHandler(this.WhereSelectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "顺序:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "下一个条件等待(秒):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "操作内容:";
            // 
            // WhereinfoinfoTxt
            // 
            this.WhereinfoinfoTxt.Location = new System.Drawing.Point(193, 112);
            this.WhereinfoinfoTxt.Name = "WhereinfoinfoTxt";
            this.WhereinfoinfoTxt.Size = new System.Drawing.Size(173, 178);
            this.WhereinfoinfoTxt.TabIndex = 12;
            this.WhereinfoinfoTxt.Text = "";
            // 
            // WhereIntTxt
            // 
            this.WhereIntTxt.Location = new System.Drawing.Point(193, 64);
            this.WhereIntTxt.Name = "WhereIntTxt";
            this.WhereIntTxt.Size = new System.Drawing.Size(173, 21);
            this.WhereIntTxt.TabIndex = 13;
            // 
            // WhereOrderTxt
            // 
            this.WhereOrderTxt.Location = new System.Drawing.Point(193, 24);
            this.WhereOrderTxt.Name = "WhereOrderTxt";
            this.WhereOrderTxt.Size = new System.Drawing.Size(173, 21);
            this.WhereOrderTxt.TabIndex = 14;
            // 
            // OperLogbtn
            // 
            this.OperLogbtn.Location = new System.Drawing.Point(193, 296);
            this.OperLogbtn.Name = "OperLogbtn";
            this.OperLogbtn.Size = new System.Drawing.Size(173, 23);
            this.OperLogbtn.TabIndex = 15;
            this.OperLogbtn.Text = "移动到";
            this.OperLogbtn.UseVisualStyleBackColor = true;
            this.OperLogbtn.Click += new System.EventHandler(this.OperLogbtn_Click);
            // 
            // WhereScriptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 360);
            this.Controls.Add(this.OperLogbtn);
            this.Controls.Add(this.WhereOrderTxt);
            this.Controls.Add(this.WhereIntTxt);
            this.Controls.Add(this.WhereinfoinfoTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WhereSelectBox);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WhereScriptInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条件信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.CheckedListBox WhereSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox WhereinfoinfoTxt;
        private System.Windows.Forms.TextBox WhereIntTxt;
        private System.Windows.Forms.TextBox WhereOrderTxt;
        private System.Windows.Forms.Button OperLogbtn;
    }
}