using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart UserShoppingCart { get; set; }
        public List<ProductMaster> ProductsInCart { get; set; }
        public decimal TotalCartPrice { get; set; }
        public decimal TotalCartDiscountPrice { get; set; }
        public int TotalCartItemCount { get; set; }
        public string BaseCurrencySymbol { get; set; }
    }
}