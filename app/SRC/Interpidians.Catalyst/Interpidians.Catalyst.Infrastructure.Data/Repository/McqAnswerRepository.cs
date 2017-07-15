using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class McqAnswerRepository : BaseRepository,IMcqAnswerRepository
    {
        private List<McqAnswer> _mcqanswers;
        //public McqAnswerRepository()
        //{
        //    _mcqanswers = new List<McqAnswer>() 
        //    {
        //        new McqAnswer{McqAnswerID=1,McqID=1,SN="B",AnswerType="Text",Answer="V and W",IsVisible=true},
        //        new McqAnswer{McqAnswerID=2,McqID=2,SN="C",AnswerType="Text",Answer="5.0 cm",IsVisible=true},
        //        new McqAnswer{McqAnswerID=3,McqID=3,SN="D",AnswerType="Text",Answer="",IsVisible=true},
        //        new McqAnswer{McqAnswerID=4,McqID=4,SN="A",AnswerType="Text",Answer="measuring cylinder, ruler and thermometer",IsVisible=true},
        //        new McqAnswer{McqAnswerID=5,McqID=5,SN="A",AnswerType="Image",Answer="Uploads\\MCQ\\Images\\Phy-q-4-A.PNG",IsVisible=true},
        //        new McqAnswer{McqAnswerID=6,McqID=6,SN="B",AnswerType="Text",Answer="27 m",IsVisible=true},
        //        new McqAnswer{McqAnswerID=7,McqID=7,SN="C",AnswerType="Image",Answer="Uploads\\MCQ\\Images\\Phy-q-6-C.PNG",IsVisible=true},
        //        new McqAnswer{McqAnswerID=8,McqID=8,SN="D",AnswerType="Text",Answer="0.58 N",IsVisible=true},
        //        new McqAnswer{McqAnswerID=9,McqID=9,SN="A",AnswerType="Image",Answer="Uploads\\MCQ\\Images\\Phy-q-9-A.PNG",IsVisible=true},
        //        new McqAnswer{McqAnswerID=10,McqID=10,SN="B",AnswerType="Text",Answer="q",IsVisible=true},
        //    };
        //}
        public IEnumerable<McqAnswer> GetAll()
        {
            //return _mcqanswers; ;
            IEnumerable<McqAnswer> lstMcqAnswer;
            lstMcqAnswer = this.DB.ExecuteSprocAccessor<McqAnswer>("usp_GetAllMcqAnswer");
            return lstMcqAnswer;
        }

        public McqAnswer GetById(IdentifiableData id)
        {
            return _mcqanswers.Where<McqAnswer>(x => x.McqID == id.LId).SingleOrDefault<McqAnswer>();
        }

        public void Add(McqAnswer mcqAns)
        {
            _mcqanswers.Add(mcqAns);
        }

        public void Update(McqAnswer mcqAns)
        {
            _mcqanswers.Where<McqAnswer>(x => x.McqID == mcqAns.McqID).ToList().ForEach(x => x = mcqAns);
        }

        public void Delete(IdentifiableData id)
        {
            _mcqanswers.RemoveAll(x => x.McqID == id.LId);
        }
    }
}
