using Jab;

namespace Framework.Jab.Http;

[ServiceProviderModule]
internal partial interface IHttpModule
{
    // protected override void Load(ContainerBuilder builder)
    // {
    //     // builder.RegisterType<UserService>()
    //     //     .As<IUserService>()
    //     //     .ConfigurePipeline(p =>
    //     //     {
    //     //         p.Use(new HttpClientMiddleware<UserService>(client =>
    //     //         {
    //     //             client.BaseAddress = new Uri("https://api.XXX.com/");
    //     //             client.DefaultRequestHeaders.Add("Accept", "application/vnd.XXX.v3+json");
    //     //             client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-XXX");
    //     //         }));
    //     //     });
    //         
    //     base.Load(builder);
    // }
}