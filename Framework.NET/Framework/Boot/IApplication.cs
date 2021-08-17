using System.Threading;
using System.Threading.Tasks;

namespace Framework.Boot
{
    public interface IApplication
    {
        Task RunAsync(CancellationToken cancellationToken);
    }
}