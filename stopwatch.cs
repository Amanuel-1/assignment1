using System;
using System.Threading;
using System.Threading.Tasks;

public class Stopwatch
{
    // Fields
    private TimeSpan _timeElapsed;
    private bool _isRunning;
    private CancellationTokenSource _cancellationTokenSource;

    // Events
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    // Properties
    public TimeSpan TimeElapsed => _timeElapsed;
    public bool IsRunning => _isRunning;

    // Delegate
    public delegate void StopwatchEventHandler(string message);

    // Methods
    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _cancellationTokenSource = new CancellationTokenSource();
            OnStarted?.Invoke("Stopwatch Started!");
            StartTicking(_cancellationTokenSource.Token);
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            _cancellationTokenSource.Cancel();
            OnStopped?.Invoke($"Stopwatch Stopped! Time elapsed: {_timeElapsed.TotalSeconds} seconds.");
        }
    }

    public void Reset()
    {
        if (_isRunning)
            Stop();

        _timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void StartTicking(CancellationToken token)
    {
        // Run ticking on a separate thread
        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);  // 1 second delay
                _timeElapsed = _timeElapsed.Add(TimeSpan.FromSeconds(1));
            }
        }, token);
    }
}
