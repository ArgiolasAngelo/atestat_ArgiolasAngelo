using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat_ArgiolasAngelo
{
    public partial class reguli : Form
    {
        public reguli()
        {
            InitializeComponent();
            richTextBox1.LoadFile("reguli.rtf");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
