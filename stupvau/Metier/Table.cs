using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

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
		private IList<PlayerCard> temp; //sert à la gestion des cas de victoire sans alterer la liste réelle de carte sur la table

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

		public void melangerAnimalCard() {

			IList<AnimalCard> pioche = new List<AnimalCard>();

			for (int i = 1; i < NB_VULTURE + 1; i++) {
				pioche.Add(new AnimalCard(i, true));
			}
			for (int i = 1; i < NB_MOUSE + 1; i++) {
				pioche.Add(new AnimalCard(i, false));
			}
			Random j = new Random();


			IList<AnimalCard> stackMelanger = new List<AnimalCard>();
			while (pioche.Count > 0) {
				int i = j.Next(pioche.Count());
				stackMelanger.Add(pioche[i]);
				pioche.Remove(pioche[i]);
			}
			this.stack = stackMelanger;
			current = stack[0];
            Console.WriteLine("Au commencement, la pile contient : " + this.stack.Count() + " éléments");
            stack.RemoveAt(0);
		}


		//Renvoie le numéro du joueur gagnant ce coup ci
		public int win_round()
		{
			temp = new List<PlayerCard>(listPlayerCardsOnTable);
			if (temp.Count == 0)
			{
				Console.WriteLine("Aucune Carte n'a été déposée || Tout le monde est à égalité !");
				return -1;
			}
			IList<PlayerCard> listCardGagnantes = new List<PlayerCard>();
			int max = 0, min = 15, i = 0;
			if (this.current.getAnimal()) { //Si c'est un vautour
				foreach (PlayerCard p in temp)
				{
					if (p.value < min)
					{//On enregistre qui a posé la valeur min
						min = p.value;
						listCardGagnantes.Clear();
						listCardGagnantes.Add(p);
					}
					else if (p.value == min)
					{
						listCardGagnantes.Add(p);
					}
					i++;
				}
			} else {    // Sinon si c'est une souris
				i = 0;
				foreach (PlayerCard p in temp)
				{
					Console.WriteLine(p.value + " de " + p.getCouleur() + " est sur la table");
					if (p.value > max)//On récupère le max et le joueur auquel il appartient
					{
						max = p.value;
						listCardGagnantes.Clear();
						listCardGagnantes.Add(p);
					}
					else if (p.value == max)
					{
						listCardGagnantes.Add(p);
					}
					i++;
				}
			}
			Console.WriteLine("La table contient : "+ listCardGagnantes.Count + " Cartes gagnantes");
			if (listCardGagnantes.Count == 1) {
				Console.WriteLine("Le joueur" + listCardGagnantes[0].getCouleur() + "gagne le round");
                Console.WriteLine(this.getStack().Count); Console.WriteLine("MENGLON !!!");
				return listCardGagnantes.ElementAt(0).getCouleur();
			} else if (listCardGagnantes.Count == 0) //Egalite parfaite
			{
				return -1;
			}
			else
			{
				Console.WriteLine("On supprime les cartes gagnantes identiques");
				i = 0;
				while (i < listCardGagnantes.Count)
				{
					temp.Remove(listCardGagnantes.ElementAt(i));
					listCardGagnantes.RemoveAt(0);
				}
				return this.win_round();
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

		public void play(int hum)
		{
			for(int i = 0; i < listPlayer.Count; i++)
			{
				Player temp = listPlayer.ElementAt(i);
				PlayerCard played = null;

				if (temp.getCouleur() != 0)
				{
					 played = temp.play(this);
				}
				else
				{
					Console.WriteLine("BOUCLE ELSE, ON JOUE EN TANT QU'HUMAIN\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
					played = temp.play(hum);
				}
				if(played!=null) listPlayerCardsOnTable.Add(played);

                //else if (winnerRound == -1) { Console.WriteLine("ERREUR : Personne n'a gagné ce round, il n'y a pas égalité non plus"); }
                //else if (winnerRound == -2) { Console.WriteLine("Personne n'a gagné ce tour ci, les cartes seront défaussées"); }
			}
            int winnerRound = this.win_round();
            int point = this.getCurrent().getValue();
            if (this.getCurrent().getAnimal())
            {
                point = point * -1;
            }
            if (winnerRound >= 0)
            {
                this.listPlayer.ElementAt(winnerRound).setScore(point);
                //Console.WriteLine("Score mis à jour: "); /////////////////
                //Console.WriteLine(this.listPlayer[winnerRound].getScore()); /////////////
            }
		}
    }
}
