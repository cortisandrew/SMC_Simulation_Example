// See https://aka.ms/new-console-template for more information
using SMC_Simulation_Example;

Console.WriteLine("Hello, World!");

long[] problemSizes = new long[] { 100, 10000, 1000000 };

ISimulation simulation = new CoinGameSimulation();
MonteCarloDriver driver = new MonteCarloDriver(simulation);

foreach (long n in problemSizes)
{
    // Run the simulation MANY times
    driver.RunSimulations(n);
    double estimatedMean = driver.EstimatedMean();
    Console.WriteLine($"Estimated expected winnings (or loss) for {n} simulations: {estimatedMean}");
    Console.WriteLine($"Estimated variance for {n} simulations: {driver.EstimatedVariance()}");
    Console.WriteLine($"Estimated RMSE for {n} simulations: {driver.RMSE()}");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine();
}

double RMSE_target = 0.00001;
Console.WriteLine($"Estimated number of simluations to obtain an RMSE of {RMSE_target} is {driver.EstimateRequiredSimulations(RMSE_target)}");
