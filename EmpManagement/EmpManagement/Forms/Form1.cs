using EmpManagement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, "Close");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(pictureBox2, "Minimize");
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmReg reg = new FrmReg();
            reg.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
