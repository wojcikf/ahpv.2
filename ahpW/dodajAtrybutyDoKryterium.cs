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
    public partial class dodajAtrybutyDoKryterium : Form
    {
        private Form1 x = null;
        List<atrybutyClass> atrybutyList = new List<atrybutyClass>();
        String nazwaKryterium;
        public dodajAtrybutyDoKryterium(Form1 f, List<atrybutyClass> atrybuty, String nazwa)
        {
            atrybutyClass a = new atrybutyClass();
            InitializeComponent();
            x = f;
            atrybutyList = atrybuty;
            nazwaKryterium = nazwa;
            label1.Text = nazwa;
            addData(atrybuty);
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void addData (List<atrybutyClass> atrybuty){

            foreach (var x in atrybuty) {
                dataGridView1.Columns.Add(x.nazwaAtrybutu, x.nazwaAtrybutu);
                dataGridView1.Rows.Add();
            }


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = atrybuty[i].nazwaAtrybutu;
            }

            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            try
            {

                for (int i = 0; i < atrybuty.Count; i++)
                {
                    for (int j = 0; j < atrybuty.Count; j++)
                    {
                        if (i == j)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = 1;
                            dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Black;
                            dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.White;
                        }
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            for (int i = 0; i < atrybutyList.Count; i++)
            {
                for (int j = 0; j < atrybutyList.Count; j++)
                {
                    if (i > j)
                    {
                        dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                        try
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                var waga = dataGridView1.Rows[i].Cells[j].Value;
                                string waga1 = waga.ToString();
                                double w = Convert.ToDouble(waga1);
                                w = 1 / w;
                                dataGridView1.Rows[j].Cells[i].Value = w;
                                dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                            }
                        }
                        catch (Exception x)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = null;
                            dataGridView1.Rows[i].Cells[j].Value = null;
                            MessageBox.Show(x.Message);
                        }
                    }
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
