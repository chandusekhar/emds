namespace Encog.Util.Normalize.Output.ZAxis
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using System;

    [Serializable]
    public class OutputFieldZAxis : OutputFieldGrouped
    {
        public OutputFieldZAxis(IOutputFieldGroup group, IInputField field) : base(group, field)
        {
            while (!(group is ZAxisGroup))
            {
                throw new NormalizationError("Must use ZAxisGroup with OutputFieldZAxis.");
            }
        }

        public override double Calculate(int subfield)
        {
            return (base.SourceField.CurrentValue * ((ZAxisGroup) base.Group).Multiplier);
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

