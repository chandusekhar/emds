namespace Encog.Util
{
    using System;
    using System.Text;

    public class Format
    {
        public const double HundredPercent = 100.0;
        public const long MemoryGig = 0x40000000L;
        public const long MemoryK = 0x400L;
        public const long MemoryMeg = 0x100000L;
        public const long MemoryTera = 0x10000000000L;
        public const long MiliInSec = 0x3e8L;
        public const int SecondsInaDay = 0x15180;
        public const int SecondsInaHour = 0xe10;
        public const int SecondsInaMinute = 60;

        private Format()
        {
        }

        public static string FormatDouble(double d, int i)
        {
            return d.ToString("N" + i);
        }

        public static string FormatInteger(int i)
        {
            return string.Format("{0:n0}", i);
        }

        public static string FormatMemory(long memory)
        {
            if (memory < 0x400L)
            {
                return (memory + " bytes");
            }
        Label_003C:
            if (memory < 0x100000L)
            {
                return (FormatDouble(((double) memory) / 1024.0, 2) + " KB");
            }
        Label_005F:
            if (memory >= 0x40000000L)
            {
                if (memory < 0x10000000000L)
                {
                    return (FormatDouble(((double) memory) / 1073741824.0, 2) + " GB");
                }
                return (FormatDouble(((double) memory) / 1099511627776, 2) + " TB");
            }
            if ((((uint) memory) & 0) != 0)
            {
                if ((((uint) memory) + ((uint) memory)) < 0)
                {
                    goto Label_003C;
                }
                goto Label_005F;
            }
            return (FormatDouble(((double) memory) / 1048576.0, 2) + " MB");
        }

        public static string FormatPercent(double e)
        {
            double num = e * 100.0;
            return (num.ToString("N6") + "%");
        }

        public static string FormatPercentWhole(double e)
        {
            double num = e * 100.0;
            return (num.ToString("N0") + "%");
        }

        public static string FormatTimeSpan(int seconds)
        {
            int num2;
            int num3;
            int num4;
            StringBuilder builder;
            int num = seconds;
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_012B;
            }
            goto Label_008C;
        Label_0056:
            builder.Append(num3.ToString("00"));
            builder.Append(':');
            if ((((uint) num) + ((uint) num2)) >= 0)
            {
                builder.Append(num4.ToString("00"));
                builder.Append(':');
                builder.Append(num.ToString("00"));
                if ((((uint) seconds) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0162;
                }
                goto Label_012B;
            }
        Label_008C:
            builder = new StringBuilder();
            if ((((uint) num4) - ((uint) num2)) <= uint.MaxValue)
            {
                if (0 != 0)
                {
                    goto Label_0162;
                }
                if (num2 > 0)
                {
                    builder.Append(num2);
                    builder.Append((num2 > 1) ? " days " : " day ");
                }
                goto Label_0056;
            }
        Label_00F8:
            num -= num3 * 0xe10;
            num4 = num / 60;
            if ((((uint) num2) | 0xfffffffe) == 0)
            {
                goto Label_0056;
            }
            num -= num4 * 60;
            goto Label_008C;
        Label_012B:
            num2 = seconds / 0x15180;
            num -= num2 * 0x15180;
            num3 = num / 0xe10;
            if ((((uint) seconds) - ((uint) seconds)) >= 0)
            {
                goto Label_00F8;
            }
            goto Label_008C;
        Label_0162:
            return builder.ToString();
        }

        public static string FormatYesNo(bool p)
        {
            if (!p)
            {
                return "No";
            }
            return "Yes";
        }
    }
}

