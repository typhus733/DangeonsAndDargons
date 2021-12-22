using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDargons
{
    public class Character
    {
        public string Name { get; }
        public int HitChance { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Block { get; set; }
        public Weapon CurrentWeapon { get; set; }

        public Character(string name, int hit, int maxHealth, int block)
        {
            this.Name = name;
            this.HitChance = hit;
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.Block = block;
            this.CurrentWeapon = new Weapon("Stick", 1, 3, false, 0);

        }

        public int DamageCalc()
        {
            Random rand = new Random();
            return rand.Next(this.CurrentWeapon.MinDamage, this.CurrentWeapon.MaxDamage);
        }

        public int HitCalc()
        {
            Random rand = new Random();
            return (this.HitChance + this.CurrentWeapon.ToHitBonus + rand.Next(-5, 5));
        }

        public override string ToString()
        {
            string returnString = String.Format("Name: {0}\nCurrent Health: {1}\nMax Health: {4}\nBlock Value: {2}\nCurrent Weapon: {3}", this.Name, this.CurrentHealth, this.Block, this.CurrentWeapon, this.MaxHealth);
            return returnString;
        }

    }
}
