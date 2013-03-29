namespace Nsim
{
    using Encog.Engine.Network.Activation;
    using System;
    using System.Windows;
    using System.Xml.Linq;

    internal class xdb76bc24a79224de<T> : IConfigurable, IConfigControlProvider, IActivationStruct, IActivationDecorator where T: IActivationFunction, new()
    {
        public const string ElementName = "ActivationFunction";
        public const string xd9a9c50036cabafb = "Type";

        public virtual IActivationFunction GetActivation()
        {
            IActivationFunction function;
            T local = default(T);
            if (-2 == 0)
            {
                goto Label_0020;
            }
        Label_0013:
            if (local != null)
            {
                local = default(T);
            }
        Label_0020:
            function = Activator.CreateInstance<T>();
            goto Label_0013;
        }

        public virtual FrameworkElement GetConfigControl()
        {
            return new ActivationEmptyConfig();
        }

        public static Type GetDecoratedType()
        {
            return typeof(T);
        }

        protected virtual XElement GetXml()
        {
            return new XElement("ActivationFunction", new XAttribute("Type", typeof(T).Name));
        }

        protected virtual void SetXml(XElement xml)
        {
            // This item is obfuscated and can not be translated.
            bool flag;
            if ((xml != null) && (xml.Name.LocalName == "ActivationFunction"))
            {
                if ((((uint) flag) < 0) && ((((uint) flag) | 8) == 0))
                {
                    return;
                }
                if (xml.Attribute("Type") == null)
                {
                }
            }
        Label_0063:
            flag = false;
            if (4 != 0)
            {
                if (flag)
                {
                    return;
                }
            }
            else if (3 == 0)
            {
                goto Label_0063;
            }
            throw new ArgumentException();
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

