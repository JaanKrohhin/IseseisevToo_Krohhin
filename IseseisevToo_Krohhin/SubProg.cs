using System;
using System.Collections.Generic;
using System.Text;

namespace IseseisevToo_Krohhin
{
    class SubProg
    {
        static Random rng = new Random();
        
        public static void ul1()
        {
            int size = 1;
            while (size%2!=0)
            {
                size = rng.Next(2, 8);
            }
            int[,] srebnum = new int[size,size];
            int[] help = new int [size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    srebnum[i, j] = rng.Next(1,50);
                    Console.Write($"{ srebnum[i, j]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Muudatud ------");
            for (int i = 0; i < size; i += 2)
            {
                    if (i + 1 == size)
                        break;

                    for (int j = 0; j < size; j++)
                    {
                        var a = srebnum[i, j];
                        srebnum[i, j] = srebnum[i + 1, j];
                        srebnum[i + 1, j] = a;
                    }

            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{ srebnum[i, j]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();

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
            int[,] cin = new int[10,30];
            bool truth = false;
            int row=0;
            int seat = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    cin[i, j] = rng.Next(0, 2);
                    Console.Write($"{cin[i,j]} ");
                }
                Console.WriteLine("");
            }
            do
            {
                while (truth!=true)
                {
                    Console.WriteLine("Mis rida sa tahad 1-10");
                    try
                    {
                        row = int.Parse(Console.ReadLine()) - 1;
                        if (row<10 && row>-1)
                        {
                            truth = true;
                        }

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Kirjuta numbrit");
                    }
                }
                truth = false;
                while (truth != true)
                {
                    Console.WriteLine("Mis kohta sa tahad? 1-30");
                    try
                    {
                        seat = int.Parse(Console.ReadLine()) - 1;
                        if (seat < 30 && seat > -1)
                        {
                            truth = true;
                        }

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Kirjuta numbrit");
                    }
                }
                truth = false;
            
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
            } while (truth!=true);
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i==row && j==seat)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write($"{cin[i, j]} ");
                }
                Console.WriteLine("");
            }

        }
    }
}
