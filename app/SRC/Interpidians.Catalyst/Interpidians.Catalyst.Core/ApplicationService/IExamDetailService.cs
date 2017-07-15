using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public interface IExamDetailService
    {
       List<ExamDetail> GetAll();
       ExamDetail GetById(long ExamDetailID);
    }
}
