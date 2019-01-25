using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public string CardName { get; set; }

        public string Suit { get; set; }

        private string _colour;
        public string CardColour
        {
            get
            {
                //add logic here to determine colour
                switch(Suit)
                {
                    case "Clubs":
                    case "Spades":
                        _colour = "Black";
                        break;
                        

                }
            }

        }


        public int GetValue()
        {
            int value = 0;

            switch (CardName)
            {
                case "Ace":
                    value = 11;
                    break;
                case "Jack":
                case "Queen":
                case "King":
                    value = 10;
                    break;
                default:
                    value = Convert.ToInt32(CardName);
                    break;
            }

            return value;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", CardName, Suit);
        }


    }
}
