namespace Encog.Util.DownSample
{
    using System;
    using System.Drawing;

    public interface IDownSample
    {
        double[] DownSample(Bitmap image, int height, int width);
        void FindBounds();
        void ProcessImage(Bitmap image);

        int DownSampleBottom { get; }

        int DownSampleLeft { get; }

        int DownSampleRight { get; }

        int DownSampleTop { get; }

        int ImageHeight { get; }

        int ImageWidth { get; }

        int[] PixelMap { get; }

        double RatioX { get; }

        double RatioY { get; }
    }
}

