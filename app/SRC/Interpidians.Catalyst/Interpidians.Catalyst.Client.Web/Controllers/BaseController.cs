using Interpidians.Catalyst.Client.Web.Common;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.DependencyResolution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public ISessionStore sessionStore { get; set; }

        public BaseController()
        {
            this.sessionStore = new SessionStore();
        }

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    try
        //    {
        //        Exception ex = filterContext.Exception;
        //        filterContext.ExceptionHandled = true;
        //        var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");


        //        //Add Error model to ViewData
        //         filterContext.Controller.ViewData.Add("Error",model);


        //        filterContext.Result = new ViewResult()
        //        {
        //            ViewName = MVC.Error.Views.ViewNames.Error,
        //            ViewData = filterContext.Controller.ViewData,
        //            TempData = filterContext.Controller.TempData
        //        };

        //        filterContext.ExceptionHandled = true;
        //        filterContext.HttpContext.Response.Clear();

        //        if (filterContext.Exception.GetType() == typeof(HttpException))
        //        {
        //            HttpException exception = filterContext.Exception as HttpException;
        //            filterContext.HttpContext.Response.StatusCode = exception.GetHttpCode();
        //        }
        //        else
        //        {
        //            filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        //        }

        //        filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {
                Exception ex = filterContext.Exception;
                ILogger Logger = DependencyConfiguration.Instance.GetInstance<ILogger>();
                Logger.Error(ex.ToString());

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Renders the specified controller.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string Render(ControllerBase controller, string viewName, object model)
        {
            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Use this method to return List<T> from csv
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csv"></param>
        /// <param name="seperatior"></param>
        /// <returns></returns>
        public List<T> CSVToList<T>(string csv, char seperatior)
        {
            return csv.Split(seperatior).Cast<T>().ToList();
        }


        /// <summary>
        /// Use this method to return List<NameValueData> from csv
        /// </summary>
        /// <param name="csv"></param>
        /// <param name="seperatior1"></param>
        /// <param name="seperator2"></param>
        /// <returns></returns>
        public List<NameValueData> CSVToNameValueData(string csv, char seperatior1 = ';', char seperator2 = ':')
        {
            NameValueData objNV = new NameValueData();
            List<NameValueData> lstNV = new List<NameValueData>();

            if (!string.IsNullOrEmpty(csv) && csv.IndexOf(seperatior1) >= 0)
            {
                List<string> lstStr = CSVToList<string>(csv, seperatior1);

                for (int i = 0; i < lstStr.Count; i++)
                {
                    if (lstStr[i].IndexOf(':') >= 0)
                    {
                        objNV = new NameValueData();
                        List<string> s = CSVToList<string>(lstStr[i], seperator2);
                        objNV.Name = s[0];
                        objNV.Value = s[1];
                        lstNV.Add(objNV);
                    }
                }
            }
            return lstNV;
        }


        /// <summary>
        /// Gets the upload document path.
        /// </summary>
        /// <value>
        /// The upload document path.
        /// </value>
        public string UploadDocumentPath
        {
            get
            {
                return Request.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["DocumentDirectory"]);
            }
        }

        /// <summary>
        /// Method used to upload file from file uploader
        /// </summary>
        /// <value>
        /// Directory Path for Directory Upload and FileName for the upload File .
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public bool FileUpload(string directoryPath, out string fileNamePramas)
        {
            try
            {
                string fileName = string.Empty;
                if (Request.QueryString["qqfile"] != null)
                    fileName = Request.QueryString["qqfile"];
                else
                    fileName = Path.GetFileName(Request.Files["qqfile"].FileName);

                string guid = Guid.NewGuid().ToString();
                string[] prefix = guid.Split('-');
                if (prefix.Length > 0)
                    fileName = prefix[0] + fileName;
                if (!System.IO.Directory.Exists(directoryPath))
                    System.IO.Directory.CreateDirectory(directoryPath);

                Stream inputStream = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase httpPostedFileBase = Request.Files[0];
                    inputStream = httpPostedFileBase.InputStream;
                }
                else
                {
                    inputStream = Request.InputStream;
                }
                fileNamePramas = fileName;
                using (FileStream ms = new FileStream(directoryPath + "\\" + fileName, FileMode.OpenOrCreate))
                {
                    int bread = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[2048]; //2KB buffer
                        bread = inputStream.Read(buffer, 0, buffer.Length);
                        if (bread > 0)
                            ms.Write(buffer, 0, bread);

                        if (bread <= 0)
                            break;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                fileNamePramas = "";
                return false;
            }
        }
    }
}
