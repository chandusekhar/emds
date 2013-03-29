namespace Nsim
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml;
    using System.Xml.Linq;

    public static class XmlExtensions
    {
        [CompilerGenerated]
        private static Func<XElement, double> x3ea1037ccf291a94;

        public static XElement AddContent(this XElement element, object content)
        {
            element.Add(content);
            return element;
        }

        public static double[] AsArray(this XContainer xmlElement)
        {
            if (xmlElement != null)
            {
            }
            return ((x3ea1037ccf291a94 != null) ? null : Enumerable.Select<XElement, double>(xmlElement.Elements("Data"), x3ea1037ccf291a94).ToArray<double>());
        }

        public static bool AsBool(this XAttribute att, [Optional, DefaultParameterValue(false)] bool defaultValue)
        {
            return ((att != null) ? bool.Parse(att.Value) : defaultValue);
        }

        public static double AsDouble(this XAttribute att, [Optional, DefaultParameterValue(0.0)] double defaultValue)
        {
            return ((att != null) ? x3a99ec4dbd038b70(att.Value) : defaultValue);
        }

        public static T AsEnumValue<T>(this XAttribute att, [Optional, DefaultParameterValue(null)] T defaultValue)
        {
            return ((att != null) ? ((T) Enum.Parse(typeof(T), att.Value)) : defaultValue);
        }

        public static Guid AsGuid(this XAttribute att)
        {
            return ((att != null) ? new Guid(att.Value) : Guid.Empty);
        }

        public static T AsInstance<T>(this Type type)
        {
            return (T) type.GetConstructor(new Type[0]).Invoke(null);
        }

        public static int AsInt(this XAttribute att, [Optional, DefaultParameterValue(0)] int defaultValue)
        {
            return ((att != null) ? int.Parse(att.Value) : defaultValue);
        }

        public static string AsString(this XAttribute att, [Optional, DefaultParameterValue(null)] string defaultValue)
        {
            return ((att != null) ? att.Value : defaultValue);
        }

        public static Type AsType(this XAttribute att, [Optional, DefaultParameterValue(null)] Type defaultValue)
        {
            // This item is obfuscated and can not be translated.
        }

        public static XElement AsXElement(this string xml)
        {
            return XDocument.Parse(xml).Root;
        }

        public static XElement AsXElement(this XmlNode xmlNode)
        {
            return xmlNode.OuterXml.AsXElement();
        }

        public static XElement AsXElement(this XmlNode xmlNode, string elementName)
        {
            return xmlNode.AsXElement().Element(elementName);
        }

        public static XmlNode AsXmlNode(this string xml)
        {
            XmlDocument document = new XmlDocument {
                InnerXml = xml
            };
            return document.DocumentElement;
        }

        public static XmlNode AsXmlNode(this XElement xElement)
        {
            return xElement.ToString().AsXmlNode();
        }

        public static XElement ByName(this IEnumerable<XElement> elements, string name)
        {
            <>c__DisplayClass1 class2;
            return Enumerable.FirstOrDefault<XElement>(elements, new Func<XElement, bool>(class2, (IntPtr) this.<ByName>b__0));
        }

        public static double DoubleAttribute(this XElement element, string attributeName, [Optional, DefaultParameterValue(0.0)] double defaultValue)
        {
            return element.Attribute(attributeName).AsDouble(defaultValue);
        }

        public static T EnumAttribute<T>(this XElement element, string attributeName, [Optional, DefaultParameterValue(null)] T defaultValue)
        {
            return element.Attribute(attributeName).AsEnumValue<T>(defaultValue);
        }

        public static int IntAttribute(this XElement element, string attributeName, [Optional, DefaultParameterValue(0)] int defaultValue)
        {
            return element.Attribute(attributeName).AsInt(defaultValue);
        }

        public static string StringAttribute(this XElement element, string attributeName, [Optional, DefaultParameterValue(null)] string defaultValue)
        {
            return element.Attribute(attributeName).AsString(defaultValue);
        }

        public static XAttribute ToNameAttribute(this string name)
        {
            return new XAttribute("Name", name);
        }

        public static XElement ToXElement(this IList<double> data)
        {
            int num;
            XElement element = new XElement("Array");
            if (0 == 0)
            {
                num = 0;
            }
            while (num < data.Count)
            {
                element.Add(new XElement("Data", new object[] { new XAttribute("Index", num), new XAttribute("Value", data[num]) }));
                num++;
            }
            return element;
        }

        private static double x3a99ec4dbd038b70(string xe4115acdf4fbfccc)
        {
            xe4115acdf4fbfccc = xe4115acdf4fbfccc.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            xe4115acdf4fbfccc = xe4115acdf4fbfccc.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            return double.Parse(xe4115acdf4fbfccc, CultureInfo.InvariantCulture.NumberFormat);
        }

        [CompilerGenerated]
        private static double x63be060911aed407(XElement x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.Attribute("Value").AsDouble(0.0);
        }
    }
}

