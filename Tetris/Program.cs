﻿using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            // что бы убрать полосы прокрутки
            Console.SetBufferSize(40, 30);

            Point p1 = new Point(2, 3, '*');
            p1.Draw();

            Point p2 = new Point() 
            {
                x = 4,
                y = 5,
                c = '*'
            };
            p2.Draw();

            Square square = new Square(10, 20, '*');
            square.Draw();


            // только для разработки
            Console.ReadLine();
        }
    }
}