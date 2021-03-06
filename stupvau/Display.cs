﻿using System;
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
        private int winner;
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
			if (etat[0] == -1)
			{
				state("Egalite sur la manche");
			}
            if (etat[0] == 0) //le gagnant est l'humain, le texte est adapté, MàJ score
            {
				if(etat[1] > 0)	state("Vous gagnez " + etat[1] + " points");
				else { state("Vous perdez " + etat[1] + " points"); }
                lbl_playerpoints.Text = "Vos points : " + etat[2];
            }
            else //gagnant ia, texte standard
            {
				if (etat[1] > 0) state("Le joueur " + etat[0] + " gagne " + etat[1] + " points");
				else { state("Le joueur " + etat[0] + " perd " + etat[1] + " points"); }
            }

            //affichage des cartes jouées et MàJ du score gagnant
            if (etat[0] != -1)
            {
                pb_player2.Image = cardsplayer2.Images[etat[3]];
                if (etat[0] == 1) lbl_player2points.Text = "points : " + etat[2];

                if (nbplayer >= 3)
                {
                    pb_player3.Image = cardsplayer3.Images[etat[4]];
                    if (etat[0] == 2) lbl_player3points.Text = "points : " + etat[2];
                }
                if (nbplayer >= 4)
                {
                    pb_player4.Image = cardsplayer4.Images[etat[5]];
                    if (etat[0] == 3) lbl_player4points.Text = "points : " + etat[2];
                }
                if (nbplayer >= 5)
                {
                    pb_player5.Image = cardsplayer5.Images[etat[6]];
                    if (etat[0] == 4) lbl_player5points.Text = "points : " + etat[2];
                }
            }
        }
		#endregion
		#region Evenements
		private void btn_valid_Click(object sender, EventArgs e)
        {
            if (selectedcard != 0) //IMPORTANT
            {
                lockgame();
                playablecards[selectedcard-1] = false;

				game.table.play(selectedcard);	//La carte de l'humain est validée et les ia jouent à tour de role



				int[] lap = new int[11];
				winner = lap[0] = game.table.win_round(this.game.table.getListPlayerCardsOnTable());		//celui qui gagne
				lap[1] = game.table.getCurrent().value;	//les points qui sont gagnés
				if (game.table.getCurrent().getAnimal()) lap[1] *= -1;
                if (lap[0] != -1)
                {
                    lap[2] = game.table.getPlayerlist().ElementAt(lap[0]).getScore();	//points du gagnant
                }
                try
                {
                    lap[3] = game.table.getListPlayerCardsOnTable().ElementAt(1).getValue();
                }
                catch (Exception ex) { lap[3]=game.table.getListPlayerCardsOnTable().ElementAt(0).getValue(); }
				if (nbplayer >= 3)
				{
					lap[4] = game.table.getListPlayerCardsOnTable().ElementAt(2).getValue();
				}
				if (nbplayer >= 4)
				{
					lap[5] = game.table.getListPlayerCardsOnTable().ElementAt(3).getValue();
				}
				if (nbplayer == 5)
				{
					lap[6] = game.table.getListPlayerCardsOnTable().ElementAt(4).getValue();
				}

				affiche(lap);
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
			turn--;
            pb_player2.Image = cardsplayer2.Images[0];
            if (nbplayer >= 3) pb_player3.Image = cardsplayer3.Images[0];
            if (nbplayer >= 4) pb_player4.Image = cardsplayer4.Images[0];
            if (nbplayer >= 5) pb_player5.Image = cardsplayer5.Images[0];
			if (turn != 0 || this.winner==-1 || this.game.table.last_winner==-1)
			{
				state("Nouveau tour, à vous de jouer");
				game.table.next_round();
				newcard();
				unlockgame();
			}
			else
			{
				state("Partie terminée");
			}
		}
		#endregion

    }
}

