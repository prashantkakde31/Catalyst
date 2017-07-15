using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public class DateTimeModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// Binds the model by using the specified controller context and binding context.
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
        /// <returns>
        /// The bound object.
        /// </returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //ISessionStore sessionStore = new SessionStore();
            //var displayFormat = sessionStore.GetItemFromSession<LoginUserInformation>(SessionKeys.USERDETAILS).UserInformation.DateFormat;

            var displayFormat = "dd-MMM-yyyy HH:mm:ss";
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (!string.IsNullOrEmpty(displayFormat) && value != null)
            {
                DateTime date;
                // use the format specified in the DisplayFormat attribute to parse the date
                if (DateTime.TryParseExact(value.AttemptedValue, displayFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    if (string.IsNullOrEmpty(value.AttemptedValue))
                        return null;
                    bindingContext.ModelState.AddModelError(
                        bindingContext.ModelName,
                        string.Format("{0} is an invalid date format", value.AttemptedValue)
                    );
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }

    }
}