using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public partial class ScreenBody : Form
    {
        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="selectModel">true是point模式 false是矩形选择模式</param>
        public ScreenBody(bool selectModel)
        {
            InitializeComponent(); 
            this.SelectModel = selectModel;
        }

        public OperationScript WhereScript;
        private Graphics MainPainter;
        private Pen DrawPen;
        private bool IsDowned;
        private bool SelectModel;
        private Image BaseImage;
        private Rectangle Rect;
        private bool RectReady;
        private Point DownPoint;
        private bool DrawChange;
        Rectangle[] Rectpoints;
        int TmpPoint;
        int TmpX;
        int TmpY;

        private void MoveDrawRect(Graphics Painter, int Mouse_x, int Mouse_y)
        {
            int width = 0;
            int heigth = 0;
            if (Mouse_y < Rect.Y)
            {
                Rect.Y = Mouse_y;
                heigth = DownPoint.Y - Mouse_y;
            }
            else
            {
                heigth = Mouse_y - DownPoint.Y;
            }
            if (Mouse_x < Rect.X)
            {
                Rect.X = Mouse_x;
                width = DownPoint.X - Mouse_x;
            }
            else
            {
                width = Mouse_x - DownPoint.X;
            }
            Rect.Size = new Size(width, heigth);
            DrawRects(Painter);
        }
        private void DrawRects(Graphics Painter)
        {
            Painter.DrawRectangle(DrawPen, Rect);

            Rectpoints[0].X = Rect.X - 2;
            Rectpoints[0].Y = Rect.Y - 2;
            Rectpoints[1].X = Rect.X - 2;
            Rectpoints[1].Y = Rect.Y - 2 + Rect.Height / 2;
            Rectpoints[2].X = Rect.X - 2;
            Rectpoints[2].Y = Rect.Y - 2 + Rect.Height;
            Rectpoints[3].X = Rect.X - 2 + Rect.Width / 2;
            Rectpoints[3].Y = Rect.Y - 2;
            Rectpoints[4].X = Rect.X - 2 + Rect.Width / 2;
            Rectpoints[4].Y = Rect.Y - 2 + Rect.Height;
            Rectpoints[5].X = Rect.X - 2 + Rect.Width;
            Rectpoints[5].Y = Rect.Y - 2;
            Rectpoints[6].X = Rect.X - 2 + Rect.Width;
            Rectpoints[6].Y = Rect.Y - 2 + Rect.Height / 2;
            Rectpoints[7].X = Rect.X - 2 + Rect.Width;
            Rectpoints[7].Y = Rect.Y - 2 + Rect.Height;
            Painter.FillRectangles(Brushes.Blue, Rectpoints);

        }

        private Image DrawScreen(Image back, int Mouse_x, int Mouse_y)
        {
            Graphics Painter = Graphics.FromImage(back);
            MoveDrawRect(Painter, Mouse_x, Mouse_y);
            return back;
        }

        /// <summary>
        /// 双击确认截图区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_DoubleClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left && Rect.Contains(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y))
            {
                ConfirmArea();
            }
        }


        /// <summary>
        /// 监听鼠标标记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectModel)
            {
                Rect.X = e.X;
                Rect.Y = e.Y;
                ConfirmArea();
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                IsDowned = true;

                if (RectReady == false)
                {
                    Rect.X = e.X;
                    Rect.Y = e.Y;
                    DownPoint = new Point(e.X, e.Y);
                }
                if (RectReady == true)
                {
                    TmpX = e.X;
                    TmpY = e.Y;
                }
                for (int i = 0; i < Rectpoints.Length; i++)
                {
                    if (Rectpoints[i].Contains(e.X, e.Y))
                    {
                        DrawChange = true;
                        TmpPoint = i + 1;
                    }
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                if (RectReady != true)
                {
                    DialogResult d = MessageBox.Show("是否停止绘制", "绘制提示", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        this.Close();
                        return;
                    }
                }
                this.CreateGraphics().DrawImage(BaseImage, 0, 0);
                RectReady = false;
            }

        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDowned = false;
                RectReady = true;
                DrawChange = false;
            }
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseMove(object sender, MouseEventArgs e)
        {

            if (RectReady == false)
            {
                if (IsDowned == true)
                {
                    Image New = DrawScreen((Image)BaseImage.Clone(), e.X, e.Y);
                    MainPainter.DrawImage(New, 0, 0);
                    New.Dispose();
                }
            }
            if (RectReady == true)
            {
                if (Rect.Contains(e.X, e.Y))
                {
                    //this.Cursor = Cursors.Hand;
                    if (IsDowned == true && DrawChange == false)
                    {
                        //和上一次的位置比较获取偏移量
                        Rect.X = Rect.X + e.X - TmpX;
                        Rect.Y = Rect.Y + e.Y - TmpY;
                        //记录现在的位置
                        TmpX = e.X;
                        TmpY = e.Y;
                        MoveRect((Image)BaseImage.Clone(), Rect);
                    }
                }
                if (DrawChange == true && IsDowned == true)
                {
                    switch (TmpPoint)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            ChangeRect((Image)BaseImage.Clone(), e.X, e.Y, ChangeSide.RightTop);
                            break;
                        case 7:
                            ChangeRect((Image)BaseImage.Clone(), e.X, e.Y, ChangeSide.Right);
                            break;
                        case 8:
                            ChangeRect((Image)BaseImage.Clone(), e.X, e.Y, ChangeSide.RightBottom);
                            break;
                    }

                }
            }

        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.Left = 0;
            this.Top = 0;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            BaseImage = this.BackgroundImage;
            MainPainter = this.CreateGraphics();
            DrawPen = new Pen(Brushes.Blue);
            IsDowned = false;
            Rect = new Rectangle();
            RectReady = false;
            DrawChange = false;
            Rectpoints = new Rectangle[8];
            for (int i = 0; i < Rectpoints.Length; i++)
            {
                Rectpoints[i].Size = new Size(4, 4);
            }
            //myRect mRect = new myRect();
            //mRect.Init(0,0,
        }

        private void MoveRect(Image image, Rectangle Rect)
        {
            Graphics Painter = Graphics.FromImage(image);
            Painter.DrawRectangle(DrawPen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
            DrawRects(Painter);
            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        private void ConfirmArea()
        {
            DialogResult d = MessageBox.Show("是否采用当前选择于判断", "信息提示", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {

                //绘制的长宽
                //Rect.Size.Width ,Rect.Size.Height
                //记录相关的位置信息。

                //编辑WhereScript条件脚本
                WhereScript = new OperationScript();
                WhereScript.StartX = Rect.X; //起始坐标
                WhereScript.StartY = Rect.Y;
                WhereScript.EndX = Rect.X + Rect.Size.Width; //绘制的结束点
                WhereScript.EndY = Rect.Y + Rect.Size.Height;
                WhereScript.KeyState = KeyStateData.KeyNone;
                WhereScript.MouseState = MouseStateData.MouseNone;
                WhereScript.RunTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
                string whereStr = string.Empty;
                if (!SelectModel)
                {
                    WhereScript.OperationState = OperationStateData.OperationRectWhere;
                    whereStr = RecognizeImage.SpireRecognize(CaptureScreenImage.CaptureScreen(Rect.X+1, Rect.Y + 1, Rect.Size.Width, Rect.Size.Height));
                }
                else
                {
                    WhereScript.OperationState = OperationStateData.OperationPointWhere;
                    Bitmap img = new Bitmap(BaseImage.Width, BaseImage.Height);
                    Graphics g = Graphics.FromImage(img);
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0),new Size(BaseImage.Width, BaseImage.Height));
                    IntPtr dc = g.GetHdc();
                    g.ReleaseHdc(dc);
                    whereStr = ColorConvertHelper.ColorToHex(img.GetPixel(Rect.X, Rect.Y));
                }

                //选择条件操作
                WhereScriptInfo whereScript = new WhereScriptInfo(whereStr);
                if (whereScript.ShowDialog() == DialogResult.OK)
                {
                    WhereScript.K = whereScript.WhereValue;
                    WhereScript.WhereState = whereScript.WhereExecState;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {

                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }


        private void ChangeRect(Image image, int Position_x, int Position_y, ChangeSide Side)
        { 
            Graphics Painter = Graphics.FromImage(image);
            switch (Side)
            {
                case ChangeSide.Left:
                    break;
                case ChangeSide.LeftBottom:
                    break;
                case ChangeSide.LeftTop:
                    Rect.Y = Position_y;
                    break;
                case ChangeSide.Bottom:
                    break;
                case ChangeSide.Top:
                    break;
                case ChangeSide.Right:
                    if (Position_x < Rect.X)
                    {
                        Rect.Size = new Size(TmpX - Position_x + Rect.Width, Rect.Height);
                        Rect.X = Position_x;
                        //记录现在的位置
                        TmpX = Position_x;
                    }
                    else
                        Rect.Size = new Size(Position_x - Rect.X, Rect.Height);
                    break;
                case ChangeSide.RightBottom:
                    Rect.Size = new Size(Position_x - Rect.X, Position_y - Rect.Y);
                    break;
                case ChangeSide.RightTop:
                    //Rect.Y = Position_y;
                    Rect.Size = new Size(Position_x - Rect.X, Rect.Height + Rectpoints[5].Y - Position_y);
                    break;
            }
            //Painter.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
            DrawRects(Painter);
            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
            /*
            MainPainter.DrawImage(New, 0, 0);
            New.Dispose();*/
        }

        private void ChangeRect(Image image, int Position, ChangeSide Side)
        {

        }

        enum ChangeSide
        {
            Left,
            LeftTop,
            LeftBottom,
            Right,
            RightTop,
            RightBottom,
            Top,
            Bottom
        }

        struct myRect
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Rectangle[] RectPoints;

            public void Init(int x, int y, int width, int height, int number)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                RectPoints = new Rectangle[number];
            }
        }

        private void ScreenBody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmArea();
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult d = MessageBox.Show("是否停止绘制", "信息提示", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            }
        }
    }
}