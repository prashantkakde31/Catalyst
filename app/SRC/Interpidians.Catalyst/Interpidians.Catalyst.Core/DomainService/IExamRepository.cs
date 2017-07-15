using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
    public interface IExamRepository
    {
        Exam StartExam(int userId, int paperId, DateTime startTime);
        //Exam EndExam(long examId, DateTime endTime);
        void EndExam(long examId);

        void ResumeExamTimer(long examId, TimeSpan/*DateTime*/ timeLeft);
        void StopExamTimer(long examId, TimeSpan/*DateTime*/ timeLeft);

        void SkipExamQuestion(long examId, long mcqId, TimeSpan/*DateTime*/ timeLeft);

        void SubmitExamQuestionAnswer(long examId, long mcqId, DateTime submissionTime, long answerId, TimeSpan/*DateTime*/ timeLeft, bool isMarkForReview);
    }
}
