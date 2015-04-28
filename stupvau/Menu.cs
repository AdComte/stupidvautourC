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
        public int nbia;
        public int[] iaplayers;
		public bool ready;

        public Menu()
        {
            InitializeComponent();
            gb_player3.Enabled = false;
            gb_player4.Enabled = false;
            gb_player5.Enabled = false;
            iaplayers = new int[5];
			ready = false;
        }

        private void btn_begin_Click(object sender, EventArgs e)    //set le nombre d'ia, et leur niveau. easy->0 medium->1 hard->2
        {
            if (rb_2players.Checked == true) nbia = 1;
            if (rb_3players.Checked == true) nbia = 2;
            if (rb_4players.Checked == true) nbia = 3;
            if (rb_5players.Checked == true) nbia = 4;
            for(int i = 1; i < nbia; i++)
            {
                switch(i)
                {
                    case 1:
                        if (rb_pl2easy.Checked == true) iaplayers[2] = 0;
                        if (rb_pl2medium.Checked == true) iaplayers[2] = 1;
                        if (rb_pl2hard.Checked == true) iaplayers[2] = 2;
                        break;
                    case 2:
                        if (rb_pl3easy.Checked == true) iaplayers[3] = 0;
                        if (rb_pl3medium.Checked == true) iaplayers[3] = 1;
                        if (rb_pl3hard.Checked == true) iaplayers[3] = 2;
                        break;
                    case 3:
                        if (rb_pl4easy.Checked == true) iaplayers[4] = 0;
                        if (rb_pl4medium.Checked == true) iaplayers[4] = 1;
                        if (rb_pl4hard.Checked == true) iaplayers[4] = 2;
                        break;
                    case 4:
                        if (rb_pl5easy.Checked == true) iaplayers[5] = 0;
                        if (rb_pl5medium.Checked == true) iaplayers[5] = 1;
                        if (rb_pl5hard.Checked == true) iaplayers[5] = 2;
                        break;
                }
            }
			ready = true;
			this.Close();
        }
        
		public int niv_ia(int nb)   //Renvoie le niveau sélectionner de l'ia, en fonction du numéro du joueur
        {
            switch(nb)
            {
                case 1:
                    if (rb_pl2easy.Checked == true) return 1;
                    if (rb_pl2medium.Checked == true) return 2;
                    return 3;
                case 3:
                    if (rb_pl3easy.Checked == true) return 1;
                    if (rb_pl3medium.Checked == true) return 2;
                    return 3;
                case 4:
                    if (rb_pl4easy.Checked == true) return 1;
                    if (rb_pl4medium.Checked == true) return 2;
                    return 3;
                case 5:
                    if (rb_pl5easy.Checked == true) return 1;
                    if (rb_pl5medium.Checked == true) return 2;
                    return 3;
                default:
                    return 0;
            }
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
