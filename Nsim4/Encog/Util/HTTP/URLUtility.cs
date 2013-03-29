namespace Encog.Util.HTTP
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class URLUtility
    {
        public const string IndexFile = "index.html";
        [CompilerGenerated]
        private static Func<char, bool> x31af784cbc72c68d;

        public static Uri ConstructURL(Uri baseURL, string url, bool stripFragment)
        {
            string str;
            string scheme;
            string host;
            string fragment;
            int port;
            StringBuilder builder;
            Uri uri = new Uri(baseURL, url);
            goto Label_0237;
        Label_0028:
            if (!stripFragment)
            {
                builder.Append('#');
                builder.Append(fragment);
                goto Label_0260;
            }
            if ((((uint) port) + ((uint) stripFragment)) <= uint.MaxValue)
            {
                goto Label_0260;
            }
            goto Label_0237;
        Label_004B:
            if (!str.StartsWith("/"))
            {
                builder.Append('/');
            }
            builder.Append(str);
            if ((((uint) stripFragment) + ((uint) port)) > uint.MaxValue)
            {
                goto Label_0162;
            }
            if ((((uint) port) - ((uint) port)) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                    goto Label_0028;
                }
                goto Label_0237;
            }
            if (15 != 0)
            {
                goto Label_01BC;
            }
            goto Label_004B;
        Label_00A6:
            if (string.Compare(scheme, "https") != 0)
            {
                goto Label_0162;
            }
            goto Label_004B;
        Label_00F9:
            if ((port == 0x1bb) && (8 != 0))
            {
                goto Label_01B5;
            }
            goto Label_004B;
        Label_0162:
            builder.Append(':');
            builder.Append("443");
            if ((((uint) port) & 0) != 0)
            {
                goto Label_0028;
            }
            if ((((uint) port) - ((uint) stripFragment)) <= uint.MaxValue)
            {
                if ((((uint) port) - ((uint) port)) <= uint.MaxValue)
                {
                    if (((((uint) stripFragment) - ((uint) port)) >= 0) && ((((uint) stripFragment) + ((uint) stripFragment)) > uint.MaxValue))
                    {
                        goto Label_00F9;
                    }
                    goto Label_004B;
                }
                if (0 == 0)
                {
                    if (((uint) port) > uint.MaxValue)
                    {
                        goto Label_004B;
                    }
                    goto Label_00F9;
                }
            }
            else
            {
                goto Label_00F9;
            }
        Label_01B5:
            if (1 != 0)
            {
                goto Label_00A6;
            }
        Label_01BC:
            builder.Append("://");
            builder.Append(host);
            if ((port == 80) && (string.Compare(scheme, "http") != 0))
            {
                builder.Append(':');
                builder.Append("80");
                if (-1 != 0)
                {
                    goto Label_004B;
                }
                goto Label_00A6;
            }
            goto Label_00F9;
        Label_0237:
            str = uri.PathAndQuery;
            scheme = uri.Scheme;
            host = uri.Host;
            fragment = uri.Fragment;
            port = uri.Port;
            str = str.Replace(" ", "%20");
            builder = new StringBuilder();
            builder.Append(scheme);
            goto Label_01BC;
        Label_0260:
            return new Uri(builder.ToString());
        }

        public static bool ContainsInvalidURLCharacters(string url)
        {
            if (x31af784cbc72c68d == null)
            {
                x31af784cbc72c68d = new Func<char, bool>(URLUtility.x6ad3bc98cdfc47fc);
            }
            return url.Any<char>(x31af784cbc72c68d);
        }

        public static string ConvertFilename(string basePath, Uri url, bool mkdir)
        {
            int num2;
            string str4;
            string str = basePath;
            string str2 = url.Host.Replace('.', '_');
            str = Path.Combine(str, str2);
            Directory.CreateDirectory(str);
            int length = url.Segments.Length;
            if ((0 != 0) || (length > 0))
            {
                length--;
            }
            string str3 = url.Segments[length];
            if ((0 == 0) && !str3.Equals('/'))
            {
                if (0 == 0)
                {
                    if (0 == 0)
                    {
                    }
                    goto Label_015B;
                }
                goto Label_010C;
            }
            str3 = "index.html";
            goto Label_015B;
        Label_0007:
            return Path.Combine(str, str3).Replace('?', '_');
        Label_0060:
            str3 = "index.html";
            goto Label_0007;
        Label_0086:
            Directory.CreateDirectory(str);
            goto Label_0060;
        Label_0091:
            if (num2 < length)
            {
                str4 = url.Segments[num2];
                if ((((uint) length) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0101;
                }
                goto Label_010C;
            }
            if (str3.EndsWith("/"))
            {
                string str5 = str3.Substring(0, str3.Length - 1);
                str = Path.Combine(str, str5);
                if (!mkdir)
                {
                    goto Label_0060;
                }
                goto Label_0086;
            }
            if ((((uint) length) & 0) == 0)
            {
                if (((uint) mkdir) > uint.MaxValue)
                {
                    return str;
                }
                if (str3.IndexOf('.') != -1)
                {
                    if ((((uint) length) | uint.MaxValue) == 0)
                    {
                        return str;
                    }
                }
                else
                {
                    str3 = "/index.html";
                }
                goto Label_0007;
            }
            if ((((uint) num2) - ((uint) num2)) >= 0)
            {
                goto Label_010C;
            }
            goto Label_0101;
        Label_00CE:
            if (!str4.Equals("/"))
            {
                str = Path.Combine(str, str4);
                if ((((uint) length) & 0) != 0)
                {
                    goto Label_015B;
                }
                if ((((uint) length) + ((uint) num2)) >= 0)
                {
                    if (mkdir)
                    {
                        goto Label_0101;
                    }
                }
                else
                {
                    goto Label_0101;
                }
            }
        Label_00E1:
            num2++;
            if ((((uint) num2) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_00CE;
            }
            goto Label_0091;
        Label_0101:
            Directory.CreateDirectory(str);
            goto Label_00E1;
        Label_010C:
            if (0 != 0)
            {
                goto Label_0086;
            }
            goto Label_00CE;
        Label_015B:
            num2 = 0;
            goto Label_0091;
        }

        [CompilerGenerated]
        private static bool x6ad3bc98cdfc47fc(char xb867a42da3ae686d)
        {
            return (xb867a42da3ae686d > '\x00ff');
        }
    }
}

