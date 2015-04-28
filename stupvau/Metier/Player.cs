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
        private Random random;


        public abstract PlayerCard play(Table table);

        public Player(int i) {
            listPlayerCard = new List<PlayerCard>();
            this.couleur = i;
            this.score = 0;
            this.random = new Random();
        }

        
        public void deal(int nbCard)
        {
            for (int i = 1; i < nbCard + 1; i++)
            {
                this.listPlayerCard.Add(new PlayerCard(i, true, couleur));
            }
        }
        /**
         * 
         * @param cap
         * @return 
         */
        protected int getMaxValueOnPlayer(int cap)
        {
            int i = 0, result = 0;
            bool loop = true;
            if (cap > 0)//Si une limite est définie
            {
                while (result < cap && loop)
                {
                    int value = this.getListPlayerCard()[i].getValue();
                    if (value > cap)
                    {
                        loop = false;
                    }
                    else
                    {
                        result = value;
                        i++;
                    }
                }
            }
            else
            {
                foreach (PlayerCard P in this.getListPlayerCard())
                {
                    if (P.getValue() > result)
                    {
                        result = P.getValue();
                    }
                }
            }
            return result;
        }
        /**
         * trouver le max posé par les autres joueurs
         * */
        protected int getMaxValueOnTable(Table table)
        {
            int result = 0;
            foreach (PlayerCard P in table.getListPlayerCardsOnTable())
            {
                if (P.value > result)
                {
                    result = P.value;
                }
            }
            return result;
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

        public Random getRandom()
        {
            return random;
        }
    }
}
