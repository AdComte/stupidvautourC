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

		private IList<int[]> listPlayerCardsOnTable;
		private AnimalCard current;
		private IList<AnimalCard> stack;
		private IList<Player> listPlayer;

		public Table(IList<Player> listPlayer)
		{
			this.listPlayerCardsOnTable = new List<int[]>();
			this.stack = new List<AnimalCard>();
			this.listPlayer = listPlayer;
		}

		public IList<int[]> getListPlayerCardsOnTable()
		{
			return listPlayerCardsOnTable;
		}

		public IList<Player> getPlayerlist()
		{
			return listPlayer;
		}

		// Fait jouer chaque joueur et met leur carte sur la table
		// Return : Tous les joueurs ont joué une carte sur la table
//		public void play() {
//            Console.WriteLine("Carte du stack : "); /////////////////
//            Console.Write(this.current.getValue() + " | ");     //////////////
//            Console.Write(this.current.getAnimal() + " \n");     //////////////
//			int point = this.getCurrent().getValue();
//			if (this.getCurrent().getAnimal()) {
//            point = point * -1;
//        }
//        
//        
//		 Console.WriteLine("************************");        ///////////
//		 foreach (Player p in this.listPlayer)
//		 {
//			 p.affichecartes(p);
//				PlayerCard a = p.play(this);
//			 if (p.getListPlayerCard()[a.getValue() - 1, 0] != 0)//Si le joueur n'a pas la carte
//				{
//					p.removeCard(a.getValue()-1);
//				}
//				else { MessageBox.Show("La carte jouée n'est pas contenue dans la liste des cartes du joueur"); }
//				Console.WriteLine("Valeur carte joueur"+ p.getCouleur()+" :");        ///////////
//				Console.WriteLine(a.getValue());                   ///////////
//				//this.listPlayerCardsOnTable.Add(a);
//		 }
//
//		 int winnerRound = this.win_round();
//			if (winnerRound >= 0) 
//			{
//				this.listPlayer.ElementAt(winnerRound).setScore(point);
//				Console.WriteLine("Score mis à jour: "); /////////////////
//				Console.WriteLine(this.listPlayer[winnerRound].getScore()); /////////////
//			}
//			else if (winnerRound == -1) { Console.WriteLine("ERREUR : Personne n'a gagné ce round, il n'y a pas égalité non plus"); }
//			else if (winnerRound == -2) { Console.WriteLine("Personne n'a gagné ce tour ci, les cartes seront défaussées"); }
//		}

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
			//Console.WriteLine("Au commencement, la pile contient : " + this.stack.Count() + " éléments");
			Random j = new Random();


			IList<AnimalCard> stackMelanger = new List<AnimalCard>();
			while (pioche.Count > 0) {
				int i = j.Next(pioche.Count());
				stackMelanger.Add(pioche[i]);
				pioche.Remove(pioche[i]);
			}
			this.stack = stackMelanger;
			current = stack[0];

			//foreach(AnimalCard a in this.stack)
			//{
			//    if(a.getAnimal())
			//    {
			//        Console.WriteLine("Vautour/" + a.getValue());
			//    }
			//    else
			//    {
			//        Console.WriteLine("Souris/" + a.getValue());
			//    }
			//}
		}

		//TODO : cas d'égalité

		//Renvoie le numéro du joueur gagnant ce coup ci
		public int win_round()
		{
			return 0;
//			if (this.listPlayerCardsOnTable.Count == 0)
//			{
//				Console.WriteLine("Aucune Carte n'a été déposée || Tout le monde est à égalité !");
//				return -1;
//			}
//			IList<int[,]> listCardGagnantes = new List<int[,]>();
//			int max = 0, min = 15, i = 0;
//			if (this.current.getAnimal()) { //Si c'est un vautour
//				foreach (int[] p in this.listPlayerCardsOnTable) {
//					if (p[i,0] < min) {//On enregistre qui a posé la valeur min
//						min = p[i, 1];
//						listCardGagnantes.Clear();
//						listCardGagnantes.Add(p);
//					}
//					else if (p[i, 0] == min)
//					{
//						listCardGagnantes.Add(p);
//					}
//					i++;
//				}
//			} else {    // Sinon si c'est une souris
//				i = 0;
//				foreach (int[] p in this.listPlayerCardsOnTable) {
//					Console.WriteLine(p[i, 0] + " de " + p[i, 1] + " est sur la table");
//					if (p[i, 0] > max)//On récupère le max et le joueur auquel il appartient
//					{
//						max = p[i, 0];
//						listCardGagnantes.Clear();
//						listCardGagnantes.Add(p);
//					}
//					else if (p[i, 0] == max)
//					{
//						listCardGagnantes.Add(p);
//					}
//					i++;
//				}
//			}
//			Console.WriteLine("La table contient : "+ listCardGagnantes.Count + " Cartes gagnantes");
//			if (listCardGagnantes.Count == 1) {
//				Console.WriteLine("Le joueur" + listCardGagnantes[0][0,1] + "gagne le round");
//				return listCardGagnantes.ElementAt(0)[0, 1];
//			} else if (listCardGagnantes.Count == 0) {
//				return -1;
//			}
//			else
//			{
//				Console.WriteLine("On supprime les cartes gagnantes identiques");
//				i = 0;
//				while (i < listCardGagnantes.Count)
//				{
//					listPlayerCardsOnTable.Remove(listCardGagnantes.ElementAt(i));
//					listCardGagnantes.RemoveAt(0);
//				}
//				return this.win_round();
//
//				//return listCardGagnantes[0].getCouleur();
//				//return this.win_round();
//			}
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

		public void play()
		{
			for(int i = 1; i < listPlayer.Count; i++)
			{
				Player temp = listPlayer.ElementAt(i);
				temp.play(this);
			}
		}
    }
}
