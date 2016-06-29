using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDelegadosWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button_Click);
            button2.Click += new EventHandler(button_Click);
            button3.Click += new EventHandler(button_Click);
            button4.Click += new EventHandler(button_Click);
            button5.Click += new EventHandler(button_Click);
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
