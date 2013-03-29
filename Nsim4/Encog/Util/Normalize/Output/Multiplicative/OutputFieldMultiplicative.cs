namespace Encog.Util.Normalize.Output.Multiplicative
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using System;

    [Serializable]
    public class OutputFieldMultiplicative : OutputFieldGrouped
    {
        public OutputFieldMultiplicative()
        {
        }

        public OutputFieldMultiplicative(IOutputFieldGroup group, IInputField field) : base(group, field)
        {
            while (!(group is MultiplicativeGroup))
            {
                throw new NormalizationError("Must use MultiplicativeGroup with OutputFieldMultiplicative.");
            }
        }

        public override double Calculate(int subfield)
        {
            return (base.SourceField.CurrentValue / ((MultiplicativeGroup) base.Group).Length);
        }

        public override void RowInit()
        {
        }

        public override int SubfieldCount
        {
            get
            {
                return 1;
            }
        }
    }
}

