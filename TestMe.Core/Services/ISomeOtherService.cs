using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMe.Core.Services
{
	public interface ISomeOtherService
	{
		void DoSomething();
	}

	public class SomeOtherService : ISomeOtherService
	{
		public void DoSomething()
		{
		}
	}
}
