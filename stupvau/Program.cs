using stupvau.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace stupvau
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Menu menu = new Menu();
            Application.EnableVisualStyles();
            Application.Run(menu);
			if (menu.ready == false) return;
            //A ce stade, on dispose de tout les paramètres pour lancer la partie dans la configuration souhaitee

			Display table = new Display(menu.nbia + 1, menu.iaplayers);
			Application.Run(table);
		}

//
//
        //static void main_debug()
        //{
        //    IAPlayer iap = new IAPlayer(0);
        //    IAMedium iam = new IAMedium(1);
        //    IList<Player> liste = new List<Player> ();
        //    liste.Add(iap);liste.Add(iam);
        //    Table table = new Table(liste);
        //}
//
        //static void Main22()
        //{
		//
        //    int pl0 = 0, pl1 = 0, pl2 = 0, pl3 = 0;
        //    int tour = 0;
        //    for (int i = 0; i < 25; i++)//Cette boucle fait tourner15 jeux et enregistre quel joueur gagne
        //    {                           // dans le but de comparer les IAs
        //        Game jeu = new Game(3);
        //        tour = jeu.GameLoop();
        //        if (tour == 0)
        //        {
        //            pl0++;
        //        }
        //        else if (tour == 1) { pl1++; }
        //        else if (tour == 2) { pl2++; }
        //        else if (tour == 3) { pl3++; }
        //    }
        //    Console.WriteLine("**********************************************************************");
        //    Console.WriteLine("************************************************************");
        //    Console.WriteLine("*************************************************");
        //    Console.WriteLine("*************************************");
        //    Console.WriteLine("Le joueur 0 a gagné " + pl0 + " fois sur 25");
        //    Console.WriteLine("Le joueur 1 a gagné " + pl1 + " fois sur 25");
        //    Console.WriteLine("Le joueur 2 a gagné " + pl2 + " fois sur 25");
        //    //Console.WriteLine("Le joueur 3 a gagné " + pl3 + " fois sur 15");
        //    Console.WriteLine("*************************************");
        //    Console.WriteLine("*************************************************");
        //    Console.WriteLine("************************************************************");
        //    Console.WriteLine("**********************************************************************");
        //}
    }
}
