using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySerialPort
{
    public partial class myMsgBox : Form
    {
        public myMsgBox()
        {
            InitializeComponent();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

    private void buttonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        public void Show(string str, Color color)
        {
            labelMessageBox.Text = str;
            labelMessageBox.ForeColor = color;

            DialogResult = DialogResult.None;
            this.ShowDialog();
        }

        private void myMsgBox_Load(object sender, EventArgs e)
        {
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度

            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//获取显示器屏幕高度

            this.Location = new Point(xWidth / 2, yHeight / 2);//两个参数，一个是距离屏幕左边的高度，一个是距离上方的高度
        }
    }
}
