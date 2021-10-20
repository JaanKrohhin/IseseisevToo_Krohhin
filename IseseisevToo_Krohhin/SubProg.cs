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
            for (int i = 0; i < cin.GetLength(0); i++)
            {
                Console.Write($"{i+1}. rida ");
                for (int j = 0; j < cin.GetLength(1); j++)
                {
                    Console.Write($"{cin[i, j]} ");
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
            int row = 0;
            bool truth = false;
            int seat = 0;
            do
            {
                Console.WriteLine("Vali oma saali: 1 - väike, 2 - keskmine, 3 - suur");
                try
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
            int[,] cin = new int[row, seat];
            array_fill(cin, 0, 2);
            array_to_con(cin);
            do
            {
                row = check(row, row, "Mis rida sa tahad? 1-" + row.ToString());
                seat = check(seat, seat, "Mis kohta sa tahad? 1-" + seat.ToString());
                if (cin[row, seat] == 1)
                {
                    Console.WriteLine("Kohta on juba ostud");
                }
                else
                {
                    cin[row, seat] = 1;
                    Console.WriteLine("Äitah ostu eest");
                    truth = true;
                }
            }
            while (!true);
            for (int i = 0; i < cin.GetLength(0); i++)
            {
                for (int j = 0; j < cin.GetLength(1); j++)
                {
                    if (i == row && j == seat)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write($"{cin[i, j]} ");
                }
                Console.WriteLine();
            }

            
            static int check(int a, int rangi, string senten)
            {
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
        }       

    }
}
