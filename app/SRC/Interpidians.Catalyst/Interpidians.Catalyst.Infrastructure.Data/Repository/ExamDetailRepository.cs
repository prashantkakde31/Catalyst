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
   public class ExamDetailRepository:BaseRepository,IExamDetailRepository
    {
        public IEnumerable<ExamDetail> GetAll()
        {
            IEnumerable<ExamDetail> lstEmployee;
            lstEmployee = this.DB.ExecuteSprocAccessor<ExamDetail>("usp_GetAllExamDetail");
            return lstEmployee;
        }

        public ExamDetail GetById(IdentifiableData id)
        {
            ExamDetail examDetail = new ExamDetail();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetExamDetailById", id))
            {
                MapRecord(IReader, examDetail);
            }
            return examDetail;
        }

        public void Add(ExamDetail exmDtl)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamDetail exmDtl)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
