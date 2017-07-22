using Interpidians.Catalyst.Client.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Utility;
using Interpidians.Catalyst.Client.Web.Common;
using Interpidians.Catalyst.Client.Web.ViewModels;
using System.Web.Routing;
using System.Globalization;
using MvcSiteMapProvider.Web.Mvc.Filters;
using MvcSiteMapProvider;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class McqController : BaseController
    {
        private IExamService Service { get; set; }
        private Exam currentExam { get; set; }
        private IMcqService McqService { get; set; }
        public McqController(IMcqService mcqService)
        {
            this.McqService = mcqService;
        }
        //
        // GET: /Mcq/

        public virtual ActionResult Index()
        {
            List<SubjectMaster> lstSub = this.McqService.GetAllSubjects();
            return View(lstSub);
        }

        //Gets sample mcq based on course, subcourse, subject
        public virtual ActionResult Sample(string course, string subcourse, string subject)
        {
            //http://localhost:51260/Mcq/Sample/?course=IB&subcourse=f&subject=f
            //http://localhost:51260/Mcq/Sample/IB/f/f
            //http://localhost:51260/Mcq/Sample/IGCSE/Grade 10/Physics

            ViewBag.SubjectName = subject;
            ViewBag.CourseName = course;
            ViewBag.Subcourse =  subcourse;

            int subcourseId = (from subcourseid in this.McqService.getAllSubCourses().Where(a => a.Name == subcourse) select subcourseid.SubCourseID).FirstOrDefault();
            List<SubjectMaster> lstSub = this.McqService.GetAllSubjects().Where(a => a.SubCourseID == subcourseId).ToList();
            ViewBag.SubjectList = lstSub;
            int sm = (from subjectid in lstSub.Where(a => a.Name == subject) select subjectid.SubjectID).FirstOrDefault();
            List<TopicMaster> lstTopic = this.McqService.getAllTopics().Where(a => a.SubjectID == sm).ToList();
            List<PaperMaster> lstPaper = this.McqService.getAllPapers().Where(a => a.SubjectId == sm && (a.IsSample)).ToList();

            SampleMcqViewModel objSampleMcqViewModel = new SampleMcqViewModel();
            objSampleMcqViewModel.TopicWiseList = lstTopic;
            objSampleMcqViewModel.PaperWiseList = lstPaper;
            objSampleMcqViewModel.SubjectList = lstSub;
            return View(objSampleMcqViewModel);
        }

        [CryptoValueProvider]
        public virtual ActionResult Topic(string id)
        {
            int topicid = Convert.ToInt32(id);
            int subcourseId = (from subcourseid in this.McqService.getAllTopics().Where(a => a.TopicID == topicid) select subcourseid.SubjectID).FirstOrDefault();
            List<Mcq> lstMcq = this.McqService.getAllMcqs().Where(a => a.TopicwisePaperID == topicid).ToList();
            List<McqAnswer> lstMcqAnswer = this.McqService.getAllMcqAnswers().ToList();
            foreach (var item1 in lstMcq)
            {
                item1.McqAnswers = lstMcqAnswer.Where(x => x.McqID == item1.McqID).ToList<McqAnswer>();
            }

            TopicMcqViewModel objTopicMcqViewModel = new TopicMcqViewModel();
            objTopicMcqViewModel.McqList = lstMcq;
            return View(objTopicMcqViewModel);
        }

        [CryptoValueProvider]
        public virtual ActionResult Paper(string id)
        {
            int paperid = Convert.ToInt32(id);
            int subcourseId = (from subcourseid in this.McqService.getAllPapers().Where(a => a.PaperID == paperid) select subcourseid.SubjectId).FirstOrDefault();
            List<Mcq> lstMcq = this.McqService.getAllMcqs().Where(a => a.TopicwisePaperID == paperid).ToList();
            List<McqAnswer> lstMcqAnswer = this.McqService.getAllMcqAnswers().ToList();
            foreach (var item1 in lstMcq)
            {
                item1.McqAnswers = lstMcqAnswer.Where(x => x.McqID == item1.McqID).ToList<McqAnswer>();
            }

            TopicMcqViewModel objTopicMcqViewModel = new TopicMcqViewModel();
            objTopicMcqViewModel.McqList = lstMcq;
            return View(objTopicMcqViewModel);
        }

    }
}
