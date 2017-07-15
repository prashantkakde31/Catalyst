using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class PaperMaster : BaseEntity
    {
        public int PaperID { get; set; } // int, not null

        public int SubjectId { get; set; } // int, not null

        public int? TopicID { get; set; } // int, null

        public int? GradeID { get; set; } // int, null

        public bool IsYearwise { get; set; } // bit, not null

        public int? Year { get; set; } // int, null

        public int? Month { get; set; } // int, null

        public bool IsSample { get; set; } // bit, not null

        public string Name { get; set; } // nvarchar(50), not null

        public string Description { get; set; } // nvarchar(max), null

        public bool IsVisible { get; set; } // bit, not null

        public bool Disable { get; set; } // bit, not null

        public string DisableQuestionAnswer { get; set; } // bit,  null
    }
}
