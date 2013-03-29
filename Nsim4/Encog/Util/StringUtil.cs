namespace Encog.Util
{
    using System;
    using System.Text;

    public class StringUtil
    {
        public static bool EqualsIgnoreCase(string a, string b)
        {
            return a.Equals(b, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string FromBytes(byte[] b)
        {
            byte[] bytes = new byte[b.Length * 2];
            for (int i = 0; i < b.Length; i++)
            {
                bytes[i * 2] = b[i];
                if ((((uint) i) - ((uint) i)) > uint.MaxValue)
                {
                    break;
                }
                bytes[(i * 2) + 1] = 0;
            }
            return new UnicodeEncoding().GetString(bytes, 0, bytes.Length);
        }
    }
}

