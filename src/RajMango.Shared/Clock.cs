namespace RajMango.Shared
{
    public static class Clock
    {
        private static readonly TimeZoneInfo BnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");

        private static Func<DateTime> now;

        static Clock()
        {
            Reset();
        }

        public static TimeZoneInfo TimeZoneInfo => BnTimeZone;

        public static Func<DateTime> Now
        {
            get { return now; }

            set { now = value; }
        }

        public static void Reset()
        {
            now = () => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, BnTimeZone);
        }
    }
}
