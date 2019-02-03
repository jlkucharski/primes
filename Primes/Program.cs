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
				{"Find n primes", () => { FindFirstNPrimes(); } },
				{"Find primes in bit range", () => { FindPrimesInBitRange(); } }
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

		static void FindPrimesInBitRange()
		{
			Console.WriteLine("Provide number of bits to look up");
			var line = Console.ReadLine();
			int bits = int.Parse(line);

			BigInteger min = new BigInteger(1) << bits;
			BigInteger max = (min << 1) - 1;

			FindPrimes(min, max);
		}

		static void FindPrimesInRange()
		{
			Console.WriteLine("Provide min (enter to use default 3)");
			var line = Console.ReadLine();
			BigInteger min = string.IsNullOrWhiteSpace(line) ? 3 : BigInteger.Parse(line);

			Console.WriteLine("Provide max");
			line = Console.ReadLine();
			BigInteger max = BigInteger.Parse(line);

			FindPrimes(min, max);
		}

		private static void FindPrimes(BigInteger min, BigInteger max)
		{
			BigInteger primeCount = 0;
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine($"Trying to find primes lower or equal to {max}...");

			stopwatch.Start();
			for (BigInteger i = min.IsEven ? min + 1 : min; i <= max; i += 2)
			{
				if (IsPrime(i))
				{
					primeCount++;
					Console.WriteLine(i);
				}
			}
			stopwatch.Stop();

			Console.WriteLine();
			Console.WriteLine($"Found {primeCount} primes in range from {min} to {max} in {stopwatch.ElapsedMilliseconds}ms.");
		}

		static bool IsPrime(BigInteger value)
		{
			if (value < 3 || value.IsEven || value.IsPowerOfTwo) return false;

			for (BigInteger j = 3; j < value >> 1; j += 2)
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
