using IBM.Data.DB2.Core;
using System;
using System.Diagnostics;

namespace ConsolaInforTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			// lets say we want to run this command:    
			//  t=$(echo 'this is a test'); echo "$t" | grep -o 'is a'
		    //var output = ExecuteBashCommand("ln /usr/lib/x86_64-linux-gnu/libxml2.so.2.9.4 /app/clidriver/lib/libxml2.so.2");
			//	var output = ExecuteBashCommand("ln /app/clidriver/lib/libxml2.so.2 /usr/lib/x86_64-linux-gnu/libxml2.so.2");
			//Console.WriteLine(output);

			try
			{
				// 	//dbc:informix-sqli://vu-prd06.pemex.pmx.com:2033/siic:INFORMIXSERVER=siic_tcp;user=osaf0300;password=Pemex.2015
				//		value = "Database=irdoc;Host=172.19.178.18;Server=siic_tcp;Service=2033;Protocol=onsoctcp;UID=cdr;Password=Prod2016;Max Pool Size=400; Min Pool Size=1; Pooling=false;" />
				Console.WriteLine("Opening the connection");

				//DB2Connection connection = new DB2Connection("server=vu-prd06.pemex.pmx.com:2033;uid=osaf0300;pwd=Pemex.2015;database=siic");

				DB2Connection connection = new DB2Connection("Database = irdoc; Server =siic_tcp;  UID=cdr; Password = Prod2016; ");

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

		static string ExecuteBashCommand(string command)
		{
			// according to: https://stackoverflow.com/a/15262019/637142
			// thans to this we will pass everything as one command
			command = command.Replace("\"", "\"\"");

			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "/bin/bash",
					Arguments = "-c \"" + command + "\"",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};

			proc.Start();
			proc.WaitForExit();

			return proc.StandardOutput.ReadToEnd();
		}
	}
}
