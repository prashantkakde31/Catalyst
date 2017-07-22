using Interpidians.Catalyst.Core.ApplicationService;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.DependencyResolution;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public class CourseDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private IMcqService McqService { get; set; }

        public CourseDetailsDynamicNodeProvider()
        {
            this.McqService = DependencyConfiguration.Instance.GetInstance<IMcqService>();
        }

        //public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        //{
        //    var courses = this.McqService.getAllCourses();
        //    var subCourses = this.McqService.getAllSubCourses();
        //    var subjects = this.McqService.GetAllSubjects();
        //    Dictionary<string, string> dict = new Dictionary<string, string>();

        //    foreach (var course in courses.Where(course=>course.IsVisible == true && course.CourseID == 4))
        //    {
        //        foreach (var subCourse in subCourses.Where(x => x.SubCourseID == course.CourseID && x.IsVisible == true))
        //        {
        //            foreach (var subject in subjects.Where(y => y.SubCourseID == subCourse.SubCourseID && y.IsVisible == true))
        //            {
        //                string s= "Sample_" + course.Name.Replace(" ", "") + "_" + subCourse.Name.Replace(" ", "") + "_" + subject.Name.Replace(" ", "");
        //                DynamicNode dynamicNode = new DynamicNode();
        //                dynamicNode.Title = "Sample_" + course.Name.Replace(" ","") + "_" + subCourse.Name.Replace(" ", "") + "_" + subject.Name.Replace(" ", "");
        //                //dynamicNode.ParentKey = "SampleMcq";
        //                dynamicNode.RouteValues.Add("course", course.Name);
        //                dynamicNode.RouteValues.Add("subcourse", subCourse.Name);
        //                dynamicNode.RouteValues.Add("subject", subject.Name);
        //                //dict.Add(dynamicNode.ParentKey,"1");
        //                yield return dynamicNode;
        //            }

        //        }
        //    }
        //}

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var courses = this.McqService.getAllCourses();

            foreach (var course in courses.Where(course => course.IsVisible == true))
            {
                DynamicNode dynamicNode = new DynamicNode("Course_" + course.Name,course.Name);
                dynamicNode.Clickable = false;
                yield return dynamicNode;

            }
        }
    }

    public class SubCourseDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private IMcqService McqService { get; set; }
        public SubCourseDetailsDynamicNodeProvider()
        {
            this.McqService = DependencyConfiguration.Instance.GetInstance<IMcqService>();
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var courses = this.McqService.getAllCourses();
            var subCourses = this.McqService.getAllSubCourses();

            foreach (var subCourse in subCourses.Where(course => course.IsVisible == true))
            {
                DynamicNode dynamicNode = new DynamicNode("SubCourse_"+ subCourse.Name, subCourse.Name);
                dynamicNode.ParentKey = "Course_" + courses.Where(x=>x.CourseID == subCourse.CourseID).Select(y=>y.Name).SingleOrDefault();
                dynamicNode.Clickable = false;
                yield return dynamicNode;

            }
        }
    }

    public class SubjectDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private IMcqService McqService { get; set; }
        public SubjectDetailsDynamicNodeProvider()
        {
            this.McqService = DependencyConfiguration.Instance.GetInstance<IMcqService>();
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var subCourses = this.McqService.getAllSubCourses();
            var subjects = this.McqService.GetAllSubjects();

            foreach (var subject in subjects.Where(course => course.IsVisible == true))
            {
                string subCourseName = subCourses.Where(x => x.SubCourseID == subject.SubCourseID).Select(y => y.Name).SingleOrDefault();
                DynamicNode dynamicNode = new DynamicNode("Subject_" + subCourseName + "_" + subject.Name, subject.Name);
                dynamicNode.ParentKey = "SubCourse_" + subCourses.Where(x => x.SubCourseID == subject.SubCourseID).Select(y => y.Name).SingleOrDefault();
                dynamicNode.Clickable = false;
                yield return dynamicNode;

            }
        }
    }

    public class MenuDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private IMcqService McqService { get; set; }
        public MenuDetailsDynamicNodeProvider()
        {
            this.McqService = DependencyConfiguration.Instance.GetInstance<IMcqService>();
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var courses = this.McqService.getAllCourses();
            var subCourses = this.McqService.getAllSubCourses();
            var subjects = this.McqService.GetAllSubjects();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var course in courses.Where(course => course.IsVisible == true))
            {
                foreach (var subCourse in subCourses.Where(x => x.CourseID == course.CourseID && x.IsVisible == true))
                {
                    foreach (var subject in subjects.Where(y => y.SubCourseID == subCourse.SubCourseID && y.IsVisible == true && subCourse.CourseID == course.CourseID))
                    {
                        string comboMenu = course.Name.Replace(" ", "") + "_" + subCourse.Name.Replace(" ", "") + "_" + subject.Name.Replace(" ", "");
                        DynamicNode dynamicNode = new DynamicNode("Menu_"+comboMenu, "MCQ");
                        dynamicNode.ParentKey = "Subject_" + subCourse.Name + "_"+ subject.Name;
                        dynamicNode.Controller = "Mcq";
                        dynamicNode.Action = "Sample";
                        dynamicNode.RouteValues.Add("course", course.Name);
                        dynamicNode.RouteValues.Add("subcourse", subCourse.Name);
                        dynamicNode.RouteValues.Add("subject", subject.Name);
                        yield return dynamicNode;
                    }

                }
            }
        }
    }
}