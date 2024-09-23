using JobEntity.DataAccess.Context;
using JobEntity.DataAccess.Repositories.Abstracts;
using JobEntity.DataAccess.Repositories.Concretes;
using JobEntity.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public int SaveChanges()
		{
			return _dbContext.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
		{
			return new Repository<TEntity>(_dbContext);
		}
	}
}
