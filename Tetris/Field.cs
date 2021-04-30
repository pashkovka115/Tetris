using System;

namespace Tetris
{
    public static class Field
    {
        private static int _width = 40;
        private static int _hight = 30;

        public static int Hight
        {
            get { return _hight; }
            set
            {
                _hight = value;
                Console.SetWindowSize(_width, Field._hight);
                Console.SetBufferSize(_width, Field._hight);
            }
        }

        public static int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                Console.SetWindowSize(_width, Field._hight);
                Console.SetBufferSize(_width, Field._hight);
            }
        }


        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Hight][];
            for (int i = 0; i < Hight; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStrike(Point point)
        {
            return _heap[point.x][point.y];
        }


        public static void AddFigure(Figure figure)
        {
            foreach (var point in figure.Points)
            {
                _heap[point.x][point.y] = true;
            }
        }
    }
}