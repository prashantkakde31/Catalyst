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
using Interpidians.Catalyst.Core.Common;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class ExamController : BaseController
    {
        private IExamService Service { get; set; }
        private IMcqService McqService { get; set; }
        private ILogger Logger { get; set; }
        private Exam currentExam { get; set; }


        public ExamController(IExamService service, IMcqService mcqService,ILogger loggerService)
        {
            this.Service = service;
            this.McqService = mcqService;
            this.Logger = loggerService;
        }

        //
        // GET: /Exam/
        //[CryptoValueProvider("id")]
        public virtual ActionResult Index(string id)
        {
            return View();
        }

        public virtual ActionResult Paper(string id,string paperName)
        {
            //Get Exam Questions Metadata
            List<Mcq> lstMcq = this.Service.GetAllExamMcq(Convert.ToInt32(id));
            TimeSpan totalTime = new TimeSpan(0, 0, 0);
            lstMcq.ForEach(x => { totalTime = totalTime.Add(x.TimeToSolve); });

            ViewData["PaperId"] = Crypto.Encrypt("id", id);
            ViewData["PaperName"] = paperName;
            ViewData["TotalQuestions"] = lstMcq.Count;
            ViewData["TotalTime"] = totalTime;
            return View();
        }

        /// <summary>
        /// Starts exam for requested Paper
        /// </summary>
        /// <param name="id">Paper Id</param>
        /// <param name="id">Question Sr No</param>
        /// <returns></return
        [CryptoValueProvider]
        public virtual ActionResult Start(string id,string SrNo)
        {
            Logger.Info("Paper-id:" + id + " SrNo:" + SrNo);

            if (string.IsNullOrEmpty(SrNo))
                SrNo = "1";
            int paperid = Convert.ToInt32(id);
            int i = 1;
            List<Mcq> lstExamMcq;

            //check if exam session is running
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS) && this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS).PaperID == paperid)
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
                lstExamMcq = this.sessionStore.GetItemFromSession<ExamQuestionPaperSet>(SessionKeys.EXAM_QUESTION_PAPER_SET).ExamQuestions;
            }
            else
            {
                this.currentExam = this.Service.StartExam(1, Convert.ToInt32(id), DateTime.Now);

                lstExamMcq=(from mcq in this.McqService.GetAllMcqs().Where(a => a.YearwisePaperID == paperid).ToList()
                 join ans in this.McqService.GetAllMcqAnswers().ToList() 
                 on mcq.McqID equals ans.McqID into mcqAnswers
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

                this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);
                this.sessionStore.SaveItemToSession<ExamQuestionPaperSet>(SessionKeys.EXAM_QUESTION_PAPER_SET,new ExamQuestionPaperSet() { ExamQuestions=lstExamMcq});
            }
            
            //lstMcq = this.McqService.GetAllMcqs().Where(a => a.YearwisePaperID == paperid).ToList();
            //lstMcqAnswer = this.McqService.GetAllMcqAnswers().ToList();
            ExamViewModel examVM = new ExamViewModel();
            examVM.CurrentExam = this.currentExam;
            //examVM.CurrentQuestion = this.Service.GetSingleExamMcq(Convert.ToInt32(id), Convert.ToInt32(SrNo));

            examVM.CurrentQuestion = lstExamMcq.Where(x=>x.PaperWiseSrNo == Convert.ToInt32(SrNo)).FirstOrDefault();
            //examVM.CurrentQuestion.McqAnswers = lstMcqAnswer.Where(x => x.McqID == examVM.CurrentQuestion?.McqID)?.ToList<McqAnswer>();
            examVM.CurrentQuestion.McqAnswers = lstExamMcq.Where(x => x.McqID == examVM.CurrentQuestion?.McqID).Select(x=>x.McqAnswers).FirstOrDefault();
            examVM.CurrentQuestion.McqAnswers.Where<McqAnswer>(x => x.McqAnswerID == this.currentExam.ExamDetails.Where<ExamDetail>(y => (y.McqID == x.McqID && y.SubmittedAnswerID != null)).Select(z => z.SubmittedAnswerID.GetValueOrDefault()).SingleOrDefault())?.ToList<McqAnswer>()?.ForEach(m => m.IsSelected=true);

            //Calculate exam summary details
            examVM.CurrentExamSummary = new ExamSummary();
            examVM.CurrentExam.ExamDetails.ToList<ExamDetail>().ForEach(x=> 
            {
                if (!string.IsNullOrEmpty(x.SubmittedAnswerID?.ToString()) && !x.IsMarkForReview) examVM.CurrentExamSummary.noOfQuestionAttempted++;
                if (x.IsSkipped) examVM.CurrentExamSummary.noOfQuestionSkipped++;
                if (x.IsMarkForReview) examVM.CurrentExamSummary.noOfQuestionMarkedForReview++;
                if ((!x.IsSkipped) && (!x.IsMarkForReview) && (string.IsNullOrEmpty(x.SubmittedAnswerID?.ToString()))) examVM.CurrentExamSummary.noOfQuestionNotAttempted++;
            });

            return View(MVC.Exam.Views.ViewNames.Start,examVM);
        }

        [HttpPost]
        public virtual ActionResult SubmitAnswer([JsonBinder]AnswerToSubmitVM answer)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Redirect(Url.Action(MVC.Exam.ExamSessionExpired()));
            }

            var mcqId = Crypto.Decrypt(answer.McqId);
            var answerId = Crypto.Decrypt(answer.AnswerId);

            if (answer.SrNo == this.currentExam.TotalQuestions)
                answer.SrNo = 0; // set SrNo = 0 when last answer is submitted or find and set it to first non-attempted question SrNo
            McqAnswer mcqAnswer = new McqAnswer();
            
            this.currentExam.ExamDetails.Where<ExamDetail>(x => x.ExamID == this.currentExam.ExamID && x.McqID == Convert.ToInt64(mcqId)).ToList<ExamDetail>().ForEach(x => { x.IsSkipped = false; x.SubmittedTime = DateTime.Now; x.SubmittedAnswerID = Convert.ToInt64(answerId); x.IsMarkForReview = answer.IsMarkForReview; if (answer.IsMarkForReview) x.QuestionStatus = "review"; else x.QuestionStatus = "attempt"; });
            this.currentExam.TotalTimeLeft = (new TimeSpan(answer.TimeLeft.SplitTimePart("H"), answer.TimeLeft.SplitTimePart("M"), answer.TimeLeft.SplitTimePart("S"))).Ticks / 10000000;
            this.Service.SubmitExamQuestionAnswer(currentExam.ExamID,
                new McqAnswer() { McqID = Convert.ToInt64(mcqId), McqAnswerID = Convert.ToInt64(answerId) }, TimeSpan.FromTicks(currentExam.TotalTimeLeft * 10000000),answer.IsMarkForReview);
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);
            return Redirect(Url.Action(MVC.Exam.Start(Crypto.Encrypt("id", this.currentExam.PaperID.ToString()), (Convert.ToInt32(answer.SrNo) + 1).ToString())));
        }

        [HttpPost]
        public virtual ActionResult SkipAnswer([JsonBinder]AnswerToSubmitVM answer)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Redirect(Url.Action(MVC.Exam.ExamSessionExpired()));
            }

            var mcqId = Crypto.Decrypt(answer.McqId);

            if (answer.SrNo == this.currentExam.TotalQuestions)
                answer.SrNo = 0; // set SrNo = 0 when last answer is submitted or find and set it to first non-attempted question SrNo

            this.currentExam.ExamDetails.Where<ExamDetail>(x => x.ExamID == this.currentExam.ExamID && x.McqID == Convert.ToInt64(mcqId)).ToList<ExamDetail>().ForEach(x => { x.IsSkipped = true; x.SubmittedTime = DateTime.Now; x.QuestionStatus = "skip"; });
            this.currentExam.TotalTimeLeft = (new TimeSpan(answer.TimeLeft.SplitTimePart("H"), answer.TimeLeft.SplitTimePart("M"), answer.TimeLeft.SplitTimePart("S"))).Ticks / 10000000;
            Int64 MCQID = Convert.ToInt64(mcqId);
            this.Service.SkipExamQuestion(currentExam.ExamID, MCQID, TimeSpan.FromTicks(currentExam.TotalTimeLeft * 10000000));
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);

            return RedirectToAction(MVC.Exam.Start(Crypto.Encrypt("id", this.currentExam.PaperID.ToString()), (Convert.ToInt32(answer.SrNo) + 1).ToString()));
        }

        [HttpPost]
        public virtual JsonResult PauseExamTimer(ExamTimerAndNavigatorVM examTimer)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Json(new { result = WebConstant.SessionExpired }, JsonRequestBehavior.AllowGet);
            }

            this.currentExam.TotalTimeLeft = (new TimeSpan(examTimer.TimeLeft.SplitTimePart("H"), examTimer.TimeLeft.SplitTimePart("M"), examTimer.TimeLeft.SplitTimePart("S"))).Ticks / 10000000;
            this.Service.StopTimer(currentExam.ExamID, TimeSpan.FromTicks(currentExam.TotalTimeLeft * 10000000));
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);

            return Json(new { result = WebConstant.Success }, JsonRequestBehavior.AllowGet);
            //return JavaScript("sucees");
        }

        [HttpPost]
        public virtual JsonResult ResumeExamTimer(ExamTimerAndNavigatorVM examTimer)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Json(new { result = WebConstant.SessionExpired }, JsonRequestBehavior.AllowGet);
            }

            this.currentExam.TotalTimeLeft =(new TimeSpan(examTimer.TimeLeft.SplitTimePart("H"), examTimer.TimeLeft.SplitTimePart("M"), examTimer.TimeLeft.SplitTimePart("S"))).Ticks;
            this.Service.StartTimer(currentExam.ExamID, TimeSpan.FromTicks(currentExam.TotalTimeLeft));
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);

            return Json(new { result = WebConstant.Success }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult NavigateToQuestion([JsonBinder]ExamTimerAndNavigatorVM examNavigator)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Redirect(Url.Action(MVC.Exam.ExamSessionExpired()));
            }

            this.currentExam.TotalTimeLeft = (new TimeSpan(examNavigator.TimeLeft.SplitTimePart("H"), examNavigator.TimeLeft.SplitTimePart("M"), examNavigator.TimeLeft.SplitTimePart("S"))).Ticks / 10000000;
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);

            return RedirectToAction(MVC.Exam.Start(Crypto.Encrypt("id", this.currentExam.PaperID.ToString()), (Convert.ToInt32(examNavigator.NavigateToSrNo)).ToString()));
        }

        public virtual ActionResult Result([JsonBinder]ExamTimerAndNavigatorVM examTimer)
        {
            if (this.sessionStore.ItemExists(SessionKeys.EXAM_DETAILS))
            {
                this.currentExam = this.sessionStore.GetItemFromSession<Exam>(SessionKeys.EXAM_DETAILS);
            }
            else
            {
                return Redirect(Url.Action(MVC.Exam.ExamSessionExpired()));
            }

            this.currentExam.TotalTimeLeft =(new TimeSpan(examTimer.TimeLeft.SplitTimePart("H"), examTimer.TimeLeft.SplitTimePart("M"), examTimer.TimeLeft.SplitTimePart("S"))).Ticks;
            this.sessionStore.SaveItemToSession<Exam>(SessionKeys.EXAM_DETAILS, this.currentExam);

            TimeSpan timeSpent;
            TimeSpan.TryParseExact(Convert.ToString(this.currentExam.TotalTime - this.currentExam.TotalTimeLeft), "g", CultureInfo.InvariantCulture, out timeSpent);
            ExamResult obj = this.Service.EndExam(currentExam.ExamID);
            this.sessionStore.RemoveItemFromSession(SessionKeys.EXAM_DETAILS);
            return View(obj);    
        }

        public virtual ActionResult ExamSessionExpired()
        {
            return View(MVC.Exam.Views.ViewNames.ExamSessionExpired);
        }
    }
}
