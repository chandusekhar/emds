using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

using MongoDB.Driver;

using MDS.FillForm.DomainModel.Database;
using MDS.FillForm.DomainModel.Entities;
using MDS.FillForm.DomainModel.Concret;

using Encog.Neural.Networks;
using Encog.ML.Data;
using Encog.ML.Data.Basic;

using emds.common;
using emds.common.Models;
using emds.NsimMediator;
using Encog.ML.Train;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using emds.TrainLoggers;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;

namespace emds.utility
{
    class Program
    {
        public static void TestSpeedGetData()
        {
            var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");

            Console.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var data1 = tmp.GetTrainingDataNotParallel();
            stopwatch.Stop();
            Console.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);

            // Reset timer and results matrix. 
            stopwatch.Reset();

            // Do the parallel loop.
            Console.WriteLine("Executing parallel loop...");
            stopwatch.Start();
            var data2 = tmp.GetTrainingData();
            stopwatch.Stop();
            Console.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void GetAllWeidtg()
        {
            var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            var neuralNet = tmp.GetNeuralNetwork();
            var w = tmp.GetWeigth();
            neuralNet.DecodeFromArray(w);

        }

        public static void Experiment()
        {
            BasicNetwork net = new BasicNetwork();

            net.AddLayer(
                new BasicLayer(new ActivationLinear(), false, 3));

            net.AddLayer(
                new BasicLayer(new ActivationTANH(), true, 3));

            net.AddLayer(
                new BasicLayer(new ActivationLinear(), false, 2));

            net.Structure.FinalizeStructure();
            //Задание случайных весов?
            net.Reset();

        }

        /// <summary>
        /// Из MDSDB извлекаются формы с templateID и хэшируются, GID и хэш помещаются в MondoDB
        /// </summary>
        /// <param name="templateID"></param>
        /// <param name="sizeData"></param>
        /// <param name="collectionName"></param>
        /// <param name="dbName"></param>
        /// <param name="hostIP"></param>
        public static void TranslateDataInHash(int templateID, int sizeData = 67, string collectionName = "HashForm", string dbName = "emdsdb", string hostIP = "localhost")
        {
            MongoServer server;
            MongoDatabase database;
            MongoCollection collection;
            string connectionString = String.Format("mongodb://{0}/?safe=true", hostIP);
            try
            {
                server = (new MongoClient(connectionString)).GetServer();
                database = server.GetDatabase(dbName);
                collection = database.GetCollection<FormHash>(collectionName);
                server.Ping();
            }
            catch
            {
                throw new Exception("Проблема подключением к монге");
            }

            Console.WriteLine("Получешине хешей...");

            using (FileLogger log = FileLogger.GetLogger())
            using (var db = MDSDB.GetInstance())
            {
                Parallel.ForEach(db.Forms.Where(x => x.FormTemplateId == templateID), form =>
                //foreach(var form in db.Forms.Where(x => x.FormTemplateId == templateID && x.Data != null))
                {
                    if (form.Data != null)
                    {
                        double[] arrData = XMLDataToDoubleArray(form.Data, sizeData);
                        if (arrData != null)
                        {
                            FormHash fh = new FormHash()
                            {
                                GID = (Guid)form.GID,
                                Hash = SearchHashForm.GetHashForm(arrData),
                                Data = arrData
                            };
                            collection.Insert<FormHash>(fh);
                        }
                        else
                        {
                            log.WriteString(form.GID.ToString());
                        }
                    }
                });
            }
            server.Disconnect();
            Console.Write("Закончено");
        }

        public static double[] XMLDataToDoubleArray(XElement xml, int sizeData)
        {
            double[] res = new double[sizeData];
            var arrXNode = xml.Elements();
            string tmp;
            int ind;
            foreach(var item in arrXNode)
            //for (int i = 0; i < sizeData; i++)
            {
                ind = int.Parse(item.Attribute("FieldId").Value);
                if (ind <= sizeData)
                {
                    if (item.Attribute("Value") != null)
                    {
                        tmp = item.Attribute("Value").Value;
                        if (tmp == "null" || String.IsNullOrEmpty(tmp))
                        {
                            return null;
                        }
                        else
                        {
                            res[ind - 1] = double.Parse(tmp); //.Replace(',', '.')
                        }
                    }
                    else
                        return null;
                }

            }
            return res;
        }

        public static void TrainNet()
        {
            var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            
            TrainLogger tLog = TrainLogger.GetTrainLogger();
            
            Dictionary<string, object> dLog = new Dictionary<string, object>();
            
            var stopParam = tmp.GetTrainingStopParams();
            int iterCount = 2500;//13943;

            dLog.Add("event", "init");
            dLog.Add("NeuralNetName", "инфаркт_миокарда.np4");
            dLog.Add("Path", @"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            dLog.Add("Анкета", "Кардиология");
            dLog.Add("IterationCount", iterCount);
            dLog.Add("Time", DateTime.Now);
            
            BasicMLDataSet tData = (BasicMLDataSet) tmp.GetTrainingData();
            dLog.Add("TrainDataSize", tData.Count);
            //записать входные данные и проскалированные
            tLog.WriteEvent(dLog);

            BasicNetwork neuralNet = tmp.GetNeuralNetwork();

            MediatorNsimLinearScale scale = new MediatorNsimLinearScale();
            DataProcessorConf dp = tmp.GetDataProcessor();
            scale.DataProcessorM(dp);

            //SearchHashForm search = new SearchHashForm();
            //Guid[] gidForm = search.GetGIDForm(tData);

            BasicMLDataSet tDataScale = scale.ProcessDataSet(tData);

            IMLTrain trainMetod;
            switch (tmp.GetNameTrainMetod())
            {
                case "ResilientPropagation":
                    {
                        trainMetod = new ResilientPropagation(neuralNet, tDataScale); 
                        break;
                    }
                default:
                    {
                        trainMetod = new ResilientPropagation(neuralNet, tDataScale);
                        break;
                    }
            }

            //trainMetod.Iteration(stopParam.Iterations);

            trainMetod.Iteration(iterCount);
            //var arrWeight = neuralNet.DumpWeights().Split(',');

            //using (FileLogger fl = FileLogger.GetLogger())
            //{
            //    fl.WriteString(neuralNet.DumpWeights());
            //    for (int i = 0; i < tDataScale.Data.Count; i++)//var item in tDataScale.Data)
            //    {
            //        fl.WriteString("Входной вектор: " + GetString(tData.Data[i].InputArray));

            //        var res = neuralNet.Compute(tDataScale.Data[i].Input);

            //        fl.WriteString("Результат: " + GetString(res.Data));

            //        var sRes = scale.RestoreIdealVector(res);

            //        fl.WriteString("Результат востановленный: " + GetString(sRes.Data));
            //        fl.WriteString("\n");
            //    }
            //}
                        
            trainMetod.FinishTraining();
            //int countW = neuralNet.EncodedArrayLength();
            //double[] w = new double[countW];
            //neuralNet.EncodeToArray(w);

            Console.WriteLine("!!!");
            //for (int i = 0; i < stopParam.Iterations; i++)
            //{
            //    trainMetod.Iteration(
            //}

        }

        public static string GetString(double[] mas)
        {
            StringBuilder sb = new StringBuilder(mas.Length);

            for (int i = 0; i < mas.Length; i++)
                sb.Append(String.Format("{0} ", mas[i]));
            
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            //Experiment();
            //var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            TrainNet();
            //TranslateDataInHash(4, 67);

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
