using JobEntity.DataAccess.Context;
using JobEntity.DataAccess.Repositories.Abstracts;
using JobEntry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Repositories.Concretes
{
	public class Repository<TEntity>:IRepository<TEntity> where TEntity : class,IBaseEntity,new()
	{
		private readonly AppDbContext _dbContext;

		public Repository(AppDbContext dbContext)
        {
			_dbContext = dbContext;
		}
		private DbSet<TEntity> Table { get => _dbContext.Set<TEntity>(); }

		public async Task AddAsync(TEntity entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await Table.Where(predicate).AnyAsync();
			
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
		{
			IQueryable<TEntity> query = Table;

			if (predicate is not null) query = query.Where(predicate);

			return await query.CountAsync();
		}

		public void Delete(TEntity entity)
		{
			Table.Remove(entity);
		}

		public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = Table;
			if(predicate is not null) query = query.Where(predicate);

			if(includeProperties.Any())
				foreach (var item in includeProperties)
				{
					query = query.Include(item);
				}

			return await query.ToListAsync();
			
		}

		public async Task<TEntity> GetAsync(bool tracking = true, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = Table;
			if (predicate is not null) query = query.Where(predicate);

			if (includeProperties.Any())
				foreach (var item in includeProperties)
				{
					query = query.Include(item);
				}

			query = tracking == false ? query.AsNoTracking() : query;

			return await query.SingleAsync();
		}

		public async Task<TEntity> GetByGuidAsync(Guid id)
		{
			return await Table.FindAsync(id);
		}

		public void Update(TEntity entity)
		{
			Table.Update(entity);
		}
	}
}
