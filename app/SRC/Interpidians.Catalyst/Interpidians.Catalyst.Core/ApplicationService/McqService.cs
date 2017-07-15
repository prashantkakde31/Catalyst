using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class McqService : IMcqService
    {
        private ISubjectMasterRepository SubjectMasterRepository { get; set; }
        private ITopicMasterRepository TopicMasterRepository { get; set; }
        private IPaperMasterRepository PaperMasterRepository { get; set; }
        private ICourseMasterRepository CourseMasterRepository { get; set; }
        private ISubCourseMasterRepository  SubCourseMasterRepository { get; set; }
        private IMcqRepository McqRepository { get; set; }
        private IMcqAnswerRepository McqAnswerRepository { get; set; }

        public McqService(ISubjectMasterRepository subjectMasterRepository, ITopicMasterRepository topicMasterRepository, IPaperMasterRepository paperMasterRepository, ICourseMasterRepository courseMasterRepository, ISubCourseMasterRepository subCourseMasterRepository, IMcqRepository mcqRepository, IMcqAnswerRepository mcqAnswerRepository)
        {
            this.SubjectMasterRepository = subjectMasterRepository;
            this.TopicMasterRepository = topicMasterRepository;
            this.PaperMasterRepository = paperMasterRepository;
            this.CourseMasterRepository = courseMasterRepository;
            this.SubCourseMasterRepository = subCourseMasterRepository;
            this.McqRepository = mcqRepository;
            this.McqAnswerRepository = mcqAnswerRepository;
        }
       
        public List<SubjectMaster> GetAllSubjects()
        {
            return this.SubjectMasterRepository.GetAll().ToList();
        }
        public List<TopicMaster> getAllTopics()
        {
            return this.TopicMasterRepository.GetAll().ToList();
        }
        public List<PaperMaster> getAllPapers()
        {
            return this.PaperMasterRepository.GetAll().ToList();
        }

        public List<CourseMaster> getAllCourses()
        {
            return this.CourseMasterRepository.GetAll().ToList();
        }

        public List<SubCourseMaster> getAllSubCourses()
        {
            return this.SubCourseMasterRepository.GetAll().ToList();
        }


        public List<Mcq> getAllMcqs()
        {
            return this.McqRepository.GetAll().ToList();
        }

        public List<McqAnswer> getAllMcqAnswers()
        {
            return this.McqAnswerRepository.GetAll().ToList();
        }
    }
}
