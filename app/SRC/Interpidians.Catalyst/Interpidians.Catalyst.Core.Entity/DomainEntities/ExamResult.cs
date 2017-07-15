using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    //public partial class ExamResult
    //{
    //    public long ExamResultID { get; set; }
    //    public long ExamID { get; set; }
    //    public int Percentage { get; set; }
    //    public int IncorrectPercentage { get; set; }
    //    public int SkipPercentage { get; set; }
    //    public int TimeSpent { get; set; }
    //    public int TimeSpentPercentage { get; set; }
    // }

    public partial class ExamResult
    {
        public long ExamResultID { get; set; }
        public long? ExamID { get; set; }
        public int? NoOfCorrectAnswer { get; set; }
        public int? NoOfIncorrectAnswer { get; set; }
        public int? NoOfSkippedAnswer { get; set; }
        public int? NoOfMarkForReviewAnswer { get; set; }
        public TimeSpan? TimeSpent { get; set; }
        public int? TimeSpentPercentage { get; set; }
        public int? Percentage { get; set; }
    }
}
