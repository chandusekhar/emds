namespace Encog.Util
{
    using Encog;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;

    public class ParamsHolder
    {
        private readonly IDictionary<string, string> _x290a8cdbc9dbb3c1;
        private readonly CSVFormat _x5786461d089b10a0;

        public ParamsHolder(IDictionary<string, string> theParams) : this(theParams, CSVFormat.EgFormat)
        {
        }

        public ParamsHolder(IDictionary<string, string> theParams, CSVFormat theFormat)
        {
            this._x290a8cdbc9dbb3c1 = theParams;
            this._x5786461d089b10a0 = theFormat;
        }

        public bool GetBoolean(string name, bool required, bool defaultValue)
        {
            string str = this.GetString(name, required, null);
            if (str == null)
            {
                return defaultValue;
            }
            if (((((uint) defaultValue) - ((uint) defaultValue)) >= 0) && (((uint) defaultValue) > uint.MaxValue))
            {
                goto Label_001D;
            }
        Label_000F:
            if (str.Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_00ED;
            }
        Label_001D:
            if (!str.Equals("false", StringComparison.InvariantCultureIgnoreCase))
            {
                string[] strArray = new string[5];
                strArray[0] = "Property ";
                strArray[1] = name;
                if ((((uint) defaultValue) | 0xff) == 0)
                {
                    goto Label_000F;
                }
                if ((((uint) defaultValue) + ((uint) required)) <= uint.MaxValue)
                {
                    strArray[2] = " has an invalid value of ";
                    strArray[3] = str;
                    strArray[4] = ", should be true/false.";
                    throw new EncogError(string.Concat(strArray));
                }
            }
        Label_00ED:
            return str.Equals("true", StringComparison.InvariantCultureIgnoreCase);
        }

        public double GetDouble(string name, bool required, double defaultValue)
        {
            double num;
            string str = this.GetString(name, required, null);
            while (str == null)
            {
                return defaultValue;
            }
            try
            {
                num = this._x5786461d089b10a0.Parse(str);
            }
            catch (FormatException)
            {
                string[] strArray;
                if ((((uint) num) - ((uint) required)) >= 0)
                {
                    goto Label_0046;
                }
            Label_0039:
                if (0 == 0)
                {
                    strArray[4] = ", should be valid floating point.";
                    throw new EncogError(string.Concat(strArray));
                }
            Label_0046:
                strArray = new string[5];
                strArray[0] = "Property ";
                strArray[1] = name;
                strArray[2] = " has an invalid value of ";
                strArray[3] = str;
                goto Label_0039;
            }
            return num;
        }

        public int GetInt(string name, bool required, int defaultValue)
        {
            int num;
            string s = this.GetString(name, required, null);
            if (s == null)
            {
                return defaultValue;
            }
            try
            {
                num = int.Parse(s);
            }
            catch (FormatException)
            {
                string[] strArray;
                if ((((uint) defaultValue) & 0) == 0)
                {
                    goto Label_0056;
                }
            Label_002D:
                strArray = new string[] { "Property ", name, " has an invalid value of ", s, ", should be valid integer." };
                throw new EncogError(string.Concat(strArray));
            Label_0056:
                if (((uint) required) >= 0)
                {
                }
                goto Label_002D;
            }
            return num;
        }

        public string GetString(string name, bool required, string defaultValue)
        {
            if (this._x290a8cdbc9dbb3c1.ContainsKey(name))
            {
                return this._x290a8cdbc9dbb3c1[name];
                if (0 == 0)
                {
                    return defaultValue;
                }
            }
            if (required)
            {
                throw new EncogError("Missing property: " + name);
            }
            return defaultValue;
        }

        public IDictionary<string, string> Params
        {
            get
            {
                return this._x290a8cdbc9dbb3c1;
            }
        }
    }
}

