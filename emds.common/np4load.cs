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
    enum ActivationFunction
    {
        ActivationLinear,
        ActivationTANH
    }

    public class np4load
    {
        private XElement xmlNeuroNet;

        /// <summary>
        /// Загружает xml с нейросетью
        /// </summary>
        /// <param name="path">Перед передачей в конструктор должен быть проверен на существование файла</param>
        public np4load(string path)
        {
            xmlNeuroNet = XElement.Load(path);
        }

        public BasicNetwork GetNeuralNetwork()
        {
            BasicNetwork net = new BasicNetwork();
            var netStr = xmlNeuroNet.Element("NetStruct").Elements();
            var inputL = netStr.First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Input");

            net.AddLayer(
                new BasicLayer(
                    GetActivationFunction(inputL.Element("ActivationFunction").Attribute("Type").Value.Trim()),
                    false,
                    int.Parse(inputL.Attribute("Size").Value)));

            var outputL = netStr.First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Output");

            XElement hiddenL = netStr.First(x => x.Name == "HiddenLayers");
            foreach (var layer in hiddenL.Elements("Layer"))
            {
                net.AddLayer(new BasicLayer(
                    GetActivationFunction(layer.Element("ActivationFunction").Attribute("Type").Value.Trim()),
                    false,
                    int.Parse(layer.Attribute("Size").Value)));
            }

            net.AddLayer(
                new BasicLayer(
                    GetActivationFunction(outputL.Element("ActivationFunction").Attribute("Type").Value.Trim()),
                    false,
                    int.Parse(outputL.Attribute("Size").Value)));

            return net;
        }

        private IActivationFunction GetActivationFunction(string funName)
        {
            switch (funName)
            {
                case "ActivationLinear": return new ActivationLinear();
                case "ActivationTANH": return new ActivationTANH();
                default: return null;
            }
        }
    }
}
