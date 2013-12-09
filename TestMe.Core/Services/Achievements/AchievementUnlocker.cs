using System;
using System.Collections.Generic;
using System.Linq;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;

namespace TestMe.Core.Services
{
    public class AchievementUnlocker
    {
        private readonly IRepository repository;
        private readonly IEnumerable<IAchievementChecker> checkers;

        public AchievementUnlocker(IRepository repository, IEnumerable<IAchievementChecker> checkers)
        {
            this.repository = repository;
            this.checkers = checkers;
        }

        public void UnlockAchievements(int userId)
        {
            // check to see if this user meets any achievements
            var allCheckins = repository.Query<CheckIn>().Where(c => c.User.Id == userId).ToList();
            var allAchievements = repository.Query<Achievement>().Where(a => a.UserId == userId).ToList();

            foreach (var checker in checkers)
            {
                if ((checker.CanHaveMultiple || allAchievements.All(a => a.Type != checker.Type))
                    && checker.MeetsRequirements(allCheckins))
                {
                    var newAchievement = new Achievement { Type = checker.Type, UserId = userId, TimeAwarded = DateTime.Now };
                    repository.Insert(newAchievement);
                }
            }
        }
    }
}
