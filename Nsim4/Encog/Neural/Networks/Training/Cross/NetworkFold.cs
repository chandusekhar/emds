namespace Encog.Neural.Networks.Training.Cross
{
    using Encog.Neural.Flat;
    using Encog.Util;
    using System;

    public class NetworkFold
    {
        private readonly double[] _x2f33d779e5a20b28;
        private readonly double[] _x9c13656d94fc62d0;

        public NetworkFold(FlatNetwork flat)
        {
            this._x2f33d779e5a20b28 = EngineArray.ArrayCopy(flat.Weights);
            this._x9c13656d94fc62d0 = EngineArray.ArrayCopy(flat.LayerOutput);
        }

        public void CopyFromNetwork(FlatNetwork source)
        {
            EngineArray.ArrayCopy(source.Weights, this._x2f33d779e5a20b28);
            EngineArray.ArrayCopy(source.LayerOutput, this._x9c13656d94fc62d0);
        }

        public void CopyToNetwork(FlatNetwork target)
        {
            EngineArray.ArrayCopy(this._x2f33d779e5a20b28, target.Weights);
            EngineArray.ArrayCopy(this._x9c13656d94fc62d0, target.LayerOutput);
        }

        public double[] Output
        {
            get
            {
                return this._x9c13656d94fc62d0;
            }
        }

        public double[] Weights
        {
            get
            {
                return this._x2f33d779e5a20b28;
            }
        }
    }
}

