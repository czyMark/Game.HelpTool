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
    public partial class EditText : Form
    {
        public EditText()
        {
            InitializeComponent();
        }
        bool type;
        public EditText(bool type,string content)
        {
            InitializeComponent();
            this.type = type;
            this.content = content;
            ContentTextBox.Text = content;
        }
       public  string content = string.Empty;
        private void Savebtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (type)
            {
                DateTime dateTime = new DateTime();
                if (DateTime.TryParse(ContentTextBox.Text, out dateTime))
                {
                    content = dateTime.ToString("yyyy年MM月dd日 HH:mm:ss.fff");
                }
                else
                {
                    MessageBox.Show("日期输入错误，请重新输入");
                    return;
                }
            }
            else
            {
                content = ContentTextBox.Text;
            }
            this.Close();
        }
    }
}
