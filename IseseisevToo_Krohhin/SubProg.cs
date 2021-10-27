using System;
using System.Collections.Generic;
using System.Text;

namespace IseseisevToo_Krohhin
{
    class SubProg
    {
        static Random rng = new Random();

        static void array_to_con(int[,] cin)
        {
            Console.Write("         ");
            for (int i = 1; i < cin.GetLength(1)+1; i++)
            {
                if (i.ToString().Length==2)
                {
                    Console.Write($"{i} ");
                }
                else
                {
                    Console.Write($"{i}  ");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < cin.GetLength(0); i++)
            {
                Console.Write($"{i+1}. rida  ");
                for (int j = 0; j < cin.GetLength(1); j++)
                {
                    Console.Write($"{cin[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        static void array_fill(int[,] cin, int a, int b)
        {
            for (int i = 0; i < cin.GetLength(0); i++)
            {
                for (int j = 0; j < cin.GetLength(1); j++)
                {
                    cin[i, j] = rng.Next(a, b);
                }
            }
        }

        public static void ul1()
        {
            int size = 1;
            while (size%2!=0)
            {
                size = rng.Next(2, 8);
            }
            int[,] srebnum = new int[size,size];
            int help;
            array_fill(srebnum,1,50);            
            array_to_con(srebnum);
            Console.WriteLine("Muudatud ------");
            for (int i = 0; i < size; i += 2)
            {
                    if (i + 1 == size)
                        break;

                    for (int j = 0; j < size; j++)
                    {
                        help = srebnum[i, j];
                        srebnum[i, j] = srebnum[i + 1, j];
                        srebnum[i + 1, j] = help;
                    }
            }
            array_to_con(srebnum);
        }
        public static string ul2(string a)
        {
            string[] sen = a.Split(" ");
            foreach (var item in sen)
            {
                if (item.ToLower()=="jaan")
                {
                    return "Jaan krjutas seda";
                }
            }
            return "Sellel lausel pole sõnat 'jaan'";
        }
        public static void ul3()
        {
            int seat = 0;//kino kohad
            int row = 0;//kino read
            bool truth = false;//abimuutuja, aitab meile minna kordusest välja
            do//valime kinosaali suurus
            {
                Console.WriteLine("Vali oma saali: 1 - väike, 2 - keskmine, 3 - suur");
                try//kontrollime,mida inimene kirjutab 
                {
                    row = int.Parse(Console.ReadLine());
                    if (row == 1)
                    {
                        row = 5;
                        seat = 15;
                        truth = !truth;
                    }
                    else if (row == 2)
                    {
                        row = 10;
                        seat = 20;
                        truth = !truth;
                    }
                    else if (row == 3)
                    {
                        row = 15;
                        seat = 25;
                        truth = !truth;
                    }
                    else
                    {
                        Console.WriteLine("Kirjuta õiget numbrit");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Kirjuta numbrit");
                }
            } while (!truth);
            int[,] cin = new int[row, seat];//teeme kahemõõtlemis massivi, mis on meie kinosaal
            array_fill(cin, 0, 2);//anname 
            array_to_con(cin);//kirjutame massivi ekraanile
            int amount=-1;
            while (true)
            {
 
                Console.WriteLine("Kas tahad ise valida kohta või me valime? 1 - Ise, 2 - Me valime");
                try
                {
                    amount = int.Parse(Console.ReadLine());
                    if (amount < 3 && amount > 0)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Kirjuta õiget numbrit");
                }
            }
            if (amount==1)//valime, kas inimene valib kohta või meie programm
            {
                int sold = 0;
                amount = check(seat, "Mitu piletid sa tahad?");
                bool sell = true;
                while (sell)
                {
                    for (int i = 0; i < (seat-1)*(row-1); i++)
                    {
                        sell = selfService(cin, row, seat);
                        if (sell){sold++;}
                        if (sold == amount){ break;}
                    }
                }
            }
            else
            {
                bot(cin,row,seat);//valime kohad inimesele
            }
            Console.WriteLine();
            array_to_con(cin);//kirjutame massivi ekraanile
            static void bot(int[,] cin, int row, int seat)//kinosaali massiv, meie valitud rida, kohtade kogus 
            {
                //küsime kui palju kohti inimene tahab
                int tickets = check(seat, "Mitu koha sa tahad?");//check() kontrollib mida kirjutab inimene, et see ei oli täht 
                //teeme uus massivi et salvestada kohti
                int[] soldSeats = new int[tickets];
                //p on meie algus punkt, et leida kohti 
                int p = (seat - tickets) / 2;
                //t utleb meile kas oli reas vabad kohad
                bool t = false;
                //k on massivi index 
                int k = 0;
                do
                {
                    //leidame, kas koht on tühi
                    if (cin[row, p] == 0)
                    {
                        //paneme et koht ei ole tühi 
                        cin[row, p] = 1;
                        //paneme selle kohta massivile 
                        soldSeats[k] = p;
                        //kirjutame et koht on vaba
                        Console.WriteLine($"koht {p} on vaba");
                        //reas oli vabad kohad
                        t = true;
                    }
                    else
                    {
                        // kirjutame et koht on kinni
                        Console.WriteLine($"koht {p} kinni");
                        //reas ei olnud vabad kohad
                        t = false;
                        //teeme selle massivi uuesti, et ta oli tühi
                        soldSeats = new int[tickets];
                        //teeme selle muutuvale reset
                        k = 0;
                        //teeme selle muutuvale reset
                        p = (seat - tickets) / 2;
                        //lahme kordusest valja
                        break;
                    }
                    //teeme p=p+1
                    p++;
                    //teeme k=k+1
                    k++;
                } while (tickets != k);
                //kui meil oli kohad selles reas, kirjutame need ekraanile
                if (t == true)
                {
                    Console.WriteLine("Sinu kohad on:");
                    //teeme foreach korduse et kirjutada koik kohad ekraanile
                    foreach (var koh in soldSeats)
                    {
                        //kui element massivil on 0 siis me seda ei kirjuta
                        if (koh!=0)
                        {
                            Console.Write($"{koh}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");
                }
            }
            static int check(int rangi, string senten)
            {
                int a;
                while (true)
                {
                    Console.WriteLine(senten);
                    try
                    {
                        a = int.Parse(Console.ReadLine()) - 1;
                        if (a < rangi && a > rangi - rangi - 1)
                        {
                            return a;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Kirjuta numbrit");
                    }
                }
            }
            static bool selfService(int[,] cin,int row,int seat)
            {
                do
                {
                    row = check(row, "Mis rida sa tahad");
                    seat = check(seat, "Mis kohta sa tahad");
                    if (cin[row, seat] == 0)
                    {
                        cin[row, seat] = 1;
                        return true;
                    }
                    return false;

                } while (true);

                //static void Muuk()
                //{
                //    Console.WriteLine("Rida:");
                //    int pileti_rida = int.Parse(Console.ReadLine());
                //    Console.WriteLine("Mitu piletid:");
                //    mitu = int.Parse(Console.ReadLine());
                //    ost = new int[mitu];
                //    int p = (kohad - mitu) / 2;
                //    bool t = false;
                //    int k = 0;
                //    do
                //    {
                //        if (saal[pileti_rida, p] == 0)
                //        {
                //            ost[k] = p;
                //            Console.WriteLine("koht {0} on vaba", p);
                //            t = true;
                //        }
                //        else
                //        {
                //            Console.WriteLine("koht {0} kinni", p);
                //            t = false;
                //            ost = new int[mitu];
                //            k = 0;
                //            p = (kohad - mitu) / 2;
                //            break;
                //        }
                //        p = p + 1;
                //        k++;
                //    } while (mitu != k);
                //    if (t == true)
                //    {
                //        Console.WriteLine("Sinu kohad on:");
                //        foreach (var koh in ost)
                //        {
                //            Console.WriteLine("{0}\n", koh);
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");
                //    }
                //}

                //static void bot(int[,] cin, int row, int seat)
                //{
                //    //küsime kui palju kohti inimene tahab
                //    int tickets = check(seat, "Mitu koha sa tahad?");
                //    //teeme uus massivi et salvestada kohti
                //    int[] soldSeats = new int[tickets];
                //    //p on meie algus punkt, et leida kohti 
                //    int p = (seat - tickets) / 2;
                //    //t utleb meile kas oli reas vabad kohad
                //    bool t = false;
                //    //k on massivi index 
                //    int k = 0;
                //    do
                //    {
                //        //leidame, kas koht on tühi
                //        if (cin[row, p] == 0)
                //        {
                //            //paneme et koht ei ole tühi 
                //            cin[row, p] = 1;
                //            //paneme selle kohta massivile 
                //            soldSeats[k] = p;
                //            //kirjutame et koht on vaba
                //            Console.WriteLine($"koht {p} on vaba");
                //            //reas oli vabad kohad
                //            t = true;
                //        }
                //        else
                //        {
                //            // kirjutame et koht on kinni
                //            Console.WriteLine($"koht {p} kinni");
                //            //reas ei olnud vabad kohad
                //            t = false;
                //            //teeme selle massivi uuesti, et ta oli tühi
                //            soldSeats = new int[tickets];
                //            //teeme selle muutuvale reset
                //            k = 0;
                //            //teeme selle muutuvale reset
                //            p = (seat - tickets) / 2;
                //            lahme kordusest valja
                //            break;
                //        }
                //        //teeme p=p+1
                //        p++;
                //        //teeme k=k+1
                //        k++;
                //    } while (tickets != k);
                //    //kui meil oli kohad selles reas, kirjutame need ekraanile
                //    if (t == true)
                //    {
                //        Console.WriteLine("Sinu kohad on:");
                //        //teeme foreach korduse et kirjutada koik kohad ekraanile
                //        foreach (var koh in soldSeats)
                //        {
                //            //kui element massivil on 0 siis me seda ei kirjuta
                //            if (koh != 0)
                //            {
                //                Console.Write($"{koh}");
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");
                //    }
                //}


            }
            //while (!true);
            //for (int i = 0; i < cin.GetLength(0); i++)
            //{
            //    for (int j = 0; j < cin.GetLength(1); j++)
            //    {
            //        if (i == row && j == seat)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Green;
            //        }
            //        Console.Write($"{cin[i, j]} ");
            //    }
            //    Console.WriteLine();
        }


    }
}
