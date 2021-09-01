using System;
using System.Threading.Tasks;
using Xunit;

namespace PasteMystSharp.Tests
{
	public class MystClientTests
	{
		private static readonly MystClient _mystClient = new();
		
		[Fact]
		public async Task Test_GetLanguageByName()
		{
			var language = await _mystClient.GetLanguageByNameAsync("C#");
			Assert.Equal("C#", language.Name);
			Assert.NotNull(language);
		}
	}
}