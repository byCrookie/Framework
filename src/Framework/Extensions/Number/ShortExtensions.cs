namespace Framework.Extensions.Number;

public static class ShortExtensions
{
    public static bool IsBetweenInclusive(this short number, short min, short max)
    {
        return number >= min && number <= max;
    }
        
    public static bool IsBetweenExclusive(this short number, short min, short max)
    {
        return number > min && number < max;
    }
}