using NARUTO____.Buffs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Fight
{
    public class MarqueMaudite : IBuff 
    {
        public decimal DamageMultiplier { get => 1M; }
        public decimal AttackMultiplier { get => 1.5M; }
        public int TourRestants { get => 2; }        
    }
}
