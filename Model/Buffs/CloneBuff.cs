using NARUTO____.Buffs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Model.Buffs
{
    public class CloneBuff : IBuff
    {
        public decimal AttackMultiplier { get => 1.5M; }
        public decimal DamageMultiplier { get => 1M; }
        public int TourRestants { get => 1; }
        
    }
}
