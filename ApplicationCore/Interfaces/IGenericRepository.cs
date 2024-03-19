using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T, in TPrimaryKey> where T : class
    {
        public Task<T> GetAsync(TPrimaryKey primaryKey);
        public Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAllFindAsync(Expression<Func<T, bool>> expression);
        public Task<List<T>> GetAllAsync();
        public Task InsertAsync(T t);
        public Task DeleteAsync(TPrimaryKey primaryKey);
        public Task UpdateAsync(TPrimaryKey primaryKey, T t);
    }
}