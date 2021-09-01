using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasteMystSharp
{
	using System;
	using System.Net.Http;
	using System.Threading;

	internal class RestClient : IDisposable
	{
		private readonly HttpClient _httpClient;

		internal RestClient()
		{
			_httpClient = new HttpClient();
		}

		public async Task<T> GetAsync<T>(string endpoint)
		{
			Console.WriteLine(endpoint);
			var response = await _httpClient.GetStringAsync(endpoint, CancellationToken.None);
			if (response == null)
			{
				throw new ArgumentException("eh");
			}

			Console.WriteLine(response);
			
			return await response.DeserializeAsync<T>();
		}

		public async Task<T> PostAsync<T>(T content, string endpoint)
		{
			var json = new StringContent(await content.SerializeAsync());
			var response = await this._httpClient.PostAsync(endpoint.PercentEncode(), json);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new ArgumentException("eh");
			}

			var returnContent = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<T>(returnContent);
		}

		public async Task<T> DeleteAsync<T>(T content, string endpoint)
		{
			return default;
		}

		public async Task<T> PatchAsync<T>(T content, string endpoint)
		{
			return default;
		}
		
		

		public void Dispose()
		{
			if (_httpClient != null)
			{
				_httpClient.Dispose();
			}
		}
	}
}