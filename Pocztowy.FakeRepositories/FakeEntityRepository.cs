using Pocztowy.IRepositories;
using Pocztowy.Models;
using System;
using System.Collections.Generic;

namespace Pocztowy.FakeRepositories
{
    public class FakeEntityRepository<TEntity, TKey>
        : IEntityRepository<TEntity, TKey>
        where
            TEntity : BaseEntity<TKey>
        where
            TKey : struct
    {
        protected IDictionary<TKey, TEntity> entities;

        public FakeEntityRepository()
        {
            entities = new Dictionary<TKey, TEntity>();
        }

        public virtual void Add(TEntity entity) => 
            entities.Add(entity.Id, entity);

        public virtual IEnumerable<TEntity> Get() => entities.Values;

        public virtual TEntity Get(TKey id) => entities[id];

        public virtual IEnumerator<TEntity> Get(Predicate<TEntity> filter)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(TKey id) => entities.Remove(id);

        public virtual void Update(TEntity entity) => entities[entity.Id] = entity;
    }
}
