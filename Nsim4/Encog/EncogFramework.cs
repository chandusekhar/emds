namespace Encog
{
    using Encog.Plugin;
    using Encog.Plugin.SystemPlugin;
    using System;
    using System.Collections.Generic;

    public class EncogFramework
    {
        private static EncogFramework _x6ed4ed9ed59eb694 = new EncogFramework();
        private IEncogPluginLogging1 _xae206eda292f3e91;
        private readonly IList<EncogPluginBase> _xdd29f42de85b003a;
        private readonly IDictionary<string, string> _xe11545499171cc05 = new Dictionary<string, string>();
        public const double DefaultDoubleEqual = 1E-07;
        public const int DefaultPrecision = 10;
        public static string EncogFileVersion = "encog.file.version";
        public const string EncogVersion = "encog.version";
        public static string PLATFORM = "DotNet";
        public static string Version = "3.0.0";
        private const string xf1b77e84e571fc5e = "1";

        private EncogFramework()
        {
            this._xe11545499171cc05["encog.version"] = Version;
            if (0 == 0)
            {
                this._xe11545499171cc05[EncogFileVersion] = "1";
                this._xdd29f42de85b003a = new List<EncogPluginBase>();
            }
            this.RegisterPlugin(new SystemLoggingPlugin());
            this.RegisterPlugin(new SystemMethodsPlugin());
            this.RegisterPlugin(new SystemTrainingPlugin());
            this.RegisterPlugin(new SystemActivationPlugin());
        }

        public void RegisterPlugin(EncogPluginBase plugin)
        {
            if ((plugin.PluginServiceType == 0) || (plugin.PluginServiceType != 1))
            {
                goto Label_0029;
            }
        Label_000A:
            if (this._xae206eda292f3e91 != null)
            {
                this._xdd29f42de85b003a.Remove(this._xae206eda292f3e91);
            }
            this._xae206eda292f3e91 = (IEncogPluginLogging1) plugin;
        Label_0029:
            this._xdd29f42de85b003a.Add(plugin);
            if (0 == 0)
            {
                return;
            }
            goto Label_000A;
        }

        public void Shutdown()
        {
        }

        public void UnregisterPlugin(EncogPluginBase plugin)
        {
            if (plugin == this._xae206eda292f3e91)
            {
                this._xae206eda292f3e91 = new SystemLoggingPlugin();
            }
            this._xdd29f42de85b003a.Remove(plugin);
        }

        public static EncogFramework Instance
        {
            get
            {
                return _x6ed4ed9ed59eb694;
            }
        }

        public IEncogPluginLogging1 LoggingPlugin
        {
            get
            {
                return this._xae206eda292f3e91;
            }
        }

        public IList<EncogPluginBase> Plugins
        {
            get
            {
                return this._xdd29f42de85b003a;
            }
        }

        public IDictionary<string, string> Properties
        {
            get
            {
                return this._xe11545499171cc05;
            }
        }
    }
}

