using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class AnimalCard
    {
        private bool vulture;

        public AnimalCard(int number, bool vulture)
            : base()
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
