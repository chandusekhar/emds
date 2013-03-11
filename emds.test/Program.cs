using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using emds.common;
using emds.common.Models;

using System.Diagnostics;
using MongoDB.Driver;
using MDS.FillForm.DomainModel.Database;
using MDS.FillForm.DomainModel.Entities;
using MDS.FillForm.DomainModel.Concret;

namespace emds.utility
{
    class Program
    {
        public static void TestSpeedGetData()
        {
            var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            //tmp.GetNeuralNetwork();
            //tmp.GetTrainingData();

            Console.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var data1 = tmp.GetTrainingData2();
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

        /// <summary>
        /// Из MDSDB извлекаются формы с templateID и хэшируются, GID и хэш помещаются в MondoDB
        /// </summary>
        /// <param name="templateID"></param>
        /// <param name="sizeData"></param>
        /// <param name="collectionName"></param>
        /// <param name="dbName"></param>
        /// <param name="hostIP"></param>
        public static void TranslateDataInHash(int templateID, int sizeData, string collectionName = "HashForm", string dbName = "emdsdb", string hostIP = "localhost")
        {
            MongoServer server;
            MongoDatabase database;
            MongoCollection collection;
            string connectionString = String.Format("mongodb://{0}/?safe=true", hostIP);
            try
            {
                server = MongoServer.Create(connectionString);
                database = server.GetDatabase(dbName);
                collection = database.GetCollection<FormHash>(collectionName);
                server.Ping();
            }
            catch
            {
                throw new Exception("Проблема подключением к монге");
            }

            Console.WriteLine("Получешине хешей...");

            using (var db = MDSDB.GetInstance())
            {    
                Parallel.ForEach(db.Forms.Where(x => x.FormTemplateId == templateID), form =>
                //foreach(var form in db.Forms.Where(x => x.FormTemplateId == templateID))
                {
                    if (form.Data != null)
                    {
                        var arrData = XMLDataToDoubleArray(form.Data, sizeData);
                        if (arrData != null)
                        {
                            FormHash fh = new FormHash()
                            {
                                GID = (Guid) form.GID,
                                Hash = CryptoHelpers.GetShaHash(String.Concat(arrData))
                            };
                            collection.Insert<FormHash>(fh);
                        }
                    }
                });
            }
            server.Disconnect();
            Console.Write("Закончено");
        }

        public static double[] XMLDataToDoubleArray(XElement xml, int sizeData)
        {
            try
            {
                double[] res = new double[sizeData];
                var arrXNode = xml.Elements().ToArray();
                string tmp;
                for (int i = 0; i < sizeData; i++)
                {
                    if (arrXNode[i].Attribute("Value") != null)
                    {
                        tmp = arrXNode[i].Attribute("Value").Value;
                        if (tmp == "null" || String.IsNullOrEmpty(tmp))
                        {
                            return null;
                        }
                        else
                        {
                            res[i] = double.Parse(tmp); //.Replace(',', '.')
                        }
                    }
                    else
                        return null;

                }
                return res;
            }
            catch
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            var tmp = new Nsim.LinearScale();
            
            //TestSpeedGetData();
            TranslateDataInHash(4, 67);
            Console.ReadKey();
        }
    }
}
