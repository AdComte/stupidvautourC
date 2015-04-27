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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            gb_player3.Enabled = false;
            gb_player4.Enabled = false;
            gb_player5.Enabled = false;
        }

        private void btn_begin_Click(object sender, EventArgs e)
        {
            //TODO, envoyer les paramètres au constructeurs de la table pour le nombre de joueurs et à la boucle de jeu pour les ia
        }

        private void rb_2players_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_2players.Checked == true)
            {
                gb_player2.Enabled = true;
                gb_player3.Enabled = false;
                gb_player4.Enabled = false;
                gb_player5.Enabled = false;
            }
        }

        private void rb_3players_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_3players.Checked == true)
            {
                gb_player2.Enabled = true;
                gb_player3.Enabled = true;
                gb_player4.Enabled = false;
                gb_player5.Enabled = false;
            }
        }

        private void rb_4players_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_4players.Checked == true)
            {
                gb_player2.Enabled = true;
                gb_player3.Enabled = true;
                gb_player4.Enabled = true;
                gb_player5.Enabled = false;
            }
        }

        private void rb_5players_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_5players.Checked == true)
            {
                gb_player2.Enabled = true;
                gb_player3.Enabled = true;
                gb_player4.Enabled = true;
                gb_player5.Enabled = true;
            }
        }
    }
}
