using Catalyst.Business.Model.ModMcqMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModMcqMaster
{
    public class McqMasterDataManager
    {
        public DataTable GetMcqList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllMcq");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetMcqListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@McqID",ID)
                };
                return DBOperate.GetDataTable("usp_GetMcqById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddMcqDetail(McqMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@TopicwisePaperID",obj.TopicwisePaperID),
                        new SqlParameter("@YearwisePaperID",obj.YearwisePaperID),                       
                        new SqlParameter("@QuestionText1",obj.QuestionText1),
                        new SqlParameter("@QuestionImageLink",obj.QuestionImageLink),
                        new SqlParameter("@QuestionImage2",obj.QuestionImage2),
                        new SqlParameter("@QuestionAudioLink",obj.QuestionAudioLink),
                        new SqlParameter("@CommonAnswerImage",obj.CommonAnswerImage),
                        new SqlParameter("@QuestionText2",obj.QuestionText2),                        
                        new SqlParameter("@HintText",obj.HintText),
                        new SqlParameter("@HintImageLink",obj.SolutionImageLink),
                        new SqlParameter("@HintAudioLink",obj.SolutionAudioLink),
                        new SqlParameter("@VideoLink",obj.VideoLink),
                        new SqlParameter("@VideoUrl",obj.VideoUrl),
                        new SqlParameter("@SupportedDocumentLink",obj.SupportedDocumentLink),
                        new SqlParameter("@SupportedDocumentLink2",obj.SupportedDocumentLink2),
                        new SqlParameter("@SupportedDocumentLink3",obj.SupportedDocumentLink3),
                        new SqlParameter("@Marks",obj.Marks),                        
                        new SqlParameter("@TimeToSolve",obj.TimeToSolve),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),                        
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddMcq", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateMcqDetail(McqMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@McqID",obj.McqID),                    
                        new SqlParameter("@TopicwisePaperID",obj.TopicwisePaperID),
                        new SqlParameter("@YearwisePaperID",obj.YearwisePaperID),                       
                        new SqlParameter("@QuestionText1",obj.QuestionText1),
                        new SqlParameter("@QuestionImageLink",obj.QuestionImageLink),
                        new SqlParameter("@QuestionImage2",obj.QuestionImage2),
                        new SqlParameter("@QuestionAudioLink",obj.QuestionAudioLink),
                        new SqlParameter("@CommonAnswerImage",obj.CommonAnswerImage),
                        new SqlParameter("@QuestionText2",obj.QuestionText2),                        
                        new SqlParameter("@HintText",obj.HintText),
                        new SqlParameter("@HintImageLink",obj.SolutionImageLink),
                        new SqlParameter("@HintAudioLink",obj.SolutionAudioLink),
                        new SqlParameter("@VideoLink",obj.VideoLink),
                        new SqlParameter("@VideoUrl",obj.VideoUrl),
                        new SqlParameter("@SupportedDocumentLink",obj.SupportedDocumentLink),
                        new SqlParameter("@SupportedDocumentLink2",obj.SupportedDocumentLink2),
                        new SqlParameter("@SupportedDocumentLink3",obj.SupportedDocumentLink3),
                        new SqlParameter("@Marks",obj.Marks),                        
                        new SqlParameter("@TimeToSolve",obj.TimeToSolve),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),                        
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                       
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateMcq", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteMcqDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@McqID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteMcq", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetMcqListwithPaperID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@PaperID",ID)
                };
                return DBOperate.GetDataTable("usp_GetMcqByPaperId", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
