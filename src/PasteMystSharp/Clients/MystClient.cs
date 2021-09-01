using System.Threading.Tasks;

namespace PasteMystSharp
{
	using System;
	using Entities;

	public class MystClient : IDisposable
	{
		private readonly RestClient _restClient;
		
		public MystClient()
		{
			_restClient = new();
		}
		
		public async Task<Language> GetLanguageByNameAsync(string name)
		{
			return await _restClient.GetAsync<Language>(Language.NameEndpoint(name.PercentEncode()));
		}
		
		public async Task<Language> GetLanguageByExtension(string name)
		{
			return await _restClient.GetAsync<Language>(Language.ExtensionEndpoint(name));
		}
		
		public void Dispose()
		{
			if (_restClient != null)
			{
				_restClient.Dispose();
			}
		}
	}
}