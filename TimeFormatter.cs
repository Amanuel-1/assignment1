using System;

public static class TimeFormatter
{
    public static string FormatTime(TimeSpan time)
    {
        return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
    }
}
