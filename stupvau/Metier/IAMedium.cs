using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    //IAMedium a été construite selon l'approche suivante : pour gagner il faut à tout prix remporter les cartes
    // intermédiaires (entre 4 et 8) et éviter les vautours, surtout les grosses valeurs
    class IAMedium : Player
    {
        public IAMedium (int i) : base(i){}

        public override PlayerCard play(Table table)
        {
            int value = table.getCurrent().getValue(), max = 0;
            PlayerCard Carte = null;
            if(table.getCurrent().getAnimal())//Si c'est un vautour
            {
                max = this.getMaxValueOnTable(table);
                if(value<3)
                {                                //il vaut mieux l'éviter
                    max = this.getMaxValueOnPlayer(9);
                } 
                bool ok = false;            //mais on peut se le permettre
                int i = 0;
                while (ok == false && max - i >=0)
                {
                    Carte = new PlayerCard(max - i, true, this.getCouleur());
                    if (this.getListPlayerCard().Contains(Carte))
                    {
                        ok = true;
                        this.getListPlayerCard().Remove(Carte);
                    }
                    i++;
                }
            }
            else
            {   //Sinon si c'est une souris
                if (value < 4)
                {                                       //Si la souris rapporte peu de points
                    max = this.getMaxValueOnPlayer(6);    //On joue une carte intermédiaire
                    Carte = new PlayerCard(max, true, this.getCouleur());
                }
                if(value <= 9 && value >= 4 )//Si elle est intermédiaire
                {
                    max = this.getMaxValueOnPlayer(15);//On cherche à l'avoir absolument
                    Carte = new PlayerCard(max, true, this.getCouleur());
                } else
                {
                    max = this.getMaxValueOnPlayer(3); // si c'est un 10 on laisse tomber car trop concurrentiel => poubelle
                    Carte = new PlayerCard(max, true, this.getCouleur());
                }
            }
            this.getListPlayerCard().Remove(Carte);
            if (Carte != null)
            {
                PlayerCard played = Carte;
                this.getListPlayerCard().Remove(Carte);
                return played;
            }
            else
            {
                Console.WriteLine("Le joueur " + this.getCouleur() + "joue au pif !!!");
                Random i = new Random();
                int indice = i.Next(this.getListPlayerCard().Count);
                PlayerCard played = new PlayerCard(indice, false, this.getCouleur());
                this.getListPlayerCard().RemoveAt(indice);
                return played;
            }
        }
    }
}
