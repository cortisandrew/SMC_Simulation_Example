using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Simulation_Example
{
    public interface ISimulation
    {
        /// <summary>
        /// Run a single simulation
        /// </summary>
        /// <returns>Return the result of the simulation</returns>
        double Simulate();
    }
}
