using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{

    public class Sciana
    {
        private string[][] pola = [[], [], []];
        string numer;
        public Sciana(string polaK, string num)
        {
            numer = num;
            pola = [[polaK, polaK, polaK], [polaK, polaK, polaK], [polaK, polaK, polaK]];
        }

        public Sciana(Sciana S)
        {            
            numer = S.numer;
            pola = new string[3][];
            pola[0] = new string[3] { S.pola_[0][0], S.pola_[0][1], S.pola_[0][2] };
            pola[1] = new string[3] { S.pola_[1][0], S.pola_[1][1], S.pola_[1][2] };
            pola[2] = new string[3] { S.pola_[2][0], S.pola_[2][1], S.pola_[2][2] };
        }

        public Graphics drawing(int x, int y, Graphics graphics)
        {
            int cellWidth = 33;
            int cellHeight = 33;
            //SolidBrush blueBrush = new SolidBrush(Color.Blue);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    string color = pola_[row][col];
                    SolidBrush blueBrush = new SolidBrush(Color.Black);
                    switch (color)
                    {
                        case "b":
                            {
                                blueBrush = new SolidBrush(Color.White);
                            }
                            break;
                        case "n":
                            {
                                blueBrush = new SolidBrush(Color.Blue);
                            }
                            break;
                        case "c":
                            {
                                blueBrush = new SolidBrush(Color.Red);
                            }
                            break;
                        case "zi":
                            {
                                blueBrush = new SolidBrush(Color.Green);
                            }
                            break;
                        case "z":
                            {
                                blueBrush = new SolidBrush(Color.Yellow);
                            }
                            break;
                        case "p":
                            {
                                blueBrush = new SolidBrush(Color.Orange);
                            }
                            break;
                    }
                    Pen pen = new Pen(Color.Black, 2);
                    pen.Alignment = PenAlignment.Inset;
                    graphics.DrawRectangle(pen, x + (col * cellWidth), y + (row * cellHeight), cellWidth, cellHeight);
                    Rectangle rect = new Rectangle(x + (col * cellWidth), y + (row * cellHeight), cellWidth - 2, cellHeight - 2);
                    graphics.FillRectangle(blueBrush, rect);
                    System.Drawing.Font F = new System.Drawing.Font("Arial", 6);
                    graphics.DrawString((x + (col * cellWidth), y + (row * cellHeight)).ToString(), F, Brushes.Black, new Point(x + (col * cellWidth), y + (row * cellHeight)));
                }

            }
            return graphics;
        }
        public string[] getCol(int index)
        {
            string[] col = [pola_[0][index], pola_[1][index], pola_[2][index]];
            return col;
        }
        public string[] getColRewerse(int index)
        {
            string[] col = [pola_[2][index], pola_[1][index], pola_[0][index]];
            return col;
        }
        public void setCol(int index, string[] col)
        {
            pola[0][index] = col[0];
            pola[1][index] = col[1];
            pola[2][index] = col[2];
        }
        public void setRow(int index, string[] row)
        {
            pola[index] = row;
        }
        public string[] getRow(int index)
        {
            string[] row = [pola_[index][0], pola_[index][1], pola_[index][2]];
            return row;
        }

        public string getRowString(int index)
        {
            string row = pola_[index][0] + pola_[index][1] + pola_[index][2];
            return row;
        }

        public string getColString(int index)
        {
            string col = pola_[0][index]+ pola_[1][index]+ pola_[2][index];
            return col;
        }

        public string[] getRowRewerse(int index)
        {
            string[] row = [pola_[index][2], pola_[index][1], pola_[index][0]];
            return row;
        }
        

        public void rotate()
        {
            var tempP1 = pola_[0][0];
            var tempP2 = pola_[0][1];
            var tempP3 = pola_[0][2];
            var tempP4 = pola_[1][0];
            var tempP6 = pola_[1][2];
            var tempP7 = pola_[2][0];
            var tempP8 = pola_[2][1];
            var tempP9 = pola_[2][2];
            pola_[0][0] = tempP7;
            pola_[0][1] = tempP4;
            pola_[0][2] = tempP1;
            pola_[1][0] = tempP8;
            pola_[1][2] = tempP2;
            pola_[2][0] = tempP9;
            pola_[2][1] = tempP6;
            pola_[2][2] = tempP3;
        }

        public override string ToString()
        {
            return pola_[0][0] + pola_[0][1] + pola_[0][2] + " " + pola_[1][0] + pola_[1][1] + pola_[1][2] + " " + pola_[2][0] + pola_[2][1] + pola_[2][2];
        }
        public string[][] pola_
        {
            get => (string[][])pola.Clone();
            set { pola = value; }
        }      
    }

    public class Kostka
    {
        string UID = "";
        List<string> ruchy = new List<string>();
        private Sciana scianaB;
        private Sciana scianaZ;
        private Sciana scianaN;
        private Sciana scianaZI;
        private Sciana scianaC;
        private Sciana scianaP;
        public Sciana scianaBT = new Sciana("b", "1");
        public Sciana scianaZT = new Sciana("z", "2");
        public Sciana scianaNT = new Sciana("n", "3");
        public Sciana scianaZIT = new Sciana("zi", "4");
        public Sciana scianaPT = new Sciana("p", "6");
        public Sciana scianaCT = new Sciana("c", "5");

        public override string ToString()
        {
            return scianaB_.ToString() + " "+scianaZ_.ToString() + " " + scianaN_.ToString() + " " + scianaZI_.ToString() + " " + scianaC_.ToString() + " " + scianaP_.ToString();
        }

        public Sciana scianaP_
        {
            get => scianaP;
            set { scianaP = value; }
        }
        public Sciana scianaN_
        {
            get => scianaN;
            set { scianaN = value; }
        }
        public Sciana scianaZ_
        {
            get => scianaZ;
            set { scianaZ = value; }
        }
        public Sciana scianaB_
        {
            get => scianaB;
            set { scianaB = value; }
        }
        public Sciana scianaZI_
        {
            get => scianaZI;
            set { scianaZI = value; }
        }
        public Sciana scianaC_
        {
            get => scianaC;
            set { scianaC = value; }
        }
    /*    public bool trueFalseCrossZI1(List<kostka> kList,ref List <kostka> nowa, string ruch)
        {
            bool check = false;
            int yeNo = 1;
            if ((this.scianaZI.pola_[0][1] == "zi") ||
                (this.scianaZI.pola_[2][1] == "zi") ||
                (this.scianaZI.pola_[1][0] == "zi") ||
                (this.scianaZI.pola_[1][2] == "zi")
                )
            {
                yeNo *= 1;
            }
            else
            {
                yeNo *= 0;
            }
            if (yeNo >= 1)
            {
                this.ruchy.Add(ruch);
                check = true;
                nowa.Add(this);
                //nowa = this;
                return check;
            }
            else
            {
                check = false;
                //kList.RemoveAt(index);
                return check;
            }
        }
        public bool trueFalseCrossZI2(List<kostka> kList, ref List<kostka> nowa, string ruch)
        {
            bool check = false;
            int yeNo = 0;
            if (this.scianaZI.pola_[1][2] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[2][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[0][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[1][0] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (yeNo >= 2)
            {
                this.ruchy.Add(ruch);
                check = true;
                nowa.Add(this);
                return check;
            }
            else
            {
                check = false;
                //kList.RemoveAt(index);
                return check;
            }
        }
        public bool trueFalseCrossZI3(List<kostka> kList, ref List<kostka> nowa, string ruch)
        {
            bool check = false;
            int yeNo = 0;
            if (this.scianaZI.pola_[1][2] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[2][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[0][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[1][0] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (yeNo >= 3)
            {
                this.ruchy.Add(ruch);
                check = true;
                nowa.Add(this);
                return check;
            }
            else
            {
                check = false;
                //kList.RemoveAt(index);
                return check;
            }
        }
        public bool trueFalseCrossZI4(List<kostka> kList, ref List<kostka> nowa, string ruch)
        {
            bool check = false;
            int yeNo = 0;
            if (this.scianaZI.pola_[1][2] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[2][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[0][1] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (this.scianaZI.pola_[1][0] == "zi")
            {
                yeNo += 1;
            }
            else
            {
                yeNo += 0;
            }
            if (yeNo >= 4)
            {
                scianaBT.pola_ = this.scianaB.pola_;
                scianaCT.pola_ = this.scianaC.pola_;
                scianaNT.pola_ = this.scianaZ.pola_;
                scianaZIT.pola_ = this.scianaZI.pola_;
                scianaPT.pola_ = this.scianaP.pola_;
                scianaNT.pola_ = this.scianaN.pola_;
                this.ruchy.Add(ruch);
                check = true;
                return check;
            }
            else
            {
                check = false;
                //kList.RemoveAt(index);
                return check;
            }
        }
        public bool trueFalse()
        {
            bool check = false;
            int c = 0;
            int pomaranczowy = 0;
            int bialy = 0;
            int zolty = 0;
            int n = 0;
            int zi = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.scianaC.pola_[i][j] == "c")
                    {
                        c++;
                    }
                    if (this.scianaP.pola_[i][j] == "p")
                    {
                        pomaranczowy++;
                    }
                    if (this.scianaB.pola_[i][j] == "b")
                    {
                        bialy++;
                    }
                    if (this.scianaZ.pola_[i][j] == "z")
                    {
                        zolty++;
                    }
                    if (this.scianaN.pola_[i][j] == "n")
                    {
                        n++;
                    }
                    if (this.scianaZI.pola_[i][j] == "zi")
                    {
                        zi++;
                    }
                }
            }

            if (c == 9 && pomaranczowy == 9 && bialy == 9 && zolty == 9 && n == 9 && zi == 9)
            {
                check = true;
                return check;
            }
            else
            {
                return check;
            }
        }
    */
        public Sciana Klonuj_Sciana(Sciana source)
        {
            Sciana N = new Sciana(source);

            return N;
        }
        private List<string> listR = null;

        public List<string> listR_
        {
            get => listR;
            set { listR = value; }
        }

        public double pozUlo()
        {
            


            int yeNoZ = 0;
            int yeNoN = 0;
            int yeNoKZ = 0;
            int yeNoKN = 0;
            int yeNoP = 0;

            if ((this.scianaZI_.pola_[0][0] == "zi") && (this.scianaB_.pola_[2][0] == "b") && (this.scianaP_.pola_[0][2] == "p")) yeNoZ++;
            
            if ((this.scianaZI_.pola_[0][2] == "zi") && (this.scianaB_.pola_[2][2] == "b") && (this.scianaC_.pola_[0][0] == "c")) yeNoZ++;

            if ((this.scianaZI_.pola_[2][0] == "zi") && (this.scianaP_.pola_[2][2] == "p") && (this.scianaZ_.pola_[0][0] == "z")) yeNoZ++;

            if ((this.scianaZI_.pola_[2][2] == "zi") && (this.scianaC_.pola_[2][0] == "c") && (this.scianaZ_.pola_[0][2] == "z")) yeNoZ++;

            if ((this.scianaN_.pola_[2][2] == "n") && (this.scianaP_.pola_[2][0] == "p") && (this.scianaZ_.pola_[2][0] == "z")) yeNoN++;

            if ((this.scianaN_.pola_[0][2] == "n") && (this.scianaP_.pola_[0][0] == "p") && (this.scianaB_.pola_[0][0] == "b")) yeNoN++;

            if ((this.scianaN_.pola_[0][0] == "n") && (this.scianaB_.pola_[0][2] == "b") && (this.scianaC_.pola_[0][2] == "c")) yeNoN++;

            if ((this.scianaN_.pola_[2][0] == "n") && (this.scianaC_.pola_[2][2] == "c") && (this.scianaZ_.pola_[2][2] == "z")) yeNoN++;
            

            if ((this.scianaZI_.getRowString(0) == "zizizi") && (this.scianaB_.getRowString(2) == "bbb")) yeNoKZ++;

            if ((this.scianaZI_.getRowString(2) == "zizizi") && (this.scianaZ_.getRowString(0) == "zzz")) yeNoKZ++;

            if ((this.scianaZI_.getColString(0) == "zizizi") && (this.scianaP_.getColString(2) == "ppp")) yeNoKZ++;

            if ((this.scianaZI_.getColString(2) == "zizizi") && (this.scianaC_.getRowString(0) == "ccc")) yeNoKZ++;


            if ((this.scianaP_.getRowString(0) == "ppp") && (this.scianaB_.getColString(0) == "bbb")) yeNoP++;

            if ((this.scianaP_.getRowString(2) == "ppp") && (this.scianaZ_.getColString(0) == "zzz")) yeNoP++;


            if ((this.scianaN_.getRowString(0) == "nnn") && (this.scianaB_.getRowString(0) == "bbb")) yeNoKN++;

            if ((this.scianaN_.getRowString(2) == "nnn") && (this.scianaZ_.getRowString(2) == "zzz")) yeNoKN++;

            if ((this.scianaN_.getColString(0) == "nnn") && (this.scianaC_.getColString(2) == "ccc")) yeNoKN++;

            if ((this.scianaN_.getColString(2) == "nnn") && (this.scianaP_.getRowString(0) == "ppp")) yeNoKN++;


            if ((this.scianaC_.getRowString(0) == "ccc") && (this.scianaB_.getColString(2) == "bbb")) yeNoP++;

            if ((this.scianaC_.getRowString(2) == "ccc") && (this.scianaZ_.getColString(2) == "zzz")) yeNoP++;



            return (yeNoZ * yeNoKZ) *1.1+ yeNoN * yeNoKN + (yeNoP * yeNoP);

        }
        /* public Kostka Klonuj_Kostka(Kostka source)
         {
             Kostka N = new Kostka();

              N.scianaC= source.Klonuj_Sciana(scianaC);
              N.scianaN= source.Klonuj_Sciana(scianaN);
              N.scianaP= source.Klonuj_Sciana(scianaP);
              N.scianaB= source.Klonuj_Sciana(scianaB);
              N.scianaZ= source.Klonuj_Sciana(scianaZ);
              N.scianaZI= source.Klonuj_Sciana(scianaZI);

             return N;
         }*/

        /*public void moves1(bool check, Kostka ulozona, string poprzedni, List<string> powtorka, ref List<kostka> kostkas, List<kostka> nowaLista, List<kostka> nowa)
        {
            foreach (Kostka k1 in kostkas)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (k1.r_T().trueFalseCrossZI1(kostkas, nowaLista) || //pierwszy element
                        k1.rT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.lT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.l_T().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.uT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.u_T().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.dT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.d_T().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.fT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.f_T().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.bT().trueFalseCrossZI1(kostkas, nowaLista) ||
                        k1.b_T().trueFalseCrossZI1(kostkas, nowaLista))
                    {
                        MessageBox.Show("dai");
                        goto krzyzElementDwa;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            poprzedni = "r";
                            powtorka = k1.copyList(powtorka, "r");
                            k1.r();
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            poprzedni = "r'";
                            powtorka = k1.copyList(powtorka, "r'");
                            k1.r_();
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            poprzedni = "l";
                            powtorka = k1.copyList(powtorka, "l");
                            k1.l();
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            poprzedni = "l'";
                            powtorka = k1.copyList(powtorka, "l'");
                            k1.l_();
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            poprzedni = "u";
                            powtorka = k1.copyList(powtorka, "u");
                            k1.u();
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            poprzedni = "u'";
                            powtorka = k1.copyList(powtorka, "u'");
                            k1.u_();
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            poprzedni = "d";
                            powtorka = k1.copyList(powtorka, "d");
                            k1.d();
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            poprzedni = "d'";
                            powtorka = k1.copyList(powtorka, "d'");
                            k1.d_();

                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            poprzedni = "f";
                            powtorka = k1.copyList(powtorka, "f");
                            k1.f_();
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            poprzedni = "f'";
                            powtorka = k1.copyList(powtorka, "f'");
                            k1.f_();
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            poprzedni = "b";
                            powtorka = k1.copyList(powtorka, "b");
                            k1.b();

                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            poprzedni = "b'";
                            powtorka = k1.copyList(powtorka, "b'");
                            k1.b_();
                        }
                    }
                }
            }
            krzyzElementDwa:
            kostkas.Clear();
            foreach (Kostka k in nowaLista)
            {
                kostkas.Add(k);
            }
            nowaLista.Clear();
            foreach (Kostka k1 in kostkas)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (k1.r_T().trueFalseCrossZI2(kostkas, nowaLista) || //pierwszy element
                        k1.rT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.lT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.l_T().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.uT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.u_T().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.dT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.d_T().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.fT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.f_T().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.bT().trueFalseCrossZI2(kostkas, nowaLista) ||
                        k1.b_T().trueFalseCrossZI2(kostkas, nowaLista))
                    {
                        MessageBox.Show("dai2");
                        goto krzyzElementTrzy;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            poprzedni = "r";
                            powtorka = k1.copyList(powtorka, "r");
                            k1.r();
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            poprzedni = "r'";
                            powtorka = k1.copyList(powtorka, "r'");
                            k1.r_();
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            poprzedni = "l";
                            powtorka = k1.copyList(powtorka, "l");
                            k1.l();
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            poprzedni = "l'";
                            powtorka = k1.copyList(powtorka, "l'");
                            k1.l_();
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            poprzedni = "u";
                            powtorka = k1.copyList(powtorka, "u");
                            k1.u();
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            poprzedni = "u'";
                            powtorka = k1.copyList(powtorka, "u'");
                            k1.u_();
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            poprzedni = "d";
                            powtorka = k1.copyList(powtorka, "d");
                            k1.d();
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            poprzedni = "d'";
                            powtorka = k1.copyList(powtorka, "d'");
                            k1.d_();

                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            poprzedni = "f";
                            powtorka = k1.copyList(powtorka, "f");
                            k1.f_();
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            poprzedni = "f'";
                            powtorka = k1.copyList(powtorka, "f'");
                            k1.f_();
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            poprzedni = "b";
                            powtorka = k1.copyList(powtorka, "b");
                            k1.b();

                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            poprzedni = "b'";
                            powtorka = k1.copyList(powtorka, "b'");
                            k1.b_();
                        }
                    }
                }
            }
            krzyzElementTrzy:
            kostkas.Clear();
            foreach (Kostka k in nowaLista)
            {
                kostkas.Add(k);
            }
            nowaLista.Clear();
            foreach (Kostka k1 in kostkas)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (k1.r_T().trueFalseCrossZI3(kostkas, nowaLista) || //pierwszy element
                        k1.rT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.lT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.l_T().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.uT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.u_T().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.dT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.d_T().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.fT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.f_T().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.bT().trueFalseCrossZI3(kostkas, nowaLista) ||
                        k1.b_T().trueFalseCrossZI3(kostkas, nowaLista))
                    {
                        MessageBox.Show("dai3");
                        goto krzyzElementCztery;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            poprzedni = "r";
                            powtorka = k1.copyList(powtorka, "r");
                            k1.r();
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            poprzedni = "r'";
                            powtorka = k1.copyList(powtorka, "r'");
                            k1.r_();
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            poprzedni = "l";
                            powtorka = k1.copyList(powtorka, "l");
                            k1.l();
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            poprzedni = "l'";
                            powtorka = k1.copyList(powtorka, "l'");
                            k1.l_();
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            poprzedni = "u";
                            powtorka = k1.copyList(powtorka, "u");
                            k1.u();
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            poprzedni = "u'";
                            powtorka = k1.copyList(powtorka, "u'");
                            k1.u_();
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            poprzedni = "d";
                            powtorka = k1.copyList(powtorka, "d");
                            k1.d();
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            poprzedni = "d'";
                            powtorka = k1.copyList(powtorka, "d'");
                            k1.d_();

                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            poprzedni = "f";
                            powtorka = k1.copyList(powtorka, "f");
                            k1.f_();
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            poprzedni = "f'";
                            powtorka = k1.copyList(powtorka, "f'");
                            k1.f_();
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            poprzedni = "b";
                            powtorka = k1.copyList(powtorka, "b");
                            k1.b();

                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            poprzedni = "b'";
                            powtorka = k1.copyList(powtorka, "b'");
                            k1.b_();
                        }
                    }
                }
            }
            krzyzElementCztery:
            kostkas.Clear();
            foreach (Kostka k in nowaLista)
            {
                kostkas.Add(k);
            }
            nowaLista.Clear();
            foreach (Kostka k1 in kostkas)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (k1.r_T().trueFalseCrossZI4(kostkas, nowaLista) || //pierwszy element
                        k1.rT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.lT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.l_T().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.uT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.u_T().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.dT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.d_T().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.fT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.f_T().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.bT().trueFalseCrossZI4(kostkas, nowaLista) ||
                        k1.b_T().trueFalseCrossZI4(kostkas, nowaLista))
                    {
                        MessageBox.Show("dai4");
                        ulozona = k1;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            poprzedni = "r";
                            powtorka = k1.copyList(powtorka, "r");
                            k1.r();
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            poprzedni = "r'";
                            powtorka = k1.copyList(powtorka, "r'");
                            k1.r_();
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            poprzedni = "l";
                            powtorka = k1.copyList(powtorka, "l");
                            k1.l();
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            poprzedni = "l'";
                            powtorka = k1.copyList(powtorka, "l'");
                            k1.l_();
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            poprzedni = "u";
                            powtorka = k1.copyList(powtorka, "u");
                            k1.u();
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            poprzedni = "u'";
                            powtorka = k1.copyList(powtorka, "u'");
                            k1.u_();
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            poprzedni = "d";
                            powtorka = k1.copyList(powtorka, "d");
                            k1.d();
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            poprzedni = "d'";
                            powtorka = k1.copyList(powtorka, "d'");
                            k1.d_();

                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            poprzedni = "f";
                            powtorka = k1.copyList(powtorka, "f");
                            k1.f_();
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            poprzedni = "f'";
                            powtorka = k1.copyList(powtorka, "f'");
                            k1.f_();
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            poprzedni = "b";
                            powtorka = k1.copyList(powtorka, "b");
                            k1.b();

                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            poprzedni = "b'";
                            powtorka = k1.copyList(powtorka, "b'");
                            k1.b_();
                        }
                    }
                }
            }
            
            //List<kostka> nowa = new List<kostka>();
            Kostka ulozona1 = new Kostka();
            //nowaLista.Clear();
            for (int i = 0; i < 5; i++)
            {
                foreach (Kostka kost1 in kostkas)
                {
                    if (kost1.r_T().trueFalseCrossZI1(kostkas, ref nowa, "r'") ||
                    kost1.rT().trueFalseCrossZI1(kostkas, ref nowa, "r") ||
                    kost1.lT().trueFalseCrossZI1(kostkas, ref nowa, "l") ||
                    kost1.l_T().trueFalseCrossZI1(kostkas, ref nowa, "l'") ||
                    kost1.uT().trueFalseCrossZI1(kostkas, ref nowa, "u") ||
                    kost1.u_T().trueFalseCrossZI1(kostkas, ref nowa, "u'") ||
                    kost1.dT().trueFalseCrossZI1(kostkas, ref nowa, "d") ||
                    kost1.d_T().trueFalseCrossZI1(kostkas, ref nowa, "d'") ||
                    kost1.fT().trueFalseCrossZI1(kostkas, ref nowa, "f") ||
                    kost1.f_T().trueFalseCrossZI1(kostkas, ref nowa, "f'") ||
                    kost1.bT().trueFalseCrossZI1(kostkas, ref nowa, "b") ||
                    kost1.b_T().trueFalseCrossZI1(kostkas, ref nowa, "b'"))
                    {
                        MessageBox.Show("działa1");

                        kostkas.Clear();
                        check = true;
                        foreach (Kostka k in nowa)
                        {
                            kostkas.Add(k);
                        }
                        kost1.moves2(check, ulozona1, poprzedni, powtorka, ref kostkas, nowaLista, nowa);
                        ulozona.scianaB.pola_ = ulozona1.scianaB.pola_;
                        ulozona.scianaC.pola_ = ulozona1.scianaC.pola_;
                        ulozona.scianaZ.pola_ = ulozona1.scianaZ.pola_;
                        ulozona.scianaZI.pola_ = ulozona1.scianaZI.pola_;
                        ulozona.scianaP.pola_ = ulozona1.scianaP.pola_;
                        ulozona.scianaN.pola_ = ulozona1.scianaN.pola_;
                        break;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r");
                            poprzedni = "r";
                            copyList(powtorka, "r");
                            nowaLista.Add(kost1.rT());
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r'");
                            poprzedni = "r'";
                            copyList(powtorka, "r'");
                            nowaLista.Add(kost1.r_T());
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l");
                            poprzedni = "l";
                            copyList(powtorka, "l");
                            nowaLista.Add(kost1.lT());
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l'");
                            poprzedni = "l'";
                            copyList(powtorka, "l'");
                            nowaLista.Add(kost1.l_T());
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u");
                            poprzedni = "u";
                            copyList(powtorka, "u");
                            nowaLista.Add(kost1.uT());
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u'");
                            poprzedni = "u'";
                            copyList(powtorka, "u'");
                            nowaLista.Add(kost1.u_T());
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d");
                            poprzedni = "d";
                            copyList(powtorka, "d");
                            nowaLista.Add(kost1.dT());
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d'");
                            poprzedni = "d'";
                            copyList(powtorka, "d'");
                            nowaLista.Add(kost1.d_T());
                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f");
                            poprzedni = "f";
                            copyList(powtorka, "f");
                            nowaLista.Add(kost1.fT());
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f'");
                            poprzedni = "f'";
                            copyList(powtorka, "f'");
                            nowaLista.Add(kost1.f_T());
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b");
                            poprzedni = "b";
                            copyList(powtorka, "b");
                            nowaLista.Add(kost1.bT());
                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b'");
                            poprzedni = "b'";
                            copyList(powtorka, "b'");
                            nowaLista.Add(kost1.b_T());
                        }
                    }
                }
                if (check == true)
                {
                    break;
                }
                else
                {
                    kostkas.Clear();
                    foreach (Kostka k in nowaLista)
                    {
                        kostkas.Add(k);
                    }
                    nowaLista.Clear();
                }
            } 
        }*/
        /*if (idx < limit)
        {
            idx++;
            if (kost.r_T().trueFalse() ||
                kost.rT().trueFalse() ||
                kost.lT().trueFalse() ||
                kost.l_T().trueFalse() ||
                kost.uT().trueFalse() ||
                kost.u_T().trueFalse() ||
                kost.dT().trueFalse() ||
                kost.d_T().trueFalse() ||
                kost.fT().trueFalse() ||
                kost.f_T().trueFalse() ||
                kost.bT().trueFalse() ||
                kost.b_T().trueFalse())
            {
                ulozona.scianaB.pola_ =
                [["b", "b", "b"], 
                ["b", "b", "b"], 
                ["b", "b", "b"]];

                ulozona.scianaZ.pola_ =
                [["z", "z", "z"],
                ["z", "z", "z"],
                ["z", "z", "z"]];

                ulozona.scianaC.pola_ =
                [["c", "c", "c"],
                ["c", "c", "c"],
                ["c", "c", "c"]];

                ulozona.scianaP.pola_ =
                [["p", "p", "p"],
                ["p", "p", "p"],
                ["p", "p", "p"]];

                ulozona.scianaN.pola_ =
                [["n", "n", "n"],
                ["n", "n", "n"],
                ["n", "n", "n"]];

                ulozona.scianaZI.pola_ =
                [["zi", "zi", "zi"],
                ["zi", "zi", "zi"],
                ["zi", "zi", "zi"]];
            }
            else
            {   
                if(poprzedni == "r'" || listToString(powtorka) == "rrr")
                {

                } 
                else
                {
                    moves(kost.rT(), idx, ref ulozona, ref check, poprzedni = "r", copyList(powtorka, "r"));
                }
                if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                {

                }
                else
                {
                    moves(kost.r_T(), idx, ref ulozona, ref check, poprzedni = "r'", copyList(powtorka, "r'"));
                }
                if (poprzedni == "l'" || listToString(powtorka) == "lll")
                {

                }
                else
                {
                    moves(kost.lT(), idx, ref ulozona, ref check, poprzedni = "l", copyList(powtorka, "l"));
                }
                if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                {

                }
                else
                {
                    moves(kost.l_T(), idx, ref ulozona, ref check, poprzedni = "l'", copyList(powtorka, "l'"));
                }
                if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                {

                }
                else
                {
                    moves(kost.uT(), idx, ref ulozona, ref check, poprzedni = "u", copyList(powtorka, "u"));
                }
                if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                {

                }
                else
                {
                    moves(kost.u_T(), idx, ref ulozona, ref check, poprzedni = "u'", copyList(powtorka, "u'"));
                }
                if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                {

                }
                else
                {
                    moves(kost.dT(), idx, ref ulozona, ref check, poprzedni = "d", copyList(powtorka, "d"));
                }
                if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                {

                }
                else
                {
                    moves(kost.d_T(), idx, ref ulozona, ref check, poprzedni = "d'", copyList(powtorka, "d'"));
                }
                if (poprzedni == "f'" || listToString(powtorka) == "fff")
                {

                }
                else
                {
                    moves(kost.fT(), idx, ref ulozona, ref check, poprzedni = "f", copyList(powtorka, "f"));
                }
                if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                {

                }
                else
                {
                    moves(kost.r_T(), idx, ref ulozona, ref check, poprzedni = "f'", copyList(powtorka, "f'"));
                }
                if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                {

                }
                else
                {
                    moves(kost.bT(), idx, ref ulozona, ref check, poprzedni = "b", copyList(powtorka, "b"));

                }
                if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                {

                }
                else
                {
                    moves(kost.b_T(), idx, ref ulozona, ref check, poprzedni = "b'", copyList(powtorka, "b'"));
                }
            }
        }



        /*for(int i = 0; i > 12; i++)
        {
            Kostka k = kost[i];
            k.r();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.r_();
            }
            k.r_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.r();
            }
            k.l();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.l_();
            }
            k.l_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.l();
            }
            k.u();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.u_();
            }
            k.u_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.u();
            }
            k.d();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.d_();
            }
            k.d_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.d();
            }
            k.f();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.f_();
            }
            k.f_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.f();
            }
            k.b();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.b_();
            }
            k.b_();
            if (k.trueFalse(k) == true)
            {
                ulozona = k;
            }
            else
            {
                k.b();
            }
        }
        kost[0].r();
        kost[1].r_();
        kost[2].l();
        kost[3].l_();
        kost[4].u();
        kost[5].u_();
        kost[6].d();
        kost[7].d_();
        kost[8].f();
        kost[9].f_();
        kost[10].b();
        kost[11].b_();*/
        /*if ( == false)
        {

            k.r();
            moves(k, ref idx);

            k.d_();
            moves(k, ref idx);
            k.l();
            moves(k, ref idx);
            k.f_();
            moves(k, ref idx);
            k.u();
            moves(k, ref idx);
            k.r_();
            moves(k, ref idx);
            k.d();
            moves(k, ref idx);
            k.l_();
            moves(k, ref idx);
            k.f();
            moves(k, ref idx);
            k.b_();
            moves(k, ref idx);
            k.b();
            moves(k, ref idx);
            k.u_();
            moves(k, ref idx);
        }*/
        /*public void moves2(bool check, Kostka ulozona, string poprzedni, List<string> powtorka, ref List<kostka> kostkas, List<kostka> nowaLista, List <kostka> nowa)
        {
            Kostka ulozona2 = new Kostka(); 
            nowaLista.Clear();
            check = false;
            for (int i = 0; i < 5; i++)
            {
                foreach (Kostka kost1 in kostkas)
                {
                    if (kost1.r_T().trueFalseCrossZI2(kostkas, ref nowa, "r'") ||
                    kost1.rT().trueFalseCrossZI2(kostkas, ref nowa, "r") ||
                    kost1.lT().trueFalseCrossZI2(kostkas, ref nowa, "l") ||
                    kost1.l_T().trueFalseCrossZI2(kostkas, ref nowa, "l'") ||
                    kost1.uT().trueFalseCrossZI2(kostkas, ref nowa, "u") ||
                    kost1.u_T().trueFalseCrossZI2(kostkas, ref nowa, "u'") ||
                    kost1.dT().trueFalseCrossZI2(kostkas, ref nowa, "d") ||
                    kost1.d_T().trueFalseCrossZI2(kostkas, ref nowa, "d'") ||
                    kost1.fT().trueFalseCrossZI2(kostkas, ref nowa, "f") ||
                    kost1.f_T().trueFalseCrossZI2(kostkas, ref nowa, "f'") ||
                    kost1.bT().trueFalseCrossZI2(kostkas, ref nowa, "b") ||
                    kost1.b_T().trueFalseCrossZI2(kostkas, ref nowa, "b'"))
                    {
                        MessageBox.Show("działa2");
                        kostkas.Clear();
                        foreach (Kostka k in nowa)
                        {
                            kostkas.Add(k);
                        }
                        check = true;
                        kost1.moves3(check, ulozona2, poprzedni, powtorka, ref kostkas, nowaLista, nowa);
                        ulozona.scianaB.pola_ = ulozona2.scianaB.pola_;
                        ulozona.scianaC.pola_ = ulozona2.scianaC.pola_;
                        ulozona.scianaZ.pola_ = ulozona2.scianaZ.pola_;
                        ulozona.scianaZI.pola_ = ulozona2.scianaZI.pola_;
                        ulozona.scianaP.pola_ = ulozona2.scianaP.pola_;
                        ulozona.scianaN.pola_ = ulozona2.scianaN.pola_;
                        break;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r");
                            poprzedni = "r";
                            copyList(powtorka, "r");
                            nowaLista.Add(kost1.rT());
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r'");
                            poprzedni = "r'";
                            copyList(powtorka, "r'");
                            nowaLista.Add(kost1.r_T());
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l");
                            poprzedni = "l";
                            copyList(powtorka, "l");
                            nowaLista.Add(kost1.lT());
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l'");
                            poprzedni = "l'";
                            copyList(powtorka, "l'");
                            nowaLista.Add(kost1.l_T());
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u");
                            poprzedni = "u";
                            copyList(powtorka, "u");
                            nowaLista.Add(kost1.uT());
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u'");
                            poprzedni = "u'";
                            copyList(powtorka, "u'");
                            nowaLista.Add(kost1.u_T());
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d");
                            poprzedni = "d";
                            copyList(powtorka, "d");
                            nowaLista.Add(kost1.dT());
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d'");
                            poprzedni = "d'";
                            copyList(powtorka, "d'");
                            nowaLista.Add(kost1.d_T());
                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f");
                            poprzedni = "f";
                            copyList(powtorka, "f");
                            nowaLista.Add(kost1.fT());
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f'");
                            poprzedni = "f'";
                            copyList(powtorka, "f'");
                            nowaLista.Add(kost1.f_T());
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b");
                            poprzedni = "b";
                            copyList(powtorka, "b");
                            nowaLista.Add(kost1.bT());
                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b'");
                            poprzedni = "b'";
                            copyList(powtorka, "b'");
                            nowaLista.Add(kost1.b_T());
                        }
                    }
                }
                if (check == true)
                {
                    break;
                }
                else
                {
                    kostkas.Clear();
                    foreach (Kostka k in nowaLista)
                    {
                        kostkas.Add(k);
                    }
                    nowaLista.Clear();
                }
            }
        }
        public void moves3(bool check, Kostka ulozona, string poprzedni, List<string> powtorka, ref List<kostka> kostkas, List<kostka> nowaLista, List <kostka> nowa)
        {
            Kostka ulozona3 = new Kostka();
            nowaLista.Clear();
            check = false;
            for (int i = 0; i < 5; i++)
            {
                foreach (Kostka kost1 in kostkas)
                {
                    if (kost1.r_T().trueFalseCrossZI3(kostkas, ref nowa, "r'") ||
                    kost1.rT().trueFalseCrossZI3(kostkas, ref nowa, "r") ||
                    kost1.lT().trueFalseCrossZI3(kostkas, ref nowa, "l") ||
                    kost1.l_T().trueFalseCrossZI3(kostkas, ref nowa, "l'") ||
                    kost1.uT().trueFalseCrossZI3(kostkas, ref nowa, "u") ||
                    kost1.u_T().trueFalseCrossZI3(kostkas, ref nowa, "u'") ||
                    kost1.dT().trueFalseCrossZI3(kostkas, ref nowa, "d") ||
                    kost1.d_T().trueFalseCrossZI3(kostkas, ref nowa, "d'") ||
                    kost1.fT().trueFalseCrossZI3(kostkas, ref nowa, "f") ||
                    kost1.f_T().trueFalseCrossZI3(kostkas,  ref nowa, "f'") ||
                    kost1.bT().trueFalseCrossZI3(kostkas, ref nowa, "b") ||
                    kost1.b_T().trueFalseCrossZI3(kostkas, ref nowa, "b'"))
                    {
                        MessageBox.Show("działa3");
                        kostkas.Clear();
                        foreach (Kostka k in nowa)
                        {
                            kostkas.Add(k);
                        }
                        check = true;
                        kost1.moves4(check, ulozona3, poprzedni, powtorka, ref kostkas, nowaLista, nowa);
                        scianaBT.pola_ = ulozona3.scianaB.pola_;
                        scianaCT.pola_ = ulozona3.scianaC.pola_;
                        scianaNT.pola_ = ulozona3.scianaZ.pola_;
                        scianaZIT.pola_ = ulozona3.scianaZI.pola_;
                        scianaPT.pola_ = ulozona3.scianaP.pola_;
                        scianaNT.pola_ = ulozona3.scianaN.pola_; 
                        break;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r");
                            poprzedni = "r";
                            copyList(powtorka, "r");
                            nowaLista.Add(kost1.rT());
                        }
                        if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("r'");
                            poprzedni = "r'";
                            copyList(powtorka, "r'");
                            nowaLista.Add(kost1.r_T());
                        }
                        if (poprzedni == "l'" || listToString(powtorka) == "lll")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l");
                            poprzedni = "l";
                            copyList(powtorka, "l");
                            nowaLista.Add(kost1.lT());
                        }
                        if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("l'");
                            poprzedni = "l'";
                            copyList(powtorka, "l'");
                            nowaLista.Add(kost1.l_T());
                        }
                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u");
                            poprzedni = "u";
                            copyList(powtorka, "u");
                            nowaLista.Add(kost1.uT());
                        }
                        if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("u'");
                            poprzedni = "u'";
                            copyList(powtorka, "u'");
                            nowaLista.Add(kost1.u_T());
                        }
                        if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d");
                            poprzedni = "d";
                            copyList(powtorka, "d");
                            nowaLista.Add(kost1.dT());
                        }
                        if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("d'");
                            poprzedni = "d'";
                            copyList(powtorka, "d'");
                            nowaLista.Add(kost1.d_T());
                        }
                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f");
                            poprzedni = "f";
                            copyList(powtorka, "f");
                            nowaLista.Add(kost1.fT());
                        }
                        if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("f'");
                            poprzedni = "f'";
                            copyList(powtorka, "f'");
                            nowaLista.Add(kost1.f_T());
                        }
                        if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b");
                            poprzedni = "b";
                            copyList(powtorka, "b");
                            nowaLista.Add(kost1.bT());
                        }
                        if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                        {

                        }
                        else
                        {
                            kost1.ruchy.Add("b'");
                            poprzedni = "b'";
                            copyList(powtorka, "b'");
                            nowaLista.Add(kost1.b_T());
                        }
                    }
                }
                if (check == true)
                {
                    break;
                } else
                {
                    kostkas.Clear();
                    foreach (Kostka k in nowaLista)
                    {
                        kostkas.Add(k);
                    }
                    nowaLista.Clear();
                }  
            }
        }
        public void moves4(bool check, Kostka ulozona, string poprzedni, List<string> powtorka, ref List<kostka> kostkas, List<kostka> nowaLista, List <kostka> nowa)
        {
            Kostka ulozona4 = new Kostka();
            nowaLista.Clear();
            check = false;
            for (int i = 0; i < 5; i++)
            {
                foreach (Kostka kost1 in kostkas)
                {
                    if (kost1.r_T().trueFalseCrossZI4(kostkas,ref nowa, "r'") ||
                    kost1.rT().trueFalseCrossZI4(kostkas,ref nowa, "r") ||
                    kost1.lT().trueFalseCrossZI4(kostkas,ref nowa, "l") ||
                    kost1.l_T().trueFalseCrossZI4(kostkas,ref nowa, "l'") ||
                    kost1.uT().trueFalseCrossZI4(kostkas,ref nowa, "u") ||
                    kost1.u_T().trueFalseCrossZI4(kostkas,ref nowa, "u'") ||
                    kost1.dT().trueFalseCrossZI4(kostkas,ref nowa, "d") ||
                    kost1.d_T().trueFalseCrossZI4(kostkas,ref nowa, "d'") ||
                    kost1.fT().trueFalseCrossZI4(kostkas,ref nowa, "f") ||
                    kost1.f_T().trueFalseCrossZI4(kostkas,ref nowa, "f'") ||
                    kost1.bT().trueFalseCrossZI4(kostkas,ref nowa, "b") ||
                    kost1.b_T().trueFalseCrossZI4(kostkas,ref nowa, "b'"))
                    {
                        MessageBox.Show("Jest krzyż");
                        check = true;
                        break;
                    }
                    else
                    {
                        if (poprzedni == "r'" || listToString(powtorka) == "rrr")
                        {
                            if (poprzedni == "r" || listToString(powtorka) == "r'r'r'")
                            {
                                if (poprzedni == "l'" || listToString(powtorka) == "lll")
                                {
                                    if (poprzedni == "l" || listToString(powtorka) == "l'l'l'")
                                    {
                                        if (poprzedni == "u'" || listToString(powtorka) == "uuu")
                                        {
                                            if (poprzedni == "u" || listToString(powtorka) == "u'u'u'")
                                            {
                                                if (poprzedni == "d'" || listToString(powtorka) == "ddd")
                                                {
                                                    if (poprzedni == "d" || listToString(powtorka) == "d'd'd'")
                                                    {
                                                        if (poprzedni == "f'" || listToString(powtorka) == "fff")
                                                        {
                                                            if (poprzedni == "f" || listToString(powtorka) == "f'f'f'")
                                                            {
                                                                if (poprzedni == "b'" || listToString(powtorka) == "bbb")
                                                                {
                                                                    if (poprzedni == "b" || listToString(powtorka) == "b'b'b'")
                                                                    {

                                                                    }
                                                                    else
                                                                    {
                                                                        kost1.ruchy.Add("b'");
                                                                        poprzedni = "b'";
                                                                        copyList(powtorka, "b'");
                                                                        nowaLista.Add(kost1.b_T());
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    kost1.ruchy.Add("b");
                                                                    poprzedni = "b";
                                                                    copyList(powtorka, "b");
                                                                    nowaLista.Add(kost1.bT());
                                                                }
                                                            }
                                                            else
                                                            {
                                                                kost1.ruchy.Add("f");
                                                                poprzedni = "f'";
                                                                copyList(powtorka, "f'");
                                                                nowaLista.Add(kost1.r_T());
                                                            }
                                                        }
                                                        else
                                                        {
                                                            kost1.ruchy.Add("f");
                                                            poprzedni = "f";
                                                            copyList(powtorka, "f");
                                                            nowaLista.Add(kost1.fT());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        kost1.ruchy.Add("d'");
                                                        poprzedni = "d'";
                                                        copyList(powtorka, "d'");
                                                        nowaLista.Add(kost1.d_T());
                                                    }
                                                }
                                                else
                                                {
                                                    kost1.ruchy.Add("d");
                                                    poprzedni = "d";
                                                    copyList(powtorka, "d");
                                                    nowaLista.Add(kost1.dT());
                                                }
                                            }
                                            else
                                            {
                                                kost1.ruchy.Add("u'");
                                                poprzedni = "u'";
                                                copyList(powtorka, "u'");
                                                nowaLista.Add(kost1.u_T());
                                            }
                                        }
                                        else
                                        {
                                            kost1.ruchy.Add("u");
                                            poprzedni = "u";
                                            copyList(powtorka, "u");
                                            nowaLista.Add(kost1.uT());
                                        }
                                    }
                                    else
                                    {
                                        kost1.ruchy.Add("l'");
                                        poprzedni = "l'";
                                        copyList(powtorka, "l'");
                                        nowaLista.Add(kost1.l_T());
                                    }
                                }
                                else
                                {
                                    kost1.ruchy.Add("l");
                                    poprzedni = "l";
                                    copyList(powtorka, "l");
                                    nowaLista.Add(kost1.lT());
                                }
                            }
                            else
                            {
                                kost1.ruchy.Add("r'");
                                poprzedni = "r'";
                                copyList(powtorka, "r'");
                                nowaLista.Add(kost1.r_T());
                            }
                        }
                        else
                        {
                            kost1.ruchy.Add("r");
                            poprzedni = "r";
                            copyList(powtorka, "r");
                            nowaLista.Add(kost1.rT());
                        }
                    }
                }
                if (check == true)
                {
                    break;
                }
                else
                {
                    kostkas.Clear();
                    foreach (Kostka k in nowaLista)
                    {
                        kostkas.Add(k);
                    }
                    nowaLista.Clear();
                }
            }
        }*/

        public string listToString(List<string> list)
        {
            string ciag = "";
            foreach (string str in list)
            {
                ciag += str;
            }
            return ciag;
        }
        public List<string> copyList(List<string> lista, string el)
        {
            List<string> L = new List<string>();
            try
            {
                L.Add(lista[1]);
            }
            catch
            {

            }
            try
            {
                L.Add(lista[2]);
            }
            catch
            {

            }
            L.Add(el);

            return L;
        }
        public void r()
        {
            scianaC_.rotate();
            var temp = scianaZI_.getCol(2);
            scianaZI_.setCol(2, scianaZ_.getCol(2));
            scianaZ_.setCol(2, scianaN_.getColRewerse(0));
            scianaN_.setCol(0, scianaB_.getColRewerse(2));
            scianaB_.setCol(2, temp);
        }
        public Kostka rT()
        {
            Kostka N = new Kostka(this);
            N.scianaC_.rotate();
            var temp = N.scianaZI_.getCol(2);
            N.scianaZI_.setCol(2, N.scianaZ_.getCol(2));
            N.scianaZ_.setCol(2, N.scianaN_.getColRewerse(0));
            N.scianaN_.setCol(0, N.scianaB_.getColRewerse(2));
            N.scianaB_.setCol(2, temp);
            N.listR.Add("r");
            return N;
        }
        public Kostka rT2()
        {
            Kostka N = new Kostka(this);
            N.scianaC_.rotate();
            var temp = N.scianaZI_.getCol(2);
            N.scianaZI_.setCol(2, N.scianaZ_.getCol(2));
            N.scianaZ_.setCol(2, N.scianaN_.getColRewerse(0));
            N.scianaN_.setCol(0, N.scianaB_.getColRewerse(2));
            N.scianaB_.setCol(2, temp);
            N.scianaC_.rotate();
            temp = N.scianaZI_.getCol(2);
            N.scianaZI_.setCol(2, N.scianaZ_.getCol(2));
            N.scianaZ_.setCol(2, N.scianaN_.getColRewerse(0));
            N.scianaN_.setCol(0, N.scianaB_.getColRewerse(2));
            N.scianaB_.setCol(2, temp);
            N.listR.Add("r2");
            return N;
        }
        public void r_()
        {
            scianaC_.rotate();
            scianaC_.rotate();
            scianaC_.rotate();
            var temp = scianaZI_.getCol(2);
            scianaZI_.setCol(2, scianaB_.getCol(2));
            scianaB_.setCol(2, scianaN_.getColRewerse(0));
            scianaN_.setCol(0, scianaZ_.getColRewerse(2));
            scianaZ_.setCol(2, temp);
        }
        public Kostka r_T()
        {
            Kostka N = new Kostka(this);
            N.scianaC_.rotate();
            N.scianaC_.rotate();
            N.scianaC_.rotate();
            var temp = N.scianaZI_.getCol(2);
            N.scianaZI_.setCol(2, N.scianaB_.getCol(2));
            N.scianaB_.setCol(2, N.scianaN_.getColRewerse(0));
            N.scianaN_.setCol(0, N.scianaZ_.getColRewerse(2));
            N.scianaZ_.setCol(2, temp);
            N.listR.Add("r_");

            return N;
        }
        public void l()
        {       
            scianaP_.rotate();
            var temp = scianaZI_.getCol(0);
            scianaZI_.setCol(0, scianaB_.getCol(0));
            scianaB_.setCol(0, scianaN_.getColRewerse(2));
            scianaN_.setCol(2, scianaZ_.getColRewerse(0));
            scianaZ_.setCol(0, temp);
        }
        public Kostka lT()
        {
            Kostka N = new Kostka(this);
            N.scianaP_.rotate();
            var temp = N.scianaZI_.getCol(0);
            N.scianaZI_.setCol(0, N.scianaB_.getCol(0));
            N.scianaB_.setCol(0, N.scianaN_.getColRewerse(2));
            N.scianaN_.setCol(2, N.scianaZ_.getColRewerse(0));
            N.scianaZ_.setCol(0, temp);
            N.listR.Add("l");
            return N;
        }
        public Kostka lT2()
        {
            Kostka N = new Kostka(this);
            N.scianaP_.rotate();
            var temp = N.scianaZI_.getCol(0);
            N.scianaZI_.setCol(0, N.scianaB_.getCol(0));
            N.scianaB_.setCol(0, N.scianaN_.getColRewerse(2));
            N.scianaN_.setCol(2, N.scianaZ_.getColRewerse(0));
            N.scianaZ_.setCol(0, temp);
            N.scianaP_.rotate();
            temp = N.scianaZI_.getCol(0);
            N.scianaZI_.setCol(0, N.scianaB_.getCol(0));
            N.scianaB_.setCol(0, N.scianaN_.getColRewerse(2));
            N.scianaN_.setCol(2, N.scianaZ_.getColRewerse(0));
            N.scianaZ_.setCol(0, temp);
            N.listR.Add("l2");
            return N;
        }
        public void l_()
        {
            scianaP_.rotate();
            scianaP_.rotate();
            scianaP_.rotate();
            var temp = scianaZI_.getCol(0);
            scianaZI_.setCol(0, scianaZ_.getCol(0));
            scianaZ_.setCol(0, scianaN_.getColRewerse(2));
            scianaN_.setCol(2, scianaB_.getColRewerse(0));
            scianaB_.setCol(0, temp);

        }
        public Kostka l_T()
        {
            Kostka N = new Kostka(this);
            N.scianaP_.rotate();
            N.scianaP_.rotate();
            N.scianaP_.rotate();
            var temp = N.scianaZI_.getCol(0);
            N.scianaZI_.setCol(0, N.scianaZ_.getCol(0));
            N.scianaZ_.setCol(0, N.scianaN_.getColRewerse(2));
            N.scianaN_.setCol(2, N.scianaB_.getColRewerse(0));
            N.scianaB_.setCol(0, temp);
            N.listR.Add("l_");
            return N;

        }
        public void u()
        {
            scianaB_.rotate();
            var temp = scianaZI_.getRow(0);
            scianaZI_.setRow(0, scianaC_.getRow(0));
            scianaC_.setRow(0, scianaN_.getRow(0));
            scianaN_.setRow(0, scianaP_.getRow(0));
            scianaP_.setRow(0, temp);
        }
        public Kostka uT()
        {
            Kostka N = new Kostka(this);
            N.scianaB_.rotate();
            var temp = N.scianaZI_.getRow(0);
            N.scianaZI_.setRow(0, N.scianaC_.getRow(0));
            N.scianaC_.setRow(0, N.scianaN_.getRow(0));
            N.scianaN_.setRow(0, N.scianaP_.getRow(0));
            N.scianaP_.setRow(0, temp);
            N.listR.Add("u");
            return N;
        }
        public Kostka uT2()
        {
            Kostka N = new Kostka(this);
            N.scianaB_.rotate();
            var temp = N.scianaZI_.getRow(0);
            N.scianaZI_.setRow(0, N.scianaC_.getRow(0));
            N.scianaC_.setRow(0, N.scianaN_.getRow(0));
            N.scianaN_.setRow(0, N.scianaP_.getRow(0));
            N.scianaP_.setRow(0, temp);
            N.scianaB_.rotate();
            temp = N.scianaZI_.getRow(0);
            N.scianaZI_.setRow(0, N.scianaC_.getRow(0));
            N.scianaC_.setRow(0, N.scianaN_.getRow(0));
            N.scianaN_.setRow(0, N.scianaP_.getRow(0));
            N.scianaP_.setRow(0, temp);
            N.listR.Add("u2");
            return N;
        }
        public void u_()
        {
            scianaB_.rotate();
            scianaB_.rotate();
            scianaB_.rotate();
            var temp = scianaZI_.getRow(0);
            scianaZI_.setRow(0, scianaP_.getRow(0));
            scianaP_.setRow(0, scianaN_.getRow(0));
            scianaN_.setRow(0, scianaC_.getRow(0));
            scianaC_.setRow(0, temp);

        }
        public Kostka u_T()
        {
            Kostka N = new Kostka(this);
            N.scianaB_.rotate();
            N.scianaB_.rotate();
            N.scianaB_.rotate();
            var temp = N.scianaZI_.getRow(0);
            N.scianaZI_.setRow(0, N.scianaP_.getRow(0));
            N.scianaP_.setRow(0, N.scianaN_.getRow(0));
            N.scianaN_.setRow(0, N.scianaC_.getRow(0));
            N.scianaC_.setRow(0, temp);
            N.listR.Add("u_");
            return N;

        }
        public void d()
        {
            scianaZ_.rotate();
            var temp = scianaZI_.getRow(2);
            scianaZI_.setRow(2, scianaP_.getRow(2));
            scianaP_.setRow(2, scianaN_.getRow(2));
            scianaN_.setRow(2, scianaC_.getRow(2));
            scianaC_.setRow(2, temp);

        }
        public Kostka dT()
        {
            Kostka N = new Kostka(this);
            N.scianaZ_.rotate();
            var temp = N.scianaZI_.getRow(2);
            N.scianaZI_.setRow(2, N.scianaP_.getRow(2));
            N.scianaP_.setRow(2, N.scianaN_.getRow(2));
            N.scianaN_.setRow(2, N.scianaC_.getRow(2));
            N.scianaC_.setRow(2, temp);
            N.listR.Add("d");
            return N;
        }
        public Kostka dT2()
        {
            Kostka N = new Kostka(this);
            N.scianaZ_.rotate();
            var temp = N.scianaZI_.getRow(2);
            N.scianaZI_.setRow(2, N.scianaP_.getRow(2));
            N.scianaP_.setRow(2, N.scianaN_.getRow(2));
            N.scianaN_.setRow(2, N.scianaC_.getRow(2));
            N.scianaC_.setRow(2, temp);
            N.scianaZ_.rotate();
            temp = N.scianaZI_.getRow(2);
            N.scianaZI_.setRow(2, N.scianaP_.getRow(2));
            N.scianaP_.setRow(2, N.scianaN_.getRow(2));
            N.scianaN_.setRow(2, N.scianaC_.getRow(2));
            N.scianaC_.setRow(2, temp);
            N.listR.Add("d2");
            return N;

        }
        public void d_()
        {
            Kostka N = new Kostka(this);
            N.scianaZ_.rotate();
            N.scianaZ_.rotate();
            N.scianaZ_.rotate();
            var temp = N.scianaZI_.getRow(2);
            N.scianaZI_.setRow(2, N.scianaC_.getRow(2));
            N.scianaC_.setRow(2, N.scianaN_.getRow(2));
            N.scianaN_.setRow(2, N.scianaP_.getRow(2));
            N.scianaP_.setRow(2, temp);

        }
        public Kostka d_T()
        {
            Kostka N = new Kostka(this);
            N.scianaZ_.rotate();
            N.scianaZ_.rotate();
            N.scianaZ_.rotate();
            var temp = N.scianaZI_.getRow(2);
            N.scianaZI_.setRow(2, N.scianaC_.getRow(2));
            N.scianaC_.setRow(2, N.scianaN_.getRow(2));
            N.scianaN_.setRow(2, N.scianaP_.getRow(2));
            N.scianaP_.setRow(2, temp);
            N.listR.Add("d_");
            return N;

        }

        public void f()
        {   
            scianaZI_.rotate();
            var temp = scianaB_.getRow(2);
            scianaB_.setRow(2, scianaP_.getColRewerse(2));
            scianaP_.setCol(2, scianaZ_.getRow(0));
            scianaZ_.setRow(0, scianaC_.getColRewerse(0));
            scianaC_.setCol(0, temp);

        }
        public Kostka fT()
        {
            Kostka N = new Kostka(this);
            N.scianaZI_.rotate();
            var temp = N.scianaB_.getRow(2);
            N.scianaB_.setRow(2, N.scianaP_.getColRewerse(2));
            N.scianaP_.setCol(2, N.scianaZ_.getRow(0));
            N.scianaZ_.setRow(0, N.scianaC_.getColRewerse(0));
            N.scianaC_.setCol(0, temp);
            N.listR.Add("f");
            return N;

        }
        public Kostka fT2()
        {
            Kostka N = new Kostka(this);
            N.scianaZI_.rotate();
            var temp = N.scianaB_.getRow(2);
            N.scianaB_.setRow(2, N.scianaP_.getColRewerse(2));
            N.scianaP_.setCol(2, N.scianaZ_.getRow(0));
            N.scianaZ_.setRow(0, N.scianaC_.getColRewerse(0));
            N.scianaC_.setCol(0, temp);
            N.scianaZI_.rotate();
            temp = N.scianaB_.getRow(2);
            N.scianaB_.setRow(2, N.scianaP_.getColRewerse(2));
            N.scianaP_.setCol(2, N.scianaZ_.getRow(0));
            N.scianaZ_.setRow(0, N.scianaC_.getColRewerse(0));
            N.scianaC_.setCol(0, temp);
            N.listR.Add("f2");
            return N;

        }
        public void f_()
        {
            scianaZI_.rotate();
            scianaZI_.rotate();
            scianaZI_.rotate();
            var temp = scianaB_.getRowRewerse(2);
            scianaB_.setRow(2, scianaC_.getCol(0));
            scianaC_.setCol(0, scianaZ_.getRowRewerse(0));
            scianaZ_.setRow(0, scianaP_.getCol(2));
            scianaP_.setCol(2, temp);
        }
        public Kostka f_T()
        {
            Kostka N = new Kostka(this);
            N.scianaZI_.rotate();
            N.scianaZI_.rotate();
            N.scianaZI_.rotate();
            var temp = N.scianaB_.getRowRewerse(2);
            N.scianaB_.setRow(2, N.scianaC_.getCol(0));
            N.scianaC_.setCol(0, N.scianaZ_.getRowRewerse(0));
            N.scianaZ_.setRow(0, N.scianaP_.getCol(2));
            N.scianaP_.setCol(2, temp);
            N.listR.Add("f_");
            return N;
        }

        public void b()
        {
            scianaN_.rotate();
            var temp = scianaB_.getRowRewerse(0);
            scianaB_.setRow(0, scianaC_.getCol(2));
            scianaC_.setCol(2, scianaZ_.getRowRewerse(2));
            scianaZ_.setRow(2, scianaP_.getCol(0));
            scianaP_.setCol(0, temp);
        }

        public Kostka bT()
        {
            Kostka N = new Kostka(this);
            N.scianaN_.rotate();
            var temp = N.scianaB_.getRowRewerse(0);
            N.scianaB_.setRow(0, N.scianaC_.getCol(2));
            N.scianaC_.setCol(2, N.scianaZ_.getRowRewerse(2));
            N.scianaZ_.setRow(2, N.scianaP_.getCol(0));
            N.scianaP_.setCol(0, temp);
            N.listR.Add("b");
            return N;
        }
        public Kostka bT2()
        {
            Kostka N = new Kostka(this);
            N.scianaN_.rotate();
            var temp = N.scianaB_.getRowRewerse(0);
            N.scianaB_.setRow(0, N.scianaC_.getCol(2));
            N.scianaC_.setCol(2, N.scianaZ_.getRowRewerse(2));
            N.scianaZ_.setRow(2, N.scianaP_.getCol(0));
            N.scianaP_.setCol(0, temp);
            N.scianaN_.rotate();
            temp = N.scianaB_.getRowRewerse(0);
            N.scianaB_.setRow(0, N.scianaC_.getCol(2));
            N.scianaC_.setCol(2, N.scianaZ_.getRowRewerse(2));
            N.scianaZ_.setRow(2, N.scianaP_.getCol(0));
            N.scianaP_.setCol(0, temp);
            N.listR.Add("b2");
            return N;
        }
        public void b_()
        {
            scianaN_.rotate();
            scianaN_.rotate();
            scianaN_.rotate();
            var temp = scianaB_.getRow(0);
            scianaB_.setRow(0, scianaP_.getColRewerse(0));
            scianaP_.setCol(0, scianaZ_.getRow(2));
            scianaZ_.setRow(2, scianaC_.getColRewerse(2));
            scianaC_.setCol(2, temp);

        }
        public Kostka b_T()
        {
            Kostka N = new Kostka(this);
            N.scianaN_.rotate();
            N.scianaN_.rotate();
            N.scianaN_.rotate();
            var temp = N.scianaB_.getRow(0);
            N.scianaB_.setRow(0, N.scianaP_.getColRewerse(0));
            N.scianaP_.setCol(0, N.scianaZ_.getRow(2));
            N.scianaZ_.setRow(2, N.scianaC_.getColRewerse(2));
            N.scianaC_.setCol(2, temp);
            N.listR.Add("b_");
            return N;

        }
        /*public void obrotPoziom(int rzad, ref Sciana sciana1, ref Sciana sciana2, ref Sciana sciana3, ref Sciana sciana4, ref Sciana gora, ref Sciana dol)
        {
            if (rzad == 0)
            {
                var temp1 = sciana1.pola_[0];
                var temp2 = sciana2.pola_[0];
                var temp3 = sciana3.pola_[0];
                var temp4 = sciana4.pola_[0];
                var tempP1 = gora.pola_[0][0];
                var tempP2 = gora.pola_[0][1];
                var tempP3 = gora.pola_[0][2];
                var tempP4 = gora.pola_[1][0];
                var tempP6 = gora.pola_[1][2];
                var tempP7 = gora.pola_[2][0];
                var tempP8 = gora.pola_[2][1];
                var tempP9 = gora.pola_[2][2];
                sciana2.pola_[0] = temp1;
                sciana3.pola_[0] = temp2;
                sciana4.pola_[0] = temp3;
                sciana1.pola_[0] = temp4;
                gora.pola_[1][0] = tempP8;
                gora.pola_[0][0] = tempP7;
                gora.pola_[0][1] = tempP4;
                gora.pola_[0][2] = tempP1;
                gora.pola_[1][2] = tempP2;
                gora.pola_[2][0] = tempP9;
                gora.pola_[2][1] = tempP6;
                gora.pola_[2][2] = tempP3;
            }
            else if (rzad == 1)
            {
                var temp1 = sciana1.pola_[1];
                var temp2 = sciana2.pola_[1];
                var temp3 = sciana3.pola_[1];
                var temp4 = sciana4.pola_[1];
                sciana2.pola_[1] = temp1;
                sciana3.pola_[1] = temp2;
                sciana4.pola_[1] = temp3;
                sciana1.pola_[1] = temp4;
            }
            else if (rzad == 2)
            {
                var temp1 = sciana1.pola_[2];
                var temp2 = sciana2.pola_[2];
                var temp3 = sciana3.pola_[2];
                var temp4 = sciana4.pola_[2];
                sciana2.pola_[2] = temp1;
                sciana3.pola_[2] = temp2;
                sciana4.pola_[2] = temp3;
                sciana1.pola_[2] = temp4;
                var tempP1 = dol.pola_[0][0];
                var tempP2 = dol.pola_[0][1];
                var tempP3 = dol.pola_[0][2];
                var tempP4 = dol.pola_[1][0];
                var tempP6 = dol.pola_[1][2];
                var tempP7 = dol.pola_[2][0];
                var tempP8 = dol.pola_[2][1];
                var tempP9 = dol.pola_[2][2];
                dol.pola_[0][0] = tempP7;
                dol.pola_[0][1] = tempP4;
                dol.pola_[0][2] = tempP1;
                dol.pola_[1][0] = tempP8;
                dol.pola_[1][2] = tempP2;
                dol.pola_[2][0] = tempP9;
                dol.pola_[2][1] = tempP6;
                dol.pola_[2][2] = tempP3;
            }
        }
        public void obrotPionowy(int kolumna, ref Sciana sciana1, ref Sciana sciana2, ref Sciana sciana3, ref Sciana sciana4, ref Sciana lewa, ref Sciana prawa)
        {
            if (kolumna == 0)
            {
                string[] rzad1 = [sciana1.pola_[0][0], sciana1.pola_[1][0], sciana1.pola_[2][0]];
                string[] rzad2 = [sciana2.pola_[0][0], sciana2.pola_[1][0], sciana2.pola_[2][0]];
                string[] rzad3 = [sciana3.pola_[0][0], sciana3.pola_[1][0], sciana3.pola_[2][0]];
                string[] rzad4 = [sciana4.pola_[0][0], sciana4.pola_[1][0], sciana4.pola_[2][0]];
                sciana1.pola_[0][0] = rzad2[0];
                sciana1.pola_[1][0] = rzad2[1];
                sciana1.pola_[2][0] = rzad2[2];
                sciana2.pola_[0][0] = rzad3[0];
                sciana2.pola_[1][0] = rzad3[1];
                sciana2.pola_[2][0] = rzad3[2];
                sciana3.pola_[0][0] = rzad4[0];
                sciana3.pola_[1][0] = rzad4[1];
                sciana3.pola_[2][0] = rzad4[2];
                sciana4.pola_[0][0] = rzad1[0];
                sciana4.pola_[1][0] = rzad1[1];
                sciana4.pola_[2][0] = rzad1[2];
                var tempP1 = lewa.pola_[0][0];
                var tempP2 = lewa.pola_[0][1];
                var tempP3 = lewa.pola_[0][2];
                var tempP4 = lewa.pola_[1][0];
                var tempP6 = lewa.pola_[1][2];
                var tempP7 = lewa.pola_[2][0];
                var tempP8 = lewa.pola_[2][1];
                var tempP9 = lewa.pola_[2][2];
                lewa.pola_[0][0] = tempP7;
                lewa.pola_[0][1] = tempP4;
                lewa.pola_[0][2] = tempP1;
                lewa.pola_[1][0] = tempP8;
                lewa.pola_[1][2] = tempP2;
                lewa.pola_[2][0] = tempP9;
                lewa.pola_[2][1] = tempP6;
                lewa.pola_[2][2] = tempP3;
            }
            else if (kolumna == 1)
            {
                string[] rzad1 = [sciana1.pola_[0][1], sciana1.pola_[1][1], sciana1.pola_[2][1]];
                string[] rzad2 = [sciana2.pola_[0][1], sciana2.pola_[1][1], sciana2.pola_[2][1]];
                string[] rzad3 = [sciana3.pola_[0][1], sciana3.pola_[1][1], sciana3.pola_[2][1]];
                string[] rzad4 = [sciana4.pola_[0][1], sciana4.pola_[1][1], sciana4.pola_[2][1]];
                sciana1.pola_[0][1] = rzad2[0];
                sciana1.pola_[1][1] = rzad2[1];
                sciana1.pola_[2][1] = rzad2[2];
                sciana2.pola_[0][1] = rzad3[0];
                sciana2.pola_[1][1] = rzad3[1];
                sciana2.pola_[2][1] = rzad3[2];
                sciana3.pola_[0][1] = rzad4[0];
                sciana3.pola_[1][1] = rzad4[1];
                sciana3.pola_[2][1] = rzad4[2];
                sciana4.pola_[0][1] = rzad1[0];
                sciana4.pola_[1][1] = rzad1[1];
                sciana4.pola_[2][1] = rzad1[2];
            }
            else if (kolumna == 2)
            {
                string[] rzad1 = [sciana1.pola_[0][2], sciana1.pola_[1][2], sciana1.pola_[2][2]];
                string[] rzad2 = [sciana2.pola_[0][2], sciana2.pola_[1][2], sciana2.pola_[2][2]];
                string[] rzad3 = [sciana3.pola_[0][2], sciana3.pola_[1][2], sciana3.pola_[2][2]];
                string[] rzad4 = [sciana4.pola_[0][2], sciana4.pola_[1][2], sciana4.pola_[2][2]];
                sciana1.pola_[0][2] = rzad2[0];
                sciana1.pola_[1][2] = rzad2[1];
                sciana1.pola_[2][2] = rzad2[2];
                sciana2.pola_[0][2] = rzad3[0];
                sciana2.pola_[1][2] = rzad3[1];
                sciana2.pola_[2][2] = rzad3[2];
                sciana3.pola_[0][2] = rzad4[0];
                sciana3.pola_[1][2] = rzad4[1];
                sciana3.pola_[2][2] = rzad4[2];
                sciana4.pola_[0][2] = rzad1[0];
                sciana4.pola_[1][2] = rzad1[1];
                sciana4.pola_[2][2] = rzad1[2];
                var tempP1 = prawa.pola_[0][0];
                var tempP2 = prawa.pola_[0][1];
                var tempP3 = prawa.pola_[0][2];
                var tempP4 = prawa.pola_[1][0];
                var tempP6 = prawa.pola_[1][2];
                var tempP7 = prawa.pola_[2][0];
                var tempP8 = prawa.pola_[2][1];
                var tempP9 = prawa.pola_[2][2];
                prawa.pola_[0][0] = tempP7;
                prawa.pola_[0][1] = tempP4;
                prawa.pola_[0][2] = tempP1;
                prawa.pola_[1][0] = tempP8;
                prawa.pola_[1][2] = tempP2;
                prawa.pola_[2][0] = tempP9;
                prawa.pola_[2][1] = tempP6;
                prawa.pola_[2][2] = tempP3;
            }

        }*/
        private int pozUlozenia;
        public int pozUlozenia_
        {
            get => pozUlozenia;
            set { pozUlozenia = value; }
        }
        public Kostka()
        {
            UID = Guid.NewGuid().ToString();
            scianaB = new Sciana("b", "1");
            scianaZ = new Sciana("z", "2");
            scianaN = new Sciana("n", "3");
            scianaZI =new Sciana("zi", "4");
            scianaC = new Sciana("c", "5");
            scianaP = new Sciana("p", "6");
            listR = new List<string>();
        }

        public Kostka(Kostka source)
        {
            UID = Guid.NewGuid().ToString();
            scianaB = new Sciana(source.scianaB_);
            scianaZ = new Sciana(source.scianaZ_);
            scianaN = new Sciana(source.scianaN_);
            scianaZI =new Sciana(source.scianaZI_);
            scianaC = new Sciana(source.scianaC_);
            scianaP = new Sciana(source.scianaP_);
            listR = new List<string>(source.listR);
        }
    }
}
