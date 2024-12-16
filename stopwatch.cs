using System;
using System.Threading;

public class Stopwatch
{
    // Fields
    private TimeSpan _timeElapsed;
    private bool _isRunning;

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
            OnStarted?.Invoke("Stopwatch Started!");
            StartTicking();
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            OnStopped?.Invoke($"Stopwatch Stopped! Time elapsed: {_timeElapsed.TotalSeconds} seconds.");
        }
    }

    public void Reset()
    {
        _timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void StartTicking()
    {
        // Simulate ticking every second when the stopwatch is running
        while (_isRunning)
        {
            Thread.Sleep(1000);  // 1 second delay
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromSeconds(1));
        }
    }
}
