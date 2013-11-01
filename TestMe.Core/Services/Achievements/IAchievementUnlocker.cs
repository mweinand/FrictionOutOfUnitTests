using TestMe.Core.Entities;

namespace TestMe.Core.Services
{
    public interface IAchievementUnlocker
    {
        void UnlockAchievements(int userId);
    }
}