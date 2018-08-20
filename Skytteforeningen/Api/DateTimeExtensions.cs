using System;

namespace Api
{
    public static class DateTimeExtensions
    {
        public static long ToUnixEpochDate(this DateTime date)
        {
            var timeSpan = date.ToUniversalTime() -
                           new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

            return (long)Math.Round(timeSpan.TotalSeconds);
        }
    }
}