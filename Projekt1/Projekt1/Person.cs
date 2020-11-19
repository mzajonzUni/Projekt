﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUO
{
    public class Person
    {
        public int Numer { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Pozycja { get; set; }
        public int Wzrost { get; set; }
        public string Poczatek { get; set; }
        public string Koniec { get; set; }


        public Person(int nNumer, string sImie, string sNazwisko, int nWiek, string sPozycja, int nWzrost, string sPoczatek, string sKoniec)
        {
            Numer = nNumer;
            Imie = sImie;
            Nazwisko = sNazwisko;
            Wiek = nWiek;
            Pozycja = sPozycja;
            Wzrost = nWzrost;
            Poczatek = sPoczatek;
            Koniec = sKoniec;
        }
        public Person()
        {

        }
    }
}
