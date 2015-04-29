using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stupvau.Metier;

namespace stupvau
{
    public partial class Display : Form
	{
		#region Attributs
		public bool[] playablecards;
        public int selectedcard;
        public int nbplayer;
		private int turn = 15;
		Game game;
		#endregion

		#region Constructeurs
		private Display()
        {
            InitializeComponent();
			playablecards = new bool[16];
            for(int i=0; i < 15; i++)
            {
                playablecards[i] = true;
            }
            selectedcard = 0;
            pb_player.Image = cardsplayer1.Images[0];
        }
        private Display(int nbplayer) : this()
        {
            this.nbplayer = nbplayer;
            if (nbplayer <= 4)
            {
                pb_player5.Visible = false;
                lbl_player5name.Visible = false;
                lbl_player5points.Visible = false;
            }
            if (nbplayer <= 3)
            {
                pb_player4.Visible = false;
                lbl_player4name.Visible = false;
                lbl_player4points.Visible = false;
            }
            if (nbplayer <= 2)
            {
                pb_player3.Visible = false;
                lbl_player3name.Visible = false;
                lbl_player3points.Visible = false;
            }
        }
		public Display(int nbplayer, int[] ialvl) : this(nbplayer)
		{
			game = new Game(nbplayer, ialvl);
			game.table.melangerAnimalCard();
			newcard();
			state("Bon Jeu");
		}
		#endregion
		#region Affichages et etats du jeu
		public void state(String txt) // Permet de gérer le label d'état en haut
        {
            lbl_state.Text = txt;
        }

        private void lockgame() //Rend les toutes cartes non sélectionnables et le bouton non cliquable
        {
            foreach (Control c in tlp_player.Controls)
            {
                c.Enabled = false;
            }
            btn_valid.Enabled = false;
        }

        private void unlockgame() //Rend les cartes non jouées sélectionnables et le bouton cliquable
        {
            int i = 0;
            foreach (Control c in tlp_player.Controls)
            {
                if (playablecards[i] == true)
                {
                    c.Enabled = true;
                }
                else
                {
                    c.Visible = false;
                }
                i++;
            }
            btn_valid.Enabled = true;
            selectedcard = 0;
            pb_player.Image = cardsplayer1.Images[selectedcard];
        }

        public void newcard() //permet d'afficher la carte en jeu
        {
			int indice = game.table.getCurrent().value;
			if (game.table.getCurrent().getAnimal()) indice += 10;
            pb_animalcard.Image = animalcards.Images[indice];
        }

        public void affiche ()
        {
            timer.Enabled = true;
            int indice_winner = this.game.table.win_round();
            if (indice_winner == 0) //le gagnant est l'humain, le texte est adapté, MàJ score
            {
                lbl_playerpoints.Text = "Vos points : " + this.game.table.getPlayerlist()[this.game.table.getPlayerHighestScore()].getScore();
            }
            else //gagnant ia, texte standard
            {
                state("Le joueur " + indice_winner + " gagne " + this.game.table.getCurrent() + " points");
            }
            //affichage des cartes jouées et MàJ du score gagnant
            pb_player2.Image = cardsplayer2.Images[this.game.table.getListPlayerCardsOnTable()[1].getValue()];
            if (indice_winner == 1) lbl_player2points.Text = "points : " + this.game.table.getPlayerlist()[indice_winner].getScore();
            {
                pb_player3.Image = cardsplayer3.Images[this.game.table.getListPlayerCardsOnTable()[2].getValue()];
                if (indice_winner == 2) lbl_player3points.Text = "points : " + this.game.table.getPlayerlist()[indice_winner].getScore();
            }
            if(nbplayer >=4)
            {
                pb_player4.Image = cardsplayer4.Images[this.game.table.getListPlayerCardsOnTable()[3].getValue()];
                if (indice_winner == 3) lbl_player4points.Text = "points : " + this.game.table.getPlayerlist()[indice_winner].getScore();
            }
            if (nbplayer >= 5)
            {
                pb_player5.Image = cardsplayer5.Images[this.game.table.getListPlayerCardsOnTable()[4].getValue()];
                if (indice_winner == 4) lbl_player5points.Text = "points : " + this.game.table.getPlayerlist()[indice_winner].getScore(); 
            }
        }
		#endregion
		#region Evenements RESTE UN TODO
		private void btn_valid_Click(object sender, EventArgs e)
        {
            if (selectedcard != 0) //IMPORTANT
            {
                lockgame();
                playablecards[selectedcard-1] = false;

				game.table.play(selectedcard);



				//int[] card = {selectedcard, 0};

				//PlayerCard human = new PlayerCard(selectedcard, false, 0);
				//game.table.getListPlayerCardsOnTable().Add(human);	//On ajoute la carte de l'humain

				//game.GameLoop(selectedcard);


				//int[] chosed = { played.value, played.getCouleur() };
				//int[] lap = new int[11];
				//lap[0] = game.table.win_round();
				//lap[1] = game.table.getCurrent().value;
				//lap[2] = game.table.getPlayerlist().ElementAt(lap[0]).getScore();
				//lap[3] = game.table.getListPlayerCardsOnTable().ElementAt(1).getValue();
				//lap[4] = game.table.getPlayerlist().ElementAt(1).getScore();
				//if (nbplayer >= 3)
				//{
				//	lap[5] = game.table.getListPlayerCardsOnTable().ElementAt(2).getValue();
				//	lap[6] = game.table.getPlayerlist().ElementAt(2).getScore();
				//}
				//if (nbplayer >= 4)
				//{
				//	lap[7] = game.table.getListPlayerCardsOnTable().ElementAt(3).getValue();
				//	lap[8] = game.table.getPlayerlist().ElementAt(3).getScore();
				//}
				//if (nbplayer == 5)
				//{
				//	lap[9] = game.table.getListPlayerCardsOnTable().ElementAt(4).getValue();
				//	lap[10] = game.table.getPlayerlist().ElementAt(4).getScore();
				//}
				//
                affiche();

				if(turn == 0)
				{
					Close();
				}
				timer.Enabled = true;
            }
        }

        private void pb_click(object sender, EventArgs e)
        {
            Control card = (Control)sender;
			selectedcard = Convert.ToInt32(card.Tag.ToString());
            pb_player.Image = cardsplayer1.Images[selectedcard];
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            state("Nouveau tour, à vous de jouer");
            pb_player2.Image = cardsplayer2.Images[0];
            if (nbplayer >= 3) pb_player3.Image = cardsplayer3.Images[0];
            if (nbplayer >= 4) pb_player4.Image = cardsplayer4.Images[0];
            if (nbplayer >= 5) pb_player5.Image = cardsplayer5.Images[0];
			game.table.next_round();
			newcard();
            unlockgame();
		}
		#endregion
	}
}
