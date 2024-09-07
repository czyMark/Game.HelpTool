using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public partial class EditScriptNode : Form
    {
        public EditScriptNode()
        {
            InitializeComponent();
            InitListView();
        }

        void InitListView()
        {
            this.OperationListView.Items.Clear();
            this.OperationListView.Columns.Clear();
            this.OperationListView.Columns.Add("序号", 50, HorizontalAlignment.Center);
            this.OperationListView.Columns.Add("运行时间", 200, HorizontalAlignment.Center);
            this.OperationListView.Columns.Add("脚本状态", 100, HorizontalAlignment.Center);
            this.OperationListView.Columns.Add("输入", 500, HorizontalAlignment.Center);
            this.OperationListView.GridLines = true;//显示行与行之间的分隔线   
            this.OperationListView.FullRowSelect = true;//要选择就是一行   
            this.OperationListView.View = View.Details;//定义列表显示的方式  
            this.OperationListView.Scrollable = true;//需要时候显示滚动条  
            this.OperationListView.MultiSelect = false; // 不可以多行选择   
            this.OperationListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.OperationListView.Visible = true;//lstView可见  
        }

        public string ExceScriptPath;
        OperationScriptInfo OSI;
        public EditScriptNode(string ExceScriptPath)
        {
            InitializeComponent();
            this.ExceScriptPath = ExceScriptPath;
            InitListView();
            //依据文件路径加载数据。如果加载错误，提示错误信息后关闭当前界面
            RestSeript(ExceScriptPath);
            InitHook();

            ListStrip.Items.Add("删除操作");
            ListStrip.Items.Add("修改操作");
            ListStrip.Items.Add("向上移动");
            ListStrip.Items.Add("修改时间");
            ListStrip.Items.Add("修改按键文本");
            ListStrip.ItemClicked += ListStrip_ItemClicked;

            this.FormClosing += EditScriptNode_FormClosing;
            this.OperationListView.KeyDown += OperationListView_KeyDown;

        }
        private int selectedindex = 0;
        private void OperationListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (OperationListView.Items.Count == 0)
                {
                    return;
                }
                OPerationUp();
                OperationListView.Items[selectedindex].Selected = true;
                OperationListView.Items[selectedindex].Focused = true;
            }
        }

        private void EditScriptNode_FormClosing(object sender, FormClosingEventArgs e)
        {
            Khook.Stop();
        }

        //钩子监听
        KeyboardHook Khook;
        MouseHook Mhook;
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


        //钩子鼠标操作
        private void M_hook_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (SystemState == false)
                return;
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
            if (e.Button == MouseButtons.Right)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //钩子鼠标操作
        private void M_hook_MouseClickUpEvent(object sender, MouseEventArgs e)
        {
            if (SystemState == false)
                return;
            if (e.Button == MouseButtons.Left)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(KeyStateData.KeyNone, MouseStateData.MouseLeft, OperationStateData.OperationMouse, WhereExecStateData.WhereExecNone);
            }
            if (e.Button == MouseButtons.Right)
            {
                EndX = e.X;
                EndY = e.Y;
                SetOSList(KeyStateData.KeyNone, MouseStateData.MouseRight, OperationStateData.OperationMouse, WhereExecStateData.WhereExecNone);
            }
        }
        #region 录制记录参数
        int StartX { get; set; }
        int StartY { get; set; }
        int EndX { get; set; }
        int EndY { get; set; }
        string K { get; set; }
        #endregion
        //钩子键盘操作
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (SystemState == false)
                return;


            K = SendChartConvert.ChartConver(e.KeyCode.ToString());
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
                case (int)Keys.F10:
                    if (EditState == false)
                    {
                        OSI.Detail.Add(tempos);
                    }
                    else
                    {
                        OperationScript os = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
                        if (os == null)
                        {
                            MessageBox.Show("操作错误请刷新列表");
                            return;
                        }
                        os.StartX = tempos.StartX;
                        os.StartY = tempos.StartY;
                        os.EndX = tempos.EndX;
                        os.EndY = tempos.EndY;
                        os.K = tempos.K;
                        os.KeyState = tempos.KeyState;
                        os.MouseState = tempos.MouseState;
                        os.WhereState = tempos.WhereState;
                        os.OperationState = tempos.OperationState;
                        os.RunTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
                    }
                    //一次操作完成后记录到文件中
                    string SCRIPT = JsonConvert.SerializeObject(OSI);
                    LogFile.WriteFile(ExceScriptPath, SCRIPT);
                    SystemState = false;
                    User32Api.DefaultMuoseCursor();
                    RestSeript(ExceScriptPath);
                    this.Show();
                    break;
                default:
                    SetOSList(KeyStateData.KeyNone, MouseStateData.MouseNone, OperationStateData.OperationKey, WhereExecStateData.WhereExecNone);
                    break;
            }

        }
        private OperationScript tempos = new OperationScript();
        /// <summary>
        /// 快捷设置录制全局的脚本中的  脚本参数
        /// </summary>
        /// <param name="keystate"></param>
        /// <param name="mousestate"></param>
        /// <param name="operationstate"></param>
        /// <param name="wherestate"></param>
        void SetOSList(KeyStateData keystate, MouseStateData mousestate, OperationStateData operationstate, WhereExecStateData wherestate)
        {
            tempos.StartX = this.StartX;
            tempos.StartY = this.StartY;
            tempos.EndX = this.EndX;
            tempos.EndY = this.EndY;
            tempos.K = this.K;
            tempos.KeyState = keystate;
            tempos.MouseState = mousestate;
            tempos.WhereState = wherestate;
            tempos.OperationState = operationstate;
            tempos.RunTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
        }

        private void RestSeript(string ExceScriptPath)
        {
            try
            {
                OperationListView.Items.Clear();
                string json = LogFile.ReadFile(ExceScriptPath);
                OSI = JsonConvert.DeserializeObject<OperationScriptInfo>(json);
                int i = 1;
                foreach (var item in OSI.Detail)
                {

                    ListViewItem scriptitem = new ListViewItem();
                    scriptitem.Text = (i++).ToString();
                    scriptitem.SubItems.Add(item.RunTime);
                    scriptitem.SubItems.Add(item.OperationState == OperationStateData.OperationMouse ? "执行鼠标操作" : "执行键盘操作");
                    scriptitem.SubItems.Add(item.OperationState == OperationStateData.OperationMouse ?
                       string.Format("S{0}:{1}-E{2}:{3}", item.StartX, item.StartY, item.EndX, item.EndY)
                        : item.K);
                    OperationListView.Items.Add(scriptitem);
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteSysLog(ex.Message.ToString());
                MessageBox.Show("脚本文件加载错误！请刷新脚本列表后在重试");
                this.Close();
            }
        }

        private void Cannlbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            //依据文件路径加载数据。如果加载错误，提示错误信息后关闭当前界面
            RestSeript(ExceScriptPath);
        }

        public bool SystemState;//设置成脚本录制状态
        public bool EditState;  //是添加还是修改
        //鼠标光标路径
        string CursorPath = System.Windows.Forms.Application.StartupPath + @"\Cur\Frequence Normal.cur";
        private void Addbtn_Click(object sender, EventArgs e)
        {
            //隐藏当前窗口
            this.Hide();
            //修改鼠标
            User32Api.SetMuoseCursor(CursorPath);
            //设置成脚本录制状态
            SystemState = true;
            //脚本添加状态
            EditState = false;
        }

        private void OperationListView_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ListStrip.Show(OperationListView, e.Location);//鼠标右键按下弹出菜单
            }
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
                        case "删除操作":
                            {

                                if (osSelected == null)
                                {
                                    MessageBox.Show("请选择操作");
                                    return;
                                }
                                OperationScript operation = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
                                if (operation == null)
                                {
                                    MessageBox.Show("操作错误请刷新列表");
                                    return;
                                }
                                OSI.Detail.Remove(operation);

                                //刷新存储数据
                                string SCRIPT = JsonConvert.SerializeObject(OSI);
                                LogFile.WriteFile(ExceScriptPath, SCRIPT);
                                //刷新脚本列表  
                                RestSeript(ExceScriptPath);
                            }
                            break;
                        case "修改操作":
                            //隐藏当前窗口
                            this.Hide();
                            //修改鼠标
                            User32Api.SetMuoseCursor(CursorPath);
                            //设置成脚本录制状态
                            SystemState = true;
                            //脚本修改状态
                            EditState = true;
                            break;
                        case "向上移动":
                            OPerationUp();

                            break;
                        case "修改时间":
                            {
                                if (osSelected == null)
                                {
                                    MessageBox.Show("请选择操作");
                                    return;
                                }
                                OperationScript operation = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
                                if (operation == null)
                                {
                                    MessageBox.Show("操作错误请刷新列表");
                                    return;
                                }
                                EditText edit = new EditText(true, operation.RunTime);
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    operation.RunTime = edit.content;
                                    //刷新存储数据
                                    string SCRIPT = JsonConvert.SerializeObject(OSI);
                                    LogFile.WriteFile(ExceScriptPath, SCRIPT);
                                    //刷新脚本列表  
                                    RestSeript(ExceScriptPath);
                                }
                            }
                            break;
                        case "修改按键文本":

                            {
                                if (osSelected == null)
                                {
                                    MessageBox.Show("请选择操作");
                                    return;
                                }
                                OperationScript operation = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
                                if (operation == null)
                                {
                                    MessageBox.Show("操作错误请刷新列表");
                                    return;
                                }
                                EditText edit = new EditText(false, operation.K);
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    operation.K = edit.content;
                                    //刷新存储数据
                                    string SCRIPT = JsonConvert.SerializeObject(OSI);
                                    LogFile.WriteFile(ExceScriptPath, SCRIPT);
                                    //刷新脚本列表  
                                    RestSeript(ExceScriptPath);
                                }
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
        }
        OperationScript osSelected;

        private void OPerationUp()
        {

            if (osSelected == null)
            {
                MessageBox.Show("请选择操作");
                return;
            }
            OperationScript operation = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
            int location = OSI.Detail.IndexOf(operation);
            if (location == 0)
            {

                MessageBox.Show("已经是第一个了");
                return;
            }
            DeepCopy.Swap(OSI.Detail, location, location - 1);
            selectedindex = location;
            //刷新存储数据
            string SCRIPT = JsonConvert.SerializeObject(OSI);
            LogFile.WriteFile(ExceScriptPath, SCRIPT);
            //刷新脚本列表  
            RestSeript(ExceScriptPath);

        }
        private void OperationListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OperationListView.SelectedIndices != null && OperationListView.SelectedIndices.Count > 0)
            {
                if (OperationListView.FocusedItem == null)
                    return;
                osSelected = new OperationScript();
                osSelected.K = OperationListView.FocusedItem.SubItems[3].Text;
                osSelected.RunTime = OperationListView.FocusedItem.SubItems[1].Text;
                osSelected.OperationState = EnumDataConvert.StringToOperationState(OperationListView.FocusedItem.SubItems[2].Text);
            }
            else
            {
                osSelected = null;
            }
        }

        private void Execbtn_Click(object sender, EventArgs e)
        {
            if (osSelected == null)
            {
                MessageBox.Show("请选择操作");
                return;
            }
            OperationScript operation = OSI.Detail.Where(d => d.RunTime == osSelected.RunTime && d.OperationState == osSelected.OperationState).FirstOrDefault();
            if (operation == null)
            {
                MessageBox.Show("操作错误请刷新列表");
                return;
            }
            this.Hide();
            //启动执行
            Action<OperationScript> action = (OperationScript os) =>
            {
                //记录执行脚本的信息
                LogFile.WriteSysLog(string.Format("执行操作{0}      {1}      {2}", operation.RunTime, operation.OperationState == OperationStateData.OperationMouse ? "执行鼠标操作" : "执行键盘操作", operation.OperationState == OperationStateData.OperationMouse ?
                   string.Format("S{0}:{1}-E{2}:{3}", operation.StartX, operation.StartY, operation.EndX, operation.EndY)
                    : operation.K));
                if (operation.OperationState == OperationStateData.OperationMouse)
                {
                    switch (operation.MouseState)
                    {
                        case MouseStateData.MouseRight:
                            RMouseHD(operation.StartX, operation.StartY, operation.EndX, operation.EndY, 1, 1);
                            break;
                        default:
                            LMouseHD(operation.StartX, operation.StartY, operation.EndX, operation.EndY, 1, 1);
                            break;
                    }
                }
                else if (operation.OperationState == OperationStateData.OperationKey)
                {
                    Thread.Sleep(1000);
                    switch (operation.KeyState)
                    {
                        case KeyStateData.KeyGuid:
                            SendKeys.SendWait(Guid.NewGuid().ToString("N"));
                            break;
                        case KeyStateData.KeyNone:
                            SendKeys.SendWait(operation.K);
                            break;
                        default:
                            SendKeys.SendWait(operation.K);
                            break;
                    }
                }

            };
            IAsyncResult asyncResult = action.BeginInvoke(operation, null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            this.Show();
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
    }
}
