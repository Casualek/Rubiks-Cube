using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Kostka test = new Kostka();



        private void button1_Click(object sender, EventArgs e)
        {
            test = new Kostka();
            rysuj();

        }
        private void rysuj()
        {
            Image bitmap = new Bitmap(width: 500, height: 500);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics = painting(test.scianaP_, 0, 111, graphics);
            graphics = painting(test.scianaZI_, 111, 111, graphics);
            graphics = painting(test.scianaC_, 222, 111, graphics);
            graphics = painting(test.scianaN_, 333, 111, graphics);
            graphics = painting(test.scianaB_, 111, 0, graphics);
            graphics = painting(test.scianaZ_, 111, 222, graphics);
            pictureBox1.Image = bitmap;
        }

        private void rysuj(Kostka test)
        {
            Image bitmap = new Bitmap(width: 500, height: 500);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics = painting(test.scianaP_, 0, 111, graphics);
            graphics = painting(test.scianaZI_, 111, 111, graphics);
            graphics = painting(test.scianaC_, 222, 111, graphics);
            graphics = painting(test.scianaN_, 333, 111, graphics);
            graphics = painting(test.scianaB_, 111, 0, graphics);
            graphics = painting(test.scianaZ_, 111, 222, graphics);
            pictureBox1.Image = null;
            pictureBox1.Image = bitmap;
        }

        private Graphics painting(Sciana tlo, int x, int y, Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, 99, 99);
            graphics.DrawRectangle(Pens.Black, rectangle);
            graphics = tlo.drawing(x, y, graphics);
            /*TextureBrush texture = new TextureBrush(new Bitmap(((Image)graphics)))
            {

            };*/
            return graphics;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test.r();
            rysuj();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            test.r_();
            rysuj();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            test.l();
            rysuj();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

            test.l_();
            rysuj();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            test.u_();
            rysuj();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            test.u();
            rysuj();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            test.d();
            rysuj();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            test.d_();
            rysuj();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            test.f();

            rysuj();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button13_Click(object sender, EventArgs e)
        {
            test.f_();
            rysuj();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            test.b();
            rysuj();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            test.b_();
            rysuj();
        }

        int mouseXE;
        int mouseYE;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXE = (int)e.X;
            mouseYE = (int)e.Y;
        }
        int mouseXEx;
        int mouseYEx;
        int absoluteX;
        int absoluteY;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseXEx = (int)e.X;
            mouseYEx = (int)e.Y;
            //MessageBox.Show("dziala");
            absoluteY = mouseYE - mouseYEx;
            if (absoluteY < 0)
            {
                absoluteY *= -1;
            }
            absoluteX = mouseXE - mouseXEx;
            if (absoluteX < 0)
            {
                absoluteX *= -1;
            }
            moving();
        }
        private void moving()
        {
            if (absoluteX > absoluteY) // ruchy wed³ug X
            {
                if (mouseXEx > mouseXE) // koñcowy X wiêkszy
                {
                    if (mouseXE > 0 && mouseXE < 444 && mouseYE > 111 && mouseYE < 211)
                    {
                        if (mouseYE > 111 && mouseYE < 144) // ruch góra/œrodek
                        {
                            test.u_();
                            rysuj();
                        }
                        else if (mouseYE > 177 && mouseYE < 211) // ruch dó³/œrodek
                        {
                            test.d();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 0 && mouseYE < 111) // bia³a œciana
                    {
                        if (mouseYE > 0 && mouseYE < 33)
                        {
                            test.b_();
                            rysuj();
                        }
                        else if (mouseYE > 66 && mouseYE < 111)
                        {
                            test.f();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 222 && mouseYE < 333) // ¿ó³ta œciana
                    {
                        if (mouseYE > 222 && mouseYE < 255)
                        {
                            test.f_();
                            rysuj();
                        }
                        else if (mouseYE > 288 && mouseYE < 333)
                        {
                            test.b();
                            rysuj();
                        }
                    }
                }
                else if (mouseXEx < mouseXE) // pocz¹tkowy X wiêkszy
                {
                    if (mouseXE > 0 && mouseXE < 444 && mouseYE > 111 && mouseYE < 211)
                    {
                        if (mouseYE > 111 && mouseYE < 144) // ruch góra/œrodek
                        {
                            test.u();
                            rysuj();
                        }
                        else if (mouseYE > 177 && mouseYE < 211) // ruch dó³/œrodek
                        {
                            test.d_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 0 && mouseYE < 111) // bia³a œciana
                    {
                        if (mouseYE > 0 && mouseYE < 33)
                        {
                            test.b();
                            rysuj();
                        }
                        else if (mouseYE > 66 && mouseYE < 111)
                        {
                            test.f_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 222 && mouseYE < 333) // ¿ó³ta œciana
                    {
                        if (mouseYE > 222 && mouseYE < 255)
                        {
                            test.f();
                            rysuj();
                        }
                        else if (mouseYE > 288 && mouseYE < 333)
                        {
                            test.b_();
                            rysuj();
                        }
                    }
                }
            }
            else if (absoluteX < absoluteY) // ruchy wed³ug Y
            {
                if (mouseYEx > mouseYE) // koñcowy Y wiêkszy
                {
                    if ((mouseXE > 0 && mouseXE < 111 && mouseYE > 111 && mouseYE < 211) ||
                        (mouseXE > 222 && mouseXE < 333 && mouseYE > 111 && mouseYE < 211)) // pomarañcz/czerwieñ
                    {
                        if (mouseXE > 0 && mouseXE < 33)
                        {
                            test.b();
                            rysuj();
                        }
                        else if (mouseXE > 66 && mouseXE < 111)
                        {
                            test.f_();
                            rysuj();
                        }
                        else if (mouseXE > 288 && mouseXE < 333)
                        {
                            test.b_();
                            rysuj();
                        }
                        else if (mouseXE > 222 && mouseXE < 255)
                        {
                            test.f();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 0 && mouseYE < 111) // bia³a œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 222 && mouseYE < 333) // ¿ó³ta œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 111 && mouseYE < 222) // zielona œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 333 && mouseXE < 444 && mouseYE > 111 && mouseYE < 222) // niebieska œciana
                    {
                        if (mouseXE > 333 && mouseXE < 366)
                        {
                            test.r_();
                            rysuj();
                        }
                        else if (mouseXE > 399 && mouseXE < 444)
                        {
                            test.l();
                            rysuj();
                        }
                    }
                }
                else if (mouseYEx < mouseYE) // pocz¹tkowy Y wiêkszy
                {
                    if ((mouseXE > 0 && mouseXE < 111 && mouseYE > 111 && mouseYE < 211) ||
                        (mouseXE > 222 && mouseXE < 333 && mouseYE > 111 && mouseYE < 211)) // pomarañcz/czerwieñ
                    {
                        if (mouseXE > 0 && mouseXE < 33)
                        {
                            test.b_();
                            rysuj();
                        }
                        else if ((mouseXE > 66 && mouseXE < 111))
                        {
                            test.f();
                            rysuj();
                        }
                        else if (mouseXE > 288 && mouseXE < 333)
                        {
                            test.b();
                            rysuj();
                        }
                        else if (mouseXE > 222 && mouseXE < 255)
                        {
                            test.f_();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 0 && mouseYE < 111) // bia³a œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l_();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 222 && mouseYE < 333) // ¿ó³ta œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l_();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 111 && mouseXE < 222 && mouseYE > 111 && mouseYE < 222) // zielona œciana
                    {
                        if (mouseXE > 111 && mouseXE < 144)
                        {
                            test.l_();
                            rysuj();
                        }
                        else if (mouseXE > 177 && mouseXE < 222)
                        {
                            test.r();
                            rysuj();
                        }
                    }
                    else if (mouseXE > 333 && mouseXE < 444 && mouseYE > 111 && mouseYE < 222) // niebieska œciana
                    {
                        if (mouseXE > 333 && mouseXE < 366)
                        {
                            test.r();
                            rysuj();
                        }
                        else if (mouseXE > 399 && mouseXE < 444)
                        {
                            test.l_();
                            rysuj();
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (x > 222 && x < 333 && y > 111 && y < 222) // czerwona œciana
            {
                test.r();
                rysuj();
            }
            else if (x > 0 && x < 111 && y > 111 && y < 222) // pomarañczowa œciana
            {
                test.l();
                rysuj();
            }
            else if (x > 111 && x < 222 && y > 0 && y < 111) // bia³a œciana
            {
                test.u();
                rysuj();
            }
            else if (x > 111 && x < 222 && y > 111 && y < 222) // zielona œciana
            {
                test.f();
                rysuj();
            }
            else if (x > 111 && x < 222 && y > 222 && y < 333) // ¿ó³ta œciana
            {
                test.d();
                rysuj();
            }
            else if (x > 333 && x < 444 && y > 111 && y < 222) // niebieska œciana
            {
                test.b();
                rysuj();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int num = rand.Next(6);
                //textBox1.Text += "," + num.ToString();
                switch (num)
                {
                    case 0:
                        test.r();
                        rysuj();
                        break;
                    case 1:
                        test.l();
                        rysuj();
                        break;
                    case 2:
                        test.u();
                        rysuj();
                        break;
                    case 3:
                        test.d();
                        rysuj();
                        break;
                    case 4:
                        test.f();
                        rysuj();
                        break;
                    case 5:
                        test.b();
                        rysuj();
                        break;
                }
            }
        }

        private void BG()
        {
            /*kostka ulozona = new kostka();
            //string poprzedni = "";
            //List<string> lista = new List<string>();
            //List<kostka> kostkaL = new List<kostka>();
            //List<kostka> nowaL = new List<kostka>();
            //List<kostka> nowa = new List<kostka>();
            //int[] tabIndx = [];
            //kostkaL.Add(test);
            //bool check = false;
            //test.moves1(check, ulozona, poprzedni, lista, ref kostkaL, nowaL, nowa);
            //test.scianaB.pola_ = kostka.scianaBT.pola_;
            //test.scianaP.pola_ = kostka.scianaPT.pola_;
            //test.scianaN.pola_ = kostka.scianaNT.pola_;
            //test.scianaC.pola_ = kostka.scianaCT.pola_;
            //test.scianaZ.pola_ = kostka.scianaZT.pola_;
            //test.scianaZI.pola_ = kostka.scianaZIT.pola_;
            //test = ulozona;*/
            //List<kostka> warianty = new List<kostka>();
            //kostka w1 = new kostka();
            List<Kostka> A = new List<Kostka>();
            List<Kostka> usunac = new List<Kostka>();
            List<Kostka> ulozona = new List<Kostka>();
            A.Add(test);
            int ogr = 2;
            List<Kostka> backup = new List<Kostka>();
            //int maxR = 1000000;
            //bool control = true;
            double i = test.pozUlo();
            int m = 1000000000;
            int m2 = 0;
            bool usun_max = false;
            int poziom_zatrzymania = 0;
            do
            {
                
                ulozona.Clear();
                poziom_zatrzymania = 100;
                foreach (Kostka T in A)
                {
                    
                    foreach (Kostka U in Ukladaj(false, ogr, 0, new Kostka(T), i, poziom_zatrzymania).ToArray())
                        ulozona.Add(new Kostka(U));
                }

                if (ulozona.Count ==0)
                {
                    ogr++;
                    /*if ((m < m2)&&(ogr>4))
                        usun_max = true;*/
                }
                else
                {
                   
                    foreach (Kostka T in ulozona)
                    {
                        if (ulozona.Count >= 1)
                        {
                            if (T.pozUlo() > i)
                            {
                                //if (T.listR_.Count() < maxR)
                                //{
                                //    maxR = T.listR_.Count();
                                //}

                                i = T.pozUlo();
                            }
                            m = 1000000000;
                            m2 = 0;
                            ogr = 1;
                        }
                        if (T.listR_.Count < m)
                            m = T.listR_.Count;
                        if (T.listR_.Count > m2)
                            m2 = T.listR_.Count;
                    }

                }
               
                
                usunac.Clear();
                foreach (Kostka K in A)
                {
                    if (!usun_max)
                    {
                        if (K.pozUlo() < i)
                        {
                            usunac.Add(K);
                        }
                    }
                    else
                    {
                        if (K.listR_.Count > m)
                        {
                            usunac.Add(K);
                        }                        
                    }

                }
                usun_max = false;
                foreach (Kostka K in usunac)
                {
                    if (A.Count > 1)
                        A.Remove(K);
                }
                foreach (Kostka T in ulozona)//mniejsze i ale mniejsze ilosc ruchów
                {
                    if (A.FindIndex(x => x.ToString() == T.ToString()) == -1 && T.pozUlo() >= i)
                        A.Add(T);
                }
                string a = "Liczba kostek: " + A.Count.ToString() + " iteracja: " + i.ToString() + " ograniczenie: " + ogr.ToString()+" ["+poziom_zatrzymania.ToString()+"]" + " min : "+m.ToString()  +" max: "+m2.ToString();
                //if (A.Count == 0)
                //{
                //    A.AddRange(backup);
                //    i--;
                //}
                //backup.Clear();
                //backup.AddRange(A);
                //int idxa = 0;
                //foreach (Kostka K in A)
                //{
                //    idxa++;
                //    pictureBox1.Invoke(DelegateMethod, [new Kostka(K)]);
                //    this.Invoke(DelegateMethod2, [idxa * 1000]);
                //    Thread.Sleep(500);
                //}
                this.Invoke(DelegateMethod2, [a]);
                if(A.Count>=1)
                pictureBox1.Invoke(DelegateMethod, [new Kostka(A.First())]);
            } while (i < new Kostka().pozUlo());
            int idx = 0;
            foreach (Kostka K in A)
            {
                idx++;
                pictureBox1.Invoke(DelegateMethod, [new Kostka(K)]);
                this.Invoke(DelegateMethod2, ["U³o¿ona kostka"]);
                Thread.Sleep(3000);
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //test.scianaZI.pola_[0][1] = "z";
            //test.scianaZI.pola_[1][0] = "z";
            //test.scianaZI.pola_[1][2] = "z";
            //test.scianaZI.pola_[2][1] = "z";
            //test.scianaB.pola_[2][1] = "zi";
            //test.scianaP.pola_[1][2] = "zi";
            //test.scianaC.pola_[1][0] = "zi";
            //test.scianaZ.pola_[0][1] = "zi";
            // rysuj();
        }
        /*private bool Porownaj(Kostka A, int ilosc_sprawdzanych)
        {
            int yeNo = 0;
            if (A.scianaZI_.pola_[0][1] == "zi" && A.scianaB_.pola_[2][1] == "b")
            {
                yeNo++;
            }
            if (A.scianaZI_.pola_[1][0] == "zi" && A.scianaP_.pola_[1][2] == "p")
            {
                yeNo++;
            }
            if (A.scianaZI_.pola_[1][2] == "zi" && A.scianaC_.pola_[1][0] == "c")
            {
                yeNo++;
            }
            if (A.scianaZI_.pola_[2][1] == "zi" && A.scianaZ_.pola_[0][1] == "z")
            {
                yeNo++;
            }
            if(yeNo == 4)
            {
                if (A.scianaZI_.pola_[0][0] == "zi")
                {

                }
            }
            if (yeNo >= ilosc_sprawdzanych)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        private Kostka Klonuj_Kostka(Kostka source)
        {
            Kostka N = new Kostka(source);
            return N;
        }


        private List<Kostka> Ukladaj(bool Lcheck, int max_liczba_ruchow, int ilosc_porzednich_ruchow, Kostka ukladana, double ilosc_ukladanych,  int poziom_zatrzymania)
        {
            bool check = false;
            //Kostka temp = new Kostka();
            List<Kostka> result = new List<Kostka>();
            List<Task<List<Kostka>>> task_list = new List<Task<List<Kostka>>>();
            if ((ilosc_porzednich_ruchow++ <= max_liczba_ruchow)&&(poziom_zatrzymania>=ilosc_porzednich_ruchow)&&((0.037<=ukladana.pozUlo())||(ilosc_ukladanych==ukladana.pozUlo())))
            {
                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.rT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.rT());
                    check = true;
                }
                if (ukladana.rT2().pozUlo() >= ilosc_ukladanych + 1)
                {                       
                    result.Add(ukladana.rT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.r_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.r_T());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.lT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.lT());
                    check = true;
                }
                if (ukladana.lT2().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.lT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.l_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.l_T());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.uT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.uT());
                    check = true;
                }
                if (ukladana.uT2().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.uT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.u_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.u_T());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.dT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.dT());
                    check = true;
                }
                if (ukladana.dT2().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.dT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.d_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.d_T());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.fT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.fT());
                    check = true;
                }
                if (ukladana.fT2().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.fT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.f_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.f_T());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.bT().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.bT());
                    check = true;
                }
                if (ukladana.bT2().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.bT2());
                    check = true;
                }

                //temp = Klonuj_Kostka(ukladana);
                if (ukladana.b_T().pozUlo() >= ilosc_ukladanych + 1)
                {
                    result.Add(ukladana.b_T());
                    check = true;
                }
                // jesi nie 
                string OstatniRuch = "";
                string OstatniaSekwencja = "";                
                if(ukladana.listR_.Count>=3)
                    OstatniaSekwencja += ukladana.listR_[ukladana.listR_.Count - 3];
                if (ukladana.listR_.Count >= 2)
                    OstatniaSekwencja += ukladana.listR_[ukladana.listR_.Count - 2];
                if (ukladana.listR_.Count >= 1)
                {
                    OstatniaSekwencja += ukladana.listR_[ukladana.listR_.Count - 1];
                    OstatniRuch = ukladana.listR_.Last();
                }

                if ((check == false) && (ilosc_porzednich_ruchow < max_liczba_ruchow))
                {

                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "r_" && OstatniRuch != "r2" && OstatniaSekwencja != "rrr")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.rT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "l_" && OstatniRuch != "l2" && OstatniaSekwencja != "lll")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.lT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "u_" && OstatniRuch != "u2" && OstatniaSekwencja != "uuu")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.uT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "d_" && OstatniRuch != "d2" && OstatniaSekwencja != "ddd")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.dT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "f_" && OstatniRuch != "f2" && OstatniaSekwencja != "fff")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.fT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "b_" && OstatniRuch != "b2" && OstatniaSekwencja != "bbb")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.bT(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "r" && OstatniRuch != "r2" && OstatniaSekwencja != "r_r_r_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.r_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "l" && OstatniRuch != "l2" && OstatniaSekwencja != "l_l_l_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.l_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "u" && OstatniRuch != "u2" && OstatniaSekwencja != "u_u_u_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.u_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "d" && OstatniRuch != "d2" && OstatniaSekwencja != "d_d_d_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.d_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if (OstatniRuch != "f" && OstatniRuch != "f2" && OstatniaSekwencja != "f_f_f_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.f_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());

                        if (OstatniRuch != "b" && OstatniRuch != "b2" && OstatniaSekwencja != "b_b_b_")
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.b_T(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if ((OstatniRuch != "r") && (OstatniRuch != "r_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.rT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }
                        if ((OstatniRuch != "l") && (OstatniRuch != "l_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.lT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if ((OstatniRuch != "u") && (OstatniRuch != "u_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.uT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }

                        if ((OstatniRuch != "d") && (OstatniRuch != "d_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.dT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }
                        return result1;
                    })));
                    task_list.Add(Task.Run(
                    async () => await Task<List<Kostka>>.Run(() =>
                    {
                        List<Kostka> result1 = new List<Kostka>();
                        if ((OstatniRuch != "f") && (OstatniRuch != "f_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.fT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }
                        if ((OstatniRuch != "b") && (OstatniRuch != "b_"))
                        {
                            result1.AddRange(Ukladaj(false, max_liczba_ruchow, ilosc_porzednich_ruchow, ukladana.bT2(), ilosc_ukladanych, poziom_zatrzymania).ToArray());
                        }
                        return result1;
                    })));

                    Task.WhenAll(task_list);

                    foreach (var task in task_list)
                        foreach (var item in task.Result)
                            result.Add(item);

                }
               /* if (check)
                {
                    if (poziom_zatrzymania > ilosc_porzednich_ruchow)
                        poziom_zatrzymania = ilosc_porzednich_ruchow;
                }*/
            }
            return result;
        }
        private delegate void Delegate(Kostka k);
        private void DelegateMethod(Kostka k)
        {
            rysuj(k);
        }

        private void DelegateMethod2(string k)
        {
            this.Text = k;
        }
        private void r_Click(object sender, EventArgs e)
        {
            test.r();
            rysuj();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            test.r_();
            rysuj();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            test.l();
            rysuj();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            test.l_();
            rysuj();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            test.u();
            rysuj();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            test.u_();
            rysuj();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            test.d();
            rysuj();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            test.d_();
            rysuj();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            test.f();
            rysuj();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            test.f_();
            rysuj();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            test.b();
            rysuj();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            test.b_();
            rysuj();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BG();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Kostka a  = new Kostka();
            Kostka b = new Kostka(a);

            a.r(); 
            b.b();

        }
    }
}
