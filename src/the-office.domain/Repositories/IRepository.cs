﻿using the_office.domain.Shared;

namespace the_office.domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByCode(Guid code, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default);
    IQueryable<TEntity> GetQueryable();
}