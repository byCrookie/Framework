using Framework.EntityFramework.Access.Session;

namespace Framework.EntityFramework.Access.Query;

public interface IAsyncSingleQuery<T> where T : class
{
    public Task<T> QueryAsync(ISession session);
}