using Newtonsoft.Json;
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
    public partial class GetWindowPix : Form
    {

        #region 录制记录参数
        int StartX { get; set; }
        int StartY { get; set; }
        int EndX { get; set; }
        int EndY { get; set; }
        string K { get; set; }
        bool logstate = false;
        #endregion
        //钩子监听
        KeyboardHook k_hook;
        MouseHook M_hook;
        public GetWindowPix()
        {
            InitializeComponent();

            InitHook();
            this.listView1.Items.Clear();
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("开始X位置", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("开始Y位置", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("结束X位置", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("结束Y位置", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("键盘按键", 100, HorizontalAlignment.Center);
            this.listView1.GridLines = true;//显示行与行之间的分隔线   
            this.listView1.FullRowSelect = true;//要选择就是一行   
            this.listView1.View = View.Details;//定义列表显示的方式  
            this.listView1.Scrollable = true;//需要时候显示滚动条  
            this.listView1.MultiSelect = false; // 不可以多行选择   
            this.listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.listView1.Visible = true;//lstView可见  
        }

        public void InitHook()
        {
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下 
            k_hook.Start();

            M_hook = new MouseHook();
            M_hook.SetHook();
            M_hook.MouseClickEvent += M_hook_MouseClickEvent;
            M_hook.MouseClickUpEvent += M_hook_MouseClickUpEvent; ;

        }
        #region 录制操作
        //钩子鼠标操作
        private void M_hook_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && logstate)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //钩子鼠标操作
        private void M_hook_MouseClickUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && logstate)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(0, 0, 0);
            }
        }
        //录制的脚本
        List<TmpPixInfo> TpiList = new List<TmpPixInfo>();

        void SetOSList(int keystate, int mousestate, int operationstate)
        {
            ListViewItem scriptitem = new ListViewItem();
            TmpPixInfo tpi = new TmpPixInfo();
            scriptitem.Text = this.StartX.ToString();
            scriptitem.SubItems.Add(this.StartY.ToString());
            scriptitem.SubItems.Add(this.EndX.ToString());
            scriptitem.SubItems.Add(this.EndY.ToString());
            scriptitem.SubItems.Add(this.K);
            tpi.StartX = this.StartX;
            tpi.StartY = this.StartY;
            tpi.EndX = this.EndX;
            tpi.EndY = this.EndY;
            tpi.K = this.K;
            TpiList.Add(tpi);
            listView1.Items.Add(scriptitem);
        }
        //钩子键盘操作
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (logstate)
            { 
                K = SendChartConvert.ChartConver(e.KeyCode.ToString());
                StartX = 0;
                StartY = 0;
                EndX = 0;
                EndY = 0;
                SetOSList(0, 0, 0);
            }
        }
        #endregion

        private void ListResetBtn_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            TpiList = new List<TmpPixInfo>(); 
        }

        private void StartLogBtn_Click(object sender, EventArgs e)
        {
            logstate = true;
        }

        private void ExportJson_Click(object sender, EventArgs e)
        {
            logstate = false;

        }

        private void StopLog_Click(object sender, EventArgs e)
        {
            logstate = false;
            string tmpscrpit = JsonConvert.SerializeObject(TpiList);
            new LogFile().WriteFile(@"D:\辅助坐标拾取"+Guid.NewGuid().ToString("N")+".json", tmpscrpit);
        }
    }


    public class TmpPixInfo
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public string K { get; set; }
    }
}
