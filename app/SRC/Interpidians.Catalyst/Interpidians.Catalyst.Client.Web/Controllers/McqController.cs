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
        private ICatalystService CatalystService { get; set; }
        public McqController(ICatalystService catalystService)
        {
            this.CatalystService = catalystService;
        }
        //
        // GET: /Mcq/

        public virtual ActionResult Index()
        {
            List<SubjectMaster> lstSub = this.CatalystService.GetAllSubjects();
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

            int subcourseId = (from subcourseid in this.CatalystService.GetAllSubCourses().Where(a => a.Name == subcourse) select subcourseid.SubCourseID).FirstOrDefault();
            List<SubjectMaster> lstSub = this.CatalystService.GetAllSubjects().Where(a => a.SubCourseID == subcourseId).ToList();
            ViewBag.SubjectList = lstSub;
            int sm = (from subjectid in lstSub.Where(a => a.Name == subject) select subjectid.SubjectID).FirstOrDefault();
            List<TopicMaster> lstTopic = this.CatalystService.GetAllTopics().Where(a => a.SubjectID == sm).ToList();
            List<PaperMaster> lstPaper = this.CatalystService.GetAllPapers().Where(a => a.SubjectId == sm).ToList();

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
            //int subcourseId = (from subcourseid in this.McqService.getAllTopics().Where(a => a.TopicID == topicid) select subcourseid.SubjectID).FirstOrDefault();
            List<Mcq> lstMcq = this.CatalystService.GetAllMcqs().Where(a => a.TopicwisePaperID == topicid).ToList();
            List<McqAnswer> lstMcqAnswer = this.CatalystService.GetAllMcqAnswers().ToList();
            int i = 1;

            //lstMcq?.ForEach(x=> { x.TopicWiseSrNo = i++; });

            var result = (from mcq in lstMcq
                       join ans in lstMcqAnswer on mcq.McqID equals ans.McqID into mcqAnswers
                       let Rank = i++
                       select new Mcq
                       {
                           McqID = mcq.McqID,
                           CommonAnswerImage = mcq.CommonAnswerImage,
                           CorrectAnswerID = mcq.CorrectAnswerID,
                           HintAudioLink = mcq.HintAudioLink,
                           HintImageLink = mcq.HintImageLink,
                           HintText = mcq.HintText,
                           HintVideoUrl = mcq.HintVideoUrl,
                           IsVisible = mcq.IsVisible,
                           Marks = mcq.Marks,
                           PaperWiseSrNo = mcq.PaperWiseSrNo,
                           QuestionAudioLink = mcq.QuestionAudioLink,
                           QuestionImage2 = mcq.QuestionImage2,
                           QuestionImageLink = mcq.QuestionImageLink,
                           QuestionText1 = mcq.QuestionText1,
                           QuestionText2 = mcq.QuestionText2,
                           SupportedDocumentLink=mcq.SupportedDocumentLink,
                           SupportedDocumentLink2=mcq.SupportedDocumentLink2,
                           SupportedDocumentLink3 = mcq.SupportedDocumentLink3,
                           TimeToSolve=mcq.TimeToSolve,
                           TopicwisePaperID=mcq.TopicwisePaperID,
                           TopicWiseSrNo= Rank,
                           VideoLink=mcq.VideoLink,
                           YearwisePaperID=mcq.YearwisePaperID,
                           McqAnswers = mcqAnswers.ToList()
                       }).ToList();

            TopicMcqViewModel objTopicMcqViewModel = new TopicMcqViewModel();
            objTopicMcqViewModel.McqList = result;
            return View(objTopicMcqViewModel);
        }

        [CryptoValueProvider]
        public virtual ActionResult Paper(string id)
        {
            int paperID = Convert.ToInt32(id);
            //int subcourseId = (from subcourseid in this.McqService.getAllTopics().Where(a => a.TopicID == paperID) select subcourseid.SubjectID).FirstOrDefault();
            List<Mcq> lstMcq = this.CatalystService.GetAllMcqs().Where(a => a.YearwisePaperID == paperID).ToList();
            List<McqAnswer> lstMcqAnswer = this.CatalystService.GetAllMcqAnswers().ToList();
            int i = 1;

            //lstMcq?.ForEach(x=> { x.TopicWiseSrNo = i++; });

            var result = (from mcq in lstMcq
                          join ans in lstMcqAnswer on mcq.McqID equals ans.McqID into mcqAnswers
                          let Rank = i++
                          select new Mcq
                          {
                              McqID = mcq.McqID,
                              CommonAnswerImage = mcq.CommonAnswerImage,
                              CorrectAnswerID = mcq.CorrectAnswerID,
                              HintAudioLink = mcq.HintAudioLink,
                              HintImageLink = mcq.HintImageLink,
                              HintText = mcq.HintText,
                              HintVideoUrl = mcq.HintVideoUrl,
                              IsVisible = mcq.IsVisible,
                              Marks = mcq.Marks,
                              PaperWiseSrNo = Rank,
                              QuestionAudioLink = mcq.QuestionAudioLink,
                              QuestionImage2 = mcq.QuestionImage2,
                              QuestionImageLink = mcq.QuestionImageLink,
                              QuestionText1 = mcq.QuestionText1,
                              QuestionText2 = mcq.QuestionText2,
                              SupportedDocumentLink = mcq.SupportedDocumentLink,
                              SupportedDocumentLink2 = mcq.SupportedDocumentLink2,
                              SupportedDocumentLink3 = mcq.SupportedDocumentLink3,
                              TimeToSolve = mcq.TimeToSolve,
                              TopicwisePaperID = mcq.TopicwisePaperID,
                              TopicWiseSrNo = Rank,
                              VideoLink = mcq.VideoLink,
                              YearwisePaperID = mcq.YearwisePaperID,
                              McqAnswers = mcqAnswers.ToList()
                          }).ToList();

            PaperMcqViewModel objTopicMcqViewModel = new PaperMcqViewModel();
            objTopicMcqViewModel.McqList = result;
            return View(objTopicMcqViewModel);
        }

        public virtual ActionResult Buy(string course, string subcourse, string subject)
        {
            //http://localhost:51260/Mcq/Buy/?course=IB&subcourse=f&subject=f
            //http://localhost:51260/Mcq/Buy/IB/f/f
            //http://localhost:51260/Mcq/Buy/IGCSE/Grade 10/Physics

            ViewBag.SubjectName = subject;
            ViewBag.CourseName = course;
            ViewBag.Subcourse = subcourse;

            int subcourseId = (from subcourseid in this.CatalystService.GetAllSubCourses().Where(a => a.Name == subcourse) select subcourseid.SubCourseID).FirstOrDefault();
            List<SubjectMaster> lstSub = this.CatalystService.GetAllSubjects().Where(a => a.SubCourseID == subcourseId).ToList();
            ViewBag.SubjectList = lstSub;
            int sm = (from subjectid in lstSub.Where(a => a.Name == subject) select subjectid.SubjectID).FirstOrDefault();
            List<ProductMaster> prodMaster = CatalystService.GetAllProducts().Where(prod => prod.SubjectID == sm).ToList();

            BuyMcqViewModel objBuyMcqViewModel = new BuyMcqViewModel();
            objBuyMcqViewModel.TopicList = prodMaster.Where(x=>Convert.ToString(x.ProductType).Equals("1")).ToList();
            objBuyMcqViewModel.PaperList = prodMaster.Where(x => Convert.ToString(x.ProductType).Equals("2")).ToList();
            objBuyMcqViewModel.SubjectList = lstSub;
            return View(objBuyMcqViewModel);
        }
    }
}
