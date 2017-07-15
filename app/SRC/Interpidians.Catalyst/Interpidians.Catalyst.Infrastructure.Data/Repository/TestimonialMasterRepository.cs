using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class TestimonialMasterRepository:BaseRepository,ITestimonialRepository
    {
        public IEnumerable<Testimonial> GetAll()
        {
            IEnumerable<Testimonial> lstTestimonial;
            lstTestimonial = this.DB.ExecuteSprocAccessor<Testimonial>("usp_GetAllTestimonial");
            return lstTestimonial;
        }

        public Testimonial GetById(IdentifiableData id)
        {
            Testimonial testimonial = new Testimonial();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetTestimonialById", id))
            {
                MapRecord(IReader, testimonial);
            }
            return testimonial;
        }

        public void Add(Testimonial Testimonial)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddTestimonial");
            this.DB.AddInParameter(saveCommand, "@AuthorName", DbType.String, Testimonial.AuthorName);
            this.DB.AddInParameter(saveCommand, "@Photo", DbType.String, Testimonial.Photo);
            this.DB.AddInParameter(saveCommand, "@Contents", DbType.String,Testimonial.Contents);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, Testimonial.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, Testimonial.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, Testimonial.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, Testimonial.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, Testimonial.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(Testimonial Testimonial)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateTestimonial");
            this.DB.AddInParameter(saveCommand, "@TestimonialID", DbType.Int32, Testimonial.TestimonialID);
            this.DB.AddInParameter(saveCommand, "@AuthorName", DbType.String, Testimonial.AuthorName);
            this.DB.AddInParameter(saveCommand, "@Photo", DbType.String, Testimonial.Photo);
            this.DB.AddInParameter(saveCommand, "@Contents", DbType.String, Testimonial.Contents);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, Testimonial.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, Testimonial.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, Testimonial.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, Testimonial.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, Testimonial.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
