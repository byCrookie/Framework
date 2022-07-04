using Framework.EntityFramework.Entities;

namespace Framework.EntityFramework.Mapping;

public interface IMappingContext<TData, TEntity>
    where TData : class
    where TEntity : IEntity
{
    public Guid Identifier(TEntity entity);
    public Guid Identifier(TData data);
    public TData MapToData(TEntity entity);
    public void MapToData(TData data, TEntity entity);
    public void MapDataToEntity(TData data, TEntity entity);
    public TEntity MapDataToEntity(TData data);
}