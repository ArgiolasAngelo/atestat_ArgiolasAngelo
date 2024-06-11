using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace atestat_ArgiolasAngelo
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int mod = 0;
       
        
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Jucatori f = new Jucatori();
            if (mod != 0)
            {  
                f.BackColor = System.Drawing.Color.Black;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                f.ShowDialog();
                this.Show();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            reguli f = new reguli();
            this.Hide();
            f.ShowDialog();
            this.Show();
         
        }
    }
}
