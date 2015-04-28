using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stupvau
{
    public partial class Display : Form
    {
        public bool[] playablecards;
        public int selectedcard;
        public int nbplayer;

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

        public Display(int nbplayer) : this()
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

        public void state(String txt) // Permet de gérer le label d'état en haut
        {
            lbl_state.Text = txt;
        }

        private void lockgame() //Rend les toutes cartes in sélectionnables et le bouton incliquable
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

        public void newcard(int animalcard) //permet d'afficher la carte en jeu
        {
            pb_animalcard.Image = animalcards.Images[animalcard];
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

        private void btn_valid_Click(object sender, EventArgs e)
        {
            //TODO, transmettre "selectedcard" à la boucle de jeu
            if (selectedcard != 0) //IMPORTANT
            {
                lockgame();
                playablecards[selectedcard] = false;
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
            unlockgame();
            //TODO il faut demander à la boucle de piocher une nouvelle carte ...
        }
    }
}
