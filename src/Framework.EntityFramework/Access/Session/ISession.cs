using Framework.EntityFramework.Access.Query;
using Framework.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Framework.EntityFramework.Access.Session;

public interface ISession
{
    Task SaveAsync();
    DbContext Context();

    Task<List<T>> QueryAsync<T>(IAsyncQuery<T> query);
    Task<T> QueryAsync<T>(IAsyncSingleQuery<T> query);
    
    IQueryable<T> QueryAsync<T>(IAsyncInlineQuery<T> query);
    IQueryable<T> QueryAsync<T>(IAsyncInlineSingleQuery<T> query);

    DbSet<T> Set<T>() where T : class, IEntity;
    ValueTask<T?> FindAsync<T>(long id) where T : class, IEntity;

    void Add<T>(T entity) where T : class, IEntity;
    void Update<T>(T entity) where T : class, IEntity;
    void Remove<T>(T entity) where T : class, IEntity;
}