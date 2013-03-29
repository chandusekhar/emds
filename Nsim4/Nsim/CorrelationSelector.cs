namespace Nsim
{
    using System;
    using System.ComponentModel;

    [TypeConverter(typeof(EnumTypeConverter))]
    public enum CorrelationSelector
    {
        [Description("Максимальная корреляция")]
        Max = 0,
        [Description("Средняя корреляция")]
        Mean = 1,
        [Description("Голосование")]
        Vote = 2
    }
}

