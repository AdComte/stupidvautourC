using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class PlayerCard : Card
    {

        private int couleur;

        public PlayerCard(int number, bool notPlayed, int couleur) : base(number, notPlayed)
        {
           // super(number, notPlayed);
            this.couleur = couleur;
        }

        public int getCouleur()
        {
            return couleur;
        }
    
    }
}
