namespace Encog.Bot.Browse.Range
{
    using Encog.Bot.Browse;
    using System;

    public abstract class FormElement : DocumentRange
    {
        private Form _x071bde1041617fce;
        private string _xbcea506a33cf9111;
        private string _xc15bd84e01929885;

        protected FormElement(WebPage source) : base(source)
        {
        }

        public abstract bool AutoSend { get; }

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

        public Form Owner
        {
            get
            {
                return this._x071bde1041617fce;
            }
            set
            {
                this._x071bde1041617fce = value;
            }
        }

        public string Value
        {
            get
            {
                return this._xbcea506a33cf9111;
            }
            set
            {
                this._xbcea506a33cf9111 = value;
            }
        }
    }
}

