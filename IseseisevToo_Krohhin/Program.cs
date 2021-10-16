using System;

namespace IseseisevToo_Krohhin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mul oli 7. variant
            //Ü 1. Kahemõõtmelises massiivis korraldage kõrvuti asetsevad jooned paarikaupa, st. 1., 2., 3., 4. jne. Kuva tulemus ekraanil.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ülesanne 1 -------");
            SubProg.ul1();

            //Ü 2.Tehke kindlaks, kas stringina määratud tekstis on teatud sõna(ignoreerige suurtähtede erinevust).
            Console.WriteLine("\nÜlesanne 2 -------");
            Console.WriteLine("Kirjuta mulle lauset");//(sõna on 'jaan')
            Console.WriteLine(SubProg.ul2(Console.ReadLine()));

            //Ü 3.Kinopiletite ostmine.Ekraanile kuvatakse saali paigutus, mis on täidetud 0 ja 1(juhuslikult).Kasutaja määrab rea ja koha, kui see on vaba, siis kirjutatakse massiivi null asemel 1 ja saal kuvatakse uuesti ekraanil.
            Console.WriteLine("\nÜlesanne 3 -------");
            SubProg.ul3();
            Console.ReadLine();
        }
    }
}
