namespace Encog.Util
{
    using System;
    using System.Text;

    public class HTMLReport
    {
        private readonly StringBuilder _xb41faee6912a2313 = new StringBuilder();

        public void BeginBody()
        {
            this._xb41faee6912a2313.Append("<body>");
        }

        public void BeginHTML()
        {
            this._xb41faee6912a2313.Append("<html>");
        }

        public void BeginList()
        {
            this._xb41faee6912a2313.Append("<ul>");
        }

        public void BeginPara()
        {
            this._xb41faee6912a2313.Append("<p>");
        }

        public void BeginRow()
        {
            this._xb41faee6912a2313.Append("<tr>");
        }

        public void BeginTable()
        {
            this._xb41faee6912a2313.Append("<table border=\"1\">");
        }

        public void BeginTableInCell(int colSpan)
        {
            this._xb41faee6912a2313.Append("<td");
            if (colSpan > 0)
            {
                this._xb41faee6912a2313.Append(" colspan=\"");
                this._xb41faee6912a2313.Append(colSpan);
                this._xb41faee6912a2313.Append("\"");
            }
            this._xb41faee6912a2313.Append(">");
            this._xb41faee6912a2313.Append("<table border=\"1\" width=\"100%\">");
        }

        public void Bold(string str)
        {
            this._xb41faee6912a2313.Append("<b>");
            this._xb41faee6912a2313.Append(Encode(str));
            this._xb41faee6912a2313.Append("</b>");
        }

        public void Cell(string head)
        {
            this.Cell(head, 0);
        }

        public void Cell(string head, int colSpan)
        {
            this._xb41faee6912a2313.Append("<td");
            goto Label_00A5;
        Label_0016:
            this._xb41faee6912a2313.Append(">");
        Label_0027:
            this._xb41faee6912a2313.Append(Encode(head));
            this._xb41faee6912a2313.Append("</td>");
            if (0 == 0)
            {
                return;
            }
            goto Label_00A5;
        Label_0074:
            this._xb41faee6912a2313.Append(" colspan=\"");
            if ((((uint) colSpan) - ((uint) colSpan)) < 0)
            {
                goto Label_0027;
            }
            this._xb41faee6912a2313.Append(colSpan);
            this._xb41faee6912a2313.Append("\"");
            goto Label_0016;
        Label_00A5:
            if (0 == 0)
            {
                if (colSpan <= 0)
                {
                    goto Label_0016;
                }
                goto Label_0074;
            }
            if (0 != 0)
            {
                return;
            }
            goto Label_0074;
        }

        public void Clear()
        {
            this._xb41faee6912a2313.Length = 0;
        }

        public static string Encode(string str)
        {
            int num;
            char ch;
            StringBuilder builder = new StringBuilder();
            if (2 != 0)
            {
                goto Label_0102;
            }
            goto Label_00BC;
        Label_0015:
            if (num < str.Length)
            {
                ch = str[num];
                goto Label_00B5;
            }
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                goto Label_0153;
            }
            if (-2 == 0)
            {
                goto Label_0043;
            }
            goto Label_0102;
        Label_003B:
            builder.Append(ch);
        Label_0043:
            num++;
            if (((uint) num) >= 0)
            {
                goto Label_0015;
            }
            if (((((uint) num) - ((uint) num)) <= uint.MaxValue) && (0 == 0))
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_00B5;
                }
                goto Label_003B;
            }
        Label_0071:
            if (ch == '&')
            {
                builder.Append("&amp;");
                goto Label_0043;
            }
            if (((uint) num) < 0)
            {
                goto Label_0043;
            }
            goto Label_003B;
        Label_00B5:
            if (ch == '<')
            {
                builder.Append("&lt;");
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0043;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_00BC;
                }
                goto Label_0153;
            }
            goto Label_00D4;
        Label_00BC:
            if ((((uint) num) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_00B5;
            }
        Label_00D4:
            if (ch != '>')
            {
                goto Label_0071;
            }
            builder.Append("&gt;");
            goto Label_0043;
        Label_0102:
            num = 0;
            if (0xff != 0)
            {
                goto Label_0015;
            }
        Label_0153:
            return builder.ToString();
        }

        public void EndBody()
        {
            this._xb41faee6912a2313.Append("</body>");
        }

        public void EndHTML()
        {
            this._xb41faee6912a2313.Append("</html>");
        }

        public void EndList()
        {
            this._xb41faee6912a2313.Append("</ul>");
        }

        public void EndPara()
        {
            this._xb41faee6912a2313.Append("</p>");
        }

        public void EndRow()
        {
            this._xb41faee6912a2313.Append("</tr>");
        }

        public void EndTable()
        {
            this._xb41faee6912a2313.Append("</table>");
        }

        public void EndTableInCell()
        {
            this._xb41faee6912a2313.Append("</table></td>");
        }

        public void H1(string title)
        {
            this._xb41faee6912a2313.Append("<h1>");
            this._xb41faee6912a2313.Append(Encode(title));
            this._xb41faee6912a2313.Append("</h1>");
        }

        public void H2(string title)
        {
            this._xb41faee6912a2313.Append("<h2>");
            this._xb41faee6912a2313.Append(Encode(title));
            this._xb41faee6912a2313.Append("</h2>");
        }

        public void H3(string title)
        {
            this._xb41faee6912a2313.Append("<h3>");
            this._xb41faee6912a2313.Append(Encode(title));
            this._xb41faee6912a2313.Append("</h3>");
        }

        public void Header(string head)
        {
            this._xb41faee6912a2313.Append("<th>");
            this._xb41faee6912a2313.Append(Encode(head));
            this._xb41faee6912a2313.Append("</th>");
        }

        public void ListItem(string str)
        {
            this._xb41faee6912a2313.Append("<li>");
            this._xb41faee6912a2313.Append(Encode(str));
        }

        public void Para(string str)
        {
            this._xb41faee6912a2313.Append("<p>");
            this._xb41faee6912a2313.Append(Encode(str));
            this._xb41faee6912a2313.Append("</p>");
        }

        public void TablePair(string name, string v)
        {
            this.BeginRow();
            this._xb41faee6912a2313.Append("<td><b>" + Encode(name) + "</b></td>");
            this.Cell(v);
            this.EndRow();
        }

        public void Title(string str)
        {
            this._xb41faee6912a2313.Append("<head><title>");
            this._xb41faee6912a2313.Append(str);
            this._xb41faee6912a2313.Append("</title></head>");
        }

        public override string ToString()
        {
            return this._xb41faee6912a2313.ToString();
        }
    }
}

