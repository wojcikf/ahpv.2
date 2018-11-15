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
        static int y = 0;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                object[,] wAtrybuty = new object[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                double[] vAtrybuty = new double[atrybutyList.Count + 1];
                double[] alfaAtrybuty= new double[atrybutyList.Count + 1];
                double row_sum = 1;
                double sWag = 0;
                double wagaAlfa = 0;
                for (int x = 0; x < wAtrybuty.GetLength(0); x++)
                    for (int i = 0; i < wAtrybuty.GetLength(1); i++)
                        wAtrybuty[x, i] = dataGridView1.Rows[x].Cells[i].Value;

                for (int i = 0; i < wAtrybuty.GetLength(0); i++)
                {
                    if (i > 0)
                    {
                        row_sum = Math.Pow(row_sum, 1.0 / atrybutyList.Count);
                        vAtrybuty[i] = row_sum;
                    }
                    row_sum = 1;
                    for (int j = 0; j < wAtrybuty.GetLength(1); j++)
                    {
                        row_sum = row_sum * Convert.ToDouble(wAtrybuty[i, j]);
                    }
                }

                for (int i = 1; i <= atrybutyList.Count + 1; i++)
                {

                    if (i <= atrybutyList.Count)
                    {
                    }
                    else
                    {

                        for (int x = 1; x <= atrybutyList.Count; x++)
                        {
                            sWag += vAtrybuty[x];
                        }
                        Label lbl = new Label();
                        this.Controls.Add(lbl);
                        lbl.Top = 350 + y * 20;
                        lbl.Size = new Size(100, 16);
                        lbl.ForeColor = Color.Black;
                        lbl.Text = "Suma: " + sWag.ToString("0.00");
                        lbl.Left = 10;
                        y = y + 1;
                    }
                }
                double sumaAlfaKryteria = 0;
                for (int i = 1; i <= atrybutyList.Count; i++)
                {
                    wagaAlfa = (vAtrybuty[i] / sWag) * atrybutyList.Count;
                    alfaAtrybuty[i] = wagaAlfa;
                    sumaAlfaKryteria += alfaAtrybuty[i];
                }
                Label lbl2 = new Label();
                this.Controls.Add(lbl2);
                lbl2.Top = 350 + y * 20;
                lbl2.Size = new Size(100, 16);
                lbl2.ForeColor = Color.Black;
                lbl2.Text = "Suma alfa: " + sumaAlfaKryteria.ToString("0.00");
                lbl2.Left = 10;
                y = y + 1;
            }

            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }
    }
}
