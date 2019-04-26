using NARUTO____.Buffs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Model.Fight
{
    public class Attack
    {
       public int Damage { get; set; }
       public IBuff Buff { get; set; }
       
        public Attack(int damage)
        {
            this.Damage = damage;
        }
        public Attack(int damage, IBuff buff) : this(damage)
        {
            this.Buff = buff;
        }
    }
}
