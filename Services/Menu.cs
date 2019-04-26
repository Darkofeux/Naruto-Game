using NARUTO____.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NARUTO____
{
    public class Menu 
    {
        public string personnageChoisis1;
        public string personnageChoisis2;
        int choixMenu;
        public Joueur joueur1 = null;
        public Joueur joueur2 = null;

        public int ShowMenu()
        {
            Console.WriteLine("\t\t\t Bienvenue dans Naruto Shippuden Ultimate Ninja Storm Deluxe Gold Edition !");
            Console.WriteLine("\n\t\t\t\t\t --------------------MENU--------------------");
            Console.WriteLine("\t\t\t\t-1 Jouer");
            Console.WriteLine("\t\t\t\t-2 Regles");
            Console.WriteLine("\t\t\t\t-3 Quitter");
            choixMenu = int.Parse(Console.ReadLine());
            return choixMenu;                                        
        }
        public void Quitter()
        {
            Console.WriteLine("Au revoir !");
            Console.ReadLine();
        }
        public void AfficherRegles()
        {
            Console.WriteLine("Le jeu se déroule sous la forme de combat au tour par tour en 1v1. Chaque tour chaque joueur effectue une action. Les   trois persoonages jouables possedent des HP et du CH qui sert a effectuer les actions.\n");
            Console.WriteLine("Descriptif des actions :\n");
            Console.WriteLine("Naruto : 500HP/ 450CH\n");
            Console.WriteLine("- Attaque de base : (-25HP/ -0CH) ");
            Console.WriteLine("- kage bunshin no jutsu : Créer entre 1 et 3 clones qui serviront seulement pour la prochaine attaque. Chaque clone a     50% de l'attaque de Naruto et chaque clone rends 40CH si utilisé pendant la Recharge de Chakra.");
            Console.WriteLine("- Rasengen : (-50HP/ -75CH) ");
            Console.WriteLine("- Mode ermite : (-70HP/tours) Tant que Mode Ermite est activé +25% de degats.");
            Console.WriteLine("- Rasenshuriken : (-150HP/ -300CH) Impossibilitée de jouer au prochain tour et de lance cette attaque avec des clones.");
            Console.WriteLine("- Recharge de chakra : (+75CH)\n");

            Console.WriteLine("Sasuke : 450HP/ 500CH\n");
            Console.WriteLine("- Attaque de base : (-40HP/ -0CH)");
            Console.WriteLine("- Marque maudite : (-100CH) Pendant deux tours +50% de degats. Impossibilitée de jouer pendant un tour a la fin des deux  tours.");
            Console.WriteLine("- Katon : (-60HP/ -90CH)");
            Console.WriteLine("- Susano : (-75CH/tours) Tant que Susano est activé reduit les degats subis de 25%.");
            Console.WriteLine("- Qílín (-175HP/ -350CH) Impossibilitée de jouer au tour suivant.");
            Console.WriteLine("- Recharge de chakra : (+75CH)\n");

            Console.WriteLine("Sakura : 500HP/ 375CH\n");
            Console.WriteLine("- Attaque de base (-30HP/ -0CH)");
            Console.WriteLine("- Controle de Chakra(Nécessite au minimum 300 CH mais n'en comsomme pas) La prochaine action sera boosté. Si c'est une    attaque elle ne consome pas de chakra. Si c'est une Recharge de Chakra +50%.");
            Console.WriteLine("- Ōkashō (-50HP/-50CH)");
            Console.WriteLine("- Byakugō no Jutsu(-375CH) Rends tous ses HP.Impossibilitée de jouer au tour suivant.");
            Console.WriteLine("- Tsūten kyaku(-100HP/-200CH) Impossibilitée de jouer au tour suivant.");
            Console.WriteLine("- Recharge de Chakra (+50HP/+50CH)\n");
        }
        internal (Joueur joueur1, Joueur joueur2) ChoixPersonnage()
        {            
            do
            {
                Console.WriteLine("\t\t\t\t ATTENTION ! interdis de prendre deux fois le même personnage !");
                Console.WriteLine("\n\t\t\t\t\t Veuillez selectionner un personnage joueur 1 \n\n-Naruto \n-Sasuke \n-Sakura");
                personnageChoisis1 = Console.ReadLine();
                while (personnageChoisis1 != "Naruto" && personnageChoisis1 != "Sasuke" && personnageChoisis1 != "Sakura")
                {
                    Console.WriteLine("Personnages inexistant veuillez recomencer");
                    Console.WriteLine("\t\t\t\t\tVeuillez selectionner un personnage joueur 1 \n\n-Naruto \n-Sasuke \n-Sakura");
                    personnageChoisis1 = Console.ReadLine();
                }
                Console.WriteLine("\t\t\t\t\tVeuillez selectionner un personnage joueur 2 \n\n-Naruto \n-Sasuke \n-Sakura");
                personnageChoisis2 = Console.ReadLine();
                while (personnageChoisis2 != "Naruto" && personnageChoisis2 != "Sasuke" && personnageChoisis2 != "Sakura")
                {
                    Console.WriteLine("Personnages inexistant veuillez recomencer");
                    Console.WriteLine("\t\t\t\t\tVeuillez selectionner un personnage joueur 2 \n\n-Naruto \n-Sasuke \n-Sakura");
                    personnageChoisis2 = Console.ReadLine();
                }                
            }
            while (personnageChoisis1 == personnageChoisis2);
            Console.WriteLine("Parfait le combat va pouvoir commencer !");
            Console.ReadLine();
            switch (personnageChoisis1)
            {
                case "Naruto":
                    joueur1 = new Naruto();
                    break;
                case "Sakura":
                    joueur1 = new Sakura();
                    break;
                case "Sasuke":
                    joueur1 = new Sasuke();
                    break;
            }
            switch (personnageChoisis2)
            {
                case "Naruto":
                    joueur2 = new Naruto();
                    break;
                case "Sakura":
                    joueur2 = new Sakura();
                    break;
                case "Sasuke":
                    joueur2 = new Sasuke();
                    break;                    
            }
            return (joueur1, joueur2);
        }                                
    }
}

