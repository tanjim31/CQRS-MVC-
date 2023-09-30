using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Shared.Contract
{
    public interface IRepository<TEntity, IModel, T>
        where TEntity : class, IEntity<T>, new()
        where IModel : class,IVM<T>, new()
        where T : IEquatable<T>
    {
        /// <summary>
        /// Gets by identidier asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IModel> GetByIdAsync(T id);
        /// <summary>
        /// Get All asynchronous
        /// </summary>
        /// <returns></returns>

        public Task<IEnumerable<IModel>> GetAllAsync();
        /// <summary>
        /// Get All asynchronous
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// Delete the asynchronous
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task DeleteAsync(TEntity entity);
        /// <summary>
        /// Delete the asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IModel> DeleteAsync(T id);
        /// <summary>
        /// Update the asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task <IModel> UpdateAsync(T id, TEntity entity);
        /// <summary>
        /// Insert the asynchronous
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<IModel> InsertAsync(TEntity entity);

    }
}
