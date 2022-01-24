using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngular.Core;

namespace DotNetAngular.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region Methods
        Task<T> InsertAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task<bool> DeleteAsync (T entity);
        Task<T> SelectAsync (int id);
        Task<T> GetByIdAsync(int? id);
        Task<IList<T>> GetAllAsync(Func<IQueryable<T>, Task<IQueryable<T>>> func = null);
        Task<bool> ExistAsync (int id);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        #endregion
    }
}