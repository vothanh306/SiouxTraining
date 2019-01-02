using System;

namespace TestDrivenDevelopment.AppException
{
	public class InvalidNumberException : Exception
	{
		public InvalidNumberException(string message) : base(message)
		{
		}
	}

	public class ValueNotFoundException : Exception
	{
		public ValueNotFoundException(string message) : base(message)
		{
		}
	}
}