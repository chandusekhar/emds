namespace Encog.App.Analyst.Script.Task
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnalystTask
    {
        private readonly IList<string> _x0383ec486664fa18 = new List<string>();
        private string _xc15bd84e01929885;

        public AnalystTask(string theName)
        {
            this._xc15bd84e01929885 = theName;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            builder.Append(" name=");
            builder.Append(this._xc15bd84e01929885);
            builder.Append("]");
            return builder.ToString();
        }

        public IList<string> Lines
        {
            get
            {
                return this._x0383ec486664fa18;
            }
        }

        public string Name
        {
            get
            {
                return this._xc15bd84e01929885;
            }
            set
            {
                this._xc15bd84e01929885 = value;
            }
        }
    }
}

