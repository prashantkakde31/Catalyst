using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interpidians.Catalyst.Core.Utility;
using System.Text;
using Interpidians.Catalyst.Client.Web.ViewModels;
using Interpidians.Catalyst.Client.Web.Common;
using System.Configuration;
using System.Collections;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class PaymentController : BaseController
    {
        #region Properties
        private IShoppingCartService ShoppingCartService { get; set; }
        private IPaymentService PaymentService { get; set; }
        private ICatalystService CatalystService { get; set; }
        private ILogger Logger { get; set; }
        private UserMaster CurrentUser => this.GetCurrentUser();
        #endregion

        #region Constructors
        public PaymentController(IShoppingCartService shoppingCartService, IPaymentService paymentService,ICatalystService catalystService, ILogger loggerService)
        {
            this.CatalystService = catalystService;
            this.ShoppingCartService = shoppingCartService;
            this.PaymentService = paymentService;
            this.Logger = loggerService;
        }
        #endregion

        //
        // GET: /Payment/
        [AuthorizeAction]
        public virtual ActionResult PayUMoney()
        {
            PaymentSummaryViewModel paySummVM = GetPaymentData();

            //PayUMoney Gateway Code
            string key = ConfigurationManager.AppSettings["MERCHANT_KEY"];
            string salt= ConfigurationManager.AppSettings["SALT"];
            string paymentGatewayUrl = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";
            string[] hashVarsSeq= ConfigurationManager.AppSettings["hashSequence"].Split('|');
            string transactionId = GenerateTransactionId();
            string productInfo = GetProductInfo(paySummVM.ProductInfo);
            string amountToBePaid = Convert.ToDecimal(paySummVM.AmountToBePaid).ToString("g29");
            string responseUrl = GetBaseUrl() + Url.Action(MVC.Payment.ActionNames.PayUMoneyResponse, MVC.Payment.Name);
            string serviceProvider = "payu_paisa";
            string hashString = string.Empty;
            string hashValue = string.Empty;

            //Hash Value Calculation
            foreach (string hash_var in hashVarsSeq)
            {
                if (hash_var == "key")
                {
                    hashString = hashString + key;
                    hashString = hashString + '|';
                }
                else if (hash_var == "txnid")
                {
                    hashString = hashString + transactionId;
                    hashString = hashString + '|';
                }
                else if (hash_var == "amount")
                {
                    hashString = hashString + amountToBePaid;
                    hashString = hashString + '|';
                }
                else if (hash_var=="productinfo")
                {
                    hashString = hashString + productInfo;
                    hashString = hashString + '|';
                }
                else if (hash_var == "firstname")
                {
                    hashString = hashString + paySummVM.UserName;
                    hashString = hashString + '|';
                }
                else if (hash_var == "email")
                {
                    hashString = hashString + paySummVM.Email;
                    hashString = hashString + '|';
                }
                else
                {
                    hashString = hashString + '|';
                }
            }

            hashString += ConfigurationManager.AppSettings["SALT"];               //appending SALT
            hashValue = Crypto.Generatehash512(hashString).ToLower();         //generating hash

            // adding values in hash table for data post
            Hashtable data = new Hashtable();
            data.Add("hash", hashValue);
            data.Add("txnid", transactionId);
            data.Add("key", key);
            data.Add("amount", amountToBePaid);
            data.Add("firstname", paySummVM.UserName);
            data.Add("email", paySummVM.Email);
            data.Add("phone", paySummVM.MobileNumber);
            data.Add("productinfo", productInfo);
            data.Add("surl", responseUrl);
            data.Add("furl", responseUrl);
            data.Add("lastname", string.Empty);
            data.Add("curl", string.Empty);
            data.Add("address1", string.Empty);
            data.Add("address2", string.Empty);
            data.Add("city", string.Empty);
            data.Add("state", string.Empty);
            data.Add("country", string.Empty);
            data.Add("zipcode", string.Empty);
            data.Add("udf1", string.Empty);
            data.Add("udf2", string.Empty);
            data.Add("udf3", string.Empty);
            data.Add("udf4", string.Empty);
            data.Add("udf5", string.Empty);
            data.Add("pg", string.Empty);
            //data.Add("currency", "USD");
            data.Add("service_provider", serviceProvider);
            
            //Log the request
            TransactionDetail tranDetail = new TransactionDetail();
            tranDetail.TransactionID = transactionId;
            tranDetail.UserID = CurrentUser.UserID;
            tranDetail.TransactionRequest = ConvertHashTableToString(data);
            PaymentService.LogPaymentRequest(tranDetail);

            string strForm = PreparePOSTForm(paymentGatewayUrl, data);
            return Content(strForm);
        }

        public virtual ActionResult PayUMoneyResponse()
        {
            string strRequest = GetRequest(Request);
            string txnId = (Request.Form["txnid"] != null ? Request.Form["txnid"] : "");
            string hashReceived = (Request.Form["hash"] != null ? Request.Form["hash"] : "");
            string txnStatus = (Request.Form["status"] != null ? Request.Form["status"] : "");
            string payUMoneyId= (Request.Form["payuMoneyId"] != null ? Request.Form["payuMoneyId"] : "");
            string prodInfo = (Request.Form["productinfo"] != null ? Request.Form["productinfo"] : "");
            string tranMode = (Request.Form["mode"] != null ? Request.Form["mode"] : "");
            string amt = (Request.Form["amount"] != null ? Request.Form["amount"] : "");
            string nameOnCard = (Request.Form["name_on_card"] != null ? Request.Form["name_on_card"] : "");
            string maskedCardNum = (Request.Form["cardnum"] != null ? Request.Form["cardnum"] : "");
            string paymentId = (Request.Form["mihpayid"] != null ? Request.Form["mihpayid"] : "");
            string paymentIDEncrypted = (Request.Form["encryptedPaymentId"] != null ? Request.Form["encryptedPaymentId"] : "");
            string bnkCode = (Request.Form["bankcode"] != null ? Request.Form["bankcode"] : "");
            string bnkRefNum = (Request.Form["bank_ref_num"] != null ? Request.Form["bank_ref_num"] : "");

            string salt = ConfigurationManager.AppSettings["SALT"];

            //Log response against transaction id
            TransactionDetail tranDetail = PaymentService.GetAllTransaction().Where(tran => tran.TransactionID.Equals(txnId)).FirstOrDefault();
            tranDetail.TransactionResponse = strRequest;
            tranDetail.PayUMoneyID = payUMoneyId;
            tranDetail.TransactionMode = tranMode;
            tranDetail.TransactionStatus = txnStatus;
            tranDetail.NameOnCard = nameOnCard;
            tranDetail.PaymentId = paymentId;
            tranDetail.PaymentIdEncrypted = paymentIDEncrypted;
            tranDetail.MaskedCardNumber = maskedCardNum;
            tranDetail.BankCode = bnkRefNum;
            tranDetail.BankRefNumber = bnkRefNum; 
            tranDetail.Amount= Convert.ToDecimal(amt);
            PaymentService.LogPaymentResponse(tranDetail);


            //check response is valid by verifying hash value received
            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;

            if (txnStatus == "success")
            {
                merc_hash_vars_seq = ConfigurationManager.AppSettings["hashSequence"].Split('|');
                Array.Reverse(merc_hash_vars_seq);
                merc_hash_string = salt + "|" + txnStatus;

                foreach (string merc_hash_var in merc_hash_vars_seq)
                {
                    merc_hash_string += "|";
                    merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");
                }

                merc_hash = Crypto.Generatehash512(merc_hash_string).ToLower();

                if (merc_hash == hashReceived)
                {
                    //Insert order details if payment is done
                    //Insert product purchase details if payment is done
                    //Hash value matched
                    OrderDetail ordDetail = new OrderDetail();
                    ordDetail.TransactionID = txnId;
                    ordDetail.UserID = CurrentUser.UserID;
                    ordDetail.OrderInfo = prodInfo;
                    ordDetail.PaymentStatus = "PAID";
                    ordDetail.OrderTotal = Convert.ToDecimal(amt);
                    ordDetail.UserIPAddress = this.GetUserIPAddress();
                    PaymentService.CreateOrder(ordDetail);

                    //Empty cart
                    ShoppingCart userShoppingCart = ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).FirstOrDefault();
                    ShoppingCartService.RemoveAllItemsFromCart(userShoppingCart.ShoppingCartID);

                    //Successful
                    ViewBag.Message = WebConstant.OrderSuccessful;
                }
                else
                {
                    //Hash value did not matched
                    ViewBag.Message = WebConstant.SomethingWentWrong;
                }
            }
            else
            {
                //Hash value did not matched
                ViewBag.Message = WebConstant.OrderFailed;
            }

            return View();
        }

        [AuthorizeAction]
        public virtual ActionResult Details()
        {
            PaymentSummaryViewModel paySummVM = GetPaymentData();
            return View(paySummVM);
        }
        private PaymentSummaryViewModel GetPaymentData()
        {
            if (CurrentUser == null)
            {
                return null;
            }

            PaymentSummaryViewModel paySummaryVM = new PaymentSummaryViewModel();
            paySummaryVM.UserName = CurrentUser.UserName;
            paySummaryVM.Email = CurrentUser.EmailID;
            paySummaryVM.MobileNumber = CurrentUser.MobileNumber;

            ShoppingCart userShoppingCart = ShoppingCartService.GetAll().Where(x => x.UserID == CurrentUser.UserID).FirstOrDefault();
            List<int> productIds = ShoppingCartService.GetCartItems(userShoppingCart.ShoppingCartID).Select(x => x.ProductID).ToList();

            if (productIds.Count() == 0)
            {
                return null;
            }

            List<ProductMaster> lstCartProducts = CatalystService.GetAllProducts().Where(x => productIds.Contains(x.ProductID)).ToList();
            List<DiscountMaster> lstDiscounts = CatalystService.GetAllDiscounts().ToList();


            paySummaryVM.ProductInfo = lstCartProducts;
            paySummaryVM.SubTotal = lstCartProducts.Sum(x => x.Price);
            paySummaryVM.Discount = lstCartProducts.Sum(x => (x.Price * lstDiscounts.Where(y => y.DiscountID == x.DiscountID).Select(z => Convert.ToDecimal(z.Percentage)).FirstOrDefault()) / 100);
            paySummaryVM.AmountToBePaid = paySummaryVM.SubTotal - paySummaryVM.Discount - paySummaryVM.VAT;

            return paySummaryVM;
        }

        private string GenerateTransactionId()
        {
            Random rnd = new Random();
            string strHash = Crypto.Generatehash512(rnd.ToString() + DateTime.Now);
            return strHash.ToString().Substring(0, 20);
        }

        private string GetProductInfo(List<ProductMaster> lstProdList)
        {
            return string.Join(",", lstProdList.Select(p => p.ProductID.ToString()));
        }

        private string GetBaseUrl()
        {
            return new Uri(Request.Url, Url.Content("~")).ToString();
        }

        private string GetRequest(HttpRequestBase request)
        {
            string req = string.Empty;
            foreach (var item in Request.Form.Keys)
            {
                req += item.ToString() + ":-" + Request.Form[item.ToString()] + "|";
            }
            return req;
        }

        private string ConvertHashTableToString(Hashtable data)
        {
            string req = string.Empty;
            foreach (DictionaryEntry item in data)
            {
                req += item.Key + ":-" + item.Value + "|";
            }
            return req;
        }

        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }

    }
}
