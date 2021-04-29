using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            // что бы убрать полосы прокрутки
            Console.SetBufferSize(40, 30);
            

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure currentFigure = generator.GetNewFigure();
            
            while (true)
            {
                // Если была нажата какая либо клавиша
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(currentFigure, key);
                }
            }
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.Move(Direction.LEFT);
                    break;
                
                case ConsoleKey.RightArrow:
                    currentFigure.Move(Direction.RIGHT);
                    break;
                
                case ConsoleKey.DownArrow:
                    currentFigure.Move(Direction.DOWN);
                    break;
            }
        }


        static void FigureFall(ref Figure figure, FigureGenerator generator)
        {
            figure = generator.GetNewFigure();
            
            for (int i = 0; i < 15; i++)
            {
                figure.Draw();
                Thread.Sleep(200);
                figure.Hide();
                figure.Move(Direction.DOWN);
            }
            figure.Hide();
        }
    }
}
