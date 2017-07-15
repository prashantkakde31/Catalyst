using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class ExamResultRepository:BaseRepository, IExamResultRepository
    {

       public ExamResult getResultByExamId(long examid)
        {
            ExamResult objExam = new ExamResult();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetExamResultById", examid))
            {
                MapRecord(IReader, objExam);
            }
            return objExam;
        }
    }
}
