using System;
using System.Collections.Generic;
using System.Linq;
using TestMe.Core.Entities;

namespace TestMe.Core.Services
{
    public class TwoInADayChecker : ITwoInADayChecker
    {
        public AchievementType Type
        {
            get { return AchievementType.TwoInOneDay; }
        }

        public bool CanHaveMultiple
        {
            get { return false; }
        }

        public bool MeetsRequirements(ICollection<CheckIn> allCheckins)
        {
            return allCheckins.Count(c => c.Time.Date == DateTime.Today) == 2;
        }
    }
}
