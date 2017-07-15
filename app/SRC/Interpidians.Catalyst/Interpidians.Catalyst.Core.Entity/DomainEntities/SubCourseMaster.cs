using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class SubCourseMaster : BaseEntity
    {
        public int SubCourseID { get; set; } // int, not null

        public int CourseID { get; set; } // int, not null

        public string Name { get; set; } // nvarchar(50), null

        public bool IsVisible { get; set; } // bit, not null
    }
}
