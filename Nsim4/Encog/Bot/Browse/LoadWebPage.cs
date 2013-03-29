namespace Encog.Bot.Browse
{
    using Encog.Bot.Browse.Range;
    using Encog.Bot.DataUnits;
    using Encog.Parse.Tags;
    using Encog.Parse.Tags.Read;
    using System;
    using System.IO;
    using System.Text;

    public class LoadWebPage
    {
        private readonly Uri _x1554c0f0264b8597;
        private WebPage _xbbe2f7d7c86e0379;
        private Form _xddf51e0bb7096df0;
        private DocumentRange _xe27443ca851b9ce6;

        public LoadWebPage(Uri baseURL)
        {
            this._x1554c0f0264b8597 = baseURL;
        }

        protected int FindEndTag(int index, Tag tag)
        {
            int num2;
            int num = 0;
            goto Label_00E9;
        Label_001D:
            num2++;
        Label_0021:
            if (num2 < this._xbbe2f7d7c86e0379.getDataSize())
            {
                DataUnit dataUnit = this._xbbe2f7d7c86e0379.GetDataUnit(num2);
            Label_00B8:
                if (!(dataUnit is TagDataUnit))
                {
                    goto Label_001D;
                }
                Tag tag2 = ((TagDataUnit) dataUnit).Tag;
                if ((((uint) num2) + ((uint) index)) <= uint.MaxValue)
                {
                    if (string.Compare(tag.Name, tag2.Name, true) == 0)
                    {
                        if (tag2.TagType != Tag.Type.End)
                        {
                            if (tag2.TagType != Tag.Type.Begin)
                            {
                                goto Label_001D;
                            }
                            if ((((uint) num) - ((uint) num2)) >= 0)
                            {
                                num++;
                                if (((uint) num2) <= uint.MaxValue)
                                {
                                    goto Label_001D;
                                }
                                goto Label_010C;
                            }
                            goto Label_00E9;
                        }
                        if (num != 0)
                        {
                            num--;
                            goto Label_001D;
                        }
                        if ((4 != 0) && ((((uint) index) | 0x7fffffff) != 0))
                        {
                            return num2;
                        }
                    }
                    else
                    {
                        goto Label_001D;
                    }
                    goto Label_00B8;
                }
            }
            else
            {
                goto Label_010C;
            }
        Label_00E9:
            num2 = index;
            goto Label_0021;
        Label_010C:
            return -1;
        }

        public WebPage Load(Stream istream)
        {
            this._xbbe2f7d7c86e0379 = new WebPage();
            this.LoadDataUnits(istream);
            this.LoadContents();
            return this._xbbe2f7d7c86e0379;
        }

        public WebPage Load(string str)
        {
            WebPage page2;
            try
            {
                Stream istream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                WebPage page = this.Load(istream);
                istream.Close();
                page2 = page;
            }
            catch (IOException exception)
            {
                throw new BrowseError(exception);
            }
            return page2;
        }

        protected void LoadContents()
        {
            Tag tag;
            int i = 0;
            if ((((uint) i) + ((uint) i)) >= 0)
            {
                if ((((uint) i) + ((uint) i)) < 0)
                {
                    goto Label_0278;
                }
                if ((((uint) i) | 0xfffffffe) == 0)
                {
                    goto Label_01A4;
                }
                goto Label_0056;
            }
            if (((uint) i) <= uint.MaxValue)
            {
                goto Label_003F;
            }
            goto Label_0052;
        Label_0031:
            if (tag.TagType == Tag.Type.End)
            {
                goto Label_00BD;
            }
            goto Label_0052;
        Label_003F:
            if ((string.Compare(tag.Name, "span", true) == 0) && (this._xe27443ca851b9ce6 != null))
            {
                if (3 == 0)
                {
                    goto Label_0278;
                }
                this._xe27443ca851b9ce6 = this._xe27443ca851b9ce6.Parent;
            }
        Label_0052:
            i++;
        Label_0056:
            if (i < this._xbbe2f7d7c86e0379.getDataSize())
            {
                DataUnit dataUnit = this._xbbe2f7d7c86e0379.GetDataUnit(i);
                if (((((uint) i) & 0) == 0) && !(dataUnit is TagDataUnit))
                {
                    if ((((uint) i) + ((uint) i)) > uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_0052;
                }
                tag = ((TagDataUnit) dataUnit).Tag;
                if (tag.TagType != Tag.Type.End)
                {
                    goto Label_0293;
                }
                goto Label_012D;
            }
            return;
        Label_00BD:
            if (string.Compare(tag.Name, "div") != 0)
            {
                goto Label_003F;
            }
        Label_00D4:
            if (this._xe27443ca851b9ce6 != null)
            {
                this._xe27443ca851b9ce6 = this._xe27443ca851b9ce6.Parent;
                if (0 != 0)
                {
                    goto Label_00BD;
                }
            }
            goto Label_0052;
        Label_012D:
            if (tag.TagType == Tag.Type.Begin)
            {
                goto Label_01A4;
            }
            goto Label_0031;
        Label_013D:
            if (string.Compare(tag.Name, "span", true) == 0)
            {
                this.xc4283bf79484a931(i, tag);
                if (1 != 0)
                {
                    goto Label_0031;
                }
                goto Label_0052;
            }
            if (((uint) i) >= 0)
            {
                goto Label_0031;
            }
            if (((uint) i) > uint.MaxValue)
            {
                goto Label_01F6;
            }
            if (4 != 0)
            {
                goto Label_00BD;
            }
            goto Label_00D4;
        Label_01A4:
            if (string.Compare(tag.Name, "div", true) != 0)
            {
                goto Label_013D;
            }
            this.xd333635ed28a1b6d(i, tag);
            goto Label_0031;
        Label_01F6:
            if ((((uint) i) - ((uint) i)) <= uint.MaxValue)
            {
                goto Label_012D;
            }
        Label_0238:
            if ((((uint) i) - ((uint) i)) >= 0)
            {
                goto Label_01A4;
            }
            if (((uint) i) <= uint.MaxValue)
            {
                if (((((uint) i) & 0) == 0) && ((((uint) i) | 1) != 0))
                {
                    if (0xff == 0)
                    {
                        goto Label_012D;
                    }
                    goto Label_013D;
                }
                goto Label_01A4;
            }
            goto Label_0052;
        Label_0278:
            if ((((uint) i) - ((uint) i)) > uint.MaxValue)
            {
                goto Label_01F6;
            }
        Label_0293:
            if (string.Compare(tag.Name, "a", true) == 0)
            {
                this.LoadLink(i, tag);
            }
            else if (string.Compare(tag.Name, "title", true) != 0)
            {
                if (string.Compare(tag.Name, "form", true) != 0)
                {
                    if (string.Compare(tag.Name, "input", true) == 0)
                    {
                        this.LoadInput(i, tag);
                        if ((((uint) i) - ((uint) i)) <= uint.MaxValue)
                        {
                            goto Label_012D;
                        }
                        goto Label_0238;
                    }
                    goto Label_01F6;
                }
                this.LoadForm(i, tag);
            }
            else
            {
                this.LoadTitle(i, tag);
            }
            goto Label_012D;
        }

        protected void LoadDataUnits(Stream istream)
        {
            int num;
            ReadHTML dhtml;
            bool flag;
            bool flag2;
            StringBuilder builder = new StringBuilder();
            if (-1 != 0)
            {
                dhtml = new ReadHTML(istream);
                flag = false;
                flag2 = false;
                goto Label_002C;
            }
        Label_0010:
            this.x82cd1c1497f0cbf7(builder.ToString());
            return;
        Label_002C:
            if ((num = dhtml.Read()) != -1)
            {
                if (num != 0)
                {
                    builder.Append((char) num);
                    goto Label_002C;
                }
                if (flag)
                {
                    this.xcf6c4f40a62f8405(builder.ToString());
                    goto Label_00F8;
                }
                if (0 != 0)
                {
                    goto Label_00A1;
                }
                if (flag2)
                {
                    this.xcf6c4f40a62f8405(builder.ToString());
                    if (((uint) flag2) >= 0)
                    {
                        goto Label_00F8;
                    }
                }
                else
                {
                    this.x82cd1c1497f0cbf7(builder.ToString());
                }
                if (0 == 0)
                {
                    goto Label_00F8;
                }
            }
            else
            {
                goto Label_0010;
            }
        Label_0070:
            flag2 = true;
            if ((((uint) flag2) & 0) == 0)
            {
                if ((((uint) flag2) & 0) != 0)
                {
                    goto Label_00F8;
                }
                if ((((uint) num) < 0) || (3 != 0))
                {
                    goto Label_002C;
                }
                goto Label_0010;
            }
            if (((uint) flag) > uint.MaxValue)
            {
            }
            goto Label_00F8;
        Label_00A1:
            if (string.Compare(dhtml.LastTag.Name, "style", true) == 0)
            {
                flag = true;
                goto Label_002C;
            }
            if (string.Compare(dhtml.LastTag.Name, "script", true) != 0)
            {
                goto Label_002C;
            }
            goto Label_0070;
        Label_00F8:
            flag = false;
            flag2 = false;
            if (0 == 0)
            {
                builder.Length = 0;
                this.x83582e0ac008c5cb(dhtml.LastTag);
                goto Label_00A1;
            }
            goto Label_0070;
        }

        protected void LoadForm(int index, Tag tag)
        {
            string str2;
            Form form;
            string attributeValue = tag.GetAttributeValue("method");
            goto Label_00E4;
        Label_0011:
            if (str2 == null)
            {
                form.Action = new Address(this._x1554c0f0264b8597);
            }
            else
            {
                form.Action = new Address(this._x1554c0f0264b8597, str2);
            }
            this._xbbe2f7d7c86e0379.AddContent(form);
            this._xddf51e0bb7096df0 = form;
            if (0 != 0)
            {
                goto Label_00E4;
            }
            if ((((uint) index) - ((uint) index)) <= uint.MaxValue)
            {
                return;
            }
        Label_0057:
            form.Method = Form.FormMethod.Post;
            goto Label_0011;
        Label_007A:
            if (attributeValue != null)
            {
                goto Label_00C9;
            }
        Label_007D:
            form.Method = Form.FormMethod.Get;
            goto Label_0011;
        Label_00C9:
            if (string.Compare(attributeValue, "GET", true) != 0)
            {
                goto Label_0057;
            }
            if (0 == 0)
            {
                goto Label_007D;
            }
            goto Label_007A;
        Label_00E4:
            str2 = tag.GetAttributeValue("action");
            form = new Form(this._xbbe2f7d7c86e0379);
            if (0 == 0)
            {
                if ((((uint) index) & 0) == 0)
                {
                    form.Begin = index;
                    form.End = this.FindEndTag(index + 1, tag);
                }
                if ((((uint) index) - ((uint) index)) <= uint.MaxValue)
                {
                    goto Label_007A;
                }
                goto Label_00C9;
            }
            goto Label_0057;
        }

        protected void LoadInput(int index, Tag tag)
        {
            string str2;
            string str3;
            Input input;
            string attributeValue = tag.GetAttributeValue("type");
            goto Label_007E;
        Label_0043:
            if (this._xddf51e0bb7096df0 != null)
            {
                this._xddf51e0bb7096df0.AddElement(input);
                return;
            }
            if ((((uint) index) + ((uint) index)) <= uint.MaxValue)
            {
                this._xbbe2f7d7c86e0379.AddContent(input);
                if (((uint) index) >= 0)
                {
                    return;
                }
                goto Label_007E;
            }
        Label_0067:
            input.Type = attributeValue;
            input.Name = str2;
        Label_0075:
            input.Value = str3;
            goto Label_0043;
        Label_007E:
            str2 = tag.GetAttributeValue("name");
            str3 = tag.GetAttributeValue("value");
            input = new Input(this._xbbe2f7d7c86e0379);
            if (8 == 0)
            {
                goto Label_0075;
            }
            if (0 == 0)
            {
                goto Label_0067;
            }
            goto Label_0043;
        }

        protected void LoadLink(int index, Tag tag)
        {
            Link span = new Link(this._xbbe2f7d7c86e0379);
            string attributeValue = tag.GetAttributeValue("href");
            if (attributeValue != null)
            {
                span.Target = new Address(this._x1554c0f0264b8597, attributeValue);
                span.Begin = index;
                if ((((uint) index) + ((uint) index)) >= 0)
                {
                    span.End = this.FindEndTag(index + 1, tag);
                }
                this._xbbe2f7d7c86e0379.AddContent(span);
            }
        }

        protected void LoadTitle(int index, Tag tag)
        {
            DocumentRange range = new DocumentRange(this._xbbe2f7d7c86e0379) {
                Begin = index,
                End = this.FindEndTag(index + 1, tag)
            };
            this._xbbe2f7d7c86e0379.Title = range;
        }

        private void x82cd1c1497f0cbf7(string xf6987a1745781d6f)
        {
            if (xf6987a1745781d6f.Trim().Length > 0)
            {
                TextDataUnit unit = new TextDataUnit {
                    Text = xf6987a1745781d6f
                };
                this._xbbe2f7d7c86e0379.AddDataUnit(unit);
            }
        }

        private void x83582e0ac008c5cb(Tag xffe521cc76054baf)
        {
            TagDataUnit unit = new TagDataUnit {
                Tag = (Tag) xffe521cc76054baf.Clone()
            };
            this._xbbe2f7d7c86e0379.AddDataUnit(unit);
        }

        private void x9d4db4971b8e4b59(DocumentRange x4bbc2c453c470189)
        {
            if (this._xe27443ca851b9ce6 == null)
            {
                this._xbbe2f7d7c86e0379.AddContent(x4bbc2c453c470189);
            }
            else
            {
                this._xe27443ca851b9ce6.AddElement(x4bbc2c453c470189);
            }
            this._xe27443ca851b9ce6 = x4bbc2c453c470189;
        }

        private void xc4283bf79484a931(int xc0c4c459c6ccbd00, Tag xffe521cc76054baf)
        {
            Span span = new Span(this._xbbe2f7d7c86e0379);
            string attributeValue = xffe521cc76054baf.GetAttributeValue("class");
            string str2 = xffe521cc76054baf.GetAttributeValue("id");
            span.IdAttribute = str2;
            span.ClassAttribute = attributeValue;
            if (((uint) xc0c4c459c6ccbd00) >= 0)
            {
                span.Begin = xc0c4c459c6ccbd00;
                span.End = this.FindEndTag(xc0c4c459c6ccbd00 + 1, xffe521cc76054baf);
            }
            this.x9d4db4971b8e4b59(span);
        }

        private void xcf6c4f40a62f8405(string xf6987a1745781d6f)
        {
            if (xf6987a1745781d6f.Trim().Length > 0)
            {
                CodeDataUnit unit = new CodeDataUnit {
                    Code = xf6987a1745781d6f
                };
                this._xbbe2f7d7c86e0379.AddDataUnit(unit);
            }
        }

        private void xd333635ed28a1b6d(int xc0c4c459c6ccbd00, Tag xffe521cc76054baf)
        {
            string str;
            Div div = new Div(this._xbbe2f7d7c86e0379);
            if ((((uint) xc0c4c459c6ccbd00) - ((uint) xc0c4c459c6ccbd00)) >= 0)
            {
                str = xffe521cc76054baf.GetAttributeValue("class");
            }
            string attributeValue = xffe521cc76054baf.GetAttributeValue("id");
            div.IdAttribute = attributeValue;
            div.ClassAttribute = str;
            div.Begin = xc0c4c459c6ccbd00;
            div.End = this.FindEndTag(xc0c4c459c6ccbd00 + 1, xffe521cc76054baf);
            do
            {
                this.x9d4db4971b8e4b59(div);
            }
            while (0xff == 0);
        }
    }
}

