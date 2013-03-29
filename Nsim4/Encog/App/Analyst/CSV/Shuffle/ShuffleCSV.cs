namespace Encog.App.Analyst.CSV.Shuffle
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.MathUtil.Randomize;
    using Encog.Util.CSV;
    using System;
    using System.IO;

    public class ShuffleCSV : BasicFile
    {
        private LoadedRow[] _x5cafa8d49ea71ea1;
        private int _x77dede646085d71e;
        private int _xb85b7645153fc718;
        public const int DefaultBufferSize = 0x1388;

        public ShuffleCSV()
        {
            this.BufferSize = 0x1388;
        }

        public void Analyze(FileInfo inputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            base.Analyzed = true;
            base.PerformBasicCounts();
        }

        public void Process(FileInfo outputFile)
        {
            base.ValidateAnalyzed();
            ReadCSV dcsv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            if (0 == 0)
            {
                LoadedRow row;
                StreamWriter tw = base.PrepareOutputFile(outputFile);
                base.ResetStatus();
                while ((row = this.x75f8dae9674cb841(dcsv)) != null)
                {
                    base.WriteRow(tw, row);
                    base.UpdateStatus(false);
                }
                base.ReportDone(false);
                tw.Close();
            }
            dcsv.Close();
        }

        private LoadedRow x75f8dae9674cb841(ReadCSV xe4aa442e12986e06)
        {
            int num;
            LoadedRow row;
            if (this._x77dede646085d71e == 0)
            {
                this.xc4041c33ab048f27(xe4aa442e12986e06);
            }
            while (this._x77dede646085d71e > 0)
            {
                num = RangeRandomizer.RandomInt(0, this._xb85b7645153fc718 - 1);
                do
                {
                    if (this._x5cafa8d49ea71ea1[num] != null)
                    {
                        goto Label_0053;
                    }
                }
                while ((((uint) num) - ((uint) num)) > uint.MaxValue);
            }
            if (0xff != 0)
            {
                if (15 != 0)
                {
                    return null;
                }
                goto Label_0053;
            }
        Label_003C:
            this._x77dede646085d71e--;
            return row;
        Label_0053:
            row = this._x5cafa8d49ea71ea1[num];
            this._x5cafa8d49ea71ea1[num] = null;
            goto Label_003C;
        }

        private void xc4041c33ab048f27(ReadCSV xe4aa442e12986e06)
        {
            int num2;
            int index = 0;
            goto Label_0092;
        Label_0018:
            this._x77dede646085d71e = num2;
            if (8 != 0)
            {
                if (0 == 0)
                {
                    if ((((uint) index) + ((uint) index)) >= 0)
                    {
                        return;
                    }
                    goto Label_0092;
                }
                goto Label_006F;
            }
            goto Label_0048;
        Label_003E:
            if (!xe4aa442e12986e06.Next())
            {
                goto Label_0018;
            }
        Label_0028:
            if (15 != 0)
            {
                if ((num2 < this._xb85b7645153fc718) && !base.ShouldStop())
                {
                    LoadedRow row = new LoadedRow(xe4aa442e12986e06);
                    if (0 == 0)
                    {
                        this._x5cafa8d49ea71ea1[num2++] = row;
                        goto Label_003E;
                    }
                    goto Label_0028;
                }
                goto Label_0018;
            }
        Label_0048:
            index++;
        Label_004C:
            if (index >= this._x5cafa8d49ea71ea1.Length)
            {
                num2 = 0;
                goto Label_003E;
            }
        Label_006F:
            this._x5cafa8d49ea71ea1[index] = null;
            goto Label_0048;
        Label_0092:
            if (((uint) num2) < 0)
            {
                goto Label_003E;
            }
            goto Label_004C;
        }

        public int BufferSize
        {
            get
            {
                return this._xb85b7645153fc718;
            }
            set
            {
                this._xb85b7645153fc718 = value;
                this._x5cafa8d49ea71ea1 = new LoadedRow[this._xb85b7645153fc718];
            }
        }
    }
}

