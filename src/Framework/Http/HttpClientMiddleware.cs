using Autofac;
using Autofac.Core;
using Autofac.Core.Resolving.Pipeline;

namespace Framework.Http;

public class HttpClientMiddleware<TService> : IResolveMiddleware
{
    private readonly Action<HttpClient> _clientConfigurator;

    public HttpClientMiddleware(Action<HttpClient> clientConfigurator)
    {
        _clientConfigurator = clientConfigurator;
    }

    public PipelinePhase Phase => PipelinePhase.ParameterSelection;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        if (context.Registration.Activator.LimitType == typeof(TService))
        {
            context.ChangeParameters(context.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, _) => p.ParameterType == typeof(HttpClient),
                        (_, i) => {
                            var client = i.Resolve<IHttpClientFactory>().CreateClient();
                            _clientConfigurator(client);
                            return client;
                        }
                    )
                }));
        }

        next(context);
    }
}