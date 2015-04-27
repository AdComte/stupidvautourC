namespace stupvau
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_begin = new System.Windows.Forms.Button();
            this.gb_nbplayers = new System.Windows.Forms.GroupBox();
            this.rb_5players = new System.Windows.Forms.RadioButton();
            this.rb_4players = new System.Windows.Forms.RadioButton();
            this.rb_3players = new System.Windows.Forms.RadioButton();
            this.rb_2players = new System.Windows.Forms.RadioButton();
            this.gb_player2 = new System.Windows.Forms.GroupBox();
            this.rb_pl2hard = new System.Windows.Forms.RadioButton();
            this.rb_pl2medium = new System.Windows.Forms.RadioButton();
            this.rb_pl2easy = new System.Windows.Forms.RadioButton();
            this.gb_player3 = new System.Windows.Forms.GroupBox();
            this.rb_pl3hard = new System.Windows.Forms.RadioButton();
            this.rb_pl3easy = new System.Windows.Forms.RadioButton();
            this.rb_pl3medium = new System.Windows.Forms.RadioButton();
            this.gb_player4 = new System.Windows.Forms.GroupBox();
            this.rb_pl4hard = new System.Windows.Forms.RadioButton();
            this.rb_pl4easy = new System.Windows.Forms.RadioButton();
            this.rb_pl4medium = new System.Windows.Forms.RadioButton();
            this.gb_player5 = new System.Windows.Forms.GroupBox();
            this.rb_pl5hard = new System.Windows.Forms.RadioButton();
            this.rb_pl5easy = new System.Windows.Forms.RadioButton();
            this.rb_pl5medium = new System.Windows.Forms.RadioButton();
            this.gb_nbplayers.SuspendLayout();
            this.gb_player2.SuspendLayout();
            this.gb_player3.SuspendLayout();
            this.gb_player4.SuspendLayout();
            this.gb_player5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jeu du Stupide Vautour";
            // 
            // btn_begin
            // 
            this.btn_begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_begin.Location = new System.Drawing.Point(74, 229);
            this.btn_begin.Name = "btn_begin";
            this.btn_begin.Size = new System.Drawing.Size(100, 60);
            this.btn_begin.TabIndex = 4;
            this.btn_begin.Text = "Lancer la Partie";
            this.btn_begin.UseVisualStyleBackColor = true;
            this.btn_begin.Click += new System.EventHandler(this.btn_begin_Click);
            // 
            // gb_nbplayers
            // 
            this.gb_nbplayers.Controls.Add(this.rb_5players);
            this.gb_nbplayers.Controls.Add(this.rb_4players);
            this.gb_nbplayers.Controls.Add(this.rb_3players);
            this.gb_nbplayers.Controls.Add(this.rb_2players);
            this.gb_nbplayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_nbplayers.Location = new System.Drawing.Point(12, 107);
            this.gb_nbplayers.Name = "gb_nbplayers";
            this.gb_nbplayers.Size = new System.Drawing.Size(162, 116);
            this.gb_nbplayers.TabIndex = 1;
            this.gb_nbplayers.TabStop = false;
            this.gb_nbplayers.Text = "Nombre de Joueurs";
            // 
            // rb_5players
            // 
            this.rb_5players.AutoSize = true;
            this.rb_5players.Location = new System.Drawing.Point(6, 88);
            this.rb_5players.Name = "rb_5players";
            this.rb_5players.Size = new System.Drawing.Size(97, 24);
            this.rb_5players.TabIndex = 0;
            this.rb_5players.Text = "5 Joueurs";
            this.rb_5players.UseVisualStyleBackColor = true;
            this.rb_5players.CheckedChanged += new System.EventHandler(this.rb_5players_CheckedChanged);
            // 
            // rb_4players
            // 
            this.rb_4players.AutoSize = true;
            this.rb_4players.Location = new System.Drawing.Point(6, 65);
            this.rb_4players.Name = "rb_4players";
            this.rb_4players.Size = new System.Drawing.Size(97, 24);
            this.rb_4players.TabIndex = 0;
            this.rb_4players.Text = "4 Joueurs";
            this.rb_4players.UseVisualStyleBackColor = true;
            this.rb_4players.CheckedChanged += new System.EventHandler(this.rb_4players_CheckedChanged);
            // 
            // rb_3players
            // 
            this.rb_3players.AutoSize = true;
            this.rb_3players.Location = new System.Drawing.Point(6, 42);
            this.rb_3players.Name = "rb_3players";
            this.rb_3players.Size = new System.Drawing.Size(97, 24);
            this.rb_3players.TabIndex = 0;
            this.rb_3players.Text = "3 Joueurs";
            this.rb_3players.UseVisualStyleBackColor = true;
            this.rb_3players.CheckedChanged += new System.EventHandler(this.rb_3players_CheckedChanged);
            // 
            // rb_2players
            // 
            this.rb_2players.AutoSize = true;
            this.rb_2players.Checked = true;
            this.rb_2players.Location = new System.Drawing.Point(6, 19);
            this.rb_2players.Name = "rb_2players";
            this.rb_2players.Size = new System.Drawing.Size(97, 24);
            this.rb_2players.TabIndex = 0;
            this.rb_2players.TabStop = true;
            this.rb_2players.Text = "2 Joueurs";
            this.rb_2players.UseVisualStyleBackColor = true;
            this.rb_2players.CheckedChanged += new System.EventHandler(this.rb_2players_CheckedChanged);
            // 
            // gb_player2
            // 
            this.gb_player2.Controls.Add(this.rb_pl2hard);
            this.gb_player2.Controls.Add(this.rb_pl2medium);
            this.gb_player2.Controls.Add(this.rb_pl2easy);
            this.gb_player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_player2.Location = new System.Drawing.Point(180, 107);
            this.gb_player2.Name = "gb_player2";
            this.gb_player2.Size = new System.Drawing.Size(95, 100);
            this.gb_player2.TabIndex = 3;
            this.gb_player2.TabStop = false;
            this.gb_player2.Text = "Joueur 2 - IA";
            // 
            // rb_pl2hard
            // 
            this.rb_pl2hard.AutoSize = true;
            this.rb_pl2hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl2hard.Location = new System.Drawing.Point(6, 73);
            this.rb_pl2hard.Name = "rb_pl2hard";
            this.rb_pl2hard.Size = new System.Drawing.Size(69, 20);
            this.rb_pl2hard.TabIndex = 1;
            this.rb_pl2hard.Text = "Difficile";
            this.rb_pl2hard.UseVisualStyleBackColor = true;
            // 
            // rb_pl2medium
            // 
            this.rb_pl2medium.AutoSize = true;
            this.rb_pl2medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl2medium.Location = new System.Drawing.Point(6, 47);
            this.rb_pl2medium.Name = "rb_pl2medium";
            this.rb_pl2medium.Size = new System.Drawing.Size(82, 20);
            this.rb_pl2medium.TabIndex = 1;
            this.rb_pl2medium.Text = "Moyenne";
            this.rb_pl2medium.UseVisualStyleBackColor = true;
            // 
            // rb_pl2easy
            // 
            this.rb_pl2easy.AutoSize = true;
            this.rb_pl2easy.Checked = true;
            this.rb_pl2easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl2easy.Location = new System.Drawing.Point(6, 21);
            this.rb_pl2easy.Name = "rb_pl2easy";
            this.rb_pl2easy.Size = new System.Drawing.Size(63, 20);
            this.rb_pl2easy.TabIndex = 1;
            this.rb_pl2easy.TabStop = true;
            this.rb_pl2easy.Text = "Facile";
            this.rb_pl2easy.UseVisualStyleBackColor = true;
            // 
            // gb_player3
            // 
            this.gb_player3.Controls.Add(this.rb_pl3hard);
            this.gb_player3.Controls.Add(this.rb_pl3easy);
            this.gb_player3.Controls.Add(this.rb_pl3medium);
            this.gb_player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_player3.Location = new System.Drawing.Point(281, 107);
            this.gb_player3.Name = "gb_player3";
            this.gb_player3.Size = new System.Drawing.Size(95, 100);
            this.gb_player3.TabIndex = 3;
            this.gb_player3.TabStop = false;
            this.gb_player3.Text = "Joueur 3 - IA";
            // 
            // rb_pl3hard
            // 
            this.rb_pl3hard.AutoSize = true;
            this.rb_pl3hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl3hard.Location = new System.Drawing.Point(6, 73);
            this.rb_pl3hard.Name = "rb_pl3hard";
            this.rb_pl3hard.Size = new System.Drawing.Size(69, 20);
            this.rb_pl3hard.TabIndex = 1;
            this.rb_pl3hard.Text = "Difficile";
            this.rb_pl3hard.UseVisualStyleBackColor = true;
            // 
            // rb_pl3easy
            // 
            this.rb_pl3easy.AutoSize = true;
            this.rb_pl3easy.Checked = true;
            this.rb_pl3easy.Location = new System.Drawing.Point(6, 21);
            this.rb_pl3easy.Name = "rb_pl3easy";
            this.rb_pl3easy.Size = new System.Drawing.Size(63, 20);
            this.rb_pl3easy.TabIndex = 1;
            this.rb_pl3easy.TabStop = true;
            this.rb_pl3easy.Text = "Facile";
            this.rb_pl3easy.UseVisualStyleBackColor = true;
            // 
            // rb_pl3medium
            // 
            this.rb_pl3medium.AutoSize = true;
            this.rb_pl3medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl3medium.Location = new System.Drawing.Point(6, 47);
            this.rb_pl3medium.Name = "rb_pl3medium";
            this.rb_pl3medium.Size = new System.Drawing.Size(82, 20);
            this.rb_pl3medium.TabIndex = 1;
            this.rb_pl3medium.Text = "Moyenne";
            this.rb_pl3medium.UseVisualStyleBackColor = true;
            // 
            // gb_player4
            // 
            this.gb_player4.Controls.Add(this.rb_pl4hard);
            this.gb_player4.Controls.Add(this.rb_pl4easy);
            this.gb_player4.Controls.Add(this.rb_pl4medium);
            this.gb_player4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_player4.Location = new System.Drawing.Point(382, 107);
            this.gb_player4.Name = "gb_player4";
            this.gb_player4.Size = new System.Drawing.Size(95, 100);
            this.gb_player4.TabIndex = 3;
            this.gb_player4.TabStop = false;
            this.gb_player4.Text = "Joueur 4 - IA";
            // 
            // rb_pl4hard
            // 
            this.rb_pl4hard.AutoSize = true;
            this.rb_pl4hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl4hard.Location = new System.Drawing.Point(6, 73);
            this.rb_pl4hard.Name = "rb_pl4hard";
            this.rb_pl4hard.Size = new System.Drawing.Size(69, 20);
            this.rb_pl4hard.TabIndex = 1;
            this.rb_pl4hard.Text = "Difficile";
            this.rb_pl4hard.UseVisualStyleBackColor = true;
            // 
            // rb_pl4easy
            // 
            this.rb_pl4easy.AutoSize = true;
            this.rb_pl4easy.Checked = true;
            this.rb_pl4easy.Location = new System.Drawing.Point(6, 21);
            this.rb_pl4easy.Name = "rb_pl4easy";
            this.rb_pl4easy.Size = new System.Drawing.Size(63, 20);
            this.rb_pl4easy.TabIndex = 1;
            this.rb_pl4easy.TabStop = true;
            this.rb_pl4easy.Text = "Facile";
            this.rb_pl4easy.UseVisualStyleBackColor = true;
            // 
            // rb_pl4medium
            // 
            this.rb_pl4medium.AutoSize = true;
            this.rb_pl4medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl4medium.Location = new System.Drawing.Point(6, 47);
            this.rb_pl4medium.Name = "rb_pl4medium";
            this.rb_pl4medium.Size = new System.Drawing.Size(82, 20);
            this.rb_pl4medium.TabIndex = 1;
            this.rb_pl4medium.Text = "Moyenne";
            this.rb_pl4medium.UseVisualStyleBackColor = true;
            // 
            // gb_player5
            // 
            this.gb_player5.Controls.Add(this.rb_pl5hard);
            this.gb_player5.Controls.Add(this.rb_pl5easy);
            this.gb_player5.Controls.Add(this.rb_pl5medium);
            this.gb_player5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_player5.Location = new System.Drawing.Point(483, 107);
            this.gb_player5.Name = "gb_player5";
            this.gb_player5.Size = new System.Drawing.Size(95, 100);
            this.gb_player5.TabIndex = 3;
            this.gb_player5.TabStop = false;
            this.gb_player5.Text = "Joueur 5 - IA";
            // 
            // rb_pl5hard
            // 
            this.rb_pl5hard.AutoSize = true;
            this.rb_pl5hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl5hard.Location = new System.Drawing.Point(6, 73);
            this.rb_pl5hard.Name = "rb_pl5hard";
            this.rb_pl5hard.Size = new System.Drawing.Size(69, 20);
            this.rb_pl5hard.TabIndex = 1;
            this.rb_pl5hard.Text = "Difficile";
            this.rb_pl5hard.UseVisualStyleBackColor = true;
            // 
            // rb_pl5easy
            // 
            this.rb_pl5easy.AutoSize = true;
            this.rb_pl5easy.Checked = true;
            this.rb_pl5easy.Location = new System.Drawing.Point(6, 21);
            this.rb_pl5easy.Name = "rb_pl5easy";
            this.rb_pl5easy.Size = new System.Drawing.Size(63, 20);
            this.rb_pl5easy.TabIndex = 1;
            this.rb_pl5easy.TabStop = true;
            this.rb_pl5easy.Text = "Facile";
            this.rb_pl5easy.UseVisualStyleBackColor = true;
            // 
            // rb_pl5medium
            // 
            this.rb_pl5medium.AutoSize = true;
            this.rb_pl5medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pl5medium.Location = new System.Drawing.Point(6, 47);
            this.rb_pl5medium.Name = "rb_pl5medium";
            this.rb_pl5medium.Size = new System.Drawing.Size(82, 20);
            this.rb_pl5medium.TabIndex = 1;
            this.rb_pl5medium.Text = "Moyenne";
            this.rb_pl5medium.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.btn_begin);
            this.Controls.Add(this.gb_player3);
            this.Controls.Add(this.gb_player5);
            this.Controls.Add(this.gb_player4);
            this.Controls.Add(this.gb_player2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_nbplayers);
            this.Name = "Menu";
            this.Text = "Stupide Vautour -- By Begou-Comte-Mourier -- Menu du Jeu";
            this.gb_nbplayers.ResumeLayout(false);
            this.gb_nbplayers.PerformLayout();
            this.gb_player2.ResumeLayout(false);
            this.gb_player2.PerformLayout();
            this.gb_player3.ResumeLayout(false);
            this.gb_player3.PerformLayout();
            this.gb_player4.ResumeLayout(false);
            this.gb_player4.PerformLayout();
            this.gb_player5.ResumeLayout(false);
            this.gb_player5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_begin;
        private System.Windows.Forms.GroupBox gb_nbplayers;
        private System.Windows.Forms.RadioButton rb_2players;
        private System.Windows.Forms.RadioButton rb_3players;
        private System.Windows.Forms.RadioButton rb_4players;
        private System.Windows.Forms.RadioButton rb_5players;
        private System.Windows.Forms.GroupBox gb_player2;
        private System.Windows.Forms.RadioButton rb_pl2easy;
        private System.Windows.Forms.RadioButton rb_pl2medium;
        private System.Windows.Forms.RadioButton rb_pl2hard;
        private System.Windows.Forms.GroupBox gb_player3;
        private System.Windows.Forms.RadioButton rb_pl3easy;
        private System.Windows.Forms.RadioButton rb_pl3medium;
        private System.Windows.Forms.RadioButton rb_pl3hard;
        private System.Windows.Forms.GroupBox gb_player4;
        private System.Windows.Forms.RadioButton rb_pl4easy;
        private System.Windows.Forms.RadioButton rb_pl4medium;
        private System.Windows.Forms.RadioButton rb_pl4hard;
        private System.Windows.Forms.GroupBox gb_player5;
        private System.Windows.Forms.RadioButton rb_pl5easy;
        private System.Windows.Forms.RadioButton rb_pl5medium;
        private System.Windows.Forms.RadioButton rb_pl5hard;
    }
}