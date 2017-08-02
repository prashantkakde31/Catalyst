using Catalyst.Business.Model.ModPaperMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModGradeMaster;
using Catalyst.DataAccess.DataManagers.ModPaperMaster;
using Catalyst.DataAccess.DataManagers.ModSubCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubjectMaster;
using Catalyst.DataAccess.DataManagers.ModTopicMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Paper_Master : System.Web.UI.Page
    {
        PaperMaster obj;
        PaperMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdown();
                bind(ddlSubject.SelectedValue);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void grdSubjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPaperMaster.PageIndex = e.NewPageIndex;
            bind(ddlSubject.SelectedValue);
        }

        protected void grdSubjectMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Paper")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdPaperMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new PaperMasterDataManager();
                obj1.DeletePaperDetail(id);
                Clear();
                bind(ddlSubject.SelectedValue);
                msgbox("Paper Deleted successfully!!!");
            }
            if (e.CommandName == "Disable_QUESTION")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdPaperMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                LinkButton btn = ((LinkButton)e.CommandSource);

                obj1 = new PaperMasterDataManager();
                obj1.DisablePaperDetail(id, btn.Text.ToUpper().Equals("DISABLE QUESTION") ? "QUESTION" : "NONE");
                Clear();
                bind(ddlSubject.SelectedValue);
                msgbox("Paper Question Enabled/Disabled successfully!!!");
            }
            if (e.CommandName == "Disable_HELP")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdPaperMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                LinkButton btn = ((LinkButton)e.CommandSource);

                obj1 = new PaperMasterDataManager();
                obj1.DisablePaperDetail(id, btn.Text.ToUpper().Equals("DISABLE HELP") ? "ANSWER" : "NONE");
                Clear();
                bind(ddlSubject.SelectedValue);
                msgbox("Paper help Enabled/Disabled successfully!!!");
            }
            if (e.CommandName == "Disable_BOTH")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdPaperMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                LinkButton btn = ((LinkButton)e.CommandSource);

                obj1 = new PaperMasterDataManager();
                obj1.DisablePaperDetail(id, btn.Text.ToUpper().Equals("DISABLE BOTH") ? "BOTH" : "NONE");
                Clear();
                bind(ddlSubject.SelectedValue);
                msgbox("Paper question and help Enabled/Disabled successfully!!!");
            }
        }

        protected void grdSubjectMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BindDropdown();
            GridViewRow grid = grdPaperMaster.Rows[e.NewSelectedIndex];
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourse")).Text;
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
            ddlSubject.SelectedValue = ((Label)grid.FindControl("lblSubjectID")).Text;
            lblPaperID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            //BindDropdown3(Convert.ToInt16(ddlSubject.SelectedValue), ddlSubject.SelectedItem.Text);
            //ddlTopic.SelectedValue = ((Label)grid.FindControl("lblTopicID")).Text;
            txtYear.Text = ((Label)grid.FindControl("lblYear")).Text;
            chkYearwise.Checked = ((Label)grid.FindControl("lblYearWise")).Text.ToUpper().Equals("TRUE") ? true : false;
            chkSample.Checked = ((Label)grid.FindControl("lblIsSample")).Text.ToUpper().Equals("TRUE") ? true : false;
            txtMonth.Text = ((Label)grid.FindControl("lblMonth")).Text;
        }

        //private void BindDropdown3(int id, string subject)
        //{
        //    ddlTopic.Items.Clear();
        //    if (new TopicMasterDataManager().GetTopicsWithSubjectID(id).Rows.Count > 0)
        //    {
        //        ddlTopic.DataSource = new TopicMasterDataManager().GetTopicsWithSubjectID(id);
        //        ddlTopic.DataTextField = "Name";
        //        ddlTopic.DataValueField = "TopicID";
        //        ddlTopic.DataBind();
        //    }
        //    else
        //    {
        //        msgbox("No Topics Found for subject :" + subject);
        //    }
        //    ddlTopic.Items.Insert(0, new ListItem("Select", "0"));
        //}

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
        }

        private void Clear()
        {
            lblPaperID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";
            chkYearwise.Checked = false;
            chkSample.Checked = false;
        }
        private void bind(string id)
        {
            if (id.Equals("0") || string.IsNullOrEmpty(id))
            {
                grdPaperMaster.DataSource = null;
            }
            else
            {
                obj1 = new PaperMasterDataManager();
                grdPaperMaster.DataSource = obj1.GetPaperListWithSubjectID(Convert.ToInt16(id));
            }
            grdPaperMaster.DataBind();
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(ddlSubject.SelectedValue);
        }

        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void btnAddPaper_Click(object sender, EventArgs e)
        {
            //   System.Threading.Thread.Sleep(5000);
            obj = new PaperMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            obj.SubjectId = Convert.ToInt16(ddlSubject.SelectedValue);
            //obj.TopicID = Convert.ToInt16(ddlTopic.SelectedValue);
            obj.GradeID = 0;
            obj.Year = Convert.ToInt16(txtYear.Text);
            obj.Month = Convert.ToInt16(txtMonth.Text);
            obj.IsYearwise = chkYearwise.Checked == true ? 1 : 0;
            obj.IsSample = chkSample.Checked == true ? 1 : 0;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.PaperID = Convert.ToInt16(lblPaperID.Text);
            if (lblPaperID.Text.Equals("-1"))
            {
                obj1 = new PaperMasterDataManager();
                obj1.AddPaperDetail(obj);
                msgbox("Paper Added successfully!!!");
            }
            else
            {
                obj1 = new PaperMasterDataManager();
                obj1.UpdatePaperDetail(obj);
                msgbox("Paper updated successfully!!!");
            }
            Clear();
            BindDropdown();
            bind(ddlSubject.SelectedValue);
        }

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            Clear();
        }

        protected void grdPaperMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblSubjectID");
                Label lbl2 = (Label)e.Row.FindControl("lblSubjectName");
                DataTable dt = new SubjectMasterDataManager().GetSubjectListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                if (((Label)e.Row.FindControl("lblDisable")).Text.ToUpper().Equals("QUESTION"))
                    ((LinkButton)e.Row.FindControl("btnDisable_Question")).Text = "Enable Question";
                else
                    ((LinkButton)e.Row.FindControl("btnDisable_Question")).Text = "Disable Question";

                if (((Label)e.Row.FindControl("lblDisable")).Text.ToUpper().Equals("ANSWER"))
                    ((LinkButton)e.Row.FindControl("btnDisable_HELP")).Text = "Enable Help";
                else
                    ((LinkButton)e.Row.FindControl("btnDisable_HELP")).Text = "Disable Help";
                if (((Label)e.Row.FindControl("lblDisable")).Text.ToUpper().Equals("BOTH"))
                    ((LinkButton)e.Row.FindControl("btnDisable_Both")).Text = "Enable Both";
                else
                    ((LinkButton)e.Row.FindControl("btnDisable_Both")).Text = "Disable Both";

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

        protected void ddlSubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
        }

    }
}