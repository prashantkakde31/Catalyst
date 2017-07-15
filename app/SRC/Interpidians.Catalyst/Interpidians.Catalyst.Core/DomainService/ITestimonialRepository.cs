using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ITestimonialRepository
    {
        IEnumerable<Testimonial> GetAll();
        Testimonial GetById(IdentifiableData id);
        void Add(Testimonial Testimonial);
        void Update(Testimonial Testimonial);
        void Delete(IdentifiableData id);
    }
}
