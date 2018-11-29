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
    public partial class dodajKryterium : Form
    {
        private Form1 x = null;
        public dodajKryterium(Form1 f)
        {
            InitializeComponent();
            x = f;
            this.Text = "Dodaj nowe kryterium";
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            kryteriaClass k = new kryteriaClass(textBox1.Text);
            if (k.nazwaKryterium != "")
            {
                x.addKryterium(k);
                x.addDataColumnToGrid(k);
                Refresh();
                x.addDataRowToGrid();
                Close();
            }
            else {
                MessageBox.Show("Pole musi byc uzupelnione.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
