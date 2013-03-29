namespace Encog.App.Analyst.CSV.Basic
{
    using System;
    using System.Runtime.CompilerServices;

    public class BaseCachedColumn
    {
        private double[] _x4a3f0a05c02f235f;
        [CompilerGenerated]
        private bool x1dc8708cd2b20f01;
        [CompilerGenerated]
        private string x35b9a94250058afe;
        [CompilerGenerated]
        private bool x9eec85b7c94f6aea;
        [CompilerGenerated]
        private bool xa2a5882c61e298f7;

        public BaseCachedColumn(string theName, bool theInput, bool theOutput)
        {
            this.Name = theName;
            this.Input = theInput;
            this.Output = theOutput;
            this.Ignore = false;
        }

        public void Allocate(int length)
        {
            this._x4a3f0a05c02f235f = new double[length];
        }

        public double[] Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
        }

        public bool Ignore
        {
            [CompilerGenerated]
            get
            {
                return this.x1dc8708cd2b20f01;
            }
            [CompilerGenerated]
            set
            {
                this.x1dc8708cd2b20f01 = value;
            }
        }

        public bool Input
        {
            [CompilerGenerated]
            get
            {
                return this.x9eec85b7c94f6aea;
            }
            [CompilerGenerated]
            set
            {
                this.x9eec85b7c94f6aea = value;
            }
        }

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return this.x35b9a94250058afe;
            }
            [CompilerGenerated]
            set
            {
                this.x35b9a94250058afe = value;
            }
        }

        public bool Output
        {
            [CompilerGenerated]
            get
            {
                return this.xa2a5882c61e298f7;
            }
            [CompilerGenerated]
            set
            {
                this.xa2a5882c61e298f7 = value;
            }
        }
    }
}

