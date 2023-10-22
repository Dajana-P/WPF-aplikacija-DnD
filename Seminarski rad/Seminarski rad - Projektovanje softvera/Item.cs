using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarski_rad___Projektovanje_softvera
{
    public class Item
    {
        public string naziv;
        public string tip;
        public int vrednost;
        public string opis;
        public int cena;
        public bool potrosnost;

        public Item(string naziv,string tip,int vrednost,string opis,int cena,bool potrosnost)
        {
            this.naziv = naziv;
            this.tip = tip;
            this.vrednost = vrednost;
            this.opis = opis;
            this.cena = cena;
            this.potrosnost = potrosnost;
        }
        
    }
}
