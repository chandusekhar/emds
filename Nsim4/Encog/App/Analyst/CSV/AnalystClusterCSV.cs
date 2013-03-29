namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Analyst.CSV.Normalize;
    using Encog.App.Analyst.Util;
    using Encog.App.Quant;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.ML.Kmeans;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AnalystClusterCSV : BasicFile
    {
        private BasicMLDataSet _x4a3f0a05c02f235f;
        private EncogAnalyst _x554f16462d8d4675;
        private CSVHeaders _xc5416b6511261016;

        public void Analyze(EncogAnalyst theAnalyst, FileInfo inputFile, bool headers, CSVFormat format)
        {
            int num;
            int num2;
            ReadCSV dcsv;
            base.InputFilename = inputFile;
            if (0 == 0)
            {
                if ((((uint) headers) + ((uint) num2)) < 0)
                {
                    goto Label_00CC;
                }
                base.ExpectInputHeaders = headers;
                base.InputFormat = format;
                if ((((uint) num) + ((uint) headers)) >= 0)
                {
                    base.Analyzed = true;
                    this._x554f16462d8d4675 = theAnalyst;
                    if (base.OutputFormat == null)
                    {
                        base.OutputFormat = base.InputFormat;
                        if (((uint) num2) < 0)
                        {
                            goto Label_007E;
                        }
                    }
                }
            }
            goto Label_0184;
        Label_0044:
            base.RecordCount = num;
            base.Count = dcsv.ColumnCount;
            base.ReadHeaders(dcsv);
            dcsv.Close();
            base.ReportDone(true);
            if ((((uint) num2) | 0xfffffffe) != 0)
            {
                return;
            }
            goto Label_0184;
        Label_0074:
            if (!base.ShouldStop())
            {
                base.UpdateStatus(true);
                LoadedRow theRow = new LoadedRow(dcsv, 1);
                double[] input = AnalystNormalizeCSV.ExtractFields(this._x554f16462d8d4675, this._xc5416b6511261016, dcsv, num2, true);
                if ((((uint) num2) + ((uint) num)) >= 0)
                {
                    ClusterRow inputData = new ClusterRow(input, theRow);
                    this._x4a3f0a05c02f235f.Add(inputData);
                    if ((((uint) num2) + ((uint) num2)) >= 0)
                    {
                        num++;
                        if ((((uint) num2) & 0) == 0)
                        {
                            goto Label_007E;
                        }
                        goto Label_0074;
                    }
                    goto Label_00C5;
                }
                goto Label_011C;
            }
            goto Label_0044;
        Label_007E:
            if (dcsv.Next())
            {
                goto Label_0074;
            }
            goto Label_0044;
        Label_00C5:
            if (2 == 0)
            {
                goto Label_0074;
            }
        Label_00CC:
            this._xc5416b6511261016 = new CSVHeaders(base.InputHeadings);
            goto Label_007E;
        Label_011C:
            num2 = this._x554f16462d8d4675.DetermineTotalColumns();
            dcsv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            base.ReadHeaders(dcsv);
            goto Label_00C5;
        Label_0184:
            this._x4a3f0a05c02f235f = new BasicMLDataSet();
            base.ResetStatus();
            if ((((uint) headers) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_0044;
            }
            num = 0;
            goto Label_011C;
        }

        public void Process(FileInfo outputFile, int clusters, EncogAnalyst theAnalyst, int iterations)
        {
            KMeansClustering clustering;
            int num;
            int num2;
            IMLCluster[] clusterArray;
            int num3;
            StreamWriter tw = this.xf911a8958011bd6d(outputFile);
            goto Label_014D;
        Label_001F:
            if (num3 >= clusterArray.Length)
            {
                if ((((uint) num2) | 0x80000000) != 0)
                {
                    if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                    {
                        base.ReportDone(false);
                        tw.Close();
                        return;
                    }
                    goto Label_014D;
                }
                goto Label_00F7;
            }
            IMLCluster cluster = clusterArray[num3];
        Label_004F:
            using (IEnumerator<IMLData> enumerator = cluster.Data.GetEnumerator())
            {
                LoadedRow row2;
                goto Label_0090;
            Label_005E:
                row2.Data[num2] = num;
                if ((((uint) num3) & 0) != 0)
                {
                    goto Label_00AD;
                }
                base.WriteRow(tw, row2);
            Label_0090:
                if (!enumerator.MoveNext())
                {
                    goto Label_00D6;
                }
                IMLData current = enumerator.Current;
                ClusterRow row = (ClusterRow) current;
            Label_00AD:
                num2 = row.Input.Count - 1;
                row2 = row.Row;
                goto Label_005E;
            }
        Label_00D6:
            num++;
            num3++;
            if (((uint) num) < 0)
            {
                goto Label_004F;
            }
            goto Label_001F;
        Label_00F7:
            clustering = new KMeansClustering(clusters, this._x4a3f0a05c02f235f);
            if (((uint) num2) < 0)
            {
                goto Label_00F7;
            }
            clustering.Iteration(iterations);
            num = 0;
            clusterArray = clustering.Clusters;
            num3 = 0;
            goto Label_001F;
        Label_014D:
            base.ResetStatus();
            goto Label_00F7;
        }

        private StreamWriter xf911a8958011bd6d(FileInfo x2608fe0a208c787d)
        {
            StreamWriter writer2;
            try
            {
                StringBuilder builder;
                string str;
                string[] strArray;
                int num;
                StreamWriter writer = new StreamWriter(x2608fe0a208c787d.OpenRead());
                goto Label_002B;
            Label_0011:
                builder.Append("\"cluster\"");
                writer.WriteLine(builder.ToString());
                goto Label_0036;
            Label_002B:
                if (base.ProduceOutputHeaders)
                {
                    goto Label_00CD;
                }
            Label_0036:
                writer2 = writer;
                goto Label_00C5;
            Label_003B:
                num++;
                if (0 == 0)
                {
                }
            Label_0044:
                if (num < strArray.Length)
                {
                    goto Label_007A;
                }
                goto Label_0011;
            Label_0050:
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0044;
                }
                builder.Append("\"");
                goto Label_003B;
            Label_007A:
                str = strArray[num];
                BasicFile.AppendSeparator(builder, base.OutputFormat);
                builder.Append("\"");
            Label_0098:
                builder.Append(str);
                goto Label_00BB;
            Label_00A2:
                strArray = base.InputHeadings;
                num = 0;
                if (3 != 0)
                {
                    goto Label_0044;
                }
                goto Label_00BB;
            Label_00B6:
                if (0 != 0)
                {
                    goto Label_0098;
                }
                goto Label_00A2;
            Label_00BB:
                if (0x7fffffff != 0)
                {
                    goto Label_0050;
                }
            Label_00C5:
                if (0 == 0)
                {
                    return writer2;
                }
                goto Label_002B;
            Label_00CD:
                builder = new StringBuilder();
                goto Label_00B6;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            return writer2;
        }
    }
}

