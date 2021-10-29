using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Framework.Boot.Configuration.Mapping;
using Framework.Xml;
using Workflow;

namespace Framework.Boot.Configuration
{
    internal class FrameworkConfigurationBootStep<TContext, TOptions> : IFrameworkConfigurationBootStep<TContext, TOptions>
        where TContext : WorkflowBaseContext, IBootContext
    {
        private readonly IFrameworkConfigurationMapper _frameworkConfigurationMapper;
        private readonly IXmlSerializer _xmlSerializer;
        private FrameworkBootStepOptions _bootStepOptions;

        public FrameworkConfigurationBootStep(
            IXmlSerializer xmlSerializer,
            IFrameworkConfigurationMapper frameworkConfigurationMapper)
        {
            _xmlSerializer = xmlSerializer;
            _frameworkConfigurationMapper = frameworkConfigurationMapper;
        }

        public Task ExecuteAsync(TContext context)
        {
            var assemblyRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var config = _xmlSerializer.Deserialize<XmlFrameworkConfiguration>(File.ReadAllText($@"{assemblyRootPath}\{_bootStepOptions.ConfigurationFile}"));

            var bootContext = context as IBootContext;
            bootContext.FrameworkConfiguration = _frameworkConfigurationMapper.Map(config);
            
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        public void SetOptions(TOptions options)
        {
            _bootStepOptions = options as FrameworkBootStepOptions;
        }
    }
}