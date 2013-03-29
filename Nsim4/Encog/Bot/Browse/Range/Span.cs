namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;
    using System.Text;

    public class Span : DocumentRange
    {
        public Span(WebPage source) : base(source)
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[Span:class=");
            builder.Append(base.ClassAttribute);
            if (0 == 0)
            {
                if (0 == 0)
                {
                }
                builder.Append(",id=");
                builder.Append(base.IdAttribute);
                builder.Append(",elements=");
                builder.Append(base.Elements.Count);
                builder.Append("]");
            }
            return builder.ToString();
        }
    }
}

