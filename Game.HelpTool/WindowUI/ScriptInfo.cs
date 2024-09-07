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
        public int WhereExecValue;
        public double ScriptOrder;
        public ScriptTypeData ScriptState;
        public bool ExecOrWhere;//false 执行脚本 true 条件脚本
        public int SXWidth;
        public int SYHeight;
        public ScriptInfo(double scriptOrder)
        {
            InitializeComponent();
            Screen screen = Screen.PrimaryScreen;
            Rectangle bounds = screen.Bounds;
            int width = bounds.Width;
            int height = bounds.Height;

            SX.Text = width.ToString();
            SY.Text = height.ToString();
            ScriptState = ScriptTypeData.ScriptExecNone;
            ExecOrWhere = false;
            ScriptOrderTxt.Text = scriptOrder.ToString();
            SecondNumTxt.Visible = false;
            ScriptNumTxt.Visible = false;
        }
        /// <summary>
        /// 初始化脚本表单
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ScriptOrder"></param>
        /// <param name="scriptState"></param>
        public ScriptInfo(string FileName, string ScriptOrder, ScriptTypeData scriptState, string SWidth, string SHeight,string ScriptStateExecValue)
        {
            InitializeComponent();
            ScriptNameTxt.Text = FileName;
            ScriptOrderTxt.Text = ScriptOrder;
            SecondNumTxt.Visible = false;
            ScriptNumTxt.Visible = false;
            if (scriptState == ScriptTypeData.ScriptExecNone)
            {
                ExecOrWhere = false;
                ScriptStateBox.Checked = false;
            }
           else if (scriptState == ScriptTypeData.ScriptExecRepeat)
            {
                ExecOrWhere = false;
                ScriptStateBox.Checked = true;
            }
            else if (scriptState == ScriptTypeData.ScriptWhereBefore)
            {
                ExecOrWhere = true;
                WaitWhereRadio.Visible = true;
                WaitWhereRadio.Checked = false;
                BeforeExecWhereRadio.Visible = true;
                BeforeExecWhereRadio.Checked = true;
                ScriptStateBox.Visible = false;
                ScriptStateBox.Checked = false;
                ScriptNumTxt.Text = ScriptStateExecValue;
                SecondNumTxt.Visible = true;
                ScriptNumTxt.Visible = true;
            }
            else if(scriptState == ScriptTypeData.ScriptWhereWait)
            {
                ExecOrWhere = true;
                WaitWhereRadio.Visible = true;
                WaitWhereRadio.Checked = true;
                BeforeExecWhereRadio.Visible = true;
                BeforeExecWhereRadio.Checked = false;
                ScriptStateBox.Visible = false;
                ScriptStateBox.Checked = false;

                SecondNumTxt.Visible = true;
                ScriptNumTxt.Visible = true;
                SecondNumTxt.Text = ScriptStateExecValue;
            }

             

            SX.Text = SWidth;
            SY.Text = SHeight; 
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
                return;
            }
            int tmpx = 0;
            int tmpy = 0;
            if (!int.TryParse(SX.Text, out tmpx) || !int.TryParse(SY.Text, out tmpy))
            {
                MessageBox.Show("屏幕分辨率必须是数字！");
                return;
            }
            if (!ExecOrWhere)
            {
                if (ScriptStateBox.Checked)
                {
                    ScriptState = ScriptTypeData.ScriptExecRepeat;
                }
                else
                { 
                    ScriptState = ScriptTypeData.ScriptExecNone;
                }
            }
            else
            {
                int num = 0;
                if (WaitWhereRadio.Checked)
                { 
                    if (!int.TryParse(SecondNumTxt.Text, out num))
                    {
                        MessageBox.Show("等待秒数必须是数字！");
                        return;
                    }
                    ScriptState = ScriptTypeData.ScriptWhereWait;
                }
                if (BeforeExecWhereRadio.Checked)
                {
                    if (!int.TryParse(ScriptNumTxt.Text, out num))
                    {
                        MessageBox.Show("从第N个脚本执行的N是脚本顺序必须是数字！");
                        return;
                    }
                    ScriptState = ScriptTypeData.ScriptWhereBefore;
                }
                WhereExecValue = num;
            }
            FileName = ScriptNameTxt.Text;
            this.DialogResult = DialogResult.OK;
            this.SXWidth = int.Parse(SX.Text);
            this.SYHeight = int.Parse(SY.Text);
            this.Close();
        }
    }
}
