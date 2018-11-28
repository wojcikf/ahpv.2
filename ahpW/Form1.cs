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
        List<List<double>> alfaAlternatywy = new List<List<double>>();
        static int sizeKryteria = 0;
        public double[] alfaKryt = new double[sizeKryteria];
        int[,] wagiKryteria = new int[5, 5];
        public List<double> rTab = new List<double> {0, 0, 0.52, 0.89, 1.11, 1.25, 1.35, 1.40, 1.45, 1.49};

        bool wagiCheck = false;

        float[] wKryteria = new float[10];
        static int x = 0;
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
            comboBox1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kryteriaList.Count <= 8)
            {
                dodajKryterium f = new dodajKryterium(this);
                DialogResult dr = f.ShowDialog();
            }
            else
            {
                button1.Visible = false;
            }
        }
        public bool checkValues(object[,] tab)
        {
            for (int x = 0; x < kryteriaList.Count; x++)
            {
                for (int i = 0; i < kryteriaList.Count; i++)
                {
                    if ((object)tab[x, i] == null)
                    {
                        MessageBox.Show("Uzupełnij macierz do końca.");
                        return false;
                    } 
                }
            }
            wagiCheck = true;
            comboBox1.Enabled = true;
            return true;
        }
        public void addKryterium(kryteriaClass k)
        {

            kryteriaList.Add(k);

            comboBox1.Items.Add(k.nazwaKryterium);

            if (kryteriaList.Count == 1)
            {
                treeView1.Nodes.Add("KryteriaMain", "Kryteria");
                treeView1.Nodes["KryteriaMain"].Nodes.Add(k.nazwaKryterium);
                treeView1.ExpandAll();
            }
            else
            {
                treeView1.Nodes["KryteriaMain"].Nodes.Add(k.nazwaKryterium);
            }

            if (kryteriaList.Count > 1)
                button3.Enabled = true;

            if (kryteriaList.Count > 1 && atrybutyList.Count > 1 && wagiCheck == true)
                comboBox1.Enabled = true;

        }
        public void addAtrybuty(atrybutyClass a)
        {
            if (a.nazwaAtrybutu != "")
            {
                atrybutyList.Add(a);

                if (atrybutyList.Count == 1)
                {
                    treeView1.Nodes.Add("AtrybutyMain", "Atrybuty");
                    treeView1.Nodes["AtrybutyMain"].Nodes.Add(a.nazwaAtrybutu);
                    treeView1.ExpandAll();
                }
                else
                {
                    treeView1.Nodes["AtrybutyMain"].Nodes.Add(a.nazwaAtrybutu);
                }


                if (kryteriaList.Count > 1 && atrybutyList.Count > 1 && wagiCheck == true)
                    comboBox1.Enabled = true;
            }
            else {
                MessageBox.Show("Musisz podać atrybut");
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

        public void addDataRowToGrid()
        {



        }
        public void addDataColumnToGrid(kryteriaClass k)
        {
            dataGridView1.Columns.Add(k.nazwaKryterium, k.nazwaKryterium);
            dataGridView1.Rows.Add();


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
            int index = comboBox.SelectedIndex;
            dodajAtrybutyDoKryterium a = new dodajAtrybutyDoKryterium(this, atrybutyList, selected, index, alfaAlternatywy);
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

        private void button3_Click_1(object sender, EventArgs e)
        {

            try
            {
                sizeKryteria = kryteriaList.Count;
                object[,] wKryteria = new object[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                double[] vKryteria = new double[kryteriaList.Count + 1];
                double[] alfaKryteria = new double[kryteriaList.Count + 1];

                double row_sum = 1;
                double column_sum = 0;
                double sWag = 0;
                double wagaAlfa = 0;

                for (int x = 0; x < wKryteria.GetLength(0); x++)
                    for (int i = 0; i < wKryteria.GetLength(1); i++)
                        wKryteria[x, i] = dataGridView1.Rows[x].Cells[i].Value;

                for (int i = 0; i < wKryteria.GetLength(0); i++)
                {
                    if (i > 0)
                    {
                        row_sum = Math.Pow(row_sum, 1.0 / kryteriaList.Count);
                        vKryteria[i] = row_sum;
                    }
                    row_sum = 1;
                    for (int j = 0; j < wKryteria.GetLength(1); j++)
                    {
                        row_sum = row_sum * Convert.ToDouble(wKryteria[i, j]);
                    }
                }
                if (checkValues(wKryteria) == true)
                {
                    for (int i = 1; i <= kryteriaList.Count + 1; i++)
                    {

                        if (i <= kryteriaList.Count)
                        {
                        }
                        else
                        {

                            for (int x = 1; x <= kryteriaList.Count; x++)
                            {
                                sWag += vKryteria[x];
                            }
                            label3.Visible = true;
                            Label lbl = new Label();
                            this.Controls.Add(lbl);
                            lbl.Top = 80 + x * 20;
                            lbl.Size = new Size(100, 16);
                            lbl.ForeColor = Color.Black;
                            lbl.Text = "Suma: " + sWag.ToString("0.00");
                            lbl.Left = 670;
                            x = x + 1;

                        }
                    }
                    double sumaAlfaKryteria = 0;
                    for (int i = 1; i <= kryteriaList.Count; i++)
                    {
                        wagaAlfa = (vKryteria[i] / sWag) * kryteriaList.Count;
                        alfaKryteria[i] = wagaAlfa;
                        sumaAlfaKryteria += alfaKryteria[i];
                    }
                    Label lbl2 = new Label();
                    this.Controls.Add(lbl2);
                    lbl2.Top = 80 + x * 20;
                    lbl2.Size = new Size(100, 16);
                    lbl2.ForeColor = Color.Black;
                    lbl2.Text = "Suma alfa: " + sumaAlfaKryteria.ToString("0.00");
                    lbl2.Left = 670;
                    x = x + 1;

                    /*END WIERSZE*/

                    /*START COLUMN */


                    object[,] wKryteriaColumn = new object[dataGridView1.Columns.Count, dataGridView1.Rows.Count];
                    double[] vKryteriaColumn = new double[kryteriaList.Count + 1];
                    double[] alfaKryteriaColumn = new double[kryteriaList.Count + 1];

                    double column_sumColumn = 0;
                    double sWagColumn = 0;
                    double wagaAlfaColumn = 0;


                    for (int x = 0; x < wKryteriaColumn.GetLength(0); x++)
                        for (int i = 0; i < wKryteriaColumn.GetLength(0); i++)
                            wKryteriaColumn[i, x] = dataGridView1.Rows[x].Cells[i].Value;

                    for (int i = 0; i < wKryteriaColumn.GetLength(0) + 1; i++)
                    {
                        if (i > 0)
                        {
                            column_sumColumn = column_sumColumn * alfaKryteria[i];
                            vKryteriaColumn[i] = column_sumColumn;
                        }
                        column_sumColumn = 0;
                        if (i < kryteriaList.Count)
                        {
                            for (int j = 0; j < wKryteriaColumn.GetLength(0); j++)
                            {
                                column_sumColumn += Convert.ToDouble(wKryteriaColumn[i, j]);
                            }
                        }
                    }

                    for (int i = 1; i <= kryteriaList.Count; i++)
                    {

                        if (i <= kryteriaList.Count)
                        {
                        }
                        else
                        {

                            for (int x = 1; x <= kryteriaList.Count; x++)
                            {
                                sWagColumn += vKryteriaColumn[x];
                            }

                        }
                    }
                    double sumaAlfaKryteriaColumn = 0;
                    for (int i = 1; i <= kryteriaList.Count; i++)
                    {
                        sumaAlfaKryteriaColumn += vKryteriaColumn[i];
                    }
                    Label lbl4 = new Label();
                    this.Controls.Add(lbl4);
                    lbl4.Top = 100 + x * 20;
                    lbl4.Size = new Size(200, 16);
                    lbl4.ForeColor = Color.Black;
                    lbl4.Text = "Suma lambda max: " + sumaAlfaKryteriaColumn.ToString("0.00");
                    lbl4.Left = 670;
                    x = x + 1;

                    double n = ((sumaAlfaKryteriaColumn / (kryteriaList.Count - 1)));

                    Label lbl5 = new Label();
                    this.Controls.Add(lbl5);
                    lbl5.Top = 100 + x * 20;
                    lbl5.Size = new Size(200, 16);
                    lbl5.ForeColor = Color.Black;
                    lbl5.Text = "Suma lambda max / n: " + (sumaAlfaKryteriaColumn / (kryteriaList.Count)).ToString("0.00");
                    lbl5.Left = 670;
                    x = x + 1;

                    double ci = ((sumaAlfaKryteriaColumn / (kryteriaList.Count)) - kryteriaList.Count) / (kryteriaList.Count - 1);
                    double cl = Math.Abs(ci / rTab[kryteriaList.Count]);
                    if (ci < 0.1 && cl < 0.1)
                        MessageBox.Show("Spójność macierzy w normie. ");


                    for (int i = 0; i <= kryteriaList.Count; i++)
                    {
                        alfaAlternatywy.Add(new List<double>());
                    }

                    alfaKryt = alfaKryteria;
                }
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           List<double> wynikKoncowy = new List<double>();
            double result = 0.0;
            for (int k = 0; k < atrybutyList.Count; k++)
            {
                result = 0.0;
                for (int j = 1; j < kryteriaList.Count; j++)
                {
                    result += alfaKryt[j] * alfaAlternatywy[j][k];
                }
                wynikKoncowy.Add(result);
            }
            double maxKoncowy = wynikKoncowy.Max();
            int idKoncowy = wynikKoncowy.FindIndex(x => x == maxKoncowy);
            var nKoncowy = kryteriaList.SingleOrDefault(x => x.Id == idKoncowy);

            string nazwKoncowy = nKoncowy.nazwaKryterium;

            MessageBox.Show("Wygrywa: " + nazwKoncowy);
            wynikKoncowy.Sort();

            listView1.View = View.Details;
            listView1.Columns.Add("Miejsce", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Nazwa", 200, HorizontalAlignment.Left);

            for (int i = 0; i < kryteriaList.Count-1; i++) {
                listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), Convert.ToString(wynikKoncowy[i]) }));
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
