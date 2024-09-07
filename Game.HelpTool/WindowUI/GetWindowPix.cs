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

            ExportJson.Enabled = false;
            InitHook();
            this.PointListView.Items.Clear();
            this.PointListView.Columns.Clear();
            this.PointListView.Columns.Add("开始X位置", 100, HorizontalAlignment.Center);
            this.PointListView.Columns.Add("开始Y位置", 100, HorizontalAlignment.Center);
            this.PointListView.Columns.Add("结束X位置", 100, HorizontalAlignment.Center);
            this.PointListView.Columns.Add("结束Y位置", 100, HorizontalAlignment.Center);
            this.PointListView.Columns.Add("键盘按键", 100, HorizontalAlignment.Center);
            this.PointListView.GridLines = true;//显示行与行之间的分隔线   
            this.PointListView.FullRowSelect = true;//要选择就是一行   
            this.PointListView.View = View.Details;//定义列表显示的方式  
            this.PointListView.Scrollable = true;//需要时候显示滚动条  
            this.PointListView.MultiSelect = false; // 不可以多行选择   
            this.PointListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.PointListView.Visible = true;//lstView可见  
        }
        /// <summary>
        /// 初始化钩子
        /// </summary>
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
        /// <summary>
        /// 钩子鼠标操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_hook_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && logstate)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        /// <summary>
        /// 钩子鼠标操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 快捷记录坐标
        /// </summary>
        /// <param name="keystate"></param>
        /// <param name="mousestate"></param>
        /// <param name="operationstate"></param>
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
            PointListView.Items.Add(scriptitem);
        }
        /// <summary>
        /// 钩子键盘操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 清空坐标列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListResetBtn_Click(object sender, EventArgs e)
        {
            LogFile.WriteSysLog(string.Format("清空坐标列表\n"));
            this.PointListView.Items.Clear();
            TpiList = new List<TmpPixInfo>();
        }
        /// <summary>
        /// 开始记录坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartLogBtn_Click(object sender, EventArgs e)
        {
            ExportJson.Enabled = false;
            LogFile.WriteSysLog(string.Format("记录坐标\n"));
            logstate = true;
        }
        /// <summary>
        /// 导出坐标拾取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportJson_Click(object sender, EventArgs e)
        {
            logstate = false;
            string tmpscrpit = JsonConvert.SerializeObject(TpiList);
            string fileName = Guid.NewGuid().ToString("N");
            string path = System.Windows.Forms.Application.StartupPath + @"\Coord\" + fileName + ".json";
            //导出文件
            LogFile.WriteFile(path, tmpscrpit);
            LogFile.WriteSysLog(string.Format("辅助坐标拾取导出成功\n"));
            //打开文件
            System.Diagnostics.Process.Start(path);
        }
        /// <summary>
        /// 停止记录鼠标状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopLog_Click(object sender, EventArgs e)
        {
            //如果已经是停止状态则不用在重新停止
            if (!logstate)
            {
                return;
            }
            ExportJson.Enabled = true;
            LogFile.WriteSysLog(string.Format("停止记录坐标\n"));
            logstate = false;
            if (TpiList != null || TpiList.Count > 0)
            {
                TpiList.Remove(TpiList.Last());
            }

            this.PointListView.Items.Clear();
            foreach (var item in TpiList)
            {
                ListViewItem scriptitem = new ListViewItem(); 
                scriptitem.Text = item.StartX.ToString();
                scriptitem.SubItems.Add(item.StartY.ToString());
                scriptitem.SubItems.Add(item.EndX.ToString());
                scriptitem.SubItems.Add(item.EndY.ToString());
                scriptitem.SubItems.Add(item.K); 
                PointListView.Items.Add(scriptitem);
            } 
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
