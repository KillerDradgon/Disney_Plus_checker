using System;
using Colorful;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Disney_
{
    class LogoPrint
    {
		

		public static void print()
        {
			foreach (string text in new List<string>
			{
				"\n",
				"  ____  _                            ",
				" |  _ \\(_)___ _ __   ___ _   _   _   ",
				" | | | | / __| '_ \\ / _ \\ | | |_| |_ ",
				" | |_| | \\__ \\ | | |  __/ |_| |_   _|",
				" |____/|_|___/_| |_|\\___|\\__, | |_|  ",
				"                         |___/       "
			})
			{
				Colorful.Console.WriteLine(string.Format("{0," + (Colorful.Console.WindowWidth / 2 + text.Length / 2) + "}", text));
			}

			Colorful.Console.WriteLine();
			Colorful.Console.WriteLine(string.Format("{0, " + (Colorful.Console.WindowWidth / 2 + "                     [Version 1.0]                      ".Length / 2) + "}", "                     [Version 1.0]                      "));
			Colorful.Console.WriteLine();
			Colorful.Console.WriteLine();
		}
    }
}
