using System;
using System.Collections.Generic;

namespace CSLight43
{
    class Program
    {
        static void Main(string[] args)
        {
            Database playersDatabase = new Database();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Добро пожаловать на сервер.\n" +
                    "Игроки в базе даннных:\n");
                playersDatabase.ShowDatabase();

                Console.WriteLine("\n1: Добавить игрока.\n" +
                    "2: Забанить игрока.\n" +
                    "3: Разбанить игрока.\n" +
                    "4: Удалить игрока.\n" +
                    "5: Выйти из программы.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        playersDatabase.AddPlayer();
                        break;
                    case "2":
                        playersDatabase.BanPlayer();
                        break;
                    case "3":
                        playersDatabase.UnbanPlayer();
                        break;
                    case "4":
                        playersDatabase.DeletePlayer();
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

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void ShowDatabase()
        {
            foreach (var player in _players)
            {
                player.ShowInfo();
            }
        }

        public void AddPlayer ()
        {
            Console.Write("Введите никнейм игрока: ");
            string nickname = Console.ReadLine();

            Console.Write("Введите уровень игрока: ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int level);

            if (isCorrect && level > 0)
            {
                Console.WriteLine("\nИгрок добавлен.");
                _players.Add(new Player(nickname, level));
            }
            else
            {
                Console.WriteLine("\nВведены некорректные данные уровня игрока. Игрок не будет добавлен.");
            }
        }

        public void BanPlayer()
        {
            GetPlayer("Ban");
        }

        public void UnbanPlayer()
        {
            GetPlayer("Unban");
        }

        public void DeletePlayer()
        {
            GetPlayer("Delete");
        }

        private void GetPlayer (string command)
        {
            if (_players.Count > 0)
            {
                Console.Write("Введите уникальный номер игрока: ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int ID);

                if (isCorrect)
                {
                    if (ID > 0 && ID <= _players.Count)
                    {
                        switch (command)
                        {
                            case "Ban":

                                if (_players[ID - 1].IsBanned)
                                {
                                    Console.WriteLine("\nИгрок уже забанен.");
                                }
                                else
                                {
                                    Console.WriteLine("\nИгрок забанен.");
                                    _players[ID - 1].Ban();
                                }

                                break;
                            case "Unban":

                                if (!_players[ID - 1].IsBanned)
                                {
                                    Console.WriteLine("\nИгрок не забанен.");
                                }
                                else
                                {
                                    Console.WriteLine("\nИгрок разбанен.");
                                    _players[ID - 1].Unban();
                                }

                                break;
                            case "Delete":

                                Console.WriteLine("\nИгрок удален.");
                                _players.RemoveAt(ID - 1);

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nТакого номера игрока не существует. ");
                    }
                }
                else
                {
                    Console.WriteLine("\nВведены некорректные данные уникального номера игрока.");
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
        private int _ID;
        private string _nickname;
        private int _level;
        public bool IsBanned { get; private set; }


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
