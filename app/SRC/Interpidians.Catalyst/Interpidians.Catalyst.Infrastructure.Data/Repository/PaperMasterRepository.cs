using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class PaperMasterRepository:BaseRepository,IPaperMasterRepository
    {
        public IEnumerable<PaperMaster> GetAll()
        {
            IEnumerable<PaperMaster> lstPaper;
            lstPaper = this.DB.ExecuteSprocAccessor<PaperMaster>("usp_GetAllPaper");
            return lstPaper;
        }

        public PaperMaster GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        public void Add(PaperMaster paperMaster)
        {
            //usp_AddPaper is the name of stored procedure but dont know how to use it
            throw new NotImplementedException();
        }

        public void Update(PaperMaster paperMaster)
        {
            //usp_UpdatePaper is the name of stored procedure but dont know how to use it
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            //usp_DeletePaper is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeletePaper");
            this.DB.AddInParameter(saveCommand, "@PaperID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
