using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class PaymentSummaryViewModel
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal AmountToBePaid { get; set; }
        public decimal VAT { get; set; }
        public List<ProductMaster> ProductInfo { get; set; }
    }
}