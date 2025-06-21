using System;
using System.Collections.Generic;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive method to calculate future value
        static double PredictFutureValue(int year, double currentValue, double growthRate)
        {
            if (year == 0)
                return currentValue;

            return PredictFutureValue(year - 1, currentValue, growthRate) * (1 + growthRate);
        }

        // Optimized using memoization (optional step)
        static double PredictFutureValueMemo(int year, double currentValue, double growthRate, Dictionary<int, double> memo)
        {
            if (year == 0)
                return currentValue;

            if (memo.ContainsKey(year))
                return memo[year];

            double result = PredictFutureValueMemo(year - 1, currentValue, growthRate, memo) * (1 + growthRate);
            memo[year] = result;
            return result;
        }

        static void Main(string[] args)
        {
            double initialValue = 1000.0;
            double annualGrowthRate = 0.08; // 8% annual growth
            int years = 5;

            Console.WriteLine("== Recursive Forecast ==");
            double futureValue = PredictFutureValue(years, initialValue, annualGrowthRate);
            Console.WriteLine($"Future Value after {years} years: ₹{futureValue:F2}");

            Console.WriteLine("\n== Optimized Forecast with Memoization ==");
            var memo = new Dictionary<int, double>();
            double futureValueMemo = PredictFutureValueMemo(years, initialValue, annualGrowthRate, memo);
            Console.WriteLine($"Future Value after {years} years (memoized): ₹{futureValueMemo:F2}");

            Console.WriteLine("\n== Time Complexity Analysis ==");
            Console.WriteLine("Naive Recursion: O(n)");
            Console.WriteLine("Memoized Version: O(n) with reduced repeated calculations");

            Console.WriteLine("\n== Optimization Notes ==");
            Console.WriteLine("Using memoization or switching to an iterative version avoids redundant work in large inputs.");
        }
    }
}
