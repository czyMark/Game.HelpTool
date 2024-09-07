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
using Tesseract;

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
        KeyboardHook Khook;
        MouseHook Mhook;

        //图像识别缓存文字
        string CacheTxt = "";
        //键盘输入
        string KeyTxt = "";

        //最大脚本顺序号
        double MaxScriptOrder;

        //默认查找脚本路径
        string DefaultPath = System.Windows.Forms.Application.StartupPath + @"\Data\";

        //鼠标光标路径
        string CursorPath = System.Windows.Forms.Application.StartupPath + @"\Cur\Frequence Normal.cur";
        //录制的脚本
        List<OperationScript> OSList = new List<OperationScript>();
        OperationScriptInfo OSI = new OperationScriptInfo();
        WhereScriptExecStateData WhereScriptExecState;
        //运行脚本路径
        string ExceScriptPath;
        string ExceScriptOrder;
        ScriptTypeData ExceScriptState;
        string ExceScriptSC;
        string ExceScriptStateValue;
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

        #region 脚本录制操作
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
                SetOSList(KeyStateData.KeyNone, MouseStateData.MouseLeft, OperationStateData.OperationMouse, WhereExecStateData.WhereExecNone);
            }
            if (e.Button == MouseButtons.Right && SystemState == 1)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(KeyStateData.KeyNone, MouseStateData.MouseRight, OperationStateData.OperationMouse, WhereExecStateData.WhereExecNone);
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
                LogFile.WriteSysLog(string.Format("脚本已录制完成:{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff")));
                MessageBox.Show("脚本已录制完成！");
                this.Show();
                OSI.Detail = OSList;
                string SCRIPT = JsonConvert.SerializeObject(OSI);
                LogFile.WriteFile(DefaultPath + OSI.ID + ".Script", SCRIPT);
                ResetScriptList();
            }
            //判断按下的键（F5） 
            if (e.KeyValue == (int)Keys.F5 && SystemState == 2)
            {
                SystemState = 0;
                SystemRunState = false;
                User32Api.DefaultMuoseCursor();
                LogFile.WriteSysLog(string.Format("已退出执行脚本:{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff")));
                MessageBox.Show("已退出执行脚本");
                this.Show();
            }
            //判断按下的键（F6） 
            if (e.KeyValue == (int)Keys.F6 && SystemState == 2)
            {
                User32Api.DefaultMuoseCursor();
                StopState = true;
                LogFile.WriteSysLog(string.Format("脚本已暂停:{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff")));
                MessageBox.Show("脚本已暂停");
            }
            //判断按下的键（F7） 
            if (e.KeyValue == (int)Keys.F7 && SystemState == 2)
            {
                StopState = false;
                User32Api.SetMuoseCursor(CursorPath);
            }
            if (SystemState == 1)
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.F8:
                        SetOSList(KeyStateData.KeyGuid, MouseStateData.MouseNone, OperationStateData.OperationKey, WhereExecStateData.WhereExecNone);
                        break;
                    case (int)Keys.F9:
                        SetOSList(KeyStateData.KeyNumber, MouseStateData.MouseNone, OperationStateData.OperationKey, WhereExecStateData.WhereExecNone);
                        break;
                    case (int)Keys.F11:
                        SetOSList(KeyStateData.KeyCache, MouseStateData.MouseNone, OperationStateData.OperationKey, WhereExecStateData.WhereExecNone);
                        break;
                    default:
                        SetOSList(KeyStateData.KeyNone, MouseStateData.MouseNone, OperationStateData.OperationKey, WhereExecStateData.WhereExecNone);
                        break;
                }
            }

            KeyTxt = K;
        }
        #endregion

        #region 界面操作
        /// <summary>
        /// 在查找脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindScript_Click(object sender, EventArgs e)
        {
            DefaultPath = System.Windows.Forms.Application.StartupPath + @"\Data\";
            LogFile.WriteSysLog(string.Format("刷新脚本列表"));
            ResetScriptList();
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        private void ResetScriptList()
        {
            List<FindFileInfo> fl = new List<FindFileInfo>();

            fl = LogFile.GetFiles(DefaultPath, fl);
            List<ScriptModel> smlist = new List<ScriptModel>();
            foreach (var item in fl)
            {
                ScriptModel sm = new ScriptModel();
                sm.ScriptPath = item.FilePath;
                string json = LogFile.ReadFile(item.FilePath);
                OperationScriptInfo os = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                sm.ScreenX = os.ScreenX;
                sm.ScreenY = os.ScreenY;
                sm.ScriptName = os.ScriptName;
                sm.ScriptState = os.ScriptState;
                sm.ID = os.ID;
                sm.ScriptOrder = os.ScriptOrder;
                sm.ScriptStateExecValue = os.ScriptStateExecValue;
                smlist.Add(sm);
            }
            string SCRIPT = JsonConvert.SerializeObject(smlist.OrderBy(d => d.ScriptOrder));
            LogFile.DeleteFile(DefaultPath + @"ScriptInfo.ScriptSetting");
            LogFile.WriteFile(DefaultPath + @"ScriptInfo.ScriptSetting", SCRIPT);
            SetScriptList();
        }
        /// <summary>
        /// 删除脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteScriptbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本！");
                return;
            }
            //ExceScriptPath

            bool f = LogFile.DeleteFile(ExceScriptPath);
            if (f)
            {
                LogFile.WriteSysLog(string.Format("成功删除脚本:{0}", ExceScriptName.Text));
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
        /// <summary>
        /// 修改脚本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditScriptInfobtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                EditScriptInfo();
            }
            else
            {
                MessageBox.Show("请选择脚本！");
            }
        }
        /// <summary>
        /// 列表选中状态记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScriptListView.SelectedIndices != null && ScriptListView.SelectedIndices.Count > 0)
            {
                ExceScriptOrder = ScriptListView.FocusedItem.SubItems[0].Text;
                ExceScriptName.Text = ScriptListView.FocusedItem.SubItems[1].Text;
                ExceScriptState = EnumDataConvert.StringToScriptState(ScriptListView.FocusedItem.SubItems[2].Text);
                ExceScriptPath = ScriptListView.FocusedItem.SubItems[3].Text;
                ExceScriptSC = ScriptListView.FocusedItem.SubItems[4].Text;
                ExceScriptStateValue = ScriptListView.FocusedItem.SubItems[6].Text;
            }
            else
            {
                ExceScriptOrder = "";
                ExceScriptName.Text = "";
                ExceScriptState = ScriptTypeData.ScriptExecNone;
                ExceScriptPath = "";
                ExceScriptSC = "";
            }
        }
        /// <summary>
        /// 选择模拟器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 修改脚本的详细参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditScriptDetailInfobtn_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptListView_DoubleClick(object sender, EventArgs e)
        {
            EditScriptInfo();
        }

        /// <summary>
        /// 右键列表属性菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < ListStrip.Items.Count; i++)
            {
                if (ListStrip.Items[i].Selected)
                {
                    switch (ListStrip.Items[i].Text.Trim())
                    {
                        case "删除脚本":
                            DeleteScriptbtn_Click(null, null);
                            break;
                        case "修改脚本":
                            EditScriptInfo();
                            break;
                        case "修改操作":
                            {
                                if (ExceScriptState == ScriptTypeData.ScriptStartExe)
                                {
                                    //弹出文件选择框，重新选择
                                    //选择文件确定，生成脚本
                                    OpenFileDialog openFileDialog = new OpenFileDialog();
                                    //openFileDialog.Filter = "Files|*.png;*.jpg";              // 设定打开的文件类型
                                    //openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;                       // 打开app对应的路径
                                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // 打开桌面

                                    // 如果选定了文件
                                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        string json = LogFile.ReadFile(ExceScriptPath);
                                        var OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                                        //文件名称是脚本名称
                                        // 取得文件路径及文件名 
                                        OSI.ScriptName = openFileDialog.SafeFileName;
                                        OSI.ScriptState = ScriptTypeData.ScriptStartExe;
                                        OSI.ScriptOrder = MaxScriptOrder + 1;
                                        List<OperationScript> detail = new List<OperationScript>();
                                        OperationScript script = new OperationScript();
                                        script.K = openFileDialog.FileName;
                                        detail.Add(script);
                                        OSI.Detail = detail;
                                        string SCRIPT = JsonConvert.SerializeObject(OSI);
                                        LogFile.WriteFile(DefaultPath + OSI.ID + ".ScriptEXE", SCRIPT);
                                        ResetScriptList(); 
                                    }
                                    return;
                                }


                                this.Hide();
                                Khook.Stop();
                                EditScriptNode editScript = new EditScriptNode(ExceScriptPath);
                                editScript.FormClosed += EditScript_FormClosed;
                                editScript.Show();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void EditScript_FormClosed(object sender, FormClosedEventArgs e)
        {
            Khook.Start();
            this.Show();
        }
        #endregion



        #region 界面初始化
        public MainTool()
        {
            InitializeComponent();
            InitHook();
            InitInfo();
            ResetScriptList();
        }
        /// <summary>
        /// 界面初始化钩子
        /// </summary>
        public void InitHook()
        {
            Khook = new KeyboardHook();
            Khook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下 
            Khook.Start();

            Mhook = new MouseHook();
            Mhook.SetHook();
            Mhook.MouseClickEvent += M_hook_MouseClickEvent;
            Mhook.MouseClickUpEvent += M_hook_MouseClickUpEvent;

        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            this.ScriptListView.Items.Clear();
            this.ScriptListView.Columns.Clear();
            this.ScriptListView.Columns.Add("顺序", 50, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("名称", 200, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("脚本类别", 200, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("脚本路径", 200, HorizontalAlignment.Center);
            this.ScriptListView.Columns.Add("屏幕分辨率", 130, HorizontalAlignment.Center);
            this.ScriptListView.GridLines = true;//显示行与行之间的分隔线   
            this.ScriptListView.FullRowSelect = true;//要选择就是一行   
            this.ScriptListView.View = View.Details;//定义列表显示的方式  
            this.ScriptListView.Scrollable = true;//需要时候显示滚动条  
            this.ScriptListView.MultiSelect = false; // 不可以多行选择   
            this.ScriptListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.ScriptListView.Visible = true;//lstView可见  

            ListStrip.Items.Add("删除脚本");
            ListStrip.Items.Add("修改脚本");
            ListStrip.Items.Add("修改操作");
            ListStrip.ItemClicked += ListStrip_ItemClicked;
        }
        #endregion


        #region 脚本操作

        /// <summary>
        /// 执行选中脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartExe_Click(object sender, EventArgs e)
        {
            if (ExceScriptState == ScriptTypeData.ScriptWhereBefore || ExceScriptState == ScriptTypeData.ScriptWhereWait)
            {
                MessageBox.Show("选中的脚本是条件脚本无法单独执行！");
                return;
            }

            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本");
                return;
            }

            LogFile.WriteSysLog(string.Format("执行单次"));

            SystemRunState = true;
            //修改键盘状态
            SystemState = 2;
            //选择的脚本路径 oFD.FileName
            string json = LogFile.ReadFile(ExceScriptPath);
            //启动执行
            Action<OperationScriptInfo> action = (OperationScriptInfo OSI) =>
            {
                if (ExecutScript(OSI))
                {
                    EndOperation();
                }
            };

            this.Hide();
            IAsyncResult asyncResult = action.BeginInvoke(JsonConvert.DeserializeObject<OperationScriptInfo>(json), null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            if (SystemRunState)
            {
                MessageBox.Show("脚本执行完成！");
                SystemRunState = false;
            }
            this.Show();
        }
        /// <summary>
        /// 循环执行选中脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForStartExe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本");
                return;
            }

            LogFile.WriteSysLog(string.Format("循环执行"));
            SystemRunState = true;
            SystemState = 2;
            string json = LogFile.ReadFile(ExceScriptPath);
            //启动执行     
            Action<OperationScriptInfo> action = (OperationScriptInfo OSI) =>
            {
                if (ExecutScript(OSI))
                {
                    EndOperation();
                }
            };
            co = int.Parse(CountNumTxt.Text);
            this.Hide();
            bool WX = true;
            while (WX)
            {
                IAsyncResult asyncResult = action.BeginInvoke(JsonConvert.DeserializeObject<OperationScriptInfo>(json), null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                if (!SystemRunState)
                {
                    WX = false;
                }
            }
        }

        /// <summary>
        /// 选择脚本运行
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
                LogFile.WriteSysLog(string.Format("选择独立脚本完成"));

                SystemState = 2;
                SystemRunState = true;
                //选择的脚本路径 oFD.FileName
                string json = LogFile.ReadFile(oFD.FileName);
                Action<OperationScriptInfo> action = (OperationScriptInfo OSI) =>
                {
                    if (ExecutScript(OSI))
                    {
                        EndOperation();
                    }
                };

                co = int.Parse(CountNumTxt.Text);
                this.Hide();
                bool WX = true;
                while (WX)
                {
                    IAsyncResult asyncResult = action.BeginInvoke(JsonConvert.DeserializeObject<OperationScriptInfo>(json), null, null);
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

        /// <summary>
        /// 脚本录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeScriptBtn_Click(object sender, EventArgs e)
        {
            ScriptInfo si = new ScriptInfo(MaxScriptOrder + 1);
            if (si.ShowDialog() == DialogResult.OK)
            {
                LogFile.WriteSysLog(string.Format("开始录制脚本"));
                OSI = new OperationScriptInfo();
                OSI.ID = Guid.NewGuid().ToString("N");
                OSI.ScriptName = si.FileName;
                OSI.ScriptState = si.ScriptState;
                OSI.ScreenX = si.SXWidth;
                OSI.ScreenY = si.SYHeight;
                OSI.ScriptOrder = si.ScriptOrder;
                if (SystemBadState == 1)
                    return;
                this.Hide();
                SystemState = 1;
                // Process proc = Process.Start(FileExePath.Text);
            }
        }

        /// <summary>
        /// 循环执行整个脚本列表中的脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllForStartExe_Click(object sender, EventArgs e)
        {
            string json = LogFile.ReadFile(DefaultPath + @"\ScriptInfo.ScriptSetting");
            List<ScriptModel> smlist = JsonConvert.DeserializeObject<List<ScriptModel>>(json);
            if (smlist == null)
                return;

            LogFile.WriteSysLog(string.Format("所有脚本顺序循环执行"));
            SystemRunState = true;
            SystemState = 2;

            this.Hide();
            bool WX = true;
            co = int.Parse(CountNumTxt.Text);
            int execindex = 1;
            while (WX)
            {
                if (!SystemRunState)
                {
                    WX = false;
                }
                for (int i = 0; i < smlist.Count; i++)
                {
                    ExceScriptName.Text = smlist[i].ScriptName;
                    ExceScriptPath = smlist[i].ScriptPath;
                    string osijson = LogFile.ReadFile(ExceScriptPath);
                    //启动执行
                    Action<OperationScriptInfo> action = (OperationScriptInfo OSI) =>
                    {
                        if (ExecutScript(OSI))
                        {
                            EndOperation();
                        }
                    };
                    IAsyncResult asyncResult = action.BeginInvoke(JsonConvert.DeserializeObject<OperationScriptInfo>(osijson), null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                    if (!SystemRunState)
                    {
                        break;
                    }
                    if (WhereScriptExecState == WhereScriptExecStateData.ScriptWhereBefore)
                    {
                        if (i <= smlist[i].ScriptStateExecValue)
                        {
                            i = -1;
                        }
                        else
                            i = i - smlist[i].ScriptStateExecValue;
                        if (i < -1)
                        {
                            i = -1;
                        }
                    }
                    if (WhereScriptExecState == WhereScriptExecStateData.ScriptWhereWait)
                    {
                        if (i == 0)
                        {
                            Thread.Sleep(smlist[i].ScriptStateExecValue * 1000);
                        }
                        else
                        {
                            i = i - 1;
                            Thread.Sleep(smlist[i].ScriptStateExecValue * 1000);
                        }

                    }
                    WhereScriptExecState = WhereScriptExecStateData.ScriptWhereSuccess;
                }
                LogFile.WriteSysLog(string.Format("所有脚本顺序循环执行" + execindex + ""));
                execindex++;
            }

        }
        /// <summary>
        /// 从选中开始执行脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllForStartExe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExceScriptName.Text))
            {
                MessageBox.Show("请选择脚本！");
                return;
            }


            string json = LogFile.ReadFile(DefaultPath + @"\ScriptInfo.ScriptSetting");
            List<ScriptModel> smlist = JsonConvert.DeserializeObject<List<ScriptModel>>(json);
            if (smlist == null)
                return;

            LogFile.WriteSysLog(string.Format("从选中脚本顺序循环执行"));
            SystemRunState = true;
            SystemState = 2;

            this.Hide();
            bool WX = true;
            bool isExec = false;
            co = int.Parse(CountNumTxt.Text);
            while (WX)
            {
                if (!SystemRunState)
                {
                    WX = false;
                }
                for (int i = 0; i < smlist.Count; i++)
                {
                    if (!isExec)
                    {
                        if (ExceScriptPath == smlist[i].ScriptPath)
                        {
                            isExec = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    ExceScriptName.Text = smlist[i].ScriptName;
                    ExceScriptPath = smlist[i].ScriptPath;
                    string osiJson = LogFile.ReadFile(ExceScriptPath);
                    //启动执行
                    Action<OperationScriptInfo> action = (OperationScriptInfo OSI) =>
                    {
                        if (ExecutScript(OSI))
                        {
                            EndOperation();
                        }
                    };
                    IAsyncResult asyncResult = action.BeginInvoke(JsonConvert.DeserializeObject<OperationScriptInfo>(osiJson), null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                    if (!SystemRunState)
                    {
                        break;
                    }
                    if (WhereScriptExecState == WhereScriptExecStateData.ScriptWhereBefore)
                    {
                        if (i <= smlist[i].ScriptStateExecValue)
                        {
                            i = -1;
                        }
                        else
                            i = i - smlist[i].ScriptStateExecValue;
                        if (i < -1)
                        {
                            i = -1;
                        }
                    }
                    if (WhereScriptExecState == WhereScriptExecStateData.ScriptWhereWait)
                    {
                        if (i == 0)
                        {
                            Thread.Sleep(smlist[i].ScriptStateExecValue * 1000);
                        }
                        else
                        {
                            i = i - 1;
                            Thread.Sleep(smlist[i].ScriptStateExecValue * 1000);
                        }
                    }
                    WhereScriptExecState = WhereScriptExecStateData.ScriptWhereSuccess;
                }
            }
        }
        /// <summary>
        /// 更换脚本文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckScriptFolder_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择脚本所在的文件夹";
            dialog.SelectedPath = DefaultPath;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                LogFile.WriteSysLog(string.Format("切换脚本方案文件夹"));
                DefaultPath = dialog.SelectedPath + @"\";
                ResetScriptList();
            }
        }
        /// <summary>
        /// 切换成全局脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalScriptPlanBtn_Click(object sender, EventArgs e)
        {
            LogFile.WriteSysLog(string.Format("切换到全局脚本方案文件夹"));
            DefaultPath = System.Windows.Forms.Application.StartupPath + @"\GlobalData\";
            ResetScriptList();
        }
        /// <summary>
        /// 切换成默认脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultScriptPlanBtn_Click(object sender, EventArgs e)
        {
            LogFile.WriteSysLog(string.Format("切换到默认脚本方案文件夹"));
            DefaultPath = System.Windows.Forms.Application.StartupPath + @"\Data\";
            ResetScriptList();
        }
        /// <summary>
        /// 绘制屏幕线条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            LogFile.WriteSysLog(string.Format("显示位置"));
        }

        /// <summary>
        /// 寻找屏幕坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindPix_Click(object sender, EventArgs e)
        {
            GetWindowPix gwp = new GetWindowPix();
            this.Hide();
            LogFile.WriteSysLog(string.Format("打开寻找屏幕坐标"));
            gwp.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 添加识别文字条件脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWhereBtn_Click(object sender, EventArgs e)
        {
            AddWhereScript(false);
        }
        /// <summary>
        /// 增加颜色条件脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddColorWhereBtn_Click(object sender, EventArgs e)
        {
            AddWhereScript(true);
        }

        #endregion

        #region 工具方法
        /// <summary>
        /// 停止执行脚本后鼠标状态变更
        /// </summary>
        private void EndOperation()
        {
            User32Api.DefaultMuoseCursor();
        }
        /// <summary>
        /// 启动某个应用 弃用
        /// </summary>
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
            SetOSList(KeyStateData.KeyNone, MouseStateData.MouseLeft, OperationStateData.OperationMouse, WhereExecStateData.WhereExecNone);

            //返回桌面
            //Type oleType = Type.GetTypeFromProgID("Shell.Application");
            //object oleObject = System.Activator.CreateInstance(oleType);
            //oleType.InvokeMember("ToggleDesktop", BindingFlags.InvokeMethod, null, oleObject, null);
        }
        /// <summary>
        /// 停止脚本
        /// </summary>
        /// <returns></returns>
        bool StopScript()
        {
            while (StopState)
            {
                Thread.Sleep(1000);
            }
            return true;
        }

        List<OperationScriptInfo> operationScriptInfosOld = new List<OperationScriptInfo>();

        /// <summary>
        /// 执行脚本
        /// </summary>
        /// <param name="execScript">要执行的脚本</param>
        /// <returns></returns>
        bool ExecutScript(OperationScriptInfo execScript, bool log = true)
        {
            if (execScript.ScriptState == ScriptTypeData.ScriptStartExe)
            {
                Process proc = Process.Start(execScript.Detail.FirstOrDefault().K);
                return true;
            }

            if (log)
                operationScriptInfosOld.Add(execScript);
            //记录执行脚本的信息
            LogFile.WriteSysLog(string.Format("执行脚本ID:{2},脚本名称:{1},脚本顺序:{0}", execScript.ScriptOrder, execScript.ScriptName, execScript.ID));
            if (SystemState == 0)
            {
                SystemRunState = false;
            }
            if (!SystemRunState)
            {
                return false;
            }
            if (StopState)
            {
                StopScript();
            }
            //StartOperation();
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

            int ScreenLineXNum = execScript.ScreenX / ScreenLineXCount;
            int ScreenLineYNum = execScript.ScreenY / ScreenLineYCount;

            foreach (var item in execScript.Detail)
            {
                if (SystemState == 0)
                {
                    SystemRunState = false;
                }
                if (!SystemRunState)
                {
                    return false;
                }
                if (StopState)
                    StopScript();


                if (item.OperationState == OperationStateData.OperationRectWhere || item.OperationState == OperationStateData.OperationPointWhere)
                {
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
                            ExecWhereScript(execScript, item, (ScreenLineXNum * i), (ScreenLineYNum * j));
                        }
                    }
                    //不执行脚本操作
                    break;
                }

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
                            //判断脚本执行状态
                            //0是鼠标
                            //1是键盘
                            //2是条件
                            //3是条件
                            if (item.OperationState == OperationStateData.OperationMouse)
                            {
                                switch (item.MouseState)
                                {
                                    case MouseStateData.MouseRight:
                                        RMouseHD(item.StartX + (ScreenLineXNum * i), item.StartY + (ScreenLineYNum * j), item.EndX + (ScreenLineXNum * i), item.EndY + (ScreenLineYNum * j), execScript.ScreenX, execScript.ScreenY);
                                        break;
                                    default:
                                        LMouseHD(item.StartX + (ScreenLineXNum * i), item.StartY + (ScreenLineYNum * j), item.EndX + (ScreenLineXNum * i), item.EndY + (ScreenLineYNum * j), execScript.ScreenX, execScript.ScreenY);
                                        break;
                                }
                            }
                            else if (item.OperationState == OperationStateData.OperationKey)
                            {
                                switch (item.KeyState)
                                {
                                    case KeyStateData.KeyGuid:
                                        SendKeys.SendWait(Guid.NewGuid().ToString("N"));
                                        break;
                                    case KeyStateData.KeyNumber:
                                        co++;
                                        SendKeys.SendWait(co.ToString());
                                        break;
                                    case KeyStateData.KeyNone:
                                        SendKeys.SendWait(item.K);
                                        break;
                                    case KeyStateData.KeyCache:
                                        SendKeys.SendWait(CacheTxt);
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
            //执行完成记录日志
            LogFile.WriteSysLog(string.Format("执行完成脚本:{0}名称:{1}", execScript.ScriptName, execScript.ID));
            return true;
        }

        private void ExecWhereScript(OperationScriptInfo execScript, OperationScript item, double screenX, double screenY)
        {

            //执行屏幕截图并获取对应的图片
            //识别图片

            string imgStr = string.Empty;
            if (item.OperationState == OperationStateData.OperationPointWhere)
            {
                Bitmap img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
                IntPtr dc = g.GetHdc();
                g.ReleaseHdc(dc);
                imgStr = ColorConvertHelper.ColorToHex(img.GetPixel((int)(item.StartX + screenX), (int)(item.StartY + screenY)));
            }
            else
            {
                imgStr = RecognizeImage.SpireRecognize(CaptureScreenImage.CaptureScreen(
                    item.StartX + screenX,
                    item.StartY + screenY,
                    item.EndX - item.StartX + screenX,
                    item.EndY - item.StartY + screenY));
                //imgStr = RecognizeImage.TesseractRecognize(CaptureScreenImage.CaptureScreen(
                //    item.StartX * screenX,
                //    item.StartY * screenY,
                //    item.EndX - item.StartX * screenX,
                //    item.EndY - item.StartY * screenY)
                //    );
            }
            bool whereFlag = false;
            double num;
            //根据条件执行
            switch (item.WhereState)
            {
                case WhereExecStateData.WhereExecNone:
                    CacheTxt = imgStr + item.K;
                    whereFlag = true;
                    break;
                case WhereExecStateData.WhereExecGreater:
                    if (!double.TryParse(imgStr, out num))
                    {
                        if (num > double.Parse(item.K))
                        {
                            whereFlag = true;
                        }
                    }
                    break;
                case WhereExecStateData.WhereExecLess:
                    if (!double.TryParse(imgStr, out num))
                    {
                        if (num < double.Parse(item.K))
                        {
                            whereFlag = true;
                        }
                    }
                    break;
                case WhereExecStateData.WhereExecEqual:
                    if (!double.TryParse(imgStr, out num))
                    {
                        if (num == double.Parse(item.K))
                        {
                            whereFlag = true;
                        }
                    }
                    break;
                case WhereExecStateData.WhereExecContains:
                    if (imgStr.Contains(item.K))
                    {
                        whereFlag = true;
                    }
                    break;
                case WhereExecStateData.WhereExecNoContains:
                    if (!imgStr.Contains(item.K))
                    {
                        whereFlag = true;
                    }
                    break;
                case WhereExecStateData.WhereExecKeyDown:
                    if (KeyTxt == item.K)
                    {
                        whereFlag = true;
                    }
                    break;
                case WhereExecStateData.WhereExecFirstChar:
                    break;
                case WhereExecStateData.WhereExecLastChar:
                    break;
                default:
                    break;
            }
            //不通过返回上一个脚本执行
            if (!whereFlag && execScript.ScriptState == ScriptTypeData.ScriptWhereBefore)
            {
                WhereScriptExecState = WhereScriptExecStateData.ScriptWhereBefore;
            }
            if (!whereFlag && execScript.ScriptState == ScriptTypeData.ScriptWhereWait)
            {
                //不通过等待1秒后重新在执行如上操作
                WhereScriptExecState = WhereScriptExecStateData.ScriptWhereWait;

            }
            if (!whereFlag && execScript.ScriptState == ScriptTypeData.ScriptWhereNoWait)
            {
                //不通过等待1秒后重新在执行如上操作
                WhereScriptExecState = WhereScriptExecStateData.ScriptWhereWait;
            }
            if (whereFlag)
            {
                WhereScriptExecState = WhereScriptExecStateData.ScriptWhereSuccess;
            }
        }

        /// <summary>
        /// 快捷设置录制全局的脚本中的  脚本参数
        /// </summary>
        /// <param name="keystate"></param>
        /// <param name="mousestate"></param>
        /// <param name="operationstate"></param>
        /// <param name="wherestate"></param>
        void SetOSList(KeyStateData keystate, MouseStateData mousestate, OperationStateData operationstate, WhereExecStateData wherestate)
        {
            OperationScript os = new OperationScript();
            os.StartX = this.StartX;
            os.StartY = this.StartY;
            os.EndX = this.EndX;
            os.EndY = this.EndY;
            os.K = this.K;
            os.KeyState = keystate;
            os.MouseState = mousestate;
            os.WhereState = wherestate;
            os.OperationState = operationstate;
            os.RunTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
            OSList.Add(os);
        }
        /// <summary>
        /// 加载脚本到脚本列表
        /// </summary>
        void SetScriptList()
        {
            ScriptListView.Items.Clear();
            string json = LogFile.ReadFile(DefaultPath + @"\ScriptInfo.ScriptSetting");
            List<ScriptModel> smlist = JsonConvert.DeserializeObject<List<ScriptModel>>(json);
            if (smlist == null || smlist.Count == 0)
                return;
            MaxScriptOrder = smlist.Max(d => d.ScriptOrder);
            foreach (var item in smlist)
            {
                ListViewItem scriptitem = new ListViewItem();
                scriptitem.Text = item.ScriptOrder.ToString();
                scriptitem.SubItems.Add(item.ScriptName);
                scriptitem.SubItems.Add(EnumDataConvert.ScriptStateToString(item.ScriptState));
                scriptitem.SubItems.Add(item.ScriptPath);
                scriptitem.SubItems.Add(item.ScreenX + ":" + item.ScreenY);
                scriptitem.SubItems.Add(item.ID);
                scriptitem.SubItems.Add(item.ScriptStateExecValue.ToString());
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
        /// <summary>
        /// 增加条件
        /// </summary>
        /// <param name="colorWhere">增加的是否是颜色条件</param>
        private void AddWhereScript(bool colorWhere)
        {
            ScriptInfo si = new ScriptInfo("", (MaxScriptOrder + 1).ToString(), ScriptTypeData.ScriptWhereWait, Screen.PrimaryScreen.Bounds.Width.ToString(), Screen.PrimaryScreen.Bounds.Height.ToString(), ExceScriptStateValue);
            if (si.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //记录下要保存的条件脚本信息
            OSI = new OperationScriptInfo();
            OSI.ID = Guid.NewGuid().ToString("N");
            OSI.ScriptName = si.FileName;
            OSI.ScriptState = si.ScriptState;
            OSI.ScreenX = si.SXWidth;
            OSI.ScreenY = si.SYHeight;
            OSI.ScriptOrder = si.ScriptOrder;
            OSI.ScriptStateExecValue = si.WhereExecValue;

            this.Hide();

            //截取当前屏幕
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            IntPtr dc = g.GetHdc();
            g.ReleaseHdc(dc);
            ScreenBody screenbody = new ScreenBody(colorWhere);
            screenbody.BackgroundImage = img;
            //body.Parent = this;
            if (screenbody.ShowDialog() != DialogResult.OK)
            {
                this.Show();
                return;
            }

            OSList = new List<OperationScript>();
            OSList.Add(screenbody.WhereScript);
            OSI.Detail = OSList;
            this.Show();

            string SCRIPT = JsonConvert.SerializeObject(OSI);
            LogFile.WriteFile(DefaultPath + OSI.ID + ".ScriptWhere", SCRIPT);
            ResetScriptList();
            LogFile.WriteSysLog(string.Format("录入条件脚本完成"));
            MessageBox.Show("添加条件成功");

            ExceScriptName.Text = "";
            ExceScriptPath = "";
        }
        /// <summary>
        /// 修改脚本
        /// </summary>
        private void EditScriptInfo()
        { 
            ScriptInfo si = new ScriptInfo(ExceScriptName.Text, ExceScriptOrder, ExceScriptState, ExceScriptSC.Split(':')[0], ExceScriptSC.Split(':')[1], ExceScriptStateValue);
            if (si.ShowDialog() == DialogResult.OK)
            {
                string json = LogFile.ReadFile(ExceScriptPath);
                var OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                OSI.ScriptName = si.FileName;
                OSI.ScriptState = si.ScriptState;
                OSI.ScreenX = si.SXWidth;
                OSI.ScreenY = si.SYHeight;
                OSI.ScriptOrder = si.ScriptOrder;
                OSI.ScriptStateExecValue = si.WhereExecValue;
                string SCRIPT = JsonConvert.SerializeObject(OSI);
                LogFile.DeleteFile(ExceScriptPath);
                LogFile.WriteFile(ExceScriptPath, SCRIPT);
                ResetScriptList();
                LogFile.WriteSysLog(string.Format("成功修改脚本:{0}", ExceScriptName.Text));
                ExceScriptName.Text = "";
                ExceScriptPath = "";
            }
        }
        #endregion


        private void ScriptListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListStrip.Show(ScriptListView, e.Location);//鼠标右键按下弹出菜单
            }
        }

        private void StatExebtn_Click(object sender, EventArgs e)
        {
            //选择文件确定，生成脚本
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Files|*.png;*.jpg";              // 设定打开的文件类型
            //openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;                       // 打开app对应的路径
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // 打开桌面

            // 如果选定了文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var OSI = new OperationScriptInfo();
                //文件名称是脚本名称
                // 取得文件路径及文件名 
                OSI.ID = Guid.NewGuid().ToString("N");
                OSI.ScriptName = openFileDialog.SafeFileName;
                OSI.ScriptState = ScriptTypeData.ScriptStartExe;
                OSI.ScriptOrder = MaxScriptOrder + 1;
                List<OperationScript> detail = new List<OperationScript>();
                OperationScript script = new OperationScript();
                script.K = openFileDialog.FileName;
                detail.Add(script);
                OSI.Detail = detail;
                string SCRIPT = JsonConvert.SerializeObject(OSI);
                LogFile.WriteFile(DefaultPath + OSI.ID + ".ScriptEXE", SCRIPT);
                ResetScriptList();
                LogFile.WriteSysLog(string.Format("录入脚本完成"));
            }

            //Process proc = Process.Start(execScript.Detail.FirstOrDefault().K);
        }
    }
}
