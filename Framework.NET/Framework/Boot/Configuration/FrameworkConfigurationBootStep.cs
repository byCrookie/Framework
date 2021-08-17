using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Framework.Boot.Configuration.Mapping;
using Framework.Workflow;
using Framework.Xml;

namespace Framework.Boot.Configuration
{
    internal class FrameworkConfigurationBootStep<TContext, TConfig> : IFrameworkConfigurationBootStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, IBootContext
    {
        private readonly IFrameworkConfigurationMapper _frameworkConfigurationMapper;
        private readonly IXmlSerializer _xmlSerializer;
        private FrameworkBootStepConfiguration _bootStepConfiguration;

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
            var config = _xmlSerializer.Deserialize<XmlFrameworkConfiguration>(File.ReadAllText($@"{assemblyRootPath}\{_bootStepConfiguration.ConfigurationFile}"));

            var bootContext = context as IBootContext;
            bootContext.FrameworkConfiguration = _frameworkConfigurationMapper.Map(config);
            
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        public void SetConfig(Action<TConfig> configure)
        {
            var configuration = Activator.CreateInstance<TConfig>();
            configure?.Invoke(configuration);
            _bootStepConfiguration = configuration as FrameworkBootStepConfiguration;
        }
    }
}