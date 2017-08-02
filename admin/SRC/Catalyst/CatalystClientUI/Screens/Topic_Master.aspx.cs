using Catalyst.Business.Model.ModTopicMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
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
    public partial class Topic_Master : System.Web.UI.Page
    {
        TopicMaster obj;
        TopicMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdown();
                bind(ddlSubject.SelectedValue);
            }
        }

        protected void grdTopicMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTopicMaster.PageIndex = e.NewPageIndex;
            bind(ddlSubject.SelectedValue);
        }

        protected void grdTopicMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Topic")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdTopicMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new TopicMasterDataManager();
                obj1.DeleteTopicDetail(id);
                Clear();
                bind(ddlSubject.SelectedValue);
                msgbox("Topic Deleted successfully!!!");
            }
        }

        protected void grdTopicMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BindDropdown();
            GridViewRow grid = grdTopicMaster.Rows[e.NewSelectedIndex];
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourse")).Text;
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
            ddlSubject.SelectedValue = ((Label)grid.FindControl("lblSubject")).Text;
            lblTopicID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            ddlSubject.SelectedValue = ((Label)grid.FindControl("lblSubject")).Text;
        }

        protected void btnAddTopic_Click(object sender, EventArgs e)
        {
            obj = new TopicMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            obj.SubjectID = Convert.ToInt16(ddlSubject.SelectedValue);
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.TopicID = Convert.ToInt16(lblTopicID.Text);
            if (lblTopicID.Text.Equals("-1"))
            {
                obj1 = new TopicMasterDataManager();
                obj1.AddTopicDetail(obj);
                msgbox("Topic Added successfully!!!");
            }
            else
            {
                obj1 = new TopicMasterDataManager();
                obj1.UpdateTopicDetail(obj);
                msgbox("Topic updated successfully!!!");
            }
            Clear();
            BindDropdown();
            bind(ddlSubject.SelectedValue);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblTopicID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
        }
        private void bind(string id)
        {
            if (id.Equals("0") || string.IsNullOrEmpty(id))
            {
                grdTopicMaster.DataSource = null;
            }
            else
            {
                obj1 = new TopicMasterDataManager();
                grdTopicMaster.DataSource = obj1.GetTopicsWithSubjectID(Convert.ToInt16(id));
            }
            grdTopicMaster.DataBind();
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

        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdTopicMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblSubject");
                Label lbl2 = (Label)e.Row.FindControl("lblSubjectName");

                DataTable dt = new SubjectMasterDataManager().GetSubjectListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }
                dt = new SubjectMasterDataManager().GetSubCourseListWithSubjectID(Convert.ToInt16(lbl1.Text));
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

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
        }

        protected void ddlSubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
        }
        
        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(ddlSubject.SelectedValue);
        }
    }
}