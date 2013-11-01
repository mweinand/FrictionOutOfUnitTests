namespace TestMe.Core.Services
{
	public interface IUserContext
	{
        int Id { get; }
		string Name { get; }
	}

	public class UserContext : IUserContext
	{
        public int Id { get; set; }
		public string Name { get; set; }
	}
}
