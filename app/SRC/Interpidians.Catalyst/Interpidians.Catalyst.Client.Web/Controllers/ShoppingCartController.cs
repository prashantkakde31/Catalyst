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
    public partial class ShoppingCartController : BaseController
    {
        private IShoppingCartService ShoppingCartService { get; set; }
        private ICatalystService CatalystService { get; set; }
        private ILogger Logger { get; set; }

        private UserMaster CurrentUser => this.GetCurrentUser();

        private long ShoppingCartId => this.GetCartId();

        public ShoppingCartController(IShoppingCartService shoppingCartService, ICatalystService catalystService, ILogger loggerService)
        {
            this.ShoppingCartService = shoppingCartService;
            this.CatalystService = catalystService;
            this.Logger = loggerService;
        }

        // POST: /ShoppingCart/GetCart - Ajax Call
        [HttpPost]
        public virtual ContentResult GetCart()
        {
            if (CurrentUser == null)
            {
                return GetEmptyCart();
            }

            ShoppingCartViewModel shoppingCartVM = new ShoppingCartViewModel();
            ShoppingCart userShoppingCart = ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).FirstOrDefault();
            userShoppingCart.CartItems = ShoppingCartService.GetCartItems(userShoppingCart.ShoppingCartID).ToList();
            List<int> productIds = userShoppingCart.CartItems.Select(x => x.ProductID).ToList();

            if (userShoppingCart.CartItems.Count() == 0 )
            {
                return GetEmptyCart();
            }

            List<ProductMaster> lstCartProducts = GetProducts(productIds);
            List<DiscountMaster> lstDiscounts = CatalystService.GetAllDiscounts().ToList();

            shoppingCartVM.UserShoppingCart = userShoppingCart;
            shoppingCartVM.ProductsInCart = lstCartProducts;
            shoppingCartVM.TotalCartItemCount = lstCartProducts.Count();
            shoppingCartVM.TotalCartDiscountPrice = lstCartProducts.Sum(x => (x.Price * lstDiscounts.Where(y => y.DiscountID == x.DiscountID).Select(z => Convert.ToDecimal(z.Percentage)).FirstOrDefault()) / 100);
            shoppingCartVM.TotalCartPrice = lstCartProducts.Sum(x => x.Price) - shoppingCartVM.TotalCartDiscountPrice;
            string cartContent = this.Render(this, MVC.Shared.Views.ViewNames._ShoppingCart,shoppingCartVM);
            return Content(cartContent);
        }

        public virtual ContentResult GetEmptyCart()
        {
            string emptyCartContent = this.Render(this, MVC.Shared.Views.ViewNames._EmptyShoppingCart, null);
            return Content(emptyCartContent);
        }

        [ChildActionOnly]
        public virtual ActionResult LoadUserCart()
        {
            if (CurrentUser == null)
            {
                return GetEmptyCart();
            }

            ShoppingCartViewModel shoppingCartVM = new ShoppingCartViewModel();
            ShoppingCart userShoppingCart = ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).FirstOrDefault();
            userShoppingCart.CartItems = ShoppingCartService.GetCartItems(userShoppingCart.ShoppingCartID).ToList();
            List<int> productIds = userShoppingCart.CartItems.Select(x => x.ProductID).ToList();

            if (userShoppingCart.CartItems.Count() == 0)
            {
                return GetEmptyCart();
            }

            List<ProductMaster> lstCartProducts = GetProducts(productIds);
            List<DiscountMaster> lstDiscounts = CatalystService.GetAllDiscounts().ToList();

            shoppingCartVM.UserShoppingCart = userShoppingCart;
            shoppingCartVM.ProductsInCart = lstCartProducts;
            shoppingCartVM.TotalCartItemCount = lstCartProducts.Count();
            shoppingCartVM.TotalCartDiscountPrice = lstCartProducts.Sum(x => (x.Price * lstDiscounts.Where(y => y.DiscountID == x.DiscountID).Select(z => Convert.ToDecimal(z.Percentage)).FirstOrDefault())/100);
            shoppingCartVM.TotalCartPrice = lstCartProducts.Sum(x => x.Price) - shoppingCartVM.TotalCartDiscountPrice;
            return PartialView(MVC.Shared.Views.ViewNames._ShoppingCart, shoppingCartVM);
        }
        private List<ProductMaster> GetProducts(List<int> productIds)
        {
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

        /// <summary>
        /// // POST: /ShoppingCart/AddItemToCart - Ajax Call
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult AddItemToCart(int productId)
        {
            ShoppingCartService.AddItemToCart(ShoppingCartId, productId);
            return Json(new { result = WebConstant.Success }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// // POST: /ShoppingCart/RemoveItemFromCart - Ajax Call
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult RemoveItemFromCart(int productId)
        {
            ShoppingCartService.RemoveItemFromCart(ShoppingCartId, productId);
            return Json(new { result = WebConstant.Success }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// // POST: /ShoppingCart/RemoveAllItemsFromCart - Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult RemoveAllItemsFromCart()
        {
            ShoppingCartService.RemoveAllItemsFromCart(ShoppingCartId);
            return Json(new { result = WebConstant.Success }, JsonRequestBehavior.AllowGet);
        }

    }
}
