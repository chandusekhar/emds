namespace Encog.Util.CSV
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;

    [Serializable]
    public class CSVFormat
    {
        private readonly char _decimalChar;
        private readonly string[] _formats;
        private readonly NumberFormatInfo _numberFormat;
        private readonly char _separatorChar;
        public const int MaxFormats = 100;

        static CSVFormat()
        {
            DecimalComma = new CSVFormat(',', ';');
            DecimalPoint = new CSVFormat('.', ',');
        }

        public CSVFormat()
        {
        }

        public CSVFormat(char decimalChar, char separatorChar)
        {
            int num;
            int num2;
            if ((((uint) num) | 0x7fffffff) != 0)
            {
                if ((((uint) num) | uint.MaxValue) != 0)
                {
                    this._decimalChar = decimalChar;
                }
                this._separatorChar = separatorChar;
                if (decimalChar == '.')
                {
                    this._numberFormat = new CultureInfo("en-us").NumberFormat;
                    goto Label_00B1;
                }
            }
            if ((((uint) num2) >= 0) && (decimalChar != ','))
            {
                this._numberFormat = NumberFormatInfo.CurrentInfo;
            }
            else
            {
                this._numberFormat = new CultureInfo("de-DE").NumberFormat;
            }
        Label_00B1:
            this._formats = new string[100];
            num = 0;
            if ((((uint) num2) - ((uint) num)) < 0)
            {
                goto Label_00B1;
            }
            while (true)
            {
                StringBuilder builder;
                if (num < 100)
                {
                    builder = new StringBuilder();
                    builder.Append("#0");
                    if (num > 0)
                    {
                        builder.Append(".");
                    }
                }
                else
                {
                    return;
                }
                for (num2 = 0; num2 < num; num2++)
                {
                    builder.Append("#");
                }
                this._formats[num] = builder.ToString();
                num++;
            }
        }

        public string Format(double d, int digits)
        {
            int index = Math.Max(Math.Min(digits, 100), 0);
            return d.ToString(this._formats[index], this._numberFormat);
        }

        public double Parse(string str)
        {
            return double.Parse(str.Trim(), this._numberFormat);
        }

        public char DecimalChar
        {
            get
            {
                return this._decimalChar;
            }
        }

        public static char DecimalCharacter
        {
            get
            {
                return NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0];
            }
        }

        public static CSVFormat DecimalComma
        {
            [CompilerGenerated]
            get
            {
                return <DecimalComma>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                <DecimalComma>k__BackingField = value;
            }
        }

        public static CSVFormat DecimalPoint
        {
            [CompilerGenerated]
            get
            {
                return <DecimalPoint>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                <DecimalPoint>k__BackingField = value;
            }
        }

        public static CSVFormat EgFormat
        {
            get
            {
                return DecimalPoint;
            }
        }

        public static CSVFormat English
        {
            get
            {
                return DecimalPoint;
            }
        }

        public char Separator
        {
            get
            {
                return this._separatorChar;
            }
        }
    }
}

