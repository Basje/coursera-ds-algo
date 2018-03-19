using System;


namespace Fibonacci
{
	class Program
	{
		/// <summary>
		/// Main program.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var io = new IoHelper();
			var n = io.ReadLong();

			Console.WriteLine(Fibonacci(n));
		}

		/// <summary>
		/// Recursive Fibonacci last digit calculater. Uses caching to speed up calculation.
		/// </summary>
		/// <param name="n">Calculate the n-th number's last digit.</param>
		/// <returns></returns>
		static int Fibonacci(long n)
		{
			if (n <= 1)
			{
				return (int)n;
			}
			int currLastDigit = -1, Nmin1 = 1, Nmin2 = 0;
			for (long currN = 2; currN <= n; currN++)
			{
				currLastDigit = (Nmin2 + Nmin1) % 10;
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
		public int ReadInteger()
		{
			var value = Console.ReadLine();
			return int.Parse(value);
		}

		public long ReadLong()
		{
			var value = Console.ReadLine();
			return long.Parse(value);
		}
	}
}
