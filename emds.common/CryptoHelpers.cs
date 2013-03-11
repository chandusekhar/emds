using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace emds.common
{
    public static class CryptoHelpers
    {
        public static string GetShaHash(string value)
        {
            var data = Encoding.UTF8.GetBytes(value);
            var hashData = new SHA1Managed().ComputeHash(data);
            return hashData.Aggregate(string.Empty, (current, b) => current + b.ToString("X2"));
        }
    }
}
