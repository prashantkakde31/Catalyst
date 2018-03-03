using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public interface ICatalystService
    {
       List<CourseMaster> GetAllCourses();
       List<SubCourseMaster> GetAllSubCourses();
       List<SubjectMaster> GetAllSubjects();
       List<TopicMaster> GetAllTopics();
       List<PaperMaster> GetAllPapers();
       List<Mcq> GetAllMcqs();
       List<McqAnswer> GetAllMcqAnswers();
       List<ProductMaster> GetAllProducts();
       List<DiscountMaster> GetAllDiscounts();
    }
}
