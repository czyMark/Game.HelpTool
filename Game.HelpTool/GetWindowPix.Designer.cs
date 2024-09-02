namespace Game.HelpTool
{
    partial class GetWindowPix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetWindowPix));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ListResetBtn = new System.Windows.Forms.Button();
            this.StartLogBtn = new System.Windows.Forms.Button();
            this.ExportJson = new System.Windows.Forms.Button();
            this.StopLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(0, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(501, 299);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ListResetBtn
            // 
            this.ListResetBtn.Location = new System.Drawing.Point(253, 12);
            this.ListResetBtn.Name = "ListResetBtn";
            this.ListResetBtn.Size = new System.Drawing.Size(115, 23);
            this.ListResetBtn.TabIndex = 1;
            this.ListResetBtn.Text = "清空重新记录";
            this.ListResetBtn.UseVisualStyleBackColor = true;
            this.ListResetBtn.Click += new System.EventHandler(this.ListResetBtn_Click);
            // 
            // StartLogBtn
            // 
            this.StartLogBtn.Location = new System.Drawing.Point(12, 12);
            this.StartLogBtn.Name = "StartLogBtn";
            this.StartLogBtn.Size = new System.Drawing.Size(115, 23);
            this.StartLogBtn.TabIndex = 2;
            this.StartLogBtn.Text = "开始记录";
            this.StartLogBtn.UseVisualStyleBackColor = true;
            this.StartLogBtn.Click += new System.EventHandler(this.StartLogBtn_Click);
            // 
            // ExportJson
            // 
            this.ExportJson.Location = new System.Drawing.Point(374, 13);
            this.ExportJson.Name = "ExportJson";
            this.ExportJson.Size = new System.Drawing.Size(115, 23);
            this.ExportJson.TabIndex = 3;
            this.ExportJson.Text = "导出查看";
            this.ExportJson.UseVisualStyleBackColor = true;
            this.ExportJson.Click += new System.EventHandler(this.ExportJson_Click);
            // 
            // StopLog
            // 
            this.StopLog.Location = new System.Drawing.Point(133, 13);
            this.StopLog.Name = "StopLog";
            this.StopLog.Size = new System.Drawing.Size(115, 23);
            this.StopLog.TabIndex = 4;
            this.StopLog.Text = "停止记录";
            this.StopLog.UseVisualStyleBackColor = true;
            this.StopLog.Click += new System.EventHandler(this.StopLog_Click);
            // 
            // GetWindowPix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 341);
            this.Controls.Add(this.StopLog);
            this.Controls.Add(this.ExportJson);
            this.Controls.Add(this.StartLogBtn);
            this.Controls.Add(this.ListResetBtn);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetWindowPix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "辅助获取屏幕坐标";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button ListResetBtn;
        private System.Windows.Forms.Button StartLogBtn;
        private System.Windows.Forms.Button ExportJson;
        private System.Windows.Forms.Button StopLog;
    }
}