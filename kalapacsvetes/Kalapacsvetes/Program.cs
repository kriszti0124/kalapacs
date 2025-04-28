using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
   public class Sportolo
    {
        public string Helyezes { get; set; }
        public double Eredmeny { get; set; }
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public string Helyszin { get; set; }
        public string Datum { get; set; }

        public Sportolo(string sor) 
        {
            string[] reszek = sor.Split(';');
            Helyezes = reszek[0];
            Eredmeny = Convert.ToDouble(reszek[1]);
            Nev      = reszek[2];
            Orszag   = reszek[3];
            Helyszin = reszek[4];
            Datum    = reszek[5];

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Sportolo> lista = new List<Sportolo>();
            StreamReader sr = new StreamReader("kalapacsvetes.txt");
            string elsosor = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Sportolo sor = new Sportolo(sr.ReadLine());
                lista.Add(sor);
            }
            sr.Close();
            //4.feladat
            Console.WriteLine($"4.feladat: {lista.Count} dobás eredménye található.");
            

            //5.feladat
            double osszeg = 0;
            int magyarokszama = 0;
            foreach (var item in lista)
            {
                if (item.Orszag =="HUN")
                {
                    osszeg = osszeg + item.Eredmeny;
                    magyarokszama++;
                }
            }
            double atlag = osszeg / magyarokszama;
            Console.WriteLine($"5.feladat: A magyar sportolók átlagosan {atlag:.##} métert dobtak.");

            //6.feladat:
            Console.WriteLine("6.feladat: Adjon meg egy évszámot:");
            string ev = Console.ReadLine();
            int darab = 0;
            var sportolok = new List<String>();
            foreach (var item in lista)
            {
                if (item.Datum.Substring(0,4) == ev)
                {
                    darab++;
                    sportolok.Add(item.Nev);
                }
            }

            if (darab>0)
            {
                Console.WriteLine($"\t{darab} darab dobás került be ebben az évben.");
                foreach (var item in sportolok)
                {
                    Console.WriteLine($"\t{item}");
                }
            }
            else
            {
                Console.WriteLine("\tEgy dobás sem került be ebben az évben.");
            }

            //7. feladat
            Dictionary<string, int> statisztika = new Dictionary<string, int>();
            foreach (var item in lista)
            {
                if (statisztika.ContainsKey(item.Orszag))
                {
                    statisztika[item.Orszag]++;
                }
                else
                {
                    statisztika.Add(item.Orszag, 1);
                }
            }

            Console.WriteLine("7. feladat");
            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }

            //8. feladat
            StreamWriter sw = new StreamWriter("magyarok.txt");
            sw.WriteLine(elsosor);
            foreach (var item in lista)
            {
                if (item.Orszag == "HUN")
                {
                    sw.WriteLine($"{item.Helyezes};{item.Eredmeny};{ item.Nev};{item.Orszag};{ item.Helyszin};{item.Datum}");
                }
            }
            sw.Flush();
            sw.Close();


            Console.ReadKey();


        }
    }
}
