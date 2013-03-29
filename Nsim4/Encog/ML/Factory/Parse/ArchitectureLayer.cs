namespace Encog.ML.Factory.Parse
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ArchitectureLayer
    {
        private readonly IDictionary<string, string> _x290a8cdbc9dbb3c1 = new Dictionary<string, string>();
        [CompilerGenerated]
        private string x35b9a94250058afe;
        [CompilerGenerated]
        private bool x3fbab20f23d5eadf;
        [CompilerGenerated]
        private bool xa7871e78d6c521ec;
        [CompilerGenerated]
        private int xc281c1a56ad963f7;

        public bool Bias
        {
            [CompilerGenerated]
            get
            {
                return this.xa7871e78d6c521ec;
            }
            [CompilerGenerated]
            set
            {
                this.xa7871e78d6c521ec = value;
            }
        }

        public int Count
        {
            [CompilerGenerated]
            get
            {
                return this.xc281c1a56ad963f7;
            }
            [CompilerGenerated]
            set
            {
                this.xc281c1a56ad963f7 = value;
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

        public IDictionary<string, string> Params
        {
            get
            {
                return this._x290a8cdbc9dbb3c1;
            }
        }

        public bool UsedDefault
        {
            [CompilerGenerated]
            get
            {
                return this.x3fbab20f23d5eadf;
            }
            [CompilerGenerated]
            set
            {
                this.x3fbab20f23d5eadf = value;
            }
        }
    }
}

