namespace Nsim.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                bool flag = resourceMan != null;
                if (((((uint) flag) - ((uint) flag)) >= 0) || (((uint) flag) > uint.MaxValue))
                {
                    if ((-2147483648 == 0) || !flag)
                    {
                        System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Nsim.Properties.Resources", typeof(Resources).Assembly);
                        resourceMan = manager;
                    }
                }
                else
                {
                    System.Resources.ResourceManager manager2;
                    return manager2;
                }
                return resourceMan;
            }
        }
    }
}

