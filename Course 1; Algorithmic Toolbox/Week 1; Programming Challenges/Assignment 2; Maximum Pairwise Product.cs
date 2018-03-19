using System;

namespace w01a02
{
	class Program
	{
		static void Main(string[] args)
		{
			// Load provided algorithm input
			var firstInput = Console.ReadLine();
			var secondInput = Console.ReadLine();

			// Parse provided algorithm input
			var tokens = secondInput.Split(' ');
			var numberOfTokens = int.Parse(firstInput);
			var numbers = new UInt64[numberOfTokens];

			for (int i = 0; i < numberOfTokens; i++)
			{
				numbers[i] = UInt64.Parse(tokens[i]);
			}

			UInt64 product = MaxPairwiseProductFast(numbers);

			// Output result
			Console.WriteLine(product);

			//StressTest(5, 9);
		}

		private static ulong MaxPairwiseProductNaive(ulong[] numbers)
		{
			// keep track of best result
			ulong product = 0;

			// calculate all possible solutions and remember the hightest one
			for (int i = 0; i < numbers.Length; i++)
			{
				for (int j = i + 1; j < numbers.Length; j++)
				{
					if (product < numbers[i] * numbers[j])
					{
						product = numbers[i] * numbers[j];
					}
				}
			}

			return product;
		}

		private static ulong MaxPairwiseProductFast(ulong[] numbers)
		{
			ulong product = 0;
			var index1 = 0;
			var index2 = 0;

			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[index1] < numbers[i])
				{
					index1 = i;
				}
			}

			if (index1 == 0)
			{
				index2 = 1;
			}

			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[index2] < numbers[i])
				{
					if (index1 != i) {
						index2 = i;
					}
					
				}
			}

			product = numbers[index1] * numbers[index2];
			return product;
		}

		private static void StressTest(int length, int boundary)
		{
			Random rnd = new Random();
			while (true)
			{
				int n = rnd.Next(2, length);
				ulong[] a = new ulong[n];

				for (int i = 0; i < n; i++)
				{
					a[i] = (ulong)rnd.Next(0, boundary);
					Console.Write(Convert.ToString(a[i]));
					Console.Write(" ");
				}
				Console.WriteLine();
				
				ulong result1 = MaxPairwiseProductNaive(a);
				ulong result2 = MaxPairwiseProductFast(a);

				if (result1 == result2)
				{
					Console.WriteLine("OK");
				}
				else
				{
					Console.Write("Wrong answer: ");
					Console.Write(result1);
					Console.Write(" ");
					Console.WriteLine(result2);
					return;
				}
			}
		}
	}
}
