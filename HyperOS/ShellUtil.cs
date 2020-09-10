using System;
using Sys = Cosmos.System;

namespace HyperOS
{
    class ShellUtil
    {
        Kernel kernel;
        public ShellUtil(Kernel kernelInput)
        {
            kernel = kernelInput;
        }
        public static void RunCommand(string command, string[] args)
        {
            switch (command)
            {
                case "":
                    break;
                case "help":
                    Console.WriteLine("==================== Help ====================");
                    Console.WriteLine("poweroff:				Shut down system");
                    Console.WriteLine("clear:					Clear screen");
                    Console.WriteLine("beep <pitch> <length>:	Play a tone");
                    Console.WriteLine("==============================================");
                    break;
                case "poweroff":
                    Console.WriteLine("Shutting down...");
                    Console.Beep(200, 200);
                    Sys.Power.Shutdown();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                /* */
                case "beep":
                    Int16 pitch;
                    Int16 length;
                    if (
                        args.Length > 2
                        && Int16.TryParse(args[2], out length)
                        && Int16.TryParse(args[1], out pitch)
                    )
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
    }
}
