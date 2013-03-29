namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Script.Prop;
    using System;
    using System.Text;

    public abstract class Cmd
    {
        private readonly EncogAnalyst _x554f16462d8d4675;
        private readonly AnalystScript _x594135906c55045c;
        private readonly ScriptProperties _xe11545499171cc05;

        protected Cmd(EncogAnalyst theAnalyst)
        {
            this._x554f16462d8d4675 = theAnalyst;
            this._x594135906c55045c = this._x554f16462d8d4675.Script;
            this._xe11545499171cc05 = this._x594135906c55045c.Properties;
        }

        public abstract bool ExecuteCommand(string args);
        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            builder.Append(" name=");
            builder.Append(this.Name);
            builder.Append("]");
            return builder.ToString();
        }

        public EncogAnalyst Analyst
        {
            get
            {
                return this._x554f16462d8d4675;
            }
        }

        public abstract string Name { get; }

        public ScriptProperties Prop
        {
            get
            {
                return this._xe11545499171cc05;
            }
        }

        public AnalystScript Script
        {
            get
            {
                return this._x594135906c55045c;
            }
        }
    }
}

