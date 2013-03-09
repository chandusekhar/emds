using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emds.common;

namespace emds.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = new np4load(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");
            tmp.GetNeuralNetwork();
        }
    }
}
