using Sys = Cosmos.System;
// This file is simply a wrapper for ShellUtil. You could write a similar wrapper in a Console app project.
namespace HyperOS
{
    public class Kernel : Sys.Kernel
	{
        private ShellUtil shellUtil;
		protected override void BeforeRun()
		{
			shellUtil = new ShellUtil();
			shellUtil.InitiallizeSession();
		}

		protected override void Run()
		{
			ShellUtil.ShellPrompt();
		}

		
	}
}
