namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Windows;
    using System.Xml.Linq;

    public class RandomDecorator<T> : IConfigurable, IConfigControlProvider, IRandomDecorator, IRandomStruct where T: IRandomizer
    {
        public const string ElementName = "RandomConfig";
        public const string TypeAttributeName = "Type";

        public virtual FrameworkElement GetConfigControl()
        {
            return null;
        }

        public static Type GetDecoratedType()
        {
            return typeof(T);
        }

        public virtual IRandomizer GetRandom()
        {
            throw new NotImplementedException();
        }

        protected virtual XElement GetXml()
        {
            return new XElement("RandomConfig", new XAttribute("Type", typeof(T).Name));
        }

        protected virtual void SetXml(XElement xml)
        {
            // This item is obfuscated and can not be translated.
            bool flag;
            if (xml != null)
            {
                goto Label_00AC;
            }
        Label_0037:
            flag = false;
            if ((((uint) flag) | 3) != 0)
            {
                if (3 != 0)
                {
                    if ((((uint) flag) & 0) != 0)
                    {
                        return;
                    }
                    if (!flag)
                    {
                        throw new ArgumentException();
                    }
                    if (0 == 0)
                    {
                        return;
                    }
                    goto Label_00AC;
                }
                if (xml.Name.LocalName != "RandomConfig")
                {
                    goto Label_0037;
                }
            }
            if (xml.Attribute("Type") == null)
            {
            }
            goto Label_0037;
        }

        public XElement Xml
        {
            get
            {
                return this.GetXml();
            }
            set
            {
                this.SetXml(value);
            }
        }
    }
}

