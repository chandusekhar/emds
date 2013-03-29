namespace Encog.App.Analyst.Wizard
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Missing;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Prop;
    using Encog.App.Analyst.Script.Segregate;
    using Encog.App.Analyst.Script.Task;
    using Encog.Util.Arrayutil;
    using Encog.Util.File;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AnalystWizard
    {
        private bool _x02283b983d652139;
        private bool _x0236ea04f9fa4aaa;
        private string _x0768e2edc97194de;
        private string _x2329764ec876a018;
        private AnalystGoal _x29c8e5bee3cb25f8;
        private bool _x34231b3d9a1591be;
        private readonly EncogAnalyst _x554f16462d8d4675;
        private readonly AnalystScript _x594135906c55045c;
        private string _x612bcf37596c363d;
        private bool _x613f2248b9e460bd = true;
        private bool _x62451326f700d5c8 = true;
        private int _x654428e3563552e3;
        private string _x6b465268cbeb5837;
        private bool _x7047063a9bee4054;
        private IHandleMissingValues _x771edacf1be2c386;
        private string _x79f5154bafa879c9;
        private string _x9097f279e99eb0be;
        private bool _x990368722123b229 = false;
        private string _x99f0b15384a590eb;
        private NormalizeRange _x9b10ace6509508c0;
        private string _x9f5087e4a335ff18;
        private WizardMethodType _xa24f4208aa2278f4;
        private string _xb577f44182f20fa3;
        private int _xb6540cd895237850;
        private string _xbb5a08794aa6d723;
        private bool _xc24b506a94383a44;
        private string _xe6d4a9d680176148;
        private string _xedea45ae43322d49;
        public const int DefaultEvalPercent = 0x19;
        public const double DefaultTrainError = 0.01;
        public const int DefaultTrainPercent = 0x4b;
        public const string FileBalance = "FILE_BALANCE";
        public const string FileCluster = "FILE_CLUSTER";
        public const string FileEval = "FILE_EVAL";
        public const string FileEvalNorm = "FILE_EVAL_NORM";
        public const string FileMl = "FILE_ML";
        public const string FileNormalize = "FILE_NORMALIZE";
        public const string FileOutput = "FILE_OUTPUT";
        public const string FileRandom = "FILE_RANDOMIZE";
        public const string FileRaw = "FILE_RAW";
        public const string FileTrain = "FILE_TRAIN";
        public const string FileTrainset = "FILE_TRAINSET";

        public AnalystWizard(EncogAnalyst theAnalyst)
        {
            if (15 == 0)
            {
                return;
            }
            this._x7047063a9bee4054 = true;
        Label_0071:
            this._xc24b506a94383a44 = false;
            this._x34231b3d9a1591be = true;
            this._x9b10ace6509508c0 = NormalizeRange.NegOne2One;
            this._x554f16462d8d4675 = theAnalyst;
            this._x594135906c55045c = this._x554f16462d8d4675.Script;
            this._xa24f4208aa2278f4 = WizardMethodType.FeedForward;
            this._x0768e2edc97194de = "";
            if (8 != 0)
            {
                this._x29c8e5bee3cb25f8 = AnalystGoal.Classification;
                this._xb6540cd895237850 = 0;
                if (1 != 0)
                {
                    this._x654428e3563552e3 = 0;
                    this._x0236ea04f9fa4aaa = false;
                    this._x771edacf1be2c386 = new DiscardMissing();
                }
                else
                {
                    goto Label_0071;
                }
            }
        }

        public void Reanalyze()
        {
            string propertyFile = this._x594135906c55045c.Properties.GetPropertyFile("HEADER:DATASOURCE_rawFile");
            FileInfo file = this._x554f16462d8d4675.Script.ResolveFilename(propertyFile);
            this._x554f16462d8d4675.Analyze(file, this._x594135906c55045c.Properties.GetPropertyBoolean("SETUP:CONFIG_inputHeaders"), this._x594135906c55045c.Properties.GetPropertyFormat("SETUP:CONFIG_csvFormat"));
        }

        public void Wizard(FileInfo analyzeFile, bool b, AnalystFileFormat format)
        {
            this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_sourceFormat", format);
            if (0 == 0)
            {
                goto Label_00E4;
            }
        Label_0039:
            if (this._x654428e3563552e3 <= 0)
            {
                return;
            }
            if (this._xb6540cd895237850 <= 0)
            {
                if (0 == 0)
                {
                    return;
                }
            }
            else
            {
                this.xfd33c8a1cd5c5a19();
                if ((((uint) b) | 8) != 0)
                {
                    return;
                }
            }
            goto Label_0039;
        Label_00E4:
            this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_sourceHeaders", b);
            this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_rawFile", analyzeFile);
            if (0 == 0)
            {
                this._x02283b983d652139 = (this._x654428e3563552e3 > 0) || (this._xb6540cd895237850 > 0);
                this.xf1bed93d6f997005();
                if ((((uint) b) - ((uint) b)) > uint.MaxValue)
                {
                    goto Label_0039;
                }
                if ((((uint) b) + ((uint) b)) <= uint.MaxValue)
                {
                    this.xf6e1c35864db42aa(analyzeFile);
                }
                this.xdd8dc65aef162a86();
                this._x554f16462d8d4675.Analyze(analyzeFile, b, format);
            }
        Label_008D:
            this.xa39295d07e81cd8c();
            this.x457a4b5397851b17();
            this.x0b3092feb6dc609a();
            this.x8623f9a426a3d24c();
            if (!this._x02283b983d652139)
            {
                return;
            }
            if ((((uint) b) + ((uint) b)) >= 0)
            {
                if ((15 != 0) && ((((uint) b) + ((uint) b)) < 0))
                {
                    goto Label_008D;
                }
                goto Label_0039;
            }
            goto Label_00E4;
        }

        public void Wizard(Uri url, FileInfo saveFile, FileInfo analyzeFile, bool b, AnalystFileFormat format)
        {
            this._x594135906c55045c.BasePath = saveFile.DirectoryName;
            while (true)
            {
                this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_sourceFile", url);
                if (((uint) b) >= 0)
                {
                    this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_sourceFormat", format);
                    this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_sourceHeaders", b);
                }
                this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_rawFile", analyzeFile);
                this.xf6e1c35864db42aa(analyzeFile);
                this.xdd8dc65aef162a86();
                this._x554f16462d8d4675.Download();
                this.Wizard(analyzeFile, b, format);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        private void x0b3092feb6dc609a()
        {
            int num;
            int num2;
            this.xd60d4f24f6e3ffb5();
            if (8 != 0)
            {
                goto Label_00D6;
            }
            goto Label_00A9;
        Label_0022:
            this.x2855325f699de339(num, num2);
            if (0 == 0)
            {
                return;
            }
        Label_0077:
            num2 = this._x594135906c55045c.Normalize.CalculateOutputColumns();
            WizardMethodType type = this._xa24f4208aa2278f4;
            if (0 != 0)
            {
                goto Label_00A9;
            }
            if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_00D6;
            }
            switch (type)
            {
                case WizardMethodType.FeedForward:
                    this.x40aa65188bc3f1f4(num);
                    return;

                case WizardMethodType.RBF:
                    goto Label_0022;

                case WizardMethodType.SVM:
                    this.x982be993d7259fbb();
                    return;

                case WizardMethodType.SOM:
                    this.x9079d3066b3873db();
                    return;

                default:
                    throw new AnalystError("Unknown method type");
            }
        Label_008F:
            num = this._x594135906c55045c.Normalize.CalculateInputColumns();
            goto Label_0077;
        Label_00A9:
            throw new AnalystError("Failed to find normalized version of target field: " + this._x0768e2edc97194de);
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_0022;
            }
            goto Label_008F;
        Label_00D6:
            if (this._x0768e2edc97194de == null)
            {
                goto Label_00A9;
            }
            goto Label_008F;
        }

        private void x2855325f699de339(int xd3af97ef1b8243b3, int x1402a42b31a31090)
        {
            int num = (int) (xd3af97ef1b8243b3 * 1.5);
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_type", "rbfnetwork");
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_architecture", "?->GAUSSIAN(c=" + num + ")->?");
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_type", (x1402a42b31a31090 > 1) ? "rprop" : "svd");
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_type", (double) 0.01);
        }

        private void x40aa65188bc3f1f4(int xd3af97ef1b8243b3)
        {
            int num = (int) (xd3af97ef1b8243b3 * 1.5);
            while (true)
            {
                this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_type", "feedforward");
                if (this._x9b10ace6509508c0 == NormalizeRange.NegOne2One)
                {
                    this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_architecture", "?:B->TANH->" + num + ":B->TANH->?");
                }
                else
                {
                    this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_architecture", "?:B->SIGMOID->" + num + ":B->SIGMOID->?");
                }
                this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_type", "rprop");
                this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_targetError", (double) 0.01);
                if ((((uint) num) & 0) == 0)
                {
                    return;
                }
            }
        }

        private void x457a4b5397851b17()
        {
            AnalystSegregateTarget[] targetArray;
            if (!this._x613f2248b9e460bd)
            {
                AnalystSegregateTarget[] targetArray2 = new AnalystSegregateTarget[0];
                if (-2 != 0)
                {
                    this._x594135906c55045c.Segregate.SegregateTargets = targetArray2;
                    return;
                }
            }
            else
            {
                targetArray = new AnalystSegregateTarget[] { new AnalystSegregateTarget("FILE_TRAIN", 0x4b), new AnalystSegregateTarget("FILE_EVAL", 0x19) };
            }
            this._x594135906c55045c.Segregate.SegregateTargets = targetArray;
        }

        private void x8623f9a426a3d24c()
        {
            AnalystTask task2;
            AnalystTask task3;
            AnalystTask task4;
            AnalystTask task5;
            AnalystTask task6;
            AnalystTask task7;
            AnalystTask task = new AnalystTask("task-full");
            goto Label_033C;
        Label_0010:
            this._x594135906c55045c.AddTask(task5);
        Label_001D:
            this._x594135906c55045c.AddTask(task6);
            this._x594135906c55045c.AddTask(task7);
            if (0xff != 0)
            {
                return;
            }
            goto Label_00FB;
        Label_0046:
            this._x594135906c55045c.AddTask(task3);
            if (2 == 0)
            {
                goto Label_001D;
            }
        Label_0059:
            this._x594135906c55045c.AddTask(task4);
            if (0 == 0)
            {
                goto Label_0010;
            }
            if (3 != 0)
            {
                goto Label_00BF;
            }
        Label_0072:
            this._x594135906c55045c.AddTask(task2);
            if (0 == 0)
            {
                goto Label_0046;
            }
        Label_00BF:
            task5 = new AnalystTask("task-train");
            task5.Lines.Add("train");
            task6 = new AnalystTask("task-evaluate");
            task6.Lines.Add("evaluate");
            task7 = new AnalystTask("task-cluster") {
                Lines = { "cluster" }
            };
            this._x594135906c55045c.AddTask(task);
            if (-2147483648 != 0)
            {
                goto Label_0072;
            }
            goto Label_0046;
        Label_00FB:
            task4 = new AnalystTask("task-create");
            if (0 != 0)
            {
                goto Label_0046;
            }
            task4.Lines.Add("create");
            if (0 == 0)
            {
                goto Label_00BF;
            }
            goto Label_0010;
        Label_016F:
            task2.Lines.Add("generate");
            task3 = new AnalystTask("task-evaluate-raw") {
                Lines = { xe1c0f6103254de7f("ML:CONFIG_evalFile", "FILE_EVAL_NORM"), xe1c0f6103254de7f("NORMALIZE:CONFIG_sourceFile", "FILE_EVAL") }
            };
            task3.Lines.Add(xe1c0f6103254de7f("NORMALIZE:CONFIG_targetFile", "FILE_EVAL_NORM"));
            task3.Lines.Add("normalize");
            task3.Lines.Add("evaluate-raw");
            goto Label_00FB;
        Label_01CE:
            if (this._x613f2248b9e460bd)
            {
                task2.Lines.Add("segregate");
            }
            if (this._x7047063a9bee4054)
            {
                task2.Lines.Add("normalize");
                if (0 != 0)
                {
                    goto Label_00FB;
                }
                if (0 == 0)
                {
                    goto Label_016F;
                }
                if (0 == 0)
                {
                    goto Label_0223;
                }
            }
            else
            {
                goto Label_016F;
            }
        Label_0207:
            task2.Lines.Add("randomize");
            goto Label_01CE;
        Label_0223:
            task2 = new AnalystTask("task-generate");
            if (!this._x02283b983d652139)
            {
                if (this._x62451326f700d5c8)
                {
                    goto Label_0207;
                }
                if (0 != 0)
                {
                    goto Label_0307;
                }
            }
            goto Label_01CE;
        Label_0292:
            if (this._x7047063a9bee4054)
            {
                task.Lines.Add("normalize");
            }
            else if (2 == 0)
            {
                goto Label_0072;
            }
            task.Lines.Add("generate");
            task.Lines.Add("create");
            task.Lines.Add("train");
            if (2 == 0)
            {
                goto Label_0311;
            }
            task.Lines.Add("evaluate");
            if (15 == 0)
            {
                goto Label_0059;
            }
            if (8 != 0)
            {
                goto Label_0223;
            }
            goto Label_033C;
        Label_02C5:
            if (this._x613f2248b9e460bd)
            {
                task.Lines.Add("segregate");
            }
            goto Label_0292;
        Label_0307:
            if (this._x02283b983d652139)
            {
                goto Label_02C5;
            }
        Label_0311:
            if (!this._xc24b506a94383a44)
            {
                if (8 == 0)
                {
                    goto Label_0307;
                }
                if (0 != 0)
                {
                    goto Label_0292;
                }
            }
            else
            {
                task.Lines.Add("balance");
            }
            goto Label_02C5;
        Label_033C:
            if (this._x02283b983d652139)
            {
                goto Label_0307;
            }
            if (!this._x62451326f700d5c8)
            {
                if (0 == 0)
                {
                    goto Label_0307;
                }
            }
            else
            {
                task.Lines.Add("randomize");
            }
            if (0 == 0)
            {
                goto Label_0307;
            }
            goto Label_033C;
        }

        private void x9079d3066b3873db()
        {
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_type", "som");
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_architecture", "?->?");
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_type", "som-neighborhood");
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_arguments", "ITERATIONS=1000,NEIGHBORHOOD=rbf1d,RBF_TYPE=gaussian");
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_targetError", (double) 0.01);
        }

        private void x982be993d7259fbb()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("?->");
            builder.Append((this._x29c8e5bee3cb25f8 == AnalystGoal.Classification) ? "C" : "R");
            do
            {
                builder.Append("(type=new,kernel=rbf)->?");
                this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_type", "svm");
                this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_architecture", builder.ToString());
            }
            while (0 != 0);
            this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_type", "svm-search");
            if (3 != 0)
            {
                this._x594135906c55045c.Properties.SetProperty("ML:TRAIN_targetError", (double) 0.01);
            }
        }

        private void xa39295d07e81cd8c()
        {
            DataField[] fields;
            int num;
            DataField field;
            NormalizationAction singleField;
            bool flag;
            IList<AnalystField> normalizedFields = this._x594135906c55045c.Normalize.NormalizedFields;
            if ((((uint) num) - ((uint) flag)) >= 0)
            {
                normalizedFields.Clear();
                fields = this._x594135906c55045c.Fields;
                if (-2 == 0)
                {
                    goto Label_016B;
                }
                num = 0;
            }
            else
            {
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_00A4;
                }
                if (0 != 0)
                {
                    goto Label_016B;
                }
                goto Label_0138;
            }
        Label_0031:
            if (num < this._x594135906c55045c.Fields.Length)
            {
                field = fields[num];
                flag = num == (this._x594135906c55045c.Fields.Length - 1);
                if (((uint) num) >= 0)
                {
                    goto Label_0160;
                }
                goto Label_016B;
            }
            this._x594135906c55045c.Normalize.Init(this._x594135906c55045c);
            if (0 == 0)
            {
                return;
            }
            if ((((uint) num) + ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_0138;
            }
        Label_007B:
            singleField = NormalizationAction.Ignore;
            normalizedFields.Add(new AnalystField(singleField, field.Name));
        Label_0091:
            num++;
            if (3 != 0)
            {
                if (0 != 0)
                {
                    return;
                }
                goto Label_0031;
            }
            goto Label_0138;
        Label_00A4:
            singleField = NormalizationAction.OneOf;
            if ((((uint) flag) - ((uint) num)) < 0)
            {
                goto Label_00A4;
            }
        Label_00BF:
            normalizedFields.Add((this._x9b10ace6509508c0 == NormalizeRange.NegOne2One) ? new AnalystField(field.Name, singleField, 1.0, -1.0) : new AnalystField(field.Name, singleField, 1.0, 0.0));
            goto Label_0091;
        Label_0138:
            if (!field.Class)
            {
                goto Label_007B;
            }
            if (flag && this._x990368722123b229)
            {
                singleField = NormalizationAction.SingleField;
                goto Label_00BF;
            }
            if (field.ClassMembers.Count > 2)
            {
                singleField = NormalizationAction.Equilateral;
                goto Label_00BF;
            }
            goto Label_00A4;
        Label_0160:
            if (field.Integer)
            {
                goto Label_0203;
            }
        Label_016B:
            if (!field.Real)
            {
                goto Label_0138;
            }
        Label_0203:
            singleField = NormalizationAction.Normalize;
            while (this._x9b10ace6509508c0 != NormalizeRange.NegOne2One)
            {
                break;
            }
            AnalystField item = new AnalystField(field.Name, singleField, 1.0, -1.0);
            normalizedFields.Add(item);
            if ((((uint) num) | 0xfffffffe) == 0)
            {
                goto Label_0160;
            }
            item.ActualHigh = field.Max;
            item.ActualLow = field.Min;
            goto Label_0091;
        }

        private void xd60d4f24f6e3ffb5()
        {
            bool flag;
            DataField field5;
            int num;
            AnalystField field6;
            IList<AnalystField> normalizedFields = this._x594135906c55045c.Normalize.NormalizedFields;
            goto Label_04D7;
        Label_0050:
            if (this._x34231b3d9a1591be)
            {
                if (this._x0768e2edc97194de.Length != 0)
                {
                    goto Label_00A2;
                }
                goto Label_00BD;
            }
            if ((((uint) flag) | 4) != 0)
            {
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0105;
            }
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                goto Label_0102;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0050;
            }
        Label_00A2:
            if (this._x29c8e5bee3cb25f8 == AnalystGoal.Classification)
            {
                DataField field8 = this._x594135906c55045c.FindDataField(this._x0768e2edc97194de);
                this._x594135906c55045c.Properties.SetProperty("CLUSTER:CONFIG_clusters", field8.ClassMembers.Count);
                return;
            }
        Label_00BD:
            this._x594135906c55045c.Properties.SetProperty("CLUSTER:CONFIG_clusters", 2);
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_0050;
            }
            if ((((uint) flag) - ((uint) num)) <= uint.MaxValue)
            {
                return;
            }
        Label_0102:
            if (0 != 0)
            {
                goto Label_00BD;
            }
        Label_0105:
            if (field6 != null)
            {
                field6.Output = true;
            }
            goto Label_0050;
        Label_013E:
            field6 = null;
            if (-2147483648 != 0)
            {
                using (IEnumerator<AnalystField> enumerator3 = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                {
                    AnalystField field7;
                Label_0169:
                    if (enumerator3.MoveNext())
                    {
                        goto Label_01EE;
                    }
                    goto Label_0105;
                Label_017A:
                    if (field7.Action != NormalizationAction.Ignore)
                    {
                        goto Label_020C;
                    }
                    goto Label_0169;
                Label_0189:
                    while (field6.TimeSlice >= field7.TimeSlice)
                    {
                        if ((((uint) flag) | 3) != 0)
                        {
                            goto Label_01D1;
                        }
                    }
                Label_01B3:
                    field6 = field7;
                    if ((((uint) num) - ((uint) num)) < 0)
                    {
                        goto Label_020C;
                    }
                    goto Label_0169;
                Label_01D1:
                    if ((((uint) flag) - ((uint) num)) <= uint.MaxValue)
                    {
                        goto Label_0169;
                    }
                    goto Label_0105;
                Label_01EE:
                    field7 = enumerator3.Current;
                    if (((uint) flag) >= 0)
                    {
                        goto Label_017A;
                    }
                Label_020C:
                    if (!field7.Name.Equals(this._x0768e2edc97194de, StringComparison.InvariantCultureIgnoreCase))
                    {
                        goto Label_0169;
                    }
                    if (field6 == null)
                    {
                        goto Label_01B3;
                    }
                    goto Label_0189;
                }
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_038F;
                }
                goto Label_02ED;
            }
        Label_028A:
            num = field5.MinClassCount;
            this._x594135906c55045c.Properties.SetProperty("BALANCE:CONFIG_countPer", num);
            goto Label_013E;
        Label_02D9:
            if ((((uint) num) & 0) == 0)
            {
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_013E;
                }
                goto Label_038F;
            }
        Label_02ED:
            if (((uint) flag) < 0)
            {
                goto Label_04D7;
            }
            if (field5 != null)
            {
                if (!field5.Class)
                {
                    goto Label_013E;
                }
                goto Label_028A;
            }
            goto Label_02D9;
        Label_0337:
            this._x594135906c55045c.Properties.SetProperty("DATA:CONFIG_goal", this._x29c8e5bee3cb25f8);
            if (!this._x02283b983d652139)
            {
                if (this._xc24b506a94383a44)
                {
                    this._x594135906c55045c.Properties.SetProperty("BALANCE:CONFIG_balanceField", this._x0768e2edc97194de);
                    field5 = this._x554f16462d8d4675.Script.FindDataField(this._x0768e2edc97194de);
                    goto Label_02ED;
                }
            }
            else if (-2147483648 != 0)
            {
                goto Label_013E;
            }
            if ((((uint) flag) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_013E;
            }
            goto Label_02D9;
        Label_038F:
            if ((((uint) flag) + ((uint) num)) >= 0)
            {
                goto Label_0105;
            }
            return;
        Label_03AF:
            throw new AnalystError("Invalid target field: " + this._x0768e2edc97194de);
        Label_03CA:
            if (!flag)
            {
                throw new AnalystError("Can't determine target field automatically, please specify one.\nThis can also happen if you specified the wrong file format.");
            }
            goto Label_0337;
        Label_04D7:
            if (((((uint) num) - ((uint) num)) <= uint.MaxValue) && (this._x0768e2edc97194de.Trim().Length != 0))
            {
                if ((0x7fffffff != 0) && (this._x594135906c55045c.FindDataField(this._x0768e2edc97194de) != null))
                {
                    goto Label_0337;
                }
                goto Label_03AF;
            }
        Label_04F2:
            flag = false;
            if (this._x29c8e5bee3cb25f8 == AnalystGoal.Classification)
            {
                using (IEnumerator<AnalystField> enumerator = normalizedFields.GetEnumerator())
                {
                    AnalystField field;
                    DataField field2;
                    goto Label_051F;
                Label_0503:
                    if ((field.Action.IsClassify() || (8 == 0)) && field2.Class)
                    {
                        goto Label_052A;
                    }
                Label_051F:
                    if (enumerator.MoveNext())
                    {
                        goto Label_053A;
                    }
                    goto Label_03CA;
                Label_052A:
                    this._x0768e2edc97194de = field.Name;
                    flag = true;
                    goto Label_051F;
                Label_053A:
                    field = enumerator.Current;
                    field2 = this._x594135906c55045c.FindDataField(field.Name);
                    goto Label_0503;
                }
            }
            using (IEnumerator<AnalystField> enumerator2 = normalizedFields.GetEnumerator())
            {
                AnalystField field3;
                DataField field4;
            Label_0426:
                if (enumerator2.MoveNext())
                {
                    goto Label_049F;
                }
                goto Label_046D;
            Label_0434:
                if (field4.Class)
                {
                    goto Label_0426;
                }
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_04A8;
                }
            Label_0455:
                if (field4.Real || field4.Integer)
                {
                    goto Label_0487;
                }
                goto Label_0426;
            Label_046D:
                if ((((uint) flag) | 0xff) != 0)
                {
                    goto Label_03CA;
                }
                goto Label_0455;
            Label_0487:
                this._x0768e2edc97194de = field3.Name;
                flag = true;
                goto Label_0426;
            Label_049F:
                field3 = enumerator2.Current;
            Label_04A8:
                field4 = this._x594135906c55045c.FindDataField(field3.Name);
                goto Label_0434;
            }
            if ((((uint) num) - ((uint) flag)) >= 0)
            {
                if (0 != 0)
                {
                    goto Label_04F2;
                }
                goto Label_03CA;
            }
            goto Label_03AF;
        }

        private void xdd8dc65aef162a86()
        {
            string str2;
            string v = "FILE_RAW";
            if (0 != 0)
            {
                goto Label_00DC;
            }
            goto Label_02B8;
        Label_005C:
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_outputFile", "FILE_OUTPUT");
            goto Label_0134;
        Label_008B:
            this._x594135906c55045c.Properties.SetProperty("GENERATE:CONFIG_sourceFile", v);
            this._x594135906c55045c.Properties.SetProperty("GENERATE:CONFIG_targetFile", "FILE_TRAINSET");
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_trainingFile", "FILE_TRAINSET");
            this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_machineLearningFile", "FILE_ML");
            goto Label_005C;
        Label_00DC:
            this._x594135906c55045c.Properties.SetProperty("CLUSTER:CONFIG_type", "kmeans");
            if (0 != 0)
            {
                goto Label_0215;
            }
            goto Label_008B;
        Label_011B:
            this._x594135906c55045c.Properties.SetProperty("CLUSTER:CONFIG_sourceFile", str2);
            if (0 == 0)
            {
                this._x594135906c55045c.Properties.SetProperty("CLUSTER:CONFIG_targetFile", "FILE_CLUSTER");
                goto Label_00DC;
            }
        Label_0134:
            if (15 != 0)
            {
                if (0 == 0)
                {
                    this._x594135906c55045c.Properties.SetProperty("ML:CONFIG_evalFile", str2);
                    this._x594135906c55045c.Properties.SetProperty("SETUP:CONFIG_csvFormat", AnalystFileFormat.DecpntComma);
                    return;
                }
                goto Label_0240;
            }
            return;
        Label_0143:
            if (!this._x613f2248b9e460bd)
            {
            }
            str2 = (0x7fffffff == 0) ? "FILE_EVAL" : v;
            if (0 == 0)
            {
                if (this._x34231b3d9a1591be)
                {
                    goto Label_011B;
                }
                goto Label_008B;
            }
            if (0 == 0)
            {
                goto Label_011B;
            }
            return;
        Label_017C:
            v = "FILE_NORMALIZE";
            if (-1 == 0)
            {
                goto Label_0229;
            }
            this._x594135906c55045c.Properties.SetProperty("NORMALIZE:CONFIG_targetFile", v);
            this._x594135906c55045c.Normalize.MissingValues = this._x771edacf1be2c386;
            goto Label_0143;
        Label_01C3:
            if (!this._x7047063a9bee4054)
            {
                goto Label_0143;
            }
            this._x594135906c55045c.Properties.SetProperty("NORMALIZE:CONFIG_sourceFile", v);
            goto Label_017C;
        Label_01E2:
            if (this._x613f2248b9e460bd)
            {
                this._x594135906c55045c.Properties.SetProperty("SEGREGATE:CONFIG_sourceFile", v);
                v = "FILE_TRAIN";
                if (0 == 0)
                {
                    if (0xff == 0)
                    {
                        goto Label_01E2;
                    }
                    goto Label_01C3;
                }
                goto Label_021D;
            }
            if (0 == 0)
            {
                if (3 != 0)
                {
                    goto Label_01C3;
                }
                goto Label_028A;
            }
            goto Label_01E2;
        Label_0215:
            if (this._x02283b983d652139)
            {
                goto Label_0229;
            }
        Label_021D:
            if (this._xc24b506a94383a44)
            {
                goto Label_0240;
            }
            if (0 != 0)
            {
                goto Label_005C;
            }
            goto Label_01E2;
        Label_0229:
            if (4 != 0)
            {
                goto Label_01E2;
            }
            goto Label_021D;
        Label_0240:
            this._x594135906c55045c.Properties.SetProperty("BALANCE:CONFIG_sourceFile", v);
            v = "FILE_BALANCE";
            this._x594135906c55045c.Properties.SetProperty("BALANCE:CONFIG_targetFile", v);
            goto Label_01E2;
        Label_027D:
            if (!this._x02283b983d652139)
            {
                goto Label_02D1;
            }
            goto Label_0215;
        Label_028A:
            if (0 != 0)
            {
                goto Label_027D;
            }
            if (0 == 0)
            {
                goto Label_0215;
            }
        Label_02B8:
            this._x594135906c55045c.Properties.SetProperty("HEADER:DATASOURCE_rawFile", v);
            if (0 == 0)
            {
                goto Label_027D;
            }
        Label_02D1:
            if (!this._x62451326f700d5c8)
            {
                goto Label_0215;
            }
            this._x594135906c55045c.Properties.SetProperty("RANDOMIZE:CONFIG_sourceFile", "FILE_RAW");
            v = "FILE_RANDOMIZE";
            if (0 != 0)
            {
                goto Label_017C;
            }
            this._x594135906c55045c.Properties.SetProperty("RANDOMIZE:CONFIG_targetFile", v);
            if (-1 != 0)
            {
                goto Label_028A;
            }
            goto Label_01C3;
        }

        private static string xe1c0f6103254de7f(string x501caf5f649cf22e, string xa9e57b1de1a3ad36)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("set ");
            do
            {
                builder.Append(ScriptProperties.ToDots(x501caf5f649cf22e));
                builder.Append("=\"");
                builder.Append(xa9e57b1de1a3ad36);
            }
            while (-1 == 0);
            builder.Append("\"");
            return builder.ToString();
        }

        private void xf1bed93d6f997005()
        {
            this._x990368722123b229 = false;
            if ((this._xa24f4208aa2278f4 == WizardMethodType.SVM) || (this._xa24f4208aa2278f4 == WizardMethodType.SOM))
            {
                this._x990368722123b229 = true;
            }
        }

        private void xf6e1c35864db42aa(FileInfo x33b0dca1d2db0c5b)
        {
            ScriptProperties properties;
            this._x612bcf37596c363d = x33b0dca1d2db0c5b.Name;
            this._xbb5a08794aa6d723 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_norm").Name;
            goto Label_01BC;
        Label_0013:
            if (this._xc24b506a94383a44)
            {
                properties.SetFilename("FILE_BALANCE", this._x9097f279e99eb0be);
            }
            properties.SetFilename("FILE_TRAINSET", this._xedea45ae43322d49);
            properties.SetFilename("FILE_ML", this._x9f5087e4a335ff18);
            properties.SetFilename("FILE_OUTPUT", this._xe6d4a9d680176148);
            return;
        Label_006A:
            if (!this._x613f2248b9e460bd)
            {
                if (0 != 0)
                {
                    goto Label_006A;
                }
            }
            else
            {
                properties.SetFilename("FILE_TRAIN", this._xb577f44182f20fa3);
                if (3 == 0)
                {
                    goto Label_00F1;
                }
                properties.SetFilename("FILE_EVAL", this._x2329764ec876a018);
                properties.SetFilename("FILE_EVAL_NORM", this._x79f5154bafa879c9);
            }
            goto Label_0013;
        Label_00B9:
            if (0 != 0)
            {
                goto Label_01BC;
            }
            goto Label_006A;
        Label_00C1:
            if (this._x34231b3d9a1591be)
            {
                properties.SetFilename("FILE_CLUSTER", this._x6b465268cbeb5837);
                goto Label_00B9;
            }
            goto Label_006A;
        Label_00F1:
            if (!this._x7047063a9bee4054)
            {
                goto Label_0110;
            }
            if (0 != 0)
            {
                goto Label_01E8;
            }
        Label_00FF:
            properties.SetFilename("FILE_NORMALIZE", this._xbb5a08794aa6d723);
        Label_0110:
            if (!this._x62451326f700d5c8)
            {
                goto Label_00C1;
            }
            if (0 == 0)
            {
                properties.SetFilename("FILE_RANDOMIZE", this._x99f0b15384a590eb);
                goto Label_00C1;
            }
            goto Label_00B9;
        Label_01BC:
            this._x99f0b15384a590eb = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_random").Name;
            this._xb577f44182f20fa3 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_train").Name;
        Label_01E8:
            this._x2329764ec876a018 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_eval").Name;
            this._x79f5154bafa879c9 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_eval_norm").Name;
            this._xedea45ae43322d49 = FileUtil.ForceExtension(this._xb577f44182f20fa3, "egb");
            this._x9f5087e4a335ff18 = FileUtil.ForceExtension(this._xb577f44182f20fa3, "eg");
            this._xe6d4a9d680176148 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_output").Name;
            this._x9097f279e99eb0be = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_balance").Name;
            if (0x7fffffff != 0)
            {
                this._x6b465268cbeb5837 = FileUtil.AddFilenameBase(x33b0dca1d2db0c5b, "_cluster").Name;
                properties = this._x594135906c55045c.Properties;
                if (0 != 0)
                {
                    goto Label_00FF;
                }
                properties.SetFilename("FILE_RAW", this._x612bcf37596c363d);
                goto Label_00F1;
            }
            goto Label_0013;
        }

        private void xfd33c8a1cd5c5a19()
        {
            IList<AnalystField> list2;
            int num;
            int num2;
            IList<AnalystField> normalizedFields = this._x594135906c55045c.Normalize.NormalizedFields;
            if (((uint) num2) >= 0)
            {
                goto Label_017E;
            }
        Label_0026:
            using (IEnumerator<AnalystField> enumerator2 = normalizedFields.GetEnumerator())
            {
                AnalystField field4;
                AnalystField field6;
                goto Label_0049;
            Label_0032:
                if (!field4.Ignored && field4.Output)
                {
                    goto Label_00B1;
                }
            Label_0049:
                if (enumerator2.MoveNext())
                {
                    goto Label_00A3;
                }
                goto Label_0084;
            Label_0054:
                field6 = new AnalystField(field4);
                field6.TimeSlice = num2;
                AnalystField item = field6;
                list2.Add(item);
            Label_0072:
                num2++;
            Label_0078:
                if (num2 <= this._xb6540cd895237850)
                {
                    goto Label_0054;
                }
                goto Label_0049;
            Label_0084:
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_00C4;
                }
                goto Label_00A3;
            Label_009E:
                if (0 != 0)
                {
                    goto Label_0072;
                }
                goto Label_0078;
            Label_00A3:
                field4 = enumerator2.Current;
                goto Label_0032;
            Label_00B1:
                num2 = 1;
                goto Label_009E;
            }
        Label_00C4:
            using (IEnumerator<AnalystField> enumerator3 = normalizedFields.GetEnumerator())
            {
                AnalystField current;
                goto Label_00F5;
            Label_00D0:
                list2.Add(current);
                goto Label_00F5;
            Label_00DA:
                if (current.Ignored || (((uint) num2) < 0))
                {
                    goto Label_00D0;
                }
            Label_00F5:
                if (enumerator3.MoveNext())
                {
                    current = enumerator3.Current;
                    goto Label_00DA;
                }
            }
            normalizedFields.Clear();
            foreach (AnalystField field8 in normalizedFields)
            {
                normalizedFields.Add(field8);
            }
            return;
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_0026;
            }
            if (((uint) num) >= 0)
            {
                return;
            }
        Label_017E:
            list2 = new List<AnalystField>();
            using (IEnumerator<AnalystField> enumerator = normalizedFields.GetEnumerator())
            {
                AnalystField field;
                AnalystField field2;
                AnalystField field3;
                goto Label_01B7;
            Label_018E:
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_026B;
                }
                list2.Add(field);
                goto Label_01B7;
            Label_01AC:
                if (field.Input)
                {
                    goto Label_026B;
                }
            Label_01B7:
                if (enumerator.MoveNext())
                {
                    goto Label_0276;
                }
                goto Label_0026;
            Label_01C5:
                if (num < this._x654428e3563552e3)
                {
                    goto Label_0215;
                }
                goto Label_01B7;
            Label_01D0:
                if (!field.Ignored)
                {
                    goto Label_0260;
                }
                goto Label_018E;
            Label_01DF:
                if ((((uint) num2) - ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_01AC;
                }
            Label_01F7:
                list2.Add(field2);
                num++;
                if (1 != 0)
                {
                    goto Label_01C5;
                }
                goto Label_0026;
            Label_020F:
                field2 = field3;
                goto Label_01DF;
            Label_0215:
                field3 = new AnalystField(field);
                field3.TimeSlice = -num;
                field3.Output = false;
                if ((((uint) num2) | uint.MaxValue) == 0)
                {
                    goto Label_01F7;
                }
                if ((((uint) num2) | 1) != 0)
                {
                    goto Label_020F;
                }
                goto Label_026B;
            Label_0260:
                if (!this._x0236ea04f9fa4aaa)
                {
                    goto Label_01AC;
                }
            Label_026B:
                num = 0;
                goto Label_01C5;
            Label_0276:
                field = enumerator.Current;
                goto Label_01D0;
            }
            if ((((uint) num2) + ((uint) num)) < 0)
            {
                return;
            }
            goto Label_0026;
        }

        public AnalystGoal Goal
        {
            get
            {
                return this._x29c8e5bee3cb25f8;
            }
            set
            {
                this._x29c8e5bee3cb25f8 = value;
            }
        }

        public bool IncludeTargetField
        {
            get
            {
                return this._x0236ea04f9fa4aaa;
            }
            set
            {
                this._x0236ea04f9fa4aaa = value;
            }
        }

        public int LagWindowSize
        {
            get
            {
                return this._x654428e3563552e3;
            }
            set
            {
                this._x654428e3563552e3 = value;
            }
        }

        public int LeadWindowSize
        {
            get
            {
                return this._xb6540cd895237850;
            }
            set
            {
                this._xb6540cd895237850 = value;
            }
        }

        public WizardMethodType MethodType
        {
            get
            {
                return this._xa24f4208aa2278f4;
            }
            set
            {
                this._xa24f4208aa2278f4 = value;
            }
        }

        public IHandleMissingValues Missing
        {
            get
            {
                return this._x771edacf1be2c386;
            }
            set
            {
                this._x771edacf1be2c386 = value;
            }
        }

        public NormalizeRange Range
        {
            get
            {
                return this._x9b10ace6509508c0;
            }
            set
            {
                this._x9b10ace6509508c0 = value;
            }
        }

        public string TargetField
        {
            get
            {
                return this._x0768e2edc97194de;
            }
            set
            {
                this._x0768e2edc97194de = value;
            }
        }

        public bool TaskBalance
        {
            get
            {
                return this._xc24b506a94383a44;
            }
            set
            {
                this._xc24b506a94383a44 = value;
            }
        }

        public bool TaskCluster
        {
            get
            {
                return this._x34231b3d9a1591be;
            }
            set
            {
                this._x34231b3d9a1591be = value;
            }
        }

        public bool TaskNormalize
        {
            get
            {
                return this._x7047063a9bee4054;
            }
            set
            {
                this._x7047063a9bee4054 = value;
            }
        }

        public bool TaskRandomize
        {
            get
            {
                return this._x62451326f700d5c8;
            }
            set
            {
                this._x62451326f700d5c8 = value;
            }
        }

        public bool TaskSegregate
        {
            get
            {
                return this._x613f2248b9e460bd;
            }
            set
            {
                this._x613f2248b9e460bd = value;
            }
        }
    }
}

