using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDargons
{
    public class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public bool IsTwoHanded { get; }
        public int ToHitBonus { get; set; }

        public Weapon(string name, int min, int max, bool twoHander, int toHit)
        {
            this.Name = name;
            this.MinDamage = min;
            this.MaxDamage = max;
            this.IsTwoHanded = twoHander;
            this.ToHitBonus = toHit;
        }

        public override string ToString()
        {
            string returnString = String.Format("{0} - ({1} - {2}) + {3}", this.Name, this.MinDamage, this.MaxDamage, this.ToHitBonus);
            return returnString;
        }
    }
}
