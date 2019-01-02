using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopment
{
	public static class FilterNumberHelper
	{
		private const int MaximumDigitOfNumber = 8;

		private const string NumberRegex = @"^\d+$";

		public static List<Tuple<int, List<int>>> FilterNumber(string[] lines)
		{
			var output = new List<Tuple<int, List<int>>>();
			var numberRegex = new Regex(NumberRegex);

			for(var i=0;i < lines.Length; i++)
			{
				var words = lines[i].Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

				var numbers = new List<int>();

				foreach (var word in words)
				{
					if (!numberRegex.IsMatch(word)) continue;

					try
					{
						var number = GetNumber(word);
						numbers.Add(number);
					}
					catch (InvalidNumberException)
					{
					}
				}

				if (numbers.Count > 0)
				{
					output.Add(Tuple.Create(i+1, numbers));
				}
				
			}

			return output;
		}

		public static int GetNumber(string number)
		{
			if (int.TryParse(number, out var outputNumber) && outputNumber > 0 && outputNumber.ToString().Length <= MaximumDigitOfNumber)
			{
				return outputNumber;
			}

			throw new InvalidNumberException("Invalid number");
		}
	}
}