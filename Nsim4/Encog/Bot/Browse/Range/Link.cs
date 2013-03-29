namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;
    using System.Text;

    public class Link : DocumentRange
    {
        private Address _x11d58b056c032b03;

        public Link(WebPage source) : base(source)
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[Link:");
            if (0 == 0)
            {
            }
            builder.Append(this._x11d58b056c032b03);
            builder.Append("|");
            builder.Append(base.GetTextOnly());
            builder.Append("]");
            return builder.ToString();
        }

        public Address Target
        {
            get
            {
                return this._x11d58b056c032b03;
            }
            set
            {
                this._x11d58b056c032b03 = value;
            }
        }
    }
}

