using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface IExamService
    {
        List<Mcq> GetAllExamMcq(int paperId);
        Mcq GetSingleExamMcq(long mcqId);
        Mcq GetSingleExamMcq(int paperId,int srNo);
        

        Exam StartExam(int userId,int paperId,DateTime startTime);
        //Exam EndExam(long examId,DateTime endTime);
        ExamResult EndExam(long examId);


        void StartTimer(long examId, TimeSpan/*DateTime*/ timeLeft);
        void StopTimer(long examId, TimeSpan/*DateTime*/ timeLeft);

        void SkipExamQuestion(long examId, long mcqId, TimeSpan/*DateTime*/ timeLeft);
        void SubmitExamQuestionAnswer(long examId, McqAnswer mcqAnswer, TimeSpan/*DateTime*/ timeLeft,bool isMarkForReview);
         IEnumerable<Exam> GetAll();
    }
}
