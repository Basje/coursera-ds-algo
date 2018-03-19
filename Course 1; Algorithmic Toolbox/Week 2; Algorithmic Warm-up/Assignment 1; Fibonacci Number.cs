using System;


namespace Fibonacci
{
	class Program
	{
		/// <summary>
		/// Caches already calculated Fibonacci numbers.
		/// </summary>
		static int[] storage;

		/// <summary>
		/// Main program.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var io = new IoHelper();
			var n = io.ReadInteger();

			// The 45th Fibonacci number is 1134903170, which will fit in an integer.
			storage = new int[n + 1];

			Console.WriteLine(Fibonacci(n));
		}

		/// <summary>
		/// Recursive Fibonacci calculater. Uses caching to speed up calculation.
		/// </summary>
		/// <param name="n">Calculate the n-th number.</param>
		/// <returns></returns>
		static int Fibonacci(int n)
		{
			if (n <= 1)
			{
				return n;
			}
			if (storage[n] > 0)
			{
				return storage[n];
			}
			var f = Fibonacci(n - 1) + Fibonacci(n - 2);
			storage[n] = f;
			return f;
		}
	}

	/// <summary>
	/// Input/Output helper class
	/// </summary>
	class IoHelper
	{
		public int ReadInteger()
		{
			var value = Console.ReadLine();
			return int.Parse(value);
		}
	}
}
