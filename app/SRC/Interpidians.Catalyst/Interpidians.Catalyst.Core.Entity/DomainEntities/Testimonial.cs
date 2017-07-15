using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class Testimonial : BaseEntity
    {
        public int TestimonialID { get; set; } // int, not null

        public string AuthorName { get; set; } // nvarchar(50), not null

        public string Photo { get; set; } // nvarchar(500), not null

        public string Contents { get; set; } // nvarchar(max), not null

        public bool IsVisible { get; set; } // bit, not null
    }
}
