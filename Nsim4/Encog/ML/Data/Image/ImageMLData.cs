namespace Encog.ML.Data.Image
{
    using Encog.ML.Data.Basic;
    using Encog.Util.DownSample;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class ImageMLData : BasicMLData
    {
        [CompilerGenerated]
        private Bitmap x8b558391133fb123;

        public ImageMLData(Bitmap image) : base(1)
        {
            this.Image = image;
        }

        public void Downsample(IDownSample downsampler, bool findBounds, int height, int width, double hi, double lo)
        {
            double[] numArray;
            int num;
            if (!findBounds)
            {
                goto Label_004B;
            }
            if (0 == 0)
            {
                goto Label_0033;
            }
        Label_0006:
            if (num < numArray.Length)
            {
                goto Label_005F;
            }
            this.Data = numArray;
            if ((((uint) width) - ((uint) height)) >= 0)
            {
                return;
            }
        Label_0033:
            if (((uint) num) < 0)
            {
                goto Label_005F;
            }
            downsampler.FindBounds();
        Label_004B:
            numArray = downsampler.DownSample(this.Image, height, width);
            num = 0;
            goto Label_0006;
        Label_005F:
            numArray[num] = (((numArray[num] - 0.0) / 255.0) * (hi - lo)) + lo;
            num++;
            goto Label_0006;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("[ImageNeuralData:");
            int index = 0;
            if ((((uint) index) | 2) != 0)
            {
                goto Label_0020;
            }
        Label_001C:
            index++;
        Label_0020:
            if (index < this.Data.Length)
            {
                if (index != 0)
                {
                    builder.Append(',');
                }
                builder.Append(this.Data[index]);
                goto Label_001C;
            }
            builder.Append("]");
            return builder.ToString();
        }

        public Bitmap Image
        {
            [CompilerGenerated]
            get
            {
                return this.x8b558391133fb123;
            }
            [CompilerGenerated]
            set
            {
                this.x8b558391133fb123 = value;
            }
        }
    }
}

