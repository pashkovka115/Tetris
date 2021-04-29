using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Day day = Day.Sat;

            if (day == Day.Sat)
            {
                Console.WriteLine("YES!");
            }

            int day3 = 3;

            Console.WriteLine( (Day)day3 );
        }
    }
}