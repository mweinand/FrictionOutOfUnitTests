using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMe.Core.Entities;

namespace TestMe.Core.Repositories
{
	public interface IRepository
	{
		IQueryable<TEntity> Query<TEntity>();
		TEntity Find<TEntity>(int id) where TEntity : IIdEntity;
		void Insert<TEntity>(TEntity entity);
		void Delete<TEntity>(TEntity entity);
		void SaveChanges();
	}
}
