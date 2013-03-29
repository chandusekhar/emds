namespace Encog.Bot
{
    using Encog.Util.File;
    using Encog.Util.HTTP;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    public class BotUtil
    {
        public static int BufferSize = 0x2000;

        private BotUtil()
        {
        }

        public static string Extract(string str, string token1, string token2, int index)
        {
            int num;
            int num2;
            string str2 = str.ToLower();
            string str3 = token1.ToLower();
            string str4 = token2.ToLower();
            if ((((uint) index) | 8) != 0)
            {
                num = index;
                num2 = -1;
                goto Label_006B;
            }
            goto Label_00A2;
        Label_0060:
            num--;
            goto Label_00A2;
        Label_006B:
            num2 = str2.IndexOf(str3, (int) (num2 + 1));
            if (num2 == -1)
            {
                return null;
            }
            goto Label_0060;
        Label_00A2:
            if (((((uint) num) - ((uint) num)) >= 0) && ((((uint) num2) - ((uint) num2)) < 0))
            {
                goto Label_0060;
            }
            if (num > 0)
            {
                goto Label_006B;
            }
            int num3 = str2.IndexOf(str4, (int) (num2 + 1));
            if ((((uint) num2) >= 0) && (num3 != -1))
            {
                return str.Substring(num2 + str3.Length, num3 - (num2 + token1.Length));
            }
            return null;
        }

        public static string ExtractFromIndex(string str, string token1, string token2, int index, int occurence)
        {
            string str3;
            string str4;
            int num;
            int num2;
            int num3;
            string str2 = str.ToLower();
            if ((((uint) occurence) + ((uint) index)) <= uint.MaxValue)
            {
                str3 = token1.ToLower();
                if (((uint) index) > uint.MaxValue)
                {
                    goto Label_00AA;
                }
                str4 = token2.ToLower();
                num = occurence;
                num2 = index - 1;
                goto Label_00C6;
            }
        Label_0022:
            while (num3 != -1)
            {
                if ((((((uint) num3) | 1) != 0) && ((((uint) num2) | 2) != 0)) || ((((uint) occurence) - ((uint) index)) <= uint.MaxValue))
                {
                    return str.Substring(num2 + str3.Length, num3 - (num2 + token1.Length));
                }
            }
        Label_008B:
            return null;
        Label_00AA:
            num--;
        Label_00AE:
            if (num <= 0)
            {
                num3 = str2.IndexOf(str4, (int) (num2 + 1));
                if (((uint) index) >= 0)
                {
                    goto Label_0022;
                }
                goto Label_008B;
            }
        Label_00C6:
            num2 = str2.IndexOf(str3, (int) (num2 + 1));
            if (num2 == -1)
            {
                return null;
            }
            if ((((uint) num) | uint.MaxValue) == 0)
            {
                goto Label_00AE;
            }
            goto Label_00AA;
        }

        public static string LoadPage(Uri url)
        {
            string str2;
            try
            {
                byte[] buffer;
                int num;
                WebRequest request;
                HttpWebResponse response;
                Stream stream;
                string str;
                StringBuilder builder = new StringBuilder();
                goto Label_00C6;
            Label_000B:
                if (((uint) num) < 0)
                {
                    goto Label_0052;
                }
            Label_001D:
                if (num > 0)
                {
                    goto Label_006F;
                }
                goto Label_002A;
            Label_0023:
                if (2 == 0)
                {
                    goto Label_001D;
                }
            Label_002A:
                if (num > 0)
                {
                    goto Label_005B;
                }
                str2 = builder.ToString();
                if ((((uint) num) & 0) == 0)
                {
                    return str2;
                }
                goto Label_00C6;
            Label_0052:
                stream = response.GetResponseStream();
            Label_005B:
                num = stream.Read(buffer, 0, buffer.Length);
                if (3 != 0)
                {
                    goto Label_001D;
                }
            Label_006F:
                str = Encoding.UTF8.GetString(buffer, 0, num);
                builder.Append(str);
                goto Label_0023;
            Label_0089:
                response = (HttpWebResponse) request.GetResponse();
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0052;
                }
                if ((((uint) num) | uint.MaxValue) != 0)
                {
                    goto Label_000B;
                }
            Label_00C6:
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_0023;
                }
                buffer = new byte[BufferSize];
                request = WebRequest.Create(url);
                goto Label_0089;
            }
            catch (IOException exception)
            {
                throw new BotError(exception);
            }
            return str2;
        }

        public static string POSTPage(Uri uri, IDictionary<string, string> param)
        {
            StringBuilder builder;
            byte[] buffer;
            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            do
            {
                request.Method = "POST";
                builder = new StringBuilder();
            }
            while (-2 == 0);
            using (IEnumerator<string> enumerator = param.Keys.GetEnumerator())
            {
                string str;
                string str2;
                goto Label_00A4;
            Label_0081:
                builder.Append('=');
                builder.Append(FormUtility.Encode(str2));
            Label_0097:
                if (4 == 0)
                {
                    goto Label_0081;
                }
                if (0 == 0)
                {
                    goto Label_00A4;
                }
            Label_00A1:
                if (str2 != null)
                {
                    goto Label_00C2;
                }
            Label_00A4:
                if (enumerator.MoveNext())
                {
                    goto Label_00E5;
                }
                if (0 == 0)
                {
                    goto Label_0108;
                }
                if (4 != 0)
                {
                    goto Label_00E5;
                }
            Label_00B7:
                str2 = param[str];
                if (0 == 0)
                {
                    goto Label_00A1;
                }
            Label_00C2:
                if (builder.Length != 0)
                {
                    if (3 == 0)
                    {
                        goto Label_0097;
                    }
                    builder.Append('&');
                }
                builder.Append(str);
                if (0 == 0)
                {
                    goto Label_0081;
                }
            Label_00E5:
                str = enumerator.Current;
                goto Label_00B7;
            }
            if (0 == 0)
            {
                goto Label_0108;
            }
        Label_0034:
            request.ContentLength = buffer.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();
            WebResponse response = request.GetResponse();
            if (response == null)
            {
                return null;
            }
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();
        Label_0108:
            buffer = Encoding.ASCII.GetBytes(builder.ToString());
            goto Label_0034;
        }

        public static string POSTPage(Uri uri, Stream stream)
        {
            Stream requestStream;
            WebResponse response;
            WebRequest request = WebRequest.Create(uri);
            if (3 != 0)
            {
                request.Method = "POST";
                requestStream = request.GetRequestStream();
                FileUtil.CopyStream(stream, requestStream);
            }
            requestStream.Close();
            if (0 == 0)
            {
                response = request.GetResponse();
            }
            if (response == null)
            {
                return null;
            }
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();
        }

        public static string POSTPage(Uri uri, byte[] bytes, int length)
        {
            string str;
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentLength = length;
            Stream requestStream = null;
            try
            {
                request.ContentLength = bytes.Length;
                requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, length);
            }
            catch (WebException exception)
            {
                throw new BotError(exception);
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Flush();
                }
            }
            try
            {
                WebResponse response = request.GetResponse();
                if (response == null)
                {
                    return null;
                }
                StreamReader reader = new StreamReader(response.GetResponseStream());
                do
                {
                    str = reader.ReadToEnd();
                }
                while (0 != 0);
            }
            catch (WebException exception2)
            {
                throw new BotError(exception2);
            }
            return str;
        }
    }
}

