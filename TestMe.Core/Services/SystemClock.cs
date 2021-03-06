﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMe.Core.Services
{
	public interface IClock
	{
		DateTime Now { get; }
	}

	public class SystemClock : IClock
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}
	}
}
