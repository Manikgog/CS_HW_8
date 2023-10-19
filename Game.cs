using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_HW_8
{
    public enum cardSuit {clubs, diamonds, hearts, spades };
    public enum cardDignity {six = 6, seven,  eight, nine, ten, jack, queen, king, ace};

    public delegate void FinishDelegate(string t);
    internal class Game
    {
        
        static void Main(string[] args)
        {
            //Card_Game();
            Car_Racing();
        }


        public static void Car_Racing()
        {
            /*
                Задание 1. Игра «Автомобильные гонки»
            Разработать игру "Автомобильные гонки" с использованием делегатов.
                1. В игре использовать несколько типов автомобилей:
            спортивные, легковые, грузовые и автобусы.
                2. Реализовать игру «Гонки». Принцип игры: Автомобили двигаются 
            от старта к финишу со скоростями,
            которые изменяются в установленных пределах
            случайным образом. Победителем считается автомобиль, 
            пришедший к финишу первым.

            Рекомендации по выполнению работы
                1. Разработать абстрактный класс «автомобиль»
            (класс Car). Собрать в нем все общие поля, свойства
            (например, скорость) методы (например, ехать).
                2. Разработать классы автомобилей с конкретной
            реализацией конструкторов и методов, свойств.
            В классы автомобилей добавить необходимые события (например, финиш).
                3. Класс игры должен производить запуск соревнований 
            автомобилей, выводить сообщения о текущем
            положении автомобилей, выводить сообщение об
            автомобиле, победившем в гонках. Создать делегаты, 
            обеспечивающие вызов методов из классов
            автомобилей (например, выйти на старт, начать
            гонку).
                4. Игра заканчивается, когда какой-то из автомобилей
            проехал определённое расстояние (старт в положении 0, 
            финиш в положении 100). Уведомление об окончании 
            гонки (прибытии какого-либо автомобиля на финиш) 
            реализовать с помощью событий.
             */

            Car car1 = new PassengerCar(12, "Lada", "Granta");
            Car car2 = new PassengerCar(12, "Lada", "Vesta");
            Car car3 = new PassengerCar(12, "Lada", "Largus");
            do
            {
                car1.Move();
                Thread.Sleep(1);
                car2.Move();
                Thread.Sleep(1);
                car3.Move();
                Thread.Sleep(1);
                Console.WriteLine(car1.ToString() + " проехала " + car1.GetOdometr() + " км.");
                Console.WriteLine(car2.ToString() + " проехала " + car2.GetOdometr() + " км.");
                Console.WriteLine(car3.ToString() + " проехала " + car3.GetOdometr() + " км.");
                Thread.Sleep(1000);
                Console.Clear();
                if (car1.GetOdometr() >= 100 || car2.GetOdometr() >= 100 || car3.GetOdometr() >= 100)
                {
                    Judge judge = new Judge();
                    if (car1.GetOdometr() >= 100)
                    {
                        judge.FinishEvent += Judge_FinishEvent;
                        judge.Finish(car1.ToString() + " проехала " + car1.GetOdometr() + " км.");
                    }
                    if (car2.GetOdometr() >= 100)
                    {
                        judge.FinishEvent += Judge_FinishEvent;
                        judge.Finish(car2.ToString() + " проехала " + car2.GetOdometr() + " км.");
                    }
                    if (car3.GetOdometr() >= 100)
                    {
                        judge.FinishEvent += Judge_FinishEvent;
                        judge.Finish(car2.ToString() + " проехала " + car2.GetOdometr() + " км.");
                    }
                    break;
                }
            } while (true);

            Console.ReadKey();

        }

        private static void Judge_FinishEvent(string t)
        {
            Console.WriteLine(t);
        }

        public static void Card_Game()
        {
            /*
                Задание 1. Программа «Карточная игра!»
            Создать модель карточной игры.
            Требования:
            1. Класс Game формирует и обеспечивает:
            1.1.1. Список игроков (минимум 2);
            1.1.2. Колоду карт (36 карт);
            1.1.3. Перетасовку карт (случайным образом);
            1.1.4. Раздачу карт игрокам (равными частями каждому
            игроку);
            1.1.5. Игровой процесс. Принцип: Игроки кладут по
            одной карте. У кого карта больше, то тот игрок
            забирает все карты и кладет их в конец своей
            колоды. Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает туза.
            Выигрывает игрок, который забрал все карты.
            2. Класс Player (набор имеющихся карт, вывод имеющихся карт).
            3. Класс Karta (масть и тип карты (6–10, валет, дама,
            король, туз).
            */
            List<Card> cards = CreatingOfDeck();
            Queue<Card>[] cardsOfPlayers = DistributionOfCardsToPlayers(cards);
            Queue<Card> queueOfPlayer_1 = cardsOfPlayers[0];    // карты первого игрока
            Queue<Card> queueOfPlayer_2 = cardsOfPlayers[1];    // карты второго игрока
            //Console.WriteLine("Карты первого игрока:");
            //foreach(Card card in queueOfPlayer_1)
            //{
            //    Console.WriteLine(card.ToString());
            //}
            //Console.WriteLine("Карты второго игрока:");
            //foreach (Card card in queueOfPlayer_2)
            //{
            //    Console.WriteLine(card.ToString());
            //}

            // определение кто ходит первым
            Random rnd = new Random();
            int firstMotion = rnd.Next(2) + 1;
            do
            {

                if (firstMotion == 1)
                {
                    Card cardOfPlayer_1 = queueOfPlayer_1.Dequeue();        // первый игрок кладёт карту на стол (объект класса Card извлекается из начала очереди)
                    Console.Write("Первый игрок: ");
                    Console.WriteLine(cardOfPlayer_1.ToString());
                    Card cardOfPlayer_2 = queueOfPlayer_2.Dequeue();        // второй игрок кладёт карту на стол (объект класса Card извлекается из начала очереди)
                    Console.Write("Второй игрок: ");
                    Console.WriteLine(cardOfPlayer_2.ToString());
                    if (cardOfPlayer_1.GetDignity() >= cardOfPlayer_2.GetDignity()) // если карта первого игрока больше или равна карте второго игрока, 
                    {                                                               // то карты уходят первому игроку
                        queueOfPlayer_1.Enqueue(cardOfPlayer_1);
                        queueOfPlayer_1.Enqueue(cardOfPlayer_2);
                        Console.WriteLine("Карты уходят первому игроку, у него " + queueOfPlayer_1.Count() + " карт");
                    }
                    else                                                            // иначе карты уходят второму игроку
                    {
                        queueOfPlayer_2.Enqueue(cardOfPlayer_1);
                        queueOfPlayer_2.Enqueue(cardOfPlayer_2);
                        Console.WriteLine("Карты уходят второму игроку, у него " + queueOfPlayer_2.Count() + " карт");
                    }
                    firstMotion = 2;        // переход хода ко второму игроку
                }
                else
                {
                    Card cardOfPlayer_1 = queueOfPlayer_1.Dequeue();        // первый игрок кладёт карту на стол (объект класса Card извлекается из начала очереди)
                    Console.Write("Первый игрок: ");
                    Console.WriteLine(cardOfPlayer_1.ToString());
                    Card cardOfPlayer_2 = queueOfPlayer_2.Dequeue();        // второй игрок кладёт карту на стол (объект класса Card извлекается из начала очереди)
                    Console.Write("Второй игрок: ");
                    Console.WriteLine(cardOfPlayer_2.ToString());
                    if (cardOfPlayer_2.GetDignity() >= cardOfPlayer_1.GetDignity())     // если карта первого игрока больше или равна карте второго игрока,
                    {                                                                   // то карты уходят второму игроку
                        queueOfPlayer_2.Enqueue(cardOfPlayer_1);
                        queueOfPlayer_2.Enqueue(cardOfPlayer_2);
                        Console.WriteLine("Карты уходят второму игроку, у него " + queueOfPlayer_2.Count() + " карт");
                    }
                    else                                                            // иначе карты уходят первому игроку
                    {
                        queueOfPlayer_1.Enqueue(cardOfPlayer_1);
                        queueOfPlayer_1.Enqueue(cardOfPlayer_2);
                        Console.WriteLine("Карты уходят первому игроку, у него " + queueOfPlayer_1.Count() + " карт");
                    }
                    firstMotion = 1;
                }
                Console.ReadKey();
                Console.Clear();
            } while (queueOfPlayer_1.Count > 0 && queueOfPlayer_2.Count > 0);         // если у игроков есть карты на руках, то игра продолжается

            if (queueOfPlayer_1.Count == 0)
            {
                Console.WriteLine("Второй игрок выиграл!");
            }
            else
            {
                Console.WriteLine("Первый игрок выиграл!");
            }

            //PrintDeck(cards);
        }

        // метод для раздачи карт
        public static Queue<Card>[] DistributionOfCardsToPlayers(List<Card> cards)
        {
            Queue<Card>[] cardsOfPlayers = new Queue<Card>[2];
            Queue<Card> cardsPlayer_1 = new Queue<Card>();
            Queue<Card> cardsPlayer_2 = new Queue<Card>();
            Random rnd = new Random();
            int index = 0;
            for(int i = 0; i < 18; i++)
            {
                index = rnd.Next(0, cards.Count);
                Card card = cards[index];
                cards.RemoveAt(index);
                cardsPlayer_1.Enqueue(card);
            }
            cardsOfPlayers[0] = cardsPlayer_1;

            for (int i = 0; i < 18; i++)
            {
                index = rnd.Next(0, cards.Count);
                Card card = cards[index];
                cards.RemoveAt(index);
                cardsPlayer_2.Enqueue(card);
            }
            cardsOfPlayers[1] = cardsPlayer_2;
            return cardsOfPlayers;
        }

        public static List<Card> CreatingOfDeck()
        {
            List<Card> cards = new List<Card>();
            for (int i = 6; i <= 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card((cardSuit)j, (cardDignity)i);
                    cards.Add(card);
                }
            }
            return cards;
        }

        public static void PrintDeck(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
