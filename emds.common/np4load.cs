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

using emds.common.Models;

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

        /// <summary>
        /// Возвращает набор данных, использовавщийся для обучения нейросети
        /// </summary>
        /// <param name="trainingData"></param>
        /// <param name="idealData"></param>
        public void GetTrainingDataArray(out double[][] trainingData, out double[][] idealData)
        {
            int size = int.Parse(xmlNeuroNet.Element("NetStruct")
                .Descendants("Layer")
                .First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Input").Attribute("Size")
                .Value);
            XElement dataSet = xmlNeuroNet.Element("DataSet");

            int sizeSet = dataSet.Nodes().Count();
            double[][] trainingSet = new double[sizeSet][];
            var dataXML = dataSet.Elements().ToArray();
            int sizeOutput = int.Parse(xmlNeuroNet.Element("NetStruct")
                .Descendants("Layer")
                .First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Output").Attribute("Size")
                .Value);
            double[][] idealSet = new double[sizeSet][];

            Parallel.For(0, sizeSet, i =>
            {
                double[] tSet = new double[size];
                var collection = dataXML[i].Elements("Array").First(x => x.Attribute("Name").Value == "Input").Elements();
                foreach (var item in collection)
                {
                    tSet[int.Parse(item.Attribute("Index").Value)] = double.Parse(item.Attribute("Value").Value.Replace('.', ','));
                }
                trainingSet[i] = tSet;
                collection = dataXML[i].Elements("Array").First(x => x.Attribute("Name").Value == "Ideal").Elements();
                double[] iSet = new double[sizeOutput];
                foreach (var item in collection)
                {
                    iSet[int.Parse(item.Attribute("Index").Value)] = double.Parse(item.Attribute("Value").Value);
                }
                idealSet[i] = iSet;
            });

            trainingData = trainingSet;
            idealData = idealSet;
        }

        public IMLDataSet GetTrainingData()
        {
            double[][] trainingSet;
            double[][] idealSet;
            GetTrainingDataArray(out trainingSet, out idealSet);

            return new BasicMLDataSet(trainingSet, idealSet);
        }

        /// <summary>
        /// Последовательное получение данных из xml
        /// </summary>
        /// <returns></returns>
        public IMLDataSet GetTrainingData2()
        {
            int size = int.Parse(xmlNeuroNet.Element("NetStruct")
                .Descendants("Layer")
                .First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Input").Attribute("Size")
                .Value);
            XElement dataSet = xmlNeuroNet.Element("DataSet");

            int sizeSet = dataSet.Nodes().Count();
            double[][] trainingSet = new double[sizeSet][];
            var dataXML = dataSet.Elements().ToArray();
            int sizeOutput = int.Parse(xmlNeuroNet.Element("NetStruct")
                .Descendants("Layer")
                .First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Output").Attribute("Size")
                .Value);
            double[][] idealSet = new double[sizeSet][];

            for(int i=0; i < sizeSet; i++)
            {
                double[] tSet = new double[size];
                var collection = dataXML[i].Elements("Array").First(x => x.Attribute("Name").Value == "Input").Elements();
                foreach (var item in collection)
                {
                    tSet[int.Parse(item.Attribute("Index").Value)] = double.Parse(item.Attribute("Value").Value.Replace('.', ','));
                }
                trainingSet[i] = tSet;
                collection = dataXML[i].Elements("Array").First(x => x.Attribute("Name").Value == "Ideal").Elements();
                double[] iSet = new double[sizeOutput];
                foreach (var item in collection)
                {
                    iSet[int.Parse(item.Attribute("Index").Value)] = double.Parse(item.Attribute("Value").Value);
                }
                idealSet[i] = iSet;
            }

            return new BasicMLDataSet(trainingSet, idealSet);
        }

        public IMLTrain GetTrainMetod()
        {
            XElement trainMetod = xmlNeuroNet.Element("TrainerConfig");
            switch (trainMetod.Attribute("Type").Value)
            {
                case "ResilientPropagation":
                    {
                        return new ResilientPropagation(GetNeuralNetwork(), GetTrainingData());
                    }
                default: return null;
            }
        }

        public DataProcessorConf GetDataProcessor()
        {
            return null;
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
