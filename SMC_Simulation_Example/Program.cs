// See https://aka.ms/new-console-template for more information
using SMC_Simulation_Example;

Console.WriteLine("Hello, World!");

// Run the simulation MANY times
int n = 10000000;

ISimulation simulation = new CoinGameSimulation();

List<double> results = new List<double>();

for (int i = 0; i < n; i++)
{
    results.Add(simulation.Simulate());
}

Console.WriteLine($"Estimated expected winnings (or loss): {results.Average()}");
