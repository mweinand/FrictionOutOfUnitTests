using System.Collections.Generic;
using TestMe.Core.Entities;

namespace TestMe.Core.Services
{
    public interface IAchievementChecker
    {
        AchievementType Type { get; }
        bool CanHaveMultiple { get; }
        bool MeetsRequirements(ICollection<CheckIn> allCheckins);
    }
}
