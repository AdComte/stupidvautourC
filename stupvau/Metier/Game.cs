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
        for (int i = 0; i < nbPlayer; i++) {
            listPlayer.Add(new IAStupid(i));
        }
      //  listPlayer.add(new Human());
        this.table = new Table(listPlayer);
    }

    // Le jeu
    public void GameLoop() {
        Console.WriteLine("***************************** Debut de la partie **************************************");
        int turn = NB_CARDS;
       // this.table.deal();
        this.table.melangerAnimalCard();
        AnimalCard AC = (AnimalCard) this.table.getStack()[0];
        Console.WriteLine("********************************************");
        foreach (AnimalCard a in this.table.getStack())
        {
            if (a.getAnimal())
            {
                Console.WriteLine("Vautour/" + a.getValue());
            }
            else
            {
                Console.WriteLine("Souris/" + a.getValue());
            }
        }
        Console.WriteLine("****************************************");
        this.table.setCurrent(AC);
        this.table.getStack().RemoveAt(0);
        foreach (AnimalCard a in this.table.getStack())
        {
            if (a.getAnimal())
            {
                Console.WriteLine("Vautour/" + a.getValue());
            }
            else
            {
                Console.WriteLine("Souris/" + a.getValue());
            }
        }
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
