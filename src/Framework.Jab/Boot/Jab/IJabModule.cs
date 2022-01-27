using Framework.Jab.Boot.Jab.Registration;
using Jab;

namespace Framework.Jab.Boot.Jab;

[ServiceProviderModule]
[Transient(typeof(IJabBootStep<,>), typeof(JabBootStep<,>))]
internal partial interface IJabModule
{
}