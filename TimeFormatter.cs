public static class TimeFormatter
{
    public static string FormatTime(TimeSpan time)
    {
        return $"{time.Minutes:D2}:{time.Seconds:D2}:{time.Milliseconds / 10:D2}";
    }
}
