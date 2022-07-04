using Framework.EntityFramework.Access.Query;
using Framework.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Framework.EntityFramework.Access.Session;

public interface ISession
{
    Task SaveAsync();
    DbContext Context();

    Task<List<T>> QueryAsync<T>(IAsyncQuery<T> query) where T : class;
    Task<T> QueryAsync<T>(IAsyncSingleQuery<T> query) where T : class;

    DbSet<T> Set<T>() where T : class, IEntity;
    ValueTask<T?> FindAsync<T>(long id) where T : class, IEntity;

    void Add<T>(T entity) where T : class, IEntity;
    void Update<T>(T entity) where T : class, IEntity;
    void Remove<T>(T entity) where T : class, IEntity;
}