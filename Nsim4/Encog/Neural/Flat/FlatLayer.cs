namespace Encog.Neural.Flat
{
    using Encog.Engine.Network.Activation;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class FlatLayer
    {
        private readonly int _x10f4d88af727adbc;
        private double _x25922738b86264c8;
        private FlatLayer _x4d51c0aa16352a14;
        [CompilerGenerated]
        private IActivationFunction x123d4fbf6a3d6ce6;

        public FlatLayer(IActivationFunction activation, int count, double biasActivation)
        {
            this.Activation = activation;
            this._x10f4d88af727adbc = count;
            this._x25922738b86264c8 = biasActivation;
            this._x4d51c0aa16352a14 = null;
        }

        public bool HasBias()
        {
            return (Math.Abs(this._x25922738b86264c8) > 1E-07);
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            goto Label_0090;
        Label_001F:
            builder.Append("]");
            return builder.ToString();
        Label_0038:
            if (0 != 0)
            {
                goto Label_0090;
            }
            if (this._x4d51c0aa16352a14 == this)
            {
                builder.Append("itself");
                goto Label_001F;
            }
            builder.Append(this._x4d51c0aa16352a14);
            if (-2147483648 != 0)
            {
                goto Label_001F;
            }
        Label_005E:
            if (this._x4d51c0aa16352a14 == null)
            {
                goto Label_001F;
            }
            builder.Append(",contextFed=");
            goto Label_0038;
        Label_0090:
            builder.Append("[");
            builder.Append(base.GetType().Name);
            builder.Append(": count=");
            builder.Append(this._x10f4d88af727adbc);
            builder.Append(",bias=");
            if (this.HasBias())
            {
                builder.Append(this._x25922738b86264c8);
                goto Label_005E;
            }
            if (0 == 0)
            {
                builder.Append("false");
                goto Label_005E;
            }
            goto Label_0038;
        }

        public IActivationFunction Activation
        {
            [CompilerGenerated]
            get
            {
                return this.x123d4fbf6a3d6ce6;
            }
            [CompilerGenerated]
            set
            {
                this.x123d4fbf6a3d6ce6 = value;
            }
        }

        public double BiasActivation
        {
            get
            {
                if (this.HasBias())
                {
                    return this._x25922738b86264c8;
                }
                return 0.0;
            }
            set
            {
                this._x25922738b86264c8 = value;
            }
        }

        public int ContextCount
        {
            get
            {
                if (this._x4d51c0aa16352a14 == null)
                {
                    return 0;
                }
                return this._x4d51c0aa16352a14.Count;
            }
        }

        public FlatLayer ContextFedBy
        {
            get
            {
                return this._x4d51c0aa16352a14;
            }
            set
            {
                this._x4d51c0aa16352a14 = value;
            }
        }

        public int Count
        {
            get
            {
                return this._x10f4d88af727adbc;
            }
        }

        public int TotalCount
        {
            get
            {
                if (this._x4d51c0aa16352a14 == null)
                {
                    return (this.Count + (this.HasBias() ? 1 : 0));
                }
                return ((this.Count + (this.HasBias() ? 1 : 0)) + this._x4d51c0aa16352a14.Count);
            }
        }
    }
}

