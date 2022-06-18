using System;
using System.Collections.Generic;

namespace CSLight43
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase playersDataBase = new DataBase();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Добро пожаловать на сервер.\n" +
                    "Игроки в базе даннных:\n");
                playersDataBase.ShowDataBase();

                Console.WriteLine("\n1: Добавить игрока.\n" +
                    "2: Забанить игрока.\n" +
                    "3: Разбанить игрока.\n" +
                    "4: Удалить игрока.\n" +
                    "5: Выйти из программы.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        playersDataBase.AddPlayer();
                        break;
                    case "2":
                        playersDataBase.BanPlayer();
                        break;
                    case "3":
                        playersDataBase.UnbanPlayer();
                        break;
                    case "4":
                        playersDataBase.DeletePlayer();
                        break;
                    case "5":
                        Console.WriteLine("Закрытие программы...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Введите число, чтобы выбрать программу.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class DataBase
    {
        public List<Player> PlayersDataBase = new List<Player>();

        public void ShowDataBase()
        {
            foreach (var player in PlayersDataBase)
            {
                player.ShowInfo();
            }
        }

        public void AddPlayer ()
        {
            Console.Write("Введите никнейм игрока: ");
            string playersNickname = Console.ReadLine();

            Console.Write("Введите уровень игрока: ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int playersLevel);

            if (isCorrect)
            {
                if (playersLevel > 0)
                {
                    Console.WriteLine("\nИгрок добавлен.");
                    PlayersDataBase.Add(new Player(playersNickname, playersLevel));
                }
                else
                {
                    Console.WriteLine("\nВведены некорректные данные уровня игрока. Игрок не будет добавлен.");
                }
            }
            else
            {
                Console.WriteLine("\nВведены некорректные данные уровня игрока. Игрок не будет добавлен.");
            }
        }

        public void BanPlayer()
        {
            if (PlayersDataBase.Count > 0)
            {
                Console.Write("Введите уникальный номер игрока: ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int playersID);

                if (isCorrect)
                {
                    if (playersID > 0 && playersID <= PlayersDataBase.Count)
                    {
                        if (PlayersDataBase[playersID - 1].IsBanned)
                        {
                            Console.WriteLine("\nИгрок уже забанен.");
                        }
                        else
                        {
                            Console.WriteLine("\nИгрок забанен.");
                            PlayersDataBase[playersID - 1].Ban();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nТакого номера игрока не существует. ");
                    }
                }
                else
                {
                    Console.WriteLine("\nВведены некорректные данные уникального номера игрока. Игрок не будет забанен.");
                }
            }
            else
            {
                Console.WriteLine("В базе данных пока нет игроков.");
            }
        }

        public void UnbanPlayer()
        {
            if (PlayersDataBase.Count > 0)
            {
                Console.Write("Введите уникальный номер игрока: ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int playersID);

                if (isCorrect)
                {
                    if (playersID > 0 && playersID <= PlayersDataBase.Count)
                    {
                        if (!PlayersDataBase[playersID - 1].IsBanned)
                        {
                            Console.WriteLine("\nИгрок не забанен.");
                        }
                        else
                        {
                            Console.WriteLine("\nИгрок разбанен.");
                            PlayersDataBase[playersID - 1].Unban();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nТакого номера игрока не существует.");
                    }
                }
                else
                {
                    Console.WriteLine("\nВведены некорректные данные уникального номера игрока. Игрок не будет разбанен.");
                }
            }
            else
            {
                Console.WriteLine("В базе данных пока нет игроков.");
            }
        }

        public void DeletePlayer()
        {
            if (PlayersDataBase.Count > 0)
            {
                Console.Write("Введите уникальный номер игрока: ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int playersID);

                if (isCorrect)
                {
                    if (playersID > 0 && playersID <= PlayersDataBase.Count)
                    {
                        Console.WriteLine("\nИгрок удален.");
                        PlayersDataBase.RemoveAt(playersID - 1);
                    }
                    else
                    {
                        Console.WriteLine("\nТакого номера игрока не существует.");
                    }
                }
                else
                {
                    Console.WriteLine("\nВведены некорректные данные уникального номера игрока. Игрок не будет удален.");
                }
            }
            else
            {
                Console.WriteLine("В базе данных пока нет игроков.");
            }
        }
    }

    class Player
    {
        public static int IDs;
        public bool IsBanned { get; private set; }
        private int _ID;
        private string _nickname;
        private int _level;

        public Player(string nickname, int level, bool isBanned = false)
        {
            _ID = ++IDs;
            _nickname = nickname;
            _level = level;
            IsBanned = isBanned;
        }

        public void ShowInfo()
        {
            Console.Write(_nickname + " #" + _ID + " LVL." + _level);

            if (IsBanned)
            {
                Console.Write("\t/BANNED");
            }

            Console.WriteLine();
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}
