using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace HyperOS
{
	public class Kernel : Sys.Kernel
	{
		ShellUtil commandExecutor;
		protected override void BeforeRun()
		{
			commandExecutor = new ShellUtil(this);
			Console.Beep(400, 100);
			Console.Beep(600, 100);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.WriteLine("Hyper OS booted successfully. Type a command, or type help.");
		}

		protected override void Run()
		{
			ShellUtil.ShellPrompt();
		}



		
	}
}
