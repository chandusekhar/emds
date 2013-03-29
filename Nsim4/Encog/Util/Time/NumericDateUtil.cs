namespace Encog.Util.Time
{
    using System;

    public static class NumericDateUtil
    {
        public const uint HourOffset = 0x2710;
        public const uint MinuteOffset = 100;
        public const uint MonthOffset = 100;
        public const uint YearOffset = 0x2710;

        public static ulong Combine(ulong date, uint time)
        {
            return ((date * ((ulong) 0xf4240L)) + time);
        }

        public static ulong DateTime2Long(DateTime time)
        {
            return (ulong) ((time.Day + (time.Month * 100L)) + (time.Year * 0x2710L));
        }

        public static int GetDayOfWeek(ulong p)
        {
            DateTime time = Long2DateTime(p);
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 0;

                case DayOfWeek.Monday:
                    return 1;

                case DayOfWeek.Tuesday:
                    return 2;

                case DayOfWeek.Wednesday:
                    return 3;

                case DayOfWeek.Thursday:
                    return 4;

                case DayOfWeek.Friday:
                    break;

                case DayOfWeek.Saturday:
                    return 6;

                default:
                    if (15 == 0)
                    {
                        break;
                    }
                    return -1;
            }
            return 5;
        }

        public static int GetMinutePeriod(uint time, int period)
        {
            uint num = time;
            int num2 = (int) (num / 0x2710);
            num -= (uint) (num2 * 0x2710L);
            int num3 = (int) (num / 100);
            int num4 = num3 + (num2 * 60);
            return (num4 / period);
        }

        public static int GetMonth(ulong l)
        {
            long num = (long) l;
            int num2 = (int) (num / 0x2710L);
            num -= num2 * 0x2710L;
            return (int) (num / 100L);
        }

        public static int GetYear(ulong date)
        {
            return (int) (date / ((ulong) 0x2710L));
        }

        public static bool HaveSameDate(DateTime d1, DateTime d2)
        {
            if (d1.Day == d2.Day)
            {
                if (0 != 0)
                {
                }
                if (d1.Month == d2.Month)
                {
                    return (d1.Year == d2.Year);
                }
                if (-2 != 0)
                {
                }
            }
            return false;
        }

        public static DateTime Long2DateTime(ulong l)
        {
            int num4;
            long num = (long) l;
            int year = (int) (num / 0x2710L);
            num -= year * 0x2710L;
            int month = (int) (num / 100L);
            num -= month * 100L;
            if ((((uint) num) + ((uint) num4)) >= 0)
            {
                num4 = (int) num;
            }
            return new DateTime(year, month, num4);
        }

        public static DateTime StripTime(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }

        internal static DateTime x76350670e7ca3047(DateTime xccf8b068badcb542, uint x7b28e8a789372508)
        {
            uint num = x7b28e8a789372508;
            int hour = (int) (num / 0x2710);
            num -= (uint) (hour * 0x2710L);
            int minute = (int) (num / 100);
            num -= (uint) (minute * 100L);
            int second = (int) num;
            if ((num + num) >= 0)
            {
            }
            return new DateTime(xccf8b068badcb542.Year, xccf8b068badcb542.Month, xccf8b068badcb542.Day, hour, minute, second);
        }

        internal static uint x93295384d7a86d9d(DateTime x0ebe150470f7718d)
        {
            return (uint) ((x0ebe150470f7718d.Second + (x0ebe150470f7718d.Minute * 100L)) + (x0ebe150470f7718d.Hour * 0x2710L));
        }
    }
}

