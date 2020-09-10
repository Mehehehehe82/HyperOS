using System;
using Sys = Cosmos.System;

namespace HyperOS
{
    class ShellUtil
	{
		
		public static void EndSession()
        {
			Sys.Power.Shutdown();
        }
		public ShellUtil(){}
		public static void RunCommand(string command, string[] args)
		{
			switch (command) // This is my idea of commands. yeah i know...
			{
				case "":
					break;
				case "help":
					Console.WriteLine("==================== Help ====================");
					Console.WriteLine("poweroff:                     Shut down system");
					Console.WriteLine("clear:                            Clear screen");
					Console.WriteLine("beep <pitch> <length>:             Play a tone");
					Console.WriteLine("==============================================");
					break;
				case "poweroff":
					Console.WriteLine("Shutting down...");
					Console.Beep(200, 200);
					EndSession();
					break;
				case "clear":
					Console.Clear();
					break;
				/* */
				case "beep": 
					// TODO: make it so that it doesn't crash when typing text
					Int16 pitch = Int16.Parse(args[1]);
					Int16 length = Int16.Parse(args[2]);
					if ( args.Length > 2 )
					{
						Console.Beep(pitch, length);
					}
					else
					{
						Console.WriteLine(MsgPrefix("Bad syntax"));
					}
					break;
				// */
				default:
					Console.WriteLine(MsgPrefix("Unknown command!"));
					break;

			}
		}
		public static string MsgPrefix(string input)
		{
			return $"{DateTime.Now} | {input}";
		}

		public static void ShellPrompt()
		{
			Console.Write(ShellUtil.MsgPrefix("root >"));
			var input = Console.ReadLine();
			var split = input.Split(' ');
			ShellUtil.RunCommand(split[0], split);
		}

		public void InitiallizeSession()
		{
			Console.Beep(400, 100);
			Console.Beep(600, 100);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.WriteLine("Hyper OS booted successfully. Type a command, or type help.");
		}
	}
}
