using System;

namespace TimeCard
{
	public static class TimeCardExtensions
	{

		public static string FormatForTimeCard(this TimeSpan timeSpan)
		{
			return $"{timeSpan.TotalHours}:{timeSpan.Minutes}:{timeSpan.Seconds}";
		}
	}
}
