using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CA200122
{
    struct Stadion
    {
        public string Varos;
        public string Nev;
        public string AltNev;
        public int Ferohely;
    }
    class Program
    {
        static List<Stadion> stadionok;
        static int sum;
        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();
            F9();
            F10();
            Console.ReadKey();
        }

        private static void F10()
        {
            Console.WriteLine("\n10. feladat:");

            for (int i = 0; i < 3; i++)
                Console.WriteLine(
                    "\t{0,-25} {1:N0} EUR", 
                    stadionok[i].Nev,
                    stadionok[i].Ferohely * 120);
        }

        private static void F9()
        {
            Console.WriteLine("\n9. feladat:");
            Console.Write("Kérem egy város nevét: ");
            string v = Console.ReadLine().ToLower();
            List<Stadion> r = new List<Stadion>();
            foreach (var s in stadionok)
                if (v == s.Varos.ToLower()) r.Add(s);
            if(r.Count == 0)
                Console.WriteLine($"\t{v}-ban/ben nincs stadion");
            else
            {
                Console.WriteLine($"Stadionok {v}-ban/ben:");
                foreach (var s in r)
                    Console.WriteLine("\t{0,-23} {1} fő", s.Nev, s.Ferohely);
            }
        }

        private static void F8()
        {
            Console.WriteLine("\n8. feladat:");
            int db = 0;
            foreach (var s in stadionok)
                if (s.AltNev != "n.a.") db++;
            Console.WriteLine($"{db} stadionnak van alternatív neve.");
        }

        private static void F7()
        {
            Console.WriteLine("\n7. feladat:");
            int mini = 0;
            for (int i = 1; i < stadionok.Count; i++)
                if (stadionok[mini].Ferohely > stadionok[i].Ferohely) mini = i;
            Console.WriteLine("Legkisebb stadion adatai:");
            Console.WriteLine($"\tváros:          {stadionok[mini].Varos}");
            Console.WriteLine($"\tnév:            {stadionok[mini].Nev}");
            Console.WriteLine($"\talternatív név: {stadionok[mini].AltNev}");
            Console.WriteLine($"\tférőhely:       {stadionok[mini].Ferohely} fő");
        }

        private static void F6()
        {
            Console.WriteLine("\n6. feladat:");
            Console.WriteLine($"Átlagos befogadóképesség: {sum/(float)stadionok.Count} fő");
        }

        private static void F5()
        {
            Console.WriteLine("\n5. feladat:");
            sum = 0;
            foreach (var s in stadionok)
                sum += s.Ferohely;
            Console.WriteLine($"Az össz-befogadó képessége a stadionoknak: {sum} fő");
        }

        private static void F4()
        {
            Console.WriteLine("\n4. feladat:");
            int db = 0;
            foreach (var s in stadionok)
                if (s.Varos == "Moszkva") db++;
            Console.WriteLine($"Moszkvában {db} stadion van");
        }

        private static void F3()
        {
            Console.WriteLine("\n3. feladat:");
            Console.WriteLine($"stadionok száma: {stadionok.Count}");
        }

        private static void F2()
        {
            Console.WriteLine("2. feladat:");
            foreach (var s in stadionok)
            {
                Console.WriteLine("{0,-20}{1}", s.Varos, s.Nev);
            }
        }

        private static void F1()
        {
            stadionok = new List<Stadion>();
            var sr = new StreamReader(@"..\..\res\vb2018.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                var s = sr.ReadLine().Split(';');
                stadionok.Add(new Stadion()
                {
                    Varos = s[0],
                    Nev = s[1],
                    AltNev = s[2],
                    Ferohely = int.Parse(s[3]),
                });
            }
            sr.Close();
        }
    }
}
