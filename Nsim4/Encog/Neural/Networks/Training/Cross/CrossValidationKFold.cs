namespace Encog.Neural.Networks.Training.Cross
{
    using Encog.ML.Train;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation;
    using System;

    public class CrossValidationKFold : CrossTraining
    {
        private readonly NetworkFold[] _x5f6ed0047d99f4b6;
        private readonly IMLTrain _xd87f6a9c53c2ed9f;
        private readonly FlatNetwork _xef94864849922d07;

        public CrossValidationKFold(IMLTrain train, int k) : base(train.Method, (FoldedDataSet) train.Training)
        {
            int num;
            if ((((uint) k) | 1) != 0)
            {
                this._xd87f6a9c53c2ed9f = train;
                base.Folded.Fold(k);
                goto Label_0083;
            }
            if (0xff != 0)
            {
                goto Label_0083;
            }
        Label_0039:
            num = 0;
            while (num < this._x5f6ed0047d99f4b6.Length)
            {
                this._x5f6ed0047d99f4b6[num] = new NetworkFold(this._xef94864849922d07);
                if (((uint) k) >= 0)
                {
                }
                num++;
            }
            if (((uint) num) <= uint.MaxValue)
            {
                return;
            }
        Label_0083:
            this._xef94864849922d07 = ((BasicNetwork) train.Method).Structure.Flat;
            this._x5f6ed0047d99f4b6 = new NetworkFold[k];
            if (8 == 0)
            {
                return;
            }
            goto Label_0039;
        }

        public override void Iteration()
        {
            int num3;
            double num4;
            double num = 0.0;
            int index = 0;
        Label_005E:
            if (index < base.Folded.NumFolds)
            {
                this._x5f6ed0047d99f4b6[index].CopyToNetwork(this._xef94864849922d07);
                num3 = 0;
                goto Label_0091;
            }
            this.Error = num / ((double) base.Folded.NumFolds);
            if ((((uint) num3) - ((uint) index)) >= 0)
            {
                return;
            }
        Label_0089:
            if (num3 != index)
            {
                base.Folded.CurrentFold = num3;
                this._xd87f6a9c53c2ed9f.Iteration();
            }
            num3++;
        Label_0091:
            if (num3 < base.Folded.NumFolds)
            {
                goto Label_0089;
            }
            if ((((uint) num4) + ((uint) num3)) < 0)
            {
                return;
            }
            base.Folded.CurrentFold = index;
            num4 = this._xef94864849922d07.CalculateError(base.Folded);
            num += num4;
            this._x5f6ed0047d99f4b6[index].CopyFromNetwork(this._xef94864849922d07);
            index++;
            goto Label_005E;
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }
    }
}

