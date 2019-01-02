using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDevelopment;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopmentTest
{
	[TestClass]
	public class FileHelperTest
	{
		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException), "File is not found")]
		public void FileNotFound()
		{
			//Arrange
			var filePath = "C:\\Desktop\aaaa.txt";

			//Act
			FileHelper.ReadFile(filePath);
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotSupportedException), "File is not supported")]
		public void FileNotSupported()
		{
			//Arrange
			var filePath = "C:\\Users\\vot\\Desktop\\Project Plan.xls";

			//Act
			FileHelper.ReadFile(filePath);
		}

		[TestMethod]
		public void ReadFile()
		{
			//Arrange
			var filePath = "C:\\Users\\vot\\Desktop\\test.txt";

			//Act
			var lines = FileHelper.ReadFile(filePath);

			//Assert
			Assert.AreNotEqual(0, lines.Length);
		}
	}
}