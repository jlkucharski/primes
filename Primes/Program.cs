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
				{"Is a number prime?", () => {IsNumberPrime(); } },
				{"Find primes in range", () => { FindPrimesInRange(); } },
				{"Find n primes", () => { FindFirstNPrimes(); } }
			});

			menu.ProcessInput();
		}

		static void IsNumberPrime()
		{
			Console.WriteLine("Provide a number to check");
			var line = Console.ReadLine();
			ulong number = ulong.Parse(line);
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find out if {number} is prime...");

			stopwatch.Start();
			bool isPrime = IsPrime(number);
			stopwatch.Stop();

			if (isPrime)
			{
				Console.WriteLine($"{number} is a prime number.");
			}
			else
			{
				Console.WriteLine($"{number} is not a prime number.");
			}

			Console.WriteLine($"Found out in {stopwatch.ElapsedMilliseconds}ms.");
		}

		static void FindFirstNPrimes()
		{
			Console.WriteLine("Provide number of primes to find.");
			var line = Console.ReadLine();
			ulong max = ulong.Parse(line);
			ulong primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find {max} primes lower...");

			stopwatch.Start();
			for (ulong i = 3; primeCount < max; i += 2)
			{
				if (IsPrime(i))
				{
					primeCount++;
					Console.WriteLine(i);
				}
			}
			stopwatch.Stop();

			Console.WriteLine();
			Console.WriteLine($"Found {primeCount} primes in {stopwatch.ElapsedMilliseconds}ms.");

		}

		static void FindPrimesInRange()
		{
			Console.WriteLine("Provide max");
			var line = Console.ReadLine();
			ulong max = ulong.Parse(line);
			ulong primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find primes lower or equal to {max}...");

			stopwatch.Start();
			for (ulong i = 3; i <= max; i += 2)
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

		static bool IsPrime(ulong value)
		{
			if (value < 3) return false;

			ulong maxj = (ulong)Math.Floor(value / 2d);

			for (ulong j = 3; j < maxj; j += 2)
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
