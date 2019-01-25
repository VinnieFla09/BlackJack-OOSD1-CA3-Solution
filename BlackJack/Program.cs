/* =====================================================
 *
 * File:                    BlackJackAssignment.cs
 *
 * Date:                    December 2018
 * 
 * Student Number:          s12345678 
 *
 * Classes:                 Program, Card, Deck
 * 

 * -----------------------------------------------
 * Program Description:
 * 
 * Create a program which mimics a game of Blackjack (21)
 *
 * ======================================================
 */


// ALGORITHM:
// Create a deck of cards
// Shuffle Cards
// Deal 2 cards for User
// Give score - check that not bust
// Ask user if they want to stick or twist
// If twist give another card
// Calculate score
// Ask if stick or twist - loop until stick or bust
// Dealer plays
// Get 2 cards
// Get score
// While under 17 get another card - repeat
// Compare scores
// Ask if user wants to play again



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            do
            {
                deck.Shuffle();

                DisplayTitleBox();

                int playerScore = PlayerTurn(deck);

                if (playerScore > 21)
                {
                    Console.WriteLine("Sorry but you are bust");
                }
                else
                {
                    int dealerScore = DealerTurn(deck);
                    if (dealerScore > 21)
                        Console.WriteLine("Dealer bust, player wins");
                    else
                        DetermineWinner(playerScore, dealerScore);
                }
            }
            while (PlayAgain());

            Console.WriteLine("Thanks for playing, hit enter to exit");

            Console.ReadLine();

        }

        private static bool PlayAgain()
        {
            bool playAgain = false;
            string response = "";

            do
            {
                Console.WriteLine("Would you like to play again - Y/N");
                response = Console.ReadLine().ToLower();
            } while (!IsValidInput(response, "y", "yes", "n", "no"));

            if (response.Equals("Yes") | response.Equals("y"))
                playAgain = true;

            return playAgain;
        }

        private static void DetermineWinner(int playerScore, int dealerScore)
        {
            if (playerScore > dealerScore)
                Console.WriteLine("Player wins");
            else if (dealerScore > playerScore)
                Console.WriteLine("Dealer wins");
            else
                Console.WriteLine("It a draw");

        }

        private static int DealerTurn(Deck deck)
        {
            int dealerScore = 0;
            Card c;

            Console.WriteLine("Dealers turn");

            while (dealerScore < 17)
            {
                c = deck.GetNextCard();
                Console.WriteLine(c);
                dealerScore += GetCardValue(c);
                Console.WriteLine("Total score is {0}", dealerScore);
            }

            return dealerScore;
        }

        private static int PlayerTurn(Deck deck)
        {
            int playerScore = 0;

            //Deal 2 cards for User
            Card c1 = deck.GetNextCard();
            Card c2 = deck.GetNextCard();

            //Describe Cards
            Console.WriteLine(c1);
            Console.WriteLine(c2);

            // Give score - check that not bust
            playerScore = GetCardValue(c1) + GetCardValue(c2);
            Console.WriteLine(string.Format("Your score is {0}", playerScore));

            //// Ask if stick or twist - loop until stick or bust
            bool twist = true;
            while (playerScore < 21 & twist)
            {
                string response = "";
                do
                {
                    Console.WriteLine("Do you want to stick or twist - select S or T ?");
                    response = Console.ReadLine().ToLower();
                } while (!IsValidInput(response, "s", "stick", "t", "twist"));

                if (response.Equals("t") | response.Equals("twist"))
                {
                    Console.WriteLine("Twist selected");

                    // If twist give another card
                    Card nextCard = deck.GetNextCard();
                    Console.WriteLine(nextCard);

                    // Calculate score
                    playerScore += GetCardValue(nextCard);
                    Console.WriteLine(string.Format("Your score is {0}", playerScore));
                }
                else
                {
                    Console.WriteLine("Stick selected");
                    twist = false;
                }

            }
            return playerScore;
        }

        //TitleBox - Print a Title Box to console
        public static void DisplayTitleBox()
        {
            Console.WindowHeight = 25;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            //Console.CursorVisible = true;
            Console.WriteLine("\t\t\t******************************");
            Console.WriteLine("\t\t\t*                            *");
            Console.WriteLine("\t\t\t*     BLACKJACK EMPORIUM     *");
            Console.WriteLine("\t\t\t*                            *");
            Console.WriteLine("\t\t\t******************************");
        }//End of TitleBox

        private static bool IsValidInput(string input, params string[] validInput)
        {
            bool valid = false;
            foreach (string s in validInput)
            {
                if (s.Equals(input))
                {
                    valid = true;
                    break;
                }
            }

            if (!valid)
            {
                Console.WriteLine("Invalid input");
            }

            return valid;
        }

        private static int GetCardValue(Card c)
        {
            int value = 0;

            switch (c.CardName)
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
                    value = Convert.ToInt32(c.CardName);
                    break;
            }

            return value;
        }

        
    }
}
