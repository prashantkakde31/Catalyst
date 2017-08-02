using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Business.Model.ModMcqMaster
{
    public class McqMaster
    {
        public int McqID;

        public int TopicwisePaperID;

        public int YearwisePaperID;

        public string QuestionText1;

        public string QuestionText2;

        public string QuestionImageLink;

        public string QuestionImage2;

        public string QuestionAudioLink;

        public string CommonAnswerImage;

        public int CorrectAnswerID;

        public string HintText;

        public string SolutionImageLink;

        public string SolutionAudioLink;

        public string VideoLink;

        public string VideoUrl;

        public int Marks;

        public string SupportedDocumentLink;

        public string SupportedDocumentLink2;

        public string SupportedDocumentLink3;

        public TimeSpan TimeToSolve;

        public int CreatedBy;

        public int UpdatedBy;
    }
}
