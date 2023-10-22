using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarski_rad___Projektovanje_softvera
{
    public class Igrac
    {
        public int ID;
        public string ime;
        public string prezime;
        public int starost;
        public Klasa klasa;
        public string opis;
        public string pol;
        public string rasa;
        public string slika;

        public int STR;
        public int ATH;
        public int WIS;
        public int CHA;
        public int MaxHP;
        public int HP;
        public int defense;
        public List<Item> Items = new List<Item>();
        public Item EquipedWeapon;
        public Item EquipedArmor;
        public int money;
        

        public Igrac(int ID,string ime, string prezime, int starost,Klasa klasa, string opis,string slika, string pol,int STR,int ATH, int WIS,int CHA,int hp)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.starost = starost;
            this.klasa = klasa;
            this.opis = opis;
            this.pol = pol;
            this.slika = slika;
            this.STR = STR;
            this.ATH = ATH;
            this.WIS = WIS;
            this.CHA = CHA;
            this.MaxHP = hp;
            this.HP = MaxHP;
            this.defense = 10 + (int)Math.Ceiling((double)ATH/2);
            this.money = 100;
           
        }
    }
}
