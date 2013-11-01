using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMe.Core.Entities;
using TestMe.Core.Repositories;

namespace TestMe.Core.Services
{
    public class MockExampleService
    {
        private readonly IRepository repository;

        public MockExampleService(IRepository repository)
        {
            this.repository = repository;
        }

        public Location GetLocationById(int id)
        {
            return repository.Find<Location>(id);
        }
    }
}
