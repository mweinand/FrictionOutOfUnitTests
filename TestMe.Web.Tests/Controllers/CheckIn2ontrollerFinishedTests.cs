using Centare.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Core.Services;
using TestMe.Web.Controllers;

namespace TestMe.Web.Tests.Controllers
{
	[TestClass]
    public class CheckIn2ontrollerFinishedTests : AutoMockContext<CheckInControllerFinished>
	{
		[TestMethod]
		public void ChecksInUserAndGetsAchievement()
		{
			var location = new Location { Id = 125, Name = "Test Place" };

			MockFor<IRepository>().Setup(r => r.Find<Location>(125)).Returns(location);
			MockFor<IUserContext>().SetupGet(u => u.Id).Returns(99);
            
			var now = new DateTime(2010, 2, 3);
			MockFor<IClock>().SetupGet(c => c.Now).Returns(now);
            
			var result = ClassUnderTest.Here(125) as JsonResult;
			Assert.IsNotNull(result);
            Assert.IsTrue((bool)result.Data);

            MockFor<IRepository>()
                .Verify(r => r.Insert(It.Is<CheckIn>(c => c.Time == now && c.UserId == 99 && c.Location == location)), Times.Once());
            MockFor<IRepository>().Verify(r => r.SaveChanges(), Times.Once());
            MockFor<IRepository>().VerifyAll();
            MockFor<IAchievementUnlocker>().Verify(a => a.UnlockAchievements(99));
		}

		[TestMethod]
		public void DoesOtherStuff()
        {
			ClassUnderTest.Other();
			MockFor<ISomeOtherService>().Verify(s => s.DoSomething(), Times.Once());
		}
	}
}
