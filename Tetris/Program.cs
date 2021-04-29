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

            Stick stick = new Stick(10, 5, '*');
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
            stick.Draw();
            

            /*Figure[] figures = new Figure[2];
            figures[0] = new Square(5, 5, '*');
            figures[1] = new Stick(10, 3, '*');
            
            foreach (Figure figure in figures)
            {
                figure.Draw();
            }*/


            // только для разработки
            // Console.ReadLine();
        }
    }
}
