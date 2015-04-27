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
    public partial class Table : Form
    {
        public bool[] playablecards;

        public Table()
        {
            InitializeComponent();
            for(int i=0; i < 15; i++)
            {
                playablecards[i] = true;
            }
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
            }
            btn_valid.Enabled = true;
        }

        private void btn_valid_Click(object sender, EventArgs e)
        {
            //TODO, on valide le coup, redone la main à la boucle de jeu ne pas oublier d'ajouter la carte jouée dans payablecards false
            lockgame();
        }
    }
}
