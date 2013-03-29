namespace Encog.Util.DownSample
{
    using System;
    using System.Drawing;

    public class SimpleIntensityDownsample : RGBDownsample
    {
        public override double[] DownSample(Bitmap image, int height, int width)
        {
            base.Image = image;
            while (true)
            {
                int num;
                int num2;
                int num3;
                if (((uint) num3) >= 0)
                {
                }
                base.ProcessImage(image);
                double[] numArray = new double[(height * width) * 3];
                if ((((uint) width) + ((uint) num2)) <= uint.MaxValue)
                {
                    num = 0;
                    num2 = 0;
                }
                while (num2 < height)
                {
                    for (num3 = 0; num3 < width; num3++)
                    {
                        base.DownSampleRegion(num3, num2);
                        numArray[num++] = ((base.CurrentRed + base.CurrentBlue) + base.CurrentGreen) / 3;
                    }
                    num2++;
                }
                if ((((uint) width) | 0xfffffffe) != 0)
                {
                    return numArray;
                }
            }
        }
    }
}

