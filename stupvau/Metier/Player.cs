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
        protected int[,] listPlayerCard;
        protected int nbCartesRestantes;
        public static int number = 0;
        private int couleur;
        private int score;
        private Random random;

        public void removeCard(int indice)
        {
            this.listPlayerCard[indice - 1,0] = 0;
            if (nbCartesRestantes>0)
                --this.nbCartesRestantes;
            
        }
        public abstract PlayerCard play(Table table);
		public abstract PlayerCard play(int selected);
        public void affichecartes(Player p)
        {
            Console.WriteLine();
            for(int k =0;k<15;k++)
            {
                if(this.listPlayerCard[k,0]!=0)
                    Console.Write(this.listPlayerCard[k,0] + " | ");
            }
            Console.WriteLine();
        }
        public Player(int i) {
            this.couleur = i;
            this.listPlayerCard = new int[,] {{1,i},{2,i},{3,i},{4,i},{5,i},{6,i},{7,i},{8,i},{9,i},{10,i},{11,i},{12,i},{13,i},{14,i},{ 15, i }};
            this.score = 0;
            this.nbCartesRestantes = 15;
            this.random = new Random();
        }

        
        public void deal(int nbCard)
        {
            for (int j = 0; j < nbCard; j++)
            {
                this.listPlayerCard[j, 0] = j + 1;
                this.listPlayerCard[j, 1] = this.couleur;
            }
        }
        /**
         * 
         * @param cap
         * @return 
         */
        public int getMaxValueOnPlayer(int cap)
        {
            int i = 0, result = 0;
            bool loop = true;
            if (cap > 0)//Si une limite est définie
            {
                while (result < cap && loop && i<15)
                {
                   int value = this.listPlayerCard[i,0];
                   if (value == 0) { i++; } else
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
                for (int k = 0; k < 15;k++ )
                {
                    if (this.listPlayerCard[k,0] > result)
                    {
                        result = this.listPlayerCard[k, 0];
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
       //     foreach (PlayerCard P in table.getListPlayerCardsOnTable())
       //     {
       //         if (P.value > result)
       //         {
       //             result = P.value;
       //         }
       //     }
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

        public int[,] getListPlayerCard()
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
