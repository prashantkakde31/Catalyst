using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class CourseMaster : BaseEntity
    {
        public int CourseID { get; set; } // int, not null

        public string Name { get; set; } // nvarchar(50), not null

        public string Description { get; set; } // nvarchar(max), null

        public bool IsVisible { get; set; } // bit, not null
    }
}
