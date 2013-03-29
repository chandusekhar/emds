namespace Nsim
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal static class x479f2661aae93792
    {
        public static XAttribute x289fcfc6ab32371c(this IDataProcessor xb01e0f96838bac90)
        {
            return new XAttribute("IsUsed", xb01e0f96838bac90.IsUsed);
        }

        public static bool xa14291458369dcd9(this XElement x4bbc2c453c470189)
        {
            return x4bbc2c453c470189.Attribute("IsUsed").AsBool(false);
        }
    }
}

