namespace Encog.ML
{
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public abstract class BasicML : IMLMethod, IMLProperties
    {
        private readonly IDictionary<string, string> _properties = new Dictionary<string, string>();

        protected BasicML()
        {
        }

        public double GetPropertyDouble(string name)
        {
            return CSVFormat.EgFormat.Parse(this._properties[name]);
        }

        public long GetPropertyLong(string name)
        {
            return long.Parse(this._properties[name]);
        }

        public string GetPropertyString(string name)
        {
            if (this._properties.ContainsKey(name))
            {
                return this._properties[name];
            }
            return null;
        }

        public void SetProperty(string name, double d)
        {
            this._properties[name] = CSVFormat.EgFormat.Format(d, 10);
            this.UpdateProperties();
        }

        public void SetProperty(string name, long l)
        {
            this._properties[name] = l;
            this.UpdateProperties();
        }

        public void SetProperty(string name, string v)
        {
            this._properties[name] = v;
            this.UpdateProperties();
        }

        public abstract void UpdateProperties();

        public IDictionary<string, string> Properties
        {
            get
            {
                return this._properties;
            }
        }
    }
}

