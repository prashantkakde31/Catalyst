using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class McqAnswer
    {
        public long McqAnswerID { get; set; } // bigint, not null

        public long McqID { get; set; } // bigint, not null

        public string SN { get; set; } // nvarchar(5), null

        public string AnswerType { get; set; } // nvarchar(30), null

        public string Answer { get; set; } // nvarchar(max), null

        public string AnswerImage { get; set; } // nvarchar(max), null

        public bool IsVisible { get; set; } // bit, not null

        public bool IsSelected { get; set; } // bit, null
    }
}
