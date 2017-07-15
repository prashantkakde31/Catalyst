using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class GradeMaster : BaseEntity
    {
        public int GradeID { get; set; } // int, not null

        public string Grade { get; set; } // nvarchar(50), not null

        public string Description { get; set; } // nvarchar(max), null

        public bool IsVisible { get; set; } // bit, not null
    }
}
