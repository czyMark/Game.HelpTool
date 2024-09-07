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
    public partial class WhereScriptInfo : Form
    {
        public string WhereValue;
        public WhereExecStateData WhereExecState; 

        public WhereScriptInfo(string ImageStr)
        {
            InitializeComponent();
            //根据图片加载
            ImageTxt.Text = ImageStr; 
        }
        public WhereScriptInfo(string ImageStr,string WhereTxt, WhereExecStateData data)
        {
            InitializeComponent();
            ImageTxt.Text = ImageStr;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        //确认条件输入
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            double num;
            if (NoneWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecNone;
            }
            if (LessWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecLess;
                if (!double.TryParse(WhereinfoTxt.Text, out num))
                {
                    MessageBox.Show("选择小于条件时输入内容必须是数字！");
                    return;
                }
            }
            if (GreaterWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecGreater;
                if (!double.TryParse(WhereinfoTxt.Text, out num))
                {
                    MessageBox.Show("选择大于条件时输入内容必须是数字！");
                    return;
                }
            }
            if (EqualWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecEqual;
                if (!double.TryParse(WhereinfoTxt.Text, out num))
                {
                    MessageBox.Show("选择等于条件时输入内容必须是数字！");
                    return;
                }
            }
            if (NoContainsWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecNoContains; 
            }
            if (ContainsWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecContains;
            }
            if (KeyWhereRadio.Checked)
            {
                WhereExecState = WhereExecStateData.WhereExecKeyDown;
            }
            this.DialogResult = DialogResult.OK;
            WhereValue = WhereinfoTxt.Text;
            this.Close();
        }
    }
}
