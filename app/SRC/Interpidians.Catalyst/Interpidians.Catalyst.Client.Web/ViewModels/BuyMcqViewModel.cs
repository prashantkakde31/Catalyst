using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class BuyMcqViewModel
    {
        public BuyMcqViewModel()
        {
            TopicList = new List<ProductMaster>();
            PaperList = new List<ProductMaster>();
            SubjectList = new List<SubjectMaster>();
        }
        public List<ProductMaster> TopicList { get; set; }
        public List<ProductMaster> PaperList { get; set; }
        public List<SubjectMaster> SubjectList { get; set; }
    }
}