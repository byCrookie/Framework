using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Extensions.List
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
            {
                action(value);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var value in enumerable)
            {
                await action(value).ConfigureAwait(false);
            }
        }

        public static IEnumerable<IEnumerable<TSource>> Group<TSource>
            (this IEnumerable<TSource> source, int itemsPerGroup)
        {
            return source.Select((x, idx) => new { x, idx })
                .GroupBy(x => x.idx / itemsPerGroup)
                .Select(g => g.Select(a => a.x));
        }

        public static async Task<IEnumerable<T>> WhenAllAsync<T>(this IEnumerable<Task<T>> tasks)
        {
            var allTasks = Task.WhenAll(tasks);

            try
            {
                return await allTasks.ConfigureAwait(false);
            }
            catch (Exception)
            {
                // ignored
            }

            throw allTasks.Exception ?? throw new Exception(nameof(WhenAllAsync));
        }

        public static Task WhenAllAsync(this IEnumerable<Task> tasks)
        {
            var allTasks = Task.WhenAll(tasks);

            try
            {
                return allTasks;
            }
            catch (Exception)
            {
                // ignored
            }

            throw allTasks.Exception ?? throw new Exception(nameof(WhenAllAsync));
        }
    }
}