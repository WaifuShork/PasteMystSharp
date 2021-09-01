using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasteMystSharp
{
	using System.Text;

	internal static class Extensions
	{
		private static readonly JsonSerializerOptions _serializerOptions = new()
		{
			WriteIndented = true
		};
		
		internal static string PercentEncode(this string value)
		{
			var sb = new StringBuilder();
			foreach (var chr in value)
			{
				if (chr >= 48 && chr <= 57 || // 0-9  
				    chr >= 65 && chr <= 90 || // a-z  
				    chr >= 97 && chr <= 122 || // A-Z                    
				    chr == 45 || chr == 46 || chr == 95 || chr == 126) // period, hyphen, underscore, tilde  
				{  
					sb.Append(chr);  
				}
				else
				{
					sb.AppendFormat("%{0:X2}", (byte)chr);
				}
			}

			return sb.ToString();
		}

		internal static async Task<string> SerializeAsync<T>(this T item)
		{
			await using var stream = new MemoryStream();
			await JsonSerializer.SerializeAsync(stream, item, _serializerOptions);
			return Encoding.UTF8.GetString(stream.ToArray());
		}

		internal static async Task<T> DeserializeAsync<T>(this string contents)
		{
			await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
			return await JsonSerializer.DeserializeAsync<T>(stream, _serializerOptions);
		}
	}
}