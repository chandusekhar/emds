namespace Encog.MathUtil
{
    using System;
    using System.Runtime.CompilerServices;

    public class LinearCongruentialGenerator
    {
        public const long MaxRand = 0xffffffffL;
        [CompilerGenerated]
        private long x389cfddf2753f097;
        [CompilerGenerated]
        private long x47bfa89900345bd6;
        [CompilerGenerated]
        private long x50c413ca91542f17;
        [CompilerGenerated]
        private long xef2ea9135a94e86d;

        public LinearCongruentialGenerator(long seed) : this((long) Math.Pow(2.0, 32.0), 0x41c64e6dL, 0x3039L, seed)
        {
        }

        public LinearCongruentialGenerator(long modulus, long multiplier, long increment, long seed)
        {
            this.Modulus = modulus;
            this.Multiplier = multiplier;
            this.Increment = increment;
            this.Seed = seed;
        }

        public double NextDouble()
        {
            return (((double) this.NextLong()) / 4294967295);
        }

        public long NextLong()
        {
            this.Seed = ((this.Multiplier * this.Seed) + this.Increment) % this.Modulus;
            return this.Seed;
        }

        public double Range(double min, double max)
        {
            double num = max - min;
            return ((num * this.NextDouble()) + min);
        }

        public long Increment
        {
            [CompilerGenerated]
            get
            {
                return this.x389cfddf2753f097;
            }
            [CompilerGenerated]
            set
            {
                this.x389cfddf2753f097 = value;
            }
        }

        public long Modulus
        {
            [CompilerGenerated]
            get
            {
                return this.x50c413ca91542f17;
            }
            [CompilerGenerated]
            set
            {
                this.x50c413ca91542f17 = value;
            }
        }

        public long Multiplier
        {
            [CompilerGenerated]
            get
            {
                return this.xef2ea9135a94e86d;
            }
            [CompilerGenerated]
            set
            {
                this.xef2ea9135a94e86d = value;
            }
        }

        public long Seed
        {
            [CompilerGenerated]
            get
            {
                return this.x47bfa89900345bd6;
            }
            [CompilerGenerated]
            set
            {
                this.x47bfa89900345bd6 = value;
            }
        }
    }
}

