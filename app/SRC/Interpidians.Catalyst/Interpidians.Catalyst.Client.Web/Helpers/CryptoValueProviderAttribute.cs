using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CryptoValueProviderAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// The list of encrypted params
        /// </summary>
        List<string> listOfEncryptedParams = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoValueProviderAttribute" /> class.
        /// </summary>
        public CryptoValueProviderAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoValueProviderAttribute" /> class.
        /// </summary>
        /// <param name="encryptedParams">The encrypted params.</param>
        public CryptoValueProviderAttribute(string encryptedParams)
        {
            if (!string.IsNullOrEmpty(encryptedParams))
            {
                listOfEncryptedParams = encryptedParams.ToUpper().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        /// <summary>
        /// Called when authorization is required.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null)
                filterContext.Controller.ValueProvider = new CryptoValueProvider(filterContext.RouteData, filterContext.HttpContext.Request.Params, listOfEncryptedParams);
        }
    }
}