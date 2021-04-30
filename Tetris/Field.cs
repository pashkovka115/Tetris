using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Tetris
{
    public static class Field
    {
        private static int _width = 20;
        private static int _hight = 20;

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

        public static void TryDeleteLines()
        {
            for (int j = 0; j < Hight; j++)
            {
                int counter = 0;

                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                    {
                        counter++;
                    }
                }

                if (counter == Width)
                {
                    DeleteLine(j);
                    Readraw();
                }
            }
        }

        private static void Readraw()
        {
            for (int j = 0; j < Hight; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                    {
                        Drawer.DrawPoint(i, j);
                    }
                    else
                    {
                        Drawer.HidePoint(i, j);
                    }
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for (int j = line; j >= 0; j--)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (j ==0)
                    {
                        _heap[j][i] = false;
                    }
                    else
                    {
                        _heap[j][i] = _heap[j - 1][i];
                    }
                }
            }
        }
    }
}