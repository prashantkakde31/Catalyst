using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using System.Data.SqlTypes;

namespace Interpidians.Catalyst.Core.ApplicationService
{
   public class SubjectService:ISubjectService
    {
       private ICourseMasterRepository CourseMasterRepository { get; set; }
       private ISubCourseMasterRepository SubCourseMasterRepository { get; set; }
       private ISubjectMasterRepository SubjectMasterRepository { get; set; }

        public List<SubjectMaster> GetAllSubjects(string course, string subcourse, string subject)
        {
            List<CourseMaster> lstCours = CourseMasterRepository.GetAll().ToList();
            //CourseMaster courseMaster = (CourseMaster)CourseMasterRepository.GetAll().Where(a => a.Name == course);
            //SubCourseMaster subCourseMaster = (SubCourseMaster)SubCourseMasterRepository.GetAll().Where(a => a.SubCourseID == courseMaster.CourseID);
            //SubjectMaster subjectMaster = (SubjectMaster)SubjectMasterRepository.GetAll().Where(a => a.SubCourseID == subCourseMaster.SubCourseID);
            //List<SubjectMaster> lstSub = ((SubjectMaster)SubjectMasterRepository.GetAll().Where(a => a.SubCourseID == subCourseMaster.SubCourseID)).ToList();
            //var q = (from course in courseMaster
            //         join subcourse in subCourseMaster on course.CourseID equals subcourse.CourseID
            //         join subject in subjectMaster on subcourse.SubCourseID equals subject.SubCourseID
            //         select new
            //         {
            //             subject.Name
            //         }).ToList(); 
            return new List<SubjectMaster>();
        }
    }
}
