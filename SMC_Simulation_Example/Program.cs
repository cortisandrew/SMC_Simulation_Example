// See https://aka.ms/new-console-template for more information
using SMC_Simulation_Example;

Console.WriteLine("Hello, World!");

// CoinGame();

long[] problemSizes = new long[] { 100, 10000, 1000000 };

ISimulation simulation = new QuarterCircleSimulation();
MonteCarloDriver driver = new MonteCarloDriver(simulation);

foreach (long n in problemSizes)
{
    driver.RunSimulations(n);

    Console.WriteLine($"Using {n} simulations, the estimate for the area of the quarter circle is: {driver.EstimatedMean()}");
    Console.WriteLine($"We can use this value to estimate Pi: {driver.EstimatedMean() * 4}");
    Console.WriteLine($"The estimated RMSE (for quarter circle) is {driver.RMSE()} " +
        $"and the error for Pi is {Math.PI - (driver.EstimatedMean() * 4)}");
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();
}

static void CoinGame()
{
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
}
