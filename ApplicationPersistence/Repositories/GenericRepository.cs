using ApplicationCore.Interfaces;
using ApplicationDomain.Concrets;
using ApplicationPersistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationPersistence.Repositories
{
    public abstract class GenericRepository<T, TPrimaryKey> : IGenericRepository<T, TPrimaryKey> where T : BaseEntity
    {
        private readonly MyDbContext _myDbContext;
        private readonly DbSet<T> entities;
        public GenericRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            entities = _myDbContext.Set<T>();
        }
        public async Task DeleteAsync(TPrimaryKey primaryKey)
        {
            var entity = await entities.FindAsync(primaryKey);
            if (entity is null) return;
            else entities.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllFindAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(TPrimaryKey primaryKey)
        {
            return await entities.FindAsync(primaryKey);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T t)
        {
            await entities.AddAsync(t);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TPrimaryKey primaryKey, T t)
        {
            _myDbContext.Entry(t).State = EntityState.Detached;
            _myDbContext.Entry(t).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
        }
    }

}