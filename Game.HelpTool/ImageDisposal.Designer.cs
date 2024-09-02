namespace Game.HelpTool
{
    partial class ImageDisposal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDisposal));
            this.WhereListView = new System.Windows.Forms.ListView();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.EditWhereBtn = new System.Windows.Forms.Button();
            this.AddWhereStrBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WhereListView
            // 
            this.WhereListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WhereListView.Location = new System.Drawing.Point(0, 39);
            this.WhereListView.Name = "WhereListView";
            this.WhereListView.Size = new System.Drawing.Size(750, 411);
            this.WhereListView.TabIndex = 2;
            this.WhereListView.UseCompatibleStateImageBehavior = false;
            this.WhereListView.SelectedIndexChanged += new System.EventHandler(this.WhereListView_SelectedIndexChanged);
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(618, 12);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(53, 21);
            this.Confirmbtn.TabIndex = 10;
            this.Confirmbtn.Text = "确认";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(685, 12);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(53, 21);
            this.ClearBtn.TabIndex = 11;
            this.ClearBtn.Text = "取消";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // EditWhereBtn
            // 
            this.EditWhereBtn.Location = new System.Drawing.Point(100, 12);
            this.EditWhereBtn.Name = "EditWhereBtn";
            this.EditWhereBtn.Size = new System.Drawing.Size(98, 21);
            this.EditWhereBtn.TabIndex = 12;
            this.EditWhereBtn.Text = "编辑选中条件";
            this.EditWhereBtn.UseVisualStyleBackColor = true;
            this.EditWhereBtn.Click += new System.EventHandler(this.EditWhereBtn_Click);
            // 
            // AddWhereStrBtn
            // 
            this.AddWhereStrBtn.Location = new System.Drawing.Point(12, 12);
            this.AddWhereStrBtn.Name = "AddWhereStrBtn";
            this.AddWhereStrBtn.Size = new System.Drawing.Size(82, 21);
            this.AddWhereStrBtn.TabIndex = 0;
            this.AddWhereStrBtn.Text = "添加条件";
            this.AddWhereStrBtn.UseVisualStyleBackColor = true;
            this.AddWhereStrBtn.Click += new System.EventHandler(this.AddWhereStrBtn_Click);
            // 
            // ImageDisposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.EditWhereBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.WhereListView);
            this.Controls.Add(this.AddWhereStrBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageDisposal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像处理";
            this.Load += new System.EventHandler(this.ImageDisposal_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView WhereListView;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button EditWhereBtn;
        private System.Windows.Forms.Button AddWhereStrBtn;
    }
}