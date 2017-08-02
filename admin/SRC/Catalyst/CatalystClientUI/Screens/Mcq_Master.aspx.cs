using Catalyst.Business.Model.ModAnswerMaster;
using Catalyst.Business.Model.ModMcqMaster;
using Catalyst.DataAccess.DataManagers.ModAnswerMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModMcqMaster;
using Catalyst.DataAccess.DataManagers.ModPaperMaster;
using Catalyst.DataAccess.DataManagers.ModSubCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubjectMaster;
using Catalyst.DataAccess.DataManagers.ModTopicMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Mcq_Master : System.Web.UI.Page
    {

        McqMaster obj;
        McqMasterDataManager obj1;
        AnswerMaster obj2;
        AnswerMasterDataManager obj3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdown();
                bind(ddlYearPaper.SelectedValue.ToString());
            }
        }

        protected void ddlTopicPaper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdMcqMater_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BindDropdown();
            GridViewRow grid = grdMcqMater.Rows[e.NewSelectedIndex];
            lblMcqID.Text = ((Label)grid.FindControl("lblID")).Text;
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourse")).Text;
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
            ddlSubject.SelectedValue = ((Label)grid.FindControl("lblSubjectID")).Text;
            txtText1.Text = ((Label)grid.FindControl("lblQuestion")).Text;
            txtQuestionText2.Text = ((Label)grid.FindControl("lblQuestion2")).Text;
            txtSolution.Text = ((Label)grid.FindControl("lblHint")).Text;
            txtMarks.Text = ((Label)grid.FindControl("lblMarks")).Text;
            txtTime.Text = ((Label)grid.FindControl("lblTime")).Text;
            BindDropdown3(Convert.ToInt16(ddlSubject.SelectedValue), ddlSubject.SelectedItem.Text);
            ddlTopicPaper.SelectedValue = ((Label)grid.FindControl("lblTopicID")).Text;
            ddlYearPaper.SelectedValue = ((Label)grid.FindControl("lblPaperId")).Text;
            QuestionImageLink.Text = ((Label)grid.FindControl("GrdQuestionImage")).Text;
            QuestionImageLink2.Text = ((Label)grid.FindControl("GrdQuestionImage2")).Text;
            QuestionAudioLink.Text = ((Label)grid.FindControl("QuestionAudioLink")).Text;
            SolutionImageLink.Text = ((Label)grid.FindControl("SolutionImageUrl")).Text;
            HintAudioLink.Text = ((Label)grid.FindControl("HintAudioLink")).Text;
            VideoLink.Text = ((Label)grid.FindControl("VideoLink")).Text;
            txtVideoUrl.Text = ((Label)grid.FindControl("VideoUrl")).Text;
            VideoUrl.Text = ((Label)grid.FindControl("VideoUrl")).Text;
            CommonAns.Text = ((Label)grid.FindControl("CommonAnswerImage")).Text;
            SupportedDocumentLink.Text = ((Label)grid.FindControl("SupportedDocumentLink")).Text;
            SupportedDocumentLink2.Text = ((Label)grid.FindControl("SupportedDocumentLink2")).Text;
            SupportedDocumentLink3.Text = ((Label)grid.FindControl("SupportedDocumentLink3")).Text;
            PreviewCommonAnswer.ImageUrl = string.IsNullOrEmpty(CommonAns.Text) ? "../Images/image.jpg" : "../Upload/CommonAnswer/" + CommonAns.Text;
            PreviewQuestion.ImageUrl = string.IsNullOrEmpty(QuestionImageLink.Text) ? "../Images/image.jpg" : "../Upload/QuestionImage/" + QuestionImageLink.Text;
            PreviewQuestion2.ImageUrl = string.IsNullOrEmpty(QuestionImageLink2.Text) ? "../Images/image.jpg" : "../Upload/QuestionImage/" + QuestionImageLink2.Text;
            PreviewSolutionImage.ImageUrl = string.IsNullOrEmpty(SolutionImageLink.Text) ? "../Images/image.jpg" : "../Upload/SolutionImage/" + SolutionImageLink.Text;

            if (new AnswerMasterDataManager().GetAnswerListWithMcqID(Convert.ToInt16(lblMcqID.Text)).Rows.Count > 0)
            {
                obj3 = new AnswerMasterDataManager();
                DataTable dt = obj3.GetAnswerListWithMcqID(Convert.ToInt16(lblMcqID.Text));
                lblAnswerID1.Text = Convert.ToString(dt.Rows[0]["McqAnswerID"]);

                if (((Label)grid.FindControl("lblCorrectAnswer")).Text.Equals(lblAnswerID1.Text))
                    opt1.Checked = true;
                txtAnswer1.Text = Convert.ToString(dt.Rows[0]["Answer"]);
                lblAnswer1.Text = Convert.ToString(dt.Rows[0]["AnswerImage"]);
                PreviewAnswerImage1.ImageUrl = string.IsNullOrEmpty(lblAnswer1.Text) ? "../Images/image.jpg" : "../Upload/AnswerImage/" + lblAnswer1.Text;
                AnswerType.Value = Convert.ToString(dt.Rows[0]["AnswerType"]);

                lblAnswerID2.Text = Convert.ToString(dt.Rows[1]["McqAnswerID"]);
                if (((Label)grid.FindControl("lblCorrectAnswer")).Text.Equals(lblAnswerID2.Text))
                    opt2.Checked = true;
                txtAnswer2.Text = Convert.ToString(dt.Rows[1]["Answer"]);
                lblAnswer2.Text = Convert.ToString(dt.Rows[1]["AnswerImage"]);
                PreviewAnswerImage2.ImageUrl = string.IsNullOrEmpty(lblAnswer2.Text) ? "../Images/image.jpg" : "../Upload/AnswerImage/" + lblAnswer2.Text;

                lblAnswerID3.Text = Convert.ToString(dt.Rows[2]["McqAnswerID"]);
                if (((Label)grid.FindControl("lblCorrectAnswer")).Text.Equals(lblAnswerID3.Text))
                    opt3.Checked = true;
                txtAnswer3.Text = Convert.ToString(dt.Rows[2]["Answer"]);
                lblAnswer3.Text = Convert.ToString(dt.Rows[2]["AnswerImage"]);
                PreviewAnswerImage3.ImageUrl = string.IsNullOrEmpty(lblAnswer3.Text) ? "../Images/image.jpg" : "../Upload/AnswerImage/" + lblAnswer3.Text;

                lblAnswerID4.Text = Convert.ToString(dt.Rows[3]["McqAnswerID"]);
                if (((Label)grid.FindControl("lblCorrectAnswer")).Text.Equals(lblAnswerID4.Text))
                    opt4.Checked = true;
                txtAnswer4.Text = Convert.ToString(dt.Rows[3]["Answer"]);
                lblAnswer4.Text = Convert.ToString(dt.Rows[3]["AnswerImage"]);
                PreviewAnswerImage4.ImageUrl = string.IsNullOrEmpty(lblAnswer4.Text) ? "../Images/image.jpg" : "../Upload/AnswerImage/" + lblAnswer4.Text;
            }
        }

        protected void grdMcqMater_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Question")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdMcqMater.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new McqMasterDataManager();
                obj1.DeleteMcqDetail(id);
                Clear();
                bind(ddlYearPaper.SelectedValue.ToString());
                msgbox("Mcq Deleted successfully!!!");
            }
        }

        protected void grdMcqMater_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMcqMater.PageIndex = e.NewPageIndex;
            bind(ddlYearPaper.SelectedValue.ToString());
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
            string filename, extension, filepath;
            if (!opt1.Checked && !opt2.Checked && !opt3.Checked && !opt4.Checked)
            {
                msgbox("Select atleast one correct Answer");
                return;
            }

            if (CommonAnswer.HasFile || !string.IsNullOrEmpty(CommonAns.Text))
            {
                if (!string.IsNullOrEmpty(txtAnswer1.Text) || !string.IsNullOrEmpty(txtAnswer2.Text) || !string.IsNullOrEmpty(txtAnswer3.Text) || !string.IsNullOrEmpty(txtAnswer4.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'For Common Answer image no need of answer text or image'});", true);
                    return;
                }
                if (!string.IsNullOrEmpty(lblAnswer1.Text) || AnswerImage1.HasFile)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'For Common Answer image no need of answer text or image'});", true);
                    return;
                }
                if (!string.IsNullOrEmpty(lblAnswer2.Text) || AnswerImage2.HasFile)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'For Common Answer image no need of answer text or image'});", true);
                    return;
                }
                if (!string.IsNullOrEmpty(lblAnswer3.Text) || AnswerImage3.HasFile)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'For Common Answer image no need of answer text or image'});", true);
                    return;
                }
                if (!string.IsNullOrEmpty(lblAnswer4.Text) || AnswerImage4.HasFile)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'For Common Answer image no need of answer text or image'});", true);
                    return;
                }
            }

            if (!CommonAnswer.HasFile && string.IsNullOrEmpty(CommonAns.Text))
            {
                if (!string.IsNullOrEmpty(txtAnswer1.Text) && !string.IsNullOrEmpty(txtAnswer2.Text) && !string.IsNullOrEmpty(txtAnswer3.Text) && !string.IsNullOrEmpty(txtAnswer4.Text))
                {

                }
                else
                {
                    if (string.IsNullOrEmpty(lblAnswer1.Text) && !AnswerImage1.HasFile)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Answer can be either image or text or common image'});", true);
                        //Tell.text("Client details validation fails", this);
                        Page.Validate("ValidationGroup2");
                        return;
                    }
                    if (string.IsNullOrEmpty(lblAnswer2.Text) && !AnswerImage2.HasFile)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Answer can be either image or text or common image'});", true);
                        //Tell.text("Client details validation fails", this);
                        Page.Validate("ValidationGroup2");
                        return;
                    }
                    if (string.IsNullOrEmpty(lblAnswer3.Text) && !AnswerImage3.HasFile)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Answer can be either image or text or common image'});", true);
                        //Tell.text("Client details validation fails", this);
                        Page.Validate("ValidationGroup2");
                        return;
                    }
                    if (string.IsNullOrEmpty(lblAnswer3.Text) && !AnswerImage3.HasFile)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Answer can be either image or text or common image'});", true);
                        //Tell.text("Client details validation fails", this);
                        Page.Validate("ValidationGroup2");
                        return;
                    }
                }
            }
            if (CommonAnswer.HasFile || !string.IsNullOrEmpty(CommonAns.Text))
                AnswerType.Value = "NONE";
            else
            {
                if (!string.IsNullOrEmpty(txtAnswer1.Text))
                    AnswerType.Value = "TEXT";
                else
                    AnswerType.Value = "IMAGE";
            }



            if (QuestionImage.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(QuestionImage.PostedFile.FileName);
                extension = Path.GetExtension(QuestionImage.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/QuestionImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    QuestionImage.PostedFile.SaveAs(filepath);
                QuestionImageLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (QuestionImage2.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(QuestionImage2.PostedFile.FileName);
                extension = Path.GetExtension(QuestionImage2.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/QuestionImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    QuestionImage2.PostedFile.SaveAs(filepath);
                QuestionImageLink2.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (QuestionAudio.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(QuestionAudio.PostedFile.FileName);
                extension = Path.GetExtension(QuestionAudio.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/QuestionAudio") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    QuestionAudio.PostedFile.SaveAs(filepath);
                QuestionAudioLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (SolutionImage.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(SolutionImage.PostedFile.FileName);
                extension = Path.GetExtension(SolutionImage.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    SolutionImage.PostedFile.SaveAs(filepath);
                SolutionImageLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (HintAudio.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(HintAudio.PostedFile.FileName);
                extension = Path.GetExtension(HintAudio.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionAudio") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    HintAudio.PostedFile.SaveAs(filepath);
                HintAudioLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (HintVideo.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(HintVideo.PostedFile.FileName);
                extension = Path.GetExtension(HintVideo.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionVideo") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    HintVideo.PostedFile.SaveAs(filepath);
                VideoLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (document.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(document.PostedFile.FileName);
                extension = Path.GetExtension(document.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionDocument") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    document.PostedFile.SaveAs(filepath);
                SupportedDocumentLink.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (document2.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(document2.PostedFile.FileName);
                extension = Path.GetExtension(document2.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionDocument") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    document2.PostedFile.SaveAs(filepath);
                SupportedDocumentLink2.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (document3.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(document3.PostedFile.FileName);
                extension = Path.GetExtension(document3.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/SolutionDocument") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    document3.PostedFile.SaveAs(filepath);
                SupportedDocumentLink3.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (CommonAnswer.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(CommonAnswer.PostedFile.FileName);
                extension = Path.GetExtension(CommonAnswer.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/CommonAnswer") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    CommonAnswer.PostedFile.SaveAs(filepath);
                CommonAns.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (AnswerImage1.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(AnswerImage1.PostedFile.FileName);
                extension = Path.GetExtension(AnswerImage1.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/AnswerImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    AnswerImage1.PostedFile.SaveAs(filepath);
                lblAnswer1.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (AnswerImage2.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(AnswerImage2.PostedFile.FileName);
                extension = Path.GetExtension(AnswerImage2.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/AnswerImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    AnswerImage2.PostedFile.SaveAs(filepath);
                lblAnswer2.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (AnswerImage3.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(AnswerImage3.PostedFile.FileName);
                extension = Path.GetExtension(AnswerImage3.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/AnswerImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    AnswerImage3.PostedFile.SaveAs(filepath);
                lblAnswer3.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }
            if (AnswerImage4.HasFile)
            {
                filename = Path.GetFileNameWithoutExtension(AnswerImage4.PostedFile.FileName);
                extension = Path.GetExtension(AnswerImage4.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/AnswerImage") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                else
                    AnswerImage4.PostedFile.SaveAs(filepath);
                lblAnswer4.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }

            obj = new McqMaster();
            obj.TopicwisePaperID = Convert.ToInt16(ddlTopicPaper.SelectedValue);
            obj.YearwisePaperID = Convert.ToInt16(ddlYearPaper.SelectedValue);
            obj.QuestionText1 = txtText1.Text;
            obj.QuestionText2 = txtQuestionText2.Text;
            obj.HintText = txtSolution.Text;
            obj.VideoUrl = txtVideoUrl.Text;
            obj.Marks = Convert.ToInt16("0" + txtMarks.Text);
            obj.TimeToSolve = new TimeSpan(Convert.ToInt16(txtTime.Text.Split(':')[0]), Convert.ToInt16(txtTime.Text.Split(':')[1]), Convert.ToInt16(txtTime.Text.Split(':')[2]));
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.McqID = Convert.ToInt16(lblMcqID.Text);
            if (lblMcqID.Text.Equals("-1"))
            {
                obj.QuestionImageLink = QuestionImageLink.Text;
                obj.QuestionImage2 = QuestionImageLink2.Text;
                obj.QuestionAudioLink = QuestionAudioLink.Text;
                obj.SolutionImageLink = SolutionImageLink.Text;
                obj.SolutionAudioLink = HintAudioLink.Text;
                obj.VideoLink = VideoLink.Text;
                obj.SupportedDocumentLink = SupportedDocumentLink.Text;
                obj.SupportedDocumentLink2 = SupportedDocumentLink2.Text;
                obj.SupportedDocumentLink3 = SupportedDocumentLink3.Text;
                obj.CommonAnswerImage = CommonAns.Text;
                obj1 = new McqMasterDataManager();
                obj1.AddMcqDetail(obj);

                //Adding Answer 1
                obj2 = new AnswerMaster();
                obj2.Answer = txtAnswer1.Text;
                obj2.SN = "a";
                obj2.McqID = 0;
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer1.Text;
                obj2.Correct = opt1.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.AddAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.Answer = txtAnswer2.Text;
                obj2.SN = "b";
                obj2.McqID = 0;
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer2.Text;
                obj2.Correct = opt2.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.AddAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.Answer = txtAnswer3.Text;
                obj2.SN = "c";
                obj2.McqID = 0;
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer3.Text;
                obj2.Correct = opt3.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.AddAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.Answer = txtAnswer4.Text;
                obj2.SN = "d";
                obj2.McqID = 0;
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer4.Text;
                obj2.Correct = opt4.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.AddAnswerDetail(obj2);
                msgbox("Mcq Added successfully!!!");
            }
            else
            {
                obj.QuestionImageLink = QuestionImageLink.Text;
                obj.QuestionImage2 = QuestionImageLink2.Text;
                obj.QuestionAudioLink = QuestionAudioLink.Text;
                obj.SolutionImageLink = SolutionImageLink.Text;
                obj.SolutionAudioLink = HintAudioLink.Text;
                obj.VideoLink = VideoLink.Text;
                obj.SupportedDocumentLink = SupportedDocumentLink.Text;
                obj.SupportedDocumentLink2 = SupportedDocumentLink2.Text;
                obj.SupportedDocumentLink3 = SupportedDocumentLink3.Text;
                obj.CommonAnswerImage = CommonAns.Text;
                obj1 = new McqMasterDataManager();
                obj1.UpdateMcqDetail(obj);

                //Adding Answer 1
                obj2 = new AnswerMaster();
                obj2.McqAnswerID = Convert.ToInt16("0" + lblAnswerID1.Text);
                obj2.Answer = txtAnswer1.Text;
                obj2.SN = "a";
                obj2.McqID = Convert.ToInt16("0" + lblMcqID.Text);
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer1.Text;
                obj2.Correct = opt1.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.UpdateAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.McqAnswerID = Convert.ToInt16("0" + lblAnswerID2.Text);
                obj2.Answer = txtAnswer2.Text;
                obj2.SN = "b";
                obj2.McqID = Convert.ToInt16("0" + lblMcqID.Text);
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer2.Text;
                obj2.Correct = opt2.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.UpdateAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.Answer = txtAnswer3.Text;
                obj2.McqAnswerID = Convert.ToInt16("0" + lblAnswerID3.Text);
                obj2.SN = "c";
                obj2.McqID = Convert.ToInt16("0" + lblMcqID.Text);
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer3.Text;
                obj2.Correct = opt3.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.UpdateAnswerDetail(obj2);

                obj2 = new AnswerMaster();
                obj2.McqAnswerID = Convert.ToInt16("0" + lblAnswerID4.Text);
                obj2.Answer = txtAnswer4.Text;
                obj2.SN = "d";
                obj2.McqID = Convert.ToInt16("0" + lblMcqID.Text);
                obj2.AnswerType = AnswerType.Value;
                obj2.AnswerImage = lblAnswer4.Text;
                obj2.Correct = opt4.Checked ? 1 : 0;
                obj3 = new AnswerMasterDataManager();
                obj3.UpdateAnswerDetail(obj2);
                msgbox("Mcq updated successfully!!!");
            }
            Clear();
            bind(ddlYearPaper.SelectedValue.ToString());
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        private void BindDropdown3(int id, string subject)
        {
            ddlTopicPaper.Items.Clear();
            if (new TopicMasterDataManager().GetTopicsWithSubjectID(id).Rows.Count > 0)
            {
                ddlTopicPaper.DataSource = new TopicMasterDataManager().GetTopicsWithSubjectID(id);
                ddlTopicPaper.DataTextField = "Name";
                ddlTopicPaper.DataValueField = "TopicID";
                ddlTopicPaper.DataBind();
            }
            else
            {
                msgbox("No Topics Found for subject :" + subject);
            }
            ddlTopicPaper.Items.Insert(0, new ListItem("Select", "0"));

            if (new PaperMasterDataManager().GetPaperListWithSubjectID(id).Rows.Count > 0)
            {
                ddlYearPaper.DataSource = new PaperMasterDataManager().GetPaperListWithSubjectID(id);
                ddlYearPaper.DataTextField = "Name";
                ddlYearPaper.DataValueField = "PaperID";
                ddlYearPaper.DataBind();
            }
            else
            {
                msgbox("No Paper Found for subject :" + subject);
            }
            ddlYearPaper.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void BindDropdown2(Int32 id, string subCourse)
        {
            ddlSubject.Items.Clear();
            if (new SubjectMasterDataManager().GetSubjectListWithSubCourseID(id).Rows.Count > 0)
            {
                ddlSubject.DataSource = new SubjectMasterDataManager().GetSubjectListWithSubCourseID(id);
                ddlSubject.DataTextField = "Name";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
            }
            else
            {
                msgbox("No Subject Found for Sub Course :" + subCourse);
            }
            ddlSubject.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void BindDropdown(Int32 id, string course)
        {
            ddlSubCourse.Items.Clear();
            if (new SubCourseMasterDataManager().GetSubCourseListWithCourseID(id).Rows.Count > 0)
            {
                ddlSubCourse.DataSource = new SubCourseMasterDataManager().GetSubCourseListWithCourseID(id);
                ddlSubCourse.DataTextField = "Name";
                ddlSubCourse.DataValueField = "SubCourseID";
                ddlSubCourse.DataBind();
            }
            else
            {
                msgbox("No SubCourse Found for Course :" + course);
            }
            ddlSubCourse.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void BindDropdown()
        {
            ddlCourse.Items.Clear();
            ddlCourse.DataSource = new CourseMasterDataManager().GetCourseList();
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("Select", "0"));

            if (new PaperMasterDataManager().GetPaperList().Rows.Count > 0)
            {
                ddlYearPaper.DataSource = new PaperMasterDataManager().GetPaperList();
                ddlYearPaper.DataTextField = "Name";
                ddlYearPaper.DataValueField = "PaperID";
                ddlYearPaper.DataBind();
            }
            else
            {
                msgbox("No Paper Found");
            }
            ddlYearPaper.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void bind(string id)
        {
            if (id.Equals("0"))
            {
                grdMcqMater.DataSource = null;
            }
            else
            {
                obj1 = new McqMasterDataManager();
                grdMcqMater.DataSource = obj1.GetMcqListwithPaperID(Convert.ToInt16(id));
            }
            grdMcqMater.DataBind();
        }

        private void Clear()
        {
            lblMcqID.Text = "-1";
            QuestionImageLink.Text = "";
            QuestionAudioLink.Text = "";
            SolutionImageLink.Text = "";
            HintAudioLink.Text = "";
            VideoLink.Text = "";
            SupportedDocumentLink.Text = "";
            SupportedDocumentLink2.Text = "";
            SupportedDocumentLink3.Text = "";
            txtVideoUrl.Text = "";
            lblAnswerID1.Text = "";
            lblAnswerID2.Text = "";
            lblAnswerID3.Text = "";
            lblAnswerID4.Text = "";
            txtAnswer1.Text = "";
            txtAnswer2.Text = "";
            txtAnswer3.Text = "";
            txtAnswer4.Text = "";
            txtVideoUrl.Text = "";
            CommonAns.Text = "";
            lblAnswer1.Text = "";
            lblAnswer2.Text = "";
            lblAnswer3.Text = "";
            lblAnswer4.Text = "";
            txtText1.Text = "";
            txtQuestionText2.Text = "";
            txtMarks.Text = "";
            txtSolution.Text = "";
            PreviewCommonAnswer.ImageUrl = "../Images/image.jpg";
            PreviewQuestion.ImageUrl = "../Images/image.jpg";
            PreviewAnswerImage1.ImageUrl = "../Images/image.jpg";
            PreviewAnswerImage2.ImageUrl = "../Images/image.jpg";
            PreviewAnswerImage3.ImageUrl = "../Images/image.jpg";
            PreviewAnswerImage4.ImageUrl = "../Images/image.jpg";
            PreviewSolutionImage.ImageUrl = "../Images/image.jpg";
        }

        protected void grdMcqMater_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblTopicId");
                Label lbl2 = (Label)e.Row.FindControl("lblTopicName");

                Label lbl3 = (Label)e.Row.FindControl("lblPaperId");
                Label lbl4 = (Label)e.Row.FindControl("lblPaperName");

                DataTable dt = new TopicMasterDataManager().GetTopicListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new PaperMasterDataManager().GetPaperListWithID(Convert.ToInt32(lbl3.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl4.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new SubjectMasterDataManager().GetSubjectListWithTopicID(Convert.ToInt32(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("lblSubjectID")).Text = Convert.ToString(dt.Rows[0]["SubjectID"]);
                    ((Label)e.Row.FindControl("lblSubjectName")).Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new SubjectMasterDataManager().GetSubCourseListWithSubjectID(Convert.ToInt16(((Label)e.Row.FindControl("lblSubjectID")).Text));
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("lblSubCourse")).Text = Convert.ToString(dt.Rows[0]["SubCourseID"]);
                    ((Label)e.Row.FindControl("lblSubCourseName")).Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new SubCourseMasterDataManager().GetCourseListWithSubCourseID(Convert.ToInt16(((Label)e.Row.FindControl("lblSubCourse")).Text));
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("lblCourse")).Text = Convert.ToString(dt.Rows[0]["CourseID"]);
                    ((Label)e.Row.FindControl("lblCourseName")).Text = Convert.ToString(dt.Rows[0]["Name"]);
                }
            }
        }

        protected bool IsGroupValid(string sValidationGroup)
        {
            foreach (BaseValidator validator in Page.Validators)
            {
                if (validator.ValidationGroup == sValidationGroup)
                {
                    bool fValid = validator.IsValid;
                    if (fValid)
                    {
                        validator.Validate();
                        fValid = validator.IsValid;
                        validator.IsValid = true;
                    }
                    if (!fValid)
                        return false;
                }

            }
            return true;
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(Convert.ToInt16(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
        }

        protected void ddlSubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown2(Convert.ToInt16(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown3(Convert.ToInt16(ddlSubject.SelectedValue), ddlSubject.SelectedItem.Text);
        }

        protected void ddlYearPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(ddlYearPaper.SelectedValue);
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            PreviewQuestion.ImageUrl = "../Images/image.jpg";
            QuestionImageLink.Text = string.Empty;
        }

        protected void btnClear2_Click(object sender, EventArgs e)
        {
            PreviewCommonAnswer.ImageUrl = "../Images/image.jpg";
            CommonAns.Text = string.Empty;
        }

        protected void btnClear3_Click(object sender, EventArgs e)
        {
            PreviewSolutionImage.ImageUrl = "../Images/image.jpg";
            SolutionImageLink.Text = string.Empty;
        }

        protected void btnAnswerClear1_Click(object sender, EventArgs e)
        {
            PreviewAnswerImage1.ImageUrl = "../Images/image.jpg";
            lblAnswer1.Text = string.Empty;
        }
        protected void btnAnswerClear2_Click(object sender, EventArgs e)
        {
            PreviewAnswerImage2.ImageUrl = "../Images/image.jpg";
            lblAnswer2.Text = string.Empty;
        }

        protected void btnAnswerClear3_Click(object sender, EventArgs e)
        {
            PreviewAnswerImage3.ImageUrl = "../Images/image.jpg";
            lblAnswer3.Text = string.Empty;
        }

        protected void btnAnswerClear4_Click(object sender, EventArgs e)
        {
            PreviewAnswerImage4.ImageUrl = "../Images/image.jpg";
            lblAnswer4.Text = string.Empty;
        }

        protected void btnClear4_Click(object sender, EventArgs e)
        {
            PreviewQuestion2.ImageUrl = "../Images/image.jpg";
            QuestionImageLink2.Text = string.Empty;
        }


    }
}