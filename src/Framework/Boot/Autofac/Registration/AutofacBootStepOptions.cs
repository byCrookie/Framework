namespace Framework.Boot.Autofac.Registration
{
    public abstract class AutofacBootStepOptions
    {
        protected AutofacBootStepOptions()
        {
            Autofac = new AutofacBuilder();
        }
        
        public AutofacBuilder Autofac { get; set; }
    }
}