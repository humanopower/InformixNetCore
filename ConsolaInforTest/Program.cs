using IBM.Data.DB2.Core;
using System;

namespace ConsolaInforTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");


			try

			{
				//dbc:informix-sqli://vu-prd06.pemex.pmx.com:2033/siic:INFORMIXSERVER=siic_tcp;user=osaf0300;password=Pemex.2015
				Console.WriteLine("Opening the connection");

				DB2Connection connection = new DB2Connection("server=vu-prd06.pemex.pmx.com:2033;uid=osaf0300;pwd=Pemex.2015;database=siic");

				connection.Open();

				Console.WriteLine("Connection open");



			}

			catch (Exception dbException)

			{

				Console.WriteLine("Exception: " + dbException.Message);

			}



			var counter = 0;
			var max = args.Length != 0 ? Convert.ToInt32(args[0]) : -1;
			while (max == -1 || counter < max)
			{
				counter++;
				Console.WriteLine($"Counter: {counter}");
				System.Threading.Tasks.Task.Delay(1000).Wait();
			}
		}
	}
}
