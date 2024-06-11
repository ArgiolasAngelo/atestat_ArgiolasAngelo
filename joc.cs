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
    public partial class joc : Form
    {
        
        struct carti
        {
            public string nume;
            public int punctaj;
            //public int nrj;

        };
        carti[] v = new carti[30]; // vectorul de carti
        int nr; // numar total de carti
        int[] v1 = new int[30]; //cartile deja impartite
        int nr1 = 0, k;
        int inceput = 0, interval;
        Random ran = new Random();
        int[] juc1 = new int[30]; //retine indicele cartilor jucatorului 1
        int[] juc2 = new int[30]; //retine indicele cartilor jucatorului 2
        PictureBox[] pj1 = new PictureBox[15]; //cartile afisate pt jucatorul 1
        PictureBox[] pj2 = new PictureBox[15]; //cartile afisate pt jucatorul 2
        int nj1 = 0, nj2 = 0;
        int jucactiv = 1;
        string tom, jerry;

        public joc(string nume1, string nume2)
        {
            InitializeComponent();
            
           
            label2.Text = nume1;
            label3.Text = nume2;
            tom = nume2;
            jerry = nume1;
            citiredate();
            impartecarti();
            afiscartejuc1();
            afiscartejuc2();
           

        }
        void afispunctaj1()
        {
            int i;
            string s;
            listBox1.Items.Clear();
            s = "0-" + Convert.ToString(v[juc1[0]].punctaj);
            listBox1.Items.Add(s);
            for (i = 1; i < nj1; i++)
            {
                s = Convert.ToString(v[juc1[i - 1]].punctaj) + "-" + Convert.ToString(v[juc1[i]].punctaj);
                listBox1.Items.Add(s);
            }
            s = Convert.ToString(v[juc1[nj1 - 1]].punctaj) + "-99";
            listBox1.Items.Add(s);
        }
        void afispunctaj2()
        {
            int i;
            string s;
            listBox1.Items.Clear();
            s = "0-" + Convert.ToString(v[juc2[0]].punctaj);
            listBox1.Items.Add(s);
            for (i = 1; i < nj2; i++)
            {
                s = Convert.ToString(v[juc2[i - 1]].punctaj) + "-" + Convert.ToString(v[juc2[i]].punctaj);
                listBox1.Items.Add(s);
            }
            s = Convert.ToString(v[juc2[nj2 - 1]].punctaj) + "-99";
            listBox1.Items.Add(s);
        }
        void ordonarepctj(ref int[] juc, int nj)
        {
            int i, j, aux;
            for (i = 0; i < nj; i++)
                for (j = i + 1; j < nj; j++)
                    if (v[juc[i]].punctaj > v[juc[j]].punctaj)
                    {
                        aux = juc[i];
                        juc[i] = juc[j];
                        juc[j] = aux;
                    }
        }
        void afiscartejuc2()
        {
            int i;
            ordonarepctj(ref juc2, nj2);
            for (i = 0; i < nj2; i++)
            {

                pj2[i] = new PictureBox();
                pj2[i].Width = 110;
                pj2[i].Height = 230;
                pj2[i].Top = 500;
                pj2[i].Left = i * 112 + 20;
                pj2[i].Image = Image.FromFile(v[juc2[i]].nume);
                pj2[i].SizeMode = PictureBoxSizeMode.Zoom;
                pj2[i].BackColor = Color.Transparent;
                this.Controls.Add(pj2[i]);
                pj2[i].Visible = true;

            }


        }
        void afiscartejuc1()
        {
            int i;
            ordonarepctj(ref juc1, nj1);
            for (i = 0; i < nj1; i++)
            {

                pj1[i] = new PictureBox();
                pj1[i].Width = 110;
                pj1[i].Height = 230;
                pj1[i].Top = 50;
                pj1[i].Left = i * 112 + 20;
                pj1[i].Image = Image.FromFile(v[juc1[i]].nume);
                pj1[i].SizeMode = PictureBoxSizeMode.Zoom;
                pj1[i].BackColor =Color.Transparent;
                this.Controls.Add(pj1[i]);
                pj1[i].Visible = true;

            }


        }
        void adaugcartejuc1()
        {
            castigatom f = new castigatom();
            int i;
            for(i=0; i<nj1;i++)
            {
                pj1[i].Visible = false;
                this.Controls.Remove(pj1[i]);
            }
            juc1[nj1] = k;
            i = nj1;
            nj1++;

            afiscartejuc1();
            if (nj1 == 10)
            {
                this.Close();
                f.label1.Text = "Felicitari " + tom + "!";
                f.ShowDialog();
            }
        }
        void adaugcartejuc2()
        {
            jerrycastiga f = new jerrycastiga();
            int i;
            for (i = 0; i < nj2; i++)
            {
                pj2[i].Visible = false;
                this.Controls.Remove(pj2[i]);
            }
            juc2[nj2] = k;
            i = nj2;
            nj2++;
           
            afiscartejuc2();
            if (nj2 == 10)
            {
                this.Close();
                f.label1.Text = "Felicitari " + jerry + "!";
                f.ShowDialog();
                
            }
        }
        void impartecarti()
        {
            int i, k;
            bool ok;
            nj1 = nj2 = nr1 = 0;
            while (nj1 < 3)
            {
                do
                {
                    k = ran.Next(0, nr);
                    ok = true;
                    for (i = 0; i < nr1; i++)
                        if (v1[i] == k)
                        {
                            ok = false;
                            break;
                        }


                } while (ok == false);
                v1[nr1] = k;
                juc1[nj1] = k;
                nj1++;
                nr1++;
            }
            while (nj2 < 3)
            {
                do
                {
                    k = ran.Next(0, nr);
                    ok = true;
                    for (i = 0; i < nr1; i++)
                        if (v1[i] == k)
                        {
                            ok = false;
                            break;
                        }


                } while (ok == false);
                v1[nr1] = k;
                juc2[nj2] = k;
                nj2++;
                nr1++;
            }




        }
        void citiredate()
        {
            string s;
            int i;
            nr = 0;
            StreamReader f = new StreamReader("date.txt");
            while ((s = f.ReadLine()) != null)
            {
                v[nr].nume = s;
                s = f.ReadLine();
                v[nr].punctaj = Convert.ToInt32(s);
                nr++;


            }
            f.Close();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int i;
            string s;
            string[] s1 = new string[5];
            bool ok;
            jucactiv = ran.Next(1, 3);
            pictureBox5.Visible = false;
            label1.Visible = false;
            listBox1.Visible = true;
            button1.Visible = true;
            if (jucactiv == 1)
            {
                afispunctaj1();
                pictureBox4.Image = Image.FromFile("Tom.png");

            }
            else
            {
                afispunctaj2();
                pictureBox4.Image = Image.FromFile("Jerry1.png");

            }
            do
            {
                k = ran.Next(0, nr);
                ok = true;
                for (i = 0; i < nr1; i++)
                    if (v1[i] == k)
                    {
                        ok = false;
                        break;
                    }


            } while (ok == false);
            v1[nr1] = k;
            nr1++;
            s = v[k].nume;
            s1 = s.Split('.');
            s = s1[0] + "f.png";
            pictureBox1.Image = Image.FromFile(s);
            interval = -1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        bool verific()
        {
            if (jucactiv == 1) 
            {
                if (interval == 0 && v[juc1[0]].punctaj >= v[k].punctaj)
                    return true;
                else

                    if (interval == nj1 && v[juc1[nj1 - 1]].punctaj <= v[k].punctaj)
                    return true;
                else if (v[juc1[interval]].punctaj >= v[k].punctaj && v[juc1[interval-1]].punctaj <= v[k].punctaj)
                    return true;
                else return false;


            }
            else
            {
                if (interval == 0 && v[juc2[0]].punctaj >= v[k].punctaj)
                    return true;
                else

                  if (interval == nj2 && v[juc2[nj2 - 1]].punctaj <= v[k].punctaj)
                    return true;
                else if (v[juc2[interval]].punctaj >= v[k].punctaj && v[juc2[interval - 1]].punctaj <= v[k].punctaj)
                    return true;
                else return false;
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            interval = listBox1.SelectedIndex;

        }
        void genereazacarte()
        {
            int i;
            string []s1=new string[5];
            string s;
            bool ok;
            if (nr1 < nr)
            {
                do
                {
                    k = ran.Next(0, nr);
                    ok = true;
                    for (i = 0; i < nr1; i++)
                        if (v1[i] == k)
                        {
                            ok = false;
                            break;
                        }


                } while (ok == false);
                v1[nr1] = k;
                nr1++;
                s = v[k].nume;
                s1 = s.Split('.');
                s = s1[0] + "f.png";
                pictureBox1.Image = Image.FromFile(s);
                label1.Text = Convert.ToString(v[k].punctaj);

            }
            else
            {
                MessageBox.Show("Toate cartile au fost utilizate");
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            bool ok, carteok;
            if (interval != -1)
            {
                carteok = verific();
                if (carteok == true)
                {
                    if (jucactiv == 1)
                    {
                        
                        adaugcartejuc1();
                        jucactiv = 2;
                        afispunctaj2();

                        pictureBox4.Image = Image.FromFile("Jerry1.png");
                    }
                    else
                    {
                        
                        adaugcartejuc2();
                        jucactiv = 1;
                         afispunctaj1();

                        pictureBox4.Image = Image.FromFile("Tom.png");
                    }
                    genereazacarte();
                    interval = -1;


                }
                else {
                    if (jucactiv == 1)
                    { jucactiv = 2;
                        pictureBox4.Image = Image.FromFile("Jerry1.png");
                        afispunctaj2();
                    }
                    else
                    { jucactiv = 1;
                        pictureBox4.Image = Image.FromFile("Tom.png");
                        afispunctaj1();
                    }
                    interval = -1;
                
                }
            }
            else MessageBox.Show("Selectati un interval!");
        }
    }
}
