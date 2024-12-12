namespace System;

public static class DateTimeExtensions
{
    public static double ToMillisecondTimestamp(this DateTime dateTime)
    {
        var timeSpan = dateTime - DateTime.UnixEpoch;
        return Math.Floor(timeSpan.TotalMilliseconds);
    }

    public static int ToMinutesSinceMidnight(this DateTime dateTime) =>
        (dateTime.Hour * 60) + dateTime.Minute;

    public static int ToSecondsSinceMidnight(this DateTime dateTime) =>
        (ToMinutesSinceMidnight(dateTime) * 60) + dateTime.Second;
}
