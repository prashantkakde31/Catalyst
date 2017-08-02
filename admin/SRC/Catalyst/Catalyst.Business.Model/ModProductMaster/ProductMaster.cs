using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Business.Model.ModProductMaster
{
    public class ProductMaster
    {
        public int ProductID;

        public int DiscountID;

        public int SubjectID;

        public int TopicID;

        public int YearwisePaperID;

        public string Name;

        public string Description;

        public double Price;

        public string BaseCurrency;

        public DateTime ValidFrom;

        public DateTime ValidUpto;

        public int CreatedBy;

        public int UpdatedBy;
    }
}
