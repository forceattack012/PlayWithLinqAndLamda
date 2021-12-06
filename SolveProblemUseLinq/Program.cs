using System;
using System.Linq;

namespace SolveProblemUseLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 100);
            var primeNumbers = numbers.Where(it => isPrimeNumber(it));
            foreach (var item in primeNumbers)
            {
                Console.WriteLine(item);
            }
            var nums = new int[] { 3, 2, 3 };
            MajorityElement(nums);

            FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
        }

        private static bool isPrimeNumber(int number)
        {
            if (number == 1)
            {
                return true;
            }
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int MajorityElement(int[] nums)
        {
            var qry = nums.GroupBy(r => r)
                            .Select(t => new
                            {
                                Key = t.Key,
                                Count = t.Where(a => a == t.Key).Count()
                            })
                            .Aggregate((result, item) => result.Count > item.Count ? result : item);
            return qry.Key;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var merge = nums1.Concat(nums2).OrderBy(r => r);
            int count = merge.Count();
            var halfIndex = count / 2;
            double median = 0.0;

            if (count % 2 == 0)
            {
                median = (merge.ElementAt(halfIndex) + merge.ElementAt(halfIndex - 1)) / 2.0000;
            }
            else
            {
                median = merge.ElementAt(halfIndex);
            }

            return median;
        }
    }
}
