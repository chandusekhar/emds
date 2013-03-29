namespace Encog.ML.SVM
{
    using Encog;
    using Encog.MathUtil.LIBSVM;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Util.Simple;
    using System;

    [Serializable]
    public class SupportVectorMachine : BasicML, IMLMethod, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLClassification, IMLError
    {
        private int _inputCount;
        private svm_model _model;
        private readonly svm_parameter _paras;
        public const int DefaultC = 1;
        public const int DefaultCacheSize = 100;
        public const int DefaultCoef0 = 0;
        public const int DefaultDegree = 3;
        public const double DefaultEps = 0.001;
        public const double DefaultNu = 0.5;
        public const double DefaultP = 0.1;

        public SupportVectorMachine()
        {
            this._paras = new svm_parameter();
        }

        public SupportVectorMachine(svm_model theModel)
        {
            svm_node[][] sV;
            int num;
            svm_node[] _nodeArray3;
            int num2;
            this._model = theModel;
            this._paras = this._model.param;
            if (8 != 0)
            {
                goto Label_00A8;
            }
            return;
        Label_002C:
            if (num < sV.Length)
            {
                _nodeArray3 = sV[num];
                num2 = 0;
            }
            else
            {
                if ((0 == 0) && ((((uint) num2) + ((uint) num2)) > uint.MaxValue))
                {
                    goto Label_002C;
                }
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                    return;
                }
                goto Label_00A8;
            }
        Label_005F:
            while (num2 < _nodeArray3.Length)
            {
                svm_node _node = _nodeArray3[num2];
                this._inputCount = Math.Max(_node.index, this._inputCount);
                num2++;
            }
            num++;
            goto Label_002C;
        Label_00A8:
            this._inputCount = 0;
            sV = this._model.SV;
            num = 0;
            if (((uint) num2) < 0)
            {
                goto Label_005F;
            }
            goto Label_002C;
        }

        public SupportVectorMachine(int theInputCount, bool regression) : this(theInputCount, regression ? Encog.ML.SVM.SVMType.EpsilonSupportVectorRegression : Encog.ML.SVM.SVMType.SupportVectorClassification, Encog.ML.SVM.KernelType.RadialBasisFunction)
        {
        }

        public SupportVectorMachine(int theInputCount, Encog.ML.SVM.SVMType svmType, Encog.ML.SVM.KernelType kernelType)
        {
            goto Label_02B7;
        Label_000B:
            this._paras.nr_weight = 0;
        Label_0017:
            this._paras.weight_label = new int[0];
            this._paras.weight = new double[0];
            this._paras.gamma = 1.0 / ((double) this._inputCount);
            goto Label_00C6;
        Label_0057:
            this._paras.C = 1.0;
            this._paras.eps = 0.001;
            this._paras.p = 0.1;
            this._paras.shrinking = 1;
            this._paras.probability = 0;
            if ((((uint) theInputCount) + ((uint) theInputCount)) >= 0)
            {
                goto Label_000B;
            }
        Label_00C6:
            if (0 == 0)
            {
                return;
            }
            goto Label_02B7;
        Label_00D1:
            this._paras.degree = 3.0;
            this._paras.coef0 = 0.0;
            this._paras.nu = 0.5;
            if (0 != 0)
            {
                goto Label_0256;
            }
            this._paras.cache_size = 100.0;
            if (0 == 0)
            {
                goto Label_0057;
            }
            goto Label_019C;
        Label_0134:
            this._paras.kernel_type = 3;
            goto Label_00D1;
        Label_0167:
            this._paras.kernel_type = 0;
            goto Label_00D1;
        Label_019C:
            switch (kernelType)
            {
                case Encog.ML.SVM.KernelType.Linear:
                    goto Label_0167;

                case Encog.ML.SVM.KernelType.Poly:
                    this._paras.kernel_type = 1;
                    goto Label_00D1;

                case Encog.ML.SVM.KernelType.RadialBasisFunction:
                    this._paras.kernel_type = 2;
                    goto Label_00D1;

                case Encog.ML.SVM.KernelType.Sigmoid:
                    goto Label_0134;

                default:
                    throw new NeuralNetworkError("Invalid kernel type");
            }
        Label_01CD:
            throw new NeuralNetworkError("Invalid svm type");
            if ((((uint) theInputCount) - ((uint) theInputCount)) < 0)
            {
                goto Label_0134;
            }
            if (8 != 0)
            {
                goto Label_019C;
            }
            if ((((uint) theInputCount) + ((uint) theInputCount)) < 0)
            {
                goto Label_01CD;
            }
            goto Label_0167;
            if (0 == 0)
            {
                goto Label_00D1;
            }
            goto Label_0057;
        Label_0256:
            this._paras.svm_type = 2;
            goto Label_019C;
        Label_02B7:
            this._inputCount = theInputCount;
            this._paras = new svm_parameter();
            if ((((uint) theInputCount) - ((uint) theInputCount)) > uint.MaxValue)
            {
                goto Label_00D1;
            }
            switch (svmType)
            {
                case Encog.ML.SVM.SVMType.SupportVectorClassification:
                    this._paras.svm_type = 0;
                    if (0 != 0)
                    {
                        goto Label_0017;
                    }
                    goto Label_019C;

                case Encog.ML.SVM.SVMType.NewSupportVectorClassification:
                    this._paras.svm_type = 1;
                    if ((((uint) theInputCount) | uint.MaxValue) == 0)
                    {
                        goto Label_000B;
                    }
                    goto Label_019C;

                case Encog.ML.SVM.SVMType.SupportVectorOneClass:
                    goto Label_0256;

                case Encog.ML.SVM.SVMType.EpsilonSupportVectorRegression:
                    this._paras.svm_type = 3;
                    if ((((uint) theInputCount) + ((uint) theInputCount)) <= uint.MaxValue)
                    {
                        goto Label_019C;
                    }
                    goto Label_02B7;

                case Encog.ML.SVM.SVMType.NewSupportVectorRegression:
                    this._paras.svm_type = 4;
                    if (((uint) theInputCount) > uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_019C;

                default:
                    goto Label_01CD;
            }
        }

        public double CalculateError(IMLDataSet data)
        {
            switch (this.SVMType)
            {
                case Encog.ML.SVM.SVMType.SupportVectorClassification:
                case Encog.ML.SVM.SVMType.NewSupportVectorClassification:
                case Encog.ML.SVM.SVMType.SupportVectorOneClass:
                    return EncogUtility.CalculateClassificationError(this, data);

                case Encog.ML.SVM.SVMType.EpsilonSupportVectorRegression:
                case Encog.ML.SVM.SVMType.NewSupportVectorRegression:
                    return EncogUtility.CalculateRegressionError(this, data);
            }
            return EncogUtility.CalculateRegressionError(this, data);
        }

        public int Classify(IMLData input)
        {
            if (this._model == null)
            {
                throw new EncogError("Can't use the SVM yet, it has not been trained, and no model exists.");
            }
            svm_node[] x = this.MakeSparse(input);
            return (int) svm.svm_predict(this._model, x);
        }

        public IMLData Compute(IMLData input)
        {
            if (this._model == null)
            {
                throw new EncogError("Can't use the SVM yet, it has not been trained, and no model exists.");
            }
            IMLData data = new BasicMLData(1);
            svm_node[] x = this.MakeSparse(input);
            double num = svm.svm_predict(this._model, x);
            if (0xff != 0)
            {
                data[0] = num;
            }
            return data;
        }

        public svm_node[] MakeSparse(IMLData data)
        {
            svm_node[] _nodeArray = new svm_node[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                _nodeArray[i] = new svm_node { index = i + 1, value_Renamed = data[i] };
                if (0 == 0)
                {
                }
            }
            return _nodeArray;
        }

        public override void UpdateProperties()
        {
        }

        public int InputCount
        {
            get
            {
                return this._inputCount;
            }
            set
            {
                this._inputCount = value;
            }
        }

        public Encog.ML.SVM.KernelType KernelType
        {
            get
            {
                switch (this._paras.kernel_type)
                {
                    case 0:
                        return Encog.ML.SVM.KernelType.Linear;

                    case 1:
                        return Encog.ML.SVM.KernelType.Poly;

                    case 2:
                        return Encog.ML.SVM.KernelType.RadialBasisFunction;

                    case 3:
                        return Encog.ML.SVM.KernelType.Sigmoid;
                }
                return Encog.ML.SVM.KernelType.Linear;
            }
        }

        public svm_model Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
            }
        }

        public int OutputCount
        {
            get
            {
                return 1;
            }
        }

        public svm_parameter Params
        {
            get
            {
                return this._paras;
            }
        }

        public Encog.ML.SVM.SVMType SVMType
        {
            get
            {
                int num = this._paras.svm_type;
                if ((-2 != 0) && (0 == 0))
                {
                    switch (num)
                    {
                        case 0:
                            return Encog.ML.SVM.SVMType.SupportVectorClassification;

                        case 1:
                            return Encog.ML.SVM.SVMType.NewSupportVectorClassification;

                        case 2:
                            return Encog.ML.SVM.SVMType.SupportVectorOneClass;

                        case 3:
                            return Encog.ML.SVM.SVMType.EpsilonSupportVectorRegression;

                        case 4:
                            return Encog.ML.SVM.SVMType.NewSupportVectorRegression;
                    }
                    if ((((uint) num) + ((uint) num)) >= 0)
                    {
                    }
                }
                return Encog.ML.SVM.SVMType.SupportVectorClassification;
            }
        }
    }
}

