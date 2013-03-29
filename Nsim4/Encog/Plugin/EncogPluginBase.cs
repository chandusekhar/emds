namespace Encog.Plugin
{
    using System;

    public interface EncogPluginBase
    {
        string PluginDescription { get; }

        string PluginName { get; }

        int PluginServiceType { get; }

        int PluginType { get; }
    }
}

