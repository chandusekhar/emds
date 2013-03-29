namespace Encog.ML.Data.Image
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Util.DownSample;
    using System;
    using System.Collections.Generic;

    public class ImageMLDataSet : BasicMLDataSet
    {
        public const string MUST_USE_IMAGE = "This data set only supports ImageNeuralData or Image objects.";
        private readonly IDownSample x0677e4dbe212e9d2;
        private readonly bool x103ca6537af9d723;
        private readonly double x20133758a5984793;
        private int x4d5aabc7a55b12ba;
        private readonly double x8948c4575e007d39;
        private int x9b0739496f8b5475;

        public ImageMLDataSet(IDownSample downsampler, bool findBounds, double hi, double lo)
        {
            if (((uint) lo) >= 0)
            {
                goto Label_005F;
            }
        Label_0018:
            if ((((uint) lo) + ((uint) lo)) >= 0)
            {
                this.x4d5aabc7a55b12ba = -1;
                this.x9b0739496f8b5475 = -1;
            }
            this.x20133758a5984793 = hi;
            this.x8948c4575e007d39 = lo;
            if (((uint) hi) <= uint.MaxValue)
            {
                return;
            }
        Label_005F:
            this.x0677e4dbe212e9d2 = downsampler;
            this.x103ca6537af9d723 = findBounds;
            if ((((uint) lo) - ((uint) findBounds)) > uint.MaxValue)
            {
                return;
            }
            goto Label_0018;
        }

        public override void Add(IMLData data)
        {
            if (!(data is ImageMLData))
            {
                throw new NeuralNetworkError("This data set only supports ImageNeuralData or Image objects.");
            }
            base.Add(data);
        }

        public override void Add(IMLDataPair inputData)
        {
            if (!(inputData.Input is ImageMLData))
            {
                throw new NeuralNetworkError("This data set only supports ImageNeuralData or Image objects.");
            }
            base.Add(inputData);
        }

        public override void Add(IMLData inputData, IMLData idealData)
        {
            if (!(inputData is ImageMLData))
            {
                throw new NeuralNetworkError("This data set only supports ImageNeuralData or Image objects.");
            }
            base.Add(inputData, idealData);
        }

        public void Downsample(int height, int width)
        {
            this.x4d5aabc7a55b12ba = height;
            this.x9b0739496f8b5475 = width;
            using (IEnumerator<IMLDataPair> enumerator = base.GetEnumerator())
            {
                IMLDataPair current;
                goto Label_0062;
            Label_0017:
                if (!(current.Input is ImageMLData))
                {
                    throw new NeuralNetworkError("Invalid class type found in ImageNeuralDataSet, only ImageNeuralData items are allowed.");
                }
                ImageMLData input = (ImageMLData) current.Input;
                if (0xff == 0)
                {
                    goto Label_0017;
                }
                input.Downsample(this.x0677e4dbe212e9d2, this.x103ca6537af9d723, height, width, this.x20133758a5984793, this.x8948c4575e007d39);
            Label_0062:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    goto Label_0017;
                }
            }
        }

        public int Height
        {
            get
            {
                return this.x4d5aabc7a55b12ba;
            }
        }

        public int Width
        {
            get
            {
                return this.x9b0739496f8b5475;
            }
        }
    }
}

