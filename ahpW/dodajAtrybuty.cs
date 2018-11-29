using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ahpW
{
    public partial class dodajAtrybuty : Form

    {
        private Form1 x = null;
        public dodajAtrybuty(Form1 f)
        {
            InitializeComponent();
            x = f;
            this.Text = "Dodaj nową alternatywę";
        }

        private void dodajAtrybuty_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            atrybutyClass a = new atrybutyClass(textBox1.Text);
            x.addAtrybuty(a);
            Close();
        }
    }
}
