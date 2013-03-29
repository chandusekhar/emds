namespace Encog.App.Analyst
{
    using Encog.App.Analyst.Analyze;
    using Encog.App.Analyst.Commands;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Task;
    using Encog.App.Quant;
    using Encog.Bot;
    using Encog.ML.Train;
    using Encog.Util;
    using Encog.Util.File;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;

    public class EncogAnalyst
    {
        private readonly AnalystScript _x594135906c55045c;
        private QuantTask _x636041b6008d8fc2;
        private readonly IList<IAnalystListener> _xa1a7b04ac1ec3821;
        private readonly IDictionary<string, Cmd> _xc8e5edc888efe6f5;
        private IDictionary<string, string> _xcdbf645ae680f224;
        public const string TaskFull = "task-full";
        public const int UpdateTime = 10;
        [CompilerGenerated]
        private int x0c8ee6f0df9aeec9;
        [CompilerGenerated]
        private static Func<int, AnalystField, int> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<int, AnalystField, int> x52e0eb7265061ab4;
        [CompilerGenerated]
        private static Func<AnalystField, bool> x90d2682d7adec16e;
        [CompilerGenerated]
        private static Func<AnalystField, bool> xca5ad8524f73e51f;
        [CompilerGenerated]
        private static Func<AnalystField, bool> xcb5110745db8648f;

        public EncogAnalyst()
        {
            if (0 == 0)
            {
                if (0x7fffffff == 0)
                {
                    goto Label_00BE;
                }
                if (0 != 0)
                {
                    goto Label_0071;
                }
                this._x594135906c55045c = new AnalystScript();
                goto Label_00E8;
            }
            goto Label_008D;
        Label_0071:
            this.AddCommand(new CmdNormalize(this));
            this.AddCommand(new CmdRandomize(this));
            this.AddCommand(new CmdSegregate(this));
            this.AddCommand(new CmdTrain(this));
            this.AddCommand(new CmdBalance(this));
            this.AddCommand(new CmdSet(this));
            this.AddCommand(new CmdReset(this));
            if (0 != 0)
            {
                goto Label_00E8;
            }
            this.AddCommand(new CmdCluster(this));
            return;
        Label_008D:
            this._x636041b6008d8fc2 = null;
            this._xc8e5edc888efe6f5 = new Dictionary<string, Cmd>();
            this.MaxIteration = -1;
            this.AddCommand(new CmdCreate(this));
            this.AddCommand(new CmdEvaluate(this));
        Label_00BE:
            this.AddCommand(new CmdEvaluateRaw(this));
            if (-2147483648 != 0)
            {
                this.AddCommand(new CmdGenerate(this));
                goto Label_0071;
            }
            return;
        Label_00E8:
            this._xa1a7b04ac1ec3821 = new List<IAnalystListener>();
            if (0 != 0)
            {
                return;
            }
            goto Label_008D;
        }

        public void AddAnalystListener(IAnalystListener listener)
        {
            this._xa1a7b04ac1ec3821.Add(listener);
        }

        public void AddCommand(Cmd cmd)
        {
            this._xc8e5edc888efe6f5[cmd.Name] = cmd;
        }

        public void Analyze(FileInfo file, bool headers, AnalystFileFormat format)
        {
            this._x594135906c55045c.Properties.SetFilename("FILE_RAW", file.ToString());
            this._x594135906c55045c.Properties.SetProperty("SETUP:CONFIG_inputHeaders", headers);
            new PerformAnalysis(this._x594135906c55045c, file.ToString(), headers, format).Process(this);
        }

        public int DetermineInputCount()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                goto Label_002C;
            Label_001C:
                if (!field.Input)
                {
                    goto Label_002C;
                }
            Label_0024:
                if (!field.Ignored)
                {
                    goto Label_004C;
                }
            Label_002C:
                if (enumerator.MoveNext())
                {
                    goto Label_005A;
                }
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0057;
                }
            Label_004C:
                num += field.ColumnsNeeded;
                goto Label_002C;
            Label_0057:
                if (0 == 0)
                {
                    return num;
                }
            Label_005A:
                field = enumerator.Current;
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_001C;
                }
                if (-2147483648 != 0)
                {
                    goto Label_0024;
                }
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_004C;
                }
            }
            return num;
        }

        public int DetermineInputFieldCount()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                goto Label_002E;
            Label_001A:
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_0038;
                }
            Label_002E:
                if (enumerator.MoveNext())
                {
                    goto Label_006A;
                }
                return num;
            Label_0038:
                if (!field.Ignored)
                {
                    num++;
                }
                goto Label_002E;
            Label_0048:
                if (field.Input)
                {
                    goto Label_0038;
                }
                if ((((uint) num) | 0xff) != 0)
                {
                    goto Label_001A;
                }
            Label_006A:
                field = enumerator.Current;
                goto Label_0048;
            }
        }

        public int DetermineOutputCount()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                goto Label_0037;
            Label_001A:
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    return num;
                }
            Label_0034:
                if (0 != 0)
                {
                    goto Label_0043;
                }
            Label_0037:
                if (enumerator.MoveNext())
                {
                    goto Label_008F;
                }
                goto Label_0072;
            Label_0043:
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_005F;
                }
            Label_0057:
                if (!field.Output)
                {
                    goto Label_0034;
                }
            Label_005F:
                if (!field.Ignored)
                {
                    goto Label_0098;
                }
                goto Label_0037;
            Label_0069:
                if (-2 == 0)
                {
                    goto Label_008F;
                }
                goto Label_0037;
            Label_0072:
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_001A;
                }
                return num;
            Label_008F:
                field = enumerator.Current;
                goto Label_0057;
            Label_0098:
                num += field.ColumnsNeeded;
                goto Label_0069;
            }
        }

        public int DetermineOutputFieldCount()
        {
            int num = 0;
            foreach (AnalystField field in this._x594135906c55045c.Normalize.NormalizedFields)
            {
                if (field.Output && !field.Ignored)
                {
                    num++;
                }
            }
            return num;
        }

        public int DetermineTotalColumns()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField current;
                goto Label_0022;
            Label_001A:
                if (!current.Ignored)
                {
                    goto Label_0035;
                }
            Label_0022:
                if (!enumerator.MoveNext())
                {
                    return num;
                }
                current = enumerator.Current;
                goto Label_001A;
            Label_0035:
                num += current.ColumnsNeeded;
                if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_001A;
                }
                goto Label_0022;
            }
        }

        public int DetermineTotalInputFieldCount()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                goto Label_002B;
            Label_001A:
                if (!field.Ignored)
                {
                    goto Label_0071;
                }
                goto Label_002B;
            Label_0024:
                if (-2147483648 == 0)
                {
                    goto Label_004D;
                }
            Label_002B:
                if (!enumerator.MoveNext() && ((((uint) num) - ((uint) num)) <= uint.MaxValue))
                {
                    return num;
                }
                goto Label_007E;
            Label_004D:
                if (!field.Input)
                {
                    goto Label_002B;
                }
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                }
                goto Label_001A;
            Label_0071:
                num += field.ColumnsNeeded;
                goto Label_0024;
            Label_007E:
                field = enumerator.Current;
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_004D;
                }
                goto Label_001A;
            }
        }

        public int DetermineUniqueColumns()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                string str;
                goto Label_0051;
            Label_0021:
                if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_007C;
                }
                if ((((uint) num) | 3) == 0)
                {
                    goto Label_0021;
                }
            Label_0051:
                if (enumerator.MoveNext())
                {
                    goto Label_009D;
                }
                return num;
            Label_005C:
                if (!field.Ignored)
                {
                    goto Label_00A7;
                }
                goto Label_0051;
            Label_0066:
                if (dictionary.ContainsKey(str))
                {
                    goto Label_0086;
                }
                num += field.ColumnsNeeded;
            Label_007C:
                dictionary[str] = null;
                goto Label_0051;
            Label_0086:
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_0021;
                }
                return num;
            Label_009D:
                field = enumerator.Current;
                goto Label_005C;
            Label_00A7:
                str = field.Name;
                goto Label_0066;
            }
        }

        public int DetermineUniqueInputFieldCount()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                goto Label_003A;
            Label_0020:
                if (((uint) num) < 0)
                {
                    goto Label_0044;
                }
                if (field.Input)
                {
                    goto Label_0070;
                }
            Label_003A:
                if (enumerator.MoveNext())
                {
                    goto Label_0067;
                }
                goto Label_007F;
            Label_0044:
                dictionary[field.Name] = null;
                goto Label_003A;
            Label_0055:
                if (dictionary.ContainsKey(field.Name))
                {
                    goto Label_003A;
                }
                goto Label_0020;
            Label_0067:
                field = enumerator.Current;
                goto Label_0055;
            Label_0070:
                if (field.Ignored)
                {
                    goto Label_003A;
                }
                num++;
                if (0 == 0)
                {
                    goto Label_0044;
                }
            Label_007F:;
            }
            return num;
        }

        public int DetermineUniqueOutputFieldCount()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
            Label_0020:
                if (enumerator.MoveNext())
                {
                    goto Label_006C;
                }
                if (0 != 0)
                {
                    goto Label_0020;
                }
                return num;
            Label_002F:
                if (!dictionary.ContainsKey(field.Name))
                {
                    goto Label_004D;
                }
                goto Label_0020;
            Label_003F:
                if (!field.Ignored)
                {
                    num++;
                }
                goto Label_0055;
            Label_004D:
                if (field.Output)
                {
                    goto Label_003F;
                }
            Label_0055:
                dictionary[field.Name] = null;
                goto Label_0020;
            Label_006C:
                field = enumerator.Current;
                if (0 == 0)
                {
                    goto Label_002F;
                }
            }
            return num;
        }

        public void Download()
        {
            Uri propertyURL = this._x594135906c55045c.Properties.GetPropertyURL("HEADER:DATASOURCE_sourceFile");
            string propertyFile = this._x594135906c55045c.Properties.GetPropertyFile("HEADER:DATASOURCE_rawFile");
            FileInfo info = this.Script.ResolveFilename(propertyFile);
            if (!info.Exists)
            {
                this.xe98b6cac0003bda6(propertyURL, info);
            }
        }

        public void ExecuteTask(AnalystTask task)
        {
            int count = task.Lines.Count;
            int num2 = 1;
            using (IEnumerator<string> enumerator = task.Lines.GetEnumerator())
            {
                string str;
                bool flag;
                string str2;
                string str3;
                string str4;
                int num3;
                Cmd cmd;
                goto Label_0023;
            Label_001D:
                num2++;
                goto Label_0034;
            Label_0023:
                if (enumerator.MoveNext())
                {
                    goto Label_0129;
                }
                return;
            Label_0034:
                if (!this.x1855cef31496f82f())
                {
                    goto Label_0023;
                }
                goto Label_0122;
            Label_003E:
                this.x7946863605ccf4d8(flag);
                this.CurrentQuantTask = null;
                goto Label_001D;
            Label_0050:
                cmd = this._xc8e5edc888efe6f5[str2];
                if (cmd != null)
                {
                    flag = cmd.ExecuteCommand(str3);
                    goto Label_003E;
                }
                throw new AnalystError("Unknown Command: " + str);
            Label_009A:
                str2 = str4.ToUpper();
                str3 = "";
                goto Label_0050;
            Label_00AE:
                if (num3 != -1)
                {
                    goto Label_00D7;
                }
                if (0 == 0)
                {
                    goto Label_009A;
                }
                goto Label_0122;
            Label_00BD:
                if ((((uint) flag) + ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_0129;
                }
                goto Label_00AE;
            Label_00D7:
                str2 = str4.Substring(0, num3).ToUpper();
                str3 = str4.Substring(num3 + 1);
                goto Label_0050;
            Label_00F9:
                flag = false;
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_0131;
                }
                str4 = str.Trim();
            Label_0115:
                num3 = str4.IndexOf(' ');
                goto Label_00BD;
            Label_0122:
                if (4 != 0)
                {
                    return;
                }
            Label_0129:
                str = enumerator.Current;
            Label_0131:
                EncogLogging.Log(0, "Execute analyst line: " + str);
                this.x1ce1584ce46d7cf9(count, num2, str);
                if (((uint) num3) < 0)
                {
                    goto Label_0115;
                }
                goto Label_00F9;
            }
        }

        public void ExecuteTask(string name)
        {
            AnalystTask task;
            EncogLogging.Log(1, "Analyst execute task:" + name);
            do
            {
                task = this._x594135906c55045c.GetTask(name);
            }
            while (0 != 0);
            if (0 == 0)
            {
                do
                {
                    if (task == null)
                    {
                        goto Label_0013;
                    }
                    break;
                }
                while (0 != 0);
                this.ExecuteTask(task);
                return;
            }
        Label_0013:
            throw new AnalystError("Can't find task: " + name);
        }

        public void Load(FileInfo file)
        {
            Stream stream = null;
            this._x594135906c55045c.BasePath = file.DirectoryName;
            try
            {
                stream = file.OpenRead();
                this.Load(stream);
            }
            catch (IOException exception)
            {
                throw new AnalystError(exception);
            }
            finally
            {
                if (stream != null)
                {
                    try
                    {
                        stream.Close();
                    }
                    catch (IOException exception2)
                    {
                        throw new AnalystError(exception2);
                    }
                }
            }
        }

        public void Load(Stream stream)
        {
            this._x594135906c55045c.Load(stream);
            this._xcdbf645ae680f224 = this._x594135906c55045c.Properties.PrepareRevert();
        }

        public void Load(string filename)
        {
            this.Load(new FileInfo(filename));
        }

        public void RemoveAnalystListener(IAnalystListener listener)
        {
            this._xa1a7b04ac1ec3821.Remove(listener);
        }

        public void ReportTraining(IMLTrain train)
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.ReportTraining(train);
            }
        }

        public void ReportTrainingBegin()
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.ReportTrainingBegin();
            }
        }

        public void ReportTrainingEnd()
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.ReportTrainingEnd();
            }
        }

        public void Save(FileInfo file)
        {
            Stream stream = null;
            try
            {
                this._x594135906c55045c.BasePath = file.DirectoryName;
                stream = file.OpenWrite();
                this.Save(stream);
            }
            catch (IOException exception)
            {
                throw new AnalystError(exception);
            }
            finally
            {
                if (stream != null)
                {
                    try
                    {
                        stream.Close();
                    }
                    catch (IOException exception2)
                    {
                        throw new AnalystError(exception2);
                    }
                }
            }
        }

        public void Save(Stream stream)
        {
            this._x594135906c55045c.Save(stream);
        }

        public void Save(string filename)
        {
            this.Save(new FileInfo(filename));
        }

        public bool ShouldStopCommand()
        {
            using (IEnumerator<IAnalystListener> enumerator = this._xa1a7b04ac1ec3821.GetEnumerator())
            {
                IAnalystListener current;
                bool flag;
                goto Label_0018;
            Label_0010:
                if (current.ShouldStopCommand())
                {
                    goto Label_002B;
                }
            Label_0018:
                if (!enumerator.MoveNext())
                {
                    goto Label_0055;
                }
                current = enumerator.Current;
                goto Label_0010;
            Label_002B:
                return true;
                if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_002B;
                }
                goto Label_0010;
            }
        Label_0055:
            return false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StopCurrentTask()
        {
            if (this._x636041b6008d8fc2 != null)
            {
                this._x636041b6008d8fc2.RequestStop();
            }
        }

        [CompilerGenerated]
        private static int x003a13383c339170(int x3bd62873fafa6252, AnalystField xe01ae93d9fe5a880)
        {
            return Math.Max(x3bd62873fafa6252, xe01ae93d9fe5a880.TimeSlice);
        }

        private bool x1855cef31496f82f()
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                if (listener.ShouldShutDown())
                {
                    return true;
                    if (8 != 0)
                    {
                    }
                }
            }
            return false;
        }

        private void x1ce1584ce46d7cf9(int xb1c30745a1525188, int x3bd62873fafa6252, string xc15bd84e01929885)
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.ReportCommandBegin(xb1c30745a1525188, x3bd62873fafa6252, xc15bd84e01929885);
            }
        }

        [CompilerGenerated]
        private static bool x39c9f3878dc6803f(AnalystField xe01ae93d9fe5a880)
        {
            return (xe01ae93d9fe5a880.TimeSlice != 0);
        }

        [CompilerGenerated]
        private static bool x4b90a4532700f8c1(AnalystField xe01ae93d9fe5a880)
        {
            return (xe01ae93d9fe5a880.TimeSlice < 0);
        }

        private void x5d9a63140eb6b015(int xb1c30745a1525188, int x3bd62873fafa6252, string x1f25abf5fb75e795)
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.Report(xb1c30745a1525188, x3bd62873fafa6252, x1f25abf5fb75e795);
            }
        }

        [CompilerGenerated]
        private static bool x76f0417a648ac746(AnalystField xe01ae93d9fe5a880)
        {
            return (xe01ae93d9fe5a880.TimeSlice > 0);
        }

        private void x7946863605ccf4d8(bool x55ccc40af0be5859)
        {
            foreach (IAnalystListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.ReportCommandEnd(x55ccc40af0be5859);
            }
        }

        private void xe98b6cac0003bda6(Uri xf50d6d3c10c0eac9, FileInfo xb44380e048627945)
        {
            try
            {
                FileInfo info;
                FileStream stream;
                int num;
                int num2;
                int num3;
                byte[] buffer;
                Stream responseStream;
                xb44380e048627945.Delete();
                goto Label_027D;
            Label_000B:
                if (((uint) num) >= 0)
                {
                    goto Label_014D;
                }
            Label_0020:
                using (FileStream stream3 = info.OpenRead())
                {
                    using (FileStream stream4 = xb44380e048627945.Create())
                    {
                        using (GZipStream stream5 = new GZipStream(stream3, CompressionMode.Decompress))
                        {
                            num3 = 0;
                            goto Label_00C4;
                        Label_0042:
                            num = 0;
                        Label_0044:
                            num++;
                            if (num2 > 0)
                            {
                                goto Label_00C6;
                            }
                            goto Label_0134;
                        Label_0054:
                            if (num <= 10)
                            {
                                goto Label_0044;
                            }
                        Label_0059:
                            this.x5d9a63140eb6b015(0, (int) (((long) num3) / 0x100000L), "Uncompressing... " + Format.FormatMemory((long) num3));
                            goto Label_0042;
                        Label_007F:
                            if (-1 == 0)
                            {
                                goto Label_00FE;
                            }
                        Label_0089:
                            if (num2 >= 0)
                            {
                                goto Label_00ED;
                            }
                            goto Label_0054;
                        Label_008F:
                            if ((((uint) num) & 0) != 0)
                            {
                                goto Label_0089;
                            }
                            if ((((uint) num3) | 0xfffffffe) == 0)
                            {
                                goto Label_0059;
                            }
                            goto Label_0054;
                        Label_00C4:
                            num = 0;
                        Label_00C6:
                            num2 = stream5.Read(buffer, 0, buffer.Length);
                            if ((((uint) num) | uint.MaxValue) != 0)
                            {
                                goto Label_0089;
                            }
                        Label_00ED:
                            stream4.Write(buffer, 0, num2);
                            num3 += num2;
                        Label_00FE:
                            if (((uint) num) <= uint.MaxValue)
                            {
                                goto Label_008F;
                            }
                            goto Label_007F;
                        }
                    }
                Label_0134:
                    info.Delete();
                    return;
                }
                goto Label_0167;
            Label_014D:
                if (xf50d6d3c10c0eac9.ToString().ToLower().EndsWith(".gz"))
                {
                    goto Label_0020;
                }
            Label_0167:
                xb44380e048627945.Delete();
                info.MoveTo(xb44380e048627945.ToString());
                return;
            Label_017E:
                if (num2 > 0)
                {
                    goto Label_0213;
                }
            Label_0185:
                if (num2 > 0)
                {
                    goto Label_0219;
                }
                stream.Close();
                goto Label_022D;
            Label_0194:
                this.x5d9a63140eb6b015(0, (int) (((long) num3) / 0x100000L), "Downloading... " + Format.FormatMemory((long) num3));
                if (3 == 0)
                {
                    goto Label_02A2;
                }
                num = 0;
            Label_01C4:
                num++;
                goto Label_0185;
            Label_01CA:
                if ((((uint) num3) | 8) == 0)
                {
                    goto Label_0213;
                }
            Label_01E2:
                if (num <= 10)
                {
                    goto Label_01C4;
                }
                goto Label_0194;
            Label_01EB:
                stream.Write(buffer, 0, num2);
                num3 += num2;
                if (((uint) num) >= 0)
                {
                    goto Label_01CA;
                }
                if (0 != 0)
                {
                    goto Label_0299;
                }
            Label_0213:
                if (num2 >= 0)
                {
                    goto Label_01EB;
                }
                goto Label_01E2;
            Label_0219:
                num2 = responseStream.Read(buffer, 0, buffer.Length);
                goto Label_017E;
            Label_022D:
                if ((((uint) num2) - ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_000B;
                }
                return;
            Label_024A:
                num3 = 0;
                buffer = new byte[BotUtil.BufferSize];
                WebRequest request = WebRequest.Create(xf50d6d3c10c0eac9);
                if (0 != 0)
                {
                    goto Label_0299;
                }
                responseStream = ((HttpWebResponse) request.GetResponse()).GetResponseStream();
                goto Label_0219;
            Label_027D:
                info = FileUtil.CombinePath(new FileInfo(xb44380e048627945.DirectoryName), "temp.tmp");
                info.Delete();
            Label_0299:
                stream = info.OpenWrite();
                num = 0;
            Label_02A2:
                num2 = 0;
                goto Label_024A;
            }
            catch (IOException exception)
            {
                throw new AnalystError(exception);
            }
        }

        [CompilerGenerated]
        private static int xfd645fc8075c58ea(int x3bd62873fafa6252, AnalystField xe01ae93d9fe5a880)
        {
            return Math.Max(x3bd62873fafa6252, Math.Abs(xe01ae93d9fe5a880.TimeSlice));
        }

        public QuantTask CurrentQuantTask
        {
            set
            {
                this._x636041b6008d8fc2 = value;
            }
        }

        public int LagDepth
        {
            get
            {
                if (xcb5110745db8648f == null)
                {
                    xcb5110745db8648f = new Func<AnalystField, bool>(EncogAnalyst.x4b90a4532700f8c1);
                }
                if (x1ecac4c96d3f3733 == null)
                {
                    x1ecac4c96d3f3733 = new Func<int, AnalystField, int>(EncogAnalyst.xfd645fc8075c58ea);
                }
                return this._x594135906c55045c.Normalize.NormalizedFields.Where<AnalystField>(xcb5110745db8648f).Aggregate<AnalystField, int>(0, x1ecac4c96d3f3733);
            }
        }

        public int LeadDepth
        {
            get
            {
                if (xca5ad8524f73e51f == null)
                {
                    xca5ad8524f73e51f = new Func<AnalystField, bool>(EncogAnalyst.x76f0417a648ac746);
                }
                if (x52e0eb7265061ab4 == null)
                {
                    x52e0eb7265061ab4 = new Func<int, AnalystField, int>(EncogAnalyst.x003a13383c339170);
                }
                return this._x594135906c55045c.Normalize.NormalizedFields.Where<AnalystField>(xca5ad8524f73e51f).Aggregate<AnalystField, int>(0, x52e0eb7265061ab4);
            }
        }

        public IList<IAnalystListener> Listeners
        {
            get
            {
                return this._xa1a7b04ac1ec3821;
            }
        }

        public int MaxIteration
        {
            [CompilerGenerated]
            get
            {
                return this.x0c8ee6f0df9aeec9;
            }
            [CompilerGenerated]
            set
            {
                this.x0c8ee6f0df9aeec9 = value;
            }
        }

        public IDictionary<string, string> RevertData
        {
            get
            {
                return this._xcdbf645ae680f224;
            }
        }

        public AnalystScript Script
        {
            get
            {
                return this._x594135906c55045c;
            }
        }

        public bool TimeSeries
        {
            get
            {
                if (x90d2682d7adec16e == null)
                {
                    x90d2682d7adec16e = new Func<AnalystField, bool>(EncogAnalyst.x39c9f3878dc6803f);
                }
                return this._x594135906c55045c.Normalize.NormalizedFields.Any<AnalystField>(x90d2682d7adec16e);
            }
        }
    }
}

