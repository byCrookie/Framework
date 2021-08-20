using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Core.Resolving.Pipeline;

namespace Framework.Boot.Logger
{
    internal class Log4NetMiddlewareModule : Module
    {
        private readonly IResolveMiddleware _middleware;

        public Log4NetMiddlewareModule(IResolveMiddleware middleware)
        {
            _middleware = middleware;
        }

        protected override void AttachToComponentRegistration(
            IComponentRegistryBuilder componentRegistryBuilder,
            IComponentRegistration registration)
        {
            registration.PipelineBuilding += (_, pipeline) => { pipeline.Use(_middleware); };
        }
    }
}