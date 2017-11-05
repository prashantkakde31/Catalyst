using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public static class ModelValidation
    {
        public static void CleanAllBut(this ModelStateDictionary modelState,params string[] includes)
        {
            modelState
              .Where(x => !includes
                 .Any(i => String.Compare(i, x.Key, true) == 0))
              .ToList()
              .ForEach(k => modelState.Remove(k));
        }
    }
}