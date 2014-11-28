using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Services
{
	public static class CommonService
	{
		public static DateTime Trim(this DateTime date, long roundTicks)
		{
			return new DateTime(date.Ticks - date.Ticks % roundTicks);
		}

		public static DateTime TrimToDay(this DateTime date)
		{
			return date.Trim(TimeSpan.TicksPerDay);
		}
	}
}
