using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;
using TestMe.Web.Controllers;

namespace TestMe.Web.Tests.Controllers
{
	[TestClass]
	public class CheckIn1ControllerTests
	{
		[TestMethod]
		public void ChecksInUserAndGetsAchievement()
		{
			var repository = new Repository();
			repository.Insert(new Location { Id = 125, Name = "Test Place" });
			repository.Insert(new User { Id = 99, Name = "testuser" });

			var classToTest = new CheckIn1Controller();
			var httpContext = new HttpContext(
                new HttpRequest("test.html", "http://test.com", ""), 
                new HttpResponse(TextWriter.Null));
			var httpContextWrapper = new HttpContextWrapper(httpContext);
			httpContext.User = new GenericPrincipal(new GenericIdentity("testuser"), new string[0]);
			classToTest.ControllerContext = new ControllerContext();
			classToTest.ControllerContext.HttpContext = httpContextWrapper;

			var result = classToTest.Here(125);

			repository.Query<CheckIn>().Any(c => c.User.Id == 99 && c.Location.Id == 125 && c.Time.Subtract(DateTime.Now) < TimeSpan.FromSeconds(10));
		}
	}
}
