using System;
using Tetris;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] nums1 = new int[5];
        
            nums1[0] = 1;
            nums1[1] = 2;
            nums1[2] = -2;
            nums1[3] = 0;
            nums1[4] = 0;
        
            foreach (int item in nums1)
            {
                Console.WriteLine(item);
            }
        
            Point[] points = new Point[3];
            points[0] = new Point(2, 3, '*');
            points[1] = new Point(4, 5, '#');
            points[2] = new Point(6, 7, '*');
        
            foreach (Point item in points)
            {
                item.Draw();
            }*/

            int position_x = 20;
            int position_y = 5;

            for (int i = position_x; i < position_x + 2; i++)
            {
                for (int j = position_y; j < position_y + 2; j++)
                {
                    Point point = new Point(i, j, '*');
                    point.Draw();
                }
            }
        }
    }
}
