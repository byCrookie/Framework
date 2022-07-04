using Framework.EntityFramework.Entities;

namespace Framework.EntityFramework.Mapping;

public interface IDataEntityMapper<TData, TEntity>
    where TData : class
    where TEntity : class, IEntity
{
    public TData MapToData(TEntity entity);
    public TEntity MapToEntity(TData data);
    public void MapToEntity(TData data, TEntity entity);
    public ICollection<TData> MapToDatas(ICollection<TData> datas, ICollection<TEntity> entities);
    public ICollection<TEntity> MapToEntities(ICollection<TEntity> entities, ICollection<TData> datas);
    public List<TEntity> MapToSession(List<TEntity> entities, ICollection<TData> datas);
}