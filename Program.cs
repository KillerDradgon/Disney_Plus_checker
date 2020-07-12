using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using System.Drawing;
using System.IO;
using System.Collections.Concurrent;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Threading;


//The Main File
// https://discord.gg/a5fVCub
//join my discord server!

namespace Disney_
{
    class Program
    {
        static void Main(string[] args)
        {
            Colorful.Console.Title = "Disney+ Checker Cracked by [Dragon_God#7877]OVERHAX";
            LogoPrint.print();
            int threads = InManager.thread_count();
            string proxy_type = InManager.proxy_sellect();
            string combo_path = InManager.path_find("combo");
			
			ConcurrentQueue<string> concurrentQueue = new ConcurrentQueue<string>();
			if (!File.Exists(combo_path))
			{
				MessageBox.Show("Please Create a Combo file in the same folder as the checker");
				System.Environment.Exit(0);

			}
			else
			{
				using (FileStream fileStream = File.Open(combo_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (BufferedStream bufferedStream = new BufferedStream(fileStream))
					{
						using (StreamReader streamReader = new StreamReader(bufferedStream))
						{
							string text2;
							while ((text2 = streamReader.ReadLine()) != null)
							{
								if (text2.Contains(":"))
								{
									concurrentQueue.Enqueue(text2);
								}
							}
						}
					}
				}
			}
			List<string> list = new List<string>();
			if (proxy_type != "4")
			{
				if (!File.Exists(InManager.path_find("proxies")))
				{
					MessageBox.Show("Please Create a Proxy file in the same folder as the checker.");
					System.Environment.Exit(0);
				}
				else
				{
					foreach (string item in File.ReadAllLines(InManager.path_find("proxies")))
					{
						list.Add(item);
					}
				}
			}
			Colorful.Console.WriteLine();
			Colorful.Console.WriteLine();

			important @class = new important(concurrentQueue, list, combo_path);

			@class.method_0();
			class3.bool_0 = true;
			@class.method_6();
			@class.method_4();
			@class.method_3(threads);

		}
    }
}
