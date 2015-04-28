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
            Console.WriteLine("//////////////////////////////IAMedium Joue ////////////////////////////////////////////////////////////////////////////////////////////////////////");
            int value = table.getCurrent().getValue(), max = 0;
            PlayerCard Carte = null;
            Console.WriteLine("Cartes disponibles avant décision : ");
            affichecartes(this);
            if(table.getCurrent().getAnimal())//Si c'est un vautour
            {
                max = this.getMaxValueOnTable(table);
                if (value < 3)
                {                                //il vaut mieux l'éviter
                    max = this.getMaxValueOnPlayer(9);
                }
                else max = this.getMaxValueOnTable(table); // Surtout si c'est une forte valeur
                bool ok = false;
                int i = 0;
                if(max!=0)
                while (ok == false && max - i >0)
                {
                    Console.WriteLine("/Passage dans le while "+(i+1));
                    Carte = new PlayerCard(max - i, true, this.getCouleur());
                    if (this.listPlayerCard[Carte.getValue() - 1, 0] != 0)//Si le joueur n'a pas la carte
                    {
                        ok = true;
                    }
                    i++;
                }
                Console.WriteLine("Cartes disponibles pendant : ");
                affichecartes(this);
            }
            else
            {   //Sinon si c'est une souris
                if (value < 4)
                {                                       //Si la souris rapporte peu de points
                    max = this.getMaxValueOnPlayer(6);    //On joue une carte intermédiaire
                    if (max > 0) { Carte = new PlayerCard(max, true, this.getCouleur()); }
                } else
                if(value <= 9 && value >= 4 )//Si elle est intermédiaire
                {                               //On cherche à l'avoir absolument
                    //if (value == 9)
                    //    max = this.getMaxValueOnPlayer(15);
                    //else if (value == 8)
                    //    max = this.getMaxValueOnPlayer(14);
                    //else if (value == 7)
                    //    max = this.getMaxValueOnPlayer(13);
                    //else if (value == 6)
                    //    max = this.getMaxValueOnPlayer(12);
                    //else
                    //{
                        bool ok = false;//On fait tout pour l'obtenir
                        int i = 1;
                        while (ok == false && max + i <= 15 && max + i > 0)
                        {
                            Carte = new PlayerCard(max + i, true, this.getCouleur());
                            if (this.listPlayerCard[Carte.getValue() - 1, 0] != 0)//Si le joueur n'a pas la carte
                            {
                                ok = true;
                                //this.getListPlayerCard().Remove(Carte);
                            }
                            i++;
                        }
                    //}
                } else
                {
                    max = this.getMaxValueOnPlayer(3); // si c'est un 10 on laisse tomber car trop concurrentiel => poubelle
                    Carte = new PlayerCard(max, true, this.getCouleur());
                }
                Console.WriteLine("Cartes disponibles : ");
                affichecartes(this);
            }
        if (Carte != null && this.nbCartesRestantes != 0 && Carte.getValue() > 0)
            {
                PlayerCard played = Carte;
                this.removeCard(Carte.getValue()-1);
                Console.WriteLine("Cartes disponibles avant return : ");
                affichecartes(this);
                Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////");
                return played;
            }
                Console.WriteLine("Le joueur " + this.getCouleur() + "joue au pif !!!");
                Random r = new Random();
                int indice = r.Next(this.nbCartesRestantes);
                PlayerCard p = new PlayerCard(indice, false, this.getCouleur());
                this.removeCard(indice);
                Console.WriteLine("Cartes disponibles avant return : ");
                affichecartes(this);
                Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////");
                return p;
        }
    }
}
