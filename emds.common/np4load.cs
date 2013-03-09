using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.ML.Train;
using Encog.ML.Data.Basic;

namespace emds.common
{
    public class np4load
    {
        private XDocument xmlNeuroNet;

        /// <summary>
        /// Загружает xml с нейросетью
        /// </summary>
        /// <param name="path">Перед передачей в конструктор должен быть проверен на существование файла</param>
        public np4load(string path)
        {
            xmlNeuroNet = XDocument.Load(path);
        }

        public BasicNetwork GetNeuralNetwork()
        {
            BasicNetwork net = new BasicNetwork();
            xmlNeuroNet

            return net;
        }
    }
}
