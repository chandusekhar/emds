namespace Encog.Util.Normalize.Output.ZAxis
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Output;
    using System;

    [Serializable]
    public class OutputFieldZAxisSynthetic : OutputFieldGrouped
    {
        public OutputFieldZAxisSynthetic(IOutputFieldGroup group) : base(group, null)
        {
            while (!(group is ZAxisGroup))
            {
                throw new NormalizationError("Must use ZAxisGroup with OutputFieldZAxisSynthetic.");
            }
        }

        public override double Calculate(int subfield)
        {
            double num2;
            double num3;
            double num4;
            double length = ((ZAxisGroup) base.Group).Length;
            if ((((uint) num4) - ((uint) subfield)) >= 0)
            {
                goto Label_0095;
            }
        Label_0060:
            num4 = num2 * Math.Sqrt(num3 - (length * length));
            if (((uint) num4) > uint.MaxValue)
            {
                goto Label_00A6;
            }
            if (!double.IsInfinity(num4) || ((-2147483648 == 0) || (((uint) num2) < 0)))
            {
                if (!double.IsNaN(num4))
                {
                    return num4;
                }
                goto Label_00BA;
            }
            if (((uint) num4) >= 0)
            {
                goto Label_00BA;
            }
        Label_0095:
            num2 = ((ZAxisGroup) base.Group).Multiplier;
        Label_00A6:
            num3 = base.Group.GroupedFields.Count;
            goto Label_0060;
        Label_00BA:
            return 0.0;
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

