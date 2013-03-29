namespace Encog.ML.Factory.Parse
{
    using Encog;
    using Encog.Util;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ArchitectureParse
    {
        public static ArchitectureLayer ParseLayer(string line, int defaultValue)
        {
            int num;
            int num2;
            ArchitectureLayer layer = new ArchitectureLayer();
            string str = line.Trim().ToUpper();
            goto Label_0170;
        Label_0043:
            if ((((uint) defaultValue) & 0) != 0)
            {
                goto Label_00E5;
            }
        Label_005A:
            layer.Name = str.Substring(0, num).Trim();
            string str2 = str.Substring(num + 1, num2 - (num + 1));
            if ((((uint) num) | 0xff) == 0)
            {
                goto Label_00F7;
            }
            IDictionary<string, string> source = ParseParams(str2);
            EngineArray.PutAll<string, string>(source, layer.Params);
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_0104;
            }
            if (((uint) defaultValue) < 0)
            {
                goto Label_005A;
            }
            return layer;
        Label_00B9:
            if (num == -1)
            {
                layer.Name = str;
                return layer;
            }
            goto Label_00E5;
        Label_00BF:
            throw new EncogError("Illegal parentheses.");
            if ((((uint) num) + ((uint) defaultValue)) >= 0)
            {
                goto Label_0043;
            }
        Label_00E5:
            if (num2 == -1)
            {
                goto Label_00BF;
            }
            if (-1 != 0)
            {
                goto Label_005A;
            }
            if (0 == 0)
            {
                if ((((uint) num) + ((uint) num2)) >= 0)
                {
                    if (1 == 0)
                    {
                        return layer;
                    }
                    goto Label_0043;
                }
                goto Label_0170;
            }
            if (0 != 0)
            {
                return layer;
            }
            goto Label_00B9;
        Label_00F7:
            if ("?".Equals(str))
            {
                if (defaultValue < 0)
                {
                    throw new EncogError("Default (?) in an invalid location.");
                }
                layer.Count = defaultValue;
                if ((((uint) defaultValue) | 0x7fffffff) != 0)
                {
                    layer.UsedDefault = true;
                    return layer;
                }
                goto Label_00BF;
            }
        Label_0104:
            num = str.IndexOf('(');
            num2 = str.LastIndexOf(')');
            goto Label_00B9;
        Label_0170:
            if (str.EndsWith(":B"))
            {
                str = str.Substring(0, str.Length - 2);
                layer.Bias = true;
            }
            try
            {
                layer.Count = int.Parse(str);
                if (layer.Count < 0)
                {
                    throw new EncogError("Count cannot be less than zero.");
                }
            }
            catch (FormatException exception)
            {
                EncogLogging.Log(exception);
            }
            goto Label_00F7;
        }

        public static IList<string> ParseLayers(string line)
        {
            IList<string> list = new List<string>();
            int startIndex = 0;
            bool flag = false;
            while (true)
            {
                string str;
                int index = line.IndexOf("->", startIndex);
                do
                {
                    if ((-1 != 0) && (index == -1))
                    {
                        do
                        {
                            str = line.Substring(startIndex).Trim();
                        }
                        while ((((uint) startIndex) + ((uint) startIndex)) < 0);
                        flag = true;
                        break;
                    }
                    str = line.Substring(startIndex, index - startIndex).Trim();
                    startIndex = index + 2;
                }
                while ((((uint) flag) + ((uint) flag)) < 0);
                if (str.EndsWith("b"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                list.Add(str);
                if (flag)
                {
                    return list;
                }
            }
        }

        public static IDictionary<string, string> ParseParams(string line)
        {
            SimpleParser parser;
            string str;
            string str2;
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            if (-1 != 0)
            {
                parser = new SimpleParser(line);
            }
            else
            {
                goto Label_002F;
            }
        Label_0012:
            if (!parser.EOL())
            {
                str = xe1cd55dd1e3e1253(parser).ToUpper();
                goto Label_007A;
            }
            if (0 == 0)
            {
                return dictionary;
            }
        Label_0022:
            if (parser.ParseThroughComma())
            {
                goto Label_0012;
            }
            if (0 != 0)
            {
                goto Label_007A;
            }
            return dictionary;
        Label_002F:
            str2 = x0738845e2abbf3d2(parser);
            dictionary[str.ToUpper()] = str2;
            goto Label_0022;
        Label_007A:
            parser.EatWhiteSpace();
            if (!parser.LookAhead("=", false))
            {
                throw new EncogError("Missing equals(=) operator.");
            }
            parser.Advance();
            goto Label_002F;
        }

        private static string x0738845e2abbf3d2(SimpleParser xbce90b56ab411c23)
        {
            bool flag = false;
            StringBuilder builder = new StringBuilder();
            xbce90b56ab411c23.EatWhiteSpace();
            if (0 == 0)
            {
                goto Label_001E;
            }
            goto Label_0160;
        Label_000F:
            builder.Append(xbce90b56ab411c23.ReadChar());
            goto Label_002B;
        Label_001E:
            if (xbce90b56ab411c23.Peek() == '"')
            {
                goto Label_0160;
            }
        Label_002B:
            if (!xbce90b56ab411c23.EOL())
            {
                goto Label_00AE;
            }
            goto Label_01A9;
        Label_0061:
            if (((uint) flag) >= 0)
            {
                goto Label_000F;
            }
        Label_008C:
            if (!flag)
            {
                if (xbce90b56ab411c23.IsWhiteSpace())
                {
                    goto Label_01A9;
                }
                if (xbce90b56ab411c23.Peek() != ',')
                {
                    goto Label_0061;
                }
                if (0 != 0)
                {
                    goto Label_008C;
                }
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_01A9;
                }
                goto Label_000F;
            }
            if (-2 != 0)
            {
                goto Label_000F;
            }
        Label_00AE:
            if (xbce90b56ab411c23.Peek() == '"')
            {
                goto Label_0109;
            }
            if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_008C;
            }
            goto Label_000F;
        Label_00D2:
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_001E;
            }
            goto Label_002B;
        Label_0109:
            if (!flag)
            {
                builder.Append(xbce90b56ab411c23.ReadChar());
                goto Label_002B;
            }
            xbce90b56ab411c23.Advance();
            if (xbce90b56ab411c23.Peek() != '"')
            {
                goto Label_01A9;
            }
            builder.Append(xbce90b56ab411c23.ReadChar());
            goto Label_00D2;
        Label_0160:
            flag = true;
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                if ((((uint) flag) | 15) == 0)
                {
                    if (((uint) flag) >= 0)
                    {
                        goto Label_0061;
                    }
                    goto Label_008C;
                }
                xbce90b56ab411c23.Advance();
                goto Label_002B;
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_0109;
            }
            goto Label_00D2;
        Label_01A9:
            return builder.ToString();
        }

        private static string xe1cd55dd1e3e1253(SimpleParser xbce90b56ab411c23)
        {
            StringBuilder builder = new StringBuilder();
            xbce90b56ab411c23.EatWhiteSpace();
            while (xbce90b56ab411c23.IsIdentifier())
            {
                builder.Append(xbce90b56ab411c23.ReadChar());
            }
            return builder.ToString();
        }
    }
}

