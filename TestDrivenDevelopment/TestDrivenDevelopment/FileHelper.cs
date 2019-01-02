using System.IO;
using System.Text.RegularExpressions;
using TestDrivenDevelopment.AppException;

namespace TestDrivenDevelopment
{
	public static class FileHelper
	{
		private const string SupportedExtensions = "^*(.txt|.TXT|.xml|.XML)$";

		public static string[] ReadFile(string filePath)
		{
			if (!File.Exists(filePath)) throw new AppException.FileNotFoundException("File is not found");

			var regex = new Regex(SupportedExtensions);

			if (!regex.IsMatch(filePath)) throw new FileNotSupportedException("File is not supported");

			return File.ReadAllLines(filePath);
		}
	}
}