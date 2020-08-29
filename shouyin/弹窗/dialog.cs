using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace shouyin
{
    public delegate void TransfDelegate(int value);//异窗口传值，委托
    public partial class dialog : Form
    {
        public dialog()
        {
            InitializeComponent();
        }
        public event TransfDelegate TransfEvent;
        private void dialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransfEvent(Convert.ToInt16(numericUpDown1.Value));
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
