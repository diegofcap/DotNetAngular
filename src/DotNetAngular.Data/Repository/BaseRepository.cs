using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngular.Core;
using DotNetAngular.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetAngular.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        protected readonly PgContext Context;
        private readonly DbSet<T> _dataset;
        #endregion

        #region Ctor
        public BaseRepository(PgContext context)
        {
            this.Context = context;
            _dataset = context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                _dataset.Remove(entity);

                await Context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                _dataset.Add(entity);
                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataset.AnyAsync(X => X.Id.Equals(id));
        }

        public async Task<T> SelectAsync(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            try
            {
                if (!id.HasValue || id == 0)
                    return null;

                return await _dataset.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IList<T>> GetAllAsync(Func<IQueryable<T>, Task<IQueryable<T>>> func = null)
        {
            var query = func != null ? await func(Table) : Table;

            return await query.ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));

                if (result == null)
                    return null;

                Context.Entry(result).CurrentValues.SetValues(entity);
                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => _dataset.AsQueryable();

        #endregion
    }
}