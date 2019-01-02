using System;

namespace TestDrivenDevelopment.AppException
{
	public class FileNotFoundException : Exception
	{
		public FileNotFoundException(string message) : base(message)
		{
		}
	}
}