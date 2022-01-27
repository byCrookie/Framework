namespace Framework.Jab.Boot.Jab.Registration;

public class JabBootStepOptions
{
    public JabBootStepOptions()
    {
        Jab = new JabBuilder();
    }
        
    public JabBuilder Jab { get; }
}