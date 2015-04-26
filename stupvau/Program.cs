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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Game jeu = new Game(3);
            jeu.GameLoop();
        }
    }
}
