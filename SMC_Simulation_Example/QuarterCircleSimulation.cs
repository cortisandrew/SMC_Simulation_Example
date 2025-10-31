using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Simulation_Example
{
    public class QuarterCircleSimulation : ISimulation
    {
        static Random random = new Random();

        public double Simulate()
        {
            double x = random.NextDouble(); // returns a value between 0 and 1
            double y = random.NextDouble();

            // check whether (x,y) is on unit circle
            if (x*x + y*y < 1)
            {
                // point lies on unit circle
                return 1;
            }
            else
            {
                // point lies outside unit circle
                return 0;
            }
        }
    }
}
