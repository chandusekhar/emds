namespace Encog.Neural.NEAT
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Serializable]
    public class NEATNeuron
    {
        private readonly double _activationResponse;
        private readonly IList<NEATLink> _inboundLinks;
        private readonly long _neuronID;
        private readonly NEATNeuronType _neuronType;
        private double _output;
        private readonly IList<NEATLink> _outputboundLinks;
        private readonly int _posX;
        private readonly int _posY;
        private readonly double _splitX;
        private readonly double _splitY;
        private readonly double _sumActivation;

        public NEATNeuron()
        {
            this._inboundLinks = new List<NEATLink>();
            this._outputboundLinks = new List<NEATLink>();
        }

        public NEATNeuron(NEATNeuronType neuronType_0, long neuronID_1, double splitY_2, double splitX_3, double activationResponse_4)
        {
            this._inboundLinks = new List<NEATLink>();
            this._outputboundLinks = new List<NEATLink>();
            this._neuronType = neuronType_0;
            if ((((uint) neuronID_1) + ((uint) neuronID_1)) >= 0)
            {
                while (true)
                {
                    this._neuronID = neuronID_1;
                    this._splitY = splitY_2;
                    this._splitX = splitX_3;
                    this._activationResponse = activationResponse_4;
                    this._posX = 0;
                    if (((uint) splitX_3) <= uint.MaxValue)
                    {
                        this._posY = 0;
                        if ((((uint) splitY_2) - ((uint) splitY_2)) <= uint.MaxValue)
                        {
                            break;
                        }
                    }
                }
            }
            if (0 == 0)
            {
                this._output = 0.0;
                this._sumActivation = 0.0;
                if ((((uint) neuronID_1) + ((uint) activationResponse_4)) <= uint.MaxValue)
                {
                }
            }
        }

        public static string NeuronType2String(NEATNeuronType t)
        {
            switch (t)
            {
                case NEATNeuronType.Bias:
                    return "B";

                case NEATNeuronType.Hidden:
                    return "H";

                case NEATNeuronType.Input:
                    return "I";

                case NEATNeuronType.None:
                    return "N";

                case NEATNeuronType.Output:
                    return "O";
            }
            return null;
        }

        public static NEATNeuronType String2NeuronType(string t)
        {
            int num;
            string str = t.ToLower().Trim();
            while (true)
            {
                if (str.Length > 0)
                {
                    num = str[0];
                    if ((-1 != 0) && (num == 0x62))
                    {
                        return NEATNeuronType.Bias;
                    }
                    break;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_0071;
                }
            }
            switch (num)
            {
                case 0x68:
                    return NEATNeuronType.Hidden;

                case 0x69:
                    return NEATNeuronType.Input;

                default:
                    switch (num)
                    {
                        case 110:
                            return NEATNeuronType.None;

                        case 0x6f:
                            return NEATNeuronType.Output;
                    }
                    break;
            }
        Label_0071:
            return NEATNeuronType.Bias;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[NEATNeuron:id=");
        Label_006A:
            builder.Append(this._neuronID);
            builder.Append(",type=");
            do
            {
                switch (this._neuronType)
                {
                    case NEATNeuronType.Bias:
                        builder.Append("B");
                        goto Label_0025;

                    case NEATNeuronType.Hidden:
                        builder.Append("H");
                        goto Label_0025;

                    case NEATNeuronType.Input:
                        builder.Append("I");
                        if (0 == 0)
                        {
                            goto Label_0025;
                        }
                        goto Label_006A;

                    case NEATNeuronType.None:
                        goto Label_0019;

                    case NEATNeuronType.Output:
                        builder.Append("O");
                        goto Label_0025;
                }
            }
            while (0 != 0);
        Label_0019:
            builder.Append("Unknown");
        Label_0025:
            builder.Append("]");
            return builder.ToString();
        }

        public double ActivationResponse
        {
            get
            {
                return this._activationResponse;
            }
        }

        public IList<NEATLink> InboundLinks
        {
            get
            {
                return this._inboundLinks;
            }
        }

        public long NeuronID
        {
            get
            {
                return this._neuronID;
            }
        }

        public NEATNeuronType NeuronType
        {
            get
            {
                return this._neuronType;
            }
        }

        public double Output
        {
            get
            {
                return this._output;
            }
            set
            {
                this._output = value;
            }
        }

        public IList<NEATLink> OutputboundLinks
        {
            get
            {
                return this._outputboundLinks;
            }
        }

        public int PosX
        {
            get
            {
                return this._posX;
            }
        }

        public int PosY
        {
            get
            {
                return this._posY;
            }
        }

        public double SplitX
        {
            get
            {
                return this._splitX;
            }
        }

        public double SplitY
        {
            get
            {
                return this._splitY;
            }
        }

        public double SumActivation
        {
            get
            {
                return this._sumActivation;
            }
        }
    }
}

