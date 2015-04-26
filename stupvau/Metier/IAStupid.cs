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
        Random i = new Random();
        return base.getListPlayerCard()[i.Next(number)];
    }
    
    }
}
