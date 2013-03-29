using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using emds.common.Models;

using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using Encog.ML.Data.Basic;

namespace emds.common
{
    public class SearchHashForm
    {
        private MongoServer server;
        private MongoDatabase database;
        private MongoCollection collection;
        private string connectionString;

        private FileLogger log;

        public SearchHashForm(string collectionName = "HashForm", string dbName = "emdsdb", string hostIP = "localhost")
        {
            connectionString = String.Format("mongodb://{0}/?safe=true", hostIP);
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
            log = FileLogger.GetLogger();
        }


        /// <summary>
        /// Проверка на равенство. Массивы должны быть равной длинны.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CompareArr(double[] f, double[] s)
        {
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].CompareTo(s[i]) != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// получает SHA1 хэш из массива данных, конкатенируя его в строку
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetHashForm(double[] data)
        {
            string tmp = String.Concat(data);
            return CryptoHelpers.GetShaHash(tmp);
        }

        /// <summary>
        /// Получает массив данных из xml
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sizeData"></param>
        /// <returns></returns>
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

        public Guid[] GetGIDFormArr(double[][] data)
        {
            Guid[] res = new Guid[data.Length];
            var forms = collection.FindAllAs<FormHash>();
            long count = forms.Count();
            //Parallel.For(0, data.Length, i =>
            for (int i = 0; i < data.Length; i++)
            {
                foreach (var item in forms)
                {
                    if(CompareArr(item.Data, data[i]))
                    {
                        res[i] = item.GID;
                        break;
                    }
                }
            }

            return res;
        }

        public Guid[] GetGIDForm(double[][] data)
        {
            Guid[] res = new Guid[data.Length];

            //Parallel.For(0, data.Length, i =>
            for(int i = 0; i < data.Length; i++)
            {
                string hash = GetHashForm(data[i]);
                var query = Query.EQ("Hash", hash);
                var forms = collection.FindAs<FormHash>(query);
                long count = forms.Count();
                if (count <= 1)
                {
                    if (count == 1)
                    {
                        FormHash fh = forms.First();
                        res[i] = fh.GID;
                    }
                    else
                        log.WriteString("e002 SearchHashForm. При поиске по хэшу не найдено совпадений.");
                }
                else
                {
                    log.WriteString(
                        String.Format("e001 SearchHashForm. При поиске по хэшу найдено несколько {0} совпадений.", count));
                }
            }

            return res;
        }

        public Guid[] GetGIDForm(BasicMLDataSet data)
        {
            double[][] dataRes = new double[data.Count][];

            for (int i = 0; i < data.Count; i++)
            {
                dataRes[i] = data[i].InputArray;
            }

            return this.GetGIDFormArr(dataRes);
            //return this.GetGIDForm(dataRes);
        }
    }
}
