namespace Encog.ML.Data.Buffer
{
    using Encog;
    using Encog.ML.Data.Buffer.CODEC;
    using System;
    using System.Runtime.CompilerServices;

    public class BinaryDataLoader
    {
        private readonly IDataSetCODEC _x75d376891c19d365;
        [CompilerGenerated]
        private IStatusReportable x23bce9651860d8f2;

        public BinaryDataLoader(IDataSetCODEC codec)
        {
            this._x75d376891c19d365 = codec;
            this.Status = new NullStatusReportable();
        }

        public void Binary2External(string binaryFile)
        {
            EncogEGBFile file;
            int inputCount;
            int idealCount;
            double[] numArray;
            double[] numArray2;
            int num3;
            int num5;
            int num6;
            int num7;
            this.Status.Report(0, 0, "Exporting binary file: " + binaryFile);
            if (0 == 0)
            {
                file = new EncogEGBFile(binaryFile);
                goto Label_0283;
            }
            goto Label_0256;
        Label_008A:
            if (num5 < file.NumberOfRecords)
            {
                num6 = 0;
                if ((((uint) num3) - ((uint) idealCount)) >= 0)
                {
                    goto Label_01BF;
                }
                goto Label_0210;
            }
            file.Close();
            this._x75d376891c19d365.Close();
            this.Status.Report(0, 0, "Done exporting binary file: " + binaryFile);
            return;
        Label_0105:
            if (num7 < idealCount)
            {
                goto Label_0142;
            }
            if ((((uint) num7) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_016E;
            }
        Label_0122:
            num7 = 0;
            goto Label_0105;
        Label_0142:
            numArray2[num7] = file.Read();
        Label_014D:
            num7++;
            if ((((uint) num7) | 0xfffffffe) != 0)
            {
                if ((((uint) num6) + ((uint) num6)) > uint.MaxValue)
                {
                    if ((((uint) num7) - ((uint) num3)) < 0)
                    {
                        goto Label_0283;
                    }
                    goto Label_0142;
                }
                goto Label_0105;
            }
        Label_016E:
            if (((uint) num3) >= 0)
            {
                goto Label_0244;
            }
            if ((((uint) num5) | 2) != 0)
            {
                goto Label_01FD;
            }
            if (((uint) num7) >= 0)
            {
                goto Label_01C6;
            }
        Label_01BF:
            while (num6 < inputCount)
            {
                numArray[num6] = file.Read();
                num6++;
            }
            goto Label_0210;
        Label_01C6:
            if (((uint) idealCount) < 0)
            {
                goto Label_014D;
            }
            goto Label_008A;
        Label_01FD:
            numArray2 = new double[idealCount];
            num3 = 0;
            int num4 = 0;
            num5 = 0;
            goto Label_01C6;
        Label_0210:
            if ((((uint) num5) | 15) != 0)
            {
                goto Label_0122;
            }
        Label_0244:
            if (((uint) num7) <= uint.MaxValue)
            {
                double significance = file.Read();
                this._x75d376891c19d365.Write(numArray, numArray2, significance);
                num3++;
                if ((((uint) num5) | uint.MaxValue) == 0)
                {
                    goto Label_01FD;
                }
                num4++;
                if (num4 >= 0x2710)
                {
                    num4 = 0;
                    if ((((uint) num4) + ((uint) num5)) < 0)
                    {
                        goto Label_0142;
                    }
                    this.Status.Report(file.NumberOfRecords, num3, "Exporting...");
                }
                num5++;
                goto Label_008A;
            }
        Label_0256:
            this._x75d376891c19d365.PrepareWrite(file.NumberOfRecords, file.InputCount, file.IdealCount);
            inputCount = file.InputCount;
            idealCount = file.IdealCount;
            numArray = new double[inputCount];
            goto Label_01FD;
        Label_0283:
            file.Open();
            goto Label_0256;
        }

        public void External2Binary(string binaryFile)
        {
            EncogEGBFile file;
            double[] numArray;
            double[] numArray2;
            int num;
            int num2;
            double num3;
            this.Status.Report(0, 0, "Importing to binary file: " + binaryFile);
            goto Label_0106;
        Label_0038:
            file.Write(num3);
        Label_0040:
            if (this._x75d376891c19d365.Read(numArray, numArray2, ref num3))
            {
                file.Write(numArray);
                file.Write(numArray2);
                num++;
                num2++;
            }
            else
            {
                file.Close();
                this._x75d376891c19d365.Close();
                this.Status.Report(0, 0, "Done importing to binary file: " + binaryFile);
                return;
            }
        Label_0082:
            if (num2 >= 0x2710)
            {
                do
                {
                    num2 = 0;
                }
                while (0 != 0);
                this.Status.Report(0, num, "Importing...");
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_0082;
                }
            }
            else
            {
                goto Label_0038;
            }
            if ((((uint) num) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_010D;
            }
            goto Label_0038;
        Label_0106:
            file = new EncogEGBFile(binaryFile);
        Label_010D:
            file.Create(this._x75d376891c19d365.InputSize, this._x75d376891c19d365.IdealSize);
            numArray = new double[this._x75d376891c19d365.InputSize];
            numArray2 = new double[this._x75d376891c19d365.IdealSize];
            this._x75d376891c19d365.PrepareRead();
            num = 0;
            num2 = 0;
            if ((((uint) num2) + ((uint) num2)) >= 0)
            {
                num3 = 0.0;
                goto Label_0040;
            }
            goto Label_0106;
        }

        public IDataSetCODEC CODEC
        {
            get
            {
                return this._x75d376891c19d365;
            }
        }

        public IStatusReportable Status
        {
            [CompilerGenerated]
            get
            {
                return this.x23bce9651860d8f2;
            }
            [CompilerGenerated]
            set
            {
                this.x23bce9651860d8f2 = value;
            }
        }
    }
}

