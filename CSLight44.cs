using System;

namespace CSLight44
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player1 = new Player(5, 5, '@');

            renderer.DrawPlayer(player1.PositionX, player1.PositionY, player1.Appearance);
            Console.ReadKey();
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;
        private char _appearance;

        public int PositionX
        {
            get
            {
                return _positionX;
            }
            private set
            {
                _positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return _positionY;
            }
            private set
            {
                _positionY = value;
            }
        }

        public char Appearance
        {
            get
            {
                return _appearance;
            }
            private set
            {
                _appearance = value;
            }
        }

        public Player (int positionX, int positionY, char appearance)
        {
            _positionX = positionX;
            _positionY = positionY;
            _appearance = appearance;
        }
    }

    class Renderer
    {
        public void DrawPlayer (int positionX, int positionY, char appearance)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(appearance);
        }
    }
}
