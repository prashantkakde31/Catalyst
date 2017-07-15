using Microsoft.Practices.EnterpriseLibrary.Data;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        #region Employee List Methods        

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> lstEmployee;
            lstEmployee = this.DB.ExecuteSprocAccessor<Employee>("usp_GetEmployees");
            return lstEmployee;
        }

        public Employee GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        #endregion

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
