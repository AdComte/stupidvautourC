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
            int pl0=0, pl1=0, pl2=0, pl3=0;
            int tour = 0;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            for (int i = 0; i < 1; i++)//Cette boucle fait tourner15 jeux et enregistre quel joueur gagne
            {                           // dans le but de comparer les IAs
                Game jeu = new Game(2);
                tour = jeu.GameLoop();
                if(tour==0)
                {
                    pl0++;
                }
                else if (tour == 1) { pl1++; } else if (tour == 2) { pl2++; }
                else if (tour == 3) { pl3++; }
            }
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("*************************************************");
            Console.WriteLine("*************************************");
            Console.WriteLine("Le joueur 0 a gagné " + pl0 + " fois sur 15");
            Console.WriteLine("Le joueur 1 a gagné " + pl1 + " fois sur 15");
            //Console.WriteLine("Le joueur 2 a gagné " + pl2 + " fois sur 15");
            //Console.WriteLine("Le joueur 3 a gagné " + pl3 + " fois sur 15");
            Console.WriteLine("*************************************");
            Console.WriteLine("*************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("**********************************************************************");
        }
    }
}
