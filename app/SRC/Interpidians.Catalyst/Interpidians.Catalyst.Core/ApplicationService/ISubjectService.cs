using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public interface ISubjectService
   {
       List<SubjectMaster> GetAllSubjects(string course, string subcourse, string subject);
    }
}
