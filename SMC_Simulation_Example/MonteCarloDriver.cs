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
        private List<double> _yi = new List<double>();

        public MonteCarloDriver(ISimulation simulator)
        {
            _simulator = simulator;
        }

        public void RunSimulations(long n)
        {
            // TODO: Known issue! List cannot accept length greater than int.MaxValue
            if (n > int.MaxValue)
            {
                throw new OverflowException("Number of simulations exceeds int.MaxValue");
            }

            _yi.Clear();
            for (long i = 0; i < n; i++)
            {
                _yi.Add(_simulator.Simulate());
            }
        }

        public double EstimatedMean()         {
            if (_yi.Count == 0)
            {
                throw new InvalidOperationException("No simulations have been run.");
            }

            double mean = 0.0;
            // mean = _results.Average();

            // TODO: Known issue! List cannot accept length greater than int.MaxValue
            for (int i = 0; i < _yi.Count; i++)
            {
              mean += _yi[i];
            }
            mean /= _yi.Count;

            return mean;
        }

        /// <summary>
        /// sigma^2 hat
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double EstimatedVariance()
        {
            if (_yi.Count == 0)
            {
                throw new InvalidOperationException("No simulations have been run.");
            }

            double mean = EstimatedMean();
            double variance = 0.0;
            for (int i = 0; i < _yi.Count; i++)
            {
                variance += (_yi[i] - mean) * (_yi[i] - mean);
            }
            variance /= (_yi.Count - 1); // Sample variance
            return variance;
        }

        /// <summary>
        /// sigma hat
        /// </summary>
        /// <returns></returns>
        public double EstimatedStandardDeviation()
        {
            double variance = EstimatedVariance();
            return Math.Sqrt(variance);
        }

        /// <summary>
        /// Estimated (because we are estimating the variance and std deviation
        /// </summary>
        /// <returns></returns>
        public double RMSE()
        {
            return EstimatedStandardDeviation() / Math.Sqrt(_yi.Count);
        }

        public long EstimateRequiredSimulations(double RMSE_Target)
        {
            // TODO: Check for overflows when converting to long
            double variance = EstimatedVariance();
            double n_required_double = variance / (RMSE_Target * RMSE_Target);
            if (n_required_double > long.MaxValue)
            {
                throw new OverflowException("Estimated required simulations exceed long.MaxValue");
            }

            long n_required = (long)Math.Ceiling(variance / (RMSE_Target * RMSE_Target));
            return n_required;
        }
    }
}
