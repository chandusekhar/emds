namespace Encog.ML.SVM.Training
{
    using Encog;
    using Encog.MathUtil.LIBSVM;
    using Encog.ML.Data;
    using System;
    using System.Collections.Generic;

    public static class EncodeSVMProblem
    {
        public static svm_problem Encode(IMLDataSet training, int outputIndex)
        {
            svm_problem _problem3;
            try
            {
                svm_problem _problem;
                int num;
                int num2;
                svm_problem _problem2 = new svm_problem();
                goto Label_0158;
            Label_000C:
                if (1 == 0)
                {
                    return _problem3;
                }
                if ((((uint) num2) + ((uint) num2)) < 0)
                {
                    goto Label_018B;
                }
            Label_0031:
                if (num >= _problem.l)
                {
                    num2 = 0;
                    using (IEnumerator<IMLDataPair> enumerator = training.GetEnumerator())
                    {
                        IMLDataPair pair;
                        IMLData input;
                        IMLData data2;
                        int num3;
                        svm_node _node;
                        goto Label_0083;
                    Label_0049:
                        num3++;
                    Label_004F:
                        if (num3 < input.Count)
                        {
                            goto Label_00CA;
                        }
                        _problem.y[num2] = data2[outputIndex];
                        if (((uint) outputIndex) < 0)
                        {
                            return _problem;
                        }
                        num2++;
                    Label_0083:
                        if (enumerator.MoveNext())
                        {
                            goto Label_0100;
                        }
                        return _problem;
                    Label_008E:
                        data2 = pair.Ideal;
                        if ((((uint) num3) + ((uint) num2)) >= 0)
                        {
                            _problem.x[num2] = new svm_node[input.Count];
                            num3 = 0;
                            goto Label_004F;
                        }
                    Label_00CA:
                        _node = new svm_node();
                        _node.index = num3 + 1;
                        _node.value_Renamed = input[num3];
                        _problem.x[num2][num3] = _node;
                        goto Label_0049;
                    Label_0100:
                        pair = enumerator.Current;
                        input = pair.Input;
                        goto Label_008E;
                    }
                }
                _problem.x[num] = new svm_node[training.InputSize];
                num++;
                if ((((uint) outputIndex) & 0) == 0)
                {
                    goto Label_000C;
                }
                return _problem3;
            Label_0158:
                _problem2.l = (int) training.Count;
                _problem = _problem2;
                _problem.y = new double[_problem.l];
                _problem.x = new svm_node[_problem.l][];
            Label_018B:
                num = 0;
                goto Label_0031;
            }
            catch (OutOfMemoryException)
            {
                throw new EncogError("SVM Model - Out of Memory");
            }
            return _problem3;
        }
    }
}

