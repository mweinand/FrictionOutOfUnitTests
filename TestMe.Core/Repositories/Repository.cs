using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMe.Core.Entities;

namespace TestMe.Core.Repositories
{
	public class Repository : IRepository
	{
		private static List<Location> locations;
		private static List<User> users;
		private static List<CheckIn> checkIns;
		private static List<Achievement> achievements;

		static Repository()
		{
			locations = new List<Location>()
				{
					new Location { Id = 1, Name = "Place 1" },
					new Location { Id = 2, Name = "Place 2" },
					new Location { Id = 4, Name = "Place 4" }
				};
			users = new List<User>()
				{
					new User { Id = 3, Name = "Bob" },
					new User { Id = 7, Name = "Sally" },
					new User { Id = 15, Name = "Paul" }
				};
			checkIns = new List<CheckIn>();
			achievements = new List<Achievement>();
		}

		public IQueryable<TEntity> Query<TEntity>()
		{
			if (typeof(TEntity) == typeof(Location))
			{
				return locations.Cast<TEntity>().AsQueryable();
			}
			else if (typeof(TEntity) == typeof(User))
			{
				return users.Cast<TEntity>().AsQueryable();
			}
			else if (typeof(TEntity) == typeof(CheckIn))
			{
				return checkIns.Cast<TEntity>().AsQueryable();
			}
			else if (typeof(TEntity) == typeof(Achievement))
			{
				return achievements.Cast<TEntity>().AsQueryable();
			}

			return new List<TEntity>().AsQueryable();
		}

		public TEntity Find<TEntity>(int id) where TEntity : IIdEntity
		{
			return this.Query<TEntity>().SingleOrDefault(e => e.Id == id);
		}

		public void Insert<TEntity>(TEntity entity)
		{
			if (entity is Location)
			{
				locations.Add(entity as Location);
			}
			else if (entity is User)
			{
				users.Add(entity as User);
			}
			else if (entity is CheckIn)
			{
				checkIns.Add(entity as CheckIn);
			}
			else if (entity is Achievement)
			{
				achievements.Add(entity as Achievement);
			}
		}

		public void Delete<TEntity>(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			// Yay!
		}
	}
}
