namespace Encog.App.Analyst.Util
{
    using Encog.App.Analyst;
    using Encog.Util.CSV;
    using System;

    public sealed class ConvertStringConst
    {
        private ConvertStringConst()
        {
        }

        public static string AnalystFileFormat2String(AnalystFileFormat af)
        {
            if (af != AnalystFileFormat.DecpntComma)
            {
                if (af == AnalystFileFormat.DecpntSpace)
                {
                    return "decpnt|space";
                }
                if (af == AnalystFileFormat.DecpntSemi)
                {
                    return "decpnt|semi";
                }
                goto Label_001B;
            }
            if (8 != 0)
            {
                goto Label_003E;
            }
        Label_000A:
            if (af != AnalystFileFormat.DeccommaSemi)
            {
                return null;
            }
        Label_000E:
            if (4 != 0)
            {
                return "deccomma|semi";
            }
        Label_001B:
            if (af == AnalystFileFormat.DeccommaSpace)
            {
                return "deccomma|space";
            }
            if (0 == 0)
            {
                goto Label_000A;
            }
        Label_003E:
            if (3 == 0)
            {
                goto Label_000E;
            }
            return "decpnt|comma";
        }

        public static CSVFormat ConvertToCSVFormat(AnalystFileFormat af)
        {
            if (af != AnalystFileFormat.DecpntComma)
            {
                if (af == AnalystFileFormat.DecpntSpace)
                {
                    return new CSVFormat('.', ' ');
                }
                if (af != AnalystFileFormat.DecpntSemi)
                {
                    if (af != AnalystFileFormat.DeccommaSpace)
                    {
                        if (af == AnalystFileFormat.DeccommaSemi)
                        {
                            return new CSVFormat(',', ';');
                        }
                        if (0 == 0)
                        {
                        }
                        return null;
                    }
                }
                else if (0 == 0)
                {
                    return new CSVFormat('.', ';');
                }
            }
            else
            {
                return new CSVFormat('.', ',');
            }
            return new CSVFormat(',', ' ');
        }

        public static AnalystFileFormat String2AnalystFileFormat(string str)
        {
            if (!str.Equals("decpnt|comma", StringComparison.InvariantCultureIgnoreCase))
            {
                if (str.Equals("decpnt|space", StringComparison.InvariantCultureIgnoreCase))
                {
                    return AnalystFileFormat.DecpntSpace;
                }
                if (str.Equals("decpnt|semi", StringComparison.InvariantCultureIgnoreCase))
                {
                    return AnalystFileFormat.DecpntSemi;
                }
                if (0 == 0)
                {
                    if (!str.Equals("decpnt|space", StringComparison.InvariantCultureIgnoreCase))
                    {
                        goto Label_0022;
                    }
                    if (1 != 0)
                    {
                        return AnalystFileFormat.DeccommaSpace;
                    }
                    if (1 != 0)
                    {
                        goto Label_0022;
                    }
                    goto Label_0020;
                }
            }
            return AnalystFileFormat.DecpntComma;
        Label_0020:
            return AnalystFileFormat.DeccommaSemi;
        Label_0022:
            if (str.Equals("decpnt|semi", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_0020;
            }
            return AnalystFileFormat.Unknown;
        }

        public static AnalystGoal String2AnalystGoal(string str)
        {
            if (string.Compare(str, "classification", true) == 0)
            {
                return AnalystGoal.Classification;
            }
            if (string.Compare(str, "regression", true) == 0)
            {
                return AnalystGoal.Regression;
            }
            return AnalystGoal.Unknown;
        }
    }
}

