using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarski_rad___Projektovanje_softvera
{
    public class Enemy
    {
        public int id;
        public string ime;
        public int MaxHp;
        public int HP;
        public int defense;
        public int damage;
        public int level;
        public string opis;
        public string pol;
        public string tip;
        public string slika;

        public Enemy(int id, string ime, int hp, int defense, int damage, int level, string opis, string pol,string tip,string slika)
        {
            this.id = id;
            this.ime = ime;
            this.MaxHp = hp;
            this.HP = hp;
            this.defense = defense;
            this.damage = damage;
            this.level = level;
            this.opis = opis;
            this.pol = pol;
            this.tip = tip;
            this.slika = slika;
        }
    }
}
