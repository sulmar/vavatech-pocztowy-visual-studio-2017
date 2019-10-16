using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocztowy.IRepositories
{
    public interface IEntityRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        IEnumerator<TEntity> Get(Predicate<TEntity> filter);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TKey id);
    }

    public static class IEntityRepositoryExtensions
    {
        public static Task AddAsync<TEntity, TKey>
            (this IEntityRepository<TEntity, TKey> repository, TEntity entity)
        {
            return Task.Run(() => repository.Add(entity));
        }
    }

    public interface IEntityRepositoryAsync<TEntity, TKey>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> Get(TKey id);
        Task<IEnumerator<TEntity>> Get(Predicate<TEntity> filter);
        Task Update(TEntity entity);
        Task Remove(TKey id);
    }

}
