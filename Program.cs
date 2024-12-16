using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // the Stopwatch object
        var stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        // Start the real-time display task
        var displayTokenSource = new CancellationTokenSource();
        StartRealTimeDisplay(stopwatch, displayTokenSource.Token);

        // Main loop for user input
        while (true)
        {
            Console.WriteLine("Stopwatch Application");
            Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset.");
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
                stopwatch.Stop();
                displayTokenSource.Cancel(); 
                break;
            }
        }
    }

    static void StartRealTimeDisplay(Stopwatch stopwatch, CancellationToken token)
    {
        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.Clear();
                Console.WriteLine("Stopwatch Application");
                Console.WriteLine($"Current Time: {TimeFormatter.FormatTime(stopwatch.TimeElapsed)}");
                Console.WriteLine($"Stopwatch Running: {stopwatch.IsRunning}");
                Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset, 'Q' to Quit.");
                Thread.Sleep(500); // refresh every 500 milliseconds
            }
        }, token);
    }
}
