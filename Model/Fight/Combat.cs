using NARUTO____.Model.Fight;
using NARUTO____.Player;
using System;

namespace NARUTO____.Fight
{
    public class Combat 
    {
        public int tour = 1;
        public Joueur Joueur1 {get;set;}
        public Joueur Joueur2 {get;set;}

        public Combat(Joueur joueur1, Joueur joueur2)
        {
            this.Joueur1 = joueur1;
            this.Joueur2 = joueur2; 
        }         
        internal void LaunchFight()
        {
            while(Joueur1.IsAlive() && Joueur2.IsAlive())
            {                
                Console.WriteLine("Début du tour numéro :" + tour + "");
                Console.WriteLine("Vous avez "+Joueur1.HP+ "HP et " +Joueur1.CH+ " CH joueur 1\n");
                Console.WriteLine("Choisissez votre action\n");
                Attack actionJoueur1 = Joueur1.ChoixAttaque();
                Joueur2.CalculateHP(actionJoueur1);

                Console.WriteLine("Vous avez " +Joueur2.HP+ "HP et " +Joueur2.CH+ " CH joueur 2\n");
                Console.WriteLine("Choisissez votre action\n");
                Attack actionJoueur2 = Joueur2.ChoixAttaque();
                Joueur1.CalculateHP(actionJoueur2);
                Joueur2.Degats = 0;
                tour++;                
            }
            if (Joueur1.HP <= 0 && Joueur2.HP <= 0)
            {
                Console.WriteLine("Egalité, le match a duré " + tour + " tours");
            }
            else if (Joueur1.HP <= 0)
            {
                Console.WriteLine("Bravo joueur 2 vous avez gagnés en " +tour+ " tours");
            }
            else if (Joueur2.HP <= 0)
            {
                Console.WriteLine("Bravo joueur 1 vous avez gagnés en "+tour+ " tours");
            }
        }
    }
}
