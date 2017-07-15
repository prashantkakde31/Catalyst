using System;
using System.Collections.Generic;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class Mcq : BaseEntity
    {
        public Mcq()
        {
            this.McqAnswers = new List<McqAnswer>();
        }

        public long McqID { get; set; } // bigint, not null

        public int? TopicwisePaperID { get; set; } // int, null

        public int? YearwisePaperID { get; set; } // int, null

        public string QuestionText1 { get; set; } // nvarchar(max), null

        public string QuestionImageLink { get; set; } // nvarchar(4000), null

        public string QuestionAudioLink { get; set; } // nvarchar(4000), null

        public string QuestionText2 { get; set; } // nvarchar(max), null

        public string QuestionImage2 { get; set; } // nvarchar(4000), null

        public long? CorrectAnswerID { get; set; } // bigint, null

        //public string QuestionText3 { get; set; } // nvarchar(max), null removed

        //public string QuestionText4 { get; set; } // nvarchar(max), null removed

        public string HintText { get; set; } // nvarchar(max), null

        public string HintImageLink { get; set; } // nvarchar(4000), null

        public string HintAudioLink { get; set; } // nvarchar(4000), null

        //public string HintVideoLink { get; set; } // nvarchar(4000), null

        public string VideoLink { get; set; } // nvarchar(4000), null

        public string SupportedDocumentLink { get; set; } // nvarchar(4000), null

        public decimal? Marks { get; set; } // numeric(5,0), null

        //public string SolutionText { get; set; } // nvarchar(max), null removed

        //public string SolutionImageLink { get; set; } // nvarchar(4000), null removed

        public bool IsVisible { get; set; } // bit, not null

        public TimeSpan TimeToSolve { get; set; }

        public string SupportedDocumentLink2 { get; set; } // nvarchar(4000), null

        public string SupportedDocumentLink3 { get; set; } // nvarchar(4000), null

        public string HintVideoUrl { get; set; } // nvarchar(4000), null

        public string CommonAnswerImage { get; set; } // nvarchar(4000), null

        public int TopicWiseSrNo { get; set; } // int, null removed

        public int PaperWiseSrNo { get; set; } // int, null removed

        public IList<McqAnswer> McqAnswers { get; set; }
    }
}
