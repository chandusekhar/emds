namespace Encog.Util.DownSample
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class RGBDownsample : IDownSample
    {
        private double _x2aded78bbc8d0650;
        private int _xa5c509adf8efeaa0;
        private int _xb28e4e0b2e9dba92;
        private double _xb89e2fc16b0143df;
        private int _xbe5a6d6d9543eee2;
        private int _xd2611dcb50ae5373;
        private int _xd6294999bbdff9e4;
        private int _xe7b61809d0fd41ca;
        [CompilerGenerated]
        private int x0d64337dd578ecc0;
        [CompilerGenerated]
        private int x132068c85a97bbc8;
        [CompilerGenerated]
        private int x370710e6280c960e;
        [CompilerGenerated]
        private int[] x469a062ebb8666fc;
        [CompilerGenerated]
        private Bitmap x8b558391133fb123;

        public virtual double[] DownSample(Bitmap image, int height, int width)
        {
            double[] numArray;
            int num;
            int num2;
            int num3;
            this.Image = image;
            if (((uint) num3) >= 0)
            {
                this.ProcessImage(image);
                goto Label_00E8;
            }
            goto Label_003D;
        Label_001E:
            if (num2 < height)
            {
                num3 = 0;
                goto Label_0085;
            }
            if ((((uint) num) + ((uint) num3)) <= uint.MaxValue)
            {
                return numArray;
            }
        Label_003D:
            if ((((uint) height) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_00E8;
            }
            numArray[num++] = this.CurrentBlue;
            if ((((uint) num) + ((uint) height)) < 0)
            {
                return numArray;
            }
            num3++;
        Label_0085:
            if (num3 >= width)
            {
                num2++;
                goto Label_001E;
            }
            this.DownSampleRegion(num3, num2);
            numArray[num++] = this.CurrentRed;
            if (((uint) num) < 0)
            {
                goto Label_001E;
            }
            numArray[num++] = this.CurrentGreen;
            goto Label_003D;
        Label_00E8:
            numArray = new double[(height * width) * 3];
            this._xb89e2fc16b0143df = ((double) (this._xbe5a6d6d9543eee2 - this._xa5c509adf8efeaa0)) / ((double) width);
            this._x2aded78bbc8d0650 = ((double) (this._xd6294999bbdff9e4 - this._xe7b61809d0fd41ca)) / ((double) height);
            if ((((uint) num3) - ((uint) width)) >= 0)
            {
                num = 0;
                num2 = 0;
                goto Label_001E;
            }
            goto Label_003D;
        }

        public void DownSampleRegion(int x, int y)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int num = this._xa5c509adf8efeaa0 + ((int) (x * this._xb89e2fc16b0143df));
            int num2 = this._xe7b61809d0fd41ca + ((int) (y * this._x2aded78bbc8d0650));
            if ((((uint) num7) - ((uint) num10)) > uint.MaxValue)
            {
                goto Label_01E6;
            }
            goto Label_01F1;
        Label_0062:
            if (num9 < num4)
            {
                num10 = num;
                goto Label_00B4;
            }
            if (((uint) num9) > uint.MaxValue)
            {
                return;
            }
            this.CurrentRed = num5 / num8;
            if ((((uint) num9) - ((uint) num10)) <= uint.MaxValue)
            {
                goto Label_0101;
            }
        Label_00A2:
            if (((uint) num8) < 0)
            {
                goto Label_00F9;
            }
        Label_00B4:
            if (num10 < num3)
            {
                Color pixel = this.Image.GetPixel(num10, num9);
                num5 += pixel.R;
                num6 += pixel.G;
                num7 += pixel.B;
                if ((((uint) num2) | 3) != 0)
                {
                    if ((((uint) num5) - ((uint) num7)) <= uint.MaxValue)
                    {
                        if (((uint) num3) > uint.MaxValue)
                        {
                            return;
                        }
                        goto Label_00F9;
                    }
                    if (((uint) num2) <= uint.MaxValue)
                    {
                        goto Label_01F1;
                    }
                    goto Label_01C9;
                }
                if ((((uint) num4) - ((uint) x)) < 0)
                {
                    goto Label_0062;
                }
                goto Label_0195;
            }
            if ((((uint) num7) - ((uint) num)) >= 0)
            {
                num9++;
                if ((((uint) num9) & 0) != 0)
                {
                    goto Label_00A2;
                }
                goto Label_0062;
            }
            goto Label_0101;
        Label_00F9:
            num8++;
            num10++;
            if ((((uint) num9) - ((uint) num5)) >= 0)
            {
                goto Label_00A2;
            }
        Label_0101:
            if ((((uint) num5) | 3) != 0)
            {
                this.CurrentGreen = num6 / num8;
                this.CurrentBlue = num7 / num8;
                if (((uint) num4) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_00F9;
            }
            return;
        Label_0195:
            num9 = num2;
            goto Label_0062;
        Label_01C9:
            num3 = Math.Min(this._xb28e4e0b2e9dba92, num3);
            num4 = Math.Min(this._xd2611dcb50ae5373, num4);
            num5 = 0;
        Label_01E6:
            num6 = 0;
            num7 = 0;
            num8 = 0;
            goto Label_0195;
        Label_01F1:
            num3 = num + ((int) this._xb89e2fc16b0143df);
            num4 = num2 + ((int) this._x2aded78bbc8d0650);
            goto Label_01C9;
        }

        public void FindBounds()
        {
            int num2;
            int num3;
            int num = 0;
            while (num < this._xd2611dcb50ae5373)
            {
                if (!this.xc7e385f8fd8856df(num))
                {
                    this._xe7b61809d0fd41ca = num;
                    goto Label_00E1;
                }
                num++;
            }
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_00E1;
            }
            goto Label_014C;
        Label_001F:
            num3++;
        Label_0023:
            if (num3 < this._xb28e4e0b2e9dba92)
            {
                if (this.xb62a16ea0e9c8e4a(num3))
                {
                    if (0x7fffffff == 0)
                    {
                        goto Label_0091;
                    }
                    goto Label_001F;
                }
                this._xa5c509adf8efeaa0 = num3;
            }
            int num4 = this._xb28e4e0b2e9dba92 - 1;
            while (num4 >= 0)
            {
                if (!this.xb62a16ea0e9c8e4a(num4) && ((((uint) num4) + ((uint) num2)) >= 0))
                {
                    this._xbe5a6d6d9543eee2 = num4;
                    return;
                }
                num4--;
                if (0 != 0)
                {
                    goto Label_001F;
                }
            }
            return;
        Label_005D:
            num3 = 0;
            goto Label_0023;
        Label_0091:
            num2--;
            if (((((uint) num4) + ((uint) num3)) >= 0) && ((((uint) num3) + ((uint) num)) > uint.MaxValue))
            {
                goto Label_00EC;
            }
        Label_00C5:
            if (num2 >= 0)
            {
                goto Label_00EC;
            }
            if ((((uint) num3) + ((uint) num4)) <= uint.MaxValue)
            {
                goto Label_014C;
            }
        Label_00E1:
            num2 = this._xd2611dcb50ae5373 - 1;
            goto Label_00C5;
        Label_00EC:
            if (this.xc7e385f8fd8856df(num2))
            {
                goto Label_0091;
            }
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                this._xd6294999bbdff9e4 = num2;
                goto Label_005D;
            }
        Label_014C:
            if (((uint) num) >= 0)
            {
                goto Label_005D;
            }
        }

        public void ProcessImage(Bitmap image)
        {
            this.Image = image;
            this._xd2611dcb50ae5373 = this.Image.Height;
            this._xb28e4e0b2e9dba92 = this.Image.Width;
            if (0 == 0)
            {
                this._xa5c509adf8efeaa0 = 0;
                this._xe7b61809d0fd41ca = 0;
                this._xbe5a6d6d9543eee2 = this._xb28e4e0b2e9dba92;
            }
            this._xd6294999bbdff9e4 = this._xd2611dcb50ae5373;
            this._xb89e2fc16b0143df = ((double) (this._xbe5a6d6d9543eee2 - this._xa5c509adf8efeaa0)) / ((double) this.ImageWidth);
            this._x2aded78bbc8d0650 = ((double) (this._xd6294999bbdff9e4 - this._xe7b61809d0fd41ca)) / ((double) this.ImageHeight);
        }

        private bool xb62a16ea0e9c8e4a(int x08db3aeabb253cb1)
        {
            Color pixel;
            int y = 0;
            goto Label_003C;
        Label_0004:
            return false;
        Label_0018:
            if (y < this._xd2611dcb50ae5373)
            {
                pixel = this.Image.GetPixel(x08db3aeabb253cb1, y);
            }
            else
            {
                return true;
            }
        Label_0027:
            if (pixel.R >= 250)
            {
                if ((pixel.G < 250) || (pixel.B < 250))
                {
                    goto Label_0004;
                }
                y++;
                goto Label_0018;
            }
            if (3 != 0)
            {
                goto Label_0004;
            }
        Label_003C:
            if ((((uint) y) + ((uint) y)) < 0)
            {
                goto Label_0027;
            }
            goto Label_0018;
        }

        private bool xc7e385f8fd8856df(int x1e218ceaee1bb583)
        {
            int x = 0;
            if (0 == 0)
            {
                goto Label_0019;
            }
            if (((uint) x1e218ceaee1bb583) >= 0)
            {
                goto Label_0046;
            }
        Label_0015:
            x++;
        Label_0019:
            if (x < this._xb28e4e0b2e9dba92)
            {
                Color pixel = this.Image.GetPixel(x, x1e218ceaee1bb583);
                if (pixel.R >= 250)
                {
                    if (pixel.G < 250)
                    {
                        goto Label_0046;
                    }
                }
                else
                {
                    goto Label_0046;
                }
                if (pixel.B < 250)
                {
                    goto Label_0046;
                }
                goto Label_0015;
            }
            return true;
        Label_0046:
            return false;
        }

        public int CurrentBlue
        {
            [CompilerGenerated]
            get
            {
                return this.x370710e6280c960e;
            }
            [CompilerGenerated]
            set
            {
                this.x370710e6280c960e = value;
            }
        }

        public int CurrentGreen
        {
            [CompilerGenerated]
            get
            {
                return this.x132068c85a97bbc8;
            }
            [CompilerGenerated]
            set
            {
                this.x132068c85a97bbc8 = value;
            }
        }

        public int CurrentRed
        {
            [CompilerGenerated]
            get
            {
                return this.x0d64337dd578ecc0;
            }
            [CompilerGenerated]
            set
            {
                this.x0d64337dd578ecc0 = value;
            }
        }

        public int DownSampleBottom
        {
            get
            {
                return this._xd6294999bbdff9e4;
            }
        }

        public int DownSampleLeft
        {
            get
            {
                return this._xa5c509adf8efeaa0;
            }
        }

        public int DownSampleRight
        {
            get
            {
                return this._xbe5a6d6d9543eee2;
            }
        }

        public int DownSampleTop
        {
            get
            {
                return this._xe7b61809d0fd41ca;
            }
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

        public int ImageHeight
        {
            get
            {
                return this._xd2611dcb50ae5373;
            }
        }

        public int ImageWidth
        {
            get
            {
                return this._xb28e4e0b2e9dba92;
            }
        }

        public int[] PixelMap
        {
            [CompilerGenerated]
            get
            {
                return this.x469a062ebb8666fc;
            }
            [CompilerGenerated]
            set
            {
                this.x469a062ebb8666fc = value;
            }
        }

        public double RatioX
        {
            get
            {
                return this._xb89e2fc16b0143df;
            }
        }

        public double RatioY
        {
            get
            {
                return this._x2aded78bbc8d0650;
            }
        }
    }
}

