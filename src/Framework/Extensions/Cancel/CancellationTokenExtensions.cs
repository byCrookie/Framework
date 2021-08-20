using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Extensions.Cancel
{
    public static class CancellationTokenExtensions
    {
        public static Task AsTaskAsync(this CancellationToken token)
        {
            return new(() => throw new InvalidOperationException(), token);
        }

        public static Task<TResult> AsTaskAsync<TResult>(this CancellationToken token)
        {
            return new(() => throw new InvalidOperationException(), token);
        }
    }
}