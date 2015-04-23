using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class IAStupid : Player
    {
     public IAStupid (int i) : base()
    {
        super(i);
        super.setName("Stupid");
    }
    public PlayerCard play() {
        Random i = new Random();
        return base.getListPlayerCard().get(i.nextInt(number));
    }
    
    }
}
