/*
 Создать модель карточной игры. 
Требования:
1. Класс Game формирует и обеспечивает:
   1.1.1. Список игроков (минимум 2,максимум 6);
   1.1.2. Колоду карт (36 карт);
   1.1.3. Перетасовку карт (случайным образом);
   1.1.4. Раздачу карт игрокам (равными частями каждому игроку);
   1.1.5. Игровой процесс. 
             Принцип: Игроки кладут по одной карте. У кого карта больше, то тот игрок  
                               забирает все карты и кладёт их в конец своей колоды. 
             Упрощение: при совпадении карт - забирает первый игрок, шестёрка не  
                                   забирает туза. Выигрывает игрок, который забрал все карты.
2. Класс Player - набор имеющихся карт, вывод имеющихся карт.
3. Класс Karta - масть и тип карты (6-10, валет, дама, король, туз).
4. При решении задачи использовать коллекции.
 */

using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(6);
            while (game.playersTurn())
            { }
            Console.ReadKey();
        }
    }
    public class Game
    {
        public List<Card> cardDeck;
        public List<Player> players;
        private Random random;
        private int cardsAmount = 36;
        public Game(int playersCount = 2)
        {
            random = new Random();
            players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player());
            }
            cardDeck = createCardDeck();
            shuffleCards(cardDeck);
            dealCardsToPlayers(players, cardDeck);
        }

        public List<Card> createCardDeck()
        {
            cardDeck = new List<Card>();
            int suitCount = cardsAmount / 4;
            for (int i = 0; i < suitCount; i++)
            {
                cardDeck.Add(new Card((CardValue)i, (CardSuit)0));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)1));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)2));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)3));
            }
            return cardDeck;
        }

        public void shuffleCards(List<Card> cards)
        {
            cards.Sort((a, b) => random.Next(-2, 2));
        }

        public void dealCardsToPlayers(List<Player> players, List<Card> cards)
        {
            int currentPlayer = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                players[currentPlayer].cards.Add(cards[i]);
                currentPlayer++;
                currentPlayer %= players.Count;
            }
        }

        public bool playersTurn()
        {
            Console.WriteLine("\nХод игроков:\n");
            Console.WriteLine("Игрок\tКол-во карт\tХод картой");
            int maxValue = -1;
            Player playerWithMaxValue = null;
            Stack<Card> cardStack = new Stack<Card>();
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                if (player.cards.Count > 0)
                {
                    Card card = player.cards[random.Next(player.cards.Count)];
                    Console.WriteLine($"{i}\t{player.cards.Count}\t\t{card}");
                    player.cards.Remove(card);
                    if ((int)card.value > maxValue)
                    {
                        maxValue = (int)card.value;
                        playerWithMaxValue = player;
                    }
                    cardStack.Push(card);
                }
            }
            playerWithMaxValue.cards.AddRange(cardStack);
            Console.WriteLine($"Забрал игрок {players.IndexOf(playerWithMaxValue)}.");
            if (playerWithMaxValue.cards.Count == cardsAmount)
            {
                Console.WriteLine($"Победил игрок номер {players.IndexOf(playerWithMaxValue)}");
                return false;
            }
            return true;
        }
    }

    public class Player
    {
        public List<Card> cards = new List<Card>();
    }
    public enum CardValue
    {
        Шесть = 0, Семь, Восемь, Девять, Десять, Валет, Дама, Король, Туз
    }
    public enum CardSuit
    {
        Черва = 0, Буба, Трефа, Пика
    }
    public class Card
    {
        public readonly CardValue value;
        public readonly CardSuit suit;
        public Card(CardValue value, CardSuit suit)
        {
            this.value = value;
            this.suit = suit;
        }
        public override string ToString()
        {
            return $"{value} {suit}";
        }
    }
}
