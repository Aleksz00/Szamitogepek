using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamitogepek
{
    internal class Szamitogepek
    {
        public int Azonosito { get; set; }
        public string Processzortipus { get; set;}
        public double Sebesseg { get; set; }
        public string Memoriameret { get; set; }
        public string Operaciosrendszer { get; set; }
        public string Gyartomodell { get; set; }
        public double Kijelzomeret { get; set; }
        public double memoria() =>double.Parse( Memoriameret.Split(" ").ToList()[0]);
        public string Gyarto() => Gyartomodell.Split(" ").ToList()[0];
        public double col() => Kijelzomeret * 2.54;
        public Szamitogepek(string s)
        {
            string[] a = s.Split("|");
            Azonosito = int.Parse(a[0]);
            Processzortipus = a[1];
            Sebesseg =double.Parse (a[2]);
            Memoriameret = a[3];
            Operaciosrendszer = a[4];
            Gyartomodell = a[5];
            Kijelzomeret =double.Parse(a[6]);

        }
        public override string ToString()
        {
            return $" Azonosito {Azonosito}, Processzortipus: {Processzortipus}, Sebbeseg: {Sebesseg}, Memoriameret: {Memoriameret}, Operaciosrendszer: {Operaciosrendszer}, Gyarto modell: {Gyartomodell}, Kijelzomeret: {Kijelzomeret}";
        }
    }
}
