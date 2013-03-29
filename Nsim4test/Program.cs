using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsim4test
{
    class Program
    {
        static void Main(string[] args)
        {
            Nsim.Calculator.NetworkCalculator calc = Nsim.Calculator.NetworkCalculator.LoadFromFile(@"..\..\..\NeuralNetworks\Cardiology\инфаркт_миокарда.np4");

            Console.WriteLine("D");
        }
    }
}
