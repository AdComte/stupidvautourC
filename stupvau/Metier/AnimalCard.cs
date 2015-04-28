using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stupvau.Metier
{
    class AnimalCard : Card
    {
        private bool vulture;

        public AnimalCard(int number, bool vulture)
            : base(number)
        {
            this.vulture = vulture;
        }

        public bool getAnimal()
        {
            return this.vulture;
        }
    }
}
