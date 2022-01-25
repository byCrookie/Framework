namespace Framework.Throttle;

public class ThrottleLimit
{
    public ThrottleLimit(int weight)
    {
        Weight = weight;
        Limit = 1000;
        Period = 60;
    }

    public ThrottleLimit(int weight, int limit, int period)
    {
        Weight = weight;
        Limit = limit;
        Period = period;
    }

    public int Weight { get; }
    public int Limit { get; }
    public int Period { get; }
}