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

        }
    }
}
