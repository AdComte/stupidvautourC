using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class Human : Player
    {
        public Human(int i) : base(i){}

        public override PlayerCard play(Table table)
        {
            throw new Exception();
        }

    }
}
