using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Simulation_Example
{
    public class MonteCarloDriver
    {
        private ISimulation _simulator;
        private List<double> _results = new List<double>();

        public MonteCarloDriver(ISimulation simulator)
        {
            _simulator = simulator;
        }

        public void RunSimulations(int n)
        {
            _results.Clear();
            for (int i = 0; i < n; i++)
            {
                _results.Add(_simulator.Simulate());
            }
        }

        public double EstimatedMean()         {
            if (_results.Count == 0)
            {
                throw new InvalidOperationException("No simulations have been run.");
            }

            double mean = 0.0;
            // mean = _results.Average();

            for (int i = 0; i < _results.Count; i++)
            {
              mean += _results[i];
            }
            mean /= _results.Count;

            return mean;
        }
    }
}
