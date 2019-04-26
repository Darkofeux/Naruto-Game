using NARUTO____.Fight;
using NARUTO____.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace NARUTO____
{
    class Game
    {
        public void GameLaunch()
        {
            Joueur joueur1, joueur2 = null;
            Menu menu = new Menu();

            do
            {
                int choix = menu.ShowMenu();

                switch (choix)
                {
                    case 1:
                        (joueur1, joueur2) = menu.ChoixPersonnage();
                        new Combat(joueur1, joueur2).LaunchFight();
                        break;
                    case 2:
                        menu.AfficherRegles();
                        break;
                    case 3:
                        break;
                }
            }
            while (menu.ShowMenu() != 3);
        }
    }   
}
