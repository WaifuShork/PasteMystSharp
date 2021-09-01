namespace PasteMystSharp
{
	using Microsoft.Extensions.Logging;
	
	public static class LoggerEvents
	{
		public static EventId Misc => new(100, "PasteMystSharp");

		public static EventId Startup => new(101, nameof(Startup));

		// public static EventId RestError => new(102, nameof(RestError));
		
		public static EventId RateLimitHit => new(103, nameof(RateLimitHit));
		
		public static EventId RateLimitDiag => new(104, nameof(RateLimitDiag));
		
		public static EventId RateLimitPreemptive => new(105, nameof(RateLimitPreemptive));
	}
}