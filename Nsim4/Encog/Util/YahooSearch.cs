namespace Encog.Util
{
    using Encog.Parse.Tags;
    using Encog.Parse.Tags.Read;
    using Encog.Util.HTTP;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;

    public class YahooSearch
    {
        public ICollection<Uri> Search(string searchFor)
        {
            ICollection<Uri> is2 = null;
            string str;
            int num;
            bool flag;
            MemoryStream os = new MemoryStream();
            FormUtility utility = new FormUtility(os, null);
            if ((((uint) flag) + ((uint) num)) <= uint.MaxValue)
            {
                utility.Add("appid", "YahooDemo");
                goto Label_00E2;
            }
        Label_0093:
            if (((uint) flag) <= uint.MaxValue)
            {
                os.Dispose();
                Uri uri = new Uri("http://search.yahooapis.com/WebSearchService/V1/webSearch?" + str);
                num = 0;
                flag = false;
                while (!flag)
                {
                    try
                    {
                        is2 = this.x7cdeaeac68d869b5(uri);
                        flag = true;
                    }
                    catch (IOException)
                    {
                        do
                        {
                            if (num == 5)
                            {
                                throw;
                            }
                            Thread.Sleep(0x1388);
                        }
                        while ((((uint) flag) - ((uint) num)) > uint.MaxValue);
                    }
                    num++;
                }
                return is2;
            }
        Label_00E2:
            utility.Add("results", "100");
            utility.Add("query", searchFor);
            utility.Complete();
            str = new ASCIIEncoding().GetString(os.GetBuffer());
            goto Label_0093;
        }

        private ICollection<Uri> x7cdeaeac68d869b5(Uri xf50d6d3c10c0eac9)
        {
            ICollection<Uri> is2 = new List<Uri>();
            HttpWebResponse response = (HttpWebResponse) WebRequest.Create(xf50d6d3c10c0eac9).GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StringBuilder builder;
                bool flag;
                int num;
                Tag lastTag;
                ReadHTML dhtml = new ReadHTML(stream);
                goto Label_014A;
            Label_002D:
                if (15 == 0)
                {
                    goto Label_004F;
                }
            Label_0034:
                if ((num = dhtml.Read()) != -1)
                {
                    goto Label_0159;
                }
                goto Label_006F;
            Label_0046:
                if (0x7fffffff == 0)
                {
                    goto Label_0078;
                }
                goto Label_002D;
            Label_004F:
                if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_0046;
                }
                if (0 == 0)
                {
                }
                goto Label_0034;
            Label_006F:
                if (4 != 0)
                {
                    goto Label_0181;
                }
                goto Label_0046;
            Label_0078:
                if (lastTag.Name.Equals("/Url", StringComparison.CurrentCultureIgnoreCase))
                {
                    goto Label_00F9;
                }
                if ((((uint) num) - ((uint) flag)) < 0)
                {
                    goto Label_010B;
                }
                goto Label_0034;
            Label_00A9:
                if (!flag)
                {
                    if ((((uint) flag) + ((uint) num)) >= 0)
                    {
                        goto Label_004F;
                    }
                    goto Label_0046;
                }
                builder.Append((char) num);
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_0046;
                }
            Label_00EF:
                if (4 != 0)
                {
                    goto Label_0078;
                }
            Label_00F9:
                is2.Add(new Uri(builder.ToString()));
            Label_010B:
                builder.Length = 0;
                flag = false;
                goto Label_0034;
            Label_011D:
                builder.Length = 0;
                flag = true;
                goto Label_0034;
            Label_012D:
                if (lastTag.Name.Equals("Url", StringComparison.CurrentCultureIgnoreCase))
                {
                    goto Label_011D;
                }
                if (0 == 0)
                {
                }
                goto Label_00EF;
            Label_014A:
                builder = new StringBuilder();
                flag = false;
                goto Label_0034;
            Label_0159:
                if (num != 0)
                {
                    goto Label_00A9;
                }
                lastTag = dhtml.LastTag;
                goto Label_012D;
            }
        Label_0181:
            response.Close();
            return is2;
        }
    }
}

