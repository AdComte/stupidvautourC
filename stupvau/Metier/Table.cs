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
    private ArrayList listPlayer;

    public Table(ArrayList listPlayer) {
        this.listPlayerCardsOnTable = new ArrayList();
        this.stack = new ArrayList();
        this.listPlayer = listPlayer;

    }

    public ArrayList getListPlayerCardsOnTable() {
        return listPlayerCardsOnTable;
    }

    public ArrayList getPlayerlist() {
        return listPlayer;
    }

    // Fait jouer chaque joueur et met leur carte sur la table
    // Return : Tous les joueurs ont joué une carte sur la table
    public void play() {
  /*      System.out.println("Carte du stack : "); /////////////////
        System.out.println(this.current.getValue());     //////////////
        System.out.println(this.current.getAnimal());     //////////////*/
        int point = this.getCurrent().getValue();
        if (this.getCurrent().getAnimal()) {
            point = point * -1;
        }
        
        
  //      System.out.println("************************");        ///////////
        foreach (Player p in this.listPlayer) {
            PlayerCard a = p.play();
 //           System.out.println("Valeur carte joueur :");        ///////////
 //           System.out.println(a.getValue());                   ///////////
            this.listPlayerCardsOnTable.Add(a);
        }
        
        int winnerRound = this.win_round();
        while (winnerRound == -1) {
            winnerRound = this.win_round();
        }
        this.listPlayer.GetRange(this.win_round(), 1).ToArray().[0].setScore(point);
  //      System.out.println("Score mis à jour: "); /////////////////
    //    System.out.println(this.listPlayer.get(this.win_round()).getScore()); /////////////
        this.next_round();
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

    // TODO
    public void melangerAnimalCard() {

        ArrayList pioche = new ArrayList();

        for (int i = 1; i < NB_VULTURE + 1; i++) {
            pioche.Add(new AnimalCard(i, true));
        }
        for (int i = 1; i < NB_MOUSE + 1; i++) {
            pioche.Add(new AnimalCard(i, false));
        }
        Random j = new Random();

        ArrayList stackMelanger = new ArrayList();
        while (pioche.Count > 0) {
            stackMelanger.Add(pioche.Remove(j.Next(pioche.size())));
        }
        this.stack = stackMelanger;
    }

    //TODO : cas d'égalité
    public int win_round() //Renvoie le numéro du joueur gagnant ce coup ci
    {
        ArrayList listCardGagnantes = new ArrayList();
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
               // System.out.println(p.value);
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
         //   System.out.println("Le joueur" + listCardGagnantes.get(0).getCouleur() + "gagne le round");
            return listCardGagnantes.get(0).getCouleur();
        } else if (listCardGagnantes.Count == 0) {
            return -1;
        } else {

            while (listCardGagnantes.Count > 0) {
                this.listPlayerCardsOnTable.Remove(listCardGagnantes.Remove(listCardGagnantes.));
            }
            return this.win_round();
        }
    }

//    
//        //TODO : cas d'égalité
//    public int win_round() //Renvoie le numéro du joueur gagnant ce coup ci
//    {
//        int max = 0, min = 15;
//        int couleur = -1;
//        if (this.current.getAnimal()) { //Si c'est un vautour
//            for (PlayerCard p : this.listPlayerCardsOnTable) {
//                if (p.value < min) {//On enregistre qui a posé la valeur min
//                    min = p.value;
//                    couleur = p.couleur;
//                }
//            }
//        } else {    // Sinon si c'est une souris
//            for (PlayerCard p : this.listPlayerCardsOnTable) {
//                System.out.println(p.value);
//                if (p.value > max)//On récupère le max et le joueur auquel il appartient
//                {
//                    max = p.value;
//                    couleur = p.couleur;
//                }
//            }
//        }
//        System.out.println("le joueur" + couleur + "gagne le round");
//        return couleur;
//    }
    // Passe au tour suivant
    // On défausse les cartes des joueurs sur le tapis
    // On retourne une nouvelle carte
    public void next_round() {
        this.listPlayerCardsOnTable.Clear();
        this.current = stack.get(0);
        this.stack.Remove(0);
    }

    public AnimalCard getCurrent() {
        return current;
    }

    public ArrayList getStack() {
        return stack;

    }

    public void setCurrent(AnimalCard current) {
        this.current = current;
    }

    }
}
