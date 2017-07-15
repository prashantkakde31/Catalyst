using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Interpidians.Catalyst.Core.Utility;
using System.Globalization;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public sealed class CryptoValueProvider : IValueProvider
    {
        /// <summary>
        /// The route data
        /// </summary>
        RouteData routeData = null;
        /// <summary>
        /// The dictionary
        /// </summary>
        Dictionary<string, string> dictionary = null;

        /// <summary>
        /// The request params
        /// </summary>
        NameValueCollection requestParams = null;

        /// <summary>
        /// The list of encrypted params
        /// </summary>
        List<string> listOfEncryptedParams = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoValueProvider"/> class.
        /// </summary>
        /// <param name="routeData">The route data.</param>
        public CryptoValueProvider(RouteData routeData, NameValueCollection requestParams, List<string> listOfEncryptedParams)
        {
            this.routeData = routeData;
            this.requestParams = requestParams;
            this.listOfEncryptedParams = listOfEncryptedParams;
        }

        /// <summary>
        /// Determines whether the collection contains the specified prefix.
        /// </summary>
        /// <param name="prefix">The prefix to search for.</param>
        /// <returns>
        /// true if the collection contains the specified prefix; otherwise, false.
        /// </returns>
        public bool ContainsPrefix(string prefix)
        {
            bool returnValue = false;

            if (!string.IsNullOrEmpty(prefix) && this.routeData.Values["id"] != null)
            {
                this.dictionary = Crypto.DecryptInKeyValue(this.routeData.Values["id"].ToString());
                returnValue = this.dictionary.ContainsKey(prefix.ToUpper());

                if (!returnValue)
                {
                    if (!this.listOfEncryptedParams.Contains(prefix.ToUpper()) && this.requestParams != null)
                    {
                        returnValue = this.requestParams.AllKeys.Contains(prefix);
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Retrieves a value object using the specified key.
        /// </summary>
        /// <param name="key">The key of the value object to retrieve.</param>
        /// <returns>
        /// The value object for the specified key.
        /// </returns>
        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult valueProviderResult = null;

            if (!string.IsNullOrEmpty(key))
            {
                if (this.dictionary.ContainsKey(key.ToUpper()))
                    valueProviderResult = new ValueProviderResult(this.dictionary[key.ToUpper()], this.dictionary[key.ToUpper()], CultureInfo.CurrentCulture);
                else
                    valueProviderResult = new ValueProviderResult(this.requestParams[key], this.requestParams[key], CultureInfo.CurrentCulture);
            }

            return valueProviderResult;
        }
    }
}