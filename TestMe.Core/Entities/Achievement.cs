using System;

namespace TestMe.Core.Entities
{
	public class Achievement
	{
		public int Id { get; set; }
        public AchievementType Type { get; set; }
        public int UserId { get; set; }
		public User User { get; set; }
		public DateTime TimeAwarded { get; set; }
	}
}
