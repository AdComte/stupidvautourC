using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class IAPlayer : Player
    {
        
    public IAPlayer (int i) : base() {
  //  super(i);
    }
/**
 * 
 * @param cap
 * @return 
 */    
private int getMaxValueOnPlayer (int cap)
{
        int i=0, result=0;
        bool loop = true;
        if(cap>0)//Si une limite est définie
        {
            while (result<cap && loop)
            {
                int value = this.getListPlayerCard().get(i).getValue();
                if( value > cap)
                {
                    loop=false;
                } else {
                    result = value;
                    i++;
                }
            }
        } 
        else
        {
            for(PlayerCard P : base.getListPlayerCard())
            {
                if (P.getValue()>result)
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
    private int getMaxValueOnTable (Table table) {
        int result =0;
            for (PlayerCard P : table.getListPlayerCardsOnTable()) 
            {
                if(P.value > result)
                {
                    result = P.value;
                }
            }
    return result;
    }
    
    public PlayerCard play(Table table){
        int value = table.getCurrent().getValue(), max=0;
        PlayerCard Carte=null;
        if(table.getCurrent().getAnimal())//Si on est sur un vautour
        {   
            max=this.getMaxValueOnTable(table);
            if(value < 4) 
            {                               //on joue une carte intermédiaire
                max = this.getMaxValueOnPlayer(8);
            }                               //Sinon on joue la carte immédiatement supérieure qu'on a
            bool ok=false;
            int i=1;
            while(ok==false && max+i<=15)
            {
                Carte = new PlayerCard(max+i, true, -1);
                if(this.getListPlayerCard().contains(Carte))
                {
                    ok=true;
                    this.getListPlayerCard().remove(Carte);
                }
               i++;
            }
        }else
        {                    //Sinon si on est sur une souris
            if(value < 4) 
            {                                       //Si la souris rapporte peu de points
                max = this.getMaxValueOnPlayer(6);    //On joue une carte intermédiaire
                Carte = new PlayerCard(max, true, -1);
            }
            if(value < 8 && value >=4)      //Si la souris rapporte quelques points
            {                               //Elle vaut le coup de se battre
                max = this.getMaxValueOnPlayer(11);
                Carte = new PlayerCard(max, true, -1);
            } else 
            {                               //Sinon on la récupère à tout prix car elle rapporte gros 
                bool ok=false;           // on joue la carte immédiatement supérieure au max de la carte posée
                int i=1;
                while(ok==false && max+i<=15)
                {
                    Carte = new PlayerCard(max+i, true, -1);
                    if(this.getListPlayerCard().contains(Carte))
                    {
                        ok=true;
                        this.getListPlayerCard().remove(Carte);
                    }
                   i++;
                }
            }
        }
        return Carte;
    }
    
    public PlayerCard play() {
      //  throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    }
}
