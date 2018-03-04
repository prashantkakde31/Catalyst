using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class CheckoutCartSummaryViewModel
    {
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Vat { get; set; }
        public string TransactionCurrency { get; set; }
    }
}