using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class ExamRepository :BaseRepository, IExamRepository
    {
        public IEnumerable<Exam> GetAll()
        {
            IEnumerable<Exam> lstEmployee;
            lstEmployee = this.DB.ExecuteSprocAccessor<Exam>("usp_GetAllExam");
            return lstEmployee;
        }

        public Exam StartExam(int userId, int paperId, DateTime startTime)//expecting userId=1 and paperId=1
        {
            Exam objExam = new Exam();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_StartExam",userId,paperId,startTime))
            {
                MapRecord(IReader, objExam);
            }
            return objExam;
        }

        public void EndExam(long examId)//stored procedure for Ending exam
        {
            DbCommand StartCommand = this.DB.GetStoredProcCommand("usp_EndExam");
            this.DB.AddInParameter(StartCommand, "@ExamId", DbType.Int64, examId);
            this.DB.ExecuteNonQuery(StartCommand);
            if (StartCommand != null) StartCommand.Dispose();
        }
        public void ResumeExamTimer(long examId, TimeSpan/*DateTime*/ timeLeft)
        {
            DbCommand StartCommand = this.DB.GetStoredProcCommand("usp_ResumeExamTimer");
            this.DB.AddInParameter(StartCommand, "@ExamId", DbType.Int64, examId);
            this.DB.AddInParameter(StartCommand, "@TimeLeft", DbType.Int64, timeLeft.Ticks / 10000000);
            this.DB.ExecuteNonQuery(StartCommand);
            if (StartCommand != null) StartCommand.Dispose();
        }

        public void StopExamTimer(long examId, TimeSpan/*DateTime*/ timeLeft)
        {
            DbCommand StartCommand = this.DB.GetStoredProcCommand("usp_PauseExamTimer");
            this.DB.AddInParameter(StartCommand, "@ExamId", DbType.Int64, examId);
            this.DB.AddInParameter(StartCommand, "@TimeLeft", DbType.Int64, timeLeft.Ticks / 10000000);
            this.DB.ExecuteNonQuery(StartCommand);
            if (StartCommand != null) StartCommand.Dispose();
        }

        public void SkipExamQuestion(long examId, long mcqId, TimeSpan/*DateTime*/ timeLeft)
        {
            DbCommand StartCommand = this.DB.GetStoredProcCommand("usp_SkipAnswer");
            this.DB.AddInParameter(StartCommand, "@ExamId", DbType.Int64, examId);
            this.DB.AddInParameter(StartCommand, "@McqId", DbType.Int64, mcqId);
            this.DB.AddInParameter(StartCommand, "@TimeLeft", DbType.Int64, timeLeft.Ticks / 10000000);
            this.DB.ExecuteNonQuery(StartCommand);
            if (StartCommand != null) StartCommand.Dispose();
            }

        public void SubmitExamQuestionAnswer(long examId, long mcqId, DateTime submissionTime, long answerId,TimeSpan/*DateTime*/ timeLeft, bool isMarkForReview)
        {
            DbCommand StartCommand = this.DB.GetStoredProcCommand("usp_SubmitAnswer");
            this.DB.AddInParameter(StartCommand, "@ExamId", DbType.Int64, examId);
            this.DB.AddInParameter(StartCommand, "@McqId", DbType.Int64, mcqId);
            this.DB.AddInParameter(StartCommand, "@SubmittedTime", DbType.DateTime, submissionTime);
            this.DB.AddInParameter(StartCommand, "@AnswerId", DbType.Int64, answerId);
            this.DB.AddInParameter(StartCommand, "@TimeLeft", DbType.Int64, timeLeft.Ticks / 10000000);//DbType.Time
            this.DB.AddInParameter(StartCommand, "@IsMarkForReview", DbType.Boolean, isMarkForReview);
            this.DB.ExecuteNonQuery(StartCommand);
            if (StartCommand != null) StartCommand.Dispose();
            }     
    }
}
