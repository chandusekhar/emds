namespace Encog.ML.Data.Specific
{
    using Encog.ML.Data.Basic;
    using Encog.ML.Data.Buffer;
    using Encog.ML.Data.Buffer.CODEC;
    using System;

    public class SQLMLDataSet : BasicMLDataSet
    {
        public SQLMLDataSet(string sql, int inputSize, int idealSize, string connectString)
        {
            MemoryDataLoader loader2;
            if ((((uint) idealSize) + ((uint) inputSize)) >= 0)
            {
                IDataSetCODEC codec = new SQLCODEC(sql, inputSize, idealSize, connectString);
                loader2 = new MemoryDataLoader(codec) {
                    Result = this
                };
            }
            loader2.External2Memory();
        }
    }
}

