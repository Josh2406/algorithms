using Algorithms.Implementations;
using Algorithms.Implementations.Easy;
using Algorithms.Implementations.Generic;
using Algorithms.Implementations.SN1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("----String Manipulation----");
            var rLastName = "Ajibade Joshua Babawale".EachWordInAStatementReversed();
            Console.WriteLine(rLastName);
            Console.WriteLine();

            var arr = new int[] { 1, 3, 2, 1, 4, 5, 5, 9, 10, 10, 12, 9, 11 };
            var nonDupArr = arr.RemoveDuplicatesWithoutLinq();

            var algo = new Algorithm();

            Console.WriteLine("----Selection Sort----");
            SelectionSortTest(algo);
            Console.WriteLine();

            Console.WriteLine("----Customer BigInteger----");
            JBigIntegerTest();
            Console.WriteLine();

            Console.WriteLine("----Prime Generator----");
            PrimeNumberGeneratorTest();
            Console.WriteLine();

            Console.WriteLine("----PSquare Generator----");
            PerfectSquareTest();
            Console.WriteLine();

            var arr1 = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
            var subSequence = new List<int> { 22, 25, 30};
            var isSub = algo.ValidateSubsequence(arr1, subSequence);

            

            Console.ReadLine();
        }

        static void JBigIntegerTest()
        {
            try
            {
                var bin1 = "8492013";
                var bin2 = "8492013";

                var big1 = new JBigInteger(bin1, 10);
                var big2 = new JBigInteger(bin2, 10);

                var sum = big1 + big2;
                var sub = big1 - big2;

                Console.WriteLine($"\n\n{big1} + {big2} = {sum}");
                Console.WriteLine($"{big1} - {big2} = {sub} (IsNegative: {sub.IsNegative})");
                Console.WriteLine($"{big1} == {big2} = {big1 == big2}");
                Console.WriteLine($"{big1} != {big2} = {big1 != big2}");
                Console.WriteLine($"{big1} > {big2} = {big1 > big2}");
                Console.WriteLine($"{big1} >= {big2} = {big1 >= big2}");
                Console.WriteLine($"{big1} <= {big2} = {big1 <= big2}");
                Console.WriteLine($"{big1} < {big2} = {big1 < big2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
        }

        static void PerfectSquareTest()
        {
            var gen = new PerfectSquares(5000, 10000);
            foreach (var psq in gen)
            {
                Console.Write(psq + ", ");
            }
            Console.WriteLine();
        }

        static void PrimeNumberGeneratorTest()
        {
            var gen = new PrimeNumberGenerator(100, 200);
            foreach (var prime in gen)
            {
                Console.Write(prime + ", ");
            }
            Console.WriteLine();
        }

        static void SelectionSortTest(Algorithm algo)
        {
            var arr = new int[] { 28, 2, 10, 9, 2, 1, 0 };
            algo.SelectionSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
