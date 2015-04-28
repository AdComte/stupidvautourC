using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace stupvau.Metier
{
    class Table
    {
    public readonly static int NB_VULTURE = 5;
    public readonly static int NB_MOUSE = 10;

    private IList<PlayerCard> listPlayerCardsOnTable;
    private AnimalCard current;
    private IList<AnimalCard> stack;
    private IList<Player> listPlayer;

    public Table(IList<Player> listPlayer)
    {
        this.listPlayerCardsOnTable = new List<PlayerCard>();
        this.stack = new List<AnimalCard>();
        this.listPlayer = listPlayer;
    }

    public IList<PlayerCard> getListPlayerCardsOnTable()
    {
        return listPlayerCardsOnTable;
    }

    public IList<Player> getPlayerlist()
    {
        return listPlayer;
    }

    // Fait jouer chaque joueur et met leur carte sur la table
    // Return : Tous les joueurs ont joué une carte sur la table
    public void play() {
             Console.WriteLine("Carte du stack : "); /////////////////
              Console.WriteLine(this.current.getValue());     //////////////
              Console.WriteLine(this.current.getAnimal());     //////////////
        int point = this.getCurrent().getValue();
        if (this.getCurrent().getAnimal()) {
            point = point * -1;
        }
        
        
     Console.WriteLine("************************");        ///////////
     foreach (Player p in this.listPlayer)
     {
            PlayerCard a = p.play(this);
            Console.WriteLine("Valeur carte joueur"+ p.getCouleur()+" :");        ///////////
            Console.WriteLine(a.getValue());                   ///////////
            this.listPlayerCardsOnTable.Add(a);
        }
        
        int winnerRound = this.win_round();
        if (winnerRound != -1) {
            this.listPlayer.ElementAt(winnerRound).setScore(point);
            Console.WriteLine("Score mis à jour: "); /////////////////
            Console.WriteLine(this.listPlayer[this.win_round()].getScore()); /////////////
        }
    }

    //Retourne le numéro du joueur au plus haut score
    public int getPlayerHighestScore() {
        int max = 0, winner = -1;
        foreach (Player p in listPlayer) {
            if (p.getScore() > max) {
                max = p.getScore();
                winner = p.getCouleur();
            }
        }
        return winner;
    }

    public void deal() {
        for (int i = 1; i < NB_VULTURE + 1; i++) {
            this.stack.Add(new AnimalCard(i, true));
        }
        for (int i = 1; i < NB_MOUSE + 1; i++) {
            this.stack.Add(new AnimalCard(i, false));
        }
    }

    public void melangerAnimalCard() {

        IList<AnimalCard> pioche = new List<AnimalCard>();

        for (int i = 1; i < NB_VULTURE + 1; i++) {
            pioche.Add(new AnimalCard(i, true));
        }
        for (int i = 1; i < NB_MOUSE + 1; i++) {
            pioche.Add(new AnimalCard(i, false));
        }
        Console.WriteLine("Au commencement, la pile contient : " + this.stack.Count() + " éléments");
        Random j = new Random();


        IList<AnimalCard> stackMelanger = new List<AnimalCard>();
        while (pioche.Count > 0) {
            int i = j.Next(pioche.Count());
            stackMelanger.Add(pioche[i]);
            pioche.Remove(pioche[i]);
        }
        this.stack = stackMelanger;

        foreach(AnimalCard a in this.stack)
        {
            if(a.getAnimal())
            {
                Console.WriteLine("Vautour/" + a.getValue());
            }
            else
            {
                Console.WriteLine("Souris/" + a.getValue());
            }
        }
    }

    //TODO : cas d'égalité

    //Renvoie le numéro du joueur gagnant ce coup ci
    public int win_round() 
    {
        if (this.listPlayerCardsOnTable.Count == 0)
        {
            return -1;
        }
        IList<PlayerCard> listCardGagnantes = new List<PlayerCard>();
        int max = 0, min = 15;
        if (this.current.getAnimal()) { //Si c'est un vautour
            foreach (PlayerCard p in this.listPlayerCardsOnTable) {
                if (p.value < min) {//On enregistre qui a posé la valeur min
                    min = p.value;
                    listCardGagnantes.Clear();
                    listCardGagnantes.Add(p);
                } else if (p.value == min) {
                    listCardGagnantes.Add(p);
                }
            }
        } else {    // Sinon si c'est une souris
            foreach (PlayerCard p in this.listPlayerCardsOnTable) {
                Console.WriteLine(p.value +" de " + p.getCouleur() +" est sur la table");
                if (p.value > max)//On récupère le max et le joueur auquel il appartient
                {
                    max = p.value;
                    listCardGagnantes.Clear();
                    listCardGagnantes.Add(p);
                } else if (p.value == max) {
                    listCardGagnantes.Add(p);
                }
            }
        }
        if (listCardGagnantes.Count == 1) {
            Console.WriteLine("Le joueur" + listCardGagnantes[0].getCouleur() + "gagne le round");
            return listCardGagnantes.ElementAt(0).getCouleur();
        } else if (listCardGagnantes.Count == 0) {
            return -1;
        } else {
            int i = 0;
            while (i < listCardGagnantes.Count) {
                listPlayerCardsOnTable.Remove(listCardGagnantes.ElementAt(i));
            }
            return this.win_round();
            
            //return listCardGagnantes[0].getCouleur();
            //return this.win_round();
        }
    }

    public void next_round() {
        this.listPlayerCardsOnTable.Clear();
        this.current = stack[0];
        this.stack.RemoveAt(0);
    }

    public AnimalCard getCurrent() {
        return current;
    }

    public IList<AnimalCard> getStack()
    {
        return stack;

    }

    public void setCurrent(AnimalCard current) {
        this.current = current;
    }

    }
}
