using JobEntity.DataAccess.Repositories.Abstracts;
using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.UnitOfWorks
{
	public interface IUnitOfWork:IAsyncDisposable
	{
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : class,IBaseEntity,new();
		Task<int> SaveChangesAsync();
		int SaveChanges();
	}
}
