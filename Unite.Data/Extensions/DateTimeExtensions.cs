using System;

namespace Unite.Data.Extensions
{
    public static class DateTimeExtensions
    {
        public static int? RelativeFrom(this DateTime? eventDate, DateTime? referenceDate)
        {
            return referenceDate != null && eventDate != null
                ? eventDate.Value.RelativeFrom(referenceDate.Value)
                : null;
        }

        public static int? RelativeFrom(this DateTime? eventDate, DateTime referenceDate)
        {
            return eventDate != null
                ? eventDate.Value.RelativeFrom(referenceDate)
                : null;
        }

        public static int? RelativeFrom(this DateTime eventDate, DateTime? referenceDate)
        {
            return referenceDate != null
                ? eventDate.RelativeFrom(referenceDate.Value)
                : null;
        }

        public static int RelativeFrom(this DateTime eventDate, DateTime referenceDate)
        {
            return (Normalise(eventDate) - Normalise(referenceDate)).Days;
        }


        private static DateTime Normalise(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 12, 00, 00);
        }
    }
}
