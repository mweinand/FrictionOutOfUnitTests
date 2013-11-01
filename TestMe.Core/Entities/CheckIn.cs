using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMe.Core.Entities
{
	public class CheckIn : IIdEntity
	{
		public int Id { get; set; }
		public User User { get; set; }
		public Location Location { get; set; }
		public DateTime Time { get; set; }
	    public int UserId { get; set; }
	}
}
