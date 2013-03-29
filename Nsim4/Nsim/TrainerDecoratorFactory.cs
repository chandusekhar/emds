namespace Nsim
{
    using System;
    using System.Collections.Generic;

    internal static class TrainerDecoratorFactory
    {
        private static readonly List<ITrainerDecoratorDescriptor> x0821fce41ef1687a = new List<ITrainerDecoratorDescriptor>();

        static TrainerDecoratorFactory()
        {
            if (2 != 0)
            {
                x0821fce41ef1687a.Add(new x3e14c21047440e17<TrainerDecorator<ResilientPropagation>>("Упругого распространения"));
                if (0 != 0)
                {
                    return;
                }
            }
            x0821fce41ef1687a.Add(new x3e14c21047440e17<BackpropagationTrainerDecorator>("Обратного распространения"));
            x0821fce41ef1687a.Add(new x3e14c21047440e17<LevenbergMarquardtTrainingTrainerDecorator>("Левенберга—Марквардта"));
            if (4 != 0)
            {
                x0821fce41ef1687a.Add(new x3e14c21047440e17<NeuralGeneticAlgorithmTrainerDecorator>("Генетический"));
                x0821fce41ef1687a.Add(new x3e14c21047440e17<TrainerDecorator<ScaledConjugateGradient>>("Сопряженных градиентов"));
                x0821fce41ef1687a.Add(new x3e14c21047440e17<LearningRateTrainerDecorator<ManhattanPropagation>>("Манхэттена"));
                x0821fce41ef1687a.Add(new x3e14c21047440e17<LearningRateTrainerDecorator<QuickPropagation>>("Быстрого распространения"));
            }
        }

        public static IEnumerable<ITrainerDecoratorDescriptor> TrainerDescriptors
        {
            get
            {
                return x0821fce41ef1687a;
            }
        }
    }
}

