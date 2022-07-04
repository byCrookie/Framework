using Framework.EntityFramework.Access.Query;
using Framework.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Framework.EntityFramework.Access.Session;

internal class Session : ISession
{
    private readonly DbContext _databaseContext;

    public Session(DbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task SaveAsync()
    {
        Log.Debug("{0} -> Has Changes {1}", nameof(SaveAsync), _databaseContext.ChangeTracker.HasChanges());
        return _databaseContext.SaveChangesAsync();
    }
    
    public DbContext Context()
    {
        return _databaseContext;
    }

    public Task<List<T>> QueryAsync<T>(IAsyncQuery<T> query) where T : class
    {
        Log.Debug("Query using async query of entity {Type}", typeof(T));
        return query.Query(this).ToListAsync();
    }

    public Task<T> QueryAsync<T>(IAsyncSingleQuery<T> query) where T : class
    {
        Log.Debug("Query using async single query of entity {Type}", typeof(T));
        return query.QueryAsync(this);
    }

    public DbSet<T> Set<T>() where T : class, IEntity
    {
        Log.Debug("Query using db set of entity {Type}", typeof(T));
        return _databaseContext.Set<T>();
    }

    public ValueTask<T?> FindAsync<T>(long id) where T : class, IEntity
    {
        Log.Debug("Find entity of type {Type} by id", typeof(T));
        return _databaseContext.FindAsync<T>();
    }

    public void Add<T>(T entity) where T : class, IEntity
    {
        Log.Debug("Query using db set of entity {Type}", typeof(T));
        _databaseContext.Add(entity);
    }
    
    public void Update<T>(T entity) where T : class, IEntity
    {
        Log.Debug("Query using db set of entity {Type}", typeof(T));
        _databaseContext.Update(entity);
    }
    
    public void Remove<T>(T entity) where T : class, IEntity
    {
        Log.Debug("Query using db set of entity {Type}", typeof(T));
        _databaseContext.Remove(entity);
    }
}