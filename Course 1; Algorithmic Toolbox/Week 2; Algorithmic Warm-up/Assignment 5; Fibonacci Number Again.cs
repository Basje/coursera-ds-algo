using System;
using System.Collections.Generic;


namespace FibAgain
{
	class Program
	{
		/// <summary>
		/// Caches already calculated Fibonacci numbers.
		/// </summary>
		static long[] storage;

		/// <summary>
		/// Main program.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var io = new IoHelper();
			var input = io.ReadLongs(2);
			var n = input[0];
			var m = (int)input[1];
			var pisanoLength = PisanoPeriodLength(m);
			var remainder = n % pisanoLength;

			storage = new long[remainder + 1];
			var fib = Fibonacci(remainder, m);
			var answer = fib % m;

			Console.WriteLine(answer);
		}

		/// <summary>
		/// Calculate Pisano period length using an adapted version of the 
		/// calculation of the last digit of a Fibonacci number.
		/// </summary>
		/// <param name="m">The modulo number</param>
		/// <returns>Pisano period length</returns>
		static int PisanoPeriodLength(int m)
		{
			// As per the assignment: 2 <= m <= 100000.
			int currLastDigit = -1, Nmin1 = 1, Nmin2 = 0;
			for (int currN = 2; currN <= m * 6; currN++)
			{
				// Check for start of new sequence
				if (currN > 2 && Nmin2 == 0 && Nmin1 == 1)
				{
					return currN - 2;
				}
				currLastDigit = (Nmin2 + Nmin1) % m;
				Nmin2 = Nmin1;
				Nmin1 = currLastDigit;
			}
			return m * 6;
		}

		/// <summary>
		/// Modulo Fibonacci calculater. 
		/// </summary>
		/// <param name="n">Calculate the n-th number modulo m.</param>
		/// <returns></returns>
		static long Fibonacci(long n, int m)
		{
			if (n <= 1)
			{
				return (int)n;
			}
			int currLastDigit = -1, Nmin1 = 1, Nmin2 = 0;
			for (long currN = 2; currN <= n; currN++)
			{
				currLastDigit = (Nmin2 + Nmin1) % m;
				Nmin2 = Nmin1;
				Nmin1 = currLastDigit;
			}
			return currLastDigit;
		}
	}


	/// <summary>
	/// Input/Output helper class
	/// </summary>
	class IoHelper
	{
		/// <summary>
		/// Read input and convert to an integer.
		/// </summary>
		/// <returns>Integer input</returns>
		public int ReadInteger()
		{
			var value = Console.ReadLine();
			return int.Parse(value);
		}

		/// <summary>
		/// Read input and convert to a long.
		/// </summary>
		/// <returns>Long input</returns>
		public long ReadLong()
		{
			var value = Console.ReadLine();
			return long.Parse(value);
		}

		/// <summary>
		/// Read the input and return a collection of n longs.
		/// </summary>
		/// <param name="n">Number of expected numbers in input.</param>
		/// <returns>Collection of n longs</returns>
		public long[] ReadLongs(int n)
		{
			var input = Console.ReadLine();
			var inputs = input.Split(' ');
			var numbers = new long[n];

			for (int i = 0; i < n; i++)
			{
				numbers[i] = long.Parse(inputs[i]);
			}

			return numbers;
		}
	}
}
