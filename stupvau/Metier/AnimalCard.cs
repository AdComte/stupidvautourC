using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class AnimalCard : Card
    {
        private bool vulture;
        //ee
        public AnimalCard(int number, bool vulture)
            : base(number)
        {
            //super(number);
            this.vulture = vulture;
        }

        public bool getAnimal()
        {
            return this.vulture;
        }
    }
}
