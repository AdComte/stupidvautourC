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
		private int manches = 15;
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

        public void affiche(int[] etat) //tableau type {gagnant, points gagnés, nouveau total de points du gagnant, carte jouée par j2, carte jouée par j3, ...}
        {
            timer.Enabled = true;
            if (etat[0] == 0) //le gagnant est l'humain, le texte est adapté, MàJ score
            {
                state("Vous gagnez " + etat[1] + " points");
                lbl_playerpoints.Text = "Vos points : " + etat[3];
            }
            else //gagnant ia, texte standard
            {
                state("Le joueur " + etat[0] + 1 + " gagne " + etat[1] + " points");
            }
            //affichage des cartes jouées et MàJ du score gagnant
            pb_player2.Image = cardsplayer2.Images[etat[3]];
            if (etat[0] == 1) lbl_player2points.Text = "points : " + etat[4];
            if(nbplayer >=3)
            {
                pb_player3.Image = cardsplayer3.Images[etat[5]];
                if (etat[0] == 2)   lbl_player3points.Text = "points : " + etat[6];
            }
            if(nbplayer >=4)
            {
                pb_player4.Image = cardsplayer4.Images[etat[7]];
                if (etat[0] == 3)   lbl_player4points.Text = "points : " + etat[8];
            }
            if (nbplayer >= 5)
            {
                pb_player5.Image = cardsplayer5.Images[etat[9]];
                if (etat[0] == 4)   lbl_player5points.Text = "points : " + etat[10];
            }
        }
		#endregion
		#region Evenements RESTE UN TODO
		private void btn_valid_Click(object sender, EventArgs e)
        {
            if (selectedcard != 0) //IMPORTANT
            {
                lockgame();
                playablecards[selectedcard] = false;
				//int[] card = {selectedcard, 0};

				PlayerCard human = new PlayerCard(selectedcard, false, 0);



				game.table.getListPlayerCardsOnTable().Add(human);	//On ajoute la carte de l'humain
				game.table.play();
				Player temp = game.table.getPlayerlist().ElementAt(0);

				PlayerCard played = new PlayerCard(selectedcard, false, temp.getCouleur());


				int[] chosed = { played.value, played.getCouleur() };
				int[] lap = new int[11];
				lap[0] = game.table.win_round();
				lap[1] = game.table.getCurrent().value;
				lap[2] = game.table.getPlayerlist().ElementAt(lap[0]).getScore();
				lap[3] = game.table.getListPlayerCardsOnTable().ElementAt(1).getValue();
				lap[4] = game.table.getPlayerlist().ElementAt(1).getScore();
				if (nbplayer >= 3)
				{
					lap[5] = game.table.getListPlayerCardsOnTable().ElementAt(2).getValue();
					lap[6] = game.table.getPlayerlist().ElementAt(2).getScore();
				}
				if (nbplayer >= 4)
				{
					lap[7] = game.table.getListPlayerCardsOnTable().ElementAt(3).getValue();
					lap[8] = game.table.getPlayerlist().ElementAt(3).getScore();
				}
				if (nbplayer == 5)
				{
					lap[9] = game.table.getListPlayerCardsOnTable().ElementAt(4).getValue();
					lap[10] = game.table.getPlayerlist().ElementAt(4).getScore();
				}

				affiche(lap);

				if(manches == 0)
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
