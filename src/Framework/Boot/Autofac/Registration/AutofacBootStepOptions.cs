namespace Framework.Boot.Autofac.Registration;

public class AutofacBootStepOptions
{
    public AutofacBootStepOptions()
    {
        Autofac = new AutofacBuilder();
    }
        
    public AutofacBuilder Autofac { get; set; }
}