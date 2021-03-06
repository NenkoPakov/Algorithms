using System;

namespace _2._Recursive_Drawing
{
    public static class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            CreateFigure(input);
        }

        private static void CreateFigure(int timesRepeat)
        {
            if (timesRepeat <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', timesRepeat));
            CreateFigure(timesRepeat-1);
            Console.WriteLine(new string('#', timesRepeat));
        }
    }
}
