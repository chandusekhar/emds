namespace Encog.Neural.Prune
{
    using System;

    public class HiddenLayerParams
    {
        private readonly int _xd088075e67f6ea91;
        private readonly int _xffd6352b2e5d70e3;

        public HiddenLayerParams(int min, int max)
        {
            this._xd088075e67f6ea91 = min;
            this._xffd6352b2e5d70e3 = max;
        }

        public int Max
        {
            get
            {
                return this._xffd6352b2e5d70e3;
            }
        }

        public int Min
        {
            get
            {
                return this._xd088075e67f6ea91;
            }
        }
    }
}

