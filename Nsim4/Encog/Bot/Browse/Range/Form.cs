namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Form : DocumentRange
    {
        [CompilerGenerated]
        private FormMethod x10cde88d44e103b8;
        [CompilerGenerated]
        private Address xb4b12b442587f260;

        public Form(WebPage source) : base(source)
        {
        }

        public Input FindType(string type, int index)
        {
            int num = index;
            using (IEnumerator<DocumentRange> enumerator = base.Elements.GetEnumerator())
            {
                DocumentRange range;
                Input input;
                goto Label_0047;
            Label_0011:
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0047;
                }
            Label_0025:
                if (string.Compare(input.Type, type, true) == 0)
                {
                    goto Label_009D;
                }
                goto Label_0047;
            Label_0039:
                if (0xff == 0)
                {
                    goto Label_007A;
                }
                if (4 == 0)
                {
                    Input input2;
                    return input2;
                }
            Label_0047:
                if (enumerator.MoveNext())
                {
                    goto Label_00A7;
                }
                if ((((uint) num) - ((uint) index)) >= 0)
                {
                    goto Label_00C1;
                }
                if (((uint) index) <= uint.MaxValue)
                {
                }
            Label_007A:
                if (range is Input)
                {
                    goto Label_0091;
                }
                goto Label_0011;
            Label_0089:
                num--;
                goto Label_0039;
            Label_0091:
                input = (Input) range;
                goto Label_0025;
            Label_009D:
                if (num > 0)
                {
                    goto Label_0089;
                }
                return input;
            Label_00A7:
                range = enumerator.Current;
                goto Label_007A;
            }
        Label_00C1:
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[Form:");
            builder.Append("method=");
            builder.Append(this.Method);
            if (4 != 0)
            {
                builder.Append(",action=");
                builder.Append(this.Action);
                if (8 != 0)
                {
                    foreach (DocumentRange range in base.Elements)
                    {
                        builder.Append("\n\t");
                        builder.Append(range.ToString());
                    }
                    builder.Append("]");
                }
            }
            return builder.ToString();
        }

        public Address Action
        {
            [CompilerGenerated]
            get
            {
                return this.xb4b12b442587f260;
            }
            [CompilerGenerated]
            set
            {
                this.xb4b12b442587f260 = value;
            }
        }

        public FormMethod Method
        {
            [CompilerGenerated]
            get
            {
                return this.x10cde88d44e103b8;
            }
            [CompilerGenerated]
            set
            {
                this.x10cde88d44e103b8 = value;
            }
        }

        public enum FormMethod
        {
            Post,
            Get
        }
    }
}

