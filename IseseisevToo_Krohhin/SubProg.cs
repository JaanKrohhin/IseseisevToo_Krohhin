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
            int size = rng.Next(2,8);
            int help;
            while (size%2!=0)
            {
                size = rng.Next(2, 8);
            }
            int[,] srebnum= new int[size+1,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    srebnum[i, j] = rng.Next(1,50);
                    Console.Write($"{ srebnum[i, j]} ");
                }
                Console.WriteLine("");
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    help = srebnum[i, j];
                    srebnum[i, j]=srebnum[i+1,j];
                    srebnum[i + 1, j] = help;
                    Console.Write($"{srebnum[i, j]} ");

                }
                Console.WriteLine("");
            }
        }
        public static void ul2(string a)
        {
            string[] sen = a.Split(" ");
            foreach (var item in sen)
            {
                if (item.ToLower()=="jaan")
                {
                    Console.WriteLine("Jaan krjutas seda");
                }
                else
                {
                    Console.WriteLine("Lausel pole sõnat 'jaan'");
                }
            }
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
                    Console.WriteLine("Kohta ei ole tühi");
                } 
                else
                {
                    cin[row, seat] = 1;
                    Console.WriteLine("Koht ostud");
                    truth = true;
                }
            } while (truth!=true);
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write($"{cin[i, j]} ");
                }
                Console.WriteLine("");
            }

        }
    }
}
