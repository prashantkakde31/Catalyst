using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class SampleMcqViewModel
    {
        public SampleMcqViewModel()
        {
            TopicWiseList = new List<TopicMaster>();
            PaperWiseList = new List<PaperMaster>();
            SubjectList = new List<SubjectMaster>();
        }
        public List<TopicMaster> TopicWiseList { get; set; }
        public List<PaperMaster> PaperWiseList { get; set; }
        public List<SubjectMaster> SubjectList { get; set; }
    }
   
}