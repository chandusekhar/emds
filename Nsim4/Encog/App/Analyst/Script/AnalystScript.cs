namespace Encog.App.Analyst.Script
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Prop;
    using Encog.App.Analyst.Script.Segregate;
    using Encog.App.Analyst.Script.Task;
    using Encog.Util.CSV;
    using Encog.Util.File;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AnalystScript
    {
        private readonly AnalystNormalize _x137d2319cbd2bef2;
        private readonly AnalystSegregate _x41b21b8404d1e8fd;
        private readonly IDictionary<string, AnalystTask> _xa4ef4a3fe0a24a84;
        private DataField[] _xa942970cc8a85fd4;
        private readonly IList<string> _xb2331775ea68cd6f;
        private string _xbb34adac352faae2;
        private readonly ScriptProperties _xe11545499171cc05;
        public const int DefaultMaxClass = 50;

        public AnalystScript()
        {
            while (true)
            {
                this._x137d2319cbd2bef2 = new AnalystNormalize(this);
                this._x41b21b8404d1e8fd = new AnalystSegregate();
                this._xb2331775ea68cd6f = new List<string>();
                this._xa4ef4a3fe0a24a84 = new Dictionary<string, AnalystTask>();
                this._xe11545499171cc05 = new ScriptProperties();
                this._xe11545499171cc05.SetProperty("SETUP:CONFIG_csvFormat", AnalystFileFormat.DecpntComma);
                this._xe11545499171cc05.SetProperty("SETUP:CONFIG_maxClassCount", 50);
                this._xe11545499171cc05.SetProperty("SETUP:CONFIG_allowedClasses", "integer,string");
                if (0xff != 0)
                {
                    return;
                }
            }
        }

        public void AddTask(AnalystTask task)
        {
            this._xa4ef4a3fe0a24a84[task.Name] = task;
        }

        public void ClearTasks()
        {
            this._xa4ef4a3fe0a24a84.Clear();
        }

        public CSVFormat DetermineInputFormat(string sourceID)
        {
            string propertyString = this.Properties.GetPropertyString("HEADER:DATASOURCE_rawFile");
            return this.Properties.GetPropertyCSVFormat(sourceID.Equals(propertyString) ? "HEADER:DATASOURCE_sourceFormat" : "SETUP:CONFIG_csvFormat");
        }

        public CSVFormat DetermineOutputFormat()
        {
            return this.Properties.GetPropertyCSVFormat("SETUP:CONFIG_csvFormat");
        }

        public bool ExpectInputHeaders(string filename)
        {
            return (this.IsGenerated(filename) || this._xe11545499171cc05.GetPropertyBoolean("SETUP:CONFIG_inputHeaders"));
        }

        public DataField FindDataField(string name)
        {
            return this._xa942970cc8a85fd4.FirstOrDefault<DataField>(dataField => dataField.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public int FindDataFieldIndex(DataField df)
        {
            for (int i = 0; i < this._xa942970cc8a85fd4.Length; i++)
            {
                do
                {
                    if (df == this._xa942970cc8a85fd4[i])
                    {
                        return i;
                    }
                }
                while (-1 == 0);
            }
            return -1;
        }

        public AnalystField FindNormalizedField(string name, int slice)
        {
            return this.Normalize.NormalizedFields.FirstOrDefault<AnalystField>(field => (field.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && (field.TimeSlice == slice)));
        }

        public AnalystTask GetTask(string name)
        {
            if (!this._xa4ef4a3fe0a24a84.ContainsKey(name))
            {
                return null;
            }
            return this._xa4ef4a3fe0a24a84[name];
        }

        public void Init()
        {
            this._x137d2319cbd2bef2.Init(this);
        }

        public bool IsGenerated(string filename)
        {
            return this._xb2331775ea68cd6f.Contains(filename);
        }

        public void Load(Stream stream)
        {
            new ScriptLoad(this).Load(stream);
        }

        public void MarkGenerated(string filename)
        {
            if (!this._xb2331775ea68cd6f.Contains(filename))
            {
                this._xb2331775ea68cd6f.Add(filename);
            }
        }

        public FileInfo ResolveFilename(string sourceID)
        {
            string filename = this.Properties.GetFilename(sourceID);
            if ((filename.IndexOf(Path.PathSeparator) == -1) && (this._xbb34adac352faae2 != null))
            {
                return FileUtil.CombinePath(new FileInfo(this._xbb34adac352faae2), filename);
            }
            return new FileInfo(filename);
        }

        public void Save(Stream stream)
        {
            new ScriptSave(this).Save(stream);
        }

        public string BasePath
        {
            get
            {
                return this._xbb34adac352faae2;
            }
            set
            {
                this._xbb34adac352faae2 = value;
            }
        }

        public DataField[] Fields
        {
            get
            {
                return this._xa942970cc8a85fd4;
            }
            set
            {
                this._xa942970cc8a85fd4 = value;
            }
        }

        public AnalystNormalize Normalize
        {
            get
            {
                return this._x137d2319cbd2bef2;
            }
        }

        public int Precision
        {
            get
            {
                return 10;
            }
        }

        public ScriptProperties Properties
        {
            get
            {
                return this._xe11545499171cc05;
            }
        }

        public AnalystSegregate Segregate
        {
            get
            {
                return this._x41b21b8404d1e8fd;
            }
        }

        public IDictionary<string, AnalystTask> Tasks
        {
            get
            {
                return this._xa4ef4a3fe0a24a84;
            }
        }
    }
}

