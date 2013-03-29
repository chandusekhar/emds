namespace Nsim
{
    using System;
    using System.Collections.Generic;

    public static class ActivationDecoratorFactory
    {
        private static readonly List<IActivationDecoratorDescriptor> x0821fce41ef1687a = new List<IActivationDecoratorDescriptor>();

        static ActivationDecoratorFactory()
        {
            while (true)
            {
                if (-2147483648 != 0)
                {
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationBiPolar>>("Биполярная"));
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationCompetitive>>("Конкуренции"));
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xc49d19d0e6c1e155>("Гаусса"));
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationLinear>>("Линейная"));
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationLOG>>("Логорифмическая"));
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationRamp>>("Наклонная"));
                }
                x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationSigmoid>>("Сигмоида"));
                x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationSIN>>("Синус"));
                x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationSoftMax>>("Софтмакс"));
                x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationStep>>("Ступенька"));
                if (0 == 0)
                {
                    x0821fce41ef1687a.Add(new xf266003de4abb417<xdb76bc24a79224de<ActivationTANH>>("Тангенс Гиперболический"));
                    return;
                }
            }
        }

        public static IEnumerable<IActivationDecoratorDescriptor> ActivationDescriptors
        {
            get
            {
                return x0821fce41ef1687a;
            }
        }
    }
}

