using System;

namespace CSLight42
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Гоблин", "Кирк", 50, 5, 8);
            player1.ShowStats();

            Console.ReadKey();
        }
    }

    class Player
    {
        private string _race;
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public Player (string race, string name, int health, int damage, int armor)
        {
            _race = race;
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine(_race + " " + _name + " имеет " + _health + " HP, " + _damage + " DMG, " + _armor + " ARMOR");
        }
    }
}
