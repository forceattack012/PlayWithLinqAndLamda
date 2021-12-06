using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleSelectMany();
            ExampleSorting();
            ExampleQuantifier();
            ExampleGrouping();
            ExampleAggregate();
            ExampleAggregate2();
            ExampleAggregateFindMax();
            ExampleExcept();
            ExampleIntercept();
            ExampleFactoria();
            ExampleSumAndJoin();
            ExampleAvarange();
        }

        private static void ExampleAvarange()
        {
            var numbers = new List<int> { 6, 2, 8, 3 };
            var avg = numbers.Aggregate(0, (result, item) => result + item,
                                result => (decimal)result / numbers.Count);
            Console.WriteLine(avg);
        }

        private static void ExampleSumAndJoin()
        {
            var players = new List<Player> {
                new Player { Name = "Alex", Team = "A", Score = 10 },
                new Player { Name = "Anna", Team = "A", Score = 20 },
                new Player { Name = "Luke", Team = "L", Score = 60 },
                new Player { Name = "Lucy", Team = "L", Score = 40 },
            };

            //var teamTotalScores = players.GroupBy(r => r.Team)
            //                             .Select(newGroup => new
            //                             {
            //                                 Team = newGroup.Key,
            //                                 Score = newGroup.Sum(r => r.Score)
            //                             }).ToList();
            //var TeamSourceMax = teamTotalScores.Aggregate((result, item) => result.Score > item.Score ? result : item);
            //Console.WriteLine(TeamSourceMax);

            var bestTotalScores = players.GroupBy(r => r.Team )
                                        .Select(newGroup => new
                                        {
                                            Team = newGroup.Key,
                                            BestScore = newGroup.Max(r => r.Score),
                                            Name = newGroup.Where(r => r.Score == newGroup.Max(r => r.Score)).Select(r => r.Name).SingleOrDefault()
                                        });
            foreach (var item in bestTotalScores)
                Console.WriteLine(item);
        }

        private static void ExampleFactoria()
        {
            var collections = Enumerable.Range(1, 5);
            var qry = collections.Aggregate(1, (result, item) => result * item);
            Console.WriteLine(qry);
        }

        private static void ExampleAggregateFindMax()
        {
            var ints = new int[]
            {
                1,2,5,4,3,0
            };
            var max = ints.Aggregate((curr, next) => curr > next ? curr : next);
            Console.WriteLine(max);
        }

        private static void ExampleIntercept()
        {
            ProductA[] store1 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 } };

            ProductA[] store2 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "lemon", Code = 12 } };

            IEnumerable<ProductA> duplicates =
            store1.Intersect(store2);

            foreach (var product in duplicates)
                Console.WriteLine(product.Name + " " + product.Code);
        }

        private static void ExampleExcept()
        {
            ProductA[] fruits1 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 },
                        new ProductA { Name = "lemon", Code = 12 } };

            ProductA[] fruits2 = { new ProductA { Name = "apple", Code = 9 } };

            //Get all the elements from the first array
            //except for the elements from the second array.

            IEnumerable<ProductA> except =
                fruits1.Except(fruits2);

            foreach (var product in except)
                Console.WriteLine(product.Name + " " + product.Code);

            /*
              This code produces the following output:

              orange 4
              lemon 12
            */
        }

        private static void ExampleAggregate2()
        {
            int[] ints = { 1,2,3,4 };
            int qry = ints.Aggregate(0, (total,next) => next % 2 == 0 ? total+1 : total);
            Console.WriteLine(qry);
        }

        private static void ExampleAggregate()
        {
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };
            string longestName =
                fruits.Aggregate("",(longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

                        Console.WriteLine(
                            "The fruit with the longest name is {0}.",
                            longestName);
        }

        private static void ExampleGrouping()
        {
            var collection = new[]
            {
                new { Name = "A", Age = 15 },
                new { Name = "B", Age = 7 },
                new { Name = "C", Age = 7 },
                new { Name = "D", Age = 15 },
                new { Name = "E", Age = 9 },
            };
            var qry = collection.GroupBy(it => it.Age);
        }

        private static void ExampleQuantifier()
        {
            var collection = new int[] { 2, 4, 6, 8, 10 };
            var any = collection.Any(it => it > 9); //true
            var all = collection.All(it => it > 5); //false
        }

        private static void ExampleSorting()
        {
            var collection = new[]
            {
                new { Score = 7, Name = "B" },
                new { Score = 3, Name = "A" },
                new { Score = 7, Name = "A" },
                new { Score = 4, Name = "A" },
                new { Score = 3, Name = "C" },
            };
            var orderCollection = collection
                                    .OrderBy(r => r.Score)
                                    .ThenBy(r => r.Name);

            //order by source and name
            foreach(var item in orderCollection)
            {
                Console.WriteLine(item);
            }
        }

        private static void ExampleSelectMany()
        {
            List<Bouquet> bouquets = new List<Bouquet>()
            {
                new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" } },
                new Bouquet { Flowers = new List<string> { "tulip", "rose", "orchid" } },
                new Bouquet { Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" } },
                new Bouquet { Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" } }
            };
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);
            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query2)
                Console.WriteLine(item);
            /*
               Results by using SelectMany():
                sunflower
                daisy
                daffodil
                larkspur
                tulip
                rose
                orchid
                gladiolis
                lily
                snapdragon
                aster
                protea
                larkspur
                lilac
                iris
                dahlia
             */
        }

        class Bouquet
        {
            public List<string> Flowers { get; set; }
        }

        class Player
        {
            public string Name;
            public string Team;
            public int Score;
        }

        public class ProductA : IEquatable<ProductA>
        {
            public string Name { get; set; }
            public int Code { get; set; }

            public bool Equals(ProductA other)
            {
                if (other is null)
                    return false;

                return this.Name == other.Name && this.Code == other.Code;
            }

            public override bool Equals(object obj) => Equals(obj as ProductA);
            public override int GetHashCode() => (Name, Code).GetHashCode();
        }

    }
}
