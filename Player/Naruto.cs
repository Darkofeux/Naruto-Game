using NARUTO____.Buffs.Model;
using NARUTO____.Fight;
using NARUTO____.Model.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Player
{
    class Naruto : Joueur
    {
        Random random;
        int choix;
        int modeErmite = 0;
        public Naruto()
        {
            HP = 500;
            CH = 450;
            Attaque = 25;
            random = new Random();
            
            Buffs = new List<IBuff>();
        }
        public void AttaqueDeBase()
        {
            Console.WriteLine("Naruto attaque\n");
            if (modeErmite % 2 == 0)
            {
                Degats = 60;
            }
            else
            {
                Degats = 25;
            }                            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        public void KageBunshinNoJustsu()
        {
            Console.WriteLine("Naruto effectue un multiclonage\n");
            int valeur = random.Next(1, 4);      
            Console.WriteLine("Vous avez invoquez " + valeur + " clones\n");
        }
        public void Rasengan()
        {
            Console.WriteLine("Naruto créee un Rasengan !\n");            
            Degats = 50;
            CH = CH - 75;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;            
        }
        public void ModeErmite()
        {
            
            
            if (modeErmite % 2 == 0)
            {
                Console.WriteLine("Naruto est en mode ermite\n");
                CH = 0;
                Console.WriteLine("1 - Attaquer");
                Console.WriteLine("2 - Sortir du mode ermite");
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("Naruto attaque");
                        Degats = 65;
                        break;
                    case 2:
                        modeErmite++;
                        break;
                }
                choix = int.Parse(Console.ReadLine());                
            }
            if (modeErmite % 2 != 0)
            {
                Console.WriteLine("Naruto sort du mode ermite");
                modeErmite++;
            }                        
        }
        public void Rasenshuriken()
        {                             
            Degats = 150;
            CH = CH - 300;
            Console.WriteLine("Naruto créee un Rasenshuriken !\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;            
        }
        public void RechargedeChakra()
        {
            Degats = 0;
            if (modeErmite % 2 == 0)
            {
                CH = 0;
            }
            else
            {
                Console.WriteLine("Naruto recharge son chakra\n");
                CH += 450 - CH > 75 ? 75 : 450 - CH;
            }                        
        }
        public override Attack ChoixAttaque()
        {
            choix = 0;
            bool isValid; 
            
            do
            {
                isValid = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1- Attaque de base");
                Console.WriteLine("2- Kage bunshin no jutsu -30CH/clones");
                Console.WriteLine("3- Rasengan -75CH");
                Console.WriteLine("4- Mode ermite -70CH/tours");
                Console.WriteLine("5- Rasenshuriken -300CH");
                Console.WriteLine("6- Recharge de Chakra +75CH");
                Console.ForegroundColor = ConsoleColor.White;
                choix = int.Parse(Console.ReadLine());
               
                string reason = "";
                if (!IsValid(choix, out reason))
                {
                    Console.WriteLine(reason);
                    isValid = false;
                }
               
            } while (choix < 1 || choix > 6 || !isValid);
            return GetAttack(choix);
        }
        private bool IsValid(int choix, out string reason)
        {
            reason = "";
            switch (choix)
            {
                case 1:
                case 6:
                case 4:
                    return true;
                case 2:
                    reason = "Pas assez de CH";
                    return CH >= 90;
                case 3:
                    reason = "Pas assez de CH";
                    return CH >= 75;               
                case 5:
                    reason = "Pas assez de CH";
                    return CH >= 300;
            }
            reason = "entrez un numéro de 1 à 6";
            return false;
        }
        private Attack GetAttack(int attackNumber)
        {
            Degats = 0;
            switch (attackNumber)
            {
                case 1:
                    AttaqueDeBase();
                    break;
                case 2:
                    KageBunshinNoJustsu();
                    break;
                case 3:
                    Rasengan();
                    break;
                case 4:
                    ModeErmite();
                    break;
                case 5:
                    Rasenshuriken();
                    break;
                case 6:
                    RechargedeChakra();
                    break;
            }
            ApplyBuffs();

            return new Attack(Degats);
        }        
    }
}
