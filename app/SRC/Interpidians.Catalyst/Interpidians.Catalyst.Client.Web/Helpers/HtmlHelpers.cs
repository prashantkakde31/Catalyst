using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public static class HtmlHelpers
	{
        public static MvcHtmlString RenderAttrIf(this HtmlHelper helper, string name, string value, Func<bool> condition = null)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                return MvcHtmlString.Empty;
            }

            var render = condition != null ? condition() : true;

            return render ?
                new MvcHtmlString(string.Format("{0}=\"{1}\"", name, HttpUtility.HtmlAttributeEncode(value))) :
                MvcHtmlString.Empty;
        }
	}
}