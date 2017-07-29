using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interpidians.Catalyst.Client.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });


            //Load mcq sample based on course, subcourse and subject
            routes.MapRoute(
                name: "McqSample",
                url: "Mcq/Sample/{course}/{subcourse}/{subject}",
                defaults: new { controller = "Mcq", action = "Sample", course = UrlParameter.Optional, subcourse = UrlParameter.Optional, subject = UrlParameter.Optional }
            );

            //Load mcq questions based on topic
            routes.MapRoute(
                name: "McqQuestionsTopicwise",
                url: "Mcq/Topic/{id}",
                defaults: new { controller = "Mcq", action = "Topic", id = UrlParameter.Optional }
            );

            //Load mcq questions based on paper
            routes.MapRoute(
                name: "McqQuestionsPaperwise",
                url: "Mcq/Questions/Paper/{id}",
                defaults: new { controller = "Mcq", action = "Paper", id = UrlParameter.Optional }
            );

            //Load exam paper based on paper Id
            routes.MapRoute(
                name: "ExamPaper",
                url: "Exam/Paper/{id}",
                defaults: new { controller = "Exam", action = "Paper", id = UrlParameter.Optional }
            );

            //Start exam based on paper Id
            routes.MapRoute(
                name: "ExamPaperStart",
                url: "Exam/Start/{id}",
                defaults: new { controller = "Exam", action = "Start", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "login", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Exam", action = "Paper", id = UrlParameter.Optional }
            //);
        }
    }
}