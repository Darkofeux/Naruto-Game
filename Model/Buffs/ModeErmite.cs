using NARUTO____.Buffs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Model.Buffs
{
    public class ModeErmite : IBuff  
    {
        public decimal DamageMultiplier { get => 1.0M; }
        public decimal AttackMultiplier { get => 1.25M; }
        public int TourRestants { get => -1; }
    }
}
