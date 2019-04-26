using NARUTO____.Buffs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Model.Buffs
{
    public class Susano : IBuff
    {
        public decimal DamageMultiplier { get => 0.75M; }
        public decimal AttackMultiplier { get => 1; }
        public int TourRestants { get => 2; }
        
    }
}
