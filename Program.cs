using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the Stopwatch object
        var stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        // Main loop for user input
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Stopwatch Application");
            Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset.");
            Console.WriteLine($"Current Time: {stopwatch.TimeElapsed.Seconds} seconds");
            Console.WriteLine($"Stopwatch Running: {stopwatch.IsRunning}");
            Console.WriteLine("Press 'Q' to Quit.");

            var input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.S)
            {
                stopwatch.Start();
            }
            else if (input == ConsoleKey.T)
            {
                stopwatch.Stop();
            }
            else if (input == ConsoleKey.R)
            {
                stopwatch.Reset();
            }
            else if (input == ConsoleKey.Q)
            {
                break;
            }
        }
    }
}
