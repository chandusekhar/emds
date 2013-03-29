namespace Encog.App.Analyst.CSV.Segregate
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SegregateCSV : BasicFile
    {
        private readonly IList<SegregateTargetPercent> _x2ea7a1eff81ae7c0 = new List<SegregateTargetPercent>();
        public const int TotalPct = 100;

        public void Analyze(FileInfo inputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            do
            {
                base.ExpectInputHeaders = headers;
                base.InputFormat = format;
            }
            while ((((uint) headers) + ((uint) headers)) < 0);
            base.Analyzed = true;
            base.PerformBasicCounts();
            this.xae1ebc39c039dcb2();
        }

        public void Process()
        {
            ReadCSV dcsv;
            this.x461c3bf969128260();
        Label_0006:
            dcsv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            base.ResetStatus();
            using (IEnumerator<SegregateTargetPercent> enumerator = this._x2ea7a1eff81ae7c0.GetEnumerator())
            {
                SegregateTargetPercent percent;
                StreamWriter writer;
                goto Label_0044;
            Label_0038:
                if (0 != 0)
                {
                    goto Label_00D1;
                }
            Label_003E:
                writer.Close();
            Label_0044:
                if (enumerator.MoveNext())
                {
                    goto Label_00D1;
                }
                if (0 == 0)
                {
                    goto Label_00EE;
                }
                if (0 == 0)
                {
                    goto Label_00D1;
                }
                if (0 == 0)
                {
                    goto Label_00BC;
                }
                if (0 == 0)
                {
                    goto Label_0098;
                }
                goto Label_003E;
            Label_0067:
                if (percent.NumberRemaining > 0)
                {
                    goto Label_0086;
                }
                if (0 == 0)
                {
                    goto Label_00B9;
                }
                goto Label_0098;
            Label_0075:
                percent.NumberRemaining--;
            Label_0083:
                if (0 == 0)
                {
                    goto Label_0067;
                }
            Label_0086:
                if (!dcsv.Next() || base.ShouldStop())
                {
                    goto Label_003E;
                }
            Label_0098:
                base.UpdateStatus(false);
                LoadedRow row = new LoadedRow(dcsv);
                base.WriteRow(writer, row);
                if (4 == 0)
                {
                    goto Label_0083;
                }
                goto Label_0075;
            Label_00B9:
                if (0 == 0)
                {
                    goto Label_00CE;
                }
            Label_00BC:
                writer = base.PrepareOutputFile(percent.Filename);
                goto Label_0067;
            Label_00CE:
                if (0 == 0)
                {
                    goto Label_0038;
                }
            Label_00D1:
                percent = enumerator.Current;
                goto Label_00BC;
            }
        Label_00EE:
            base.ReportDone(false);
            if (0 != 0)
            {
                goto Label_0006;
            }
            dcsv.Close();
        }

        private void x461c3bf969128260()
        {
            int num;
            base.ValidateAnalyzed();
            if (this._x2ea7a1eff81ae7c0.Count < 1)
            {
                throw new QuantError("There are no segregation targets.");
            }
            do
            {
                while (this._x2ea7a1eff81ae7c0.Count < 2)
                {
                    throw new QuantError("There must be at least two segregation targets.");
                }
                num = 0;
            }
            while ((((uint) num) & 0) != 0);
            foreach (SegregateTargetPercent percent in this._x2ea7a1eff81ae7c0)
            {
                num += percent.Percent;
            }
            if (num != 100)
            {
                throw new QuantError("Target percents must equal 100.");
            }
        }

        private void xae1ebc39c039dcb2()
        {
            SegregateTargetPercent percent = null;
            int num3;
            if ((((uint) num3) & 0) == 0)
            {
                int num = 0;
                using (IEnumerator<SegregateTargetPercent> enumerator = this._x2ea7a1eff81ae7c0.GetEnumerator())
                {
                    SegregateTargetPercent percent2;
                    SegregateTargetPercent percent3;
                    double num2;
                Label_0037:
                    if (enumerator.MoveNext())
                    {
                        goto Label_011E;
                    }
                    int num4 = base.RecordCount - num;
                    if ((num4 > 0) && (percent != null))
                    {
                        percent.NumberRemaining += num4;
                        if ((((uint) num) - ((uint) num3)) > uint.MaxValue)
                        {
                        }
                    }
                    return;
                Label_0048:
                    if ((((uint) num2) - ((uint) num2)) > uint.MaxValue)
                    {
                        goto Label_006C;
                    }
                Label_0060:
                    num += num3;
                    goto Label_0037;
                Label_006C:
                    if (0 != 0)
                    {
                        goto Label_0083;
                    }
                    goto Label_0060;
                Label_0073:
                    if (percent.Percent > percent3.Percent)
                    {
                        goto Label_00BA;
                    }
                    goto Label_006C;
                Label_0083:
                    if ((((uint) num2) + ((uint) num4)) < 0)
                    {
                        goto Label_0073;
                    }
                    if ((((uint) num3) | uint.MaxValue) == 0)
                    {
                    }
                    goto Label_0048;
                Label_00BA:
                    percent = percent3;
                    goto Label_013D;
                Label_00C1:
                    if (percent == null)
                    {
                        goto Label_00BA;
                    }
                    goto Label_0128;
                Label_00C6:
                    if (1 == 0)
                    {
                        goto Label_011E;
                    }
                    goto Label_0104;
                Label_00CF:
                    percent3 = percent2;
                    if (0 != 0)
                    {
                        goto Label_006C;
                    }
                    num2 = ((double) percent3.Percent) / 100.0;
                    num3 = (int) (base.RecordCount * num2);
                    if (0 != 0)
                    {
                        goto Label_006C;
                    }
                    percent3.NumberRemaining = num3;
                    goto Label_00C6;
                Label_0104:
                    if ((((uint) num3) | uint.MaxValue) != 0)
                    {
                        goto Label_00C1;
                    }
                    goto Label_0128;
                Label_011E:
                    percent2 = enumerator.Current;
                    goto Label_00CF;
                Label_0128:
                    if (((uint) num2) >= 0)
                    {
                        goto Label_0073;
                    }
                Label_013D:
                    if ((((uint) num2) - ((uint) num4)) >= 0)
                    {
                        goto Label_0083;
                    }
                    goto Label_0048;
                }
            }
        }

        public IList<SegregateTargetPercent> Targets
        {
            get
            {
                return this._x2ea7a1eff81ae7c0;
            }
        }
    }
}

