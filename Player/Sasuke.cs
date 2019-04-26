using NARUTO____.Buffs.Model;
using NARUTO____.Fight;
using NARUTO____.Model.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____.Player
{
    class Sasuke : Joueur
    {
        public Sasuke()
        {
            HP = 450;
            CH = 500;
            Attaque = 35;
            Buffs = new List<IBuff>();
        }
        public void AttaqueDeBase()
        {
            Console.WriteLine("Sasuke attaque\n");
            Degats = 35;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void MarqueMaudite()
        {
            Console.WriteLine("Sasuke active sa marque maudite\n");
            CH = CH - 100;
            for (int i = 0; i <= 2; i++)
            {                
                   Degats = Degats + ((Degats * 150)/100);
            }
        }
        public void Katon()
        {
            Console.WriteLine("Sasuke effectue un Katon : Boule de feu suprème\n");
            Degats = 60;
            CH = CH - 90;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Susano()
        {
            Console.WriteLine("Sasuke invoque Susano !\n");           
        }
        public void Qílín()
        {
            Console.WriteLine("Sasuke utilise Qílín\n");
            Degats = 175;
            CH = CH - 350;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous infligez " + Degats + " HP\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void RechargedeChakra()
        { 
            Degats = 0;  
            Console.WriteLine("Sasuke recharge son chakra\n");
            CH += 500 - CH > 75 ? 75 : 500 - CH;
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
                Console.WriteLine("2- Marque maudite -100CH");
                Console.WriteLine("3- Katon: Boule de feu suprème -90CH");
                Console.WriteLine("4- Susano -75CH/tours");
                Console.WriteLine("5- Qílín -350CH");
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
                    return true;
                case 2:
                    reason = "Pas assez de CH";
                    return CH >= 90;
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
                    AttaqueDeBase();
                    break;
                case 2:
                    MarqueMaudite();
                    break;
                case 3:
                    Katon();
                    break;
                case 4:
                    Susano();
                    break; 
                case 5:
                    Qílín();
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
