using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        private static FigureGenerator _generator;
        
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Hight);
            // что бы убрать полосы прокрутки
            Console.SetBufferSize(Field.Width, Field.Hight);

            // Field.Width = 20;

            _generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            Figure currentFigure = _generator.GetNewFigure();

            while (true)
            {
                // Если была нажата какая либо клавиша
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                }
            }
        }


        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HeapStrike || result == Result.DownBorderStrike)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
                currentFigure = _generator.GetNewFigure();
                return true;
            }

            return false;
        }

        private static Result HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return currentFigure.TryMove(Direction.LEFT);

                case ConsoleKey.RightArrow:
                    return currentFigure.TryMove(Direction.RIGHT);

                case ConsoleKey.DownArrow:
                    return currentFigure.TryMove(Direction.DOWN);

                case ConsoleKey.Spacebar:
                    return currentFigure.TryRotate();
            }

            return Result.Success;
        }
    }
}