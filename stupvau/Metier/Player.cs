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

        public void removeCard(PlayerCard p)
        {
            this.listPlayerCard.Remove(p);
            if(this.listPlayerCard.Contains(p))
            {
                Console.WriteLine("Echec de la suppression");
            }
            affichecartes(this);
        }
        public void removeCard(int indice)
        {
            PlayerCard a =this.listPlayerCard[indice];
            this.listPlayerCard.RemoveAt(indice);
            if(this.listPlayerCard.Contains(a)){
                Console.WriteLine("La suppression a échoué");
            }
            affichecartes(this);
        }
        public abstract PlayerCard play(Table table);
        public void affichecartes(Player p)
        {
            Console.WriteLine();
            foreach (PlayerCard a in p.getListPlayerCard())
            {
                Console.Write(a.getValue() + " | ");
            }
            Console.WriteLine();
        }
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
                while (result < cap && loop && i<this.getListPlayerCard().Count)
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
