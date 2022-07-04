using Framework.EntityFramework.Access.Session;

namespace Framework.EntityFramework.Access.Query;

public interface IAsyncInlineQuery<out T> where T : class
{
    public IQueryable<T> Query(ISession session);
}