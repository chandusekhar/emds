namespace Encog.Parse.Tags.Read
{
    using System;
    using System.IO;

    public class ReadHTML : ReadTags
    {
        public ReadHTML(Stream istream) : base(istream)
        {
        }

        protected string ParseAttributeName()
        {
            return base.ParseAttributeName().ToLower();
        }
    }
}

