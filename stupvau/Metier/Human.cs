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
			return null;
		}

		public override PlayerCard play(int selected)
		{
			return new PlayerCard(selected, false, getCouleur());
		}
    }
}
