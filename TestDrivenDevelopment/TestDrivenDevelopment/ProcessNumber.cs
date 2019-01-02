using System;
using System.Collections.Generic;
using System.Linq;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopment
{
	public class ProcessNumber
	{
		public int GetHighestNumber(List<Tuple<int, List<int>>> numbers, out int[] lines)
		{
			var results = new Dictionary<int, int>();
			var highestNumber = 0;

			foreach (var tuple in numbers)
			{
				foreach (var number in tuple.Item2)
				{
					if (highestNumber > number) continue;

					if (highestNumber < number)
					{
						results.Clear();
					}

					highestNumber = number;
					results.Add(tuple.Item1, number);
				}
			}

			if (results.Count <= 0) throw new ValueNotFoundException("Value is not found");

			lines = results.Keys.ToArray();
			return results.First().Value;
		}

		public int GetLowestNumber(List<Tuple<int, List<int>>> numbers, out int[] lines)
		{
			var results = new Dictionary<int, int>();
			var lowestNumber = int.MaxValue;

			foreach (var tuple in numbers)
			{
				foreach (var number in tuple.Item2)
				{
					if (lowestNumber < number) continue;

					if (lowestNumber > number)
					{
						results.Clear();
					}

					lowestNumber = number;
					results.Add(tuple.Item1, number);
				}
			}

			if (results.Count <= 0) throw new ValueNotFoundException("Value is not found");

			lines = results.Keys.ToArray();
			return results.First().Value;
		}

		public void GetAverageAndSum(List<int> numbers, out double average, out double sum)
		{
			average = numbers.Average();
			sum = numbers.Sum();
		}

		public void GetLineHasMostNumber(List<Tuple<int, List<int>>> numbers, out int[] lines)
		{
			var results = new Dictionary<int, int>();
			var count = 0;

			foreach (var tuple in numbers)
			{
				if (count > tuple.Item2.Count) continue;

				if (count < tuple.Item2.Count)
				{
					results.Clear();
				}

				count = tuple.Item2.Count;
				results.Add(tuple.Item1, count);
			}

			if (results.Count <= 0) throw new ValueNotFoundException("Value is not found");

			lines = results.Keys.ToArray();
		}
	}
}