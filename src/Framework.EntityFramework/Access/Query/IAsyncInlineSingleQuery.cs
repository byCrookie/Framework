using Framework.EntityFramework.Access.Session;

namespace Framework.EntityFramework.Access.Query;

public interface IAsyncInlineSingleQuery<out T>
{
    public IQueryable<T> QueryAsync(ISession session);
}