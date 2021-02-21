using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void numericUpDownLight1_ValueChanged(object sender, int e)
        {
            if (this.ForeColor != Color.Red)
                this.ForeColor = Color.Red;
            else
                this.ForeColor = Color.Blue;
        }
    }
}
