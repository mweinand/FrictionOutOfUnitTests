using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Core.Services;

namespace TestMe.Web.Controllers
{
    public class CheckIn2Controller : Controller
    {
		private IRepository repository;
		private IUserContext userContext;
		private IAchievementUnlocker achievementUnlocker;
		private IClock clock;
		private ISomeOtherService someOtherService;

		public CheckIn2Controller(IRepository repository, IUserContext userContext, IAchievementUnlocker achievementUnlocker, IClock clock, ISomeOtherService someOtherService)
		{
			this.repository = repository;
			this.userContext = userContext;
			this.achievementUnlocker = achievementUnlocker;
			this.clock = clock;
			this.someOtherService = someOtherService;
		}

        public ActionResult Here(int locationId)
		{
			// Get the data
			var location = repository.Find<Location>(locationId);
			if (location == null)
			{
				return new HttpNotFoundResult();
			}

			// make a new check in
			var checkIn = new CheckIn();
            checkIn.UserId = this.userContext.Id;
			checkIn.Location = location;
			checkIn.Time = clock.Now;
			repository.Insert(checkIn);

			// check achievements
            this.achievementUnlocker.UnlockAchievements(this.userContext.Id);

			repository.SaveChanges();

            return View();
        }

		public ActionResult Other()
		{
			someOtherService.DoSomething();
			return View();
		}

    }
}
