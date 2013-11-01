using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;

namespace TestMe.Core.Services
{
    public class TestService
    {
        private readonly IRepository repository;
        public TestService() : this(new Repository())
        {
        }
        public TestService(IRepository repository)
        {
            this.repository = repository;
        }



        public void Test()
        {
            this.repository.Query<Location>();
            var condition1 = true;
            var condition2 = false;
            var condition3 = true;

            //if (condition1 && condition2)
            //{
            //    if (condition3)
            //    {
            //        doSomething();
            //    }
            //    else
            //    {
            //        doSomethingElse();
            //    }
            //}
            //else if (condition3)
            //{
            //    doAnotherThing();
            //}

        }
    }
}
