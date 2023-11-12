using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpManagement.Forms
{
    public partial class FrmReg : Form
    {
        public FrmReg()
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
    }
}
