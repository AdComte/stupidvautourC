using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Object;

namespace stupvau.Metier
{
    class Game
    {
    public sealed static int NB_CARDS = 15;
    //private int nbPlayer;
    private Table table;
    
    public Game(int nbPlayer) {
        ArrayList listPlayer = new ArrayList();
        for (int i = 0; i < nbPlayer - 1; i++) {
            listPlayer.Add(new IAStupid(i));
        }
      //  listPlayer.add(new Human());
        this.table = new Table(listPlayer);
    }

    // Le jeu
    public void GameLoop() {
        // // System.out.println("***************************** Debut de la partie **************************************");
        int turn = NB_CARDS;
       // this.table.deal(NB_CARDS);
        this.table.melangerAnimalCard();
                
        this.table.setCurrent(this.table.getStack().get(0)) ;
        for (Player p : this.table.getPlayerlist()) {
            p.deal(NB_CARDS);
        }        
        
        while (turn > 0) {
           // System.out.println("Début du tour" + turn);  ////////////////
            this.table.play();
            turn--;
        }
       // System.out.println("Le joueur numéro " + this.table.getPlayerHighestScore() + " a gagné ! Bravo à lui");
    }
    }
}
