using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(IdentifiableData id);
        void Register(Employee employee);
        void Update(Employee employee);
        void Delete(IdentifiableData id);
    }
}
