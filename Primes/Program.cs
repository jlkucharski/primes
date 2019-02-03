using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

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
			BigInteger number = BigInteger.Parse(line);
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
			BigInteger max = BigInteger.Parse(line);
			BigInteger primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find {max} primes lower...");

			stopwatch.Start();
			for (BigInteger i = 3; primeCount < max; i += 2)
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
			BigInteger max = BigInteger.Parse(line);
			BigInteger primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find primes lower or equal to {max}...");

			stopwatch.Start();
			for (BigInteger i = 3; i <= max; i += 2)
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

		static bool IsPrime(BigInteger value)
		{
			if (value < 3) return false;

			BigInteger maxj = value >> 1;

			for (BigInteger j = 3; j < maxj; j += 2)
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
