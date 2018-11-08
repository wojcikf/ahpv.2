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
    public partial class Form1 : Form
    {
        List<kryteriaClass> kryteriaList = new List<kryteriaClass>();
        List<atrybutyClass> atrybutyList = new List<atrybutyClass>();
        List<WagiClass> wagiList = new List<WagiClass>();
        int[,] wagiKryteria = new int[5,5];
       static int x = 0;
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kryteriaList.Count <= 8)
            {
                dodajKryterium f = new dodajKryterium(this);
                DialogResult dr = f.ShowDialog();
            }
            else {
                button1.Visible = false;
            }
        }

        public void addKryterium(kryteriaClass k) {
            kryteriaList.Add(k);

            comboBox1.Items.Add(k.nazwaKryterium);

            if (kryteriaList.Count == 1)
            {
                treeView1.Nodes.Add("KryteriaMain", "Kryteria");
                treeView1.Nodes["KryteriaMain"].Nodes.Add(k.nazwaKryterium);
            }
            else
            {
                treeView1.Nodes["KryteriaMain"].Nodes.Add(k.nazwaKryterium);
            }                
        }
        public void addAtrybuty(atrybutyClass a)
        {
            atrybutyList.Add(a);

            if (atrybutyList.Count == 1)
            {
                treeView1.Nodes.Add("AtrybutyMain", "Atrybuty");
                treeView1.Nodes["AtrybutyMain"].Nodes.Add(a.nazwaAtrybutu);
            }
            else {
                treeView1.Nodes["AtrybutyMain"].Nodes.Add(a.nazwaAtrybutu);
            }

        }
        public void addWagi()
        {


            /*   for (int j = 1; j < kryteriaList.Count; j++)
               {
                   for (int i = 1; i < kryteriaList.Count; i++)
                   {
                       if (i < j)
                       {
                           wagiKryteria[i,j] = i;
                           dataGridView1.Rows[j].Cells[i].Value = i;
                       }

                   }
           }*/

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i > j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = i;
                        wagiKryteria[i, j] = i;
                    }
                }
            }
        }

        public void addDataRowToGrid() {

           

        }
        public void addDataColumnToGrid(kryteriaClass k)
        {
            dataGridView1.Columns.Add(k.nazwaKryterium, k.nazwaKryterium);
            dataGridView1.Rows.Add();


            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = kryteriaList[i].nazwaKryterium;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            

            try
            {

                for (int i = 0; i < kryteriaList.Count; i++)
                {
                    for (int j = 0; j < kryteriaList.Count; j++)
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

        public void addAtrubutyDoKryterium(atrybutyClass a)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i < kryteriaList.Count; i++)
            {
                for (int j = 0; j < kryteriaList.Count; j++)
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
                        catch (Exception x) {
                            dataGridView1.Rows[j].Cells[i].Value = null;
                            dataGridView1.Rows[i].Cells[j].Value = null;
                            MessageBox.Show(x.Message);
                        }
                    }
                }

            }
        
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dodajAtrybuty a = new dodajAtrybuty(this);
            DialogResult dr = a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dodajWagi w = new dodajWagi(this, kryteriaList);
            DialogResult dr = w.ShowDialog();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            addWagi();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;
            MessageBox.Show(selected);
            dodajAtrybutyDoKryterium a = new dodajAtrybutyDoKryterium(this, atrybutyList, selected);
            DialogResult dr = a.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dodajAtrybuty a = new dodajAtrybuty(this);
            DialogResult dr = a.ShowDialog();
        }
    }
}
