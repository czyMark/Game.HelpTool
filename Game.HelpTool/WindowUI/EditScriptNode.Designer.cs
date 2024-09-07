namespace Game.HelpTool
{
    partial class EditScriptNode
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Execbtn = new System.Windows.Forms.Button();
            this.Cannlbtn = new System.Windows.Forms.Button();
            this.OperationListView = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.OperationListView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.888889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Addbtn);
            this.flowLayoutPanel1.Controls.Add(this.Resetbtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(803, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(3, 3);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(81, 39);
            this.Addbtn.TabIndex = 0;
            this.Addbtn.Text = "添加操作";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Resetbtn
            // 
            this.Resetbtn.Location = new System.Drawing.Point(90, 3);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(116, 39);
            this.Resetbtn.TabIndex = 1;
            this.Resetbtn.Text = "刷新操作信息";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.Execbtn);
            this.flowLayoutPanel2.Controls.Add(this.Cannlbtn);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 412);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(803, 35);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // Execbtn
            // 
            this.Execbtn.Location = new System.Drawing.Point(3, 3);
            this.Execbtn.Name = "Execbtn";
            this.Execbtn.Size = new System.Drawing.Size(192, 32);
            this.Execbtn.TabIndex = 2;
            this.Execbtn.Text = "执行一次（键盘操作延迟一秒）";
            this.Execbtn.UseVisualStyleBackColor = true;
            this.Execbtn.Click += new System.EventHandler(this.Execbtn_Click);
            // 
            // Cannlbtn
            // 
            this.Cannlbtn.Location = new System.Drawing.Point(201, 3);
            this.Cannlbtn.Name = "Cannlbtn";
            this.Cannlbtn.Size = new System.Drawing.Size(111, 32);
            this.Cannlbtn.TabIndex = 1;
            this.Cannlbtn.Text = "关闭当前窗口";
            this.Cannlbtn.UseVisualStyleBackColor = true;
            this.Cannlbtn.Click += new System.EventHandler(this.Cannlbtn_Click);
            // 
            // OperationListView
            // 
            this.OperationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationListView.HideSelection = false;
            this.OperationListView.Location = new System.Drawing.Point(3, 51);
            this.OperationListView.Name = "OperationListView";
            this.OperationListView.Size = new System.Drawing.Size(803, 355);
            this.OperationListView.TabIndex = 4;
            this.OperationListView.UseCompatibleStateImageBehavior = false;
            this.OperationListView.SelectedIndexChanged += new System.EventHandler(this.OperationListView_SelectedIndexChanged);
            this.OperationListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OperationListView_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(318, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(480, 32);
            this.label6.TabIndex = 19;
            this.label6.Text = "录制脚本说明：\r\n1-F8是生成Guid输入 2-F9是在循环执行时写入计数 3-F10确认操作";
            // 
            // EditScriptNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditScriptNode";
            this.Text = "修改脚本操作";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button Execbtn;
        private System.Windows.Forms.Button Cannlbtn;
        private System.Windows.Forms.ListView OperationListView;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.ContextMenuStrip ListStrip = new System.Windows.Forms.ContextMenuStrip();//列表菜单
        private System.Windows.Forms.Label label6;
    }
}