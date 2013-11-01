using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMe.Core.Entities
{
	public class User : IIdEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
