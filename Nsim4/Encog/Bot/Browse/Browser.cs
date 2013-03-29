namespace Encog.Bot.Browse
{
    using Encog.Bot.Browse.Range;
    using Encog.Util.HTTP;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public class Browser
    {
        private WebPage _x3194f515d046bdf4;

        public void Navigate(Form form)
        {
            this.Navigate(form, null);
        }

        public void Navigate(Link link)
        {
            Address target = link.Target;
            while (1 != 0)
            {
                if (target.Url != null)
                {
                    this.Navigate(target.Url);
                    return;
                }
                this.Navigate(target.Original);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        public void Navigate(string url)
        {
            this.Navigate(new Uri(url));
        }

        public void Navigate(Uri url)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse) WebRequest.Create(url).GetResponse();
                Stream responseStream = response.GetResponseStream();
                this.Navigate(url, responseStream);
                do
                {
                    responseStream.Close();
                }
                while (-2 == 0);
                response.Close();
            }
            catch (IOException exception)
            {
                throw new BrowseError(exception);
            }
        }

        public void Navigate(Form form, Input submit)
        {
            try
            {
                Stream requestStream;
                Uri url;
                FormUtility utility;
                string str3;
                HttpWebResponse response;
                WebRequest request = null;
                goto Label_01D3;
            Label_0007:
                requestStream.Close();
                Stream responseStream = ((HttpWebResponse) request.GetResponse()).GetResponseStream();
            Label_0022:
                this.Navigate(url, responseStream);
            Label_002A:
                responseStream.Close();
                if (0 == 0)
                {
                    return;
                }
                if (0 == 0)
                {
                    goto Label_0057;
                }
            Label_0036:
                responseStream = response.GetResponseStream();
                goto Label_0022;
            Label_0040:
                if (form.Method == Form.FormMethod.Get)
                {
                    goto Label_0081;
                }
                url = form.Action.Url;
                goto Label_0007;
            Label_0057:
                response = (HttpWebResponse) WebRequest.Create(url).GetResponse();
                goto Label_0036;
            Label_0074:
                url = new Uri(str3);
                goto Label_0057;
            Label_0081:
                str3 = form.Action.Url.ToString();
                requestStream.Close();
                str3 = str3 + "?" + requestStream.ToString();
                goto Label_0074;
            Label_00BB:
                if (0x7fffffff == 0)
                {
                    goto Label_0074;
                }
                goto Label_0040;
            Label_00C7:
                request.Method = "POST";
                requestStream = request.GetRequestStream();
            Label_00D9:
                utility = new FormUtility(requestStream, null);
                if (0 != 0)
                {
                    goto Label_002A;
                }
                using (IEnumerator<DocumentRange> enumerator = form.Elements.GetEnumerator())
                {
                    DocumentRange range;
                    FormElement element;
                    string str;
                    string str2;
                    goto Label_0109;
                Label_00F7:
                    if (element.AutoSend)
                    {
                        goto Label_0163;
                    }
                    goto Label_0109;
                Label_0105:
                    if (str != null)
                    {
                        goto Label_013B;
                    }
                Label_0109:
                    if (enumerator.MoveNext())
                    {
                        goto Label_016E;
                    }
                    goto Label_0141;
                Label_0117:
                    str2 = "";
                    if (0 != 0)
                    {
                        goto Label_0163;
                    }
                Label_0121:
                    utility.Add(str, str2);
                    goto Label_0109;
                Label_012E:
                    if (range is FormElement)
                    {
                        goto Label_017D;
                    }
                    goto Label_0109;
                Label_013B:
                    if (str2 != null)
                    {
                        goto Label_0121;
                    }
                    goto Label_0117;
                Label_0141:
                    if (0 == 0)
                    {
                        goto Label_0040;
                    }
                    goto Label_016E;
                Label_0146:
                    str2 = element.Value;
                    if (0 == 0)
                    {
                        goto Label_0105;
                    }
                    if (-2147483648 != 0)
                    {
                        goto Label_016E;
                    }
                Label_0159:
                    if (element != submit)
                    {
                        goto Label_00F7;
                    }
                Label_0163:
                    str = element.Name;
                    goto Label_0146;
                Label_016E:
                    range = enumerator.Current;
                    if (0 != 0)
                    {
                        goto Label_0109;
                    }
                    if (0 == 0)
                    {
                        goto Label_012E;
                    }
                Label_017D:
                    element = (FormElement) range;
                    goto Label_0159;
                }
                goto Label_00BB;
            Label_019F:
                requestStream = new MemoryStream();
                goto Label_00D9;
            Label_01AA:
                request = WebRequest.Create(form.Action.Url);
                request.Timeout = 0x7530;
                request.ContentType = "application/x-www-form-urlencoded";
                goto Label_00C7;
            Label_01D3:
                if (form.Method != Form.FormMethod.Get)
                {
                    goto Label_01AA;
                }
                goto Label_019F;
            }
            catch (IOException exception)
            {
                throw new BrowseError(exception);
            }
        }

        public void Navigate(Uri url, Stream istream)
        {
            this._x3194f515d046bdf4 = new LoadWebPage(url).Load(istream);
        }

        public WebPage CurrentPage
        {
            get
            {
                return this._x3194f515d046bdf4;
            }
            set
            {
                this._x3194f515d046bdf4 = value;
            }
        }
    }
}

