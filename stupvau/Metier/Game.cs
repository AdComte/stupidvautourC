using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace stupvau.Metier
{
    class Game
    {
    public readonly static int NB_CARDS = 15;
    //private int nbPlayer;
    private Table table;
    
    public Game(int nbPlayer) {
        IList<Player> listPlayer = new List<Player>();
        int i;
        for ( i = 0; i < nbPlayer-1; i++) {
            listPlayer.Add(new IAPlayer(i));
        }
        listPlayer.Add(new IAPlayer(i));  // Le nième joueur : un Human ou pas
        //  listPlayer.add(new Human());
        foreach (Player p in listPlayer) { Console.WriteLine("Le joueur " + p.getCouleur() + "Entre dans la partie"); }
      
        this.table = new Table(listPlayer);
    }

    // Le jeu
    public void GameLoop() {
        Console.WriteLine("***************************** Debut de la partie **************************************");
        int turn = NB_CARDS;
       // this.table.deal();
        this.table.melangerAnimalCard();
        AnimalCard AC = (AnimalCard) this.table.getStack()[0];

        this.table.setCurrent(AC);
        this.table.getStack().RemoveAt(0);

        foreach (Player p in this.table.getPlayerlist()) {
            p.deal(NB_CARDS);
        }        
        
        while (turn > 0) {
            Console.WriteLine("Début du tour" + turn);  ////////////////
            this.table.play();
            if(turn!=1)
                this.table.next_round();
            turn--;
        }
        Console.WriteLine("Le joueur numéro " + this.table.getPlayerHighestScore() + " a gagné ! Bravo à lui");
    }
    }
}
