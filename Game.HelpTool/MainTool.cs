using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms; 

namespace Game.HelpTool
{
    public partial class MainTool : Form
    {
        #region 运行脚本的全局变量
        /// <summary>
        /// 0默认不操作
        /// 1开始录制
        /// 2执行脚本
        /// </summary>
        //当系统操作状态
        int SystemState = 0;
        //当系统操作状态
        int SystemBadState = 0;
        //系统是否执行脚本
        bool SystemRunState = false;
        //系统是否执行脚本
        bool StopState = false;
        //钩子监听
        KeyboardHook k_hook;
        MouseHook M_hook;


        //默认查找脚本路径
        string DefaultPath = System.Windows.Forms.Application.StartupPath + @"\data\";

        //鼠标光标路径
        string CursorPath = System.Windows.Forms.Application.StartupPath + @"\cur\Frequence Normal.cur";
        //录制的脚本
        List<OperationScript> OSList = new List<OperationScript>();
        OperationScriptInfo OSI = new OperationScriptInfo();
        //运行脚本路径
        string ExceScriptPath;
        string ExceScriptOrder;
        bool ExceScriptChecked;
        string ExceScriptSC; 
        //计数器
        int co = 0;
        #endregion

        #region 录制记录参数
        int StartX { get; set; }
        int StartY { get; set; }
        int EndX { get; set; }
        int EndY { get; set; }
        string K { get; set; }
        #endregion

        #region 录制操作
        //钩子鼠标操作
        private void M_hook_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SystemState == 1)
            {
                StartX = e.X;
                StartY = e.Y;
            }
            if (e.Button == MouseButtons.Right && SystemState == 1)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //钩子鼠标操作
        private void M_hook_MouseClickUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SystemState == 1)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(0, 0, 0);
            }
            if (e.Button == MouseButtons.Right && SystemState == 1)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(0, 1, 0);
            }
        }
        //钩子键盘操作
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            K = SendChartConvert.ChartConver(e.KeyCode.ToString());
            //判断按下的键（F10） 
            if (e.KeyValue == (int)Keys.F10 && SystemState == 1)
            {
                SystemState = 0;
                EndOperation();
                MessageBox.Show("脚本已录制完成！");
                this.Show();
                OSI.Detail = OSList;
                string SCRIPT = JsonConvert.SerializeObject(OSI);
                new LogFile().WriteFile(DefaultPath + OSI.ScriptName + ".Script", SCRIPT);
                ResetScriptList();
            }
            //判断按下的键（F11） 
            if (e.KeyValue == (int)Keys.F11 && SystemState == 2)
            {
                SystemState = 0;
                SystemRunState = false;
                User32Api.DefaultMuoseCursor();
                MessageBox.Show("脚本已停止！");
                this.Show();
            }
            //判断按下的键（F7） 
            if (e.KeyValue == (int)Keys.F7 && SystemState == 2)
            {
                User32Api.DefaultMuoseCursor();
                StopState = true;
                MessageBox.Show("脚本已暂停！");
            }
            //判断按下的键（F6） 
            if (e.KeyValue == (int)Keys.F6 && SystemState == 2)
            {
                StopState = false;
                User32Api.SetMuoseCursor(CursorPath);
            }
            if (SystemState == 1)
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.F8: SetOSList(1, 0, 1); break;
                    case (int)Keys.F9: SetOSList(2, 0, 1); break;
                    default:
                        SetOSList(0, 0, 1);
                        break;
                }
            }
        }
        #endregion

        #region 界面操作

        /// <summary>
        /// 在本地查找脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindScript_Click(object sender, EventArgs e)
        {
            DefaultPath = System.Windows.Forms.Application.StartupPath + @"\data\";
            ResetScriptList();
        }

        private void ResetScriptList()
        {
            List<FindFileInfo> fl = new List<FindFileInfo>();
            fl = new LogFile().GetFiles(DefaultPath, fl);
            List<ScriptModel> smlist = new List<ScriptModel>();
            foreach (var item in fl)
            {
                ScriptModel sm = new ScriptModel();
                sm.ScriptPath = item.FilePath;
                string json = new LogFile().ReadFile(item.FilePath);
                OperationScriptInfo os = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                sm.ScreenX = os.ScreenX;
                sm.ScreenY = os.ScreenY;
                sm.ScriptName = os.ScriptName;
                sm.ScriptState = os.ScriptState;
                sm.ID = os.ID;
                sm.ScriptOrder = os.ScriptOrder;
                smlist.Add(sm);
            }
            string SCRIPT = JsonConvert.SerializeObject(smlist.OrderBy(d => d.ScriptOrder));
            new LogFile().DeleteFile(DefaultPath + @"ScriptInfo.ScriptSetting");
            new LogFile().WriteFile(DefaultPath + @"ScriptInfo.ScriptSetting", SCRIPT);
            SetScriptList();
        }

        private void DeleteScriptbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本！");
                return;
            }
            //ExceScriptPath

            bool f = new LogFile().DeleteFile(ExceScriptPath);
            if (f)
            {
                MessageBox.Show("删除成功！");
                ResetScriptList();
                ExceScriptName.Text = "";
                ExceScriptPath = "";
            }
            else
            {
                MessageBox.Show("无法找到该脚本！");
            }
        }

        private void EditScriptInfobtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本！");
                return;
            }
            ScriptInfo si = new ScriptInfo(ExceScriptName.Text, ExceScriptOrder, ExceScriptChecked, ExceScriptSC.Split(':')[0], ExceScriptSC.Split(':')[1]);
            if (si.ShowDialog() == DialogResult.OK)
            {
                string json = new LogFile().ReadFile(ExceScriptPath);
                var tempOsi = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                tempOsi.ScriptName = si.FileName;
                tempOsi.ScriptState = si.FileState;
                tempOsi.ScreenX = si.SXWidth;
                tempOsi.ScreenY = si.SYHeight;
                tempOsi.ScriptOrder = si.ScriptOrder;
                string SCRIPT = JsonConvert.SerializeObject(tempOsi);
                new LogFile().DeleteFile(ExceScriptPath);
                new LogFile().WriteFile(ExceScriptPath, SCRIPT);

                MessageBox.Show("修改完成！");
                ResetScriptList();
                ExceScriptName.Text = "";
                ExceScriptPath = "";
            }
        }
        private void ScriptListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScriptListView.SelectedIndices != null && ScriptListView.SelectedIndices.Count > 0)
            {
                ExceScriptOrder = ScriptListView.FocusedItem.SubItems[0].Text;
                ExceScriptName.Text = ScriptListView.FocusedItem.SubItems[1].Text;
                string strtemp = ScriptListView.FocusedItem.SubItems[2].Text;
                ExceScriptChecked = strtemp == "单次执行脚本" ? false : true;
                ExceScriptPath = ScriptListView.FocusedItem.SubItems[3].Text;
                ExceScriptSC = ScriptListView.FocusedItem.SubItems[4].Text;
            }
        }
        //窗体键盘按下
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        //选择模拟器
        private void CheckFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Title = "打开文件";
            oFD.ShowHelp = true;
            oFD.Filter = "模拟器|*.exe|所有文件|*.*";//过滤格式
            oFD.FilterIndex = 1;                                    //格式索引
            oFD.RestoreDirectory = false;
            oFD.Multiselect = true;                                 //是否多选
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                FileExePath.Text = oFD.FileName;
            }
        }
        #endregion

        #region 界面初始化
        public MainTool()
        {
            InitializeComponent();
            //InitHook();
            InitInfo();
            ResetScriptList();
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

        void InitInfo()
        {
            this.ScriptListView.Items.Clear();
            this.ScriptListView.Columns.Clear();
            this.ScriptListView.Columns.Add("脚本顺序", 70, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("脚本名称", 120, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("脚本执行状态", 120, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("脚本本地路径", 350, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("屏幕分辨率", 120, HorizontalAlignment.Center);
            this.ScriptListView.GridLines = true;//显示行与行之间的分隔线   
            this.ScriptListView.FullRowSelect = true;//要选择就是一行   
            this.ScriptListView.View = View.Details;//定义列表显示的方式  
            this.ScriptListView.Scrollable = true;//需要时候显示滚动条  
            this.ScriptListView.MultiSelect = false; // 不可以多行选择   
            this.ScriptListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.ScriptListView.Visible = true;//lstView可见  
        }
        #endregion

        #region 工具方法
        private void EndOperation()
        {
            User32Api.DefaultMuoseCursor();
        }

        private void StartOperation()
        {
            if (FileExePath.Text == "")
            {
                MessageBox.Show("请选择启动游戏");
                SystemBadState = 1;
                return;
            }
            SystemBadState = 0;
            User32Api.SetMuoseCursor(CursorPath);
            OSList = new List<OperationScript>();
            SetOSList(0, 0, 0);

            //返回桌面
            //Type oleType = Type.GetTypeFromProgID("Shell.Application");
            //object oleObject = System.Activator.CreateInstance(oleType);
            //oleType.InvokeMember("ToggleDesktop", BindingFlags.InvokeMethod, null, oleObject, null);
        }
        bool StopScript()
        {
            while (StopState)
            {
                Thread.Sleep(1000);
            }
            return true;
        }

        bool ExecutScript()
        {
            if (!SystemRunState)
            {
                return false;
            }
            if (StopState) StopScript();
            SystemState = 2;
            StartOperation();
            if (SystemBadState == 1)
                return false;
            DateTime oldtime = DateTime.Now;
            int f = 0;

            int ScreenLineXCount = 0;
            int ScreenLineYCount = 0;
            double ScriptDelay = 0;
            if (!int.TryParse(ScreenLineXTxt.Text, out ScreenLineXCount))
            {
                MessageBox.Show("脚本扩展必须是整数！");
                return false;
            }
            if (!int.TryParse(ScreenLineYTxt.Text, out ScreenLineYCount))
            {
                MessageBox.Show("脚本扩展必须是整数！");
                return false;
            }
            if (!double.TryParse(ScriptDelayTxt.Text, out ScriptDelay))
            {
                MessageBox.Show("脚本延迟必须是数字！");
                return false;
            }

            int ScreenLineXNum = OSI.ScreenX / ScreenLineXCount;
            int ScreenLineYNum = OSI.ScreenY / ScreenLineYCount;

            foreach (var item in OSI.Detail)
            {
                if (!SystemRunState)
                {
                    return false;
                }
                if (StopState) StopScript();
                if (f == 1)
                {
                    //获取每次的操作间隔 毫秒数据
                    System.TimeSpan t3 = DateTime.Parse(item.RunTime) - oldtime;
                    Thread.Sleep((int)t3.TotalMilliseconds);
                    if (!SystemRunState)
                        return false;
                    if (StopState) StopScript();
                    for (int i = 0; i < ScreenLineXCount; i++)
                    {
                        if (!SystemRunState)
                            return false;
                        if (StopState) StopScript();
                        for (int j = 0; j < ScreenLineYCount; j++)
                        {
                            if (!SystemRunState)
                                return false;
                            if (StopState) StopScript();
                            oldtime = DateTime.Parse(item.RunTime);
                            if (item.OperationState == 0)
                            {
                                switch (item.MouseState)
                                {
                                    case 1:
                                        RMouseHD(item.StartX + (ScreenLineXNum * i), item.StartY + (ScreenLineYNum * i), item.EndX + (ScreenLineXNum * i), item.EndY + (ScreenLineYNum * i), OSI.ScreenX, OSI.ScreenY);
                                        break;
                                    default:
                                        LMouseHD(item.StartX + (ScreenLineXNum * i), item.StartY + (ScreenLineYNum * i), item.EndX + (ScreenLineXNum * i), item.EndY + (ScreenLineYNum * i), OSI.ScreenX, OSI.ScreenY);
                                        break;
                                }
                            }
                            else
                            {
                                switch (item.KeyState)
                                {
                                    case 1:
                                        SendKeys.SendWait(Guid.NewGuid().ToString("N"));
                                        break;
                                    case 2:
                                        co++;
                                        SendKeys.SendWait(co.ToString());
                                        break;
                                    default:
                                        SendKeys.SendWait(item.K);
                                        break;
                                }
                            }
                            Thread.Sleep((int)(1000 * ScriptDelay));
                        }
                    }
                }
                else
                {
                    oldtime = DateTime.Parse(item.RunTime);
                    // Process proc = Process.Start(FileExePath.Text);
                    f = 1;
                }
            }
            return true;
        }
        void SetOSList(int keystate, int mousestate, int operationstate)
        {
            OperationScript os = new OperationScript();
            os.StartX = this.StartX;
            os.StartY = this.StartY;
            os.EndX = this.EndX;
            os.EndY = this.EndY;
            os.K = this.K;
            os.KeyState = keystate;
            os.MouseState = mousestate;
            os.OperationState = operationstate;
            os.RunTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
            OSList.Add(os);
        }
        void SetScriptList()
        {
            ScriptListView.Items.Clear();
            string json = new LogFile().ReadFile(System.Windows.Forms.Application.StartupPath + @"\data\ScriptInfo.ScriptSetting");
            List<ScriptModel> smlist = JsonConvert.DeserializeObject<List<ScriptModel>>(json);
            if (smlist == null)
                return;
            foreach (var item in smlist)
            {
                ListViewItem scriptitem = new ListViewItem();
                scriptitem.Text = item.ScriptOrder.ToString();
                scriptitem.SubItems.Add(item.ScriptName);
                scriptitem.SubItems.Add(item.ScriptState == 0 ? "单次执行脚本" : "多次执行脚本");
                scriptitem.SubItems.Add(item.ScriptPath);
                scriptitem.SubItems.Add(item.ScreenX + ":" + item.ScreenY);
                scriptitem.SubItems.Add(item.ID);
                ScriptListView.Items.Add(scriptitem);
            }
        }

        private static void LMouseHD(int firstX, int firstY, int lastX, int lastY, int screenX, int screenY)
        {
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_MOVE, firstX * 65536 / screenX, firstY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_LEFTDOWN, firstX * 65536 / screenX, firstY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_MOVE, lastX * 65536 / screenX, lastY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_LEFTUP, lastX * 65536 / screenX, lastY * 65536 / screenY, 0, 0);
        }
        private static void RMouseHD(int firstX, int firstY, int lastX, int lastY, int screenX, int screenY)
        {
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_MOVE, firstX * 65536 / screenX, firstY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_RIGHTDOWN, firstX * 65536 / screenX, firstY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_MOVE, lastX * 65536 / screenX, lastY * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_RIGHTUP, lastX * 65536 / screenX, lastY * 65536 / screenY, 0, 0);
        }
        private static void MouseDJ(int X, int Y, int screenX, int screenY)
        {
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_MOVE, X * 65536 / screenX, Y * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_LEFTDOWN, X * 65536 / screenX, Y * 65536 / screenY, 0, 0);
            User32Api.mouse_event(User32Api.MOUSEEVENTF_ABSOLUTE | User32Api.MOUSEEVENTF_LEFTUP, X * 65536 / screenX, Y * 65536 / screenY, 0, 0);
        }
        #endregion

        //启动脚本
        private void StartExe_Click(object sender, EventArgs e)
        {
            SystemRunState = true;
            //修改键盘状态
            SystemState = 2;
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本");
                return;
            }
            //选择的脚本路径 oFD.FileName
            string json = new LogFile().ReadFile(ExceScriptPath);
            OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
            //启动执行
            Action<string> action = this.StartAllScript;

            this.Hide();
            IAsyncResult asyncResult = action.BeginInvoke("完成状态", null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            if (SystemRunState)
            {
                MessageBox.Show("脚本已经全部执行完成！");
                SystemRunState = false;
            }
            this.Show();
        }
        //循环启动脚本
        private void ForStartExe_Click(object sender, EventArgs e)
        {
            SystemRunState = true;
            SystemState = 2;
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本");
                return;
            }
            string json = new LogFile().ReadFile(ExceScriptPath);
            OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
            //启动执行
            Action<string> action = this.StartAllScript;

            co = int.Parse(CountNumTxt.Text);
            this.Hide();
            bool WX = true;
            while (WX)
            {
                IAsyncResult asyncResult = action.BeginInvoke("测试异步", null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                if (!SystemRunState)
                {
                    WX = false;
                }
            }
        }

        /// <summary>
        /// 选择本地脚本运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckScriptBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Title = "打开文件";
            oFD.ShowHelp = true;
            oFD.Filter = "脚本文件|*.Script|所有文件|*.*";//过滤格式
            oFD.FilterIndex = 1;                                    //格式索引
            oFD.RestoreDirectory = false;
            oFD.Multiselect = true;                                 //是否多选
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                SystemState = 2;
                SystemRunState = true;
                //选择的脚本路径 oFD.FileName
                string json = new LogFile().ReadFile(oFD.FileName);
                OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);

                Action<string> action = this.StartAllScript;

                co = int.Parse(CountNumTxt.Text);
                this.Hide();
                bool WX = true;
                while (WX)
                {
                    IAsyncResult asyncResult = action.BeginInvoke("测试异步", null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                    if (!SystemRunState)
                    {
                        WX = false;
                    }
                }
                SystemRunState = false;
                MessageBox.Show("脚本已经全部执行完成！");
                this.Show();
            }
        }

        private void StartAllScript(string name)
        {
            //启动执行
            if (ExecutScript())
            {
                EndOperation();
            }
        }

        /// <summary>
        /// 脚本录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeScriptBtn_Click(object sender, EventArgs e)
        {
            ScriptInfo si = new ScriptInfo();
            if (si.ShowDialog() == DialogResult.OK)
            {
                OSI = new OperationScriptInfo();
                OSI.ID = Guid.NewGuid().ToString("N");
                OSI.ScriptName = si.FileName;
                OSI.ScriptState = si.FileState;
                OSI.ScreenX = Screen.PrimaryScreen.Bounds.Width;
                OSI.ScreenY = Screen.PrimaryScreen.Bounds.Height;
                OSI.ScriptOrder = si.ScriptOrder;
                StartOperation();
                if (SystemBadState == 1)
                    return;
                this.Hide();
                SystemState = 1;
                // Process proc = Process.Start(FileExePath.Text);
            }
        }

        private void AllForStartExe_Click(object sender, EventArgs e)
        {
            SystemRunState = true;
            SystemState = 2;

            string json = new LogFile().ReadFile(System.Windows.Forms.Application.StartupPath + @"\data\ScriptInfo.ScriptSetting");
            List<ScriptModel> smlist = JsonConvert.DeserializeObject<List<ScriptModel>>(json);
            if (smlist == null)
                return;

            this.Hide();
            bool WX = true;
            co = int.Parse(CountNumTxt.Text);
            while (WX)
            {
                if (!SystemRunState)
                {
                    WX = false;
                }
                foreach (var item in smlist)
                {
                    ExceScriptName.Text = item.ScriptName;
                    ExceScriptPath = item.ScriptPath;
                    string detaijson = new LogFile().ReadFile(ExceScriptPath);
                    OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(detaijson);
                    //启动执行
                    Action<string> action = this.StartAllScript;
                    IAsyncResult asyncResult = action.BeginInvoke("测试异步", null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                    if (!SystemRunState)
                    {
                        break;
                    }
                }
            }

        }

        private void CheckScriptFolder_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择脚本所在的文件夹";
            dialog.SelectedPath = System.Windows.Forms.Application.StartupPath + @"\data";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                DefaultPath = dialog.SelectedPath + @"\";
                ResetScriptList();
            }
        }

        private void ScreenLine_Click(object sender, EventArgs e)
        {
            System.IntPtr DesktopHandle = User32Api.GetDC(System.IntPtr.Zero);
            Graphics g = Graphics.FromHdc(DesktopHandle);
            int ScreenLineXCount = 0;
            int ScreenLineYCount = 0;
            if (!int.TryParse(ScreenLineXTxt.Text, out ScreenLineXCount))
            {
                MessageBox.Show("脚本扩展必须是整数！");
                return;
            }
            if (!int.TryParse(ScreenLineYTxt.Text, out ScreenLineYCount))
            {
                MessageBox.Show("脚本扩展必须是整数！");
                return;
            }
            int ScreenX = Screen.PrimaryScreen.Bounds.Width;
            int ScreenY = Screen.PrimaryScreen.Bounds.Height;

            int ScreenLineXNum = ScreenX / ScreenLineXCount;
            int ScreenLineYNum = ScreenY / ScreenLineYCount;

            for (int i = 0; i < ScreenLineXCount; i++)
            {
                g.DrawRectangle(new Pen(Color.Red), new Rectangle(ScreenLineXNum * i, 0, ScreenLineXNum * i, ScreenY));
            }
            for (int i = 0; i < ScreenLineYCount; i++)
            {
                g.DrawRectangle(new Pen(Color.Red), new Rectangle(0, ScreenLineYNum * i, ScreenX, ScreenLineYNum * i));
            }
            g.Dispose();
        }

        private void FindPix_Click(object sender, EventArgs e)
        {
            GetWindowPix gwp = new GetWindowPix();
            this.Hide();
            gwp.ShowDialog();
            this.Show();
        }

        private void SelectPositionBtn_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            IntPtr dc = g.GetHdc();
            g.ReleaseHdc(dc);
            ScreenBody body = new ScreenBody();
            body.BackgroundImage = img;
            //body.Parent = this;
            body.ShowDialog();
            this.Show();
        }
    }
}
