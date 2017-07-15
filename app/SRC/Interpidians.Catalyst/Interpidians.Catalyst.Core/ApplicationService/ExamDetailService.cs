using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public class ExamDetailService:IExamDetailService
    {
       private IExamRepository ExamRepository { get; set; }
       private IExamDetailRepository ExamDetailRepository { get; set; }
       public ExamDetailService(IExamRepository examRepository, IExamDetailRepository examDetailRepository)
       {
           this.ExamRepository = examRepository;
           this.ExamDetailRepository = examDetailRepository;
       }
        public List<ExamDetail> GetAll()
        {
            return this.ExamDetailRepository.GetAll().ToList();
        }


        public ExamDetail GetById(long ExamDetailID)
        {
            return this.ExamDetailRepository.GetAll().Where(a => a.ExamDetailID == ExamDetailID).SingleOrDefault<ExamDetail>();
        }
    }
}
