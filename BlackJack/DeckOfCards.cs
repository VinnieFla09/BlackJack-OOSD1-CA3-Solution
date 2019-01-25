using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class DeckOfCards
    {

        private string[] suits = { "Clubs", "Hearts", "Diamonds", "Spades" };
        private int currentCard;

        public Card[,] CardCollection { get; set; }

        //CONSTRUCTOR FOR DECK OF CARDS
        public DeckOfCards()
        {
            CardCollection = new Card[4, 13];

            //Give values to Cards
            //Loop through rows
            for (int i = 0; i < CardCollection.GetLength(0); i++)
            {
                //Loop through columns
                for (int j = 1; j <= CardCollection.GetLength(1); j++)
                {
                    Card c = new Card();
                    switch (j)
                    {
                        case 1:
                            c.CardName = "Ace";
                            break;
                        case 11:
                            c.CardName = "Jack";
                            break;
                        case 12:
                            c.CardName = "Queen";
                            break;
                        case 13:
                            c.CardName = "King";
                            break;
                        default:
                            c.CardName = j.ToString();
                            break;
                    }

                    c.Suit = suits[i];

                    CardCollection[i, j - 1] = c;

                }//end of for
            }//end of for

            //set current card to 0
            currentCard = 0;

        }

        //SHUFFLES THE DECK
        public void Shuffle()
        {
            Random ran = new Random();

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 13; j++)
                {
                    int randomSuit = ran.Next(0, 4);
                    int randomCardFace = ran.Next(0, 13);

                    Card temp = CardCollection[randomSuit, randomCardFace];
                    CardCollection[randomSuit, randomCardFace] = CardCollection[i, j];
                    CardCollection[i, j] = temp;

                }
            }

            currentCard = 0;
        }

        //RETURNS THE NEXT CARD IN THE DECK
        public Card GetNextCard()
        {
            //Cards are in a 2D array - 4 x 13 cards, need to move along one card at a time

            int col = currentCard % 13; //gets the next card column number
            int row = currentCard / 13; //gets the next card row number

            currentCard++;              //counting the cards in the deck from 0 - 52

            return CardCollection[row, col];
        }

    }
}
