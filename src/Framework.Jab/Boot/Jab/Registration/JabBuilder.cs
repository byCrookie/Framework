namespace Framework.Jab.Boot.Jab.Registration;

public class JabBuilder
{
    public JabBuilder SetServiceProvider(DefaultServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        return this;
    }

    public DefaultServiceProvider ServiceProvider { get; set; } = null!;
}