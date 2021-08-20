namespace Framework.Extensions.Number
{
    public static class LongExtensions
    {
        public static bool IsBetweenInclusive(this long number, long min, long max)
        {
            return number >= min && number <= max;
        }
        
        public static bool IsBetweenExclusive(this long number, long min, long max)
        {
            return number > min && number < max;
        }
    }
}