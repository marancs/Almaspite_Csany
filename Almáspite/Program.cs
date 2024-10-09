using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace Almáspite
{
    public class Program
    {
        //globális cicák lista
        List<string> cicak = new List<string>();
        Random random = new Random();
        int otvenFelett = 0;
        public Program()//konstruktor
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Gyakorlas2();
        }

        public void Osztas()
        {
            double n = 2;
            Console.WriteLine((n*10)%10);
        }

        public void Gyakorlas2()
        {
            //Kérj be egy számot (3 és 10 között) ez lesz a csoport létszám
            //Kérj be annyi diák nevét ahány a csoport létszám és mentsd le őket egy tömbbe.
            //Generálj le jegyeket (1-5, ahány diák van) és mentsd le őket egy másik tömbbe.
            //0. diak jegye a jegy tömb 0. eleme.
            //Feladatok:
            //Hány diák kapott 1-est és kik azok?
            //Mennyi lett a csoport átlag
            //Kérj be egy diák nevét és írd ki a jegyét, ha nem található ilyen diák, akkor azt is szépen
            //Kik azok a diákok akik az átlaghoz közeli jegyük van. 
            //pl.: Átlag: 3,5 azok a diákok kellenek akiknek 3-as és 4-es jegyük van

            Console.WriteLine("Csoport feladat!");
            int letszam=0;
            do
            {
                Console.Write("Kérem a csoport létszámát (3 - 10): ");
                letszam = Convert.ToInt32(Console.ReadLine());
            } while (letszam < 3 || letszam > 10);

            string[] diakok = new string[letszam];
            int[] jegyek = new int[letszam];

            Console.WriteLine("Kérem a diákok nevét és jegyét:");
            for (int i = 0; i < diakok.Length; i++)
            {
                Console.Write($"{(i+1)}. diák: ");
                diakok[i] = Console.ReadLine();

                Console.Write($"{diakok[i]} jegye: ");
                jegyek[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Feladatok:");
            Console.WriteLine("Diákok aki elégtelent kaptak:");
            int db_1 = 0;
            if (!jegyek.Contains(1))
                Console.WriteLine("Szerencsére senki se kapott elégtelent!");
            else
                for (int i = 0; i < letszam; i++)
                    if (jegyek[i] == 1)
                    {
                        db_1++;
                        Console.WriteLine(" - " + diakok[i]);
                    }
                Console.WriteLine($"Összesen: {db_1}db elégtelen lett!");

            Console.Write("Diákok átlaga:");
            double osszeg = 0;
            double atlag = 0;
            foreach (var jegy in jegyek)
                osszeg += jegy;

            atlag = Math.Round(osszeg / jegyek.Length,2);
            Console.WriteLine(atlag);
            Console.WriteLine("Diák lekérdezése....");
            Console.Write("Diák neve: ");
            string nev = Console.ReadLine();
            if (!diakok.Contains(nev))
            {
                Console.WriteLine("Sajnos nem találtam meg!");
            }
            else
            {
                for (int i = 0; i < diakok.Length; i++)
                {
                    if (diakok[i].Equals(nev))
                    {
                        Console.WriteLine($"Megtaláltam: {diakok[i]} - jegye: {jegyek[i]}");
                        break;
                    }
                }
            }
            //atlag: 2.0 -> 1 - 3
            //atlag: 3.4 -> 3 - 4
            int int_a = 0;
            int int_b = 0;

            if ((atlag * 10) % 10 > 0) {

                int_a = Convert.ToInt32(Math.Floor(atlag));
                int_b = int_a+1; 
            }
            else
            {
                int_a = Convert.ToInt32(atlag - 1);
                int_b = int_a+2;
            }
            Console.WriteLine("Diákok, akiknek a jegye átlag közelében van!");
            for (int i = 0; i < jegyek.Length; i++)
            {
                if (jegyek[i] >= int_a && jegyek[i]<= int_b)
                {
                    Console.WriteLine($" {diakok[i]} diák jegye: {jegyek[i]}.");
                }
            }

        }

        public void Gyakorlas()
        {
            //Kérj be neveket vesszővel elválasztva
            //Kérj be átlagokat szóközzel elválasztva
            //Addig kérd be az átlagokat, ameddig ugyan annyit nem ad meg, mint amennyi nevet megadott
            //Mi az átlag név hossz?
            //Mi az átlaga a megadott számoknak?

            Console.WriteLine("1. Feladat");
            string nevek = "";
            while (true) {
                Console.Write("Név: ");
                string nev = Console.ReadLine();
                if (String.IsNullOrEmpty(nev)) {
                    break;
                }
                nevek += nev+",";//Jani;Tamás;Feri;
            }
            nevek = nevek.Remove(nevek.Length - 1, 1);
            string[] nevekTomb = nevek.Split(',');

            double[] atlagTomb = new double[nevekTomb.Length];
            Console.WriteLine("Kérem szépen adja meg az átlagokat:");
            for (int i = 0; i < atlagTomb.Length; i++)
            {
                Console.Write("Átlag: ");
                atlagTomb[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Mi az átlag név hossz?");
            int[] atlagHossz = new int[nevekTomb.Length];
            for (int i = 0; i < atlagTomb.Length; i++)
                atlagHossz[i] = nevekTomb[i].Length;

            Console.WriteLine($"Átlag név hossz: {atlagHossz.Average()}");
            Console.WriteLine($"Megadott számok átlaga: {atlagTomb.Average()}");
            //Csinálj egy üres tömböt 50 szamot tudunk elmenteni
            //Töltsd fel ezt a tömböt 1-50ig
            //Mi a számok átlaga?
            int[] tomb = new int[50];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = random.Next(1, 50);
            }
            Console.WriteLine($"Számok átlaga: {tomb.Average()}");

            //Kérj be a felhasználótól egy számot
            //Nézd meg hogy benne van-e (igen/nem)
            Console.Write("\nKérek egy számot:");
            int szam = Convert.ToInt32(Console.ReadLine());
            if (tomb.Contains(szam))
            {
                Console.WriteLine("Benne van a tömbben!");
            }
            else
            {
                Console.WriteLine("Nincs a tömbben!!");
            }

        }

        public void Randizas()
        {
            Console.Write("Hány ember jelent meg a vakrandin: ");
            int resztvevok = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Hány hölgy jelent meg: ");
            int holgyek_db = Convert.ToInt32(Console.ReadLine());
            while (holgyek_db >= (resztvevok/2)+1)
            {
                Console.WriteLine("Túl sok hölgy jelent meg!");
                Console.WriteLine("Kérem újra a hölgyek számát!");
                holgyek_db = Convert.ToInt32(Console.ReadLine());                
            }
            string[] urak = new string[resztvevok - holgyek_db];
            string[] holgyek = new string[holgyek_db];

            Console.WriteLine("Kérem a hölgyek nevét!");
            for(int i=0;i<holgyek.Length; i++)
            {
                Console.Write("Hölgy: ");
                holgyek[i] = Console.ReadLine();
            }
            Console.WriteLine("Kérem az urak nevét!");
            for (int i = 0; i < urak.Length; i++)
            {
                Console.Write("Úr: ");
                urak[i] = Console.ReadLine();
            }
            Console.WriteLine("Indul a randi!");
            Random rand = new Random();
            string[] parok = new string[holgyek_db];
            int maximum;
            for(int h=0;h<holgyek_db;h++)
            {
                Console.WriteLine($" - {holgyek[h]}: Pontjai:");
                maximum = 0;
                foreach (string u in urak)
                {
                    int pont = rand.Next(1, 11);
                    Console.WriteLine($"{u} pontja: {pont}");
                    if (maximum< pont)
                    {
                        parok[h] = $"{holgyek[h]} - {u}";
                        maximum = pont;
                    }
                }
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Párok a hölgyek alapján!");
            foreach (var par in parok)
                Console.WriteLine(par);
            Console.WriteLine("---------------------");
            Console.WriteLine("Párok az urak alapján!");

            string[] urparok = new string[urak.Length];
            maximum = 0;
            for (int h = 0; h < urak.Length; h++)
            {
                Console.WriteLine($" - {urak[h]}: Pontjai:");
                maximum = 0;
                foreach (string ho in holgyek)
                {
                    int pont = rand.Next(1, 11);
                    Console.WriteLine($"{ho} pontja: {pont}");
                    if (maximum < pont)
                    {
                        urparok[h] = $"{urak[h]} - {ho}";
                        maximum = pont;
                    }
                }
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Párok az urak alapján!");
            foreach (var par in urparok)
                Console.WriteLine(par);

            Console.WriteLine("---------------------");
            Console.WriteLine("Tökéletes párok");
            string ur;
            string holgy;
            foreach(var hpar in parok)//hölgyek
            {
                holgy = hpar.Split('-')[0].Trim();
                ur = hpar.Split('-')[1].Trim();
                
                foreach (var upar in urparok)//urak
                {
                    if (upar.Equals($"{ur} - {holgy}"))
                    {
                        Console.WriteLine($"Tökéletes pár: {holgy} - {ur} ");
                        break;
                    }
                }
            }
            

        }

        public void HF2()
        {
            Console.WriteLine("Generálj kettő (a,b) 100 elemű int tömböt 1 és 10 000 közötti értékekkel!");
            Console.WriteLine("Írd ki tömbök metszetét!");
            Console.WriteLine("Írd ki azokat a számokat melyek az 'a' tömbben benne vannak de a 'b' -ben nincsennek!");

            int[] a = new int[100];
            int[] b = new int[100];
            
            for (int i = 0; i < a.Length; i++)
                a[i] = random.Next(1,10001);                
            

            for (int i = 0; i < b.Length; i++)
                b[i] = random.Next(1, 10001);

            Console.WriteLine("Tömbök metszete:");

            foreach (int item in a)            
                if (b.Contains(item))
                    Console.WriteLine(item);

            Console.Write("\nKérek egy számot");
            int szam = Convert.ToInt32(Console.ReadLine());
            int db_a = 0;
            int db_b = 0;

            foreach (var item in a)
                if (item == szam)
                    db_a++;

            foreach (var item in b)
                if (item == szam)
                    db_b++;

            if (db_a > 0)
                Console.WriteLine($"Az 'a' tömbben megtaláltam a számot: {db_a}db van belölle");
            else
                Console.WriteLine($"Az 'a' tömbben nem találtam meg a számot");

            if (db_b > 0)
                Console.WriteLine($"Az 'b' tömbben megtaláltam a számot: {db_b}db van belölle");
            else
                Console.WriteLine($"Az 'b' tömbben nem találtam meg a számot");


            Console.WriteLine("\n'a' tömbben benne vannak de a 'b'-ben nincsennek\n");
            foreach (var item in a)
                if (!b.Contains(item))
                {
                    Console.Write(item + ", ");
                }

        }
        public void Tombok()
        {
            string[] t = new string[5];
            t[0] = "Hali";
            t[1] = "Almáspite";
            t[2] = "Jani";
            t[4] = "Utolsó";

            string[] maganh = new string[] { "a", "á", "e", "é","i","í" };
            string[] szamok = new string[9];
            //szamok[0] = 2;
            //szamok[1] = 12;
            foreach(string szam in szamok)
                Console.WriteLine(szam);

        }

        public void Lista()
        {
            List<string> l = new List<string>();
            l.Add("11. szoftverfejlesztők");
            l.Add("Álmos a csoport");
            l.Add("Ügyes a csoport");
            Console.WriteLine($"Elemszáma: {l.Count}");
        }

        public string Helyezes(int helyezes)
        {
            List<int> pontok = new List<int>();
            string eredmeny = "";
            otvenFelett = 0;
            foreach (string s in cicak)
            {
                int pont = Convert.ToInt32(s.Split(';')[1]);
                if (pont > 50)
                    otvenFelett++;

                pontok.Add(pont);
            }
            pontok.Sort();
            pontok.Reverse();
            if (helyezes > 0 && helyezes <= cicak.Count())
            {
                int keresett_pont = pontok[helyezes - 1];
                foreach ( string s in cicak)
                {
                    int cica_pont = Convert.ToInt32(s.Split(';')[1]);
                    if (cica_pont == keresett_pont)
                    {
                        eredmeny = s;
                    }
                }                
            }
            return eredmeny;
        }

        public void Agazati2()
        {
            Console.WriteLine("2. feladat\nCica szépségverseny:");
           

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
            string sor = "";
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\n{i}. helyezett cica adatai:");
                sor = Helyezes(i);//sor="C;84"
                Console.WriteLine($"Cica: {sor.Split(';')[0]} elért pontja: {sor.Split(';')[1]}");
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine(otvenFelett);
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
