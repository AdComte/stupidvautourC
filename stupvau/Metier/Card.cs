using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class Card
    {
        public int value;
        public bool notPlayed;

        public Card()
        {

        }
        public Card(int number, bool notPlayed)
        {
            this.value = number;
            this.notPlayed = notPlayed;

        }
        public Card(int number)
        {
            this.value = number;
            this.notPlayed = true;
        }

        public int getValue()
        {
            return this.value;
        }

        public bool getVisible()
        {
            return this.notPlayed;
        }
        public void setNotPlayed(bool V)
        {
            this.notPlayed = V;
        }

        /*     public void ToString() 
             {
             if(notPlayed)
         *   {
             Console.WriteLine("Carte "+this.value);}
             else
         *   {
                 Console.WriteLine("Carte Inconnue");}
             }
             }*/
    }
}
