using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    abstract class Player
    {
        private String name;
        private IList<PlayerCard> listPlayerCard;
        public static int number = 0;
        private int couleur;
        private int score;


        public abstract PlayerCard play(Table table);

        public Player ()
        {

        }
        public Player(int i) {
        listPlayerCard = new List<PlayerCard>();
        this.couleur = i;
        this.score = 0;
    }

        public void deal(int nbCard)
        {
            for (int i = 1; i < nbCard + 1; i++)
            {
                this.listPlayerCard.Add(new PlayerCard(i, true, couleur));
            }
        }

        public void setScore(int points)
        {
            this.score = this.score + points;
        }

        public int getScore()
        {
            return score;
        }

        public String getName()
        {
            return name;
        }

        public IList<PlayerCard> getListPlayerCard()
        {
            return listPlayerCard;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getCouleur()
        {
            return couleur;
        }
    }
}
