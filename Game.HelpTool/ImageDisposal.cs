using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public partial class ImageDisposal : Form
    {
        List<ScriptWhereInfo> swiList = new List<ScriptWhereInfo>();
        ScriptWhereInfo swi = new ScriptWhereInfo();
        public ImageDisposal()
        {
            InitializeComponent();
            InitInfo();
        }
        void InitInfo()
        {
            this.WhereListView.Items.Clear();
            this.WhereListView.Columns.Clear();
            this.WhereListView.Columns.Add("ID", 0, HorizontalAlignment.Center);
            this.WhereListView.Columns.Add("顺序", 80, HorizontalAlignment.Center);
            this.WhereListView.Columns.Add("下一个条件等待（秒）", 80, HorizontalAlignment.Center);
            this.WhereListView.Columns.Add("条件", 200, HorizontalAlignment.Center);
            this.WhereListView.Columns.Add("操作内容", 380, HorizontalAlignment.Center);
            this.WhereListView.GridLines = true;//显示行与行之间的分隔线   
            this.WhereListView.FullRowSelect = true;//要选择就是一行   
            this.WhereListView.View = View.Details;//定义列表显示的方式  
            this.WhereListView.Scrollable = true;//需要时候显示滚动条  
            this.WhereListView.MultiSelect = false; // 不可以多行选择   
            this.WhereListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.WhereListView.Visible = true;//lstView可见   
        }
        void ResetWhereInfo()
        { 
            WhereListView.Items.Clear();
            foreach (var item in swiList.OrderBy(d=>d.WhereinfoID))
            {
                ListViewItem scriptitem = new ListViewItem();
                scriptitem.Text = item.WhereinfoID;
                scriptitem.SubItems.Add(item.WhereinfoOrder);
                scriptitem.SubItems.Add(item.WhereinfoInt); 
                scriptitem.SubItems.Add(item.WhereinfoName);
                scriptitem.SubItems.Add(item.Whereinfoinfo); 
                WhereListView.Items.Add(scriptitem);
            }
        }
        private void AddWhereStrBtn_Click(object sender, EventArgs e)
        {
            WhereScriptInfo wsi = new WhereScriptInfo();
            DialogResult dr = wsi.ShowDialog();
            if (dr == DialogResult.OK)
            {
                swiList.Add(wsi.OperationScriptWhere);
                ResetWhereInfo();
            }
        }
        private void ImageDisposal_Load(object sender, EventArgs e)
        {

        }

        private void EditWhereBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(swi.WhereinfoID))
            {
                WhereScriptInfo wsi = new WhereScriptInfo(swi);
                DialogResult dr = wsi.ShowDialog();
                if (dr == DialogResult.OK)
                { 
                    swiList.Remove(swiList.Where(d =>
                    d.WhereinfoID == swi.WhereinfoID 
                    ).First());
                    swiList.Add(wsi.OperationScriptWhere);
                    ResetWhereInfo();
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的条件！");
            }
        }
        private void WhereListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WhereListView.SelectedIndices != null && WhereListView.SelectedIndices.Count > 0)
            {
                swi.WhereinfoID = WhereListView.FocusedItem.SubItems[0].Text;
                swi.WhereinfoOrder = WhereListView.FocusedItem.SubItems[1].Text;
                swi.WhereinfoName = WhereListView.FocusedItem.SubItems[3].Text;
                swi.WhereinfoInt = WhereListView.FocusedItem.SubItems[2].Text;
                swi.Whereinfoinfo = WhereListView.FocusedItem.SubItems[4].Text;
            }
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
