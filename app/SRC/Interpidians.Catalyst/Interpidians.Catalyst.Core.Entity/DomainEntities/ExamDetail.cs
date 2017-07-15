using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class ExamDetail
    {
        public long ExamDetailID { get; set; } // bigint, not null

        public long ExamID { get; set; } // bigint, not null

        public long McqID { get; set; } // bigint, not null

        public string QuestionStatus { get; set; } // nvarchar(30), null

        public long? SubmittedAnswerID { get; set; } // bigint, null

        public DateTime? SubmittedTime { get; set; } // datetime, null

        public bool IsSkipped { get; set; } // bit, not null

        public bool IsMarkForReview { get; set; } // bit, not null

        //public int SrNo { get; set; } // bit, not null
    }
}
