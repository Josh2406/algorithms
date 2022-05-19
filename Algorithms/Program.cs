using Algorithms.Implementations;
using Algorithms.Implementations.SN1;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rLastName = "Ajibade".Reversed();
            Console.WriteLine(rLastName);

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
