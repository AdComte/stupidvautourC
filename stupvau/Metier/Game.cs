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


	public Game(int nbplayers, int[] ialvl)
	{
		IList<Player> listPlayer = new List<Player>();
		for (int i = 1; i < nbplayers; i++)
		{
			switch(ialvl[i])
			{
				case 1:
					listPlayer.Add(new IAStupid(i));
					break;
				case 2:
					listPlayer.Add(new IAMedium(i));
					break;
				case 3:
					listPlayer.Add(new IAPlayer(i));
					break;
			}
		}
	}





    public Game(int nbPlayer) {
        IList<Player> listPlayer = new List<Player>();
        int i=0;
        //for ( i = 0; i < nbPlayer-2; i++) {
        //    listPlayer.Add(new IAStupid(i));
        //}
        listPlayer.Add(new IAPlayer(i));
        listPlayer.Add(new IAMedium(i+1));  // Le nième joueur : un Human ou pas
      //  listPlayer.add(new Human());
        foreach (Player p in listPlayer) { Console.WriteLine("Le joueur " + p.getCouleur() + " entre dans la partie"); }
      
        this.table = new Table(listPlayer);


        ////////
        ///////
        //////
        /////
        //int j; Random m = new Random();
        //for (j = 0; j < 15; j++)
        //{
           
        //    int indice = m.Next(10);
        //    Console.WriteLine(indice);
        //}
    }

    // Le jeu
    public int GameLoop() {
        Console.WriteLine("***************************** Debut de la partie **************************************");
        int turn = NB_CARDS;
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
            if (turn != 1)
            { this.table.next_round(); Console.WriteLine("******************* Passage au tour suivant *******************"); }
            turn--;
        }
        int score = this.table.getPlayerHighestScore();
        if (score != -1)
            Console.WriteLine("Le joueur numéro " + score + " a gagné ! Bravo à lui");
        else Console.WriteLine("Egalité parfaite à l'issue de la partie !");
        return score;
    }
    }
}
