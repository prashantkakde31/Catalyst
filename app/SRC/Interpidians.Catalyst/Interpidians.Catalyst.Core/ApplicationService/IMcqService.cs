using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public interface IMcqService
    {
       List<CourseMaster> getAllCourses();
       List<SubCourseMaster> getAllSubCourses();
       List<SubjectMaster> GetAllSubjects();
       List<TopicMaster> getAllTopics();
       List<PaperMaster> getAllPapers();
       List<Mcq> getAllMcqs();
       List<McqAnswer> getAllMcqAnswers();
    }
}
