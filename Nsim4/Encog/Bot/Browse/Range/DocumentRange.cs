namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using Encog.Bot.DataUnits;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DocumentRange
    {
        private WebPage _x337e217cb3ba0627;
        private readonly IList<DocumentRange> _x6e96c3657c96bbbe = new List<DocumentRange>();
        [CompilerGenerated]
        private DocumentRange x1548549334a804e7;
        [CompilerGenerated]
        private string x31fe0294870ceda2;
        [CompilerGenerated]
        private string x74820bbf5a9a481c;
        [CompilerGenerated]
        private int xa67c0de35ff21e84;
        [CompilerGenerated]
        private int xb8ac65837f8cd454;

        public DocumentRange(WebPage source)
        {
            this._x337e217cb3ba0627 = source;
        }

        public void AddElement(DocumentRange element)
        {
            this.Elements.Add(element);
            element.Parent = this;
        }

        public string GetTextOnly()
        {
            StringBuilder builder = new StringBuilder();
            int begin = this.Begin;
            goto Label_0025;
        Label_0021:
            begin++;
        Label_0025:
            if (begin >= this.End)
            {
                return builder.ToString();
            }
            DataUnit unit = this._x337e217cb3ba0627.Data[begin];
            if (unit is TextDataUnit)
            {
                builder.Append(unit.ToString());
            }
            else
            {
                goto Label_0021;
            }
            if (0 == 0)
            {
                builder.Append("\n");
            }
            goto Label_0021;
        }

        public override string ToString()
        {
            return this.GetTextOnly();
        }

        public int Begin
        {
            [CompilerGenerated]
            get
            {
                return this.xb8ac65837f8cd454;
            }
            [CompilerGenerated]
            set
            {
                this.xb8ac65837f8cd454 = value;
            }
        }

        public string ClassAttribute
        {
            [CompilerGenerated]
            get
            {
                return this.x31fe0294870ceda2;
            }
            [CompilerGenerated]
            set
            {
                this.x31fe0294870ceda2 = value;
            }
        }

        public IList<DocumentRange> Elements
        {
            get
            {
                return this._x6e96c3657c96bbbe;
            }
        }

        public int End
        {
            [CompilerGenerated]
            get
            {
                return this.xa67c0de35ff21e84;
            }
            [CompilerGenerated]
            set
            {
                this.xa67c0de35ff21e84 = value;
            }
        }

        public string IdAttribute
        {
            [CompilerGenerated]
            get
            {
                return this.x74820bbf5a9a481c;
            }
            [CompilerGenerated]
            set
            {
                this.x74820bbf5a9a481c = value;
            }
        }

        public DocumentRange Parent
        {
            [CompilerGenerated]
            get
            {
                return this.x1548549334a804e7;
            }
            [CompilerGenerated]
            set
            {
                this.x1548549334a804e7 = value;
            }
        }

        public WebPage Source
        {
            get
            {
                return this._x337e217cb3ba0627;
            }
            set
            {
                this._x337e217cb3ba0627 = value;
            }
        }
    }
}

