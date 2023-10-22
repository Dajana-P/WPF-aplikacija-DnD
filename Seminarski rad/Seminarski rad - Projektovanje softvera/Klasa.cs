using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarski_rad___Projektovanje_softvera
{
    public class Klasa
    {
        public string naziv;
        public string specialAttack;
        public string resurs;
        public int kolicina;

        public Klasa(string Naziv, string SpecialAttack, string Resurs, int Kolicina)
        {

            this.naziv = Naziv;
            this.specialAttack = SpecialAttack;
            this.resurs = Resurs;
            this.kolicina = Kolicina;
        }

        public void IskoristResurs()
        {
            kolicina--;
        }
    }
   
}
