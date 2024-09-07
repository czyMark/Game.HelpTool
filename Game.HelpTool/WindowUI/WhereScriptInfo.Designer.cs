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
            this.WhereinfoTxt = new System.Windows.Forms.RichTextBox();
            this.NoneWhereRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.GreaterWhereRadio = new System.Windows.Forms.RadioButton();
            this.LessWhereRadio = new System.Windows.Forms.RadioButton();
            this.EqualWhereRadio = new System.Windows.Forms.RadioButton();
            this.ContainsWhereRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ImageTxt = new System.Windows.Forms.RichTextBox();
            this.KeyWhereRadio = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.NoContainsWhereRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(497, 303);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 5;
            this.ConfirmBtn.Text = "确认";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(596, 303);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "取消";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // WhereinfoTxt
            // 
            this.WhereinfoTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WhereinfoTxt.Location = new System.Drawing.Point(441, 140);
            this.WhereinfoTxt.Name = "WhereinfoTxt";
            this.WhereinfoTxt.Size = new System.Drawing.Size(397, 145);
            this.WhereinfoTxt.TabIndex = 12;
            this.WhereinfoTxt.Text = "";
            // 
            // NoneWhereRadio
            // 
            this.NoneWhereRadio.AutoSize = true;
            this.NoneWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NoneWhereRadio.Location = new System.Drawing.Point(441, 21);
            this.NoneWhereRadio.Name = "NoneWhereRadio";
            this.NoneWhereRadio.Size = new System.Drawing.Size(107, 16);
            this.NoneWhereRadio.TabIndex = 13;
            this.NoneWhereRadio.Text = "内容做拼接操作";
            this.NoneWhereRadio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(370, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "识别方式：";
            // 
            // GreaterWhereRadio
            // 
            this.GreaterWhereRadio.AutoSize = true;
            this.GreaterWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GreaterWhereRadio.Location = new System.Drawing.Point(596, 65);
            this.GreaterWhereRadio.Name = "GreaterWhereRadio";
            this.GreaterWhereRadio.Size = new System.Drawing.Size(149, 16);
            this.GreaterWhereRadio.TabIndex = 13;
            this.GreaterWhereRadio.Text = "判断值是否大于N(数字)";
            this.GreaterWhereRadio.UseVisualStyleBackColor = true;
            // 
            // LessWhereRadio
            // 
            this.LessWhereRadio.AutoSize = true;
            this.LessWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LessWhereRadio.Location = new System.Drawing.Point(596, 21);
            this.LessWhereRadio.Name = "LessWhereRadio";
            this.LessWhereRadio.Size = new System.Drawing.Size(149, 16);
            this.LessWhereRadio.TabIndex = 13;
            this.LessWhereRadio.Text = "判断值是否小于N(数字)";
            this.LessWhereRadio.UseVisualStyleBackColor = true;
            // 
            // EqualWhereRadio
            // 
            this.EqualWhereRadio.AutoSize = true;
            this.EqualWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EqualWhereRadio.Location = new System.Drawing.Point(596, 43);
            this.EqualWhereRadio.Name = "EqualWhereRadio";
            this.EqualWhereRadio.Size = new System.Drawing.Size(149, 16);
            this.EqualWhereRadio.TabIndex = 13;
            this.EqualWhereRadio.Text = "判断值是否等于N(数字)";
            this.EqualWhereRadio.UseVisualStyleBackColor = true;
            // 
            // ContainsWhereRadio
            // 
            this.ContainsWhereRadio.AutoSize = true;
            this.ContainsWhereRadio.Checked = true;
            this.ContainsWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ContainsWhereRadio.Location = new System.Drawing.Point(441, 43);
            this.ContainsWhereRadio.Name = "ContainsWhereRadio";
            this.ContainsWhereRadio.Size = new System.Drawing.Size(107, 16);
            this.ContainsWhereRadio.TabIndex = 13;
            this.ContainsWhereRadio.TabStop = true;
            this.ContainsWhereRadio.Text = "内容出现XX通过";
            this.ContainsWhereRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(370, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "判断值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "—————————————————————————————————————————————";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(605, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "——————————————————————————————————————————————————";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "当前识别内容：";
            // 
            // ImageTxt
            // 
            this.ImageTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageTxt.Location = new System.Drawing.Point(5, 24);
            this.ImageTxt.Name = "ImageTxt";
            this.ImageTxt.ReadOnly = true;
            this.ImageTxt.Size = new System.Drawing.Size(342, 311);
            this.ImageTxt.TabIndex = 12;
            this.ImageTxt.Text = "";
            // 
            // KeyWhereRadio
            // 
            this.KeyWhereRadio.AutoSize = true;
            this.KeyWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.KeyWhereRadio.Location = new System.Drawing.Point(441, 87);
            this.KeyWhereRadio.Name = "KeyWhereRadio";
            this.KeyWhereRadio.Size = new System.Drawing.Size(137, 16);
            this.KeyWhereRadio.TabIndex = 13;
            this.KeyWhereRadio.Text = "键盘按下XX时 不等待";
            this.KeyWhereRadio.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 372);
            this.label11.TabIndex = 28;
            this.label11.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n" +
    "|\r\n|\r\n|\r\n|\r\n";
            // 
            // NoContainsWhereRadio
            // 
            this.NoContainsWhereRadio.AutoSize = true;
            this.NoContainsWhereRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NoContainsWhereRadio.Location = new System.Drawing.Point(441, 65);
            this.NoContainsWhereRadio.Name = "NoContainsWhereRadio";
            this.NoContainsWhereRadio.Size = new System.Drawing.Size(119, 16);
            this.NoContainsWhereRadio.TabIndex = 13;
            this.NoContainsWhereRadio.Text = "内容不出现xx通过";
            this.NoContainsWhereRadio.UseVisualStyleBackColor = true;
            // 
            // WhereScriptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 339);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ContainsWhereRadio);
            this.Controls.Add(this.NoContainsWhereRadio);
            this.Controls.Add(this.KeyWhereRadio);
            this.Controls.Add(this.EqualWhereRadio);
            this.Controls.Add(this.LessWhereRadio);
            this.Controls.Add(this.GreaterWhereRadio);
            this.Controls.Add(this.NoneWhereRadio);
            this.Controls.Add(this.ImageTxt);
            this.Controls.Add(this.WhereinfoTxt);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.RichTextBox WhereinfoTxt;
        private System.Windows.Forms.RadioButton NoneWhereRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton GreaterWhereRadio;
        private System.Windows.Forms.RadioButton LessWhereRadio;
        private System.Windows.Forms.RadioButton EqualWhereRadio;
        private System.Windows.Forms.RadioButton ContainsWhereRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox ImageTxt;
        private System.Windows.Forms.RadioButton KeyWhereRadio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton NoContainsWhereRadio;
    }
}