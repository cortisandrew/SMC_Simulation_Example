// See https://aka.ms/new-console-template for more information
using SMC_Simulation_Example;

Console.WriteLine("Hello, World!");

int[] problemSizes = new int[] { 100, 10000, 1000000 };

ISimulation simulation = new CoinGameSimulation();
MonteCarloDriver driver = new MonteCarloDriver(simulation);

foreach (int n in problemSizes)
{
    // Run the simulation MANY times
    driver.RunSimulations(n);
    double estimatedMean = driver.EstimatedMean();
    Console.WriteLine($"Estimated expected winnings (or loss) for {n} simulations: {estimatedMean}");
}
