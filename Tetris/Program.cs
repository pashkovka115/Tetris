using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        private static FigureGenerator _generator;
        private static Figure currentFigure;

        const int TIMER_INTERVAL = 500;
        private static System.Timers.Timer _timer;

        static private Object _lockObject = new object();
        
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Hight);
            // что бы убрать полосы прокрутки
            Console.SetBufferSize(Field.Width, Field.Hight);

            // Field.Width = 20;

            _generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = _generator.GetNewFigure();
            SetTimer();

            while (true)
            {
                // Если была нажата какая либо клавиша
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
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
        
        
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            _timer = new System.Timers.Timer(TIMER_INTERVAL);
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        
        
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }
    }
}