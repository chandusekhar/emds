namespace Encog.Util.Time
{
    using System;

    internal class x3dee5ff19639f5c6 : x7d9d2bab121fc402
    {
        public string x245c043bccc9a2f0(TimeUnit x1c40252c1b8530fe)
        {
            switch (x1c40252c1b8530fe)
            {
                case TimeUnit.Seconds:
                    return "seconds";

                case TimeUnit.Minutes:
                    return "minutes";

                case TimeUnit.Hours:
                    return "hours";

                case TimeUnit.Days:
                    return "days";

                case TimeUnit.Weeks:
                    goto Label_001C;

                case TimeUnit.Fortnights:
                    return "fortnights";

                case TimeUnit.Months:
                    return "months";

                case TimeUnit.Years:
                    return "years";

                case TimeUnit.Decades:
                    return "decades";

                case TimeUnit.Scores:
                    return "scores";

                case TimeUnit.Centuries:
                    return "centures";

                case TimeUnit.Millennia:
                    break;

                default:
                    if (0 == 0)
                    {
                        if (4 == 0)
                        {
                            break;
                        }
                        return "unknowns";
                    }
                    goto Label_001C;
            }
            return "millennia";
        Label_001C:
            return "weeks";
        }

        public string xa7b27eb509663b32(TimeUnit x1c40252c1b8530fe)
        {
            switch (x1c40252c1b8530fe)
            {
                case TimeUnit.Seconds:
                    return "second";

                case TimeUnit.Minutes:
                    return "minute";

                case TimeUnit.Hours:
                    return "hour";

                case TimeUnit.Days:
                    return "day";

                case TimeUnit.Weeks:
                    return "week";

                case TimeUnit.Fortnights:
                    return "fortnight";

                case TimeUnit.Months:
                    return "month";

                case TimeUnit.Years:
                    return "year";

                case TimeUnit.Decades:
                    return "decade";

                case TimeUnit.Scores:
                    return "score";

                case TimeUnit.Centuries:
                    return "century";

                case TimeUnit.Millennia:
                    return "millenium";
            }
            return "unknown";
        }

        public string xb0b4ff1622a01d12(TimeUnit x1c40252c1b8530fe)
        {
            switch (x1c40252c1b8530fe)
            {
                case TimeUnit.Seconds:
                    return "sec";

                case TimeUnit.Minutes:
                    return "min";

                case TimeUnit.Hours:
                    return "hr";

                case TimeUnit.Days:
                    return "d";

                case TimeUnit.Weeks:
                    return "w";

                case TimeUnit.Fortnights:
                    return "fn";

                case TimeUnit.Months:
                    return "m";

                case TimeUnit.Years:
                    return "y";

                case TimeUnit.Decades:
                    return "dec";

                case TimeUnit.Scores:
                    return "sc";

                case TimeUnit.Centuries:
                    break;

                case TimeUnit.Millennia:
                    return "m";

                default:
                    if (0 != 0)
                    {
                        break;
                    }
                    return "unk";
            }
            return "c";
        }
    }
}

