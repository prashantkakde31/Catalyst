using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class ExamService : IExamService
    {
        private IMcqRepository McqRepository { get; set; }

        private IExamRepository ExamRepository { get; set; }

        private IExamDetailRepository ExamDetailRepository { get; set; }
        private IExamResultRepository ExamResultRepository { get; set; }

        public ExamService(IMcqRepository mcqRepository, IExamRepository examRepository, IExamDetailRepository examDetailRepository, IExamResultRepository examResultRepository)
        {
            this.McqRepository = mcqRepository;
            this.ExamRepository = examRepository;
            this.ExamDetailRepository = examDetailRepository;
            this.ExamResultRepository = examResultRepository;
        }

        public List<Mcq> GetAllExamMcq(int paperId)
        {
            return this.McqRepository.GetAll().Where<Mcq>(x => x.TopicwisePaperID == paperId || x.YearwisePaperID == paperId).ToList<Mcq>();
        }

        public Mcq GetSingleExamMcq(long mcqId)
        {
            return this.McqRepository.GetAll().Where<Mcq>(x => x.McqID == mcqId).SingleOrDefault<Mcq>();
        }

        public Mcq GetSingleExamMcq(int paperId, int srNo)
        {
            //return this.McqRepository.GetAll().Where<Mcq>(x => (x.TopicwisePaperID == paperId || x.YearwisePaperID == paperId) && (x.TopicWiseSrNo == srNo || x.PaperWiseSrNo == srNo)).SingleOrDefault<Mcq>();
            return this.McqRepository.GetAll().Where<Mcq>(x => (x.YearwisePaperID == paperId) && (x.PaperWiseSrNo == srNo)).SingleOrDefault<Mcq>();
        }

        public Exam StartExam(int userId, int paperId, DateTime startTime)
        {
            Exam objExam=this.ExamRepository.StartExam(userId, paperId, startTime);
            objExam.ExamDetails = this.ExamDetailRepository.GetAll().Where<ExamDetail>(x => x.ExamID == objExam.ExamID).ToList<ExamDetail>();
            return objExam;
        }
        public ExamResult EndExam(long examId)
        { 
            this.ExamRepository.EndExam(examId);
            return this.ExamResultRepository.getResultByExamId(examId);
        }

        public void StartTimer(long examId, TimeSpan/*DateTime*/ timeLeft)
        {
            this.ExamRepository.ResumeExamTimer(examId, timeLeft);
        }

        public void StopTimer(long examId, TimeSpan/*DateTime*/ timeLeft)
        {
            this.ExamRepository.StopExamTimer(examId, timeLeft);
        }

        public void SkipExamQuestion(long examId, long mcqId, TimeSpan/*DateTime*/ timeLeft)
        {
            this.ExamRepository.SkipExamQuestion(examId, mcqId, timeLeft);
        }

        public void SubmitExamQuestionAnswer(long examId, McqAnswer mcqAnswer, TimeSpan/*DateTime*/ timeLeft, bool isMarkForReview)
        {
            this.ExamRepository.SubmitExamQuestionAnswer(examId, mcqAnswer.McqID, DateTime.Now, mcqAnswer.McqAnswerID, timeLeft,isMarkForReview);
        }
        public IEnumerable<Exam> GetAll()
        {
            List<Exam> lstExam = new List<Exam>();
            return lstExam;
        }
    }
}
