using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDevelopment;

namespace TestDrivenDevelopmentTest
{
	[TestClass]
	public class FilterNumberHelperTest
	{
		[TestMethod]
		public void InputNumberHasNumberMoreThan8Digit()
		{
			//Arrange
			var lines = new string[]
			{
				"2 abc 123456789"
			};

			//Act
			var numbers = FilterNumberHelper.FilterNumber(lines);

			//Assert
			Assert.AreEqual(1, numbers.Count);
			Assert.AreEqual(1, numbers[0].Item1);
			Assert.AreEqual(2, numbers[0].Item2[0]);
		}

		[TestMethod]
		public void InputNumberHasNegativeNumber()
		{
			//Arrange
			var lines = new string[]
			{
				"2 abc -10"
			};

			//Act
			var numbers = FilterNumberHelper.FilterNumber(lines);

			//Assert
			Assert.AreEqual(1, numbers.Count);
			Assert.AreEqual(1, numbers[0].Item1);
			Assert.AreEqual(2, numbers[0].Item2[0]);
		}

		[TestMethod]
		public void FilterInputNumber()
		{
			//Arrange
			var lines = new string[]
			{
				"1 12345678",
				"asdsad asdsd",
				"8 12 123.456"
			};

			//Act
			var numbers = FilterNumberHelper.FilterNumber(lines);

			//Assert
			Assert.AreEqual(2, numbers.Count);
			Assert.AreEqual(2, numbers[0].Item2.Count);
			Assert.AreEqual(2, numbers[1].Item2.Count);
		}
	}
}