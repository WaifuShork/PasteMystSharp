namespace PasteMystSharp.Entities 
{
	using System;
	using System.Text.Json.Serialization;
	
	// GET: /data/languageExt?extension=
	// GET: /data/language?name=
	public class Language
	{
		[JsonIgnore]
		internal static readonly Func<string, string> NameEndpoint = languageName => $"{Endpoints.BaseEndpoint}/data/language?name={languageName}";
		
		[JsonIgnore]
		internal static readonly Func<string, string> ExtensionEndpoint = extensionName => $"{Endpoints.BaseEndpoint}/data/languageExt?extension={extensionName}";

		[JsonPropertyName("name")]
		public string Name { get; set; }
		
		[JsonPropertyName("mode")]
		public string Mode { get; set; }
		
		[JsonPropertyName("mimes")]
		public string[] Mimes { get; set; }
		
		[JsonPropertyName("ext")]
		public string[] Extensions { get; set; }
		
		[JsonPropertyName("color")]
		public string Color { get; set; }
	}
}