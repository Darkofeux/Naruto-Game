using NARUTO____.Buffs.Model;
using NARUTO____.Fight;
using NARUTO____.Model.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Player
{
    class Sakura : Joueur
    {
        private bool controleDeChakra;
        public Sakura()
        {
            HP = 500;
            CH = 375;
            Attaque = 30;
            Buffs = new List<IBuff>();            
        }
        public void AttaquedeBase()
        {
            Console.WriteLine("Sakura attaque\n");
            Degats = 30;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ControledeChakra()
        {            
            controleDeChakra = true;           
            Console.WriteLine("Sakura se concentre\n"); 
        }
        public void Ōkashō()
        {
            Console.WriteLine("Sakura effectue un Ōkashō\n"); 
            Degats = 50;
            CH = CH - 50;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ByakugōnoJutsu()
        {
            Console.WriteLine("Sakura se soigne completement\n");
            HP = 500;
            CH -= 375;
        }
        public void Tsūtenkyaku()
        {
            Console.WriteLine("Sakura frappe le sol de toute ses forces !\n");
            Degats = 100;
            CH = CH - 200;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void RechargedeChakra()
        {
            Degats = 0;
            Console.WriteLine("Sakura recharge son chakra et se soigne\n");
            HP += 500 - HP > 50 ? 50 : 500 - HP;
            CH += 375 - CH > 50 ? 50 : 375 - CH;
        }
        public override Attack ChoixAttaque()
        {
            int choix = 0;
            bool isValid;
            do
            {
                isValid = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1- Attaque de base");
                Console.WriteLine("2- Controle de Chakra");
                Console.WriteLine("3- Ōkashō -50CH");
                Console.WriteLine("4- Byakugō no Jutsu -375CH");
                Console.WriteLine("5- Tsūten kyaku -200CH");
                Console.WriteLine("6- Recharge de Chakra +50HP +50CH");
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
                    return true;
                case 2:
                    reason = "Pas assez de CH";
                    return CH >= 300;
                case 3:
                    reason = "Pas assez de CH";
                    return CH >= 75;
                case 4:
                    reason = "Pas assez de CH";
                    return CH >= 70;
                case 5:
                    reason = "Pas assez de CH";
                    return CH >= 300;
            }
            reason = "entrez un numéro de 1 à 6";
            return false;
        }
        private Attack GetAttack(int attackNumber)
        {
            switch (attackNumber)
            {
                case 1:
                    AttaquedeBase();
                    break;
                case 2:
                    ControledeChakra();
                    break;                    
                case 3:
                    Ōkashō();
                    break;
                case 4:
                    ByakugōnoJutsu();
                    break;
                case 5:
                    Tsūtenkyaku();
                    break;
                case 6:
                    RechargedeChakra();
                    break;
            }
            controleDeChakra = false;

            ApplyBuffs();

            return new Attack(Degats);
        }
    }
}
