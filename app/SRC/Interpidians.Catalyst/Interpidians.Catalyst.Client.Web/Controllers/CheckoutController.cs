using Interpidians.Catalyst.Client.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Utility;
using Interpidians.Catalyst.Client.Web.Common;
using Interpidians.Catalyst.Client.Web.ViewModels;
using System.Web.Routing;
using System.Globalization;
using Interpidians.Catalyst.Core.Common;
namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class CheckoutController : BaseController
    {
        #region Properties
        private IShoppingCartService ShoppingCartService { get; set; }
        private ICatalystService CatalystService { get; set; }
        private ILogger Logger { get; set; }
        private UserMaster CurrentUser => this.GetCurrentUser();
        #endregion

        #region Constructor
        public CheckoutController(IShoppingCartService shoppingCartService, ICatalystService catalystService, ILogger loggerService)
        {
            this.ShoppingCartService = shoppingCartService;
            this.CatalystService = catalystService;
            this.Logger = loggerService;
        }
        #endregion
        //
        // GET: /Checkout/
        [AuthorizeAction]
        public virtual ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public virtual ActionResult LoadCheckoutCartSummary()
        {
            CheckoutCartSummaryViewModel chkoutSummaryVM = GetCheckoutCartSummaryData();

            if (chkoutSummaryVM == null)
            {
                return GetEmptyCheckoutCartSummary();
            }
            else
            {
                return PartialView(MVC.Shared.Views.ViewNames._CheckoutCartSummary, chkoutSummaryVM);
            }
        }

        [ChildActionOnly]
        public virtual ActionResult LoadCheckoutItems()
        {
            List<ProductMaster> lstCheckoutItems = GetCheckoutItemsData();

            if (lstCheckoutItems == null)
            {
                return GetEmptyCheckoutItems();
            }
            else
            {
                return PartialView(MVC.Shared.Views.ViewNames._CheckoutItems, lstCheckoutItems);
            }
        }

        // POST: /Checkout/GetCheckoutItems - Ajax Call
        [HttpPost]
        public virtual ContentResult GetCheckoutItems()
        {
            List<ProductMaster> lstCheckoutItems = GetCheckoutItemsData();

            if (lstCheckoutItems == null)
            {
                return GetEmptyCheckoutItems();
            }
            else
            {
                string cartContent = this.Render(this, MVC.Shared.Views.ViewNames._CheckoutItems, lstCheckoutItems);
                return Content(cartContent);
            }
        }

        // POST: /Checkout/GetCheckoutCartSummary - Ajax Call
        [HttpPost]
        public virtual ContentResult GetCheckoutCartSummary()
        {
            CheckoutCartSummaryViewModel chkoutSummaryVM = GetCheckoutCartSummaryData();

            if (chkoutSummaryVM == null)
            {
                return GetEmptyCheckoutCartSummary();
            }
            else
            {
                string cartContent = this.Render(this, MVC.Shared.Views.ViewNames._CheckoutCartSummary, chkoutSummaryVM);
                return Content(cartContent);
            }
        }

        private CheckoutCartSummaryViewModel GetCheckoutCartSummaryData()
        {
            if (CurrentUser == null)
            {
                return null;
            }

            CheckoutCartSummaryViewModel chkoutSummaryVM = new CheckoutCartSummaryViewModel();
            ShoppingCart userShoppingCart = ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).FirstOrDefault();
            List<int> productIds = ShoppingCartService.GetCartItems(userShoppingCart.ShoppingCartID).Select(x => x.ProductID).ToList();

            if (productIds.Count() == 0)
            {
                return null;
            }

            List<ProductMaster> lstCartProducts = CatalystService.GetAllProducts().Where(x => productIds.Contains(x.ProductID)).ToList();
            List<DiscountMaster> lstDiscounts = CatalystService.GetAllDiscounts().ToList();



            chkoutSummaryVM.SubTotal = lstCartProducts.Sum(x => x.Price);
            chkoutSummaryVM.Discount = lstCartProducts.Sum(x => (x.Price * lstDiscounts.Where(y => y.DiscountID == x.DiscountID).Select(z => Convert.ToDecimal(z.Percentage)).FirstOrDefault()) / 100);
            chkoutSummaryVM.GrandTotal = chkoutSummaryVM.SubTotal - chkoutSummaryVM.Discount - chkoutSummaryVM.Vat;

            return chkoutSummaryVM;
        }

        private List<ProductMaster> GetCheckoutItemsData()
        {

            if (CurrentUser == null)
            {
                return null;
            }
            List<CartItem> lstCartItems = ShoppingCartService.GetCartItems(GetCartId()).ToList();
            List<int> productIds = lstCartItems.Select(x => x.ProductID).ToList();

            if (productIds.Count() == 0)
            {
                return null;
            }

            return CatalystService.GetAllProducts().Where(x => productIds.Contains(x.ProductID)).ToList();
        }

        private long GetCartId()
        {
            if (CurrentUser == null)
            {
                return 0;
            }
            else
            {
                return ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).Select(y => y.ShoppingCartID).FirstOrDefault();
            }
        }
        public virtual ContentResult GetEmptyCheckoutCartSummary()
        {
            string emptyCartContent = this.Render(this, MVC.Shared.Views.ViewNames._CheckoutCartSummary, null);
            return Content(emptyCartContent);
        }

        public virtual ContentResult GetEmptyCheckoutItems()
        {
            string emptyCartContent = this.Render(this, MVC.Shared.Views.ViewNames._CheckoutItems, null);
            return Content(emptyCartContent);
        }
    }
}
