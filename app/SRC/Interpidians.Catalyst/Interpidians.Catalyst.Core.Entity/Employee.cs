using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public string EMail { get; set; }
        public DateTime StartDate { get; set; }
    }
}
