using System.Linq;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;

namespace TestMe.Core.Services
{
	public interface IUserContextFactory
	{
		IUserContext GetCurrentUser(string name);
	}

	public class UserContextFactory : IUserContextFactory
	{
	    private IRepository repository;

	    public UserContextFactory(IRepository repository)
	    {
	        this.repository = repository;
	    }

	    public IUserContext GetCurrentUser(string name)
	    {
	        var user = repository.Query<User>().SingleOrDefault(u => u.Name == name);

	        if (user == null)
	        {
	            return new UserContext {Id = 0};
	        }

	        return new UserContext {Id = user.Id, Name = user.Name};
	    }
	}
}
