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
    public partial class dodajWagi : Form
    {
        private List<kryteriaClass> kryteriaList;
        private Form1 x = null;
        public dodajWagi (Form1 f, List<kryteriaClass> kryteriaList)
        {
            InitializeComponent();
            x = f;
            this.kryteriaList = kryteriaList;
            Label[] label = new Label[kryteriaList.Count];
            ComboBox[] comboBox = new ComboBox[kryteriaList.Count];
            int licznik = 40;

            /*for (int i = 0; i < kryteriaList.Count; i++) {



                    TextBox textBoxAdd = new TextBox();
                textBoxAdd.Location = new Point(73, licznik);
                textBoxAdd.Name = "k"+i;

                Label labelBoxAdd = new Label();
                Label labelBoxAdd2 = new Label();

                //1
                labelBoxAdd.Text = kryteriaList[i].nazwaKryterium;
                labelBoxAdd.Width = 60;
                labelBoxAdd.Location = new Point(13, licznik);

                if (i + 1 < kryteriaList.Count)
                {

                    labelBoxAdd2.Text = kryteriaList[i + 1].nazwaKryterium;
                    labelBoxAdd2.Width = 60;
                    labelBoxAdd2.Location = new Point(173, licznik);
                    this.Controls.Add(labelBoxAdd);
                    this.Controls.Add(labelBoxAdd2);
                    this.Controls.Add(textBoxAdd);
                }

                licznik+=40;
                
            }*/


            int space2 = 10;
            for (int i = 0; i < kryteriaList.Count; i++)
            {
                int space1 = 10;
                for (int k = 0; k < kryteriaList.Count; k++)
                {
                    comboBox[k] = new ComboBox();
                    comboBox[k].Name = k + "c" + i;
                    label[k] = new Label();
                    label[k].Name = k + "n" + i;
                    label[k].Text = kryteriaList[k].nazwaKryterium;

                    for (int j = -9; j <= -2; j++)
                    {
                        comboBox[k].Items.Add(j);
                    }
                    for (int j = 1; j <= 9; j++)
                    {
                        comboBox[k].Items.Add(j);
                    }


                    if (k == i)
                    {
                        label[k].ForeColor = Color.Red;
                        comboBox[k].Text = "1";
                        comboBox[k].Enabled = false;
                    }
                    else if (k > i)
                    {
                        label[k].ForeColor = Color.Red;
                        comboBox[k].Enabled = false;
                    }
                    else
                    {
                        comboBox[k].SelectedText = "0";
                    }
                    
                    comboBox[k].Width = 80;
                    comboBox[k].Location = new Point(20 + space1, 50 + space2);
                    label[k].Location = new Point(20 + space1, 35 + space2);
                    this.Controls.Add(comboBox[k]);
                    this.Controls.Add(label[k]);

                    space1 += 120;
                }
                space2 += 40;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
