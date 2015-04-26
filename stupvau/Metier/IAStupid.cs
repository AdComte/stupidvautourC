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
    public override PlayerCard play(Table table) {
        Console.WriteLine("Le joueur possède les cartes suivantes :");
        foreach(PlayerCard p in getListPlayerCard())
        {
            Console.Write(p.getValue() + "|");
        }
        Console.WriteLine();
        Random i = new Random();
        int indice = i.Next(this.getListPlayerCard().Count);
        Console.WriteLine("L'IA_stupid "+ this.getCouleur() + " joue sa carte " + indice);
        PlayerCard played = new PlayerCard(indice, false, this.getCouleur());
        this.getListPlayerCard().RemoveAt(indice);
        return played;
    }
    
    }
}
