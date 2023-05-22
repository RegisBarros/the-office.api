﻿using the_office.domain.Common;

namespace the_office.domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetById(int id);

        Task<TEntity> GetByCode(Guid code);

        Task<IEnumerable<TEntity>> GetAll();

        Task<int> SaveChanges();
    }
}
