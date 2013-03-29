namespace Nsim
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal class xf266003de4abb417<T> : IActivationDecoratorDescriptor where T: IActivationDecorator
    {
        private readonly Type _x48a150aa547655ec;
        [CompilerGenerated]
        private static Func<MethodInfo, bool> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private Type x249c9c9431aa4299;
        [CompilerGenerated]
        private static Func<MethodInfo, bool> x3ea1037ccf291a94;
        [CompilerGenerated]
        private string x84ae50e55afbb83e;
        [CompilerGenerated]
        private static Func<MethodInfo, bool> xec790bb6d0304faa;

        public xf266003de4abb417(string title)
        {
            // This item is obfuscated and can not be translated.
        }

        public IActivationDecorator GetDecorator()
        {
            return (this._x48a150aa547655ec.GetConstructors().First<ConstructorInfo>().Invoke(null) as IActivationDecorator);
        }

        public IActivationDecorator GetDecorator(XElement config)
        {
            IActivationDecorator decorator = this.GetDecorator();
            decorator.Xml = config;
            return decorator;
        }

        [CompilerGenerated]
        private static bool xed8c4a3b422f5390(MethodInfo x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.Name == "GetDecoratedType");
        }

        [CompilerGenerated]
        private static bool xf29670e286f5562f(MethodInfo x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.Name == "GetDecoratedType");
        }

        [CompilerGenerated]
        private static bool xfef8a9719a9ce225(MethodInfo x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.Name == "GetDecoratedType");
        }

        public Type DecoratedType
        {
            [CompilerGenerated]
            get
            {
                return this.x249c9c9431aa4299;
            }
            [CompilerGenerated]
            private set
            {
                this.x249c9c9431aa4299 = value;
            }
        }

        public string Title
        {
            [CompilerGenerated]
            get
            {
                return this.x84ae50e55afbb83e;
            }
            [CompilerGenerated]
            private set
            {
                this.x84ae50e55afbb83e = value;
            }
        }
    }
}

