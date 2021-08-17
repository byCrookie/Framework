namespace Framework.Extensions.Number
{
    public static class IntExtensions
    {
        public static bool IsBetweenInclusive(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }
        
        public static bool IsBetweenExclusive(this int number, int min, int max)
        {
            return number > min && number < max;
        }
    }
}