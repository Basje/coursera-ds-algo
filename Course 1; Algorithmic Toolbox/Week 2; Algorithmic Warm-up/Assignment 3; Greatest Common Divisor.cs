using System;


namespace Gcd
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
			var input = io.ReadLongs(2);

			Console.WriteLine(Gcd(input[0], input[1]));
		}

		static long Gcd(long left, long right)
		{
			// Make sure right is always smaller than or equal to left.
			if (right > left)
			{
				var temp = left;
				left = right;
				right = temp;
			}
			if (right > 0)
			{
				return Gcd(right, left % right);
			}
			if (right == 0)
			{
				return left;
			}
			return 1;
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
