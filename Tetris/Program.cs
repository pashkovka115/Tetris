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
            
            

            /*Point p1 = new Point(2, 3, '*');
            p1.Draw();

            Point p2 = new Point() 
            {
                x = 4,
                y = 5,
                c = '*'
            };
            p2.Draw();*/

            /*Square square = new Square(5, 5, '*');
            square.Draw();
            Thread.Sleep(1000);
            square.Hide();
            square.Move(Direction.LEFT);
            square.Draw();
            square.Hide();
            square.Rotate();*/

            /*Stick stick = new Stick(10, 5, '*');
            stick.Draw();
            Thread.Sleep(1000);
            
            stick.Hide();
            stick.Rotate();
            stick.Draw();
            Thread.Sleep(1000);
            
            stick.Hide();
            stick.Move(Direction.LEFT);
            stick.Draw();
            Thread.Sleep(1000);
            
            stick.Hide();
            stick.Move(Direction.RIGHT);
            stick.Draw();
            Thread.Sleep(1000);
            
            stick.Hide();
            stick.Move(Direction.RIGHT);
            stick.Draw();
            Thread.Sleep(1000);
            
            stick.Hide();
            stick.Rotate();
            stick.Draw();*/


            /*FigureGenerator generator = new FigureGenerator(20, 0, '*');
            for (int j = 0; j < 10; j++)
            {
                Figure s = generator.GetNewFigure();
                for (int i = 0; i < 10; i++)
                {
                    s.Draw();
                    Thread.Sleep(500);
                    s.Hide();
                    s.Move(Direction.DOWN);
                }
                s.Hide();
            }*/
            
            
            /*Figure b = generator.GetNewFigure();
            for (int i = 0; i < 10; i++)
            {
                b.Draw();
                Thread.Sleep(500);
                b.Hide();
                b.Move(Direction.DOWN);
            }
            b.Hide();*/
            


            /*Figure[] figures = new Figure[2];
            figures[0] = new Square(5, 5, '*');
            figures[1] = new Stick(10, 3, '*');
            
            foreach (Figure figure in figures)
            {
                figure.Draw();
            }*/

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = null;
            
            while (true)
            {
                FigureFall(ref s, generator);
                s.Draw();
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
