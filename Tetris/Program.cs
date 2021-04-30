using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Hight);
            // что бы убрать полосы прокрутки
            Console.SetBufferSize(Field.Width, Field.Hight);

            // Field.Width = 20;

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure currentFigure = generator.GetNewFigure();

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
                FigureGenerator generator = new FigureGenerator(20, 0, '*');
                Field.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();
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


        /*static void FigureFall(ref Figure figure, FigureGenerator generator)
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
        }*/
    }
}