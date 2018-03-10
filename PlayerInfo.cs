using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ECardCSharp
{
    abstract class Player
    {
        private int winCnt;
        public int WinCnt { get => winCnt; set => winCnt = value; }


        private int[] deck;

        protected int[] Deck { get => deck; set => deck = value; }
        private int[] pDeck { get => deck; }

        public Player()
        {
        }

        public abstract void ShuffleDeck();

        public void PrintCards()
        {
            foreach(var card in deck)
            {
                Console.Write(card + " ");
            }
            Console.WriteLine();
        }

        public bool? Play(Player opponent)
        {
            winCnt = 0;
            opponent.WinCnt = 0;

            foreach (int idx in Enumerable.Range(0, Constants.DeckCount))
            {
                if (this.deck[idx].Equals((int)Constants.Card.Citizen))
                {
                    if (opponent.pDeck[idx].Equals((int)Constants.Card.Slave))
                    {
                        return true;
                    }
                    else if (opponent.pDeck[idx].Equals((int)Constants.Card.Emperor))
                    {
                        return false;
                    }
                    else continue;
                }
                else if (this.deck[idx].Equals((int)Constants.Card.Emperor))
                {
                    if (opponent.pDeck[idx].Equals((int)Constants.Card.Citizen))
                    {
                        return true;
                    }
                    else if (opponent.pDeck[idx].Equals((int)Constants.Card.Slave))
                    {
                        return false;
                    }
                    else continue;
                }
                else if (this.deck[idx].Equals((int)Constants.Card.Slave))
                {
                    if (opponent.pDeck[idx].Equals((int)Constants.Card.Emperor))
                    {
                        return true;
                    }
                    else if (opponent.pDeck[idx].Equals((int)Constants.Card.Citizen))
                    {
                        return false;
                    }
                    else continue;
                }
            }
            return null;
        }
    }

    class EmperorPlayer : Player
    {

        public EmperorPlayer()
        {
            Deck = new int[Constants.DeckCount];
            Deck[0] = (int)Constants.Card.Emperor;
            foreach (int i in Enumerable.Range(1, Deck.Length - 1))
            {
                Deck[i] = (int)Constants.Card.Citizen;
            }
        }

        public void SetEmperorLocation(int locationPm)
        {
            foreach (int deckIdx in Enumerable.Range(0, Constants.DeckCount))
            {
                Deck[deckIdx] = (int)Constants.Card.Citizen;
            }
            Deck[locationPm] = (int)Constants.Card.Emperor;
        }

        public override void ShuffleDeck()
        {
            Random random1 = new Random();

            foreach (int idx in Enumerable.Range(0, Deck.Length))
            {
                Deck[idx] = (int)Constants.Card.Citizen;
            }

            int rand = random1.Next(Deck.Length - 1);
            Deck[rand] = (int)Constants.Card.Emperor;
            Thread.Sleep(100);
        }
    }

    class SlavePlayer : Player
    {

        public SlavePlayer()
        {
            Deck = new int[Constants.DeckCount];
            Deck[0] = (int)Constants.Card.Slave;
            foreach (int i in Enumerable.Range(1, Deck.Length - 1))
            {
                Deck[i] = (int)Constants.Card.Citizen;
            }
        }

        public void SetSlaveLocation(int locationPm)
        {
            foreach (int deckIdx in Enumerable.Range(0, Constants.DeckCount))
            {
                Deck[deckIdx] = (int)Constants.Card.Citizen;
            }
            Deck[locationPm] = (int)Constants.Card.Slave;
        }

        public override void ShuffleDeck()
        {
            Random random1 = new Random();

            foreach (int idx in Enumerable.Range(0, Deck.Length))
            {
                Deck[idx] = (int)Constants.Card.Citizen;
            }

            Random random2 = new Random(random1.Next());
            int rand = random2.Next(Deck.Length - 1);
            Deck[rand] = (int)Constants.Card.Slave;
            Thread.Sleep(100);
        }
    }
}
