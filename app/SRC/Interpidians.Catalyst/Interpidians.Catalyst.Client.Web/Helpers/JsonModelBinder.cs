using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public class JsonModelBinder : DefaultModelBinder
    {
        public override Object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var strJson = controllerContext.HttpContext.Request.Form[bindingContext.ModelName];
                if (string.IsNullOrEmpty(strJson))
                {
                    return null;
                }
                else
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var model = serializer.Deserialize(strJson, bindingContext.ModelType);
                    var modelMetaData = ModelMetadataProviders.Current
                                .GetMetadataForType(() => model, bindingContext.ModelType);
                    var validator = ModelValidator
                                .GetModelValidator(modelMetaData, controllerContext);
                    var validationResult = validator.Validate(null);
                    foreach (var item in validationResult)
                    {
                        bindingContext.ModelState
                                    .AddModelError(item.MemberName, item.Message);
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelType.Name, ex.Message);
                return null;
            }
        }

    }

    public class JsonBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }
    }
}