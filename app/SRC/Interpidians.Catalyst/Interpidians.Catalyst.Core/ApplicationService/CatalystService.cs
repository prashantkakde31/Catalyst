using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Interpidians.Catalyst.Core.Common;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class CatalystService : ICatalystService
    {
        private ISubjectMasterRepository SubjectMasterRepository { get; set; }
        private ITopicMasterRepository TopicMasterRepository { get; set; }
        private IPaperMasterRepository PaperMasterRepository { get; set; }
        private ICourseMasterRepository CourseMasterRepository { get; set; }
        private ISubCourseMasterRepository  SubCourseMasterRepository { get; set; }
        private IMcqRepository McqRepository { get; set; }
        private IMcqAnswerRepository McqAnswerRepository { get; set; }
        private IProductMasterRepository ProductMasterRepository { get; set; }
        private IDiscountMasterRepository DiscountMasterRepository { get; set; }
        private ICacheService CacheService { get; set; }

        public CatalystService(ISubjectMasterRepository subjectMasterRepository, ITopicMasterRepository topicMasterRepository, IPaperMasterRepository paperMasterRepository, ICourseMasterRepository courseMasterRepository, ISubCourseMasterRepository subCourseMasterRepository, IMcqRepository mcqRepository, IMcqAnswerRepository mcqAnswerRepository, IProductMasterRepository productMasterRepository, IDiscountMasterRepository discountMasterRepository,ICacheService cacheService)
        {
            this.SubjectMasterRepository = subjectMasterRepository;
            this.TopicMasterRepository = topicMasterRepository;
            this.PaperMasterRepository = paperMasterRepository;
            this.CourseMasterRepository = courseMasterRepository;
            this.SubCourseMasterRepository = subCourseMasterRepository;
            this.McqRepository = mcqRepository;
            this.McqAnswerRepository = mcqAnswerRepository;
            this.ProductMasterRepository = productMasterRepository;
            this.DiscountMasterRepository = discountMasterRepository;
            this.CacheService = cacheService;
        }
       
        public List<SubjectMaster> GetAllSubjects()
        {
            //return this.SubjectMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_SUBJECTS, 20, () => this.SubjectMasterRepository.GetAll().ToList());
        }
        public List<TopicMaster> GetAllTopics()
        {
            //return this.TopicMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_TOPICS, 20, () => this.TopicMasterRepository.GetAll().ToList());
        }
        public List<PaperMaster> GetAllPapers()
        {
            //return this.PaperMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_PAPERS, 20, () => this.PaperMasterRepository.GetAll().ToList());
        }

        public List<CourseMaster> GetAllCourses()
        {
            //return this.CourseMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_COURSES, 20, () => this.CourseMasterRepository.GetAll().ToList());
        }

        public List<SubCourseMaster> GetAllSubCourses()
        {
            //return this.SubCourseMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_SUBCOURSES, 20, () => this.SubCourseMasterRepository.GetAll().ToList());
        }


        public List<Mcq> GetAllMcqs()
        {
            //return this.McqRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_MCQS, 20, () => this.McqRepository.GetAll().ToList());
        }

        public List<McqAnswer> GetAllMcqAnswers()
        {
            //return this.McqAnswerRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_MCQANSWERS, 20, () => this.McqAnswerRepository.GetAll().ToList());
        }

        public List<ProductMaster> GetAllProducts()
        {
            //return this.ProductMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_PRODUCTS, 20, () => this.ProductMasterRepository.GetAll().ToList());
        }

        public List<DiscountMaster> GetAllDiscounts()
        {
            //return this.DiscountMasterRepository.GetAll().ToList();
            return CacheService.Get(CachingKeys.CATALOG_DISCOUNTS, 20, () => this.DiscountMasterRepository.GetAll().ToList());
        }
    }
}
