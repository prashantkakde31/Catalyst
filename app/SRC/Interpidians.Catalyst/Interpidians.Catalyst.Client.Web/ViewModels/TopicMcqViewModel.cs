using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class TopicMcqViewModel
    {
        public TopicMcqViewModel()
        {
            SubjectList = new List<SubjectMaster>();
            McqList = new List<Mcq>();
        }
        public List<SubjectMaster> SubjectList { get; set; }
        public List<Mcq> McqList { get; set; }
    }
}