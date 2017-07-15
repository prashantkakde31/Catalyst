using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class ExamViewModel
    {
        public Exam CurrentExam { get; set; }
        public Mcq CurrentQuestion { get; set; }
        public ExamSummary CurrentExamSummary { get; set; }

    }

    public class ExamSummary
    {
        public int noOfQuestionAttempted { get; set; }

        public int noOfQuestionNotAttempted { get; set; }

        public int noOfQuestionSkipped { get; set; }

        public int noOfQuestionMarkedForReview { get; set; }
    }

    public class AnswerToSubmitVM
    {
        public string ExamId { get; set; }
        public string McqId { get; set; }
        public string AnswerId { get; set; }
        public int SrNo { get; set; }
        public string TimeLeft { get; set; }
        public bool IsMarkForReview { get; set; }
    }

    public class ExamTimerAndNavigatorVM
    {
        public string ExamId { get; set; }
        public string TimeLeft { get; set; }
        public int NavigateToSrNo { get; set; }
    }
}