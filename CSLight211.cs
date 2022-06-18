using System;
using System.Collections.Generic;

namespace CSLight211
{
    class Program
    {
        static void Main(string[] args)
        {
            int suitAmount = 4;
            int valueAmount = 9;
            Deck playingCardDeck = new Deck(suitAmount, valueAmount);
            
            Player player = new Player();

            bool isRunning = true;

            while (isRunning)
            {
                Console.SetCursorPosition(35, 12);
                Console.WriteLine("На столе лежит колода карт. Вы можете брать по одной,");
                Console.SetCursorPosition(30, 13);
                Console.WriteLine("пока не решите, что Вам хватит карт.\n\n");
                Console.SetCursorPosition(70, 15);
                Console.WriteLine("Нажмите любую клавишу для продолжения...");

                Console.ReadKey();
                Console.Clear();

                Console.SetCursorPosition(40, 4);
                Console.WriteLine("1: Взять карту.");
                Console.SetCursorPosition(40, 5);
                Console.WriteLine("2: Закончить раздачу.\n");

                playingCardDeck.ShowDeck();

                /*
                switch (Console.ReadLine())
                {
                    case "1":
                        player.TakeCard(playingCardDeck);
                        break;
                    case "2":
                        Console.WriteLine("\tВы переворачиваете карты рубашкой вниз, чтобы посмотреть, что у Вас на руках.\n");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\tНе буянь, введи 1 или 2.");
                        break;
                }

                player.ShowTheHand();
                */
                Console.ReadKey();
            }
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>() { new Card(CardSuit.Clubs, CardValue.Ace) };

        public Player ()
        {
            _hand.RemoveAt(0);
        }

        public void TakeCard(Deck cardDeck)
        {
            _hand.Add(cardDeck.TakeCard());
        }

        public void ShowTheHand ()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card);
            }
        }
    }

    class Deck
    {
        private int _suitAmount;
        private int _valueAmount;
        private List<Card> _cardDeck = new List<Card>() {new Card(CardSuit.Clubs, CardValue.Ace)};

        public Deck (int suitAmoint, int valueAmount)
        {
            _cardDeck.RemoveAt(0);

            _suitAmount = suitAmoint;
            _valueAmount = valueAmount;

            for (int i = 0; i < _suitAmount; i++)
            {
                for (int j = 0; j < _valueAmount; j++)
                {
                    CardSuit suit = (CardSuit)i;
                    CardValue value = (CardValue)j;

                    Card card = new Card(suit, value);

                    _cardDeck.Add(card);
                }
            }
        }

        public void ShowDeck ()
        {
            foreach (var card in _cardDeck)
            {
                Console.WriteLine(card);
            }
        }

        public Card TakeCard ()
        {
            Random random = new Random();
            int removebleIndex = random.Next(0,_cardDeck.Count);

            Card randomCard = _cardDeck[removebleIndex];
            _cardDeck.RemoveAt(removebleIndex);

            return randomCard;
        }
    }


    class Card
    {
        private CardSuit _suit;
        private CardValue _value;

        public Card (CardSuit suit, CardValue value)
        {
            _suit = suit;
            _value = value;
        }
    }

    enum CardSuit
    {
        Diamonds,
        Clubs,
        Hearts,
        Spaders
    }

    enum CardValue
    {
        Ace,
        King,
        Queen,
        Jack,
        Ten,
        Nine,
        Eight,
        Seven,
        Six
    }
}
