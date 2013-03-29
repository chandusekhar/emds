using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using emds.common.Models;

using myNsim4 = emds.MyNsim4;
using Encog.ML.Data.Basic;
using Encog.ML.Data;

namespace emds.NsimMediator
{
    /// <summary>
    /// Посредник для предобработки данных
    /// </summary>
    public class MediatorNsimLinearScale
    {
        private myNsim4.LinearScale linearScale;
        private DataProcessorConf _confDP;

        public MediatorNsimLinearScale()
        {
            //neuralNet = NetworkCalculator.LoadFromFile(xmlFilePath);
            #region old
            //conf = confDP;
            //if (confDP.Type == "LinearScale")
            //{
            //    dp = new LinearScale();
            //    ((LinearScale)dp).A = confDP.A;
            //    ((LinearScale)dp).B = confDP.B;
            //    ((LinearScale)dp).IsUsed = confDP.IsUsed;

            //    //double[][] inC = new double[confDP.InCC.Length+confDP.OutCD.Length][];
            //    //double[][] idelaFalse = new double[inC.Length][];
            //    //for (int i = 0; i < confDP.InCC.Length; i++)
            //    //{
            //    //    double[] tmp = new double[2];
            //    //    tmp[0] = confDP.InCC[i];
            //    //    tmp[1] = confDP.InCD[i];
            //    //    inC[i] = tmp;
            //    //    idelaFalse[i] = tmp;

            //    //}
                                
            //    //for (int i = 0; i < confDP.OutCC.Length; i++)
            //    //{
            //    //    double[] tmp = new double[2];
            //    //    tmp[0] = confDP.OutCC[i];
            //    //    tmp[1] = confDP.OutCD[i];
            //    //    inC[confDP.InCC.Length+i] = tmp;
            //    //    idelaFalse[confDP.InCC.Length + i] = tmp;
            //    //}

            //    double[][] inC = new double[2][];
            //    double[][] idelaFalse = new double[2][];
            //    double[] tmpInC = new double[confDP.InCC.Length];
            //    double[] tmpIdealFalse = new double[confDP.InCC.Length];
            //    for (int i = 0; i < confDP.InCC.Length; i++)
            //    {
            //        tmpInC[i] = confDP.InCC[i];
            //        tmpIdealFalse[i] = confDP.InCD[i];
            //    }
            //    inC[0] = tmpInC;
            //    idelaFalse[0] = tmpIdealFalse;

            //    tmpInC = new double[confDP.OutCC.Length];
            //    tmpIdealFalse = new double[confDP.OutCD.Length];
            //    for (int i = 0; i < confDP.OutCC.Length; i++)
            //    {
            //        tmpInC[i] = confDP.OutCC[i];
            //        tmpIdealFalse[i] = confDP.OutCD[i];
            //    }

            //    inC[1] = tmpInC;
            //    idelaFalse[1] = tmpIdealFalse;
                
            //    BasicMLDataSet dataSet = new BasicMLDataSet(inC, idelaFalse);

            //    dp.ConfigureProcessor(dataSet);                
            //}
            #endregion
        }

        public void DataProcessorM(DataProcessorConf confDP)
        {
            _confDP = confDP;
            if (confDP.Type == "LinearScale")
            {
                linearScale = new myNsim4.LinearScale();
                linearScale.A = confDP.A;
                linearScale.B = confDP.B;
                linearScale.IsUsed = confDP.IsUsed;
                linearScale.InC = this.ConvertToScalerC(confDP.InCC, confDP.InCD);
                linearScale.OutC = this.ConvertToScalerC(confDP.OutCC, confDP.OutCD);
            }
        }

        private myNsim4.ScalerC[] ConvertToScalerC(double[] c, double[] d)
        {
            myNsim4.ScalerC[] res = new myNsim4.ScalerC[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                res[i].C = c[i];
                res[i].D = d[i];
            }
            return res;
        }

        #region Вызов методов исходного объекта

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            return linearScale.ProcessDataSet(dataToProcess);
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            return linearScale.ProcessDataVector(vectorToProcess);
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            return linearScale.ProcessIdealVector(row);
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            return linearScale.ProcessInputVector(row);
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToProcess)
        {
            return linearScale.RestoreDataSet(dataToProcess);
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            return linearScale.RestoreDataVector(vectorToProcess);
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            return linearScale.RestoreIdealVector(row);
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            return linearScale.RestoreInputVector(row);
        }

        #endregion
        //public void DataProcessorM2(double[][] trainData, double[][] idealData)
        //{
        //    var tmp = new BasicMLDataSet(trainData, idealData);
            
        //    dp.ConfigureProcessor(tmp);
        //}

    }
}
