namespace Nsim
{
    using System;
    using System.Collections.Generic;

    internal static class RandomDecoratorFactory
    {
        private static readonly List<IRandomDecoratorDescriptor> x0821fce41ef1687a = new List<IRandomDecoratorDescriptor>();

        static RandomDecoratorFactory()
        {
            while (true)
            {
                x0821fce41ef1687a.Add(new xb999c9330b7a1db7<xb417a5fb2bc37c95>("Автоматически"));
                do
                {
                    x0821fce41ef1687a.Add(new xb999c9330b7a1db7<xea522cb7be4b23be>("Постоянный"));
                    x0821fce41ef1687a.Add(new xb999c9330b7a1db7<ConstRandomizerDecorator>("Константа"));
                    x0821fce41ef1687a.Add(new xb999c9330b7a1db7<GaussianRandomizerDecorator>("Гаусса"));
                    x0821fce41ef1687a.Add(new xb999c9330b7a1db7<IntervalRandomDecorator<RangeRandomizer>>("Равномерное"));
                }
                while (0x7fffffff == 0);
                x0821fce41ef1687a.Add(new xb999c9330b7a1db7<IntervalRandomDecorator<NguyenWidrowRandomizer>>("Нгуен-Видроу"));
                if (0 == 0)
                {
                    return;
                }
            }
        }

        public static IEnumerable<IRandomDecoratorDescriptor> RandomDescriptors
        {
            get
            {
                return x0821fce41ef1687a;
            }
        }
    }
}

