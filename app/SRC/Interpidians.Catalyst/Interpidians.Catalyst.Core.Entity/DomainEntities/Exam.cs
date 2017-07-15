using System;
using System.Collections.Generic;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class Exam : BaseEntity
    {
        public Exam()
        {
            this.ExamDetails = new List<ExamDetail>();
        }

        public long ExamID { get; set; } // bigint, not null

        public int UserID { get; set; } // int, not null

        public int PaperID { get; set; } // int, not null

        public DateTime? StartTime { get; set; } // datetime, null

        public DateTime? EndTime { get; set; } // datetime, null

        public int? TotalQuestions { get; set; } // int, null

        public int? AttemptedQuestions { get; set; } // int, null

        public int? NonAttemptedQuestions { get; set; } // int, null

        public decimal? TotalMarks { get; set; } // numeric(5,2), null

        public decimal? Score { get; set; } // numeric(5,2), null

        public string Result { get; set; } // nvarchar(30), null

        //public TimeSpan? TotalTime { get; set; } // time(7), null
        //public DateTime? TotalTime { get; set; }
        public Int64 TotalTime { get; set; }

        public bool IsTimerOn { get; set; } // bit, not null

        //public TimeSpan TotalTimeLeft { get; set; } // time(7), null
        //public DateTime TotalTimeLeft { get; set; }
        public Int64 TotalTimeLeft { get; set; }

        public bool IsCompleted { get; set; } // bit, not null

        public string DisableQuestionAnswer { get; set; } // bit,  null

        //public IEnumerable<ExamDetail> ExamDetails;
        public IList<ExamDetail> ExamDetails;

    }
}
