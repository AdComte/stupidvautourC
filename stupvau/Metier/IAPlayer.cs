using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    //IAPlayer a été construite selon l'approche suivante : pour gagner il faut à tout prix récupérer les cartes les plus hautes
    //et éviter les cartes les plus basses
    class IAPlayer : Player
    { 
    public IAPlayer (int i) : base(i) {}
   

    public override PlayerCard play(Table table){
        Console.WriteLine("Cartes du joueur IAPLAYER"); this.affichecartes(this);
        int value = table.getCurrent().getValue(), max=0;
        PlayerCard Carte=null;
        if(table.getCurrent().getAnimal())//Si on est sur un vautour
        {   
            max= this.getMaxValueOnTable(table);
            if(value < 4) 
            {                               //on joue une carte intermédiaire
                max = this.getMaxValueOnPlayer(8);
                Console.WriteLine("max = " + max);
            }                               //Sinon on joue la carte immédiatement supérieure qu'on a
            bool ok=false;
            int i=1;
            max = this.getMaxValueOnTable(table);
            while (ok == false && max + i <= 15)
            {
                Carte = new PlayerCard(max + i, true, this.getCouleur());
                if (this.getListPlayerCard().Contains(Carte))
                {
                    ok = true;
                }
                i++;
            }
        }
        else
        {                    //Sinon si on est sur une souris
            if(value < 4) 
            {                                       //Si la souris rapporte peu de points
                max = this.getMaxValueOnPlayer(6);    //On joue une carte intermédiaire
                Carte = new PlayerCard(max, true, this.getCouleur());
            }
            if(value < 8 && value >=4)      //Si la souris rapporte quelques points
            {                               //Elle vaut le coup de se battre
                max = this.getMaxValueOnPlayer(11);
                Carte = new PlayerCard(max, true, this.getCouleur());
            } else 
            {                               //Sinon on la récupère à tout prix car elle rapporte gros 
                bool ok = false;
                int i = 1;
                max = this.getMaxValueOnTable(table);
                while (ok == false && max + i <= 15)
                {
                    Carte = new PlayerCard(max + i, true, this.getCouleur());
                    if (this.getListPlayerCard().Contains(Carte))
                    {
                        ok = true;
                    }
                    i++;
                }
            }
            Console.WriteLine("max = " + max);
        }
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
