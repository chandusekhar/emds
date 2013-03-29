namespace Nsim
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal static class xe362616ebc6ada30
    {
        public static XElement x20ef846b7fe0cd42<T>(this XElement x4bbc2c453c470189, string xc15bd84e01929885) where T: class, IConfigurable
        {
            return x4bbc2c453c470189.AddContent(App.Services.GetService<T>().Xml.AddContent(xc15bd84e01929885.ToNameAttribute()));
        }

        public static void x9f74ccae27c47030<T>(this XElement x4bbc2c453c470189, string xc15bd84e01929885) where T: class, IConfigurable
        {
            App.Services.GetService<T>().Xml = x4bbc2c453c470189.Elements().ByName(xc15bd84e01929885);
        }
    }
}

