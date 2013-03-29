namespace Encog.ML.Data.Temporal
{
    using Encog.Engine.Network.Activation;
    using System;
    using System.Runtime.CompilerServices;

    public class TemporalDataDescription
    {
        private readonly Type _x43163d22e8cd5a71;
        private readonly IActivationFunction _xd4c451dfebf8f2a6;
        [CompilerGenerated]
        private int x2c232604070cc09d;
        [CompilerGenerated]
        private double x7ebd0c804c53b697;
        [CompilerGenerated]
        private double x7f6c9a54cf3b80d6;
        [CompilerGenerated]
        private bool xa5d7a5f9120fde2c;
        [CompilerGenerated]
        private bool xd21eb224755a30ef;

        public TemporalDataDescription(Type type, bool input, bool predict) : this(null, 0.0, 0.0, type, input, predict)
        {
        }

        public TemporalDataDescription(IActivationFunction activationFunction, Type type, bool input, bool predict) : this(activationFunction, 0.0, 0.0, type, input, predict)
        {
        }

        public TemporalDataDescription(IActivationFunction activationFunction, double low, double high, Type type, bool input, bool predict)
        {
            if ((((uint) input) - ((uint) input)) >= 0)
            {
                this.Low = low;
                if (0 != 0)
                {
                    goto Label_002D;
                }
            }
            this._x43163d22e8cd5a71 = type;
            this.High = high;
        Label_002D:
            this.IsInput = input;
            this.IsPredict = predict;
            this._xd4c451dfebf8f2a6 = activationFunction;
        }

        public IActivationFunction ActivationFunction
        {
            get
            {
                return this._xd4c451dfebf8f2a6;
            }
        }

        public Type DescriptionType
        {
            get
            {
                return this._x43163d22e8cd5a71;
            }
        }

        public double High
        {
            [CompilerGenerated]
            get
            {
                return this.x7ebd0c804c53b697;
            }
            [CompilerGenerated]
            set
            {
                this.x7ebd0c804c53b697 = value;
            }
        }

        public int Index
        {
            [CompilerGenerated]
            get
            {
                return this.x2c232604070cc09d;
            }
            [CompilerGenerated]
            set
            {
                this.x2c232604070cc09d = value;
            }
        }

        public bool IsInput
        {
            [CompilerGenerated]
            get
            {
                return this.xa5d7a5f9120fde2c;
            }
            [CompilerGenerated]
            set
            {
                this.xa5d7a5f9120fde2c = value;
            }
        }

        public bool IsPredict
        {
            [CompilerGenerated]
            get
            {
                return this.xd21eb224755a30ef;
            }
            [CompilerGenerated]
            set
            {
                this.xd21eb224755a30ef = value;
            }
        }

        public double Low
        {
            [CompilerGenerated]
            get
            {
                return this.x7f6c9a54cf3b80d6;
            }
            [CompilerGenerated]
            set
            {
                this.x7f6c9a54cf3b80d6 = value;
            }
        }

        public enum Type
        {
            Raw,
            PercentChange,
            DeltaChange
        }
    }
}

