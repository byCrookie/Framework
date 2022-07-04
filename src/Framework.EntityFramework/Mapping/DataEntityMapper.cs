using Framework.EntityFramework.Access.Session;
using Framework.EntityFramework.Entities;

namespace Framework.EntityFramework.Mapping;

internal class DataEntityMapper<TData, TEntity> : IDataEntityMapper<TData, TEntity>
    where TData : class
    where TEntity : class, IEntity
{
    private readonly ISession _session;
    private readonly IMappingContext<TData, TEntity> _mappingContext;

    public DataEntityMapper(
        ISession session,
        IMappingContext<TData, TEntity> mappingContext
    )
    {
        _session = session;
        _mappingContext = mappingContext;
    }

    public TData MapToData(TEntity entity)
    {
        return _mappingContext.MapToData(entity);
    }

    public TEntity MapToEntity(TData data)
    {
        return _mappingContext.MapDataToEntity(data);
    }

    public void MapToEntity(TData data, TEntity entity)
    {
        _mappingContext.MapDataToEntity(data, entity);
    }

    public ICollection<TData> MapToDatas(ICollection<TData> datas, ICollection<TEntity> entities)
    {
        RemoveFromDatas(datas, entities);
        UpdateInDatas(datas, entities);
        AddToDatas(datas, entities);
        return datas;
    }

    private void RemoveFromDatas(ICollection<TData> datas, ICollection<TEntity> entities)
    {
        var datasToRemove = datas
            .Where(data => entities.All(entity => !_mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var data in datasToRemove)
        {
            datas.Remove(data);
        }
    }

    private void UpdateInDatas(IEnumerable<TData> datas, ICollection<TEntity> entities)
    {
        var datasToUpdate = datas
            .Where(data => entities.Any(entity => _mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var dataToUpdate in datasToUpdate)
        {
            _mappingContext.MapToData(dataToUpdate, entities
                .Single(entity => _mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(dataToUpdate))));
        }
    }

    private void AddToDatas(ICollection<TData> datas, IEnumerable<TEntity> entities)
    {
        var datasToAdd = entities
            .Where(entity => datas.All(data => !_mappingContext.Identifier(data).Equals(_mappingContext.Identifier(entity))))
            .Select(entity => _mappingContext.MapToData(entity))
            .ToList();

        foreach (var data in datasToAdd)
        {
            datas.Add(data);
        }
    }

    public ICollection<TEntity> MapToEntities(ICollection<TEntity> entities, ICollection<TData> datas)
    {
        RemoveFromEntities(entities, datas);
        UpdateInEntities(entities, datas);
        AddToEntities(entities, datas);
        return entities;
    }

    private void RemoveFromEntities(ICollection<TEntity> entities, ICollection<TData> datas)
    {
        var entitiesToRemove = entities
            .Where(entity => datas.All(data => !_mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var entity in entitiesToRemove)
        {
            entities.Remove(entity);
        }
    }

    private void UpdateInEntities(IEnumerable<TEntity> entities, ICollection<TData> datas)
    {
        var entitiesToUpdate = entities
            .Where(entity => datas.Any(data => _mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var entityToUpdate in entitiesToUpdate)
        {
            _mappingContext.MapDataToEntity(datas
                    .Single(data => _mappingContext.Identifier(data).Equals(_mappingContext.Identifier(entityToUpdate))),
                entityToUpdate
            );
        }
    }

    private void AddToEntities(ICollection<TEntity> entities, IEnumerable<TData> datas)
    {
        var entitiesToAdd = datas
            .Where(data => entities.All(entity => !_mappingContext.Identifier(data).Equals(_mappingContext.Identifier(entity))))
            .Select(data => _mappingContext.MapDataToEntity(data))
            .ToList();

        foreach (var entity in entitiesToAdd)
        {
            entities.Add(entity);
        }
    }
    
    public List<TEntity> MapToSession(List<TEntity> entities, ICollection<TData> datas)
    {
        RemoveFromSession(entities, datas);
        UpdateInSession(entities, datas);
        AddToSession(entities, datas);
        return entities;
    }
    
    private void RemoveFromSession(List<TEntity> entities, ICollection<TData> datas)
    {
        var entitiesToRemove = entities
            .Where(entity => datas.All(data => !_mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var entity in entitiesToRemove)
        {
            entities.Remove(entity);
            _session.Remove(entity);
        }
    }

    private void UpdateInSession(IReadOnlyCollection<TEntity> entities, ICollection<TData> datas)
    {
        var entitiesToUpdate = entities
            .Where(entity => datas.Any(data => _mappingContext.Identifier(entity).Equals(_mappingContext.Identifier(data))))
            .ToList();

        foreach (var entity in entitiesToUpdate)
        {
            _mappingContext.MapDataToEntity(datas
                    .Single(data => _mappingContext.Identifier(data).Equals(_mappingContext.Identifier(entity))),
                entity
            );
            _session.Update(entity);
        }
    }

    private void AddToSession(List<TEntity> entities, IEnumerable<TData> datas)
    {
        var entitiesToAdd = datas
            .Where(data => entities.All(entity => !_mappingContext.Identifier(data).Equals(_mappingContext.Identifier(entity))))
            .Select(data => _mappingContext.MapDataToEntity(data))
            .ToList();

        foreach (var entityToAdd in entitiesToAdd)
        {
            entities.Add(entityToAdd);
            _session.Add(entityToAdd);
        }
    }
}