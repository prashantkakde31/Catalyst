using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Business.Model.ModPaperMaster
{
    public class PaperMaster
    {
        public int PaperID;

        public int SubjectId;

        //public int TopicID;

        public int GradeID;

        public int IsYearwise;

        public int Year;

        public int Month;

        public int IsSample;

        public string Name;

        public string Description;

        public int CreatedBy;

        public int UpdatedBy;
    }
}
