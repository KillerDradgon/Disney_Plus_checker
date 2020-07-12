using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Disney_
{
    class InManager
    {








		public static void smethod_0()
		{
			Colorful.Console.Write(DateTime.Now.ToString("h:mm:ss | "), Color.White);
		}




		// Takes User Input for thread Count;
		public static int thread_count() {

			int result;
			for (; ; )
			{
				InManager.smethod_0();
				Colorful.Console.Write("Threads amount : ", Color.DarkSlateBlue);
				Colorful.Console.ForegroundColor = Color.White;
				try
				{
					int num = Convert.ToInt32(Colorful.Console.ReadLine());
					Colorful.Console.ResetColor();
					result = num;
				}
				catch
				{
					Colorful.Console.ForegroundColor = Color.Yellow;
					Colorful.Console.WriteLine("[Error: Must be an integer]");
					Colorful.Console.ResetColor();
					continue;
				}
				break;
			}
			return result;





        }


		public static string proxy_sellect()
        {
			string result;
			for (; ; )
			{
				InManager.smethod_0();
				Colorful.Console.Write("[1]HTTP/[2]SOCKS4/[3]SOCKS5 : ", Color.DarkSlateBlue);
				Colorful.Console.ForegroundColor = Color.White;
				try
				{
					string text = Colorful.Console.ReadKey().KeyChar.ToString();
					Colorful.Console.WriteLine();
					Colorful.Console.ResetColor();
					if (!(text == "1") && !(text == "2") && !(text == "3"))
					{
						Colorful.Console.ForegroundColor = Color.Yellow;
						Colorful.Console.WriteLine("[Error: Must be an integer between 1 and 3]");
						Colorful.Console.ResetColor();
						continue;
					}
					result = text;
				}
				catch
				{
					Colorful.Console.ForegroundColor = Color.Yellow;
					Colorful.Console.WriteLine("[Error: Must be an integer]");
					Colorful.Console.ResetColor();
					continue;
				}
				break;
			}
			return result;
		}

		public static string path_find(string string_0)
        {
			string path = Application.StartupPath;
			string fileName;
            if (!string_0.Contains(".txt"))
            {
				string_0 = string_0+".txt";
            }
			fileName = path + "\\" + string_0;

			return fileName;
		}




    }
}
