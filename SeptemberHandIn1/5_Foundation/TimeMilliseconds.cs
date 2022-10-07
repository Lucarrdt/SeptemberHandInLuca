using System.Diagnostics;
namespace SeptemberHandIn1._5_Foundation;

public static class TimeMilliseconds
{
    public static long GetMilliseconds()
    {
        double elapsedTime = Stopwatch.GetTimestamp();
        double milliseconds = (elapsedTime / Stopwatch.Frequency) * 1000;
        
        return (long)milliseconds;
    }
}