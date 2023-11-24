using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Szamitogepek
{
    internal class Program
    {
        static List<Szamitogepek> win(List<Szamitogepek> a)
        {
            var f7 = a.Where(x => x.Operaciosrendszer.Contains("Windows") && x.Kijelzomeret > 20).ToList();
            return f7;
        }
        static (List<Szamitogepek>,double) lassu(List<Szamitogepek> b)
        {
           var minimum= b.Min(x => x.Sebesseg);
            var f8 = b.Where(x => x.Sebesseg == minimum).ToList();
            return (f8,minimum);
        }
        static double atlag(List<Szamitogepek> c)
        {
            var f9 = c.Average(x => x.memoria());
            return f9;
        }
        static List<string> gyarto(List<Szamitogepek> d)
        {
            var f10 = d.Where(x => x.Memoriameret.Contains("DDR4")).ToList().OrderBy(x=>x.Gyarto()).Select(x=>x.Gyarto()).ToList().Distinct();
           
            return f10.ToList();
        }
        static List<Szamitogepek> monitor(List<Szamitogepek> e)
        {
            var f11 = e.Where(x => x.Processzortipus.Contains("Intel")&& x.Kijelzomeret < 20).ToList();
            return f11;
        }

        static void Main(string[] args)
        {
            var szamitogepek = new List<Szamitogepek>();
            using (var sr = new StreamReader(@"..\..\..\src\szamitogepek.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    szamitogepek.Add(new Szamitogepek(sr.ReadLine()));
#pragma warning restore CS8604 // Possible null reference argument.
                }
            }
            foreach (var item in szamitogepek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("7.feladat");
            foreach (var item in win(szamitogepek))
            {
                if (item==null)
                {
                    Console.WriteLine("Hiba");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"{win(szamitogepek).Count} db ilyen gép van");

            Console.WriteLine("8.feladat");
            (List<Szamitogepek> lassuszamito,double min) = lassu(szamitogepek);
            foreach (var item in lassuszamito )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{min} db");

            Console.WriteLine("9.feladat");
            Console.WriteLine(atlag(szamitogepek));


            Console.WriteLine("10.feladat");
            var lista = gyarto(szamitogepek);
            if (lista.Count==0)
            {
                Console.WriteLine("Hiba");
            }
            else
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("11.feladat");
            foreach (var item in monitor(szamitogepek))
            {
                Console.Write($"{item.Azonosito},");
            }

            Console.WriteLine("13.feladat");
            using (var sw = new StreamWriter(@"..\..\..\src\adatok.txt"))
            {
                foreach (var item in szamitogepek)
                {
                    sw.WriteLine($"{item.Gyartomodell} {item.col()} cm");
                }
            }
        }
    }
}