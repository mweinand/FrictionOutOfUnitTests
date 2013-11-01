using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Core.Services;

namespace TestMe.Web.Controllers
{
    public class CheckIn1ControllerScratch : Controller
    {
        private readonly IRepository repository;
        private readonly IAchievementUnlocker unlocker;
        private readonly IUserContext userContext;

        public CheckIn1ControllerScratch(IRepository repository, IAchievementUnlocker unlocker, IUserContext userContext)
        {
            this.repository = repository;
            this.unlocker = unlocker;
            this.userContext = userContext;
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Here(int locationId)
        {
            var location = repository.Find<Location>(locationId);
            if (location == null)
            {
                return new HttpNotFoundResult();
            }
            
            // make a new check in
            var checkIn = new CheckIn();
            checkIn.UserId = this.userContext.Id;
            checkIn.Location = location;
            checkIn.Time = DateTime.Now;
            repository.Insert(checkIn);

            // achievements
            this.unlocker.UnlockAchievements(this.userContext.Id);

            repository.SaveChanges();

            return View();
        }

        public ActionResult Other()
        {
            var someOtherService = new SomeOtherService();
            someOtherService.DoSomething();
            return View();
        }
    }
}
