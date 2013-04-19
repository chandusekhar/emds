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
                    true,
                    int.Parse(inputL.Attribute("Size").Value)));
            
            XElement hiddenL = netStr.First(x => x.Name == "HiddenLayers");
            foreach (var layer in hiddenL.Elements("Layer"))
            {
                net.AddLayer(new BasicLayer(
                    GetActivationFunction(layer.Element("ActivationFunction").Attribute("Type").Value.Trim()),
                    true,
                    int.Parse(layer.Attribute("Size").Value)));
            }

            var outputL = netStr.First(x => x.Attribute("Name") != null && x.Attribute("Name").Value == "Output");
            net.AddLayer(
                new BasicLayer(
                    GetActivationFunction(outputL.Element("ActivationFunction").Attribute("Type").Value.Trim()),
                    true,
                    int.Parse(outputL.Attribute("Size").Value)));

            net.Structure.FinalizeStructure();
            //Задание случайных весов?
            net.Reset();

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

        /// <summary>
        /// Данные для обучения. Обрабатываются с применнеием TPL
        /// </summary>
        /// <returns></returns>
        public IMLDataSet GetTrainingData()
        {
            double[][] trainingSet;
            double[][] idealSet;
            GetTrainingDataArray(out trainingSet, out idealSet);

            return new BasicMLDataSet(trainingSet, idealSet);
        }

        /// <summary>
        /// Последовательное получение данных из xml без TPL
        /// </summary>
        /// <returns></returns>
        public IMLDataSet GetTrainingDataNotParallel()
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

        public string GetNameTrainMetod()
        {
            XElement trainMetod = xmlNeuroNet.Element("TrainerConfig");
            return trainMetod.Attribute("Type").Value;
        }

        public IMLTrain GetTrainMetod(out BasicNetwork net, out IMLDataSet data)
        {
            XElement trainMetod = xmlNeuroNet.Element("TrainerConfig");
            switch (trainMetod.Attribute("Type").Value)
            {
                case "ResilientPropagation":
                    {
                        net = GetNeuralNetwork();
                        data = GetTrainingData();
                        return new ResilientPropagation(net, data);
                    }
                default:
                    {
                        net = null;
                        data = null;
                        return null;
                    }
            }
        }

        public DataProcessorConf GetDataProcessor()
        {
            XElement dataProcessor = xmlNeuroNet.Element("DataProcessor")
                .Elements().Skip(1).First();
            DataProcessorConf res = new DataProcessorConf()
            {
                IsUsed = bool.Parse(dataProcessor.Attribute("IsUsed").Value),
                A = int.Parse(dataProcessor.Attribute("A").Value),
                B = int.Parse(dataProcessor.Attribute("B").Value),
                Type = dataProcessor.Attribute("Type").Value
            };
            var inArr = dataProcessor.Elements("InC").ToArray();
            int sizeIn = inArr.Count();
            res.InCC = new double[sizeIn];
            res.InCD = new double[sizeIn];
            
            //System.Globalization.NumberFormatInfo.

            for (int i = 0; i < sizeIn; i++)
            {
                res.InCC[i] = double.Parse(inArr[i].Attribute("C").Value.Replace('.', ','));
                res.InCD[i] = double.Parse(inArr[i].Attribute("D").Value.Replace('.', ','));
            }

            var outArr = dataProcessor.Elements("OutC").ToArray();
            int sizeOut = outArr.Count();
            res.OutCC = new double[sizeOut];
            res.OutCD = new double[sizeOut];

            for (int i = 0; i < sizeOut; i++)
            {
                res.OutCC[i] = double.Parse(outArr[i].Attribute("C").Value.Replace('.', ','));
                res.OutCD[i] = double.Parse(outArr[i].Attribute("D").Value.Replace('.', ','));
            }

            return res;
        }

        public TrainingStopParams GetTrainingStopParams()
        {
            XElement tsp = xmlNeuroNet.Element("TrainingStopParams");
            TrainingStopParams res = TrainingStopParams.GetTraningStopParams(tsp);
            return res;
        }

        public double[] GetWeigth()
        {
            XElement arrW = xmlNeuroNet.Element("TrainStatus").Element("Array");
            var elements = arrW.Elements("Data");
            double[] res = new double[elements.Count()];

            foreach (var item in elements)
            {
                res[int.Parse(item.Attribute("Index").Value)] = double.Parse(item.Attribute("Value").Value);
            }

            return res;
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
