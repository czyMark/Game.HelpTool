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
        public ScriptWhereInfo OperationScriptWhere { get; set; }
        public WhereScriptInfo()
        {
            InitializeComponent();
        }
        public WhereScriptInfo(ScriptWhereInfo swi)
        {
            InitializeComponent();
            WhereSelectBox.SelectedItem = swi.WhereinfoName;
            WhereOrderTxt.Text = swi.WhereinfoOrder;
            WhereIntTxt.Text = swi.WhereinfoInt;
            WhereinfoinfoTxt.Text = swi.Whereinfoinfo;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            OperationScriptWhere = new ScriptWhereInfo();
            OperationScriptWhere.WhereinfoName = WhereSelectBox.SelectedItem.ToString();
            OperationScriptWhere.WhereinfoOrder = WhereOrderTxt.Text;
            OperationScriptWhere.WhereinfoInt = WhereIntTxt.Text;
            OperationScriptWhere.Whereinfoinfo = WhereinfoinfoTxt.Text;
            OperationScriptWhere.WhereinfoID = Guid.NewGuid().ToString("N");
            this.Close();
        }

        private void WhereSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OperLogbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
