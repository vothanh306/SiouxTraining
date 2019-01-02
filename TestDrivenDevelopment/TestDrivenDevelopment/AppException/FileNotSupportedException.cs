namespace TestDrivenDevelopment.AppException
{
	public class FileNotSupportedException : System.Exception
	{
		public FileNotSupportedException(string message) : base(message)
		{
		}
	}
}