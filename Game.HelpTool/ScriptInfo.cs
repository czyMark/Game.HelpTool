using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public partial class ScriptInfo : Form
    {
        public string FileName;
        public double ScriptOrder;
        public int FileState;
        public int SXWidth;
        public int SYHeight;
        public ScriptInfo()
        {
            InitializeComponent();
            SX.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            SY.Text = Screen.PrimaryScreen.Bounds.Height.ToString();
        }
        /// <summary>
        /// 初始化脚本表单
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ScriptOrder"></param>
        /// <param name="FileState"></param>
        public ScriptInfo(string FileName, string ScriptOrder, bool FileState, string SWidth, string SHeight)
        {
            InitializeComponent();
            ScriptNameTxt.Text = FileName;
            ScriptOrderTxt.Text = ScriptOrder;
            ScriptState.Checked = FileState;
            SX.Text = SWidth;
            SY.Text = SHeight;
            SX.Enabled = true;
            SY.Enabled = true;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ScriptNameTxt.Text))
            {
                MessageBox.Show("脚本名称不能为空！");
                return;
            }
            if (!double.TryParse(ScriptOrderTxt.Text, out ScriptOrder))
            {
                MessageBox.Show("脚本顺序必须是数字！");
            }
            int tmpx=0;
            int tmpy=0;
            if (!int.TryParse(SX.Text, out tmpx) || !int.TryParse(SY.Text, out tmpy))
            {
                MessageBox.Show("屏幕分辨率必须是数字！");
            }
            if (ScriptState.Checked)
            {
                FileState = 1;
            }
            FileName = ScriptNameTxt.Text;
            this.DialogResult = DialogResult.OK;
            this.SXWidth = int.Parse(SX.Text);
            this.SYHeight = int.Parse(SY.Text);
            this.Close();
        }
    }
}
