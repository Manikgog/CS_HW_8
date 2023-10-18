using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    internal class Card
    {
        private cardSuit suit;
        private cardDignity dignity;

        public Card(cardSuit suit, cardDignity dignity)
        {
            this.suit=suit;
            this.dignity=dignity;
        }

        public cardDignity GetDignity()
        {
            return this.dignity;
        }



        public override string ToString()
        {
            return dignity.ToString() + ' ' +suit.ToString();
        }
    }
}
