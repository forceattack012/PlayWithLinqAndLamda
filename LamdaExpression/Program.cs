using System;
using System.Linq;

namespace LamdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            int[] numbers = { 2, 3, 4, 5 };
            var sq = numbers.Select(r => square(r));


            Action<string> greet = name =>
            {
                Console.WriteLine(name);
            };
            Func<int, bool> IsEqualFive = x => x == 5;

            sq = numbers.Where(r => IsEqualFive(r));

            greet("Hello");

        }
    }
}
