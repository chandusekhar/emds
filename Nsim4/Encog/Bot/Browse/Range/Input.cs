namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;
    using System.Text;

    public class Input : FormElement
    {
        private string _x43163d22e8cd5a71;

        public Input(WebPage source) : base(source)
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (0xff != 0)
            {
                goto Label_0059;
            }
        Label_000D:
            builder.Append(",name=");
            if (-1 != 0)
            {
            }
            builder.Append(base.Name);
            builder.Append(",value=");
            builder.Append(base.Value);
            builder.Append("]");
            if (4 != 0)
            {
                return builder.ToString();
            }
        Label_0059:
            builder.Append("[Input:");
            builder.Append("type=");
            builder.Append(this.Type);
            goto Label_000D;
        }

        public override bool AutoSend
        {
            get
            {
                return (string.Compare(this._x43163d22e8cd5a71, "submit", true) != 0);
            }
        }

        public string Type
        {
            get
            {
                return this._x43163d22e8cd5a71;
            }
            set
            {
                this._x43163d22e8cd5a71 = value;
            }
        }
    }
}

