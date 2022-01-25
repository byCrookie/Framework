namespace Framework.Validation;

public static class Validate
{
    public static void NotNull<T>(T value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException($"{name} can not be null", name);
        }
    }

    public static void NotEmpty<T>(IEnumerable<T> value, string name)
    {
        if (value is null || !value.Any())
        {
            throw new ArgumentException($"{name} can not be null");
        }
    }

    public static void IsTrue(bool value, string name)
    {
        if (!value)
        {
            throw new ArgumentException($"{name} is not true");
        }
    }
}