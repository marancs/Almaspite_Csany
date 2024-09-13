using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almáspite
{
    public class Program
    {
        public Program()//konstruktor
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Agazati2();
        }

        public void Tombok()
        {
            string[] t = new string[5];
            t[0] = "Hali";
            t[1] = "Almáspite";
            t[2] = "Jani";
            t[5] = "Utolsó";

            string[] maganh = new string[] { "a", "á", "e", "é","i","í" };

        }

        public void Lista()
        {
            List<string> l = new List<string>();
            l.Add("11. szoftverfejlesztők");
            l.Add("Álmos a csoport");
            l.Add("Ügyes a csoport");
            Console.WriteLine($"Elemszáma: {l.Count}");
        }

        public void Agazati2()
        {
            Console.WriteLine("2. feladat\nCica szépségverseny:");
            List<string> cicak = new List<string>();

            while (true)
            {
                Console.Write("Kérem a cica nevét: ");
                string nev = Console.ReadLine();
                if (String.IsNullOrEmpty(nev))
                    break;
                Console.Write($"Kérem a {nev} pontját: ");
                string pont = Console.ReadLine();
                cicak.Add($"{nev};{pont}");
            }
            Console.WriteLine("\nCicák lista kiiratása:");
            foreach(string cica in cicak)
            {
                Console.WriteLine(cica);
            }

        }

        public void Agazati()
        {
            Console.WriteLine("Ágazati 1. feladat: PIzza");
            double osszT = 0.0;
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"{i} átmérő: ");
                int a = Convert.ToInt32(Console.ReadLine());
                osszT += a / 2 * a / 2 * Math.PI;
            }
            Console.WriteLine($"Pizzák összterülete: {osszT}");
        }

        public void Elso()
        {
            Console.WriteLine("Ez az első metódusom");
            //1. feladat: Ciklusok
            //Számlálós ciklus: for
            for (int i = 1; i < 10; i++)
            {
                double pi = 3.14;
                double kor_kerulete = 2 * i * pi;
                Console.WriteLine(kor_kerulete);
            }
            Console.WriteLine("Páros számok: 1-20");
            for (int i = 2; i <= 20; i += 2)
                Console.Write($"{i} ");

            Console.WriteLine("");
            Console.WriteLine("Páratlan számok : 30 - 10");
            for (int i = 29; i >= 10; i -= 2)
                Console.Write($"{i} ");

            //foreach
            int[] t = new int[] { 2, 4, 5, 7, 8, 2, 34, 5, 6, 7, 8, 9 };
            int db = 0;
            foreach (int n in t)
            {
                if (n % 2 == 1)
                    db++;
            }
            Console.WriteLine($"\nA tömbben {db} db páratlan szám van.");

            //Elöltesztelős ciklus
            //while (feltétel) { }
            Console.WriteLine("Elöltesztelős ciklus:");
            int a = 1;
            while (a <= 20)
            {
                if (a % 2 == 0)
                    Console.Write($"{a} ");
                a++;
            }

            //Hátultesztelős ciklus
            //do
            //{

            //} while (feltétel);
            Console.WriteLine("\nHátultesztelős ciklus:");
            a = 1;
            do
            {
                if (a % 2 == 0)
                    Console.Write($"{a} ");
                a++;
            } while (a <= 20);
        }

        static void Main(string[] args)
        {
            new Program();
            Console.ReadKey();
        }
    }
}
