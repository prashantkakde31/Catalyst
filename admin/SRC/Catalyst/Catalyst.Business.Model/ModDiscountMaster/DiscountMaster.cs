using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Business.Model.ModDiscountMaster
{
    public class DiscountMaster
    {
        public int DiscountID;

        public string Name;

        public string Description;

        public double Percentage;

        public DateTime ValidFrom;

        public DateTime ValidTo;

        //public bool IsVisible;

        public int CreatedBy;

        public int UpdatedBy;
    }
}
