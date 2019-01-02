using System;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopment
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter file path");
			string filePath;
			do
			{
				filePath = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(filePath));

			try
			{
				var lines = FileHelper.ReadFile(filePath);
				var numbers = FilterNumberHelper.FilterNumber(lines);
				var processNumber = new ProcessNumber();

				var highestNumber = processNumber.GetHighestNumber(numbers, out var highestLines);
				Console.WriteLine($"Highest number = {highestNumber} in line {string.Join(", ", highestLines)}");

				var lowestNumber = processNumber.GetLowestNumber(numbers, out var lowestLines);
				Console.WriteLine($"Lowest number = {lowestNumber} in line {string.Join(", ", lowestLines)}");

				processNumber.GetLineHasMostNumber(numbers, out var mostNumnerlines);
				Console.WriteLine($"Line with most number in it: {string.Join(", ", mostNumnerlines)}");

				foreach (var number in numbers)
				{
					processNumber.GetAverageAndSum(number.Item2, out var average, out var sum);
					Console.WriteLine($"Line {number.Item1}: AVG = {average} SUM = {sum}");
				}
			}
			catch (FileNotFoundException fileNotFoundException)
			{
				Console.WriteLine(fileNotFoundException.Message);
			}
			catch (FileNotSupportedException fileNotSupportedException)
			{
				Console.WriteLine(fileNotSupportedException.Message);
			}
			catch (ValueNotFoundException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.ReadLine();
		}
	}
}