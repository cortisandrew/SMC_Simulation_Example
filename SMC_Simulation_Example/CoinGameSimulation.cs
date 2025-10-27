using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Simulation_Example
{
    public class CoinGameSimulation : ISimulation
    {
        static Random random = new Random();

        public double Simulate()
        {
            double result = double.MinValue;

            bool isHeadsCoinOne = false;
            bool isHeadsCoinTwo = false;

            // if our uniform random number, is greater than 0.5 (0.5 probability)
            if (random.NextDouble() > 0.5)
            {
                isHeadsCoinOne = true;
            }

            if (random.NextDouble() > 0.5)
            {
                isHeadsCoinTwo = true;
            }

            if (isHeadsCoinOne && isHeadsCoinTwo) // HH
            {
                result = 3.5;
            }
            else if ((isHeadsCoinOne && !isHeadsCoinTwo) || (!isHeadsCoinOne && isHeadsCoinTwo)) // HT or TH
            {
                result = -1;
            }
            else // TT
            {
                result = -2;
            }

            return result;
        }
    }
}
