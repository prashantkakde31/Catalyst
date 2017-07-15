using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository Repository { get; set; }

        public EmployeeService(IEmployeeRepository repository)
        {
            this.Repository = repository;
        }
        public List<Employee> GetAll()
        {
            return this.Repository.GetAll().ToList<Employee>();
        }

        public Employee GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        public void Register(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
