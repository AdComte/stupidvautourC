using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class IAStupid : Player
    {
     public IAStupid (int i) : base(i)
    {
        base.setName("Stupid");
    }
	 public override PlayerCard play(int selected)
	{
		return null;
	}

    public override PlayerCard play(Table table) {
        Console.WriteLine("Le joueur possède les cartes suivantes :");
        for (int k = 0; k < 15;k++ )
        {
            if(this.listPlayerCard[k,0]!=0)
             Console.Write(this.listPlayerCard[k,0] + "|");
        }
        Console.WriteLine();


        ////////////// test :!!!!!!!!!////////////////////
        //Console.WriteLine("--------------TEST---------------");
        //int j;
        //for (j = 0; j < 15; j++)
        //{
        //    int z = this.getRandom().Next(10);
        //    Console.Write(z + " | ");
        //}
        //Console.WriteLine("--------------FIN-TEST---------------");
        //Console.WriteLine("menglon : "+ this.getCouleur());
        ///////////


        int indice = this.getRandom().Next(1, this.nbCartesRestantes);

		Random r = new Random();
		IList<int> dispo = new List<int>();
		for (int i = 0; i < 15; i++)
		{
			if (this.listPlayerCard[i, 0] != 0) dispo.Add(i);
		}
		int indice2 = dispo.ElementAt(r.Next(this.nbCartesRestantes));
		PlayerCard p = new PlayerCard(indice2, false, this.getCouleur());
		this.removeCard(indice2);
		return p;
    }

    }
}
