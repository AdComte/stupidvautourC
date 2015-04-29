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
		public IAPlayer(int i) : base(i) { }
		public override PlayerCard play(int selected)
		{
			return null;
		}
   

    public override PlayerCard play(Table table){
        int value = table.getCurrent().getValue(), max=0, indice=1;
        PlayerCard Carte=null;
        if(table.getCurrent().getAnimal())//Si on est sur un vautour
        {   
            max= this.getMaxValueOnTable(table);
            if(value < 4) 
            {                               //on joue une carte intermédiaire
                max = this.getMaxValueOnPlayer(8);
            }                               //Sinon on joue la carte immédiatement supérieure qu'on a
            bool ok=false;
            int i=1;
            if(max!=0)
            while(ok==false && max+i<=15 && max+i>0)
            {
                if (max + i > 0) { indice = max + i; }
                Carte = new PlayerCard(max + i, true, this.getCouleur());
                if(this.listPlayerCard[indice-1,0] != 0)//Si le joueur n'a pas la carte
                {
                    ok=true;
                    this.removeCard(Carte.getValue()-1);
                }
               i++;
            }
        }
        else
        {                    //Sinon si on est sur une souris
            if(value < 4) 
            {                                       //Si la souris rapporte peu de points
                max = this.getMaxValueOnPlayer(6);    //On joue une carte intermédiaire
                if(max!=0) Carte = new PlayerCard(max, true, this.getCouleur());
            }
            if(value < 8 && value >=4)      //Si la souris rapporte quelques points
            {                               //Elle vaut le coup de se battre
                max = this.getMaxValueOnPlayer(11);
                if (max != 0) { Carte = new PlayerCard(max, true, this.getCouleur()); }
            } else 
            {                               //Sinon on la récupère à tout prix car elle rapporte gros 
                bool ok=false;           // on joue la carte immédiatement supérieure au max de la carte posée
                int i=1;
                while(ok==false && max+i<=15 && max+i>0)
                {
                    Carte = new PlayerCard(max+i, true, this.getCouleur());
                    if (this.listPlayerCard[Carte.getValue() - 1, 0] != 0)//Si le joueur n'a pas la carte
                    {
                        ok=true;
                        //this.getListPlayerCard().Remove(Carte);
                    }
                   i++;
                }
            }
        }
        if (Carte != null && this.nbCartesRestantes >= 0 && Carte.getValue() != 0) 
        {
            PlayerCard played = Carte;
            this.removeCard(Carte.getValue()-1);
            return played; 
        }
            Console.WriteLine("Le joueur " + this.getCouleur() + "joue au pif !!!");
            Random r = new Random();
            IList<int> dispo = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                if (this.listPlayerCard[i, 0] != 0) dispo.Add(i);
            }
            int indice2 = dispo.ElementAt(r.Next(this.nbCartesRestantes)); 
            PlayerCard p = new PlayerCard(indice2, false, this.getCouleur());
            this.removeCard(indice2);
            return p;

    }
    
    }
}
