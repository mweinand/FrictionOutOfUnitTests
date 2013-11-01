using System.Collections.Generic;
using System.Linq;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;

namespace TestMe.Core.Services
{
    public class AllAchievementsChecker : IAllAchievementsChecker
	{
		private readonly IRepository repository;

		public AllAchievementsChecker(IRepository repository)
		{
			this.repository = repository;
		}

		public AchievementType Type
		{
			get { return AchievementType.AllLocations; }
		}

		public bool CanHaveMultiple
		{
			get { return false; }
		}

		public bool MeetsRequirements(ICollection<CheckIn> allCheckins)
		{
			var allLocationIds = repository.Query<Location>().Select(l => l.Id);

			var hasAll = false;
			foreach (var testLocationId in allLocationIds)
			{
				hasAll = hasAll || allCheckins.Any(c => c.Location.Id == testLocationId);
			}
			return hasAll;
		}
	}
}
