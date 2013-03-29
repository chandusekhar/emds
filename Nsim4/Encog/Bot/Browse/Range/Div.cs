namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;
    using System.Text;

    public class Div : DocumentRange
    {
        public Div(WebPage source) : base(source)
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[Div:class=");
            builder.Append(base.ClassAttribute);
            builder.Append(",id=");
            if (-2 != 0)
            {
            }
            builder.Append(base.IdAttribute);
            builder.Append(",elements=");
            builder.Append(base.Elements.Count);
            builder.Append("]");
            return builder.ToString();
        }
    }
}

