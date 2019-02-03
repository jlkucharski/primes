using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Primes
{
	class Program
	{
		static void Main(string[] args)
		{
			var menu = new ActionController(new Dictionary<string, Action>()
			{
				{"Find primes in range", () => { FindPrimesInRange(); } }
			});

			menu.ProcessInput();
		}

		static void FindPrimesInRange()
		{
			Console.WriteLine("Provide max");
			var line = Console.ReadLine();
			int max = int.Parse(line);
			int primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find primes lower or equal to {max}...");

			stopwatch.Start();
			for (int i = 3; i <= max; i += 2)
			{
				if (IsPrime(i))
				{
					primeCount++;
					Console.WriteLine(i);
				}
			}
			stopwatch.Stop();

			Console.WriteLine();
			Console.WriteLine($"Found {primeCount} primes smaller than {max} in {stopwatch.ElapsedMilliseconds}ms.");
		}

		static bool IsPrime(int value)
		{
			if (value < 3) return false;

			int maxj = (int)Math.Floor(value / 2d);

			for (int j = 3; j < maxj; j += 2)
			{
				if (value % j == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
