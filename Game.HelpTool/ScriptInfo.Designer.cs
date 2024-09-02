namespace Game.HelpTool
{
    partial class ScriptInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.ScriptNameTxt = new System.Windows.Forms.TextBox();
            this.ScriptState = new System.Windows.Forms.CheckBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ScriptOrderTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SX = new System.Windows.Forms.TextBox();
            this.SY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ScriptNameTxt
            // 
            resources.ApplyResources(this.ScriptNameTxt, "ScriptNameTxt");
            this.ScriptNameTxt.Name = "ScriptNameTxt";
            // 
            // ScriptState
            // 
            resources.ApplyResources(this.ScriptState, "ScriptState");
            this.ScriptState.Name = "ScriptState";
            this.ScriptState.UseVisualStyleBackColor = true;
            // 
            // ConfirmBtn
            // 
            resources.ApplyResources(this.ConfirmBtn, "ConfirmBtn");
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ExitBtn
            // 
            resources.ApplyResources(this.ExitBtn, "ExitBtn");
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ScriptOrderTxt
            // 
            resources.ApplyResources(this.ScriptOrderTxt, "ScriptOrderTxt");
            this.ScriptOrderTxt.Name = "ScriptOrderTxt";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SX
            // 
            resources.ApplyResources(this.SX, "SX");
            this.SX.Name = "SX";
            // 
            // SY
            // 
            resources.ApplyResources(this.SY, "SY");
            this.SY.Name = "SY";
            // 
            // ScriptInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SY);
            this.Controls.Add(this.SX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScriptOrderTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.ScriptState);
            this.Controls.Add(this.ScriptNameTxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ScriptNameTxt;
        private System.Windows.Forms.CheckBox ScriptState;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox ScriptOrderTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SX;
        private System.Windows.Forms.TextBox SY;
    }
}