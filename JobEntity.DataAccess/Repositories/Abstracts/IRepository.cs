using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Repositories.Abstracts
{
	public interface IRepository<TEntity> where TEntity : class,IBaseEntity,new()
	{
		Task AddAsync(TEntity entity);

		Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> predicate = null,params Expression<Func<TEntity, object>>[] includeProperties);

		Task<TEntity> GetAsync(bool tracking = true,Expression < Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

		Task<TEntity> GetByGuidAsync(Guid id);

		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

		Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

		void Update(TEntity entity);

		void Delete(TEntity entity);
	}
}
