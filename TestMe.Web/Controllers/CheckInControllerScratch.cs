using System;
using System.Linq;
using System.Web.Mvc;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Core.Services;

namespace TestMe.Web.Controllers
{
    public class CheckInControllerScratch : Controller
    {
        private readonly IRepository repository;
        private readonly IUserContext userContext;
        private readonly IAchievementUnlocker achievementUnlocker;
        private readonly IClock clock;
        private readonly ISomeOtherService someOtherService;
        
        public CheckInControllerScratch(IRepository repository, IUserContext userContext, IClock clock, IAchievementUnlocker achievementUnlocker, ISomeOtherService someOtherService)
        {
            this.repository = repository;
            this.userContext = userContext;
            this.clock = clock;
            this.achievementUnlocker = achievementUnlocker;
            this.someOtherService = someOtherService;
        }

        [HttpPost]
        public ActionResult Here(int locationId)
        {
            var location = repository.Find<Location>(locationId);
            if (location == null)
            {
                return new HttpNotFoundResult();
            }
            
            // make a new check in
            var checkIn = new CheckIn();
            checkIn.UserId = userContext.Id;
            checkIn.Location = location;
            checkIn.Time = clock.Now;
            repository.Insert(checkIn);

            achievementUnlocker.UnlockAchievements(userContext.Id);

            repository.SaveChanges();

            return Json(true);
        }

        public ActionResult Other()
        {
            someOtherService.DoSomething();
            return Json(true);
        }
    }
}
