using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace cuoikycnpm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int startpoint=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            myprogress.Value = startpoint;
            if (myprogress.Value == 100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide();
                log.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
