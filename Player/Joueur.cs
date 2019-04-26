using NARUTO____.Buffs.Model;
using NARUTO____.Fight;
using NARUTO____.Model.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Player
{
    public abstract class Joueur 
    {
        public int HP { get; set; }
        public int CH { get; set; }
        public int Degats { get; set; }
        public int DegatsSubis { get; set; }
        public int Attaque { get; set; }    
        public int TourRestants { get => 1; }
    public List<IBuff> Buffs { get; set; }
      
        public bool IsAlive()
        {
            return HP > 0;
        }
        public abstract Attack ChoixAttaque();
        protected void ApplyBuffs()
        {
            foreach (IBuff buff in Buffs)
            {
                Degats *= (int)Math.Floor(buff.AttackMultiplier);
                
            }
        }

        internal void CalculateHP(Attack actionJoueur1)
        {
            int degatSubit = actionJoueur1.Damage;
            if (actionJoueur1.Buff != null)
            {
                Buffs.Add(actionJoueur1.Buff);
            }
            foreach (IBuff buff in Buffs)
            {
                degatSubit *= (int)Math.Floor(buff.DamageMultiplier);
            }

            HP -= degatSubit;
        }
    }
}
