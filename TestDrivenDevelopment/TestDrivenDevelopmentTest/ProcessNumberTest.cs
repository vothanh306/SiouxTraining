using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDevelopment;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopmentTest
{
	[TestClass]
	public class ProcessNumberTest
	{
		[TestMethod]
		public void GetHighestNumber()
		{
			//Arrange
			var numbers = new List<Tuple<int, List<int>>>
			{
				Tuple.Create(1, new List<int> {1, 12345678}),
				Tuple.Create(2, new List<int> {5, 12345678})
			};

			//Act
			var processNumber = new ProcessNumber();
			var highestNumber = processNumber.GetHighestNumber(numbers, out var lines);
			//Assert
			Assert.AreEqual(12345678, highestNumber);
			Assert.AreEqual(2, lines.Length);
			Assert.AreEqual(1, lines[0]);
			Assert.AreEqual(2, lines[1]);
		}

		[TestMethod]
		[ExpectedException(typeof(ValueNotFoundException), "Value is not found")]
		public void NoNumberInContentFile()
		{
			//Arrange
			var numbers = new List<Tuple<int, List<int>>>();

			//Act
			var processNumber = new ProcessNumber();
			processNumber.GetHighestNumber(numbers, out var lines);
		}

		[TestMethod]
		public void GetLowestNumber()
		{
			//Arrange
			var numbers = new List<Tuple<int, List<int>>>
			{
				Tuple.Create(1, new List<int> {1, 12345678}),
				Tuple.Create(2, new List<int> {5, 12345678})
			};

			//Act
			var processNumber = new ProcessNumber();
			var lowestNumber = processNumber.GetLowestNumber(numbers, out var lines);
			//Assert
			Assert.AreEqual(1, lowestNumber);
			Assert.AreEqual(1, lines.Length);
			Assert.AreEqual(1, lines[0]);
		}

		[TestMethod]
		public void GetAverageAndSumNumber()
		{
			//Arrange
			var numbers = new List<int> {1, 12345678};

			//Act
			var processNumber = new ProcessNumber();
			processNumber.GetAverageAndSum(numbers, out var average, out var sum);

			//Assert
			Assert.AreEqual(6172839.5, average);
			Assert.AreEqual(12345679, sum);
		}

		[TestMethod]
		public void GetLineWithMostNumber()
		{
			//Arrange
			var numbers = new List<Tuple<int, List<int>>>
			{
				Tuple.Create(1, new List<int> {1, 12, 12345678}),
				Tuple.Create(2, new List<int> {5, 1, 2, 12345678}),
				Tuple.Create(4, new List<int> {50, 11, 22, 23})
			};

			//Act
			var processNumber = new ProcessNumber();
			processNumber.GetLineHasMostNumber(numbers, out var lines);

			//Assert
			Assert.AreEqual(2, lines.Length);
			Assert.AreEqual(2, lines[0]);
			Assert.AreEqual(4, lines[1]);
		}
	}
}