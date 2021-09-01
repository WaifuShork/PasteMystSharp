using System;
using System.Threading.Tasks;

namespace PasteMystSharp.Examples
{
	internal static class Program
	{
		private static async Task Main()
		{
			var client = new MystClient();
			var language = await client.GetLanguageByNameAsync("C#");
			Console.WriteLine(language.Name);
			Console.WriteLine(language.Color);
			Console.WriteLine(language.Mode);
		}
	}
}