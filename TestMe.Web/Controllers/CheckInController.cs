using System;
using System.Linq;
using System.Web.Mvc;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Core.Services;

namespace TestMe.Web.Controllers
{
    public class CheckInController : Controller
    {
        [HttpPost]
        public ActionResult Here(int locationId)
        {
            // Get the data
            var repository = new Repository();

            var location = repository.Find<Location>(locationId);
            if (location == null)
            {
                return new HttpNotFoundResult();
            }

            var username = HttpContext.User.Identity.Name;

            var user = repository.Query<User>().SingleOrDefault(u => u.Name == username);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            // make a new check in
            var checkIn = new CheckIn();
            checkIn.User = user;
            checkIn.Location = location;
            checkIn.Time = DateTime.Now;
            repository.Insert(checkIn);

            // check to see if this user meets any achievements
            var allCheckins = repository.Query<CheckIn>().Where(c => c.User.Id == user.Id);
            var allAchievements = repository.Query<Achievement>();
            var allLocationIds = repository.Query<Location>().Select(l => l.Id);

            // two in one day?
            if (!allAchievements.Any(a => a.Type == AchievementType.TwoInOneDay) && allCheckins.Count(c => c.Time.Date == DateTime.Today) > 2)
            {
                var twoInOneDay = new Achievement { Type = AchievementType.TwoInOneDay, User = user, TimeAwarded = DateTime.Now };
                repository.Insert(twoInOneDay);
            }

            // all locations?
            var hasAll = false;
            foreach (var testLocationId in allLocationIds)
            {
                hasAll = hasAll || allCheckins.Any(c => c.Location.Id == testLocationId);
            }

            if (!allAchievements.Any(a => a.Type == AchievementType.AllLocations) && hasAll)
            {
                var allLocations = new Achievement { Type = AchievementType.AllLocations, User = user, TimeAwarded = DateTime.Now };
                repository.Insert(allLocations);
            }

            repository.SaveChanges();

            return Json(true);
        }

        public ActionResult Other()
        {
            var someOtherService = new SomeOtherService();
            someOtherService.DoSomething();
            return Json(true);
        }
    }
}
